
using AATM.Contracts.Dtos;

namespace AATM.DataAccess
{
    public interface IUserRepository
    {
        Task<UserDto> UpsertUserAsync(UserDto dto);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(int idNo);
        Task<UserDto> GetUserByIdAsync(int idNo);
        Task<string> GetUserAsync(string originalString, string normalizedLanguage);
        Task<List<UserDto>> GetUsersPageAsync(int pageNumber, int pageSize);
    }

}