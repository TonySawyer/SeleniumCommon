namespace UITest.RegressionCommon.Models.SeleniumExtensions
{
    using OpenQA.Selenium;

    using UITest.RegressionCommon.Models;

    /// <summary> The check box manager. </summary>
    public static class CheckBoxManager
    {
        /// <summary>
        /// The click check box. 
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique. 
        /// </param>
        public static void ClickCheckBox(By findTechnique)
        {
            Log.Logger.Debug(string.Format("Clicking checkbox ({0})", findTechnique));
            SnapshotManager.TakeSnapshot();
            BrowserHost.Instance.FindElement(findTechnique).Click();
        }
    }
}