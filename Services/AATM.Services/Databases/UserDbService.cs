using AATM.Contracts.Dtos;
using AATM.DataAccess;

namespace AATM.Services.Database
{
    /// <summary>
    /// Service for managing users using the data access repository.
    /// </summary>
    public class UserDbService
    {
        private readonly IUserRepository _repository;

        // Inject the repository via constructor
        public UserDbService(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Inserts or updates a user record.
        /// </summary>
        public async Task<UserDto> UpsertUserAsync(UserDto dto)
        {
            return await _repository.UpsertUserAsync(dto);
        }

        /// <summary>
        /// Gets a page of users.
        /// </summary>
        public async Task<List<UserDto>> GetUsersPageAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetUsersPageAsync(pageNumber, pageSize);
        }

        /// <summary>
        /// Fetches all users.
        /// </summary>
        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            return await _repository.GetAllUsersAsync();
        }

        /// <summary>
        /// Deletes a user record.
        /// </summary>
        public async Task<bool> DeleteUserAsync(int idNo)
        {
            return await _repository.DeleteUserAsync(idNo);
        }

        /// <summary>
        /// Gets a user by IdNo.
        /// </summary>
        public async Task<UserDto> GetUserByIdAsync(int idNo)
        {
            return await _repository.GetUserByIdAsync(idNo);
        }
    }
}