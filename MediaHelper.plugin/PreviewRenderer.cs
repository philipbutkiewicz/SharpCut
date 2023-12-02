using SDL2;
using SharpCutCommon.Video;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace MediaHelper.plugin
{
    public class PreviewRenderer : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets the current frame index.
        /// </summary>
        public int CurrentFrameIndex
        {
            get { return currentFrameIndex; }
        }

        /// <summary>
        /// Gets or sets the frame rendering interval.
        /// </summary>
        public double FrameInterval
        {
            get { return frameInterval; }
            set { frameInterval = value; }
        }

        /// <summary>
        /// Gets or sets frameskip.
        /// </summary>
        public int FrameSkip
        {
            get { return frameSkip;  }
            set { frameSkip = value;  }
        }

        #endregion

        #region Events

        /// <summary>
        /// Called when the textures have finished loading.
        /// </summary>
        public event EventHandler TexturesLoaded;

        /// <summary>
        /// Called when the end of render task is reached (every frame).
        /// </summary>
        public event EventHandler<RenderTaskEndedEventArgs> RenderTaskEnded;

        #endregion

        #region Event args

        public class RenderTaskEndedEventArgs : EventArgs
        {
            public double FrameTime = 0;

            public double RenderTaskTime = 0;
        }

        #endregion

        #region Fields - refs

        /// <summary>
        /// Reference to the SDL window.
        /// </summary>
        private IntPtr sdlWindow;

        /// <summary>
        /// Reference to the SDL renderer.
        /// </summary>
        private IntPtr sdlRenderer;

        /// <summary>
        /// Reference to the SDL_ttf font.
        /// </summary>
        private IntPtr sdlFont;

        /// <summary>
        /// Stopwatch that keeps track of frametime for accurate rendering interval.
        /// </summary>
        private Stopwatch frameTimeStopwatch = new Stopwatch();

        /// <summary>
        /// All loaded frames (as SDL textures).
        /// </summary>
        private List<IntPtr> sdlTextures = new List<IntPtr>();

        /// <summary>
        /// SharpCut project reference.
        /// </summary>
        private Project project;

        /// <summary>
        /// Main window bounds (ref).
        /// </summary>
        private Rectangle mainWindowBounds;

        private Dispatcher currentDispatcher = Dispatcher.CurrentDispatcher;

        #endregion

        #region Fields - flags

        /// <summary>
        /// Has SDL initialized?
        /// </summary>
        private bool sdlInitialized = false;

        /// <summary>
        /// Are we currently rendering?
        /// </summary>
        private bool isRendering = false;

        private bool isErrored = false;

        private bool finishedLoadingPreviewFrames = false;

        #endregion

        #region Fields - values

        /// <summary>
        /// Current frame index.
        /// </summary>
        private int currentFrameIndex = 0;

        /// <summary>
        /// Frame rendering interval.
        /// </summary>
        private double frameInterval = 16.666;

        /// <summary>
        /// Frame skip.
        /// </summary>
        private int frameSkip = 0;

        /// <summary>
        /// Preview loading progress.
        /// </summary>
        private float previewLoadingProgress = 0f;

        /// <summary>
        /// SDl font color.
        /// </summary>
        private SDL.SDL_Color sdlFontColor = new SDL.SDL_Color();

        /// <summary>
        /// SDl font shadow color.
        /// </summary>
        private SDL.SDL_Color sdlFontShadowColor = new SDL.SDL_Color();

        private string errorString = "";

        #endregion

        #region Public methods

        public PreviewRenderer(Rectangle _mainWindowBounds)
        {
            mainWindowBounds = _mainWindowBounds;

            sdlFontColor.r = 255;
            sdlFontColor.g = 255;
            sdlFontColor.b = 255;
            sdlFontColor.a = 255;

            sdlFontShadowColor.r = 0;
            sdlFontShadowColor.g = 0;
            sdlFontShadowColor.b = 0;
            sdlFontShadowColor.a = 50;
        }

        public void LoadProject(Project _project)
        {
            if (project != null)
            {
                project.LoadPreviewFramesProgress -= project_LoadPreviewFramesProgress;
                project.LoadPreviewFramesCompleted -= project_LoadPreviewFramesCompleted;

                if (finishedLoadingPreviewFrames)
                {
                    DestroyTextures();
                }
            }

            project = _project;

            project.LoadPreviewFramesProgress += project_LoadPreviewFramesProgress;
            project.LoadPreviewFramesCompleted += project_LoadPreviewFramesCompleted;

            LoadPreviewFramesAndTextures();
        }

        /// <summary>
        /// Disposes of this object gracefully.
        /// </summary>
        public void Dispose()
        {
            if (project != null)
            {
                project.LoadPreviewFramesProgress -= project_LoadPreviewFramesProgress;
                project.LoadPreviewFramesCompleted -= project_LoadPreviewFramesCompleted;
            }

            DestroyTextures();
            DestroySDL();
        }

        /// <summary>
        /// Initializes SDL, loads textures and starts rendering.
        /// </summary>
        public void StartRendering()
        {
            InitializeSDL();
        }

        /// <summary>
        /// Sets the position of the SDL window.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetWindowPosition(int x, int y)
        {
            SDL.SDL_SetWindowPosition(sdlWindow, x, y);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Initialize SDL.
        /// </summary>
        private void InitializeSDL()
        {
            Console.WriteLine("Initializing SDL...");
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
            {
                MessageBox.Show(Properties.Resources.SDLInitFailed);
                Environment.Exit(0);
            }

            Console.WriteLine("Initializing SDL window and renderer...");
            SDL.SDL_SetHint(SDL.SDL_HINT_RENDER_SCALE_QUALITY, "2");
            sdlWindow = SDL.SDL_CreateWindow(
                Properties.Resources.PreviewWindowTitle,
                mainWindowBounds.X + 8,
                mainWindowBounds.Y + mainWindowBounds.Height + 32,
                mainWindowBounds.Width, 480, SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE);

            sdlRenderer = SDL.SDL_CreateRenderer(sdlWindow, 0, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
            SDL.SDL_SetRenderDrawBlendMode(sdlRenderer, SDL.SDL_BlendMode.SDL_BLENDMODE_BLEND);

            SDL_ttf.TTF_Init();
            sdlFont = SDL_ttf.TTF_OpenFont(Path.Combine(Path.Combine(SharpCutPlugin.AssemblyDirectory, "Resources"), Path.Combine("Fonts", "NotoSans-Regular.ttf")), 12);

            sdlInitialized = true;
        }

        /// <summary>
        /// Gracefully destroys SDL.
        /// </summary>
        private void DestroySDL()
        {
            if (!sdlInitialized) return;

            finishedLoadingPreviewFrames = false;
            sdlInitialized = false;
            isRendering = false;

            Console.WriteLine("Destroying SDL...");

            SDL.SDL_DestroyRenderer(sdlRenderer);
            SDL.SDL_DestroyWindow(sdlWindow);
            SDL.SDL_Quit();

            Console.WriteLine("Garbage collecting SDL...");
            GC.Collect();

            SDL_ttf.TTF_CloseFont(sdlFont);
            SDL_ttf.TTF_Quit();
        }

        /// <summary>
        /// Load preview frames and textures.
        /// </summary>
        private void LoadPreviewFramesAndTextures()
        {
            Console.WriteLine("Loading frames...");
            project.LoadPreviewFrames();
        }

        /// <summary>
        /// Loads textures and changes the window size.
        /// </summary>
        private void LoadTextures()
        {
            Console.WriteLine("Loading textures...");
            int bitmapWidth = 0;
            int bitmapHeight = 0;

            Console.WriteLine($"Loading {project.PreviewFrames.Count} textures");
            for (int i = 0; i < project.PreviewFrames.Count; i++)
            {
                using (Bitmap bitmap = (Bitmap)project.PreviewFrames[i])
                {
                    bitmapWidth = bitmap.Width;
                    bitmapHeight = bitmap.Height;

                    BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                    IntPtr hBitmap = bitmapData.Scan0;

                    IntPtr surface = SDL.SDL_CreateRGBSurfaceFrom(hBitmap, bitmap.Width, bitmap.Height, 24, bitmapData.Stride, 0, 0, 0, 0);

                    IntPtr texture = SDL.SDL_CreateTextureFromSurface(sdlRenderer, surface);

                    sdlTextures.Add(texture);

                    SDL.SDL_FreeSurface(surface);

                    bitmap.UnlockBits(bitmapData);
                }

                GC.Collect();
            }

            Console.WriteLine($"Window size is {(int)(bitmapWidth * 1.5f)}, {(int)(bitmapHeight * 1.5f)}");
            SDL.SDL_SetWindowSize(sdlWindow, (int)(bitmapWidth * 1.5f), (int)(bitmapHeight * 1.5f));

            finishedLoadingPreviewFrames = true;

            TexturesLoaded?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Stops rendering, resets the current frame index and destroys loaded textures.
        /// </summary>
        private void DestroyTextures()
        {
            finishedLoadingPreviewFrames = false;
            currentFrameIndex = 0;

            if (sdlTextures.Count > 0)
            {
                Console.WriteLine("Destroying textures...");
                foreach (IntPtr texture in sdlTextures)
                {
                    if (texture != IntPtr.Zero)
                        Console.WriteLine("Destroying texture");
                        SDL.SDL_DestroyTexture(texture);
                }

                sdlTextures.Clear();
            }

            if (project != null)
            {
                project.PreviewFrames.Clear();
            }

            GC.Collect();
        }

        /// <summary>
        /// Async render task caller. Begins rendering.
        /// </summary>
        private void RenderTaskAsync()
        {
            Console.WriteLine("Start rendering");
            isRendering = true;
            Task.Run(RenderTask);
        }

        /// <summary>
        /// The rendering task.
        /// </summary>
        private void RenderTask()
        {
            Stopwatch renderTaskStopwatch = new Stopwatch();

            double renderTaskTime = 0d;
            double frameTime = 0d;

            while (isRendering)
            {
                if (sdlInitialized)
                {
                    renderTaskStopwatch.Start();

                    SDL.SDL_RenderClear(sdlRenderer);

                    SDL.SDL_Rect fillRect = new SDL.SDL_Rect();
                    fillRect.x = 0;
                    fillRect.y = 0;
                    fillRect.w = mainWindowBounds.Width;
                    fillRect.h = mainWindowBounds.Height;

                    byte r, g, b, a;
                    SDL.SDL_GetRenderDrawColor(sdlRenderer, out r, out g, out b, out a);
                    SDL.SDL_SetRenderDrawColor(sdlRenderer, 0, 0, 0, 127);

                    SDL.SDL_RenderFillRect(sdlRenderer, ref fillRect);
                    SDL.SDL_SetRenderDrawColor(sdlRenderer, r,g,b,a);
                    if (finishedLoadingPreviewFrames)
                    {
                        if (frameTimeStopwatch.IsRunning && frameTimeStopwatch.Elapsed.TotalMilliseconds >= frameInterval)
                        {
                            frameTime = frameTimeStopwatch.Elapsed.TotalMilliseconds;

                            int offset = 1 + frameSkip;
                            if (currentFrameIndex < (project.PreviewFrames.Count - offset))
                            {
                                currentFrameIndex += offset;
                            }
                            else
                            {
                                currentFrameIndex = 0;
                            }

                            frameTimeStopwatch.Stop();
                            frameTimeStopwatch.Reset();
                        }
                        else
                        {
                            frameTimeStopwatch.Start();
                        }

                        if (currentFrameIndex <= sdlTextures.Count)
                        {
                            IntPtr texture = sdlTextures[currentFrameIndex];
                            if (texture != IntPtr.Zero)
                                SDL.SDL_RenderCopy(sdlRenderer, texture, IntPtr.Zero, IntPtr.Zero);

                            RenderBar(currentFrameIndex == 0 ? 0 : (float)currentFrameIndex / (float)project.PreviewFrames.Count, Color.CornflowerBlue);
                        }
                    }

                    if (previewLoadingProgress > 0f && previewLoadingProgress < 1f)
                    {
                        RenderBar(previewLoadingProgress, Color.Purple);
                    }

                    renderTaskTime = renderTaskStopwatch.Elapsed.TotalMilliseconds;
                    renderTaskStopwatch.Stop();
                    renderTaskStopwatch.Reset();

                    if (isErrored)
                    {
                        RenderText(4, 30, $"An error occurred while loading preview data: {errorString}");
                    }

                    RenderText(4, 10, $"Render thread: {Math.Round(renderTaskTime, 2)} ms, Frametime: {Math.Round(frameTime, 2)} ms");

                    SDL.SDL_RenderPresent(sdlRenderer);

                    RenderTaskEnded?.Invoke(this, new RenderTaskEndedEventArgs()
                    {
                        FrameTime = frameTime,
                        RenderTaskTime = renderTaskTime
                    });
                }
            }
        }

        /// <summary>
        /// Renders the top progress bar.
        /// </summary>
        /// <param name="percent"></param>
        /// <param name="color"></param>
        private void RenderBar(float percent, Color color)
        {
            int w, h = 0;
            SDL.SDL_GetWindowSize(sdlWindow, out w, out h);

            byte r, g, b, a;
            SDL.SDL_GetRenderDrawColor(sdlRenderer, out r, out g, out b, out a);
            SDL.SDL_SetRenderDrawColor(sdlRenderer, color.R, color.G, color.B, 127);

            SDL.SDL_Rect rect = new SDL.SDL_Rect();
            rect.w = (int)(percent * w);
            rect.h = 8;

            SDL.SDL_RenderFillRect(sdlRenderer, ref rect);

            SDL.SDL_SetRenderDrawColor(sdlRenderer, r, g, b, a);
        }

        /// <summary>
        /// Renders text.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        private void RenderText(int x, int y, string text)
        {
            int w, h = 0;
            SDL_ttf.TTF_SizeUTF8(sdlFont, text, out w, out h);

            IntPtr textSurface = SDL_ttf.TTF_RenderUTF8_Blended(sdlFont, text, sdlFontColor);
            IntPtr textTexture = SDL.SDL_CreateTextureFromSurface(sdlRenderer, textSurface);
            SDL.SDL_FreeSurface(textSurface);

            IntPtr shadowSurface = SDL_ttf.TTF_RenderUTF8_Blended(sdlFont, text, sdlFontShadowColor);
            IntPtr shadowTexture = SDL.SDL_CreateTextureFromSurface(sdlRenderer, shadowSurface);
            SDL.SDL_FreeSurface(shadowSurface);

            SDL.SDL_Rect rect = new SDL.SDL_Rect()
            {
                x = x,
                y = y,
                w = w,
                h = h
            };

            SDL.SDL_Rect shadowRect = new SDL.SDL_Rect()
            {
                x = x + 2,
                y = y + 2,
                w = w,
                h = h
            };

            SDL.SDL_RenderCopy(sdlRenderer, shadowTexture, IntPtr.Zero, ref shadowRect);
            SDL.SDL_RenderCopy(sdlRenderer, textTexture, IntPtr.Zero, ref rect);

            if (shadowTexture != IntPtr.Zero)
                SDL.SDL_DestroyTexture(shadowTexture);

            if (textTexture != IntPtr.Zero)
                SDL.SDL_DestroyTexture(textTexture);
        }

        #endregion

        #region Event handlers

        private void project_LoadPreviewFramesProgress(object sender, Project.LoadPreviewFramesProgressEventArgs e)
        {
            previewLoadingProgress = e.Progress;
        }

        private void project_LoadPreviewFramesCompleted(object sender, Project.LoadPreviewFramesCompletedEventArgs e)
        {
            if (!e.Success)
            {
                isErrored = true;
                errorString = e.ErrorMessage;
                RenderTaskAsync();
                return;
            }

            Console.WriteLine("Frame loading is complete");
            currentDispatcher.Invoke(LoadTextures);
            RenderTaskAsync();
        }

        #endregion
    }
}
