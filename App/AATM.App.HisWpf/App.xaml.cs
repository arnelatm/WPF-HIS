using AATM.App.HisWpf.ViewModels;
using AATM.Core.Localization;
using AATM.DataAccess;
using AATM.DataAccess.Sql;
using AATM.Modules.Localization;
using AATM.Modules.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        // Make Host lazy so the designer does not execute CreateHost() when it loads App type
        private static IHost? _host;
        public static IHost Host => _host ??= CreateHost();

        private static IHost CreateHost()
        {
            var builder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder();

            builder.Configuration
                   .SetBasePath(AppContext.BaseDirectory)
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables();

            // Use the same connection string key everywhere: IspDatabase
            builder.Services.AddSingleton<ITranslationRepository>(sp =>
            {
                var cfg = sp.GetRequiredService<IConfiguration>();
                var conn = cfg.GetConnectionString("IspDatabase")
                          ?? throw new InvalidOperationException("Connection string 'IspDatabase' is missing.");
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

            // Register the IUserRepository implementation (replace UserRepository with your actual implementation)
            builder.Services.AddTransient<IUserRepository>(sp =>
            {
                var cfg = sp.GetRequiredService<IConfiguration>();
                var conn = cfg.GetConnectionString("IspDatabase")
                          ?? throw new InvalidOperationException("Connection string 'IspDatabase' is missing.");
                return new UserRepository(conn);
            });

            // Register UserCrudService
            builder.Services.AddSingleton<UserCrudService>();
            builder.Services.AddTransient<UserViewModel>();
            builder.Services.AddTransient<UserWindow>();

            builder.Services.AddTransient<IEmployeeRepository>(sp =>
            {
                var cfg = sp.GetRequiredService<IConfiguration>();
                var conn = cfg.GetConnectionString("IspDatabase")
                          ?? throw new InvalidOperationException("Connection string 'IspDatabase' is missing.");
                return new EmployeeRepository(conn); // Replace with your actual implementation
            });

            builder.Services.AddTransient<ISecurityGroupRepository>(sp =>
            {
                var cfg = sp.GetRequiredService<IConfiguration>();
                var conn = cfg.GetConnectionString("IspDatabase")
                          ?? throw new InvalidOperationException("Connection string 'IspDatabase' is missing.");
                return new SecurityGroupRepository(conn); // Replace with your actual implementation
            });

            return builder.Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Host is created/started here at runtime, not at design-time
            Host.Start();
        }
    }
}