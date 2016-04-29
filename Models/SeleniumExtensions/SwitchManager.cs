namespace UITest.RegressionCommon.Models.SeleniumExtensions
{
    using System;
    using System.Threading;

    using OpenQA.Selenium;

    using UITest.RegressionCommon.Models;

    /// <summary> The switch manager. </summary>
    public static class SwitchManager
    {

        /// <summary>
        /// The get value. 
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique. 
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>. 
        /// </returns>
        public static bool GetValue(By findTechnique)
        {
            Log.Logger.Debug(string.Format("Getting value for switch ({0})", findTechnique));
            SnapshotManager.TakeSnapshot();
            var inputElement = BrowserHost.Instance.FindElement(findTechnique);
            var containingDiv = inputElement.FindElement(By.XPath(".."));
            var classes = containingDiv.GetAttribute("class");
            return classes.IndexOf("switch-on", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// The get value. 
        /// </summary>
        /// <param name="forInput">
        /// The for input. 
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>. 
        /// </returns>
        /// <exception cref="Exception">
        /// Could not find value of switch
        /// </exception>
        public static bool GetValue(string forInput)
        {
            Log.Logger.Debug(string.Format("Getting value for switch ({0})", forInput));
            SnapshotManager.TakeSnapshot();

            var labels = BrowserHost.Instance.FindElements(By.TagName("label"));

            foreach (var webElement in labels)
            {
                var labelFor = webElement.GetAttribute("for");
                if (labelFor.Equals(forInput, StringComparison.OrdinalIgnoreCase))
                {
                    var containingDiv = webElement.FindElement(By.XPath(".."));
                    var classes = containingDiv.GetAttribute("class");
                    return classes.IndexOf("switch-on", StringComparison.OrdinalIgnoreCase) >= 0;
                }
            }

            throw new Exception("Could not find value of switch");
        }

        /// <summary>
        /// The toggle. 
        /// </summary>
        /// <param name="findTechniqueForLabel">
        /// The find technique for label. 
        /// </param>
        public static void Toggle(By findTechniqueForLabel)
        {
            Log.Logger.Debug(string.Format("Switching ({0})", findTechniqueForLabel));
            SnapshotManager.TakeSnapshot();
            var switchElement = BrowserHost.Instance.FindElement(findTechniqueForLabel);
            switchElement.Click();
            Thread.Sleep(TimeSpan.FromMilliseconds(250));
        }

        /// <summary>
        /// The toggle. 
        /// </summary>
        /// <param name="findTechniqueForLabels">
        /// The find technique for label. 
        /// </param>
        /// <param name="index">
        /// Index of switch. 
        /// </param>
        public static void Toggle(By findTechniqueForLabels, int index)
        {
            Log.Logger.Debug(string.Format("Switching ({0})", findTechniqueForLabels));
            SnapshotManager.TakeSnapshot();
            var switchElements = BrowserHost.Instance.FindElements(findTechniqueForLabels);
            switchElements[index].Click();
            Thread.Sleep(TimeSpan.FromMilliseconds(250));
        }
    }
}