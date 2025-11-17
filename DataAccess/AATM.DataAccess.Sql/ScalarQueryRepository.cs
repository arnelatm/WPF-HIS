using System;
using System.Data;
using Microsoft.Data.SqlClient;
using AATM.DataAccess;

namespace AATM.DataAccess.Sql
{
    public class ScalarQueryRepository : IScalarQueryRepository
    {
    private readonly string _connectionString;

  public ScalarQueryRepository(string connectionString)
    {
  _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    public object ExecuteScalar(string sql, params object[] parameters)
    {
        using var connection = new SqlConnection(_connectionString);
  using var command = new SqlCommand(sql, connection);
   if (parameters != null && parameters.Length > 0)
       {
     for (int i = 0; i < parameters.Length; i += 2)
      {
     var name = parameters[i]?.ToString() ?? string.Empty;
     var value = parameters[i + 1] ?? DBNull.Value;
     command.Parameters.AddWithValue(name, value);
       }
   }
   connection.Open();
       return command.ExecuteScalar();
   }
    }
}
