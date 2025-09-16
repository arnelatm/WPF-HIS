// This file contains a mock implementation of the ITranslationService.
// A mock service is used for testing and development purposes to simulate
// the behavior of a real service without relying on external dependencies
// like a network connection or a third-party API.

using System;
using System.Threading.Tasks;
using AATM.Contracts.Interfaces.Services;

namespace AATM.Services
{
    /// <summary>
    /// A mock implementation of the translation service for testing purposes.
    /// It simulates an asynchronous translation by returning a modified string
    /// after a short delay.
    /// </summary>
    public class MockTranslationService : ITranslationService
    {
        /// <summary>
        /// Asynchronously translates the specified text by simply formatting it.
        /// A small delay is included to simulate a network request.
        /// </summary>
        /// <param name="sourceText">The text to "translate".</param>
        /// <param name="targetLanguage">The target language.</param>
        /// <returns>A task containing the mock-translated string.</returns>
        public async Task<string> TranslateAsync(string sourceText, string targetLanguage)
        {
            // Await a brief delay to simulate the latency of a real network call.
            await Task.Delay(200);

            if (string.IsNullOrWhiteSpace(sourceText))
            {
                return "Please enter text to translate.";
            }

            // Construct and return the mock translated string.
            return $"[Mock Translated to {targetLanguage}]: {sourceText}";
        }
    }
}
