//// File: MyProject.Business/CustomerPresenter.cs
////
//// This presenter class is part of the business layer. It gets its translations
//// by calling the TranslationService with the necessary context.

//using System;
//using AATM.Contracts;
//using AATM.Business.Logic; // Assuming TranslationService is here

//namespace MyProject.Business
//{
//    /// <summary>
//    /// Handles the business logic for customer-related views.
//    /// </summary>
//    public class CustomerPresenter
//    {
//        private readonly TranslationService _translationService;

//        public CustomerPresenter(TranslationService translationService)
//        {
//            _translationService = translationService ?? throw new ArgumentNullException(nameof(translationService));
//        }

//        /// <summary>
//        /// Gets a translated string for a specific UI identifier.
//        /// </summary>
//        /// <param name="originalString">The string to translate.</param>
//        /// <param name="languageCode">The target language code.</param>
//        /// <param name="uiIdentifier">A unique identifier for the string in the UI.</param>
//        /// <returns>The translated string.</returns>
//        public string GetString(string originalString, string languageCode, string uiIdentifier)
//        {
//            var TranslationDto = _translationService.Translate(
//                originalString: originalString,
//                languageCode: languageCode,
//                moduleName: this.GetType().Name, // Using the class name for the module identifier
//                uiIdentifier: uiIdentifier
//            );

//            return TranslationDto.LocalizedString;
//        }

//        // Example of how to use the GetString method.
//        public void LoadCustomerDetails(string languageCode)
//        {
//            string welcomeMessage = GetString("Welcome to the customer dashboard!", languageCode, "WelcomeMessageLabel");
//            string saveButtonText = GetString("Save", languageCode, "SaveButton");

//            // ... use the translated strings to update the UI
//            // (e.g., this.welcomeLabel.Text = welcomeMessage;)
//        }
//    }
//}


using System;
using System.Collections.Generic;
using AATM.Contracts;
using AATM.Core.Localization;

namespace AATM.Modules.Customers
{

    /// <summary>
    /// The Presenter for the customer management feature.
    /// This class mediates between the View (the UI) and the Model (the business logic).
    /// </summary>
    public class CustomerPresenter
    {
        private readonly ICustomerView _view;
        private readonly ICustomerService _service;
        private readonly ILogger _logger;
        private readonly IMessagingService _messagingService;
        private readonly ILocalizationService _localizationService;
        private readonly IUiLocalizationManager _uiLocalizationManager;

        /// <summary>
        /// Initializes a new instance of the CustomerPresenter class.
        /// </summary>
        /// <param name="view">The view that the presenter will manage.</param>
        /// <param name="service">The service containing the customer business logic.</param>
        /// <param name="logger">The logging service for recording application events.</param>
        /// <param name="messagingService">The messaging service for user notifications.</param>
        /// <param name="localizationService">The localization service for language strings.</param>
        public CustomerPresenter(ICustomerView view, ICustomerService service, ILogger logger, IMessagingService messagingService, ILocalizationService localizationService, IUiLocalizationManager uiLocalizationManager)
        {
            _view = view;
            _service = service;
            _logger = logger;
            _messagingService = messagingService;
            _localizationService = localizationService;
            _uiLocalizationManager = uiLocalizationManager;
            _view.LoadView += OnLoadView;
            _view.SaveCustomer += OnSaveCustomer;
            _view.DeleteCustomer += OnDeleteCustomer;
            _view.ClearView += OnClearView;
            _view.EditCustomer += OnEditCustomer;
            _view.LanguageChanged += OnLanguageChanged;
        }

        /// <summary>
        /// Handles the event when the view is loaded.
        /// </summary>
        private void OnLoadView(object sender, EventArgs e)
        {
            try
            {
                // Load initial data
                var customers = _service.GetCustomers();
                _view.DisplayCustomers(customers);
                _view.ClearCustomerDetails();
                _view.SetEditMode(false);

                // Get available languages from the localization service and pass them to the view
                var availableLanguages = _localizationService.GetAvailableLanguages();
                _view.DisplayLanguages(availableLanguages);

                // Set initial localized text and layout
                Dictionary<string, string> localizedStrings = _localizationService.GetLocalizedStrings()["CustomerModule"];
                _view.SetLocalizedText(_uiLocalizationManager, localizedStrings);
                _view.SetRightToLeft(_localizationService.IsRightToLeft);

                _logger.LogInfo("Customer view loaded successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                _messagingService.ShowError("Error during view load: " + ex.Message);
            }
            // Try
            // ' Set the UI language and layout direction on form load.
            // _view.SetRightToLeft(_localizationService.IsRightToLeft)

            // ' Update all UI text based on the selected language.
            // SetUIText()

            // _logger.LogInfo("Loading customer view.")
            // Dim customers As List(Of CustomerDTO) = _customerService.GetCustomers()
            // _view.DisplayCustomers(customers)
            // Catch ex As Exception
            // _logger.LogException(ex)
            // _messagingService.ShowError("An error occurred while loading customers.")
            // End Try
        }

        /// <summary>
        /// Handles the event to save a customer.
        /// </summary>
        private void OnSaveCustomer(CustomerDTO customer)
        {
            var result = _service.SaveCustomer(customer);
            if (result.IsValid)
            {
                _messagingService.ShowSuccess(_localizationService.GetString("CustomerSaved"));
                _view.ClearCustomerDetails();
                OnLoadView(null, EventArgs.Empty);
            }
            else
            {
                _messagingService.ShowError(_localizationService.GetString(result.ErrorMessage));
            }
        }

        /// <summary>
        /// Handles the event to delete a customer.
        /// </summary>
        private void OnDeleteCustomer(int customerID)
        {
            var result = _service.DeleteCustomer(customerID);
            if (result.IsValid)
            {
                _messagingService.ShowSuccess(_localizationService.GetString("CustomerDeleted"));
                _view.ClearCustomerDetails();
                OnLoadView(null, EventArgs.Empty);
            }
            else
            {
                _messagingService.ShowError(_localizationService.GetString(result.ErrorMessage));
            }
        }

        /// <summary>
        /// Handles the event to clear the view.
        /// </summary>
        private void OnClearView(object sender, EventArgs e)
        {
            _view.ClearCustomerDetails();
            _view.SetEditMode(false);
        }

        /// <summary>
        /// Handles the event to edit a customer.
        /// </summary>
        private void OnEditCustomer(CustomerDTO customer)
        {
            _view.DisplayCustomerDetails(customer);
            _view.SetEditMode(true);
        }

        // ''' <summary>
        // ''' Sets the UI text on the view using the localization service.
        // ''' </summary>
        // Private Sub SetUIText()
        // _view.SetLocalizedText(_localizationService.GetLocalizedStrings("CustomerModule"))
        // End Sub

        /// <summary>
        /// Handles the event when the user changes the language.
        /// </summary>
        private void OnLanguageChanged(string languageCode)
        {
            _localizationService.SetLanguage(languageCode);
            Dictionary<string, string> localizedStrings = _localizationService.GetLocalizedStrings()["CustomerModule"];
            _view.SetLocalizedText(_uiLocalizationManager, localizedStrings);
            _view.SetRightToLeft(_localizationService.IsRightToLeft);
            // _localizationService.SetLanguage(languageCode)
            // _view.SetRightToLeft(_localizationService.IsRightToLeft)
            // SetUIText()
        }
    }
}


//// Imports AATM.Core.Logging
//// Imports AATM.Core.Messaging
//// Imports AATM.Core.Localization
//// Imports AATM.Modules.Customers
//// Imports System.Collections.Generic

//// ''' <summary>
//// ''' The Presenter for the customer management feature.
//// ''' This class mediates between the View (the UI) and the Model (the business logic).
//// ''' </summary>
//// Public Class CustomerPresenter
//// Private ReadOnly _view As ICustomerView
//// Private ReadOnly _customerService As ICustomerService
//// Private ReadOnly _logger As ILogger
//// Private ReadOnly _messagingService As IMessagingService
//// Private ReadOnly _localizationService As ILocalizationService

//// ''' <summary>
//// ''' Initializes a new instance of the CustomerPresenter class.
//// ''' </summary>
//// ''' <param name="view">The view that the presenter will manage.</param>
//// ''' <param name="customerService">The service containing the customer business logic.</param>
//// ''' <param name="logger">The logging service for recording application events.</param>
//// ''' <param name="messagingService">The messaging service for user notifications.</param>
//// ''' <param name="localizationService">The localization service for language strings.</param>
//// Public Sub New(view As ICustomerView, customerService As ICustomerService, logger As ILogger, messagingService As IMessagingService, localizationService As ILocalizationService)
//// _view = view
//// _customerService = customerService
//// _logger = logger
//// _messagingService = messagingService
//// _localizationService = localizationService
//// AddHandler _view.LoadView, AddressOf OnLoadView
//// AddHandler _view.SaveCustomer, AddressOf OnSaveCustomer
//// AddHandler _view.DeleteCustomer, AddressOf OnDeleteCustomer
//// AddHandler _view.ClearView, AddressOf OnClearView
//// AddHandler _view.EditCustomer, AddressOf OnEditCustomer
//// AddHandler _view.LanguageChanged, AddressOf OnLanguageChanged
//// End Sub

//// ''' <summary>
//// ''' Handles the event when the view is loaded.
//// ''' </summary>
//// Private Sub OnLoadView(sender As Object, e As EventArgs)
//// Try
//// ' Set the UI language and layout direction on form load.
//// _view.SetRightToLeft(_localizationService.IsRightToLeft)

//// ' Update all UI text based on the selected language.
//// SetUIText()

//// _logger.LogInfo("Loading customer view.")
//// Dim customers As List(Of CustomerDTO) = _customerService.GetCustomers()
//// _view.DisplayCustomers(customers)
//// Catch ex As Exception
//// _logger.LogException(ex)
//// _messagingService.ShowError("An error occurred while loading customers.")
//// End Try
//// End Sub

//// ''' <summary>
//// ''' Handles the event to save a customer.
//// ''' </summary>
//// Private Sub OnSaveCustomer(customer As CustomerDTO)
//// Dim result As ValidationResult = _customerService.SaveCustomer(customer)
//// If result.IsValid Then
//// _messagingService.ShowSuccess(_localizationService.GetString("CustomerSaved"))
//// _view.ClearCustomerDetails()
//// OnLoadView(Nothing, EventArgs.Empty)
//// Else
//// _messagingService.ShowError(_localizationService.GetString(result.ErrorMessage))
//// End If
//// End Sub

//// ''' <summary>
//// ''' Handles the event to delete a customer.
//// ''' </summary>
//// Private Sub OnDeleteCustomer(customerID As Integer)
//// Dim result As ValidationResult = _customerService.DeleteCustomer(customerID)
//// If result.IsValid Then
//// _messagingService.ShowSuccess(_localizationService.GetString("CustomerDeleted"))
//// _view.ClearCustomerDetails()
//// OnLoadView(Nothing, EventArgs.Empty)
//// Else
//// _messagingService.ShowError(_localizationService.GetString(result.ErrorMessage))
//// End If
//// End Sub

//// ''' <summary>
//// ''' Handles the event to clear the view.
//// ''' </summary>
//// Private Sub OnClearView(sender As Object, e As EventArgs)
//// _view.ClearCustomerDetails()
//// _view.SetEditMode(False)
//// End Sub

//// ''' <summary>
//// ''' Handles the event to edit a customer.
//// ''' </summary>
//// Private Sub OnEditCustomer(customer As CustomerDTO)
//// _view.DisplayCustomerDetails(customer)
//// _view.SetEditMode(True)
//// End Sub

//// ''' <summary>
//// ''' Sets the UI text on the view using the localization service.
//// ''' </summary>
//// Private Sub SetUIText()
//// _view.SetLocalizedText(_localizationService.GetLocalizedStrings("CustomerModule"))
//// End Sub

//// ''' <summary>
//// ''' Handles the event when the user changes the language.
//// ''' </summary>
//// Private Sub OnLanguageChanged(languageCode As String) Handles _view.LanguageChanged
//// _localizationService.SetLanguage(languageCode)
//// _view.SetRightToLeft(_localizationService.IsRightToLeft)
//// SetUIText()
//// End Sub
//// End Class




//// Imports AATM.Core.Localization
//// Imports AATM.Core.Logging
//// Imports AATM.Core.Messaging
//// Imports AATM.Modules.Customers
//// Imports System.Collections.Generic

//// ''' <summary>
//// ''' The Presenter for the customer management feature.
//// ''' This class mediates between the View (the UI) and the Model (the business logic).
//// ''' </summary>
//// Public Class CustomerPresenter
//// Private ReadOnly _view As ICustomerView
//// Private ReadOnly _customerService As ICustomerService
//// Private ReadOnly _logger As ILogger
//// Private ReadOnly _messagingService As IMessagingService

//// ''' <summary>
//// ''' Initializes a new instance of the CustomerPresenter class.
//// ''' </summary>
//// ''' <param name="view">The view that the presenter will manage.</param>
//// ''' <param name="customerService">The service containing the customer business logic.</param>
//// ''' <param name="logger">The logging service for recording application events.</param>
//// ''' <param name="messagingService">The messaging service for user notifications.</param>
//// Public Sub New(view As ICustomerView, customerService As ICustomerService, logger As ILogger, messagingService As IMessagingService, localizationService As ILocalizationService)
//// _view = view
//// _customerService = customerService
//// _logger = logger
//// _messagingService = messagingService
//// AddHandler _view.LoadView, AddressOf OnLoadView
//// AddHandler _view.SaveCustomer, AddressOf OnSaveCustomer
//// AddHandler _view.DeleteCustomer, AddressOf OnDeleteCustomer
//// AddHandler _view.ClearView, AddressOf OnClearView
//// AddHandler _view.EditCustomer, AddressOf OnEditCustomer
//// End Sub

//// ''' <summary>
//// ''' Handles the event when the view is loaded.
//// ''' </summary>
//// Private Sub OnLoadView(sender As Object, e As EventArgs)
//// Try
//// _logger.LogInfo("Loading customer view.")
//// Dim customers As List(Of CustomerDTO) = _customerService.GetCustomers()
//// _view.DisplayCustomers(customers)
//// Catch ex As Exception
//// _logger.LogException(ex)
//// _messagingService.ShowError("An error occurred while loading customers.")
//// End Try
//// End Sub

//// ''' <summary>
//// ''' Handles the event to save a customer.
//// ''' </summary>
//// Private Sub OnSaveCustomer(customer As CustomerDTO)
//// Dim result As ValidationResult = _customerService.SaveCustomer(customer)
//// If result.IsValid Then
//// _messagingService.ShowSuccess("Customer saved successfully.")
//// _view.ClearCustomerDetails()
//// OnLoadView(Nothing, EventArgs.Empty)
//// Else
//// _messagingService.ShowError(result.ErrorMessage)
//// End If
//// End Sub

//// ''' <summary>
//// ''' Handles the event to delete a customer.
//// ''' </summary>
//// Private Sub OnDeleteCustomer(customerID As Integer)
//// Dim result As ValidationResult = _customerService.DeleteCustomer(customerID)
//// If result.IsValid Then
//// _messagingService.ShowSuccess("Customer deleted successfully.")
//// _view.ClearCustomerDetails()
//// OnLoadView(Nothing, EventArgs.Empty)
//// Else
//// _messagingService.ShowError(result.ErrorMessage)
//// End If
//// End Sub

//// ''' <summary>
//// ''' Handles the event to clear the view.
//// ''' </summary>
//// Private Sub OnClearView(sender As Object, e As EventArgs)
//// _view.ClearCustomerDetails()
//// _view.SetEditMode(False)
//// End Sub

//// ''' <summary>
//// ''' Handles the event to edit a customer.
//// ''' </summary>
//// Private Sub OnEditCustomer(customer As CustomerDTO)
//// _view.DisplayCustomerDetails(customer)
//// _view.SetEditMode(True)
//// End Sub

//// End Class


//// Imports AATM.Core.Logging
//// Imports AATM.Core.Messaging
//// Imports AATM.Modules.Customers
//// Imports System.Collections.Generic

//// ''' <summary>
//// ''' The Presenter for the customer management feature.
//// ''' This class mediates between the View (the UI) and the Model (the business logic).
//// ''' </summary>
//// Public Class CustomerPresenter
//// Private ReadOnly _view As ICustomerView
//// Private ReadOnly _customerService As ICustomerService
//// Private ReadOnly _logger As ILogger
//// Private ReadOnly _messagingService As IMessagingService

//// ''' <summary>
//// ''' Initializes a new instance of the CustomerPresenter class.
//// ''' </summary>
//// ''' <param name="view">The view that the presenter will manage.</param>
//// ''' <param name="customerService">The service containing the customer business logic.</param>
//// ''' <param name="logger">The logging service for recording application events.</param>
//// ''' <param name="messagingService">The messaging service for user notifications.</param>
//// Public Sub New(view As ICustomerView, customerService As ICustomerService, logger As ILogger, messagingService As IMessagingService)
//// _view = view
//// _customerService = customerService
//// _logger = logger
//// _messagingService = messagingService
//// AddHandler _view.LoadView, AddressOf OnLoadView
//// AddHandler _view.SaveCustomer, AddressOf OnSaveCustomer
//// AddHandler _view.DeleteCustomer, AddressOf OnDeleteCustomer
//// AddHandler _view.ClearView, AddressOf OnClearView
//// AddHandler _view.EditCustomer, AddressOf OnEditCustomer
//// End Sub

//// ''' <summary>
//// ''' Handles the event when the view is loaded.
//// ''' </summary>
//// Private Sub OnLoadView(sender As Object, e As EventArgs)
//// Try
//// _logger.LogInfo("Loading customer view.")
//// Dim customers As List(Of CustomerDTO) = _customerService.GetCustomers()
//// _view.DisplayCustomers(customers)
//// Catch ex As Exception
//// _logger.LogException(ex)
//// _messagingService.ShowError("An error occurred while loading customers.")
//// End Try
//// End Sub

//// ''' <summary>
//// ''' Handles the event to save a customer.
//// ''' </summary>
//// Private Sub OnSaveCustomer(customer As CustomerDTO)
//// Dim result As ValidationResult = _customerService.SaveCustomer(customer)
//// If result.IsValid Then
//// _messagingService.ShowSuccess("Customer saved successfully.")
//// OnLoadView(Nothing, EventArgs.Empty)
//// Else
//// _messagingService.ShowError(result.ErrorMessage)
//// End If
//// End Sub


//// ''' <summary>
//// ''' Handles the event to delete a customer.
//// ''' </summary>
//// Private Sub OnDeleteCustomer(customerID As Integer)
//// Dim result As ValidationResult = _customerService.DeleteCustomer(customerID)
//// If result.IsValid Then
//// _messagingService.ShowSuccess("Customer deleted successfully.")
//// _view.ClearCustomerDetails()
//// OnLoadView(Nothing, EventArgs.Empty)
//// Else
//// _messagingService.ShowError(result.ErrorMessage)
//// End If
//// End Sub

//// ''' <summary>
//// ''' Handles the event to clear the view.
//// ''' </summary>
//// Private Sub OnClearView(sender As Object, e As EventArgs)
//// _view.ClearCustomerDetails()
//// _view.SetEditMode(False)
//// End Sub

//// ''' <summary>
//// ''' Handles the event to edit a customer.
//// ''' </summary>
//// Private Sub OnEditCustomer(customer As CustomerDTO)
//// _view.DisplayCustomerDetails(customer)
//// _view.SetEditMode(True)
//// End Sub

//// End Class


//// 'Imports AATM.Core.Logging
//// 'Imports AATM.Core.Messaging

//// '''' <summary>
//// '''' The Presenter for the customer management feature. It mediates between the View and the Model.
//// '''' </summary>
//// 'Public Class CustomerPresenter

//// '    Private ReadOnly _view As ICustomerView
//// '    Private ReadOnly _customerService As ICustomerService
//// '    Private ReadOnly _messagingService As IMessagingService
//// '    Private ReadOnly _logger As ILogger

//// '    ''' <summary>
//// '    ''' Initializes a new instance of the CustomerPresenter class.
//// '    ''' </summary>
//// '    Public Sub New(view As ICustomerView, customerService As ICustomerService, messagingService As IMessagingService, logger As ILogger)
//// '        _view = view
//// '        _customerService = customerService
//// '        _messagingService = messagingService
//// '        _logger = logger

//// '        ' Add handlers for events raised by the View
//// '        AddHandler _view.LoadCustomers, AddressOf Me.OnLoadCustomers
//// '        AddHandler _view.SaveCustomer, AddressOf Me.OnSaveCustomer
//// '    End Sub

//// '    Private Sub OnLoadCustomers(sender As Object, e As EventArgs)
//// '        Try
//// '            _view.EnableView(False) ' Disable the view during the operation
//// '            _messagingService.ShowInformation("Loading customers...")

//// '            Dim customers As List(Of CustomerDTO) = _customerService.GetCustomers()
//// '            _view.DisplayCustomers(customers)

//// '            _messagingService.ShowSuccess("Customers loaded successfully.")
//// '            _logger.LogInfo("Customers loaded.")
//// '        Catch ex As Exception
//// '            _messagingService.ShowError("Failed to load customers.")
//// '            _logger.LogException(ex)
//// '        Finally
//// '            _view.EnableView(True) ' Re-enable the view
//// '        End Try
//// '    End Sub

//// '    Private Sub OnSaveCustomer(customer As CustomerDTO)
//// '        Try
//// '            _view.EnableView(False)
//// '            _messagingService.ShowInformation("Saving customer...")

//// '            ' Use type inference to avoid ambiguous type issues
//// '            Dim result = _customerService.SaveCustomer(customer)

//// '            If result.IsValid Then
//// '                _messagingService.ShowSuccess("Customer saved successfully.")
//// '                _logger.LogInfo("Customer saved successfully.")
//// '                ' Refresh the customer list after saving.
//// '                OnLoadCustomers(Nothing, EventArgs.Empty)
//// '            Else
//// '                _messagingService.ShowError("Validation Error: " & result.ErrorMessage)
//// '                _logger.LogError("Validation Error: " & result.ErrorMessage)
//// '            End If
//// '        Catch ex As Exception
//// '            _messagingService.ShowError("An error occurred while saving the customer.")
//// '            _logger.LogException(ex)
//// '        Finally
//// '            _view.EnableView(True)
//// '        End Try
//// '    End Sub

//// 'End Class

