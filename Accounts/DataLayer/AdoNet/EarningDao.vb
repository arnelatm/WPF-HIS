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

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As Earning Implements IDaoAll(Of Earning).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, EarningCode, EarningName, EarningNameAra, AccountIdNo, DefaultFrequency, EarningType " &
                    "   FROM [Earning]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Earning) _
            Implements IDaoAll(Of Earning).GetAll
            If sortExpression = Nothing Then
                sortExpression = "EarningName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, EarningCode, EarningName, EarningNameAra" &
                    "   FROM [Earning] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef Earning As Earning) As Integer Implements IDaoAll(Of Earning).UpdateRecord
            Dim sql As String =
                    " UPDATE [Earning]" &
                    " SET EarningCode = @EarningCode," &
                    " EarningName = @EarningName," &
                    " EarningNameAra = @EarningNameAra," &
                    " AccountIdNo = @AccountIdNo," &
                    " DefaultFrequency = @DefaultFrequency," &
                    " EarningType = @EarningType" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(Earning))
        End Function

        Public Function AddRecord(ByRef Earning As Earning) As Integer Implements IDaoAll(Of Earning).AddRecord
            Dim sql As String =
                    " INSERT INTO [Earning] " &
                    " (EarningCode,EarningName,EarningNameAra,AccountIdNo,DefaultFrequency,EarningType) " &
                    " VALUES (@EarningCode,@EarningName,@EarningNameAra,@AccountIdNo,@DefaultFrequency,@EarningType) "
            Return Db.Insert(sql, Take(Earning))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Earning) =
                                    Function(reader) _
            New Earning() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .EarningCode = Extensions.AsString(reader("EarningCode")),
            .EarningName = Extensions.AsString(reader("EarningName")),
            .EarningNameAra = Extensions.AsString(reader("EarningNameAra")),
            .AccountIdNo = Extensions.AsId(Of Int32)(reader("AccountIdNo")),
            .DefaultFrequency = Extensions.AsString(reader("DefaultFrequency")),
            .EarningType = Extensions.AsString(reader("EarningType"))
            }

        Private Function Take(Earning As Earning) As Object()
            Return New Object() {
                                    "@IdNo", Earning.IdNo,
                                    "@EarningCode", Earning.EarningCode,
                                    "@EarningName", Earning.EarningName,
                                    "@EarningNameAra", Earning.EarningNameAra,
                                    "@AccountIdNo", Earning.AccountIdNo,
                                    "@DefaultFrequency", Earning.DefaultFrequency,
                                    "@EarningType", Earning.EarningType
                                }
        End Function

    End Class

End Namespace