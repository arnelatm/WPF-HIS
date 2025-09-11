Imports System.Collections.Generic

Public Class CustomerModule
    Private ReadOnly _container As SimpleDIContainer

    Public Sub New(container As SimpleDIContainer)
        _container = container
    End Sub

    ''' <summary>
    ''' Registers all customer-related services and presenters with the DI container.
    ''' </summary>
    Public Sub RegisterServices()
        ' Resolve the connection string from the container
        Dim connectionString As String = CType(_container.Resolve(GetType(String)), String)

        ' Register the concrete CustomerRepository instance
        _container.Register(GetType(CustomerRepository), New CustomerRepository(connectionString))

        ' Resolve its dependencies from the container and then register the presenter instance
        Dim mainForm As ICustomerView = CType(_container.Resolve(GetType(FrmMain)), ICustomerView)
        Dim repository As CustomerRepository = CType(_container.Resolve(GetType(CustomerRepository)), CustomerRepository)
        Dim messagingService As IMessagingService = CType(_container.Resolve(GetType(IMessagingService)), IMessagingService)

        _container.Register(GetType(CustomerPresenter), New CustomerPresenter(mainForm, repository, messagingService))
    End Sub
End Class
