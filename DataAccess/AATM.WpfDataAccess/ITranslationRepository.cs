using AATM.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AATM.WpfDataAccess    
{
    public interface ITranslationRepository
    {
        Task<TranslationDto> UpsertTranslationAsync(TranslationDto dto);
        Task<List<TranslationDto>> GetAllTranslationsAsync();
        Task<bool> DeleteTranslationAsync(int id);
        Task<TranslationDto> GetTranslationByIdAsync(int id);
        Task<string> GetTranslationAsync(string originalString, string normalizedLanguage);
    }

}
