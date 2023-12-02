using Newtonsoft.Json;
using SharpCutCommon.Dialogs;
using SharpCutCommon.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpCutCommon.Util
{
    public class Updater
    {
        #region Public methods

        /// <summary>
        /// Downloads the application changelog.
        /// </summary>
        /// <returns></returns>
        public static string GetChangelog()
        {
            try
            {
                WebClient webClient = new WebClient();
                return webClient.DownloadString(Resources.UpdateChangelogURL);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to download changelog: ${ex.Message}");
                return null;
            }
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
            using (UpdateDialog updateDialog = new UpdateDialog(release["file"]))
            {
                if (updateDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ProcessStartInfo processStartInfo = new ProcessStartInfo()
                    {
                        FileName = updateDialog.FileName,
                        UseShellExecute = true,
                        Arguments = release["args"]
                    };

                    Process.Start(processStartInfo);
                    Environment.Exit(0);
                }
            }
        }

        #endregion
    }
}
