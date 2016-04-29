namespace UITest.RegressionCommon.Models
{
    /// <summary> The settings. </summary>
    public class SiteSettings
    {
        /// <summary> Gets or sets the admin password. </summary>
        public string AdminPassword { get; set; }

        /// <summary> Gets or sets the admin user. </summary>
        public string AdminUser { get; set; }

        /// <summary> Gets or sets the application name. </summary>
        public string ApplicationName { get; set; }

        /// <summary> Gets or sets the database connection string. </summary>
        public string DatabaseConnectionString { get; set; }

        /// <summary> Gets or sets the root site url. </summary>
        public string RootSiteUrl { get; set; }

        /// <summary> Gets or sets a value indicating whether take debug snapshots. </summary>
        public bool TakeDebugSnapshots { get; set; }
    }
}