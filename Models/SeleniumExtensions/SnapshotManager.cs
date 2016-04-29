namespace UITest.RegressionCommon.Models.SeleniumExtensions
{
    using System;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Threading.Tasks;

    using OpenQA.Selenium;

    using UITest.RegressionCommon.Models;

    /// <summary> The snapshot manager. </summary>
    public static class SnapshotManager
    {
        /// <summary>
        /// The take snapshot. 
        /// </summary>
        public static void TakeSnapshot()
        {
            var snapshotDirectory = EnsureTestMethodSnapshotDirectoryExists();
            var snapshotTask = TakeSnapshotAndSaveToDirectory(snapshotDirectory);
        }

        /// <summary> The ensure test method snapshot directory exists. </summary>
        /// <returns> The <see cref="DirectoryInfo" />. </returns>
        private static DirectoryInfo EnsureTestMethodSnapshotDirectoryExists()
        {
            if (!BrowserHost.SnapshotDirectory.Exists)
            {
                BrowserHost.SnapshotDirectory.Create();
            }

            return BrowserHost.SnapshotDirectory;
        }

        /// <summary>
        /// The take snapshot and save to directory. 
        /// </summary>
        /// <param name="snapshotDirectory">
        /// The snapshot directory. 
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private static Task TakeSnapshotAndSaveToDirectory(DirectoryInfo snapshotDirectory)
        {
            return Task.Run(
                () =>
                    {
                        try
                        {
                            var file = ((ITakesScreenshot)BrowserHost.Instance).GetScreenshot();
                            var filename = Path.Combine(snapshotDirectory.FullName, string.Format("{0}.png", BrowserHost.TestStep++));
                            Log.Logger.Debug(string.Format("Image of screen taken with id ({0})", BrowserHost.TestStep));

                            file.SaveAsFile(filename, ImageFormat.Png);
                        }
                        catch (Exception)
                        {
                            Log.Logger.Warn("Unable to take screenshot");
                        }
                    });
        }
    }
}