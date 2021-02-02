Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for DefaultFieldValue
    ' ** DAO Pattern

    Public Class DefaultFieldValueDao
        Implements IDefaultFieldValueDao

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As DefaultFieldValue _
            Implements IDefaultFieldValueDao.GetRecordById
            Dim sql As String =
                    " SELECT IdNo, ViewName, FieldName, DataType, Length, DecimalPart, DefaultValue, LinkedTable, LinkedField" &
                    "   FROM [DefaultFieldValue]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "ViewName") As List(Of DefaultFieldValue) _
            Implements IDefaultFieldValueDao.GetAll
            Dim sql As String =
                    " SELECT IdNo, ViewName, FieldName, DataType, Length, DecimalPart, DefaultValue, LinkedTable, LinkedField " &
                    "   FROM [DefaultFieldValue] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef defaultFieldValue As DefaultFieldValue) As Integer _
            Implements IDefaultFieldValueDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [DefaultFieldValue]" &
                    "    SET ViewName = @ViewName," &
                    "        FieldName = @FieldName," &
                    "        DataType = @DataType," &
                    "        Length = @Length," &
                    "        DecimalPart = @DecimalPart," &
                    "        DefaultValue = @DefaultValue," &
                    "        LinkedTable = @LinkedTable," &
                    "        LinkedField = @LinkedField" &
                    "  WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(defaultFieldValue))
        End Function

        Public Function GetDefaultFieldValues(viewName As String) As List(Of DefaultFieldValue) _
            Implements IDefaultFieldValueDao.GetTableDefaultValues
            Dim sql As String =
                    " SELECT IdNo, ViewName, FieldName, DataType, Length, DecimalPart, DefaultValue, LinkedTable, LinkedField " &
                    "   FROM [DefaultFieldValue] where ViewName = '" & viewName & "'"
            Dim data = Db.Read(sql, Make).ToList()
            Return data
        End Function

        Public Function AddRecord(ByRef defaultFieldValue As DefaultFieldValue) As Integer _
            Implements IDefaultFieldValueDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [DefaultFieldValue] " &
                    " (ViewName, FieldName, DataType, Length, DecimalPart, DefaultValue, LinkedTable, LinkedField) " &
                    " VALUES (@ViewName, @FieldName, @DataType, @Length, @DecimalPart, @DefaultValue, @LinkedTable, @LinkedField) "
            Return Db.Insert(sql, Take(defaultFieldValue))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DefaultFieldValue) =
                                    Function(reader) _
            New DefaultFieldValue() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .ViewName = Extensions.AsString(reader("ViewName")),
            .FieldName = Extensions.AsString(reader("FieldName")),
            .DataType = Extensions.AsInt(Of Byte)(reader("DataType")),
            .Length = Extensions.AsInt(Of Byte)(reader("Length")),
            .DecimalPart = Extensions.AsInt(Of Byte)(reader("DecimalPart")),
            .LinkedTable = Extensions.AsString(reader("LinkedTable")),
            .LinkedField = Extensions.AsString(reader("LinkedField")),
            .DefaultValue = Extensions.AsString(reader("DefaultValue"))
            }

        Private Function Take(defaultFieldValue As DefaultFieldValue) As Object()
            Return New Object() {
                                    "@IdNo", defaultFieldValue.IdNo,
                                    "@ViewName", defaultFieldValue.ViewName,
                                    "@FieldName", defaultFieldValue.FieldName,
                                    "@DataType", defaultFieldValue.DataType,
                                    "@Length", defaultFieldValue.Length,
                                    "@DecimalPart", defaultFieldValue.DecimalPart,
                                    "@LinkedTable", defaultFieldValue.LinkedTable,
                                    "@LinkedField", defaultFieldValue.LinkedField,
                                    "@DefaultValue", defaultFieldValue.DefaultValue
                                }
        End Function

    End Class

End Namespace