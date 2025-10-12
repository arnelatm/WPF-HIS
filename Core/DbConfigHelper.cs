using System;
using Microsoft.Extensions.Configuration;

namespace AATM.Core
{
    public static class DbConfigHelper
    {
        public static string GetIspDataConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();

            return config.GetConnectionString("ISPDATA")
                ?? throw new InvalidOperationException("Connection string 'ISPDATA' is missing in appsettings.json.");
        }
    }
}   