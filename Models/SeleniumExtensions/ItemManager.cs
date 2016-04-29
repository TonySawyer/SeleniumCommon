namespace UITest.RegressionCommon.Models.SeleniumExtensions
{
    using System;

    using OpenQA.Selenium;

    using UITest.RegressionCommon.Models;

    /// <summary> The item manager. </summary>
    public static class ItemManager
    {
        /// <summary>
        /// The item visible. 
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique. 
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>. 
        /// </returns>
        public static bool ItemVisible(By findTechnique)
        {
            try
            {
                var element = BrowserHost.Instance.FindElement(findTechnique);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}