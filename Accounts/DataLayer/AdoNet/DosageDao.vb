Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for Dosage
    ' ** DAO Pattern

    Public Class DosageDao
        Inherits CommonDao
        Implements IDao(Of Dosage)

        Private ReadOnly _db As New Db()

        Private ReadOnly _fieldList As String =
                                      "Direction," &
                                      "DosageCode," &
                                      "DosageName," &
                                      "DosageNameAra," &
                                      "IdNo," &
                                      "Frequency," &
                                      "FrequencyTiming," &
                                      "Route," &
                                      "DateTimeStamp"
        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Function GetRecordByIdNo(idNo) As Dosage Implements IDao(Of Dosage).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & _fieldList &
                    " FROM Dosage_View" &
                    " WHERE IdNo = @IdNo"

            Dim params() As Object = {"@IdNo", idNo}
            Dim value As Dosage = _db.Read(sql, Make, params).FirstOrDefault()
            Return value
        End Function

        Public Function UpdateRecord(ByRef Dosage As Dosage) As Integer Implements IDao(Of Dosage).UpdateRecord
            Dim sql As String = " UPDATE Dosage SET " &
                    " Direction = @Direction," &
                    " DosageCode = @DosageCode," &
                    " Frequency = @Frequency," &
                    " FrequencyTiming = @FrequencyTiming," &
                    " Route = @Route" &
                    " where IdNo = @IdNo"
            Dim retVal As Integer
            retVal = _db.Update(sql, Take(Dosage))
            'If retVal > 0 And Not GlobalFunctions.IsEmpty(Dosage.GTin) Then
            '    Dim sql1 As String = "UPDATE ItemDetails SET " &
            '        " GTin = @GTin" &
            '        " WHERE Item_Code = @Item_Code and BranchId = @BranchId"
            '    _db.Update(sql1, Take(Dosage))
            'End If
            Return retVal
        End Function

        Public Function AddRecord(ByRef Dosage As Dosage) As Integer Implements IDao(Of Dosage).AddRecord
            Dim sql As String =
                    " INSERT INTO [Dosage] " &
                    " (DosageCode,Route,Direction,Frequency,FrequencyTiming) " &
                    " VALUES (@DosageCode,@Route,@Direction,@Frequency,@FrequencyTiming) "
            Return _db.Insert(sql, Take(Dosage))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Dosage) =
                            Function(reader) _
            New Dosage() With {
            .Direction = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Int32)(reader("Direction")),
            .DosageCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DosageCode")),
            .Frequency = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("Frequency")),
            .FrequencyTiming = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Int32)(reader("FrequencyTiming")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Route = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Int32)(reader("Route")),
            .DosageName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DosageName")),
            .DosageNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DosageNameAra"))
            }

        Private Function Take(Dosage As Dosage) As Object()
            Return New Object() {
                            "Direction", Dosage.Direction,
                            "DosageCode", Dosage.DosageCode,
                            "Frequency", Dosage.Frequency,
                            "FrequencyTiming", Dosage.FrequencyTiming,
                            "IdNo", Dosage.IdNo,
                            "Route", Dosage.Route
                            }
        End Function

        Private Function MakeDosage(number As Decimal) As String
            Return NumberToWord(number)
        End Function

        'Public Overrides Function GetActualFieldName(fieldName As String)
        '    Dim actualFieldName As String
        '    If fieldName = "DosageCode" Then
        '        actualFieldName = "Item_Code"
        '    ElseIf fieldName = "DosageName" Then
        '        actualFieldName = "ItemNameEnglish"
        '    Else
        '        actualFieldName = fieldName
        '    End If
        '    Return actualFieldName
        'End Function


    End Class

End Namespace