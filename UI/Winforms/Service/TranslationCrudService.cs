using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AATM.UI.Winforms.Service
{
    // Thin adapter to reuse existing TranslationDbService with the generic base
    public sealed class TranslationCrudService : ICrudService<TranslationDto>
    {
        private readonly TranslationDbService _inner = new TranslationDbService();

        public Task<IReadOnlyList<TranslationDto>> GetAllAsync(CancellationToken ct = default)
            => _inner.GetAllTranslationsAsync().ContinueWith(t => (IReadOnlyList<TranslationDto>)t.Result, ct);

        public Task<TranslationDto> GetByIdAsync(int id, CancellationToken ct = default)
            => throw new System.NotImplementedException();

        public Task<TranslationDto> UpsertAsync(TranslationDto dto, CancellationToken ct = default)
            => _inner.UpsertTranslationAsync(dto);

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default)
            => _inner.DeleteTranslationAsync(id);
    }
}