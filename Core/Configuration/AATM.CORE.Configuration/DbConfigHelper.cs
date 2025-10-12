using Microsoft.Extensions.Configuration;
using System;

namespace AATM.App.HisWpf.Helpers
{
    public static class DbConfigHelper
    {
        public static string GetIspDataConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            return config.GetConnectionString("ISPDATA")
                ?? throw new InvalidOperationException("Connection string 'ISPDATA' is missing in appsettings.json.");
        }
    }
}   