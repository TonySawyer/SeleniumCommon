namespace UITest.RegressionCommon.Models
{
    using System;
    using System.Diagnostics;
    using System.IO;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    /// <summary> The browser host. </summary>
    public static class BrowserHost
    {
        /// <summary> Gets or sets the instance. </summary>
        public static IWebDriver Instance { get; set; }

        /// <summary> Gets or sets the snapshot directory. </summary>
        public static DirectoryInfo SnapshotDirectory { get; set; }

        /// <summary> Gets or sets the test step. </summary>
        public static int TestStep { get; set; }

        /// <summary>
        /// The log time. 
        /// </summary>
        /// <param name="action">
        /// The action. 
        /// </param>
        public static void LogTime(Action action)
        {
            var stackTrace = new StackTrace();
            var callingMethod = stackTrace.GetFrame(1).GetMethod();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            action();

            stopwatch.Stop();
            Log.Logger.Info(
                string.Format("{0}->{1} - ({2} milliseconds)", callingMethod.DeclaringType, callingMethod.Name, stopwatch.Elapsed.TotalMilliseconds));
        }

        /// <summary>
        /// The run test. 
        /// </summary>
        /// <param name="action">
        /// The action. 
        /// </param>
        public static void RunTest(Action action)
        {
            try
            {
                using (Instance = new FirefoxDriver())
                {
                    TestStep = 0;
                    SnapshotDirectory = GetSnapshotDirectory();
                    CleanSnapshotDirectory();
                    Instance.Manage().Window.Size = SizeFactory.DefaultLandscape();
                    action();
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(string.Format("It Broke: ({0})", ex));
                throw;
            }
        }

        /// <summary> The clean snapshot directory. </summary>
        private static void CleanSnapshotDirectory()
        {
            if (!SnapshotDirectory.Exists)
            {
                return;
            }

            foreach (var file in SnapshotDirectory.GetFiles())
            {
                file.Delete();
            }

            SnapshotDirectory.Delete();
        }

        /// <summary> The get snapshot directory. </summary>
        /// <returns> The <see cref="DirectoryInfo" />. </returns>
        private static DirectoryInfo GetSnapshotDirectory()
        {
            var stackTrace = new StackTrace();
            var methodBase = stackTrace.GetFrame(2).GetMethod();
            var methodType = methodBase.ReflectedType;

            var testSpecificDirectory = string.Format("{0}_{1}", methodBase.Name, DateTime.Now.ToString("yyyyMMddHHmmss"));

            return new DirectoryInfo(Path.Combine(methodType.Namespace, methodType.Name, testSpecificDirectory));
        }
    }
}