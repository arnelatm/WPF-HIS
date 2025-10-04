using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AATM.Contracts;
using AATM.Contracts.Interfaces.Services;
using AATM.Core;
using AATM.Core.Configuration;
using AATM.Core.Localization;
using AATM.Core.Logging;
using AATM.Core.Messaging;
using AATM.Modules.Customers;

namespace Winforms
{
    static class Program
    {
        [STAThread]
        public static void Main()
        {
            // Set global exception handlers early
            Application.ThreadException += (s, e) =>
                MessageBox.Show("A UI error occurred: " + e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    MessageBox.Show("A fatal error occurred: " + ex.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // 1. Create the Dependency Injection Container
                var container = new SimpleDIContainer();

                // 2. Create and Register Core Services
                var logger = new FileLogger("log.txt");
                container.Register(typeof(ILogger), logger);

                var configService = new ConfigurationService();
                container.Register(typeof(IConfigurationService), configService);

                var localizationService = new LocalizationService("en-US", "CustomerModule");
                container.Register(typeof(ILocalizationService), localizationService);

                // 3. Create and Register UI and Messaging Services
                var customerView = new FrmCustomer();
                container.Register(typeof(ICustomerView), customerView);

                // Ensure StatusStrip exists before using it
                if (customerView.StatusStrip == null)
                {
                    throw new InvalidOperationException("Customer form StatusStrip is not initialized.");
                }

                var messagingService = new StatusBarMessagingService(customerView.StatusStrip);
                container.Register(typeof(IMessagingService), messagingService);

                var uiLocalizationManager = new UILocalizationManager(localizationService);
                container.Register(typeof(IUiLocalizationManager), uiLocalizationManager);

                // 4. Register localization resources for the form (register once per culture)
                uiLocalizationManager.RegisterFormStrings(customerView, "CustomerModule", "en-US");
                uiLocalizationManager.RegisterFormStrings(customerView, "CustomerModule", "ar-SA");

                // 5. Create and Register Customer Module components
                var customerRepository = new CustomerRepository();
                container.Register(typeof(CustomerRepository), customerRepository);

                var customerService = new CustomerService(
                    customerRepository,
                    logger,
                    messagingService);
                container.Register(typeof(ICustomerService), customerService);

                var customerPresenter = new CustomerPresenter(
                    customerView,
                    customerService,
                    logger,
                    messagingService,
                    localizationService,
                    uiLocalizationManager);
                container.Register(typeof(CustomerPresenter), customerPresenter);

                // Optionally perform initial localization (e.g., default culture)
                //uiLocalizationManager.ApplyCulture(customerView, localizationService.CurrentCulture?.Name ?? "en-US");

                // 6. Run the main application form
                Application.Run(customerView);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unhandled error occurred: " + ex.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

// Imports AATM.Core.Logging
// Imports AATM.Core.Messaging
// Imports AATM.Modules.Customers
// Imports System.Windows.Forms

// Module Program
// ''' <summary>
// ''' The main entry point for the application.
// ''' This is the Composition Root where all dependencies are created and wired together.
// ''' </summary>
// <STAThread>
// Sub Main()
// Application.EnableVisualStyles()
// Application.SetCompatibleTextRenderingDefault(False)

// ' 1. Create concrete implementations of services and repositories.
// Dim logger As ILogger = New FileLogger("log.txt")
// Dim customerRepository As CustomerRepository = New CustomerRepository()

// ' 2. Create the main view (the form).
// Dim customerView As New FormCustomer()

// ' 3. Create the messaging service, passing it a control from the view.
// Dim messagingService As IMessagingService = New StatusBarMessagingService(customerView.MainStatusStrip)

// ' 4. Create the customer service and inject its dependencies.
// Dim customerService As ICustomerService = New CustomerService(customerRepository, logger, messagingService)

// ' 5. Create the presenter and inject its dependencies (the view, the service, etc.).
// Dim customerPresenter As New CustomerPresenter(customerView, customerService, logger, messagingService)

// ' 6. Run the application with the main view.
// Application.Run(customerView)
// End Sub
// End Module