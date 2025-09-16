// This file defines the contract for the View in the Model-View-Presenter (MVP) pattern.
// It is part of the Contracts layer, which means it contains only interfaces
// and data transfer objects, ensuring a loose coupling between application layers.

using System;

namespace AATM.Contracts.Interfaces.Views
{
    /// <summary>
    /// Defines the contract for a translation view.
    /// The presenter communicates with the view solely through this interface.
    /// </summary>
    public interface ITranslationView
    {
        // Properties used by the Presenter to get and set data on the View.
        // The get and set accessors are a contract for the UI elements
        // that will hold this data.

        /// <summary>
        /// Gets or sets the text to be translated.
        /// </summary>
        string SourceText { get; set; }

        /// <summary>
        /// Gets or sets the target language for the translation.
        /// </summary>
        string TargetLanguage { get; set; }

        /// <summary>
        /// Gets or sets the translated text to be displayed.
        /// </summary>
        string LocalizedText { get; set; }

        // Events that the View can expose for the Presenter to subscribe to.
        // The Presenter registers a handler to these events to respond to user actions.

        /// <summary>
        /// Occurs when the view has finished loading and is ready for the presenter to initialize it.
        /// </summary>
        event EventHandler ViewLoaded;

        /// <summary>
        /// Occurs when the user requests a translation (e.g., by clicking a "Translate" button).
        /// </summary>
        event EventHandler TranslateRequested;

        // Methods for the Presenter to direct the View to perform an action.

        /// <summary>
        /// Displays an error message to the user.
        /// </summary>
        /// <param name="message">The message to display.</param>
        void ShowErrorMessage(string message);
    }
}
