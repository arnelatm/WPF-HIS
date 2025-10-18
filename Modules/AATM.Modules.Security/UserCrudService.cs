using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using AATM.DataAccess;
using AATM.Services.Database;

namespace AATM.Modules.Users
{
    /// <summary>
    /// Service for managing users using the data access repository.
    /// </summary>
    public sealed class UserCrudService : ICrudService<UserDto>
    {
        private readonly UserDbService _db;

        public UserCrudService(IUserRepository repository)
        {
            _db = new UserDbService(repository);
        }

        public async Task<IReadOnlyList<UserDto>> GetPageAsync(int pageNumber, int pageSize)
        {
            return await _db.GetUsersPageAsync(pageNumber, pageSize).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<UserDto>> GetAllAsync(CancellationToken ct = default)
            => await _db.GetAllUsersAsync().ConfigureAwait(false);

        public async Task<UserDto> GetByIdAsync(int id, CancellationToken ct = default)
            => await _db.GetUserByIdAsync(id).ConfigureAwait(false);

        public Task<UserDto> UpsertAsync(UserDto dto, CancellationToken ct = default)
            => _db.UpsertUserAsync(dto);

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default)
            => _db.DeleteUserAsync(id);
    }
}