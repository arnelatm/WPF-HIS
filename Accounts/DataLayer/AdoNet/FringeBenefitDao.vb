Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for FringeBenefit
    ' ** DAO Pattern

    Public Class FringeBenefitDao
        Inherits CommonDao
        Implements IDaoAll(Of FringeBenefit)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As FringeBenefit Implements IDaoAll(Of FringeBenefit).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, FringeBenefitCode, FringeBenefitName, FringeBenefitNameAra, AccountIdNo, DefaultFrequency, FringeBenefitType " &
                    "   FROM [FringeBenefit]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of FringeBenefit) _
            Implements IDaoAll(Of FringeBenefit).GetAll
            If sortExpression = Nothing Then
                sortExpression = "FringeBenefitName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, FringeBenefitCode, FringeBenefitName, FringeBenefitNameAra" &
                    "   FROM [FringeBenefit] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef FringeBenefit As FringeBenefit) As Integer Implements IDaoAll(Of FringeBenefit).UpdateRecord
            Dim sql As String =
                    " UPDATE [FringeBenefit]" &
                    " SET FringeBenefitCode = @FringeBenefitCode," &
                    " FringeBenefitName = @FringeBenefitName," &
                    " FringeBenefitNameAra = @FringeBenefitNameAra," &
                    " AccountIdNo = @AccountIdNo," &
                    " DefaultFrequency = @DefaultFrequency," &
                    " FringeBenefitType = @FringeBenefitType" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(FringeBenefit))
        End Function

        Public Function AddRecord(ByRef FringeBenefit As FringeBenefit) As Integer Implements IDaoAll(Of FringeBenefit).AddRecord
            Dim sql As String =
                    " INSERT INTO [FringeBenefit] " &
                    " (FringeBenefitCode,FringeBenefitName,FringeBenefitNameAra,AccountIdNo,DefaultFrequency,FringeBenefitType) " &
                    " VALUES (@FringeBenefitCode,@FringeBenefitName,@FringeBenefitNameAra,@AccountIdNo,@DefaultFrequency,@FringeBenefitType) "
            Return Db.Insert(sql, Take(FringeBenefit))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, FringeBenefit) =
                                    Function(reader) _
            New FringeBenefit() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .FringeBenefitCode = Extensions.AsString(reader("FringeBenefitCode")),
            .FringeBenefitName = Extensions.AsString(reader("FringeBenefitName")),
            .FringeBenefitNameAra = Extensions.AsString(reader("FringeBenefitNameAra")),
            .AccountIdNo = Extensions.AsId(Of Int32)(reader("AccountIdNo")),
            .DefaultFrequency = Extensions.AsString(reader("DefaultFrequency")),
            .FringeBenefitType = Extensions.AsString(reader("FringeBenefitType"))
            }

        Private Function Take(FringeBenefit As FringeBenefit) As Object()
            Return New Object() {
                                    "@IdNo", FringeBenefit.IdNo,
                                    "@FringeBenefitCode", FringeBenefit.FringeBenefitCode,
                                    "@FringeBenefitName", FringeBenefit.FringeBenefitName,
                                    "@FringeBenefitNameAra", FringeBenefit.FringeBenefitNameAra,
                                    "@AccountIdNo", FringeBenefit.AccountIdNo,
                                    "@DefaultFrequency", FringeBenefit.DefaultFrequency,
                                    "@FringeBenefitType", FringeBenefit.FringeBenefitType
                                }
        End Function

    End Class

End Namespace