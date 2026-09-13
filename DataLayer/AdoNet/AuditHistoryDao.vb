Imports System.Data

Namespace AdoNet

    Public Class AuditHistoryDao
        Inherits BaseDao

        Public Function GetHistory(fromUtc As DateTime?, toUtc As DateTime?, userIdNo As Short?,
                                   entityName As String, action As String, recordIdNo As Integer?,
                                   referenceNo As String, topRows As Integer) As DataTable
            Const sql As String =
                "EXEC dbo.GetAuditHistory @FromUtc,@ToUtc,@UserIdNo,@EntityName,@Action,@RecordIdNo,@ReferenceNo,@TopRows"

            Return BaseDb.SqlReadDataTable(sql,
                "@FromUtc", If(fromUtc.HasValue, CType(fromUtc.Value, Object), DBNull.Value),
                "@ToUtc", If(toUtc.HasValue, CType(toUtc.Value, Object), DBNull.Value),
                "@UserIdNo", If(userIdNo.HasValue, CType(userIdNo.Value, Object), DBNull.Value),
                "@EntityName", If(String.IsNullOrWhiteSpace(entityName), CType(DBNull.Value, Object), entityName),
                "@Action", If(String.IsNullOrWhiteSpace(action), CType(DBNull.Value, Object), action),
                "@RecordIdNo", If(recordIdNo.HasValue, CType(recordIdNo.Value, Object), DBNull.Value),
                "@ReferenceNo", If(String.IsNullOrWhiteSpace(referenceNo), CType(DBNull.Value, Object), referenceNo),
                "@TopRows", If(topRows > 0, topRows, 1000))
        End Function
    End Class

End Namespace
