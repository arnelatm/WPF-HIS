Imports System.Collections.Generic
Imports System.Windows.Forms
Imports AATM.Core.Logging
Imports AATM.Core.Messaging
Imports AATM.Modules.Customers

Namespace AATM.Modules.Customers

    ''' <summary>
    ''' The Presenter for the customer management feature. It mediates between the View and the Model.
    ''' </summary>
    Public Class CustomerPresenter

        Private ReadOnly _view As ICustomerView
        Private ReadOnly _customerService As ICustomerService
        Private ReadOnly _messagingService As IMessagingService
        Private ReadOnly _logger As ILogger

        ''' <summary>
        ''' Initializes a new instance of the CustomerPresenter class.
        ''' </summary>
        Public Sub New(view As ICustomerView, customerService As ICustomerService, messagingService As IMessagingService, logger As ILogger)
            _view = view
            _customerService = customerService
            _messagingService = messagingService
            _logger = logger

            ' Add handlers for events raised by the View
            AddHandler _view.LoadCustomers, AddressOf Me.OnLoadCustomers
            AddHandler _view.SaveCustomer, AddressOf Me.OnSaveCustomer
        End Sub

        Private Sub OnLoadCustomers(sender As Object, e As EventArgs)
            Try
                _view.EnableView(False) ' Disable the view during the operation
                _messagingService.ShowInformation("Loading customers...")

                Dim customers As List(Of CustomerDTO) = _customerService.GetCustomers()
                _view.DisplayCustomers(customers)

                _messagingService.ShowSuccess("Customers loaded successfully.")
                _logger.LogInfo("Customers loaded.")
            Catch ex As Exception
                _messagingService.ShowError("Failed to load customers.")
                _logger.LogException(ex)
            Finally
                _view.EnableView(True) ' Re-enable the view
            End Try
        End Sub

        Private Sub OnSaveCustomer(customer As CustomerDTO)
            Try
                _view.EnableView(False)
                _messagingService.ShowInformation("Saving customer...")

                ' Use type inference to avoid ambiguous type issues
                Dim result = _customerService.SaveCustomer(customer)

                If result.IsValid Then
                    _messagingService.ShowSuccess("Customer saved successfully.")
                    _logger.LogInfo("Customer saved successfully.")
                    ' Refresh the customer list after saving.
                    OnLoadCustomers(Nothing, EventArgs.Empty)
                Else
                    _messagingService.ShowError("Validation Error: " & result.ErrorMessage)
                    _logger.LogError("Validation Error: " & result.ErrorMessage)
                End If
            Catch ex As Exception
                _messagingService.ShowError("An error occurred while saving the customer.")
                _logger.LogException(ex)
            Finally
                _view.EnableView(True)
            End Try
        End Sub

    End Class

End Namespace
