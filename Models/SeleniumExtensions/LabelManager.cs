namespace UITest.RegressionCommon.Models.SeleniumExtensions
{
    using System;

    using OpenQA.Selenium;

    using UITest.RegressionCommon.Models;

    /// <summary> The label manager. </summary>
    public static class LabelManager
    {
        /// <summary>
        /// The click label. 
        /// </summary>
        /// <param name="forInput">
        /// The for input. 
        /// </param>
        /// <param name="index">
        /// The index. 
        /// </param>
        /// <exception cref="Exception">
        /// Could not find the label
        /// </exception>
        public static void ClickLabel(string forInput, int index)
        {
            Log.Logger.Debug(string.Format("Finding label {0} and index {1}", forInput, index));
            SnapshotManager.TakeSnapshot();
            var labels = BrowserHost.Instance.FindElements(By.TagName("label"));

            foreach (var webElement in labels)
            {
                var labelFor = webElement.GetAttribute("for");
                if (labelFor.Equals(forInput, StringComparison.OrdinalIgnoreCase))
                {
                    webElement.Click();
                    return;
                }
            }

            throw new Exception("Could not find label to click");
        }
    }
}