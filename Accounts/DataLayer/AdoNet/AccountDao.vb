Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Account
    ' ** DAO Pattern

    Public Class AccountDao
        Inherits CommonDao
        Implements iDao(Of Account), IDaoAccount

        Private Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Account Implements iDao(Of Account).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " &
                    "AccountCode," &
                    "AccountGroup," &
                    "AccountName," &
                    "AccountNameAra," &
                    "Active," &
                    "DetailAccount," &
                    "IdNo," &
                    "LevelNumber," &
                    "NormalBalance," &
                    "Notes," &
                    "ParentIdNo," &
                    "PayeeType," &
                    "SortKey," &
                    "SpecialAccount," &
                    "WithReconciliation" &
                    " FROM [Account_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim x = Db.Read(sql, Make, params).FirstOrDefault()
            Return x
        End Function

        Public Function GetDetailAccounts(Optional sortExpression As String = Nothing) As List(Of Account) _
            Implements IDaoAccount.GetDetailAccounts
            If sortExpression Is Nothing Or sortExpression = "" Then
                sortExpression = "AccountName"
            End If
            Dim sql As String
            sql = "Select" &
                  "a.AccountCode," &
                  "a.AccountGroup," &
                  "a.AccountName," &
                  "a.AccountNameAra," &
                  "a.Active," &
                  "a.DetailAccount," &
                  "a.IdNo," &
                  "a.LevelNumber," &
                  "a.NormalBalance," &
                  "a.Notes," &
                  "a.ParentIdNo," &
                  "a.PayeeType," &
                  "a.SortKey," &
                  "a.SpecialAccount," &
                  "a.WithReconciliation" &
                  " from Account_View as a" &
                  " LEFT JOIN Account b" &
                  " ON a.IdNo = b.ParentIdNo" &
                  " WHERE b.IdNo IS NULL " &
                  " order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef account As Account) As Integer Implements iDao(Of Account).UpdateRecord
            Dim sql As String =
                    "UPDATE [Account] SET " &
                    "AccountCode = @AccountCode," &
                    "AccountGroup = @AccountGroup," &
                    "AccountName = @AccountName," &
                    "AccountNameAra = @AccountNameAra," &
                    "Active = @Active," &
                    "DetailAccount = @DetailAccount," &
                    "NormalBalance = @NormalBalance," &
                    "Notes = @Notes," &
                    "ParentIdNo = @ParentIdNo," &
                    "PayeeType = @PayeeType," &
                    "SpecialAccount = @SpecialAccount," &
                    "WithReconciliation = @WithReconciliation" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(account))
        End Function

        Public Function AddRecord(ByRef account As Account) As Integer Implements iDao(Of Account).AddRecord
            Dim sql As String =
                    "INSERT INTO [Account] (" &
                    "AccountCode," &
                    "AccountGroup," &
                    "AccountName," &
                    "AccountNameAra," &
                    "Active," &
                    "DetailAccount," &
                    "NormalBalance," &
                    "Notes," &
                    "ParentIdNo," &
                    "PayeeType," &
                    "SpecialAccount," &
                    "WithReconciliation" &
                    ") VALUES (" &
                    "@AccountCode," &
                    "@AccountGroup," &
                    "@AccountName," &
                    "@AccountNameAra," &
                    "@Active," &
                    "@DetailAccount," &
                    "@NormalBalance," &
                    "@Notes," &
                    "@ParentIdNo," &
                    "@PayeeType," &
                    "@SpecialAccount," &
                    "@WithReconciliation" &
                    ")"
            Return Db.Insert(sql, Take(account))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Account) =
                                    Function(reader) _
            New Account() With {
            .AccountCode = Extensions.AsString(reader("AccountCode")),
            .AccountGroup = Extensions.AsString(reader("AccountGroup")),
            .AccountName = Extensions.AsString(reader("AccountName")),
            .AccountNameAra = Extensions.AsString(reader("AccountNameAra")),
            .Active = Extensions.AsBool(reader("Active")),
            .DetailAccount = Extensions.AsBool(reader("DetailAccount")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .LevelNumber = Extensions.AsInt(Of Short)(reader("LevelNumber")),
            .NormalBalance = Extensions.AsString(reader("NormalBalance")),
            .Notes = Extensions.AsString(reader("Notes")),
            .ParentIdNo = Extensions.AsNullable(Of Int32?)(reader("ParentIdNo")),
            .PayeeType = Extensions.AsString(reader("PayeeType")),
            .SortKey = Extensions.AsString(reader("SortKey")),
            .SpecialAccount = Extensions.AsString(reader("SpecialAccount")),
            .WithReconciliation = Extensions.AsBool(reader("WithReconciliation"))
            }

        Private Function Take(Account As Account) As Object()
            Return New Object() {
                                    "@AccountCode", Account.AccountCode,
                                    "@AccountGroup", Account.AccountGroup,
                                    "@AccountName", Account.AccountName,
                                    "@AccountNameAra", Account.AccountNameAra,
                                    "@Active", Account.Active,
                                    "@DetailAccount", Account.DetailAccount,
                                    "@IdNo", Account.IdNo,
                                    "@LevelNumber", Account.LevelNumber,
                                    "@NormalBalance", Account.NormalBalance,
                                    "@Notes", Account.Notes,
                                    "@ParentIdNo", Account.ParentIdNo,
                                    "@PayeeType", Account.PayeeType,
                                    "@SortKey", Account.SortKey,
                                    "@SpecialAccount", Account.SpecialAccount,
                                    "@WithReconciliation", Account.WithReconciliation
                                }
        End Function

    End Class

End Namespace