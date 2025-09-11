Imports System
Imports System.Collections.Generic

Public Class CustomerPresenter
    Private ReadOnly _view As ICustomerView
    Private ReadOnly _model As CustomerRepository
    Private ReadOnly _messagingService As IMessagingService

    Public Sub New(view As ICustomerView, model As CustomerRepository, messagingService As IMessagingService)
        _view = view
        _model = model
        _messagingService = messagingService
        AddHandler _view.LoadView, AddressOf OnLoadView
        AddHandler _view.SaveCustomer, AddressOf OnSaveCustomer
    End Sub

    Private Async Sub OnLoadView(sender As Object, e As EventArgs)
        Try
            ' The presenter awaits the model's async method
            Dim customers As List(Of CustomerDTO) = Await _model.GetCustomersAsync()
            _view.DisplayCustomers(customers)
        Catch ex As Exception
            ErrorHandler.LogError(ex)
            _messagingService.ShowError("An unexpected error occurred while loading customers.")
        End Try
    End Sub

    Private Sub OnSaveCustomer(sender As Object, e As CustomerDTO)
        Dim result As ValidationResult = _model.AddCustomer(e)
        If result.IsValid Then
            ' Call the messaging service to show a success message
            _messagingService.ShowSuccess("Customer saved successfully.")
            ' Refresh the view
            OnLoadView(Nothing, EventArgs.Empty)
        Else
            ' Call the messaging service to show an error
            _messagingService.ShowError("Validation Error: " & result.ErrorMessage)
        End If
    End Sub
End Class
