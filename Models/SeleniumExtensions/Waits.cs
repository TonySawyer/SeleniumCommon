namespace UITest.RegressionCommon.Models.SeleniumExtensions
{
    using System;
    using System.Drawing.Imaging;

    using Common.Logging;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    using UITest.RegressionCommon.Models;

    /// <summary> The waits. </summary>
    public static class Waits
    {
        /// <summary>
        /// The item enabled. 
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique. 
        /// </param>
        public static void ItemEnabled(By findTechnique)
        {
            WaitFor(
                () =>
                    {
                        Log.Logger.Debug(string.Format("Waiting for item to be enabled ({0})", findTechnique));
                        var waitObject = new WebDriverWait(BrowserHost.Instance, TimeSpan.FromSeconds(10));
                        waitObject.Until(x => x.FindElement(findTechnique).Enabled);
                    });
        }

        /// <summary>
        /// The item selected.
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique.
        /// </param>
        public static void ItemSelected(By findTechnique)
        {
            WaitFor(
                () =>
                    {
                        Log.Logger.Debug(string.Format("Waiting for item to be enabled ({0})", findTechnique));
                        var waitObject = new WebDriverWait(BrowserHost.Instance, TimeSpan.FromSeconds(10));
                        var select = BrowserHost.Instance.FindElement(findTechnique);
                        var element = new SelectElement(select);
                        waitObject.Until(x => element.SelectedOption != null);
                    });
        }

        /// <summary>
        /// The item visible. 
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique. 
        /// </param>
        public static void ItemVisible(By findTechnique)
        {
            WaitFor(
                () =>
                    {
                        Log.Logger.Debug(string.Format("Waiting for item to be visible ({0})", findTechnique));
                        var waitObject = new WebDriverWait(BrowserHost.Instance, TimeSpan.FromSeconds(10));
                        waitObject.Until(x => x.FindElement(findTechnique).Displayed);
                    });
        }

        /// <summary>
        /// The page title. 
        /// </summary>
        /// <param name="title">
        /// The title. 
        /// </param>
        public static void PageTitle(string title)
        {
            WaitFor(
                () =>
                    {
                        Log.Logger.Debug(string.Format("Waiting for page title to be ({0})", title));
                        var waitObject = new WebDriverWait(BrowserHost.Instance, TimeSpan.FromSeconds(10));
                        waitObject.Until(x => x.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                    });
        }

        /// <summary>
        /// The wait for. 
        /// </summary>
        /// <param name="action">
        /// The action. 
        /// </param>
        private static void WaitFor(Action action)
        {
            try
            {
                SnapshotManager.TakeSnapshot();
                action();
            }
            catch (WebDriverTimeoutException)
            {
                var file = ((ITakesScreenshot)BrowserHost.Instance).GetScreenshot();
                file.SaveAsFile("WaitsBroke.png", ImageFormat.Png);
                Log.Logger.Error(string.Format("Item being waited for didn't appear - Current Page Title: ({0})", BrowserHost.Instance.Title));
                throw;
            }
        }
    }
}