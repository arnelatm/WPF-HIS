using System.Data;
using AATM.Contracts.Dtos;
using AATM.DataAccess;
using Microsoft.Data.SqlClient;

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
            // Return all employees to ensure lookups can resolve existing User.EmployeeIdNo even if employee is inactive
            const string sql = @"
SELECT IdNo, EmployeeCode, EmployeeName
FROM dbo.Employee
ORDER BY EmployeeName";

            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync().ConfigureAwait(false);
                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                {
                    while (await reader.ReadAsync().ConfigureAwait(false))
                    {
                        var dto = new EmployeeLookupDto
                        {
                            IdNo = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            EmployeeCode = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            EmployeeName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
                        };
                        list.Add(dto);
                    }
                }
            }
            return list;
        }
    }
}