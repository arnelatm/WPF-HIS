Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for Duration
    ' ** DAO Pattern

    Public Class DurationDao
        Inherits CommonDao
        Implements IDao(Of Duration), IDaoGetAll(Of Duration)

        Private ReadOnly _db As New Db("IGROUPCLINIC")
        Private ReadOnly _tableName As String = "PMRQtyDays"
        Private ReadOnly _primaryKey As String = "IdNo"
        Private ReadOnly _originalField As String = "DescriptionEnglish"
        Private ReadOnly _translatedField As String = "DescriptionArabic"
        Private ReadOnly _itemCode As String = "Id"
        Private ReadOnly _fieldList As String = _primaryKey & "," & _itemCode & "," & _originalField & "," & _translatedField

        Public Overrides Function GetDB()
            Return _db
        End Function


        Public Function GetAll(Of TM)(sortExpression As String) As List(Of Duration) Implements IDaoGetAll(Of Duration).GetAll
            Dim sql As String = "SELECT " & _fieldList & " FROM " & _tableName & " order by " & GetActualFieldName(sortExpression)
            Return _db.Read(sql, Make).ToList()
        End Function


        Public Function GetRecordByIdNo(idNo) As Duration Implements IDao(Of Duration).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & _fieldList &
                    " FROM " & _tableName &
                    " WHERE " & GetPrimaryFieldName() & " = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim value As Duration = _db.Read(sql, Make, params).FirstOrDefault()
            Return value
        End Function

        Public Function UpdateRecord(ByRef duration As Duration) As Integer Implements IDao(Of Duration).UpdateRecord
            Dim sql As String = " UPDATE " & _tableName & " SET " &
                    " DescriptionArabic = @DurationNameAra where " & GetPrimaryFieldName() & " = @IdNo"
            Dim retVal As Integer
            retVal = _db.Update(sql, Take(duration))
            Return retVal
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Duration) =
                            Function(reader) _
            New Duration With {
            .DurationCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Id")),
            .DurationName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DescriptionEnglish")),
            .DurationNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DescriptionArabic")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo"))
            }

        Private Function Take(Duration As Duration) As Object()
            Return New Object() {
                            "Id", Duration.DurationNameAra,
                            "DescriptionEnglish", Duration.DurationName,
                            "DescriptionArabic", Duration.DurationNameAra
                            }
        End Function

        Public Function AddRecord(ByRef recordData As Duration) As Integer Implements IDao(Of Duration).AddRecord
            Throw New NotImplementedException()
        End Function

        Public Overrides Function GetActualFieldName(fieldName As String)
            Dim actualFieldName As String
            If fieldName = "DurationCode" Then
                actualFieldName = "Id"
            ElseIf fieldName = "DurationName" Then
                actualFieldName = "DescriptionEnglish"
            ElseIf fieldName = "DurationNameAra" Then
                actualFieldName = "DescriptionArabic"
            Else
                actualFieldName = fieldName
            End If
            Return actualFieldName
        End Function

        Public Overrides Function GetPrimaryFieldName()
            Return "IdNo"
        End Function

    End Class

    Public Class DurationListDao
        Inherits CommonDao
        Implements IDaoGetAll(Of Duration)

        Private ReadOnly _db As New Db("IGROUPCLINIC")
        Private ReadOnly _tableName As String = "PMRQtyDays"
        Private ReadOnly _primaryKey As String = "IdNo"
        Private ReadOnly _originalField As String = "DescriptionEnglish"
        Private ReadOnly _translatedField As String = "DescriptionArabic"
        Private ReadOnly _itemCode As String = "Id"
        Private ReadOnly _fieldList As String = _primaryKey & "," & _itemCode & "," & _originalField & "," & _translatedField

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Function GetAll(Of TM)(sortExpression As String) As List(Of Duration) Implements IDaoGetAll(Of Duration).GetAll
            Dim sql As String = "SELECT " & _fieldList & " FROM " & _tableName & " order by " & GetActualFieldName(sortExpression)
            Return _db.Read(sql, Make).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Duration) =
                    Function(reader) _
                    New Duration With {
                    .DurationCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Id")),
                    .DurationName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DescriptionEnglish")),
                    .DurationNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DescriptionArabic")),
                    .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo"))
                    }

    End Class
End Namespace