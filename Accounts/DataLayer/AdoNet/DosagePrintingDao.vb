Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for DosagePrinting
    ' ** DAO Pattern

    Public Class DosagePrintingDao
        Inherits CommonDao
        Implements IDao(Of DosagePrinting)

        Private ReadOnly _db As New Db()

        Private ReadOnly _fieldList As String =
                                      "Age," &
                                      "Direction," &
                                      "Dose," &
                                      "DoseUnit," &
                                      "DosageCode," &
                                      "DosageName," &
                                      "DosageNameAra," &
                                      "Duration," &
                                      "DurationUnit," &
                                      "IdNo," &
                                      "Frequency," &
                                      "FrequencyTiming," &
                                      "Route," &
                                      "Age," &
                                      "AgeYMD," &
                                      "FileNo," &
                                      "Gender," &
                                      "PatientName," &
                                      "DateTimeStamp"
        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Function GetRecordByIdNo(idNo) As DosagePrinting Implements IDao(Of DosagePrinting).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & _fieldList &
                    " FROM Dosage_View" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim value As DosagePrinting = _db.Read(sql, Make, params).FirstOrDefault()
            Return value
        End Function

        Public Function UpdateRecord(ByRef DosagePrinting As DosagePrinting) As Integer Implements IDao(Of DosagePrinting).UpdateRecord
            Dim sql As String = " UPDATE DosagePrinting SET " &
                    " Direction = @Direction," &
                    " DosageCode = @DosageCode," &
                    " Frequency = @Frequency," &
                    " FrequencyTiming = @FrequencyTiming," &
                    " Route = @Route" &
                    " where IdNo = @IdNo"
            Dim retVal As Integer
            retVal = _db.Update(sql, Take(DosagePrinting))
            'If retVal > 0 And Not GlobalFunctions.IsEmpty(DosagePrinting.GTin) Then
            '    Dim sql1 As String = "UPDATE ItemDetails SET " &
            '        " GTin = @GTin" &
            '        " WHERE Item_Code = @Item_Code and BranchId = @BranchId"
            '    _db.Update(sql1, Take(DosagePrinting))
            'End If
            Return retVal
        End Function

        Public Function AddRecord(ByRef DosagePrinting As DosagePrinting) As Integer Implements IDao(Of DosagePrinting).AddRecord
            Dim sql As String =
                    " INSERT INTO [DosagePrinting] " &
                    " (DosageCode,Route,Direction,Frequency,FrequencyTiming) " &
                    " VALUES (@DosageCode,@Route,@Direction,@Frequency,@FrequencyTiming) "
            Return _db.Insert(sql, Take(DosagePrinting))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DosagePrinting) =
                            Function(reader) _
            New DosagePrinting() With {
            .Direction = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Int32)(reader("Direction")),
            .DosageCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DosageCode")),
            .Frequency = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("Frequency")),
            .FrequencyTiming = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Int32)(reader("FrequencyTiming")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Route = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Int32)(reader("Route")),
            .DosageName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DosageName")),
            .DosageNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DosageNameAra")),
            .Age = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Age")),
            .AgeDMY = AATM.DataLayer.AdoNet.Extensions.AsString("year(s)"),
            .FileNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("FileNo")),
            .PatientName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PatientName")),
            .Dose = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Dose")),
            .DoseUnit = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("DoseUnit")),
            .Duration = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Duration")),
            .DurationUnit = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("DurationUnit"))
            }

        Private Function Take(DosagePrinting As DosagePrinting) As Object()
            Return New Object() {
                            "Direction", DosagePrinting.Direction,
                            "DosageCode", DosagePrinting.DosageCode,
                            "Frequency", DosagePrinting.Frequency,
                            "FrequencyTiming", DosagePrinting.FrequencyTiming,
                            "IdNo", DosagePrinting.IdNo,
                            "Route", DosagePrinting.Route
                            }
        End Function

        'Private Function MakeDosage(number As Decimal) As String
        '    Return NumberToWord(number)
        'End Function

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