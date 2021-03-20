Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for DefaultFieldValue
    ' ** DAO Pattern

    Public Class DefaultFieldValueDao
        Implements IDefaultFieldValueDao

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As DefaultFieldValue _
            Implements IDefaultFieldValueDao.GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, SystemViewName, SystemViewNameAra, FieldName, DataType, Length, DecimalPart, DefaultValue, LinkedTable, LinkedField" &
                    "   FROM [DefaultFieldValue_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "SystemViewName") As List(Of DefaultFieldValue) _
            Implements IDefaultFieldValueDao.GetAll
            Dim sql As String =
                    " SELECT IdNo, SystemViewName, SystemViewNameAra, FieldName, DataType, Length, DecimalPart, DefaultValue, LinkedTable, LinkedField " &
                    "   FROM [DefaultFieldValue_View] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef defaultFieldValue As DefaultFieldValue) As Integer _
            Implements IDefaultFieldValueDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [DefaultFieldValue]" &
                    "    SET FieldName = @FieldName," &
                    "        DataType = @DataType," &
                    "        Length = @Length," &
                    "        DecimalPart = @DecimalPart," &
                    "        DefaultValue = @DefaultValue," &
                    "        LinkedTable = @LinkedTable," &
                    "        LinkedField = @LinkedField" &
                    "  WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(defaultFieldValue))
        End Function

        Public Function GetDefaultFieldValues(systemViewName As String) As List(Of DefaultFieldValue) _
            Implements IDefaultFieldValueDao.GetTableDefaultValues
            Dim sql As String =
                    " SELECT IdNo, SystemViewName, SystemViewNameAra , FieldName, DataType, Length, DecimalPart, DefaultValue, LinkedTable, LinkedField " &
                    "   FROM [DefaultFieldValue_View] where SystemViewName = '" & systemViewName & "'"
            Dim data = Db.Read(sql, Make).ToList()
            Return data
        End Function

        Public Function AddRecord(ByRef defaultFieldValue As DefaultFieldValue) As Integer _
            Implements IDefaultFieldValueDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [DefaultFieldValue] " &
                    " (FieldName, DataType, Length, DecimalPart, DefaultValue, LinkedTable, LinkedField) " &
                    " VALUES (@FieldName, @DataType, @Length, @DecimalPart, @DefaultValue, @LinkedTable, @LinkedField) "
            Return Db.Insert(sql, Take(defaultFieldValue))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DefaultFieldValue) =
                                    Function(reader) _
            New DefaultFieldValue() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .SystemViewName = Extensions.AsString(reader("SystemViewName")),
            .SystemViewNameAra = Extensions.AsString(reader("SystemViewNameAra")),
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
                                    "@SystemViewName", defaultFieldValue.SystemViewName,
                                    "@SystemViewNameAra", defaultFieldValue.SystemViewNameAra,
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