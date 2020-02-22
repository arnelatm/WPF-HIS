
Imports AATM.HIS.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for DefaultFieldValue
    ' ** DAO Pattern

    Public Class DefaultFieldValueDao
        Implements IDefaultFieldValueDao

        Private Shared ReadOnly Db As New Db()

        Public Function GetRecordById(idNo As Integer) As DefaultFieldValue _
            Implements IDefaultFieldValueDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, TableName, FieldName, DataType, Length, DecimalPart, DefaultValue " &
                    "   FROM [DefaultFieldValue]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "TableName") As List(Of DefaultFieldValue) _
            Implements IDefaultFieldValueDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, TableName, FieldName, DataType, Length, DecimalPart, DefaultValue " &
                    "   FROM [DefaultFieldValue] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef defaultFieldValue As DefaultFieldValue) As Integer _
            Implements IDefaultFieldValueDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [DefaultFieldValue]" &
                    "    SET TableName = @TableName," &
                    "        FieldName = @FieldName," &
                    "        DataType = @DataType," &
                    "        Length = @Length," &
                    "        DecimalPart = @DecimalPart" &
                    "        DefaultValue = @DefaultValue" &
                    "  WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(defaultFieldValue))
        End Function

        Public Function GetDefaultFieldValues(tableName As String) As List(Of DefaultFieldValue) _
            Implements IDefaultFieldValueDao.GetTableDefaultValues
            Dim sql As String =
                    " SELECT IDNo, TableName, FieldName, DataType, Length, DecimalPart, DefaultValue " &
                    "   FROM [DefaultFieldValue] where TableName = '" & tableName & "'"
            Dim data = Db.Read(sql, Make).ToList()
            Return data
        End Function

        Public Function AddRecord(ByRef defaultFieldValue As DefaultFieldValue) As Integer _
            Implements IDefaultFieldValueDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [DefaultFieldValue] " &
                    " (TableName, FieldName, DataType, Length, DecimalPart, DefaultValue) " &
                    " VALUES (@TableName, @FieldName, @DataType, @Length, @DecimalPart, @DefaultValue) "
            Return Db.Insert(sql, Take(defaultFieldValue))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DefaultFieldValue) =
                                    Function(reader) _
            New DefaultFieldValue() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .TableName = Extensions.AsString(reader("TableName")),
            .FieldName = Extensions.AsString(reader("FieldName")),
            .DataType = Extensions.AsInt(Of UShort)(reader("DataType")),
            .Length = Extensions.AsInt(Of UShort)(reader("Length")),
            .DecimalPart = Extensions.AsInt(Of UShort)(reader("DecimalPart")),
            .DefaultValue = Extensions.AsString(reader("DefaultValue"))
            }

        Private Function Take(defaultFieldValue As DefaultFieldValue) As Object()
            Return New Object() {
                                    "@IDNo", defaultFieldValue.IdNo,
                                    "@TableName", defaultFieldValue.TableName,
                                    "@FieldName", defaultFieldValue.FieldName,
                                    "@DataType", defaultFieldValue.DataType,
                                    "@Length", defaultFieldValue.Length,
                                    "@DecimalPart", defaultFieldValue.DecimalPart,
                                    "@DefaultValue", defaultFieldValue.DefaultValue
                                }
        End Function
    End Class
End Namespace