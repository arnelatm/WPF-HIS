using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using AATM.Services.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AATM.Modules.Localization
{
    public sealed class TranslationCrudService : ICrudService<TranslationDto>
    {
        private readonly TranslationDbService _db = new TranslationDbService();

        public async Task<IReadOnlyList<TranslationDto>> GetAllAsync(CancellationToken ct = default)
            => (await _db.GetAllTranslationsAsync().ConfigureAwait(false));

        public async Task<TranslationDto> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var all = await _db.GetAllTranslationsAsync().ConfigureAwait(false);
            return all.FirstOrDefault(t => t.ID == id);
        }

        public Task<TranslationDto> UpsertAsync(TranslationDto dto, CancellationToken ct = default)
            => _db.UpsertTranslationAsync(dto);

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default)
            => _db.DeleteTranslationAsync(id);
    }
}
