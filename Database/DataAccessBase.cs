namespace UITest.RegressionCommon.Database
{
    using System;
    using System.Data;

    using Common.Logging;

    using Devart.Data.Oracle;

    using UITest.RegressionCommon.Models;

    /// <summary>
    /// The data access base.
    /// </summary>
    public class DataAccessBase
    {
        /// <summary> The settings. </summary>
        private readonly DatabaseConfiguration settings;

        private readonly ILog logger;

        /// <summary>
        /// Initialises a new instance of the <see cref="DataAccessBase"/> class. 
        /// </summary>
        /// <param name="settings">
        /// The settings. 
        /// </param>
        /// <param name="logger">The Logger</param>
        public DataAccessBase(DatabaseConfiguration settings, ILog logger)
        {
            this.settings = settings;
            this.logger = logger;
        }

        /// <summary>
        /// The open database. 
        /// </summary>
        /// <param name="conn">
        /// The conn. 
        /// </param>
        /// <exception cref="Exception">
        /// TNS name in the connection string is invalid. 
        /// </exception>
        /// <exception cref="Exception">
        /// The credentials to access the database are incorrect. 
        /// </exception>
        /// <exception cref="Exception">
        /// The database is not open. 
        /// </exception>
        protected void OpenDatabase(IDbConnection conn)
        {
            try
            {
                conn.Open();
            }
            catch (OracleException ex)
            {
                this.logger.Error(m => m("Oracle Exception when opening database ({0})", ex));

                switch (ex.Code)
                {
                    case 12154:
                        this.logger.Error(m => m("Invalid TNS Names segment in connection string, ({0})", ex));
                        throw new Exception("Invalid TNS Names segment in connection string", ex);
                    case 1017:
                        this.logger.Error(m => m("Invalid Database Credentials in connection string, ({0})", ex));
                        throw new Exception("Invalid Database Credentials in connection string", ex);
                    default:
                        this.logger.Error(m => m("Database not opened - Oracle, ({0})", ex));
                        throw new Exception("Database not opened - Oracle", ex);
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(m => m("Error opening database ({0})", ex));
                throw new Exception("Database not opened", ex);
            }
        }

        /// <summary>
        /// The get oracle connection. 
        /// </summary>
        /// <param name="connectionString">
        /// The connection string. 
        /// </param>
        /// <returns>
        /// The <see cref="OracleConnection"/>. 
        /// </returns>
        /// <exception cref="Exception">
        /// Connection string is invalid. 
        /// </exception>
        protected OracleConnection GetOracleConnection(string connectionString)
        {
            try
            {
                var connection = new OracleConnection(connectionString);
                return connection;
            }
            catch (ArgumentException ex)
            {
                this.logger.Error(m => m("Error creating database connection ({0})", ex));
                throw new Exception("Connection String Invalid", ex);
            }
        }

        /// <summary>
        /// The run database command. 
        /// </summary>
        /// <param name="action">
        /// The action. 
        /// </param>
        /// <exception cref="Exception">
        /// There is a problem running the database command. 
        /// </exception>
        protected void RunDatabaseCommand(Action<OracleCommand> action)
        {
            try
            {
                var connectionString = this.settings.ConnectionString;
                using (var conn = this.GetOracleConnection(connectionString))
                {
                    this.OpenDatabase(conn);

                    using (var cmd = new OracleCommand())
                    {
                        cmd.Connection = conn;
                        action(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(m => m("Error reading from database ({0})", ex));
                throw new Exception("Error reading from database", ex);
            }
        }
    }
}