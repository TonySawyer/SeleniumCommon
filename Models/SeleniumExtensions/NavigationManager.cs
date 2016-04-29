namespace UITest.RegressionCommon.Models.SeleniumExtensions
{
    using UITest.RegressionCommon.Models;

    /// <summary>
    /// The navigation manager.
    /// </summary>
    public static class NavigationManager
    {
        /// <summary>
        /// The go.
        /// </summary>
        /// <param name="urlToNavigateTo">
        /// The url to navigate to.
        /// </param>
        public static void Go(string urlToNavigateTo)
        {
            Log.Logger.Debug(string.Format("Navigating to ({0})", urlToNavigateTo));
            BrowserHost.Instance.Navigate().GoToUrl(urlToNavigateTo);
        }
    }
}