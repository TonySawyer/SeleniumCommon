namespace UITest.RegressionCommon.Models.SeleniumExtensions
{
    using System;
    using System.Linq;
    using System.Threading;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    using UITest.RegressionCommon.Models;

    /// <summary>
    /// The select manager.
    /// </summary>
    public static class SelectManager
    {
        /// <summary>
        /// The select by value.
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public static void SelectByValue(By findTechnique, string value)
        {
            Log.Logger.Debug(string.Format("Selecting element from {1} with value ({0})", value, findTechnique));
            SnapshotManager.TakeSnapshot();
            var select = BrowserHost.Instance.FindElement(findTechnique);
            var element = new SelectElement(select);
            element.SelectByValue(value);
        }

        /// <summary>
        /// The select by text.
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public static void SelectByText(By findTechnique, string value)
        {
            Log.Logger.Debug(string.Format("Selecting element from {1} with text ({0})", value, findTechnique));
            SnapshotManager.TakeSnapshot();
            var select = BrowserHost.Instance.FindElement(findTechnique);
            var element = new SelectElement(select);
            element.SelectByText(value);
        }

        /// <summary>
        /// The select by index.
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        public static void SelectByIndex(By findTechnique, int index)
        {
            Log.Logger.Debug(string.Format("Selecting element from {1} with index ({0})", index, findTechnique));
            SnapshotManager.TakeSnapshot();
            var select = BrowserHost.Instance.FindElement(findTechnique);
            var element = new SelectElement(select);
            while (!element.AllSelectedOptions.Any())
            {
                element.SelectByIndex(index); 
                Thread.Sleep(TimeSpan.FromMilliseconds(400));
            }
        }
    }
}