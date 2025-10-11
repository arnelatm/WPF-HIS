using AATM.Contracts.Dtos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<List<TranslationDto>> GetAllTranslationsAsync()
        {
            var translations = new List<TranslationDto>();
            const string sql = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString, CreationDate FROM Translations";

            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
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

        public async Task<TranslationDto?> GetTranslationByIdAsync(int id)
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
                                ID = Convert.ToInt32(reader["ID"]),
                                OriginalString = reader["OriginalString"].ToString(),
                                ModuleName = reader["ModuleName"].ToString(),
                                UIIdentifier = reader["UIIdentifier"].ToString(),
                                LanguageCode = reader["LanguageCode"].ToString(),
                                LocalizedString = reader["LocalizedString"].ToString(),
                                CreationDate = Convert.ToDateTime(reader["CreationDate"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public async Task<string?> GetTranslationAsync(string originalString, string normalizedLanguage)
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
                    return result?.ToString();
                }
            }
        }
    }
}