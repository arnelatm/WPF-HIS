Imports AATM.Core.Logging
Imports AATM.Core.Messaging
Imports AATM.Core.Localization
Imports AATM.Modules.Customers
Imports System.Collections.Generic
Imports AATM.UI.Winforms
Imports AATM.Contracts

''' <summary>
''' The Presenter for the customer management feature.
''' This class mediates between the View (the UI) and the Model (the business logic).
''' </summary>
Public Class CustomerPresenter
    Private ReadOnly _view As ICustomerView
    Private ReadOnly _service As ICustomerService
    Private ReadOnly _logger As ILogger
    Private ReadOnly _messagingService As IMessagingService
    Private ReadOnly _localizationService As ILocalizationService
    Private ReadOnly _uiLocalizationManager As IUiLocalizationManager

    ''' <summary>
    ''' Initializes a new instance of the CustomerPresenter class.
    ''' </summary>
    ''' <param name="view">The view that the presenter will manage.</param>
    ''' <param name="service">The service containing the customer business logic.</param>
    ''' <param name="logger">The logging service for recording application events.</param>
    ''' <param name="messagingService">The messaging service for user notifications.</param>
    ''' <param name="localizationService">The localization service for language strings.</param>
    Public Sub New(view As ICustomerView, service As ICustomerService, logger As ILogger, messagingService As IMessagingService, localizationService As ILocalizationService, uiLocalizationManager As IUiLocalizationManager)
        _view = view
        _service = service
        _logger = logger
        _messagingService = messagingService
        _localizationService = localizationService
        _uiLocalizationManager = uiLocalizationManager
        AddHandler _view.LoadView, AddressOf OnLoadView
        AddHandler _view.SaveCustomer, AddressOf OnSaveCustomer
        AddHandler _view.DeleteCustomer, AddressOf OnDeleteCustomer
        AddHandler _view.ClearView, AddressOf OnClearView
        AddHandler _view.EditCustomer, AddressOf OnEditCustomer
        AddHandler _view.LanguageChanged, AddressOf OnLanguageChanged
    End Sub

    ''' <summary>
    ''' Handles the event when the view is loaded.
    ''' </summary>
    Private Sub OnLoadView(sender As Object, e As EventArgs)
        Try
            ' Load initial data
            Dim customers As List(Of CustomerDTO) = _service.GetCustomers()
            _view.DisplayCustomers(customers)
            _view.ClearCustomerDetails()
            _view.SetEditMode(False)

            ' Get available languages from the localization service and pass them to the view
            Dim availableLanguages = _localizationService.GetAvailableLanguages()
            _view.DisplayLanguages(availableLanguages)

            ' Set initial localized text and layout
            Dim localizedStrings As Dictionary(Of String, String) = _localizationService.GetLocalizedStrings("CustomerModule")
            _view.SetLocalizedText(_uiLocalizationManager, localizedStrings)
            _view.SetRightToLeft(_localizationService.IsRightToLeft)

            _logger.LogInfo("Customer view loaded successfully.")
        Catch ex As Exception
            _logger.LogException(ex)
            _messagingService.ShowError("Error during view load: " & ex.Message)
        End Try
        'Try
        '    ' Set the UI language and layout direction on form load.
        '    _view.SetRightToLeft(_localizationService.IsRightToLeft)

        '    ' Update all UI text based on the selected language.
        '    SetUIText()

        '    _logger.LogInfo("Loading customer view.")
        '    Dim customers As List(Of CustomerDTO) = _customerService.GetCustomers()
        '    _view.DisplayCustomers(customers)
        'Catch ex As Exception
        '    _logger.LogException(ex)
        '    _messagingService.ShowError("An error occurred while loading customers.")
        'End Try
    End Sub

    ''' <summary>
    ''' Handles the event to save a customer.
    ''' </summary>
    Private Sub OnSaveCustomer(customer As CustomerDTO)
        Dim result As ValidationResult = _service.SaveCustomer(customer)
        If result.IsValid Then
            _messagingService.ShowSuccess(_localizationService.GetString("CustomerSaved"))
            _view.ClearCustomerDetails()
            OnLoadView(Nothing, EventArgs.Empty)
        Else
            _messagingService.ShowError(_localizationService.GetString(result.ErrorMessage))
        End If
    End Sub

    ''' <summary>
    ''' Handles the event to delete a customer.
    ''' </summary>
    Private Sub OnDeleteCustomer(customerID As Integer)
        Dim result As ValidationResult = _service.DeleteCustomer(customerID)
        If result.IsValid Then
            _messagingService.ShowSuccess(_localizationService.GetString("CustomerDeleted"))
            _view.ClearCustomerDetails()
            OnLoadView(Nothing, EventArgs.Empty)
        Else
            _messagingService.ShowError(_localizationService.GetString(result.ErrorMessage))
        End If
    End Sub

    ''' <summary>
    ''' Handles the event to clear the view.
    ''' </summary>
    Private Sub OnClearView(sender As Object, e As EventArgs)
        _view.ClearCustomerDetails()
        _view.SetEditMode(False)
    End Sub

    ''' <summary>
    ''' Handles the event to edit a customer.
    ''' </summary>
    Private Sub OnEditCustomer(customer As CustomerDTO)
        _view.DisplayCustomerDetails(customer)
        _view.SetEditMode(True)
    End Sub

    '''' <summary>
    '''' Sets the UI text on the view using the localization service.
    '''' </summary>
    'Private Sub SetUIText()
    '    _view.SetLocalizedText(_localizationService.GetLocalizedStrings("CustomerModule"))
    'End Sub

    ''' <summary>
    ''' Handles the event when the user changes the language.
    ''' </summary>
    Private Sub OnLanguageChanged(languageCode As String)
        _localizationService.SetLanguage(languageCode)
        Dim localizedStrings As Dictionary(Of String, String) = _localizationService.GetLocalizedStrings("CustomerModule")
        _view.SetLocalizedText(_uiLocalizationManager, localizedStrings)
        _view.SetRightToLeft(_localizationService.IsRightToLeft)
        '_localizationService.SetLanguage(languageCode)
        '_view.SetRightToLeft(_localizationService.IsRightToLeft)
        'SetUIText()
    End Sub
End Class


'Imports AATM.Core.Logging
'Imports AATM.Core.Messaging
'Imports AATM.Core.Localization
'Imports AATM.Modules.Customers
'Imports System.Collections.Generic

'''' <summary>
'''' The Presenter for the customer management feature.
'''' This class mediates between the View (the UI) and the Model (the business logic).
'''' </summary>
'Public Class CustomerPresenter
'    Private ReadOnly _view As ICustomerView
'    Private ReadOnly _customerService As ICustomerService
'    Private ReadOnly _logger As ILogger
'    Private ReadOnly _messagingService As IMessagingService
'    Private ReadOnly _localizationService As ILocalizationService

'    ''' <summary>
'    ''' Initializes a new instance of the CustomerPresenter class.
'    ''' </summary>
'    ''' <param name="view">The view that the presenter will manage.</param>
'    ''' <param name="customerService">The service containing the customer business logic.</param>
'    ''' <param name="logger">The logging service for recording application events.</param>
'    ''' <param name="messagingService">The messaging service for user notifications.</param>
'    ''' <param name="localizationService">The localization service for language strings.</param>
'    Public Sub New(view As ICustomerView, customerService As ICustomerService, logger As ILogger, messagingService As IMessagingService, localizationService As ILocalizationService)
'        _view = view
'        _customerService = customerService
'        _logger = logger
'        _messagingService = messagingService
'        _localizationService = localizationService
'        AddHandler _view.LoadView, AddressOf OnLoadView
'        AddHandler _view.SaveCustomer, AddressOf OnSaveCustomer
'        AddHandler _view.DeleteCustomer, AddressOf OnDeleteCustomer
'        AddHandler _view.ClearView, AddressOf OnClearView
'        AddHandler _view.EditCustomer, AddressOf OnEditCustomer
'        AddHandler _view.LanguageChanged, AddressOf OnLanguageChanged
'    End Sub

'    ''' <summary>
'    ''' Handles the event when the view is loaded.
'    ''' </summary>
'    Private Sub OnLoadView(sender As Object, e As EventArgs)
'        Try
'            ' Set the UI language and layout direction on form load.
'            _view.SetRightToLeft(_localizationService.IsRightToLeft)

'            ' Update all UI text based on the selected language.
'            SetUIText()

'            _logger.LogInfo("Loading customer view.")
'            Dim customers As List(Of CustomerDTO) = _customerService.GetCustomers()
'            _view.DisplayCustomers(customers)
'        Catch ex As Exception
'            _logger.LogException(ex)
'            _messagingService.ShowError("An error occurred while loading customers.")
'        End Try
'    End Sub

'    ''' <summary>
'    ''' Handles the event to save a customer.
'    ''' </summary>
'    Private Sub OnSaveCustomer(customer As CustomerDTO)
'        Dim result As ValidationResult = _customerService.SaveCustomer(customer)
'        If result.IsValid Then
'            _messagingService.ShowSuccess(_localizationService.GetString("CustomerSaved"))
'            _view.ClearCustomerDetails()
'            OnLoadView(Nothing, EventArgs.Empty)
'        Else
'            _messagingService.ShowError(_localizationService.GetString(result.ErrorMessage))
'        End If
'    End Sub

'    ''' <summary>
'    ''' Handles the event to delete a customer.
'    ''' </summary>
'    Private Sub OnDeleteCustomer(customerID As Integer)
'        Dim result As ValidationResult = _customerService.DeleteCustomer(customerID)
'        If result.IsValid Then
'            _messagingService.ShowSuccess(_localizationService.GetString("CustomerDeleted"))
'            _view.ClearCustomerDetails()
'            OnLoadView(Nothing, EventArgs.Empty)
'        Else
'            _messagingService.ShowError(_localizationService.GetString(result.ErrorMessage))
'        End If
'    End Sub

'    ''' <summary>
'    ''' Handles the event to clear the view.
'    ''' </summary>
'    Private Sub OnClearView(sender As Object, e As EventArgs)
'        _view.ClearCustomerDetails()
'        _view.SetEditMode(False)
'    End Sub

'    ''' <summary>
'    ''' Handles the event to edit a customer.
'    ''' </summary>
'    Private Sub OnEditCustomer(customer As CustomerDTO)
'        _view.DisplayCustomerDetails(customer)
'        _view.SetEditMode(True)
'    End Sub

'    ''' <summary>
'    ''' Sets the UI text on the view using the localization service.
'    ''' </summary>
'    Private Sub SetUIText()
'        _view.SetLocalizedText(_localizationService.GetLocalizedStrings("CustomerModule"))
'    End Sub

'    ''' <summary>
'    ''' Handles the event when the user changes the language.
'    ''' </summary>
'    Private Sub OnLanguageChanged(languageCode As String) Handles _view.LanguageChanged
'        _localizationService.SetLanguage(languageCode)
'        _view.SetRightToLeft(_localizationService.IsRightToLeft)
'        SetUIText()
'    End Sub
'End Class




'Imports AATM.Core.Localization
'Imports AATM.Core.Logging
'Imports AATM.Core.Messaging
'Imports AATM.Modules.Customers
'Imports System.Collections.Generic

'''' <summary>
'''' The Presenter for the customer management feature.
'''' This class mediates between the View (the UI) and the Model (the business logic).
'''' </summary>
'Public Class CustomerPresenter
'    Private ReadOnly _view As ICustomerView
'    Private ReadOnly _customerService As ICustomerService
'    Private ReadOnly _logger As ILogger
'    Private ReadOnly _messagingService As IMessagingService

'    ''' <summary>
'    ''' Initializes a new instance of the CustomerPresenter class.
'    ''' </summary>
'    ''' <param name="view">The view that the presenter will manage.</param>
'    ''' <param name="customerService">The service containing the customer business logic.</param>
'    ''' <param name="logger">The logging service for recording application events.</param>
'    ''' <param name="messagingService">The messaging service for user notifications.</param>
'    Public Sub New(view As ICustomerView, customerService As ICustomerService, logger As ILogger, messagingService As IMessagingService, localizationService As ILocalizationService)
'        _view = view
'        _customerService = customerService
'        _logger = logger
'        _messagingService = messagingService
'        AddHandler _view.LoadView, AddressOf OnLoadView
'        AddHandler _view.SaveCustomer, AddressOf OnSaveCustomer
'        AddHandler _view.DeleteCustomer, AddressOf OnDeleteCustomer
'        AddHandler _view.ClearView, AddressOf OnClearView
'        AddHandler _view.EditCustomer, AddressOf OnEditCustomer
'    End Sub

'    ''' <summary>
'    ''' Handles the event when the view is loaded.
'    ''' </summary>
'    Private Sub OnLoadView(sender As Object, e As EventArgs)
'        Try
'            _logger.LogInfo("Loading customer view.")
'            Dim customers As List(Of CustomerDTO) = _customerService.GetCustomers()
'            _view.DisplayCustomers(customers)
'        Catch ex As Exception
'            _logger.LogException(ex)
'            _messagingService.ShowError("An error occurred while loading customers.")
'        End Try
'    End Sub

'    ''' <summary>
'    ''' Handles the event to save a customer.
'    ''' </summary>
'    Private Sub OnSaveCustomer(customer As CustomerDTO)
'        Dim result As ValidationResult = _customerService.SaveCustomer(customer)
'        If result.IsValid Then
'            _messagingService.ShowSuccess("Customer saved successfully.")
'            _view.ClearCustomerDetails()
'            OnLoadView(Nothing, EventArgs.Empty)
'        Else
'            _messagingService.ShowError(result.ErrorMessage)
'        End If
'    End Sub

'    ''' <summary>
'    ''' Handles the event to delete a customer.
'    ''' </summary>
'    Private Sub OnDeleteCustomer(customerID As Integer)
'        Dim result As ValidationResult = _customerService.DeleteCustomer(customerID)
'        If result.IsValid Then
'            _messagingService.ShowSuccess("Customer deleted successfully.")
'            _view.ClearCustomerDetails()
'            OnLoadView(Nothing, EventArgs.Empty)
'        Else
'            _messagingService.ShowError(result.ErrorMessage)
'        End If
'    End Sub

'    ''' <summary>
'    ''' Handles the event to clear the view.
'    ''' </summary>
'    Private Sub OnClearView(sender As Object, e As EventArgs)
'        _view.ClearCustomerDetails()
'        _view.SetEditMode(False)
'    End Sub

'    ''' <summary>
'    ''' Handles the event to edit a customer.
'    ''' </summary>
'    Private Sub OnEditCustomer(customer As CustomerDTO)
'        _view.DisplayCustomerDetails(customer)
'        _view.SetEditMode(True)
'    End Sub

'End Class


'Imports AATM.Core.Logging
'Imports AATM.Core.Messaging
'Imports AATM.Modules.Customers
'Imports System.Collections.Generic

'''' <summary>
'''' The Presenter for the customer management feature.
'''' This class mediates between the View (the UI) and the Model (the business logic).
'''' </summary>
'Public Class CustomerPresenter
'    Private ReadOnly _view As ICustomerView
'    Private ReadOnly _customerService As ICustomerService
'    Private ReadOnly _logger As ILogger
'    Private ReadOnly _messagingService As IMessagingService

'    ''' <summary>
'    ''' Initializes a new instance of the CustomerPresenter class.
'    ''' </summary>
'    ''' <param name="view">The view that the presenter will manage.</param>
'    ''' <param name="customerService">The service containing the customer business logic.</param>
'    ''' <param name="logger">The logging service for recording application events.</param>
'    ''' <param name="messagingService">The messaging service for user notifications.</param>
'    Public Sub New(view As ICustomerView, customerService As ICustomerService, logger As ILogger, messagingService As IMessagingService)
'        _view = view
'        _customerService = customerService
'        _logger = logger
'        _messagingService = messagingService
'        AddHandler _view.LoadView, AddressOf OnLoadView
'        AddHandler _view.SaveCustomer, AddressOf OnSaveCustomer
'        AddHandler _view.DeleteCustomer, AddressOf OnDeleteCustomer
'        AddHandler _view.ClearView, AddressOf OnClearView
'        AddHandler _view.EditCustomer, AddressOf OnEditCustomer
'    End Sub

'    ''' <summary>
'    ''' Handles the event when the view is loaded.
'    ''' </summary>
'    Private Sub OnLoadView(sender As Object, e As EventArgs)
'        Try
'            _logger.LogInfo("Loading customer view.")
'            Dim customers As List(Of CustomerDTO) = _customerService.GetCustomers()
'            _view.DisplayCustomers(customers)
'        Catch ex As Exception
'            _logger.LogException(ex)
'            _messagingService.ShowError("An error occurred while loading customers.")
'        End Try
'    End Sub

'    ''' <summary>
'    ''' Handles the event to save a customer.
'    ''' </summary>
'    Private Sub OnSaveCustomer(customer As CustomerDTO)
'        Dim result As ValidationResult = _customerService.SaveCustomer(customer)
'        If result.IsValid Then
'            _messagingService.ShowSuccess("Customer saved successfully.")
'            OnLoadView(Nothing, EventArgs.Empty)
'        Else
'            _messagingService.ShowError(result.ErrorMessage)
'        End If
'    End Sub


'    ''' <summary>
'    ''' Handles the event to delete a customer.
'    ''' </summary>
'    Private Sub OnDeleteCustomer(customerID As Integer)
'        Dim result As ValidationResult = _customerService.DeleteCustomer(customerID)
'        If result.IsValid Then
'            _messagingService.ShowSuccess("Customer deleted successfully.")
'            _view.ClearCustomerDetails()
'            OnLoadView(Nothing, EventArgs.Empty)
'        Else
'            _messagingService.ShowError(result.ErrorMessage)
'        End If
'    End Sub

'    ''' <summary>
'    ''' Handles the event to clear the view.
'    ''' </summary>
'    Private Sub OnClearView(sender As Object, e As EventArgs)
'        _view.ClearCustomerDetails()
'        _view.SetEditMode(False)
'    End Sub

'    ''' <summary>
'    ''' Handles the event to edit a customer.
'    ''' </summary>
'    Private Sub OnEditCustomer(customer As CustomerDTO)
'        _view.DisplayCustomerDetails(customer)
'        _view.SetEditMode(True)
'    End Sub

'End Class


''Imports AATM.Core.Logging
''Imports AATM.Core.Messaging

''''' <summary>
''''' The Presenter for the customer management feature. It mediates between the View and the Model.
''''' </summary>
''Public Class CustomerPresenter

''    Private ReadOnly _view As ICustomerView
''    Private ReadOnly _customerService As ICustomerService
''    Private ReadOnly _messagingService As IMessagingService
''    Private ReadOnly _logger As ILogger

''    ''' <summary>
''    ''' Initializes a new instance of the CustomerPresenter class.
''    ''' </summary>
''    Public Sub New(view As ICustomerView, customerService As ICustomerService, messagingService As IMessagingService, logger As ILogger)
''        _view = view
''        _customerService = customerService
''        _messagingService = messagingService
''        _logger = logger

''        ' Add handlers for events raised by the View
''        AddHandler _view.LoadCustomers, AddressOf Me.OnLoadCustomers
''        AddHandler _view.SaveCustomer, AddressOf Me.OnSaveCustomer
''    End Sub

''    Private Sub OnLoadCustomers(sender As Object, e As EventArgs)
''        Try
''            _view.EnableView(False) ' Disable the view during the operation
''            _messagingService.ShowInformation("Loading customers...")

''            Dim customers As List(Of CustomerDTO) = _customerService.GetCustomers()
''            _view.DisplayCustomers(customers)

''            _messagingService.ShowSuccess("Customers loaded successfully.")
''            _logger.LogInfo("Customers loaded.")
''        Catch ex As Exception
''            _messagingService.ShowError("Failed to load customers.")
''            _logger.LogException(ex)
''        Finally
''            _view.EnableView(True) ' Re-enable the view
''        End Try
''    End Sub

''    Private Sub OnSaveCustomer(customer As CustomerDTO)
''        Try
''            _view.EnableView(False)
''            _messagingService.ShowInformation("Saving customer...")

''            ' Use type inference to avoid ambiguous type issues
''            Dim result = _customerService.SaveCustomer(customer)

''            If result.IsValid Then
''                _messagingService.ShowSuccess("Customer saved successfully.")
''                _logger.LogInfo("Customer saved successfully.")
''                ' Refresh the customer list after saving.
''                OnLoadCustomers(Nothing, EventArgs.Empty)
''            Else
''                _messagingService.ShowError("Validation Error: " & result.ErrorMessage)
''                _logger.LogError("Validation Error: " & result.ErrorMessage)
''            End If
''        Catch ex As Exception
''            _messagingService.ShowError("An error occurred while saving the customer.")
''            _logger.LogException(ex)
''        Finally
''            _view.EnableView(True)
''        End Try
''    End Sub

''End Class

