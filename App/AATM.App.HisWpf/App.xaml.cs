using AATM.App.HisWpf.ViewModels;
using AATM.Contracts.Interfaces.Services;
using AATM.Core.Localization;
using AATM.DataAccess;
using AATM.DataAccess.Sql;
using AATM.Modules.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace AATM.App.HisWpf
{
    public partial class App : Application
    {
        // Optional: keep if you needed this to avoid native SNI issues on Windows
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

            // Use the same connection string key everywhere: ISPDATA
            builder.Services.AddSingleton<ITranslationRepository>(sp =>
            {
                var cfg = sp.GetRequiredService<IConfiguration>();
                var conn = cfg.GetConnectionString("ISPDATA")
                          ?? throw new InvalidOperationException("Connection string 'ISPDATA' is missing.");
                return new TranslationRepository(conn);
            });
            builder.Services.AddSingleton<TranslationCrudService>();

            // Localization via DI
            builder.Services.AddLocalizationServiceFactory();
            var loc = builder.Configuration.GetSection("Localization");
            var defaultLang = loc["DefaultLanguage"] ?? "en-US";
            var moduleName = loc["ModuleName"] ?? "Translation";
            builder.Services.AddDefaultLocalizationService(defaultLang, moduleName);

            // Views + ViewModels
            builder.Services.AddTransient<TranslationViewModel>();
            builder.Services.AddTransient<TranslationWindow>();

            return builder.Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Host.Start();
        }
    }
}