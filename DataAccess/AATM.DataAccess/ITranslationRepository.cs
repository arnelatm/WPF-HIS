
using AATM.Contracts.Dtos;

namespace AATM.DataAccess    
{
    public interface ITranslationRepository
    {
        Task<TranslationDto> UpsertTranslationAsync(TranslationDto dto);
        Task<List<TranslationDto>> GetAllTranslationsAsync();
        Task<bool> DeleteTranslationAsync(int idNo);
        Task<TranslationDto> GetTranslationByIdAsync(int idNo);
        Task<string> GetTranslationAsync(string originalString, string normalizedLanguage);
        Task<List<TranslationDto>> GetTranslationsPageAsync(int pageNumber, int pageSize);
    }

}
