// AATM.Data/TranslationRepository.cs
//
// This Data Layer now interacts with a more detailed database schema.
// It uses the updated DTO from the Contracts project.

using System;
using System.Data;
using System.Data.SqlClient;
using AATM.Contracts;
using AATM.Contracts.Dtos;

namespace AATM.Data
{
    public class TranslationRepository
    {
        private readonly string connectionString = "Server=Ibn-Server;Database=IspData;User Id=iGroupAdmin;Password=igss@123;";

        /// <summary>
        /// Retrieves a translation from the database based on original string and language code.
        /// </summary>
        public TranslationDto GetTranslationFromDb(string originalString, string languageCode)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                // Use a parameterized query to prevent SQL injection.
                string sql = "SELECT ID, OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString, CreationDate FROM Translations WHERE OriginalString = @originalString AND LanguageCode = @languageCode;";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@originalString", SqlDbType.NVarChar).Value = originalString;
                    cmd.Parameters.Add("@languageCode", SqlDbType.NVarChar).Value = languageCode;

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
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

        /// <summary>
        /// Saves a new translation record to the database.
        /// </summary>
        public void SaveTranslationToDb(TranslationDto translation)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                // Use a parameterized query to prevent SQL injection.
                string sql = "INSERT INTO Translations (OriginalString, ModuleName, UIIdentifier, LanguageCode, LocalizedString, CreationDate) VALUES (@originalString, @moduleName, @uiIdentifier, @languageCode, @localizedString, GETDATE());";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@originalString", SqlDbType.NVarChar).Value = translation.OriginalString;
                    cmd.Parameters.Add("@moduleName", SqlDbType.NVarChar).Value = translation.ModuleName;
                    cmd.Parameters.Add("@uiIdentifier", SqlDbType.NVarChar).Value = translation.UIIdentifier;
                    cmd.Parameters.Add("@languageCode", SqlDbType.NVarChar).Value = translation.LanguageCode;
                    cmd.Parameters.Add("@localizedString", SqlDbType.NVarChar).Value = translation.LocalizedString;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}


//// WinFormsTranslationApp.cs
////
//// This is a complete, self-contained Windows Forms application
//// that demonstrates a tiered architecture.
//using System;
//using System.Collections.Generic;
//using System.Reflection.Emit;
//using static System.Net.Mime.MediaTypeNames;

//// -------------------------------------------------------------------
//// 1. Data Layer (Handles SQL Database Interaction - Simulated)
//// This layer's sole purpose is to get and save data.
//// -------------------------------------------------------------------
//public class TranslationRepository
//{
//    private readonly string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";

//    // Using a simple dictionary to simulate a database cache for this example.
//    private readonly Dictionary<string, string> cache = new Dictionary<string, string>();

//    public TranslationRepository(string connStr)
//    {
//        this.connectionString = connStr;
//    }

//    /// <summary>
//    /// Attempts to retrieve a translation from the simulated database cache.
//    /// In a real app, this would be a SQL query.
//    /// </summary>
//    public string GetTranslationFromDb(string sourceText, string targetLang)
//    {
//        string key = $"{sourceText.ToLower()}-{targetLang.ToLower()}";
//        if (cache.ContainsKey(key))
//        {
//            return cache[key];
//        }
//        else
//        {
//            return null;
//        }
//    }

//    /// <summary>
//    /// Saves a new translation to the simulated database cache.
//    /// In a real app, this would be a SQL INSERT command.
//    /// </summary>
//    public void SaveTranslationToDb(string sourceText, string translatedText, string targetLang)
//    {
//        string key = $"{sourceText.ToLower()}-{targetLang.ToLower()}";
//        if (!cache.ContainsKey(key))
//        {
//            cache.Add(key, translatedText);
//        }
//    }
//}

