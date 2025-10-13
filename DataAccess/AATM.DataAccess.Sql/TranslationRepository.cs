using System.Diagnostics;
using AATM.Contracts.Dtos;
using Microsoft.Data.SqlClient;

namespace AATM.DataAccess.Sql
{
    public class TranslationRepository : ITranslationRepository
    {
#if NETFRAMEWORK
        static TranslationRepository()
        {
            // Avoid native SNI issues on .NET Framework
            AppContext.SetSwitch("Switch.Microsoft.Data.SqlClient.UseManagedNetworkingOnWindows", true);
        }
#endif
        private readonly string _connectionString;

        public TranslationRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<TranslationDto> UpsertTranslationAsync(TranslationDto dto)
        {
            const string mergeSql = @"
                MERGE INTO [dbo].[Translations] AS Target
                USING (SELECT @OriginalString AS OriginalString, @ModuleName AS ModuleName, @UIIdentifier AS UIIdentifier, @LanguageCode AS LanguageCode, @LocalizedString AS LocalizedString) AS Source
                ON (Target.OriginalString = Source.OriginalString AND Target.LanguageCode = Source.LanguageCode)
                WHEN MATCHED THEN
                    UPDATE SET
                        ModuleName = Source.ModuleName,
                        UIIdentifier = Source.UIIdentifier,
                        LocalizedString = Source.LocalizedString
                WHEN NOT MATCHED BY TARGET THEN
                    INSERT (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString)
                    VALUES (Source.OriginalString, Source.ModuleName, Source.UIIdentifier, Source.LanguageCode, Source.LocalizedString)
                OUTPUT inserted.ID;";

            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand(mergeSql, conn))
                {
                    cmd.Parameters.AddWithValue("@OriginalString", dto.OriginalString);
                    cmd.Parameters.AddWithValue("@ModuleName", dto.ModuleName);
                    cmd.Parameters.AddWithValue("@UIIdentifier", dto.UIIdentifier);
                    cmd.Parameters.AddWithValue("@LanguageCode", dto.LanguageCode);
                    cmd.Parameters.AddWithValue("@LocalizedString", dto.LocalizedString);

                    var result = await cmd.ExecuteScalarAsync();
                    if (result != null)
                        dto.ID = Convert.ToInt32(result);
                }
            }
            return dto;
        }

        Task<List<TranslationDto>> ITranslationRepository.GetTranslationsPageAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<(List<TranslationDto> Items, int TotalCount)> GetTranslationsPageAsync(int pageNumber, int pageSize)
        {
            var items = new List<TranslationDto>();
            int totalCount = 0;
            string sql = @"
        SELECT COUNT(*) OVER() AS TotalCount, ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString, CreationDate
        FROM Translations
        ORDER BY ID
        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            if (totalCount == 0)
                                totalCount = reader.GetInt32(reader.GetOrdinal("TotalCount"));
                            items.Add(new TranslationDto
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                OriginalString = reader["OriginalString"].ToString(),
                                ModuleName = reader["ModuleName"].ToString(),
                                UIIdentifier = reader["UIIdentifier"].ToString(),
                                LanguageCode = reader["LanguageCode"].ToString(),
                                LocalizedString = reader["LocalizedString"].ToString(),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"))
                            });
                        }
                    }
                }
            }
            return (items, totalCount);
        }


        public async Task<List<TranslationDto>> GetAllTranslationsAsync()
        {
            var translations = new List<TranslationDto>();
            const string sql = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString, CreationDate FROM Translations";

            // Fail fast if connection cannot be opened within N seconds
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
                            translations.Add(new TranslationDto
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                OriginalString = reader["OriginalString"].ToString(),
                                ModuleName = reader["ModuleName"].ToString(),
                                UIIdentifier = reader["UIIdentifier"].ToString(),
                                LanguageCode = reader["LanguageCode"].ToString(),
                                LocalizedString = reader["LocalizedString"].ToString(),
                                CreationDate = Convert.ToDateTime(reader["CreationDate"])
                            });
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Debug.WriteLine("SqlConnection.OpenAsync timed out.");
                throw new TimeoutException("Opening a SQL connection timed out. Check server reachability, port, and TLS settings.");
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
            return translations;
        }

        public async Task<bool> DeleteTranslationAsync(int id)
        {
            const string sql = "DELETE FROM Translations WHERE ID = @ID";
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    var rowsAffected = await cmd.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }

        public async Task<TranslationDto> GetTranslationByIdAsync(int id)
        {
            const string sql = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString, CreationDate FROM Translations WHERE ID = @ID";
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new TranslationDto
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                OriginalString = reader.GetString(reader.GetOrdinal("OriginalString")),
                                ModuleName = reader.GetString(reader.GetOrdinal("ModuleName")),
                                UIIdentifier = reader.GetString(reader.GetOrdinal("UIIdentifier")),
                                LanguageCode = reader.GetString(reader.GetOrdinal("LanguageCode")),
                                LocalizedString = reader.GetString(reader.GetOrdinal("LocalizedString")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"))
                            };
                        }
                    }
                }
            }
            throw new KeyNotFoundException($"Translation with ID {id} not found.");
        }

        public async Task<string> GetTranslationAsync(string originalString, string normalizedLanguage)
        {
            const string sql = "SELECT LocalizedString FROM Translations WHERE OriginalString = @OriginalString AND LanguageCode = @LanguageCode";
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@OriginalString", originalString);
                    cmd.Parameters.AddWithValue("@LanguageCode", normalizedLanguage);
                    var result = await cmd.ExecuteScalarAsync();
                    return result?.ToString() ?? string.Empty;
                }
            }
        }


    }
}