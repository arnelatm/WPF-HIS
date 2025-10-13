using System;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AATM.Core.Localization; // brings AddLocalizationServiceFactory() into scope

namespace AATM.App.HisWpf
{
    public partial class App : Application
    {
        static App()
        {
            try
            {
                AppContext.SetSwitch("Switch.Microsoft.Data.SqlClient.UseManagedNetworkingOnWindows", true);
                AppContext.SetSwitch("System.Data.SqlClient.UseManagedNetworkingOnWindows", true);
            }
            catch { /* ignore */ }
        }

        public static IHost Host { get; } = CreateHost();

        private static IHost CreateHost()
        {
            var builder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder();
            builder.Configuration
                   .SetBasePath(AppContext.BaseDirectory)
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables();

            builder.Services.AddSingleton<AATM.DataAccess.ITranslationRepository>(sp =>
            {
                var cfg = sp.GetRequiredService<IConfiguration>();
                var conn = cfg.GetConnectionString("ISPDATA")
                          ?? throw new InvalidOperationException("Connection string 'ISPDATA' is missing.");
                return new AATM.DataAccess.Sql.TranslationRepository(conn);
            });

            builder.Services.AddSingleton<AATM.Modules.Localization.TranslationCrudService>();
            builder.Services.AddLocalizationServiceFactory();

            var loc = builder.Configuration.GetSection("Localization");
            builder.Services.AddDefaultLocalizationService(
                loc["DefaultLanguage"] ?? "en-US",
                loc["ModuleName"] ?? "Translation");

            builder.Services.AddTransient<AATM.App.HisWpf.ViewModels.TranslationViewModel>();
            builder.Services.AddTransient<AATM.App.HisWpf.TranslationWindow>();
            return builder.Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Host.Start();
        }
    }
}   