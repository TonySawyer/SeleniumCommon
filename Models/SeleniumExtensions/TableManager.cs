namespace UITest.RegressionCommon.Models.SeleniumExtensions
{
    using OpenQA.Selenium;

    using UITest.RegressionCommon.Models;

    /// <summary> The table manager. </summary>
    public static class TableManager
    {
        /// <summary>
        /// The click link. 
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique. 
        /// </param>
        /// <param name="rowIndex">
        /// The row index. 
        /// </param>
        /// <param name="elementToClick">
        /// The element to click. 
        /// </param>
        public static void ClickLink(By findTechnique, int rowIndex, By elementToClick)
        {
            Log.Logger.Debug(string.Format("Selecting row ({0}) in table {1}", rowIndex, findTechnique));
            SnapshotManager.TakeSnapshot();
            var table = BrowserHost.Instance.FindElement(findTechnique);
            var rows = table.FindElements(By.TagName("tr"));
            var rowToClick = rows[rowIndex];
            var elementsToClick = rowToClick.FindElements(elementToClick);
            elementsToClick[0].Click();
        }
    }
}