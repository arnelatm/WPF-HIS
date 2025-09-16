// --- Mock external API for demonstration ---
// This class simulates a real translation service like Google Translate.
// It simply returns a hardcoded translation.
using AATM.Contracts.Interfaces.Services;
using System.Threading.Tasks;

namespace AATM.Services.Database
{
    public class MockTranslationApi : ITranslationApi
    {
        public Task<string> GetTranslationAsync(string sourceText, string targetLanguage)
        {
            // Simulate a network call and return a "translated" string.
            return Task.FromResult($"[Translated to {targetLanguage} by API: {sourceText}]");
        }
    }
}