// This file defines the presenter for the translation feature,
// adhering to the Model-View-Presenter (MVP) pattern.
// The presenter acts as the middleman between the View (ITranslationView)
// and the Model (ITranslationService).

using System;
using System.Threading.Tasks;
using AATM.Contracts.Interfaces.Views;
using AATM.Contracts.Interfaces.Services;

namespace AATM.Presenters
{
    /// <summary>
    /// Handles the application logic for the translation feature.
    /// It coordinates the interaction between the view and the translation service.
    /// </summary>
    public class TranslationPresenter
    {
        // Dependencies are private fields, injected through the constructor.
        private readonly ITranslationView _view;
        private readonly ITranslationService _translationService;

        /// <summary>
        /// Initializes a new instance of the TranslationPresenter class.
        /// </summary>
        /// <param name="view">The view that the presenter will manage.</param>
        /// <param name="translationService">The service that performs the translation.</param>
        public TranslationPresenter(ITranslationView view, ITranslationService translationService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _translationService = translationService ?? throw new ArgumentNullException(nameof(translationService));

            // Subscribe to events exposed by the view to react to user actions.
            _view.ViewLoaded += OnViewLoaded;
            // The event handler is now an async method to support async calls.
            _view.TranslateRequested += async (sender, e) => await OnTranslateRequested();
        }

        /// <summary>
        /// Handles the ViewLoaded event. This is where initialization logic
        /// for the view would go, like setting default values or populating lists.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object that contains the event data.</param>
        private void OnViewLoaded(object sender, EventArgs e)
        {
            // Example of initialization: set a default language.
            _view.TargetLanguage = "en-US";
        }

        /// <summary>
        /// Handles the TranslateRequested event triggered by the user.
        /// It fetches the source text and target language from the view,
        /// performs the translation, and updates the view with the result.
        /// </summary>
        private async Task OnTranslateRequested()
        {
            try
            {
                var sourceText = _view.SourceText;
                var targetLanguage = _view.TargetLanguage;

                // Await the asynchronous service call to perform the translation.
                // The presenter can do other work while waiting for the result.
                var translatedText = await _translationService.TranslateAsync(sourceText, targetLanguage);

                // Update the view with the result from the service.
                _view.LocalizedText = translatedText;
            }
            catch (Exception ex)
            {
                // If an error occurs, instruct the view to display an error message.
                _view.ShowErrorMessage($"Translation failed: {ex.Message}");
            }
        }
    }
}




//using AATM.Contracts;
//using AATM.Contracts.Interfaces.Presentation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AATM.Presentation
//{
//    /// <summary>
//    /// The presenter class that contains the business logic for the translation.
//    /// It communicates with the view and a messaging service through interfaces.
//    /// </summary>
//    public class TranslationPresenter
//    {
//        // Private fields to hold references to the injected services.
//        private readonly ITranslationView _view;
//        private readonly IMessagingService _messagingService;

//        /// <summary>
//        /// Initializes a new instance of the TranslationPresenter.
//        /// The view and the messaging service are injected through the constructor.
//        /// </summary>
//        /// <param name="view">The view that this presenter will manage.</param>
//        /// <param name="messagingService">The service for displaying messages.</param>
//        public TranslationPresenter(ITranslationView view, IMessagingService messagingService)
//        {
//            _view = view;
//            _messagingService = messagingService;

//            // Subscribe to the view's event. This is where the presenter
//            // starts listening for user actions.
//            _view.TranslateRequested += OnTranslateRequested;
//        }

//        /// <summary>
//        /// This is the event handler for when the user requests a translation.
//        /// It contains the core business logic.
//        /// </summary>
//        private void OnTranslateRequested(object sender, EventArgs e)
//        {
//            string sourceText = _view.SourceText;
//            string targetLanguage = _view.TargetLanguage;

//            // In a real-world scenario, you would call a service here
//            // to perform the actual translation. For this example, we'll
//            // just simulate the translation.
//            string translatedText = $"Translated to {targetLanguage}: {sourceText}";

//            // Update the view with the new, translated text.
//            _view.LocalizedText = translatedText;

//            // Display a success message using the injected service.
//            // The presenter doesn't care if this is a MessageBox or a StatusStrip.
//            _messagingService.ShowSuccess("Translation complete!");
//        }
//    }
//}


//using AATM.Business.Logic;
//using AATM.Contracts;
//using AATM.UI.IView; // This import allows the presenter to communicate with the UI.

//namespace AATM.Business
//{
//    /// <summary>
//    /// The presenter acts as a bridge between the UI (View) and the business logic (Service).
//    /// It handles user actions and updates the view based on the service's response.
//    /// </summary>
//    public class TranslationPresenter
//    {
//        private readonly IView _view;
//        private readonly TranslationService _translationService;

//        /// <summary>
//        /// Initializes a new instance of the TranslationPresenter.
//        /// </summary>
//        /// <param name="view">The view (UI) that the presenter will control.</param>
//        /// <param name="translationService">The business service to be used.</param>
//        public TranslationPresenter(IView view, TranslationService translationService)
//        {
//            _view = view;
//            _translationService = translationService;
//        }

//        /// <summary>
//        /// Handles the user's request to perform a translation.
//        /// This method would be called by the UI in response to a button click.
//        /// </summary>
//        public void HandleTranslateRequest()
//        {
//            // 1. Get data from the view.
//            string sourceText = _view.GetSourceText();
//            string targetLanguage = _view.GetTargetLanguage();

//            // 2. Create a DTO (Data Transfer Object) from the retrieved data.
//            var TranslationDto = new TranslationDto
//            {
//                SourceText = sourceText,
//                TargetLanguage = targetLanguage
//            };

//            // 3. Call the business service to perform the logic.
//            string translatedText = _translationService.Translate(TranslationDto);

//            // 4. Update the view with the result.
//            _view.UpdateTranslationOutput(translatedText);
//        }
//    }
//}


//using AATM.Contracts;
//using System.Collections.Generic;

//namespace AATM.Modules.Localization
//{

//    /// <summary>
///// Presenter for the Translation Management user interface.
///// This class contains the business logic for loading and saving translations.
///// </summary>
//    public class TranslationPresenter
//    {

//        private readonly ILocalizationService _localizationService;
//        private readonly ILocalizationRepository _localizationRepository;
//        private readonly ITranslationManagerView _view;

//        public TranslationPresenter(ITranslationManagerView view, ILocalizationService localizationService, ILocalizationRepository localizationRepository)
//        {
//            _view = view;
//            _localizationService = localizationService;
//            _localizationRepository = localizationRepository;
//            _view.SaveTranslation += OnSaveTranslation;
//        }

//        /// <summary>
//    /// Initializes the view by loading all available languages.
//    /// This should be called when the form is first displayed.
//    /// </summary>
//        public void Initialize()
//        {
//            // Get the list of languages and populate the view's language dropdown
//            List<(string display, string code)> languages = _localizationService.GetAvailableLanguages();
//            _view.DisplayLanguages(languages);
//        }

//        /// <summary>
//    /// Loads all translations for a selected language and populates the view.
//    /// </summary>
//        public void LoadTranslations(string languageCode)
//        {
//            List<TranslationDto> translations = _localizationRepository.GetLocalizedStrings(languageCode);
//            var viewTranslations = new List<(string original, string localized)>();
//            foreach (var translation in translations)
//                viewTranslations.Add((translation.OriginalString, translation.LocalizedString));
//            _view.DisplayStrings(viewTranslations);
//        }

//        private void OnSaveTranslation(string originalString, string localizedString)
//        {
//            // This is a placeholder. A full implementation would need more data,
//            // such as module name and language code.
//            _localizationRepository.AddOrUpdateLocalization(originalString, "TranslationManager", originalString, "en-US", localizedString); // ModuleName is hard-coded for now
//                                                                                                                                             // UIIdentifier is hard-coded for now
//                                                                                                                                             // LanguageCode is hard-coded for now

//            _view.ShowSuccessMessage("Translation saved successfully!");

//            // After saving, reload the translations to refresh the grid
//            LoadTranslations("en-US");
//        }
//    }
//}

//// Imports System.Collections.Generic
//// Imports System.Linq
//// Imports AATM.Core.Localization

//// ''' <summary>
//// ''' Presenter for the Translation Management user interface.
//// ''' This class contains the business logic for loading and saving translations.
//// ''' </summary>
//// Public Class TranslationManagerPresenter

//// Private ReadOnly _localizationService As ILocalizationService
//// Private ReadOnly _localizationRepository As ILocalizationRepository
//// Private ReadOnly _view As ITranslationManagerView

//// Public Sub New(view As ITranslationManagerView, localizationService As ILocalizationService, localizationRepository As ILocalizationRepository)
//// _view = view
//// _localizationService = localizationService
//// _localizationRepository = localizationRepository
//// AddHandler _view.SaveTranslation, AddressOf OnSaveTranslation
//// End Sub

//// ''' <summary>
//// ''' Initializes the view by loading all available languages.
//// ''' This should be called when the form is first displayed.
//// ''' </summary>
//// Public Sub Initialize()
//// ' Get the list of languages and populate the view's language dropdown
//// Dim languages As List(Of (display As String, code As String)) = _localizationService.GetAvailableLanguages()
//// _view.DisplayLanguages(languages)
//// End Sub

//// ''' <summary>
//// ''' Loads all translations for a selected language and populates the view.
//// ''' </summary>
//// Public Sub LoadTranslations(languageCode As String)
//// Dim translations As List(Of TranslationDto) = _localizationRepository.GetLocalizedStrings(languageCode)
//// Dim viewTranslations As New List(Of (original As String, localized As String))
//// For Each translation In translations
//// viewTranslations.Add((translation.OriginalString, translation.LocalizedString))
//// Next
//// _view.DisplayStrings(viewTranslations)
//// End Sub

//// Private Sub OnSaveTranslation(originalString As String, localizedString As String)
//// ' This is a placeholder. A full implementation would need more data,
//// ' such as module name and language code.
//// _localizationRepository.AddOrUpdateLocalization(
//// originalString,
//// "TranslationManager", ' ModuleName is hard-coded for now
//// originalString, ' UIIdentifier is hard-coded for now
//// "en-US", ' LanguageCode is hard-coded for now
//// localizedString)

//// _view.ShowSuccessMessage("Translation saved successfully!")

//// ' After saving, reload the translations to refresh the grid
//// LoadTranslations("en-US")
//// End Sub
//// End Class


//// Imports System.Collections.Generic
//// Imports System.Linq
//// Imports AATM.Core.Localization


//// ''' <summary>
//// ''' Presenter for the Translation Management user interface.
//// ''' This class contains the business logic for loading and saving translations.
//// ''' </summary>
//// Public Class TranslationManagerPresenter

//// Private ReadOnly _localizationService As ILocalizationService
//// Private ReadOnly _localizationRepository As ILocalizationRepository
//// Private ReadOnly _view As ITranslationManagerView

//// Public Sub New(view As ITranslationManagerView, localizationService As ILocalizationService, localizationRepository As ILocalizationRepository)
//// _view = view
//// _localizationService = localizationService
//// _localizationRepository = localizationRepository
//// AddHandler _view.SaveTranslationClicked, AddressOf OnSaveTranslationClicked
//// End Sub

//// ''' <summary>
//// ''' Initializes the view by loading all available languages.
//// ''' This should be called when the form is first displayed.
//// ''' </summary>
//// Public Sub Initialize()
//// ' Get the list of languages and populate the view's language dropdown
//// Dim languages As List(Of (display As String, code As String)) = _localizationService.GetAvailableLanguages()
//// _view.DisplayLanguages(languages)
//// End Sub

//// ''' <summary>
//// ''' Loads all translations for a selected language and populates the view.
//// ''' </summary>
//// Public Sub LoadTranslations(languageCode As String)
//// Dim translations As List(Of TranslationDto) = _localizationRepository.GetLocalizedStrings(languageCode)
//// _view.DisplayTranslations(translations)
//// End Sub

//// Private Sub OnSaveTranslationClicked(sender As Object, e As TranslationEventArgs)
//// _localizationRepository.AddOrUpdateLocalization(
//// e.OriginalString,
//// e.ModuleName,
//// e.UIIdentifier,
//// e.LanguageCode,
//// e.LocalizedString)

//// _view.ShowMessage("Translation saved successfully!")

//// ' After saving, reload the translations to refresh the grid
//// LoadTranslations(e.LanguageCode)
//// End Sub

//// End Class

//// ''' <summary>
//// ''' Custom event arguments for the TranslationEventArgs event.
//// ''' </summary>
//// Public Class TranslationEventArgs
//// Inherits EventArgs

//// Public Property OriginalString As String
//// Public Property ModuleName As String
//// Public Property UIIdentifier As String
//// Public Property LanguageCode As String
//// Public Property LocalizedString As String
//// End Class


