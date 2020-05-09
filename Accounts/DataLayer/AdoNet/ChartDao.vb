Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Chart
    ' ** DAO Pattern

    Public Class ChartDao
        Inherits CommonDao
        Implements IDaoAll(Of Chart), IDaoChart

        Private Db As New Db()

        Public Function GetRecordById(idNo) As Chart Implements IDaoAll(Of Chart).GetRecordById
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
                    " FROM [Chart_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim x = Db.Read(sql, Make, params).FirstOrDefault()
            Return x
        End Function

        Public Function GetDetailAccounts(Optional sortExpression As String = Nothing) As List(Of Chart) _
            Implements IDaoChart.GetDetailAccounts
            If sortExpression Is Nothing Then
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
                  " from Chart_View as a" &
                  " LEFT JOIN chart b" &
                  " ON a.IdNo = b.ParentIdNo" &
                  " WHERE b.IdNo IS NULL " &
                  " order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Chart) _
            Implements IDaoAll(Of Chart).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "AccountName Asc"
            End If
            Dim sql As String =
                    " SELECT IdNo, ParentIdNo, AccountCode, AccountName, AccountNameAra, AccountGroup, DetailAccount, NormalBalance, " &
                    " PayeeType, WithReconciliation, Active, Notes, LevelNumber, SortKey" &
                    "   FROM [Chart_View] order by sortKey"
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef chart As Chart) As Integer Implements IDaoAll(Of Chart).UpdateRecord
            Dim sql As String =
                    "UPDATE [Chart] SET " &
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
            Return Db.Update(sql, Take(chart))
        End Function

        Public Function AddRecord(ByRef chart As Chart) As Integer Implements IDaoAll(Of Chart).AddRecord
            Dim sql As String =
                    "INSERT INTO [Chart] (" &
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
            Return Db.Insert(sql, Take(chart))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Chart) =
                                    Function(reader) _
            New Chart() With {
            .AccountCode = Extensions.AsString(reader("AccountCode")),
            .AccountGroup = Extensions.AsString(reader("AccountGroup")),
            .AccountName = Extensions.AsString(reader("AccountName")),
            .AccountNameAra = Extensions.AsString(reader("AccountNameAra")),
            .Active = Extensions.AsBool(reader("Active")),
            .DetailAccount = Extensions.AsBool(reader("DetailAccount")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .LevelNumber = Extensions.AsInt(Of Short)(reader("LevelNumber")),
            .NormalBalance = Extensions.AsString(reader("NormalBalance")),
            .Notes = Extensions.AsString(reader("Notes")),
            .ParentIdNo = Extensions.AsNullable(Of Int32?)(reader("ParentIdNo")),
            .PayeeType = Extensions.AsString(reader("PayeeType")),
            .SortKey = Extensions.AsString(reader("SortKey")),
            .SpecialAccount = Extensions.AsString(reader("SpecialAccount")),
            .WithReconciliation = Extensions.AsBool(reader("WithReconciliation"))
            }

        Private Function Take(chart As Chart) As Object()
            Return New Object() {
                                    "@AccountCode", chart.AccountCode,
                                    "@AccountGroup", chart.AccountGroup,
                                    "@AccountName", chart.AccountName,
                                    "@AccountNameAra", chart.AccountNameAra,
                                    "@Active", chart.Active,
                                    "@DetailAccount", chart.DetailAccount,
                                    "@IdNo", chart.IdNo,
                                    "@LevelNumber", chart.LevelNumber,
                                    "@NormalBalance", chart.NormalBalance,
                                    "@Notes", chart.Notes,
                                    "@ParentIdNo", chart.ParentIdNo,
                                    "@PayeeType", chart.PayeeType,
                                    "@SortKey", chart.SortKey,
                                    "@SpecialAccount", chart.SpecialAccount,
                                    "@WithReconciliation", chart.WithReconciliation
                                }
        End Function

    End Class

End Namespace