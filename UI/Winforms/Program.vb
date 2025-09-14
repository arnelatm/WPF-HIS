Imports System.Windows.Forms
Imports AATM.Core
Imports AATM.Core.Configuration
Imports AATM.Core.Localization
Imports AATM.Core.Logging
Imports AATM.Core.Messaging
Imports AATM.Modules.Customers

Module Program
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <STAThread>
    Sub Main()
        Try
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)

            ' 1. Create the Dependency Injection Container
            Dim container As New SimpleDIContainer()

            ' 2. Create and Register Core Services
            Dim logger As ILogger = New FileLogger("log.txt")
            container.Register(GetType(ILogger), logger)
            Dim configService As IConfigurationService = New ConfigurationService()
            container.Register(GetType(IConfigurationService), configService)
            Dim localizationService As ILocalizationService = New LocalizationService(configService)
            container.Register(GetType(ILocalizationService), localizationService)

            ' 3. Create and Register UI and Messaging Services
            Dim customerView As New FrmCustomer()
            container.Register(GetType(ICustomerView), customerView)
            container.Register(GetType(IMessagingService), New StatusBarMessagingService(customerView.StatusStrip))
            Dim uiLocalizationManager As New UILocalizationManager(localizationService)
            container.Register(GetType(IUiLocalizationManager), uiLocalizationManager)


            ' 4. Create and Register Customer Module components
            uiLocalizationManager.RegisterFormStrings(customerView, "CustomerModule", "en-US")
            uiLocalizationManager.RegisterFormStrings(customerView, "CustomerModule", "ar-SA")

            ' 5. Create and Register Customer Module components
            Dim customerRepository As New CustomerRepository()
            container.Register(GetType(CustomerRepository), customerRepository)

            Dim customerService As New CustomerService(customerRepository,
                                                       CType(container.Resolve(GetType(ILogger)), ILogger),
                                                       CType(container.Resolve(GetType(IMessagingService)), IMessagingService))
            container.Register(GetType(ICustomerService), customerService)

            Dim customerPresenter As New CustomerPresenter(CType(container.Resolve(GetType(ICustomerView)), ICustomerView),
                                                           CType(container.Resolve(GetType(ICustomerService)), ICustomerService),
                                                           CType(container.Resolve(GetType(ILogger)), ILogger),
                                                           CType(container.Resolve(GetType(IMessagingService)), IMessagingService),
                                                           CType(container.Resolve(GetType(ILocalizationService)), ILocalizationService),
                                                           CType(container.Resolve(GetType(IUiLocalizationManager)), IUiLocalizationManager))

            container.Register(GetType(CustomerPresenter), customerPresenter)


            ' 6. Run the main application form
            Application.Run(customerView)

        Catch ex As Exception
            MessageBox.Show("An unhandled error occurred: " & ex.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module

'Imports AATM.Core.Logging
'Imports AATM.Core.Messaging
'Imports AATM.Modules.Customers
'Imports System.Windows.Forms

'Module Program
'    ''' <summary>
'    ''' The main entry point for the application.
'    ''' This is the Composition Root where all dependencies are created and wired together.
'    ''' </summary>
'    <STAThread>
'    Sub Main()
'        Application.EnableVisualStyles()
'        Application.SetCompatibleTextRenderingDefault(False)

'        ' 1. Create concrete implementations of services and repositories.
'        Dim logger As ILogger = New FileLogger("log.txt")
'        Dim customerRepository As CustomerRepository = New CustomerRepository()

'        ' 2. Create the main view (the form).
'        Dim customerView As New FormCustomer()

'        ' 3. Create the messaging service, passing it a control from the view.
'        Dim messagingService As IMessagingService = New StatusBarMessagingService(customerView.MainStatusStrip)

'        ' 4. Create the customer service and inject its dependencies.
'        Dim customerService As ICustomerService = New CustomerService(customerRepository, logger, messagingService)

'        ' 5. Create the presenter and inject its dependencies (the view, the service, etc.).
'        Dim customerPresenter As New CustomerPresenter(customerView, customerService, logger, messagingService)

'        ' 6. Run the application with the main view.
'        Application.Run(customerView)
'    End Sub
'End Module