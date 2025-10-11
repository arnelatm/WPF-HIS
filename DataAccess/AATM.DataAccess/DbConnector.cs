using Microsoft.Data.SqlClient;
using System.Configuration;

namespace AATM.DataAccess
{

    /// <summary>
    /// Provides a simple way to get a new SqlConnection instance by reading
    /// the connection string from the application's configuration file.
    /// </summary>
    public class DbConnector
    {

        /// <summary>
        /// Returns a new, open SqlConnection instance.
        /// </summary>
        /// <returns>An open SqlConnection object.</returns>
        /// <exception cref="ConfigurationErrorsException">Thrown if the connection string is not found.</exception>
        public static SqlConnection GetConnection()
        {
            // The name of the connection string in the configuration file.
            const string connectionStringName = "LocalizationDb";

            // Get the connection string from the application's configuration file.
            var connStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (connStringSettings is null || string.IsNullOrEmpty(connStringSettings.ConnectionString))
            {
                throw new ConfigurationErrorsException($"Connection string '{connectionStringName}' was not found or is empty in the application's configuration file.");
            }

            var conn = new SqlConnection(connStringSettings.ConnectionString);
            conn.Open();
            return conn;
        }

    }
}