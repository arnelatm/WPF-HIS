using System.Diagnostics;
using System.Data;
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
                USING (
                    SELECT 
                        @UserName AS UserName, 
                        @Password AS Password, 
                        @EmployeeIdNo AS EmployeeIdNo, 
                        @SecurityGroupIdNo AS SecurityGroupIdNo,
                        @Active AS Active
                ) AS Source
                ON (Target.UserName = Source.UserName AND Target.EmployeeIdNo = Source.EmployeeIdNo)
                WHEN MATCHED THEN
                    UPDATE SET
                        Password = Source.Password,
                        SecurityGroupIdNo = Source.SecurityGroupIdNo,
                        Active = Source.Active
                WHEN NOT MATCHED BY TARGET THEN
                    INSERT (UserName, Password, EmployeeIdNo, SecurityGroupIdNo, Active)
                    VALUES (Source.UserName, Source.Password, Source.EmployeeIdNo, Source.SecurityGroupIdNo, Source.Active)
                OUTPUT inserted.IdNo;";

            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync().ConfigureAwait(false);
                using (var cmd = new SqlCommand(mergeSql, conn))
                {
                    // Prefer explicit typing over AddWithValue to avoid implicit conversions
                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 256).Value = dto.UserName ?? string.Empty;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, -1).Value = (object?)dto.Password ?? DBNull.Value;
                    cmd.Parameters.Add("@EmployeeIdNo", SqlDbType.Int).Value = dto.EmployeeIdNo;
                    cmd.Parameters.Add("@SecurityGroupIdNo", SqlDbType.Int).Value = dto.SecurityGroupIdNo;
                    cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = dto.Active;

                    var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    if (result != null && result != DBNull.Value)
                        dto.IdNo = Convert.ToInt32(result, System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            return dto;
        }

        // Explicit interface implementation now returns just the items page
        async Task<List<UserDto>> IUserRepository.GetUsersPageAsync(int pageNumber, int pageSize)
        {
            var (items, _) = await GetUsersPageAsync(pageNumber, pageSize).ConfigureAwait(false);
            return items;
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
                    cmd.Parameters.Add("@Offset", SqlDbType.Int).Value = (pageNumber - 1) * pageSize;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;

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
            const string sql = "DELETE FROM Users WHERE IdNo = @IdNo";
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync().ConfigureAwait(false);
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@IdNo", SqlDbType.Int).Value = idNo;
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
                    cmd.Parameters.Add("@IdNo", SqlDbType.Int).Value = idNo;
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

        // Signature preserved (per interface), but treat the second parameter as EmployeeIdNo
        public async Task<string> GetUserAsync(string userName, string employeeIdNo)
        {
            const string sql = "SELECT SecurityGroupIdNo FROM Users WHERE UserName = @UserName AND EmployeeIdNo = @EmployeeIdNo";
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync().ConfigureAwait(false);
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 256).Value = userName ?? string.Empty;

                    if (int.TryParse(employeeIdNo, out var empId))
                        cmd.Parameters.Add("@EmployeeIdNo", SqlDbType.Int).Value = empId;
                    else
                        cmd.Parameters.Add("@EmployeeIdNo", SqlDbType.Int).Value = DBNull.Value;

                    var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    return result == null || result == DBNull.Value ? string.Empty : Convert.ToString(result)!;
                }
            }
        }

        private static UserDto MapUserDto(SqlDataReader reader)
        {
            int ordIdNo = reader.GetOrdinal("IdNo");
            int ordUserName = reader.GetOrdinal("UserName");
            int ordPassword = reader.GetOrdinal("Password");
            int ordEmployeeIdNo = reader.GetOrdinal("EmployeeIdNo");
            int ordSecurityGroupIdNo = reader.GetOrdinal("SecurityGroupIdNo");
            int ordActive = reader.GetOrdinal("Active");
            int ordCreationDate = reader.GetOrdinal("CreationDate");

            return new UserDto
            {
                IdNo = reader.IsDBNull(ordIdNo) ? 0 : reader.GetInt32(ordIdNo),
                UserName = reader.IsDBNull(ordUserName) ? string.Empty : reader.GetString(ordUserName),
                Password = reader.IsDBNull(ordPassword) ? null : reader.GetString(ordPassword),
                EmployeeIdNo = reader.IsDBNull(ordEmployeeIdNo) ? 0 : reader.GetInt32(ordEmployeeIdNo),
                SecurityGroupIdNo = reader.IsDBNull(ordSecurityGroupIdNo) ? 0 : reader.GetInt32(ordSecurityGroupIdNo),
                Active = reader.IsDBNull(ordActive) ? false : reader.GetBoolean(ordActive),
                CreationDate = reader.IsDBNull(ordCreationDate) ? DateTime.Now : reader.GetDateTime(ordCreationDate)
            };
        }
    }
}