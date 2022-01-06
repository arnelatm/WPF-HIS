Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for DefaultFieldValue
    ' ** DAO Pattern

    Public Class DefaultFieldValueDao
        Implements IDefaultFieldValueDao

        Const FieldList As String = "DataType," &
                                    "DecimalPart," &
                                    "DefaultValue," &
                                    "FieldName," &
                                    "IdNo," &
                                    "Length," &
                                    "LinkedField," &
                                    "LinkedTable," &
                                    "SystemViewIdNo," &
                                    "SystemViewName," &
                                    "SystemViewNameAra"

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As DefaultFieldValue _
            Implements IDefaultFieldValueDao.GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & FieldList &
                    " FROM [DefaultFieldValue_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef defaultFieldValue As DefaultFieldValue) As Integer _
            Implements IDefaultFieldValueDao.UpdateRecord
            Dim sql As String =
                    "UPDATE [DefaultFieldValue] " &
                    "SET DataType = @DataType," &
                    "DecimalPart = @DecimalPart," &
                    "DefaultValue = @DefaultValue," &
                    "FieldName = @FieldName," &
                    "Length = @Length," &
                    "LinkedField = @LinkedField," &
                    "LinkedTable = @LinkedTable," &
                    "SystemViewIdNo = @SystemViewIdNo " &
                    "WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(defaultFieldValue))
        End Function

        Public Function GetDefaultFieldValues(systemViewName As String) As List(Of DefaultFieldValue) Implements IDefaultFieldValueDao.GetTableDefaultValues
            Dim sql As String = "SELECT " & FieldList &
                    " FROM [DefaultFieldValue_View] where SystemViewName = '" & systemViewName & "'"
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function AddRecord(ByRef defaultFieldValue As DefaultFieldValue) As Integer _
            Implements IDefaultFieldValueDao.AddRecord
            Dim sql As String =
                    "INSERT INTO [DefaultFieldValue] " &
                    "(DataType, DecimalPart, DefaultValue, FieldName, Length, LinkedField, LinkedTable, SystemViewIdNo) " &
                    "VALUES (@DataType, @DecimalPart, @DefaultValue, @FieldName, @Length, @LinkedField, @LinkedTable, @SystemViewIdNo)"
            Return Db.Insert(sql, Take(defaultFieldValue))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DefaultFieldValue) =
                                    Function(reader) _
            New DefaultFieldValue() With {
            .DataType = Extensions.AsInt(Of Byte)(reader("DataType")),
            .DecimalPart = Extensions.AsInt(Of Byte)(reader("DecimalPart")),
            .DefaultValue = Extensions.AsString(reader("DefaultValue")),
            .FieldName = Extensions.AsString(reader("FieldName")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .Length = Extensions.AsInt(Of Byte)(reader("Length")),
            .LinkedTable = Extensions.AsString(reader("LinkedTable")),
            .LinkedField = Extensions.AsString(reader("LinkedField")),
            .SystemViewIdNo = Extensions.AsInt(Of Int16)(reader("SystemViewIdNo")),
            .SystemViewName = Extensions.AsString(reader("SystemViewName")),
            .SystemViewNameAra = Extensions.AsString(reader("SystemViewNameAra"))}

        Private Function Take(defaultFieldValue As DefaultFieldValue) As Object()
            Return New Object() {"@DataType", defaultFieldValue.DataType,
                                 "@DecimalPart", defaultFieldValue.DecimalPart,
                                 "@DefaultValue", defaultFieldValue.DefaultValue,
                                 "@FieldName", defaultFieldValue.FieldName,
                                 "@IdNo", defaultFieldValue.IdNo,
                                 "@Length", defaultFieldValue.Length,
                                 "@LinkedTable", defaultFieldValue.LinkedTable,
                                 "@LinkedField", defaultFieldValue.LinkedField,
                                 "SystemViewIdNo", defaultFieldValue.SystemViewIdNo}
        End Function

    End Class

End Namespace