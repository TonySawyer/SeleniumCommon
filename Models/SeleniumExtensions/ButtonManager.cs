namespace UITest.RegressionCommon.Models.SeleniumExtensions
{
    using OpenQA.Selenium;

    using UITest.RegressionCommon.Models;

    /// <summary>
    /// The button manager.
    /// </summary>
    public static class ButtonManager
    {
        /// <summary>
        /// The click button.
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique.
        /// </param>
        public static void ClickButton(By findTechnique)
        {
            Log.Logger.Debug(string.Format("Clicking button ({0})", findTechnique));
            SnapshotManager.TakeSnapshot();
            BrowserHost.Instance.FindElement(findTechnique).Click();
        }
    }
}