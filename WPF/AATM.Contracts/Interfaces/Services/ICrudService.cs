using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AATM.Contracts.Interfaces.Services // ENSURE this exact namespace
{
    public interface ICrudService<T>
    {
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default);
        Task<T> GetByIdAsync(int idNo, CancellationToken ct = default);
        Task<T> UpsertAsync(T dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int idNo, CancellationToken ct = default);
    }
}
