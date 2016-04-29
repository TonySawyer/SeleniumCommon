namespace UITest.RegressionCommon.Models.SeleniumExtensions
{
    using System;

    using OpenQA.Selenium;

    using UITest.RegressionCommon.Models;

    /// <summary> The link manager. </summary>
    public static class LinkManager
    {
        /// <summary>
        /// The click first link. 
        /// </summary>
        /// <param name="classType">
        /// The class type. 
        /// </param>
        /// <param name="startOfLink">
        /// The start of link. 
        /// </param>
        public static void ClickFirstLink(string classType, string startOfLink)
        {
            Log.Logger.Debug(string.Format("Finding first link that conforms to {0} and starts with {1}", classType, startOfLink));
            SnapshotManager.TakeSnapshot();
            var hyperlinks = BrowserHost.Instance.FindElements(By.TagName("a"));
            foreach (var webElement in hyperlinks)
            {
                var classes = webElement.GetAttribute("class");
                if (classes.IndexOf(classType, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Log.Logger.Debug(string.Format("Found a hyperlink with the class {0}", webElement));
                    var href = webElement.GetAttribute("href");
                    if (href.IndexOf(startOfLink, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Log.Logger.Debug(string.Format("Found a hyperlink with the class and starts with the text provided {0}", webElement));
                        webElement.Click();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// The click button. 
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique. 
        /// </param>
        public static void ClickHyperLink(By findTechnique)
        {
            Log.Logger.Debug(string.Format("Clicking hyperlink ({0})", findTechnique));
            SnapshotManager.TakeSnapshot();
            BrowserHost.Instance.FindElement(findTechnique).Click();
        }
    }
}