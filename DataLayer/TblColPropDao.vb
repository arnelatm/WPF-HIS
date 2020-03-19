Imports AATM.DataLayer.AdoNet

' Data access object for TblColProp
' ** DAO Pattern

Public Class TblColPropDao
    Implements ITblColPropDao

    Private ReadOnly Db As New Db()

    Public Function GetMainTableColumnProperties(tableName As String) As List(Of TblColProp) _
        Implements ITblColPropDao.GetMainTableColumnProperties
        Dim sql As String =
                "SELECT c.name as FldName, t.name as FldType, c.max_length as MaxLength, c.is_nullable as IsNullable, c.is_identity as IsIdentity " &
                "from sys.columns c " &
                "join sys.types t " &
                "on t.system_type_id = c.system_type_id " &
                "where c.object_id = object_id(@TableName) " &
                "order by column_id"
        Dim params() As Object = {"@TableName", tableName}
        Return Db.Read(sql, Make, params).ToList()
    End Function

    ' creates a TblColProp object based on DataReader

    Private Shared ReadOnly Make As Func(Of IDataReader, TblColProp) =
                                Function(reader) _
        New TblColProp() With {
        .FldName = Extensions.AsString(reader("FldName")),
        .FldType = Extensions.AsString(reader("FldType")),
        .MaxLength = Extensions.AsInt(Of Long)(reader("MaxLength")),
        .IsNullable = Extensions.AsBool(reader("IsNullable")),
        .IsIdentity = Extensions.AsBool(reader("IsIdentity"))
        }

End Class