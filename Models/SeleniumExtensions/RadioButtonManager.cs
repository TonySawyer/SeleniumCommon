namespace UITest.RegressionCommon.Models.SeleniumExtensions
{
    using System;
    using System.Linq;

    using OpenQA.Selenium;

    using UITest.RegressionCommon.Models;

    /// <summary> The radio button manager. </summary>
    public static class RadioButtonManager
    {
        /// <summary>
        /// The click by index. 
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique. 
        /// </param>
        /// <param name="index">
        /// The index. 
        /// </param>
        public static void ClickByIndex(By findTechnique, int index)
        {
            Log.Logger.Debug(string.Format("Clicking radio button by index ({0})", findTechnique));
            SnapshotManager.TakeSnapshot();
            var radioButtons = BrowserHost.Instance.FindElements(findTechnique);
            radioButtons.ElementAt(index).Click();
        }

        /// <summary>
        /// The click by value. 
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique. 
        /// </param>
        /// <param name="value">
        /// The value. 
        /// </param>
        public static void ClickByValue(By findTechnique, string value)
        {
            Log.Logger.Debug(string.Format("Clicking radio button ({0})", findTechnique));
            SnapshotManager.TakeSnapshot();
            var radioButtons = BrowserHost.Instance.FindElements(findTechnique);

            for (var i = 0; i < radioButtons.Count; i++)
            {
                var radioButtonValue = radioButtons.ElementAt(i).GetAttribute("value");
                if (value.Equals(radioButtonValue, StringComparison.OrdinalIgnoreCase))
                {
                    radioButtons.ElementAt(i).Click();
                    break;
                }
            }
        }
    }
}