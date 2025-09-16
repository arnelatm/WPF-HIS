// This file defines the contract for our core business logic.
// It is part of the Contracts layer, ensuring the Presenter is
// loosely coupled from the actual implementation of the translation service.
using System.Threading.Tasks;

namespace AATM.Contracts.Interfaces.Services
{
    public interface ITranslationService
    {
        Task<string> TranslateAsync(string sourceText, string targetLanguage);
    }

    public interface ITranslationApi
    {
        Task<string> GetTranslationAsync(string sourceText, string targetLanguage);
    }
}


//// This file defines the contract for our core business logic.
//// It is part of the Contracts layer, ensuring the Presenter is
//// loosely coupled from the actual implementation of the translation service.

//using System.Threading.Tasks;

//namespace AATM.Contracts.Interfaces.Services
//{
//    /// <summary>
//    /// Defines the contract for a service that can translate text.
//    /// </summary>
//    public interface ITranslationService
//    {
//        /// <summary>
//        /// Asynchronously translates the specified text to a target language.
//        /// </summary>
//        /// <param name="sourceText">The text to translate.</param>
//        /// <param name="targetLanguage">The target language for the translation.</param>
//        /// <returns>A task that represents the asynchronous operation. The task result contains the translated text.</returns>
//        Task<string> TranslateAsync(string sourceText, string targetLanguage);
//    }
//}
