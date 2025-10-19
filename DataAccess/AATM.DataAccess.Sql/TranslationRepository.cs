using System.Diagnostics;
using System.Data;
using AATM.Contracts.Dtos;
using Microsoft.Data.SqlClient;

namespace AATM.DataAccess.Sql
{
    public class TranslationRepository : ITranslationRepository
    {
        private readonly string _connectionString;

        public TranslationRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<TranslationDto> UpsertTranslationAsync(TranslationDto dto)
        {
            const string mergeSql = @"
                MERGE INTO [dbo].[Translations] AS Target
                USING (
                    SELECT 
                        @OriginalString AS OriginalString, 
                        @ModuleName AS ModuleName, 
                        @UIIdentifier AS UIIdentifier, 
                        @LanguageCode AS LanguageCode, 
                        @LocalizedString AS LocalizedString
                ) AS Source
                ON (Target.OriginalString = Source.OriginalString AND Target.LanguageCode = Source.LanguageCode)
                WHEN MATCHED THEN
                    UPDATE SET
                        ModuleName = Source.ModuleName,
                        UIIdentifier = Source.UIIdentifier,
                        LocalizedString = Source.LocalizedString
                WHEN NOT MATCHED BY TARGET THEN
                    INSERT (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString)
                    VALUES (Source.OriginalString, Source.ModuleName, Source.UIIdentifier, Source.LanguageCode, Source.LocalizedString)
                OUTPUT inserted.IdNo;";

            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync().ConfigureAwait(false);
                using (var cmd = new SqlCommand(mergeSql, conn))
                {
                    // Prefer explicit typing to avoid implicit conversions
                    cmd.Parameters.Add("@OriginalString", SqlDbType.NVarChar, -1).Value = dto.OriginalString ?? string.Empty;
                    cmd.Parameters.Add("@ModuleName", SqlDbType.NVarChar, 256).Value = dto.ModuleName ?? string.Empty;
                    cmd.Parameters.Add("@UIIdentifier", SqlDbType.NVarChar, 256).Value = dto.UIIdentifier ?? string.Empty;
                    cmd.Parameters.Add("@LanguageCode", SqlDbType.NVarChar, 16).Value = dto.LanguageCode ?? string.Empty;
                    cmd.Parameters.Add("@LocalizedString", SqlDbType.NVarChar, -1).Value = dto.LocalizedString ?? string.Empty;

                    var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    if (result != null && result != DBNull.Value)
                        dto.IdNo = Convert.ToInt32(result, System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            return dto;
        }

        // Explicit interface implementation returns just the items page (mirrors UserRepository)
        async Task<List<TranslationDto>> ITranslationRepository.GetTranslationsPageAsync(int pageNumber, int pageSize)
        {
            var (items, _) = await GetTranslationsPageAsync(pageNumber, pageSize).ConfigureAwait(false);
            return items;
        }

        public async Task<(List<TranslationDto> Items, int TotalCount)> GetTranslationsPageAsync(int pageNumber, int pageSize)
        {
            var items = new List<TranslationDto>();
            int totalCount = 0;
            const string sql = @"
SELECT COUNT(*) OVER() AS TotalCount, IdNo, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString, CreationDate
FROM Translations
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

                            items.Add(MapTranslationDto(reader));
                        }
                    }
                }
            }
            return (items, totalCount);
        }

        public async Task<List<TranslationDto>> GetAllTranslationsAsync()
        {
            var translations = new List<TranslationDto>();
            const string sql = "SELECT IdNo, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString, CreationDate FROM Translations";

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
                            translations.Add(MapTranslationDto(reader));
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Debug.WriteLine("SqlConnection.OpenAsync timed out.");
                throw new TimeoutException("Opening a SQL connection timed out. Check server reachability, port, and TLS settings.");
            }
            return translations;
        }

        public async Task<bool> DeleteTranslationAsync(int idNo)
        {
            const string sql = "DELETE FROM Translations WHERE IdNo = @IdNo";
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

        public async Task<TranslationDto> GetTranslationByIdAsync(int idNo)
        {
            const string sql = "SELECT IdNo, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString, CreationDate FROM Translations WHERE IdNo = @IdNo";
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
                            return MapTranslationDto(reader);
                        }
                    }
                }
            }
            throw new KeyNotFoundException($"Translation with ID Number {idNo} not found.");
        }

        public async Task<string> GetTranslationAsync(string originalString, string normalizedLanguage)
        {
            const string sql = "SELECT LocalizedString FROM Translations WHERE OriginalString = @OriginalString AND LanguageCode = @LanguageCode";
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync().ConfigureAwait(false);
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@OriginalString", SqlDbType.NVarChar, -1).Value = originalString ?? string.Empty;
                    cmd.Parameters.Add("@LanguageCode", SqlDbType.NVarChar, 16).Value = normalizedLanguage ?? string.Empty;

                    var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    return result == null || result == DBNull.Value ? string.Empty : Convert.ToString(result)!;
                }
            }
        }

        private static TranslationDto MapTranslationDto(SqlDataReader reader)
        {
            int ordIdNo = reader.GetOrdinal("IdNo");
            int ordOriginalString = reader.GetOrdinal("OriginalString");
            int ordModuleName = reader.GetOrdinal("ModuleName");
            int ordUIIdentifier = reader.GetOrdinal("UIIdentifier");
            int ordLanguageCode = reader.GetOrdinal("LanguageCode");
            int ordLocalizedString = reader.GetOrdinal("LocalizedString");
            int ordCreationDate = reader.GetOrdinal("CreationDate");

            return new TranslationDto
            {
                IdNo = reader.IsDBNull(ordIdNo) ? 0 : reader.GetInt32(ordIdNo),
                OriginalString = reader.IsDBNull(ordOriginalString) ? string.Empty : reader.GetString(ordOriginalString),
                ModuleName = reader.IsDBNull(ordModuleName) ? string.Empty : reader.GetString(ordModuleName),
                UIIdentifier = reader.IsDBNull(ordUIIdentifier) ? string.Empty : reader.GetString(ordUIIdentifier),
                LanguageCode = reader.IsDBNull(ordLanguageCode) ? string.Empty : reader.GetString(ordLanguageCode),
                LocalizedString = reader.IsDBNull(ordLocalizedString) ? string.Empty : reader.GetString(ordLocalizedString),
                CreationDate = reader.IsDBNull(ordCreationDate) ? DateTime.Now : reader.GetDateTime(ordCreationDate)
            };
        }
    }
}