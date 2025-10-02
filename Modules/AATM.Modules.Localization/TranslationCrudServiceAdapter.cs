using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class TranslationCrudServiceAdapter : ICrudService<IEntityWithId>
{
    private readonly ICrudService<TranslationDto> _inner;

    public TranslationCrudServiceAdapter(ICrudService<TranslationDto> inner)
    {
        _inner = inner;
    }

    public async Task<IReadOnlyList<IEntityWithId>> GetAllAsync(CancellationToken ct = default)
        => (await _inner.GetAllAsync(ct)).Cast<IEntityWithId>().ToList();

    public async Task<IEntityWithId> GetByIdAsync(int id, CancellationToken ct = default)
        => await _inner.GetByIdAsync(id, ct);

    public async Task<IEntityWithId> UpsertAsync(IEntityWithId dto, CancellationToken ct = default)
        => await _inner.UpsertAsync((TranslationDto)dto, ct);

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        => await _inner.DeleteAsync(id, ct);
}