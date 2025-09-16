// Example of how to use this service
using AATM.Contracts.Dtos;
using System;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        var dbService = new TranslationDbService();

        // 1. Use UpsertTranslationAsync to insert a new record
        Console.WriteLine("Upserting new translation...");
        var newTranslation = new TranslationDto
        {
            OriginalString = "Hello, world!",
            ModuleName = "Core",
            UIIdentifier = "Greeting",
            LanguageCode = "es-ES",
            LocalizedString = "Hola, mundo!"
        };
        var newId = await dbService.UpsertTranslationAsync(newTranslation);
        Console.WriteLine($"New translation upserted with ID: {newId}");

        // 2. Use UpsertTranslationAsync to update the existing record
        Console.WriteLine("\nUpserting updated translation...");
        var updatedTranslation = new TranslationDto
        {
            ID = newId, // The ID is not used by the MERGE statement, but kept for clarity.
            OriginalString = "Hello, world!",
            ModuleName = "Core",
            UIIdentifier = "Greeting",
            LanguageCode = "es-ES",
            LocalizedString = "¡Hola, mundo!" // The updated value
        };
        var updatedId = await dbService.UpsertTranslationAsync(updatedTranslation);
        Console.WriteLine($"Existing translation updated with ID: {updatedId}");

        // 3. Get the updated translation by ID to verify
        Console.WriteLine("\nRetrieving translation by ID to verify update...");
        var retrievedTranslation = await dbService.GetTranslationByIdAsync(updatedId);
        if (retrievedTranslation != null)
        {
            Console.WriteLine($"Retrieved: Original='{retrievedTranslation.OriginalString}', Localized='{retrievedTranslation.LocalizedString}'");
        }

        // 4. Clean up
        //Console.WriteLine("\nDeleting translation by ID...");
        //await dbService.DeleteTranslationAsync(updatedId);
        Console.WriteLine("Translation deleted successfully!");
    }
}