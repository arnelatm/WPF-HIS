// Change the accessibility of DesignTimeCrudService from internal sealed to public sealed
public sealed class DesignTimeCrudService : ICrudService<T>
{
    public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default) => Task.FromResult((IReadOnlyList<T>)new List<T>());
    public Task<T> GetByIdAsync(int id, CancellationToken ct = default) => Task.FromResult<T>(null);
    public Task<T> UpsertAsync(T dto, CancellationToken ct = default) => Task.FromResult(dto);
    public Task<bool> DeleteAsync(int id, CancellationToken ct = default) => Task.FromResult(false);
}