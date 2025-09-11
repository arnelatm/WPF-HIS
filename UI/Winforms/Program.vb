Imports System.Windows.Forms
Imports AATM.Core
Imports AATM.Core.Logging
Imports AATM.Core.Messaging
Imports AATM.Modules.Customers
Imports Winforms.AATM.Modules.Customers

Module Program
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <STAThread>
    Sub Main()
        ' This is the Composition Root.
        ' All services and dependencies are created and linked here.

        ' 1. Create a concrete logger implementation.
        ' You can easily switch to FileLogger here for file logging:
        ' Dim logger As ILogger = New FileLogger("log.txt")
        Dim logger As ILogger = New ConsoleLogger()

        ' 2. Create the data repository for customers.
        Dim customerRepository As New CustomerRepository()

        ' 3. Create the customer service, injecting the repository.
        Dim customerService As ICustomerService = New CustomerService(customerRepository)

        ' 4. Create the view (the main form).
        Dim customerView As New FormCustomer()

        ' 5. Create a concrete messaging service implementation.
        ' You can easily switch between them here.
        ' Option 1: Use a standard MessageBox.
        ' Dim messagingService As IMessagingService = New WinFormsMessageBoxService()

        ' Option 2: Use the status bar of the main form.
        Dim messagingService As New StatusBarMessagingService(customerView.MainStatusStrip)

        ' 6. Create the presenter, injecting the view, services, and logger.
        Dim customerPresenter As New CustomerPresenter(customerView, customerService, messagingService, logger)

        ' 7. Run the application with the main form.
        Application.Run(customerView)
    End Sub
End Module
