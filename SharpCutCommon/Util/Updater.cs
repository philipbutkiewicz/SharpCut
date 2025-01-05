using Newtonsoft.Json;
using SharpCutCommon.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace SharpCutCommon.Util
{
    public class Updater
    {
        #region Public methods

        /// <summary>
        /// Returns the application changelog.
        /// </summary>
        /// <returns></returns>
        public static string GetChangelog()
        {
            string changeLogPath = Path.Combine("Resources", "ChangeLog.txt");

            return File.Exists(changeLogPath) ? File.ReadAllText(changeLogPath) : null;
        }

        /// <summary>
        /// Checks for application updates and starts the update process.
        /// </summary>
        /// <param name="silent"></param>
        /// <param name="silent"></param>
        public static void CheckForUpdates(bool silent = true, bool noUpdatesSilent = false)
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            try
            {
                WebClient webClient = new WebClient();
                string manifestJson = webClient.DownloadString(Settings.Default.IsBetaBuild ? Resources.UpdateBetaManifestURL : Resources.UpdateManifestURL);

                List<Dictionary<string, string>> manifest = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(manifestJson);
                if (manifest == null || manifest.Count == 0)
                {
                    throw new Exception("The update manifest does not contain any items.");
                }

                Dictionary<string, string> latestRelease = manifest[0];
                if (latestRelease["version"] != version)
                {
                    if (!silent)
                    {
                        if (MessageBox.Show(Resources.NewVersionAvailable, Resources.UpdateTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            StartUpdate(latestRelease);
                        }
                    }
                    else
                    { 
                        StartUpdate(latestRelease);
                    }
                }
                else if (!noUpdatesSilent)
                {
                    MessageBox.Show(Resources.NoUpdatesAvailable, Resources.UpdateTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Update check failed: {ex.Message}");
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Starts the update process.
        /// </summary>
        private static void StartUpdate(Dictionary<string, string> release)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = "SharpCutUpdate.exe",
                UseShellExecute = true
            };

            Process.Start(processStartInfo);
            Environment.Exit(0);
        }

        #endregion
    }
}
