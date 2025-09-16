using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

// --- Interfaces for our translation services ---
// In a real application, these would likely be defined in a separate project.
public interface ITranslationService
{
    Task<string> TranslateAsync(string sourceText, string targetLanguage);
}

public interface ITranslationApi
{
    Task<string> GetTranslationAsync(string sourceText, string targetLanguage);
}

// --- Mock external API for demonstration ---
// This class simulates a real translation service by returning a "translated" string.
// It also includes a short delay to simulate network latency.
public class MockTranslationApi : ITranslationApi
{
    public async Task<string> GetTranslationAsync(string sourceText, string targetLanguage)
    {
        Console.WriteLine($"[API] Translating '{sourceText}' to {targetLanguage}...");
        // Simulate a network call with a delay using await.
        await Task.Delay(1000);
        return $"[Translated to {targetLanguage} by API: {sourceText}]";
    }
}

// --- Our translation service with caching logic ---
// This service checks a "database" (simulated by a ConcurrentDictionary)
// before falling back to the external API.
public class DatabaseTranslationService : ITranslationService
{
    private readonly ITranslationApi _translationApi;
    // We use a ConcurrentDictionary to simulate a fast, in-memory database cache.
    private static readonly ConcurrentDictionary<string, string> _inMemoryDb = new ConcurrentDictionary<string, string>();

    public DatabaseTranslationService(ITranslationApi translationApi)
    {
        _translationApi = translationApi;
    }

    public async Task<string> TranslateAsync(string sourceText, string targetLanguage)
    {
        string cacheKey = $"{sourceText}_{targetLanguage}";

        // Try to get the translation from our "database"
        if (_inMemoryDb.TryGetValue(cacheKey, out string cachedTranslation))
        {
            Console.WriteLine("[Cache] Translation found in cache.");
            return cachedTranslation;
        }

        // Cache miss: fall back to the external API
        Console.WriteLine("[Cache] Translation not found. Falling back to external API.");
        string newTranslation = await _translationApi.GetTranslationAsync(sourceText, targetLanguage);

        // Save the new translation to the "database" for future use
        _inMemoryDb.TryAdd(cacheKey, newTranslation);
        Console.WriteLine("[Cache] New translation saved to cache.");

        return newTranslation;
    }
}

// --- Main Program to run the demonstration ---
// This simulates the user interacting with the app, making multiple requests.
public class MockTranslationApp
{
    public static async Task Main(string[] args)
    {
        // Set up our dependencies. In a real app, this would be handled by a DI container.
        ITranslationApi mockApi = new MockTranslationApi();
        ITranslationService translationService = new DatabaseTranslationService(mockApi);

        Console.WriteLine("--- First Translation Request (Cache Miss) ---");
        string firstTranslation = await translationService.TranslateAsync("Hello world", "fr-FR");
        Console.WriteLine($"Result: {firstTranslation}\n");

        Console.WriteLine("--- Second Translation Request (Cache Hit) ---");
        string secondTranslation = await translationService.TranslateAsync("Hello world", "fr-FR");
        Console.WriteLine($"Result: {secondTranslation}\n");

        Console.WriteLine("--- Third Translation Request (New Text, Cache Miss) ---");
        string thirdTranslation = await translationService.TranslateAsync("Goodbye", "es-ES");
        Console.WriteLine($"Result: {thirdTranslation}\n");

        Console.WriteLine("--- Fourth Translation Request (Same as third, Cache Hit) ---");
        string fourthTranslation = await translationService.TranslateAsync("Goodbye", "es-ES");
        Console.WriteLine($"Result: {fourthTranslation}\n");
    }
}
