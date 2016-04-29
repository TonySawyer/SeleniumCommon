namespace UITest.RegressionCommon.Models.SeleniumExtensions
{
    using OpenQA.Selenium;

    using UITest.RegressionCommon.Models;

    /// <summary> The input manager. </summary>
    public static class InputManager
    {
        /// <summary>
        /// The clear. 
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique. 
        /// </param>
        public static void Clear(By findTechnique)
        {
            Log.Logger.Debug(string.Format("Clearing ({0})", findTechnique));
            SnapshotManager.TakeSnapshot();
            BrowserHost.Instance.FindElement(findTechnique).Clear();
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string Get(By findTechnique)
        {
            Log.Logger.Debug(string.Format("Getting ({0})", findTechnique));
            SnapshotManager.TakeSnapshot();
            var input = BrowserHost.Instance.FindElement(findTechnique);
            return input.GetAttribute("value");
        }

        /// <summary>
        /// The send keys. 
        /// </summary>
        /// <param name="findTechnique">
        /// The find technique. 
        /// </param>
        /// <param name="inputValue">
        /// The input value. 
        /// </param>
        public static void SendKeys(By findTechnique, string inputValue)
        {
            Log.Logger.Debug(string.Format("Sending ({0}) to {1}", inputValue, findTechnique));
            SnapshotManager.TakeSnapshot();
            BrowserHost.Instance.FindElement(findTechnique).SendKeys(inputValue);
        }
    }
}