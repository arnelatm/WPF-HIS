using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using AATM.WpfServices.Database;
using AATM.WpfDataAccess;

namespace AATM.Modules.Localization
{
    public sealed class TranslationCrudService : ICrudService<TranslationDto>
    {
        private readonly TranslationDbService _db;

        public TranslationCrudService(ITranslationRepository repository)
        {
            _db = new TranslationDbService(repository);
        }

        public async Task<IReadOnlyList<TranslationDto>> GetPageAsync(int pageNumber, int pageSize)
        {
            return (await _db.GetTranslationsPageAsync(pageNumber, pageSize));
        }

        public async Task<IReadOnlyList<TranslationDto>> GetAllAsync(CancellationToken ct = default)
            => (await _db.GetAllTranslationsAsync().ConfigureAwait(false));

        public async Task<TranslationDto> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _db.GetTranslationByIdAsync(id).ConfigureAwait(false);
        }

        public Task<TranslationDto> UpsertAsync(TranslationDto dto, CancellationToken ct = default)
            => _db.UpsertTranslationAsync(dto);

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default)
            => _db.DeleteTranslationAsync(id);
    }
}