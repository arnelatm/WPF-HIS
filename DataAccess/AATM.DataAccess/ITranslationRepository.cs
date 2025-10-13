
using AATM.Contracts.Dtos;

namespace AATM.DataAccess    
{
    public interface ITranslationRepository
    {
        Task<TranslationDto> UpsertTranslationAsync(TranslationDto dto);
        Task<List<TranslationDto>> GetAllTranslationsAsync();
        Task<bool> DeleteTranslationAsync(int id);
        Task<TranslationDto> GetTranslationByIdAsync(int id);
        Task<string> GetTranslationAsync(string originalString, string normalizedLanguage);
        Task<List<TranslationDto>> GetTranslationsPageAsync(int pageNumber, int pageSize);
    }

}
