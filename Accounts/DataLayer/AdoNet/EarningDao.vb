Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Earning
    ' ** DAO Pattern

    Public Class EarningDao
        Inherits CommonDao
        Implements IDaoAll(Of Earning)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As Earning Implements IDaoAll(Of Earning).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, EarningCode, EarningName, EarningNameAra, Frequency, EarningType, AccountIdNo" &
                    "   FROM [Earning]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            'Dim jiDao = New PayrollEarnAccountDao()

            'data.JournalItems = jiDao.GetRecordsWithIdNo(idNo, "Sequence")
            'For Each item In data.JournalItems
            '    data.TotalDebits += item.Debit
            '    data.TotalCredits += item.Credit
            'Next
            Return data
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Earning) _
            Implements IDaoAll(Of Earning).GetAll
            If sortExpression = Nothing Then
                sortExpression = "EarningName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, EarningCode, EarningName, EarningNameAra" &
                    "   FROM [Earning] " & "order by " & sortExpression
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef earning As Earning) As Integer Implements IDaoAll(Of Earning).UpdateRecord
            Dim sql As String =
                    " UPDATE [Earning]" &
                    " SET EarningCode = @EarningCode," &
                    " EarningName = @EarningName," &
                    " EarningNameAra = @EarningNameAra," &
                    " Frequency = @Frequency," &
                    " EarningType = @EarningType," &
                    " AccountIdNo = @AccountIdNo" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(earning))
        End Function

        Public Function AddRecord(ByRef earning As Earning) As Integer Implements IDaoAll(Of Earning).AddRecord
            Dim sql As String =
                    " INSERT INTO [Earning] " &
                    " (EarningCode,EarningName,EarningNameAra,Frequency,EarningType,AccountIdNo) " &
                    " VALUES (@EarningCode,@EarningName,@EarningNameAra,@Frequency,@EarningType,@AccountIdNo) "
            Return _db.Insert(sql, Take(earning))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Earning) =
                                    Function(reader) _
            New Earning() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .EarningCode = Extensions.AsString(reader("EarningCode")),
            .EarningName = Extensions.AsString(reader("EarningName")),
            .EarningNameAra = Extensions.AsString(reader("EarningNameAra")),
            .Frequency = Extensions.AsString(reader("Frequency")),
            .EarningType = Extensions.AsChar(reader("EarningType")),
            .AccountIdNo = Extensions.AsId(Of Int16)(reader("AccountIdNo"))
            }

        Private Function Take(earning As Earning) As Object()
            Return New Object() {
                                    "@IdNo", earning.IdNo,
                                    "@EarningCode", earning.EarningCode,
                                    "@EarningName", earning.EarningName,
                                    "@EarningNameAra", earning.EarningNameAra,
                                    "@Frequency", earning.Frequency,
                                    "@EarningType", earning.EarningType,
                                    "@AccountIdNo", earning.AccountIdNo
                                }
        End Function

    End Class

End Namespace