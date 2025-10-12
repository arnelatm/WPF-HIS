using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using AATM.App.HisWpf.ViewModels;

namespace AATM.App.HisWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Keep the property name 'Host' for external callers, but build it via CreateApplicationBuilder.
        public static IHost Host { get; } = CreateHost();

        private static IHost CreateHost()
        {
            // Requires the Microsoft.Extensions.Hosting package
            var builder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder();

            // Requires Microsoft.Extensions.Configuration.FileExtensions + .Json packages
            builder.Configuration
                   .SetBasePath(AppContext.BaseDirectory)
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            builder.Services.AddTransient<TranslationViewModel>();
            // register other services...

            return builder.Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Host.Start();
            // Resolve your main window and set DataContext from DI as needed
        }
    }
}
