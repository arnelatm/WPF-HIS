using System;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AATM.DataAccess.Sql;
using AATM.DataAccess;
using AATM.Wpf.App.HIS;

namespace AATM.App.Wpf.HIS
{
    public partial class App : Application
    {
        public static IHost HostApp { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            HostApp = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((ctx, cfg) =>
                {
                    cfg.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                       .AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                       .AddEnvironmentVariables(); // e.g. ConnectionStrings__Default
                })
                .ConfigureServices((ctx, services) =>
                {
                    var conn = ctx.Configuration.GetConnectionString("Default")
                        ?? throw new InvalidOperationException("ConnectionStrings:Default is missing.");

                    services.AddSingleton<ITranslationRepository>(_ => new TranslationRepository(conn));

                    // Register ViewModels and Windows
                    services.AddTransient<ViewModels.TranslationViewModel>();
                    services.AddTransient<AATM.Wpf.App.HIS.Forms.TranslationWindow>();
                    services.AddTransient<MainWindow>();
                })
                .Build();

            base.OnStartup(e);

            var main = HostApp.Services.GetRequiredService<MainWindow>();
            main.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            if (HostApp is not null) await HostApp.StopAsync();
            HostApp?.Dispose();
            base.OnExit(e);
        }
    }
}   