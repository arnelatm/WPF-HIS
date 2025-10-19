using System.Diagnostics;
using AATM.Contracts.Dtos;
using Microsoft.Data.SqlClient;

namespace AATM.DataAccess.Sql
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<UserDto> UpsertUserAsync(UserDto dto)
        {
            const string mergeSql = @"
                MERGE INTO [dbo].[Users] AS Target
                USING (SELECT @UserName AS UserName, @Password AS Password, @EmployeeIdNo AS EmployeeIdNo, @SecurityGroupIdNo AS SecurityGroupIdNo) AS Source
                ON (Target.UserName = Source.UserName AND Target.EmployeeIdNo = Source.EmployeeIdNo)
                WHEN MATCHED THEN
                    UPDATE SET
                        Password = Source.Password,
                        SecurityGroupIdNo = Source.SecurityGroupIdNo
                WHEN NOT MATCHED BY TARGET THEN
                    INSERT (UserName, Password, EmployeeIdNo, SecurityGroupIdNo)
                    VALUES (Source.UserName, Source.Password, Source.EmployeeIdNo, Source.SecurityGroupIdNo)
                OUTPUT inserted.IdNo;";

            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync().ConfigureAwait(false);
                using (var cmd = new SqlCommand(mergeSql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", dto.UserName);
                    cmd.Parameters.AddWithValue("@Password", dto.Password);
                    cmd.Parameters.AddWithValue("@EmployeeIdNo", dto.EmployeeIdNo);
                    cmd.Parameters.AddWithValue("@SecurityGroupIdNo", dto.SecurityGroupIdNo);
                    cmd.Parameters.AddWithValue("@Active", dto.Active);

                    var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    if (result != null)
                        dto.IdNo = Convert.ToInt32(result);
                }
            }
            return dto;
        }

        Task<List<UserDto>> IUserRepository.GetUsersPageAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<(List<UserDto> Items, int TotalCount)> GetUsersPageAsync(int pageNumber, int pageSize)
        {
            var items = new List<UserDto>();
            int totalCount = 0;
            const string sql = @"
SELECT COUNT(*) OVER() AS TotalCount, IdNo, UserName, Password, EmployeeIdNo, SecurityGroupIdNo, Active, CreationDate
FROM Users
ORDER BY IdNo
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync().ConfigureAwait(false);
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);
                    using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        while (await reader.ReadAsync().ConfigureAwait(false))
                        {
                            if (totalCount == 0)
                                totalCount = reader.GetInt32(reader.GetOrdinal("TotalCount"));
                            items.Add(MapUserDto(reader));
                        }
                    }
                }
            }
            return (items, totalCount);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var Users = new List<UserDto>();
            const string sql = "SELECT IdNo, UserName, Password, EmployeeIdNo, SecurityGroupIdNo, Active, CreationDate FROM Users";

            // Optional: add timeout to fail fast if network/TLS causes stalls
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(15));

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync(cts.Token).ConfigureAwait(false);
                    using (var cmd = new SqlCommand(sql, conn))
                    using (var reader = await cmd.ExecuteReaderAsync(cts.Token).ConfigureAwait(false))
                    {
                        while (await reader.ReadAsync(cts.Token).ConfigureAwait(false))
                        {
                            Users.Add(MapUserDto(reader));
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Debug.WriteLine("SqlConnection.OpenAsync timed out.");
                throw new TimeoutException("Opening a SQL connection timed out. Check server reachability, port, and TLS settings.");
            }
            return Users;
        }

        public async Task<bool> DeleteUserAsync(int idNo)
        {
            const string sql = "DELETE FROM Users WHERE ID = @ID";
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync().ConfigureAwait(false);
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdNo", idNo);
                    var rowsAffected = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                    return rowsAffected > 0;
                }
            }
        }

        public async Task<UserDto> GetUserByIdAsync(int idNo)
        {
            const string sql = "SELECT IdNo, UserName, Password, EmployeeIdNo, SecurityGroupIdNo, Active, CreationDate FROM Users WHERE IdNo = @IdNo";
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync().ConfigureAwait(false);
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdNo", idNo);
                    using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync().ConfigureAwait(false))
                        {
                            return MapUserDto(reader);
                        }
                    }
                }
            }
            throw new KeyNotFoundException($"User with ID Number {idNo} not found.");
        }

        public async Task<string> GetUserAsync(string UserName, string normalizedLanguage)
        {
            const string sql = "SELECT SecurityGroupIdNo FROM Users WHERE UserName = @UserName AND EmployeeIdNo = @EmployeeIdNo";
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync().ConfigureAwait(false);
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@EmployeeIdNo", normalizedLanguage);
                    var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    return result?.ToString() ?? string.Empty;
                }
            }
        }

        private static UserDto MapUserDto(SqlDataReader reader)
        {
            return new UserDto
            {
                IdNo = reader.GetInt32(reader.GetOrdinal("IdNo")),
                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                Password = reader.IsDBNull(reader.GetOrdinal("Password")) ? null : reader.GetString(reader.GetOrdinal("Password")),
                EmployeeIdNo = reader.GetInt32(reader.GetOrdinal("EmployeeIdNo")),
                SecurityGroupIdNo = reader.GetInt32(reader.GetOrdinal("SecurityGroupIdNo")),
                Active = reader.GetBoolean(reader.GetOrdinal("Active")),
                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"))
            };
        }
    }
}