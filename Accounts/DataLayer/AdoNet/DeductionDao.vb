Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Deduction
    ' ** DAO Pattern

    Public Class DeductionDao
        Inherits CommonDao
        Implements IDaoAll(Of Deduction)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As Deduction Implements IDaoAll(Of Deduction).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, DeductionCode, DeductionName, DeductionNameAra, AccountIdNo, DefaultFrequency, DeductionType, Notes " &
                    "   FROM [Deduction]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Deduction) _
            Implements IDaoAll(Of Deduction).GetAll
            If sortExpression = Nothing Then
                sortExpression = "DeductionName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, DeductionCode, DeductionName, DeductionNameAra" &
                    "   FROM [Deduction] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef Deduction As Deduction) As Integer Implements IDaoAll(Of Deduction).UpdateRecord
            Dim sql As String =
                    " UPDATE [Deduction]" &
                    " SET DeductionCode = @DeductionCode," &
                    " DeductionName = @DeductionName," &
                    " DeductionNameAra = @DeductionNameAra," &
                    " AccountIdNo = @AccountIdNo," &
                    " DefaultFrequency = @DefaultFrequency," &
                    " DeductionType = @DeductionType," &
                    " Notes = @Notes" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(Deduction))
        End Function

        Public Function AddRecord(ByRef Deduction As Deduction) As Integer Implements IDaoAll(Of Deduction).AddRecord
            Dim sql As String =
                    " INSERT INTO [Deduction] " &
                    " (DeductionCode,DeductionName,DeductionNameAra,AccountIdNo,DefaultFrequency,DeductionType,Notes) " &
                    " VALUES (@DeductionCode,@DeductionName,@DeductionNameAra,@AccountIdNo,@DefaultFrequency,@DeductionType,@Notes) "
            Return Db.Insert(sql, Take(Deduction))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Deduction) =
                                    Function(reader) _
            New Deduction() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .DeductionCode = Extensions.AsString(reader("DeductionCode")),
            .DeductionName = Extensions.AsString(reader("DeductionName")),
            .DeductionNameAra = Extensions.AsString(reader("DeductionNameAra")),
            .AccountIdNo = Extensions.AsId(Of Int32)(reader("AccountIdNo")),
            .DefaultFrequency = Extensions.AsString(reader("DefaultFrequency")),
            .DeductionType = Extensions.AsString(reader("DeductionType")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(Deduction As Deduction) As Object()
            Return New Object() {
                                    "@IdNo", Deduction.IdNo,
                                    "@DeductionCode", Deduction.DeductionCode,
                                    "@DeductionName", Deduction.DeductionName,
                                    "@DeductionNameAra", Deduction.DeductionNameAra,
                                    "@AccountIdNo", Deduction.AccountIdNo,
                                    "@DefaultFrequency", Deduction.DefaultFrequency,
                                    "@DeductionType", Deduction.DeductionType,
                                    "@Notes", Deduction.Notes
                                }
        End Function

    End Class

End Namespace