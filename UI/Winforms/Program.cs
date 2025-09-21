using System;
using System.Windows.Forms;
using AATM.Core;
using AATM.Core.Configuration;
using AATM.Core.Localization;
using AATM.Core.Logging;
using Microsoft.VisualBasic.CompilerServices;

namespace Winforms
{

    static class Program
    {
        /// <summary>
    /// The main entry point for the application.
    /// </summary>
        [STAThread]
        public static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // 1. Create the Dependency Injection Container
                var container = new SimpleDIContainer();

                // 2. Create and Register Core Services
                ILogger logger = new FileLogger("log.txt");
                container.Register(typeof(ILogger), logger);
                IConfigurationService configService = new ConfigurationService();
                container.Register(typeof(IConfigurationService), configService);
                ILocalizationService localizationService = new LocalizationService(Conversions.ToString(configService));
                container.Register(typeof(ILocalizationService), localizationService);

                // 3. Create and Register UI and Messaging Services
                var customerView = new FrmCustomer();
                container.Register(typeof(ICustomerView), customerView);
                container.Register(typeof(IMessagingService), new StatusBarMessagingService(customerView.StatusStrip));
                var uiLocalizationManager = new UILocalizationManager(localizationService);
                container.Register(typeof(IUiLocalizationManager), uiLocalizationManager);


                // 4. Create and Register Customer Module components
                uiLocalizationManager.RegisterFormStrings(customerView, "CustomerModule", "en-US");
                uiLocalizationManager.RegisterFormStrings(customerView, "CustomerModule", "ar-SA");

                // 5. Create and Register Customer Module components
                var customerRepository = new CustomerRepository();
                container.Register(typeof(CustomerRepository), customerRepository);

                var customerService = new CustomerService(customerRepository, (ILogger)container.Resolve(typeof(ILogger)), (IMessagingService)container.Resolve(typeof(IMessagingService)));
                container.Register(typeof(ICustomerService), customerService);

                var customerPresenter = new CustomerPresenter((ICustomerView)container.Resolve(typeof(ICustomerView)), (ICustomerService)container.Resolve(typeof(ICustomerService)), (ILogger)container.Resolve(typeof(ILogger)), (IMessagingService)container.Resolve(typeof(IMessagingService)), (ILocalizationService)container.Resolve(typeof(ILocalizationService)), (IUiLocalizationManager)container.Resolve(typeof(IUiLocalizationManager)));

                container.Register(typeof(CustomerPresenter), customerPresenter);


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