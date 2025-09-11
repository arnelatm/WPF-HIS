Imports System
Imports System.Net.Mime.MediaTypeNames

Module Program
    Private ReadOnly container As New SimpleDIContainer()

    <STAThread>
    Sub Main()
        ' Register core services first
        RegisterCoreServices()

        ' Load and register all modules
        RegisterModules()

        ' Resolve the main form from the container to run the application
        Dim mainForm As FrmMain = CType(container.Resolve(GetType(FrmMain)), FrmMain)
        Application.Run(mainForm)
    End Sub

    Private Sub RegisterCoreServices()
        ' Register concrete instances for the main form and shared services
        container.Register(GetType(IMessagingService), New WinFormsMessageBoxService())
        container.Register(GetType(FrmMain), New FrmMain())
        ' You could also register your connection string or other shared resources here
        container.Register(GetType(String), "YourConnectionString")
    End Sub

    Private Sub RegisterModules()
        ' The module is initialized with a reference to the container
        Dim customerModule As New CustomerModule(container)
        ' The module registers its own services
        customerModule.RegisterServices()

        ' Future modules would be registered here
        ' Dim salesModule As New SalesModule(container)
        ' salesModule.RegisterServices()
    End Sub
End Module