using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// Fetch one page of combo records (remote mode) using paging parameters.
        /// Template can contain {Where}, {Skip}, {Take}. If {Skip}/{Take} missing an OFFSET/FETCH will be appended.
        /// </summary>
        public async Task<List<ComboRecord>> FetchRemoteRecordsAsync(string sqlQueryTemplate, string filterCodeField, string filterNameField, string filter, int pageIndex, int pageSize, CancellationToken token)
        {
            var results = new List<ComboRecord>();
            string baseQuery = sqlQueryTemplate ?? string.Empty;
            if (string.IsNullOrWhiteSpace(baseQuery)) return results;

            string whereClause = BuildWhereClause(filter, filterCodeField, filterNameField);
            string query = InjectWhere(baseQuery, whereClause);
            query = EnsurePagingClause(query, pageIndex, pageSize);

            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(query, conn) { CommandTimeout = 30 };
                // Parameters
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
                    var rec = new ComboRecord
                    {
                        IdNo = reader["IdNo"],
                        Code = reader["Code"] as string ?? string.Empty,
                        Name = reader["Name"] as string ?? string.Empty,
                        Raw = null
                    };
                    results.Add(rec);
                }
            }
            catch
            {
                // Swallow or log externally; caller controls error surface.
            }
            return results;
        }

        /// <summary>
        /// Returns total count matching filter (without paging) to improve HasNextPage logic.
        /// </summary>
        public async Task<int> FetchTotalCountAsync(string sqlQueryTemplate, string filterCodeField, string filterNameField, string filter, CancellationToken token)
        {
            string baseQuery = sqlQueryTemplate ?? string.Empty;
            if (string.IsNullOrWhiteSpace(baseQuery)) return 0;
            string whereClause = BuildWhereClause(filter, filterCodeField, filterNameField);
            string queryWithWhere = InjectWhere(RemoveOrderBy(baseQuery), whereClause);
            // Wrap query as subselect to avoid side effects
            string countSql = $"SELECT COUNT(1) FROM ( {queryWithWhere} ) AS Q";
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(countSql, conn) { CommandTimeout = 30 };
                if (!string.IsNullOrWhiteSpace(filter) && countSql.Contains("@Filter", StringComparison.OrdinalIgnoreCase))
                {
                    cmd.Parameters.Add("@Filter", SqlDbType.NVarChar, Math.Max(filter.Length, 50)).Value = filter;
                }
                await conn.OpenAsync(token).ConfigureAwait(false);
                var scalar = await cmd.ExecuteScalarAsync(token).ConfigureAwait(false);
                if (scalar == null || scalar == DBNull.Value) return 0;
                return Convert.ToInt32(scalar);
            }
            catch
            {
                return 0;
            }
        }

        private static string BuildWhereClause(string filter, string codeField, string nameField)
        {
            if (string.IsNullOrWhiteSpace(filter) || string.IsNullOrWhiteSpace(codeField) || string.IsNullOrWhiteSpace(nameField))
                return string.Empty;
            return $"WHERE ([{codeField}] LIKE '%' + @Filter + '%' OR [{nameField}] LIKE '%' + @Filter + '%')";
        }

        private static string InjectWhere(string template, string whereClause)
        {
            if (string.IsNullOrWhiteSpace(whereClause)) return template;
            if (template.Contains("{Where}", StringComparison.OrdinalIgnoreCase))
                return template.Replace("{Where}", whereClause, StringComparison.OrdinalIgnoreCase);

            // If already has WHERE we assume caller handled filter; else inject before ORDER BY if exists.
            if (Regex.IsMatch(template, "\\bWHERE\\b", RegexOptions.IgnoreCase)) return template;
            var orderMatch = Regex.Match(template, "ORDER\\s+BY", RegexOptions.IgnoreCase);
            if (orderMatch.Success)
            {
                int idx = orderMatch.Index;
                return template.Substring(0, idx).TrimEnd() + " " + whereClause + " " + template.Substring(idx);
            }
            return template.TrimEnd() + " " + whereClause;
        }

        private static string EnsurePagingClause(string query, int pageIndex, int pageSize)
        {
            // If caller used placeholders {Skip}/{Take} replace them with param names then ensure OFFSET/FETCH if not present.
            if (query.Contains("{Skip}", StringComparison.OrdinalIgnoreCase))
                query = query.Replace("{Skip}", "@Skip", StringComparison.OrdinalIgnoreCase);
            if (query.Contains("{Take}", StringComparison.OrdinalIgnoreCase))
                query = query.Replace("{Take}", "@Take", StringComparison.OrdinalIgnoreCase);

            // If query already has OFFSET FETCH assume user provided paging.
            if (Regex.IsMatch(query, "OFFSET\\s+@?\\w+\\s+ROWS", RegexOptions.IgnoreCase)) return query;

            // Need ORDER BY for OFFSET/FETCH; if missing append default on IdNo.
            if (!Regex.IsMatch(query, "ORDER\\s+BY", RegexOptions.IgnoreCase))
            {
                query = query.TrimEnd() + " ORDER BY IdNo"; // fallback ordering
            }
            query = query.TrimEnd() + " OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";
            return query;
        }

        private static string RemoveOrderBy(string sql)
        {
            // crude removal of last ORDER BY to allow wrapping for count.
            var match = Regex.Match(sql, @"ORDER\s+BY[\s\S]*$", RegexOptions.IgnoreCase);
            return match.Success ? sql.Substring(0, match.Index) : sql;
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
