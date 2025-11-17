using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AATM.DataAccess.Sql
{
    public class ComboRecordRepository
    {
        private readonly string _connectionString;
        public ComboRecordRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<List<ComboRecord>> FetchRemoteRecordsAsync(string sqlQueryTemplate, string filterCodeField, string filterNameField, string filter, int pageIndex, int pageSize, CancellationToken token)
        {
            var results = new List<ComboRecord>();
            string whereClause = string.Empty;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                whereClause = $"WHERE ([{filterCodeField}] LIKE '%' + @Filter + '%' OR [{filterNameField}] LIKE '%' + @Filter + '%')";
            }
            string query = sqlQueryTemplate ?? string.Empty;
            if (query.Contains("{Where}", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Replace("{Where}", whereClause);
            }
            else if (!string.IsNullOrWhiteSpace(whereClause))
            {
                if (!query.Contains(" WHERE ", StringComparison.OrdinalIgnoreCase))
                {
                    int orderByIndex = query.IndexOf("ORDER BY", StringComparison.OrdinalIgnoreCase);
                    if (orderByIndex >= 0)
                    {
                        query = query.Substring(0, orderByIndex).TrimEnd() + " " + whereClause + " " + query.Substring(orderByIndex);
                    }
                    else
                    {
                        query = query.TrimEnd() + " " + whereClause;
                    }
                }
            }
            if (query.Contains("{Skip}", StringComparison.OrdinalIgnoreCase))
                query = query.Replace("{Skip}", "@Skip");
            if (query.Contains("{Take}", StringComparison.OrdinalIgnoreCase))
                query = query.Replace("{Take}", "@Take");
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(query, conn)
                {
                    CommandTimeout = 30
                };
                cmd.Parameters.Add("@Skip", SqlDbType.Int).Value = pageIndex * pageSize;
                cmd.Parameters.Add("@Take", SqlDbType.Int).Value = pageSize;
                if (!string.IsNullOrWhiteSpace(filter) && query.Contains("@Filter", StringComparison.OrdinalIgnoreCase))
                {
                    cmd.Parameters.Add("@Filter", SqlDbType.NVarChar, Math.Max(filter.Length, 50)).Value = filter;
                }
                await conn.OpenAsync(token).ConfigureAwait(false);
                using var reader = await cmd.ExecuteReaderAsync(token).ConfigureAwait(false);
                while (await reader.ReadAsync(token).ConfigureAwait(false))
                {
                    if (token.IsCancellationRequested) break;
                    var idNo = reader["IdNo"];
                    var code = reader["Code"] as string ?? string.Empty;
                    var name = reader["Name"] as string ?? string.Empty;
                    var rec = new ComboRecord
                    {
                        IdNo = idNo,
                        Code = code,
                        Name = name,
                        Raw = null
                    };
                    results.Add(rec);
                }
            }
            catch (Exception ex)
            {
                // Optionally log error
            }
            return results;
        }
    }

    // DTO for ComboRecord (should match your UI definition)
    public class ComboRecord
    {
        public object IdNo { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public object Raw { get; set; }
    }
}
