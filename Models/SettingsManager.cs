namespace UITest.RegressionCommon.Models
{
    using System.IO;

    using Newtonsoft.Json;

    /// <summary> The settings manager. </summary>
    public class SettingsManager
    {
        /// <summary> Gets or sets the runtime settings. </summary>
        public static SiteSettings Configuration { get; set; }

        /// <summary> The get settings. </summary>
        public static void GetSettings()
        {
            var settingsFileContents = File.ReadAllText("Settings.json");
            var settings = JsonConvert.DeserializeObject<SiteSettings>(settingsFileContents);
            Configuration = settings;
        }
    }
}