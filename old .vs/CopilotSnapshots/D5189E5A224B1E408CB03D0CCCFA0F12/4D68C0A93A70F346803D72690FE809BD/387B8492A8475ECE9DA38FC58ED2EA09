using System.Data;
using AATM.Contracts.Dtos;
using AATM.DataAccess;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AATM.DataAccess.Sql
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<List<EmployeeLookupDto>> GetEmployeesLookupAsync()
        {
            var list = new List<EmployeeLookupDto>();
            const string sql = @"
SELECT IdNo, EmployeeCode, EmployeeName
FROM dbo.Employee
ORDER BY EmployeeName";

            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            using var cmd = new SqlCommand(sql, conn);
            using var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                list.Add(MapEmployeeLookupDto(reader));
            }
            return list;
        }

        private static EmployeeLookupDto MapEmployeeLookupDto(SqlDataReader reader)
        {
            return new EmployeeLookupDto
            {
                IdNo = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                EmployeeCode = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                EmployeeName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
            };
        }
    }

    // Static factory for repository access
    public static class RepositoryFactory
    {
        // You can replace this with a configuration provider or DI
        public static string ConnectionString { get; set; } = "your-connection-string-here";

        public static EmployeeRepository EmployeeRepository => new EmployeeRepository(ConnectionString);
        // Add other repositories as needed
    }
}