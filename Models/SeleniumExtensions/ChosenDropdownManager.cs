namespace UITest.RegressionCommon.Models.SeleniumExtensions
{
    using OpenQA.Selenium;

    using UITest.RegressionCommon.Models;

    /// <summary> The chosen dropdown manager. </summary>
    public static class ChosenDropdownManager
    {
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
            var element = BrowserHost.Instance.FindElement(findTechnique);
            var parent = element.FindElement(By.XPath(".."));
            parent.FindElement(By.CssSelector("div.chosen-container a.chosen-single")).Click();
            parent.FindElements(By.CssSelector("div.chosen-drop li.active-result"))[index].Click();
        }
    }
}