Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for DefaultFieldValue
    ' ** DAO Pattern

    Public Class DefaultFieldValueDao
        Inherits CommonDao
        Implements IDaoAll(Of DefaultFieldValue)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As DefaultFieldValue Implements IDaoAll(Of DefaultFieldValue).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, TableName, FieldName, DataType, Length, DecimalPart, LinkedTable, LinkedField, DefaultValue" &
                    "   FROM [DefaultFieldValue]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of DefaultFieldValue) _
            Implements IDaoAll(Of DefaultFieldValue).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "FieldName"
            End If
            Dim sql As String =
                    " SELECT IdNo, TableName, FieldName, DataType, Length" &
                    "   FROM [DefaultFieldValue] " & "order by " & sortExpression
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef DefaultFieldValue As DefaultFieldValue) As Integer Implements IDaoAll(Of DefaultFieldValue).UpdateRecord
            Dim sql As String =
                    "UPDATE [DefaultFieldValue] " &
                    "SET TableName = @TableName," &
                    "FieldName = @FieldName," &
                    "DataType = @DataType," &
                    "Length = @Length," &
                    "DecimalPart = @DecimalPart," &
                    "LinkedTable = @LinkedTable," &
                    "LinkedField = @LinkedField," &
                    "DefaultValue = @DefaultValue " &
                    "WHERE IdNo = @IdNo"

            Return _db.Update(sql, Take(DefaultFieldValue))
        End Function

        Public Function AddRecord(ByRef DefaultFieldValue As DefaultFieldValue) As Integer Implements IDaoAll(Of DefaultFieldValue).AddRecord
            Dim sql As String =
                    " INSERT INTO [DefaultFieldValue] " &
                    " (TableName,FieldName,DataType,Length,DecimalPart,LinkedTable,LinkedField,DefaultValue) " &
                    " VALUES (@TableName,@FieldName,@DataType,@Length,@DecimalPart,@LinkedTable,@LinkedField,@DefaultValue) "
            Return _db.Insert(sql, Take(DefaultFieldValue))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DefaultFieldValue) =
                                    Function(reader) _
            New DefaultFieldValue() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .TableName = Extensions.AsString(reader("TableName")),
            .FieldName = Extensions.AsString(reader("FieldName")),
            .DataType = Extensions.AsInt(Of Byte)(reader("DataType")),
            .Length = Extensions.AsInt(Of Byte)(reader("Length")),
            .DecimalPart = Extensions.AsInt(Of Byte)(reader("DecimalPart")),
            .LinkedTable = Extensions.AsString(reader("LinkedTable")),
            .LinkedField = Extensions.AsString(reader("LinkedField")),
            .DefaultValue = Extensions.AsString(reader("DefaultValue"))
            }

        Private Function Take(DefaultFieldValue As DefaultFieldValue) As Object()
            Return New Object() {
                                    "@IdNo", DefaultFieldValue.IdNo,
                                    "@TableName", DefaultFieldValue.TableName,
                                    "@FieldName", DefaultFieldValue.FieldName,
                                    "@DataType", DefaultFieldValue.DataType,
                                    "@Length", DefaultFieldValue.Length,
                                    "@DecimalPart", DefaultFieldValue.DecimalPart,
                                    "@LinkedTable", DefaultFieldValue.LinkedTable,
                                    "@LinkedField", DefaultFieldValue.LinkedField,
                                    "@DefaultValue", DefaultFieldValue.DefaultValue
                                }
        End Function

    End Class

End Namespace