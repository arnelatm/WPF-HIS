Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports AATM.Accounts.DataLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models

Namespace ServiceLayer
    Public Class CashPositionService
        Private ReadOnly _dao As ICashPositionDao

        Public Sub New()
            Me.New(New CashPositionDao())
        End Sub

        Public Sub New(dao As ICashPositionDao)
            If dao Is Nothing Then Throw New ArgumentNullException(NameOf(dao))
            _dao = dao
        End Sub

        Public Function GetAccounts() As List(Of CashPositionAccountModel)
            Return _dao.GetAccounts().AsEnumerable().Select(Function(row) MakeAccount(row)).ToList()
        End Function

        Public Function GetAllAccounts() As List(Of CashPositionAccountModel)
            Dim generalDao = TryCast(_dao, IGeneralAccountPositionDao)
            If generalDao Is Nothing Then Throw New InvalidOperationException("GeneralAccountPositionUnavailable")
            Return generalDao.GetAllAccounts().AsEnumerable().Select(Function(row) MakeAccount(row)).ToList()
        End Function

        Public Function GetTransaction(journalCode As String, journalIdNo As Integer,
                                       itemIdNo As Integer, Optional allowAnyDetailAccount As Boolean = False) As CashPositionTransactionModel
            If journalIdNo <= 0 OrElse itemIdNo <= 0 OrElse
               Not {"GJ", "AP", "AR", "ER", "CK", "CD", "CR", "PC", "SJ"}.Contains(journalCode) Then
                Throw New ArgumentException("CashPositionTransactionUnavailable")
            End If
            Dim data As DataTable
            If allowAnyDetailAccount Then
                Dim generalDao = TryCast(_dao, IGeneralAccountPositionDao)
                If generalDao Is Nothing Then Throw New InvalidOperationException("GeneralAccountPositionUnavailable")
                data = generalDao.GetGeneralTransaction(journalCode, journalIdNo, itemIdNo)
            Else
                data = _dao.GetTransaction(journalCode, journalIdNo, itemIdNo)
            End If
            If data.Rows.Count = 0 Then Throw New InvalidOperationException("CashPositionTransactionUnavailable")
            Dim header = data.Rows(0)
            Dim result As New CashPositionTransactionModel With {
                .JournalCode = journalCode, .JournalIdNo = journalIdNo, .SelectedItemIdNo = itemIdNo,
                .TransactionDate = If(header.IsNull("TransactionDate"), CType(Nothing, Date?), Convert.ToDateTime(header("TransactionDate"))),
                .ReferenceNo = Convert.ToString(header("ReferenceNo")), .Notes = Convert.ToString(header("HeaderNotes")),
                .Posted = NullableFlag(header, "HeaderPosted"), .Approved = NullableFlag(header, "Approved"),
                .Cancelled = NullableFlag(header, "Cancelled"), .ClosingJournal = NullableFlag(header, "ClosingJournal")}
            For Each row As DataRow In data.Rows
                If Convert.ToInt32(row("JournalIdNo")) <> journalIdNo Then
                    Throw New InvalidOperationException("CashPositionTransactionUnavailable")
                End If
                result.Lines.Add(New CashPositionTransactionLineModel With {
                    .ItemIdNo = Convert.ToInt32(row("ItemIdNo")), .Sequence = Convert.ToInt16(row("Sequence")),
                    .AccountIdNo = Convert.ToInt16(row("AccountIdNo")), .AccountCode = Convert.ToString(row("AccountCode")),
                    .AccountName = Convert.ToString(row("AccountName")), .AccountNameAra = Convert.ToString(row("AccountNameAra")),
                    .Debit = MoneyOrZero(row, "Debit"), .Credit = MoneyOrZero(row, "Credit"),
                    .Notes = Convert.ToString(row("Notes")), .Posted = NullableFlag(row, "ItemPosted")})
            Next
            If Not result.Lines.Any(Function(line) line.ItemIdNo = itemIdNo) Then
                Throw New InvalidOperationException("CashPositionTransactionUnavailable")
            End If
            Return result
        End Function

        Public Function GetPosition(beginningDate As Date, endingDate As Date,
                                    accountIds As IEnumerable(Of Short)) As CashPositionModel
            beginningDate = beginningDate.Date
            endingDate = endingDate.Date
            If beginningDate > endingDate OrElse endingDate = Date.MaxValue.Date Then
                Throw New ArgumentException("CashPositionInvalidDates")
            End If
            Dim ids = If(accountIds, Enumerable.Empty(Of Short)()).Distinct().ToList()
            If ids.Count = 0 OrElse ids.Count > 2000 OrElse ids.Any(Function(id) id <= 0) Then
                Throw New ArgumentException("CashPositionSelectAccounts")
            End If
            Dim table = _dao.GetPosition(beginningDate, endingDate, ids)
            If table.Rows.Count = 0 OrElse Convert.ToInt32(table.Rows(0)("SnapshotRows")) = 0 Then
                Throw New InvalidOperationException("CashPositionMissingYear")
            End If
            If Math.Abs(Convert.ToDecimal(table.Rows(0)("SnapshotDifference"))) > 0.00005D Then
                Throw New InvalidOperationException("CashPositionUnbalancedSnapshot")
            End If
            Dim result As New CashPositionModel With {.BeginningDate = beginningDate, .EndingDate = endingDate}
            Dim accounts As New Dictionary(Of Short, CashPositionAccountModel)
            Dim identities As New HashSet(Of String)(StringComparer.Ordinal)
            For Each row As DataRow In table.Rows
                Dim id = Convert.ToInt16(row("IdNo"))
                Dim account As CashPositionAccountModel = Nothing
                If Not accounts.TryGetValue(id, account) Then
                    account = MakeAccount(row)
                    account.HasOpeningSnapshot = Not row.IsNull("SnapshotId")
                    account.OpeningBalance = MoneyOrZero(row, "SnapshotDebit") - MoneyOrZero(row, "SnapshotCredit")
                    accounts.Add(id, account)
                    result.Accounts.Add(account)
                End If
                If row.IsNull("ItemIdNo") Then Continue For
                Dim line As New CashPositionLineModel With {
                    .AccountIdNo = id, .JournalCode = Convert.ToString(row("JournalCode")),
                    .JournalIdNo = Convert.ToInt32(row("JournalIdNo")), .ItemIdNo = Convert.ToInt32(row("ItemIdNo")),
                    .TransactionDate = Convert.ToDateTime(row("TransactionDate")),
                    .ReferenceNo = Convert.ToString(row("ReferenceNo")), .Notes = Convert.ToString(row("Notes")),
                    .HeaderPosted = NullableFlag(row, "HeaderPosted"), .ItemPosted = NullableFlag(row, "ItemPosted"),
                    .ClosingJournal = Not row.IsNull("ClosingJournal") AndAlso Convert.ToBoolean(row("ClosingJournal")),
                    .Debit = Convert.ToDecimal(row("Debit")), .Credit = Convert.ToDecimal(row("Credit"))}
                Dim identity = line.JournalCode & ":" & line.JournalIdNo.ToString() & ":" & line.ItemIdNo.ToString()
                If Not identities.Add(identity) Then Throw New InvalidOperationException("CashPositionDuplicateSource")
                If Not line.HeaderPosted.HasValue OrElse Not line.ItemPosted.HasValue OrElse
                    line.HeaderPosted.Value <> line.ItemPosted.Value Then account.PostingReviewLines += 1
                If line.ClosingJournal Then account.ClosingJournalLines += 1
                If line.TransactionDate < beginningDate Then
                    account.OpeningBalance += line.Debit - line.Credit
                Else
                    account.Debit += line.Debit
                    account.Credit += line.Credit
                    result.Lines.Add(line)
                End If
            Next
            If accounts.Count <> ids.Count OrElse ids.Any(Function(id) Not accounts.ContainsKey(id)) Then
                Throw New InvalidOperationException("CashPositionAccountsChanged")
            End If
            For Each account In result.Accounts
                account.ClosingBalance = account.OpeningBalance + account.Debit - account.Credit
            Next
            Return result
        End Function

        Public Function GetGeneralPosition(beginningDate As Date, endingDate As Date,
                                           accountIds As IEnumerable(Of Short), Optional includeClosingEntries As Boolean = True) As CashPositionModel
            beginningDate = beginningDate.Date
            endingDate = endingDate.Date
            If beginningDate > endingDate OrElse endingDate = Date.MaxValue.Date Then
                Throw New ArgumentException("CashPositionInvalidDates")
            End If
            Dim selectedIds = If(accountIds, Enumerable.Empty(Of Short)()).Distinct().ToList()
            If selectedIds.Count = 0 OrElse selectedIds.Count > 2000 OrElse selectedIds.Any(Function(id) id <= 0) Then
                Throw New ArgumentException("CashPositionSelectAccounts")
            End If
            Dim generalDao = TryCast(_dao, IGeneralAccountPositionDao)
            If generalDao Is Nothing Then Throw New InvalidOperationException("GeneralAccountPositionUnavailable")
            Dim allAccounts = GetAllAccounts()
            Dim detailIds = allAccounts.Where(Function(candidate) candidate.DetailAccount AndAlso selectedIds.Contains(candidate.IdNo) OrElse candidate.DetailAccount AndAlso selectedIds.Any(Function(selected) IsDescendantOf(candidate, selected, allAccounts))).Select(Function(candidate) candidate.IdNo).Distinct().ToList()
            If detailIds.Count = 0 Then Throw New ArgumentException("CashPositionSelectAccounts")
            Return BuildPosition(beginningDate, endingDate, detailIds, generalDao.GetGeneralPosition(beginningDate, endingDate, detailIds, includeClosingEntries))
        End Function

        Private Shared Function IsDescendantOf(candidate As CashPositionAccountModel, ancestorId As Short, accounts As List(Of CashPositionAccountModel)) As Boolean
            Dim current = candidate.ParentIdNo
            Dim visited As New HashSet(Of Short)
            While current.HasValue AndAlso visited.Add(current.Value)
                If current.Value = ancestorId Then Return True
                Dim parent = accounts.FirstOrDefault(Function(account) account.IdNo = current.Value)
                If parent Is Nothing Then Exit While
                current = parent.ParentIdNo
            End While
            Return False
        End Function

        Private Function BuildPosition(beginningDate As Date, endingDate As Date,
                                       ids As List(Of Short), table As DataTable) As CashPositionModel
            If table.Rows.Count = 0 OrElse Convert.ToInt32(table.Rows(0)("SnapshotRows")) = 0 Then
                Throw New InvalidOperationException("CashPositionMissingYear")
            End If
            If Math.Abs(Convert.ToDecimal(table.Rows(0)("SnapshotDifference"))) > 0.00005D Then
                Throw New InvalidOperationException("CashPositionUnbalancedSnapshot")
            End If
            Dim result As New CashPositionModel With {.BeginningDate = beginningDate, .EndingDate = endingDate}
            Dim accounts As New Dictionary(Of Short, CashPositionAccountModel)
            Dim identities As New HashSet(Of String)(StringComparer.Ordinal)
            For Each row As DataRow In table.Rows
                Dim id = Convert.ToInt16(row("IdNo"))
                Dim account As CashPositionAccountModel = Nothing
                If Not accounts.TryGetValue(id, account) Then
                    account = MakeAccount(row)
                    account.HasOpeningSnapshot = Not row.IsNull("SnapshotId")
                    account.OpeningBalance = MoneyOrZero(row, "SnapshotDebit") - MoneyOrZero(row, "SnapshotCredit")
                    accounts.Add(id, account) : result.Accounts.Add(account)
                End If
                If row.IsNull("ItemIdNo") Then Continue For
                Dim line As New CashPositionLineModel With {.AccountIdNo = id, .JournalCode = Convert.ToString(row("JournalCode")), .JournalIdNo = Convert.ToInt32(row("JournalIdNo")), .ItemIdNo = Convert.ToInt32(row("ItemIdNo")), .TransactionDate = Convert.ToDateTime(row("TransactionDate")), .ReferenceNo = Convert.ToString(row("ReferenceNo")), .Notes = Convert.ToString(row("Notes")), .HeaderPosted = NullableFlag(row, "HeaderPosted"), .ItemPosted = NullableFlag(row, "ItemPosted"), .ClosingJournal = Not row.IsNull("ClosingJournal") AndAlso Convert.ToBoolean(row("ClosingJournal")), .Debit = Convert.ToDecimal(row("Debit")), .Credit = Convert.ToDecimal(row("Credit"))}
                Dim identity = line.JournalCode & ":" & line.JournalIdNo.ToString() & ":" & line.ItemIdNo.ToString()
                If Not identities.Add(identity) Then Throw New InvalidOperationException("CashPositionDuplicateSource")
                If Not line.HeaderPosted.HasValue OrElse Not line.ItemPosted.HasValue OrElse line.HeaderPosted.Value <> line.ItemPosted.Value Then account.PostingReviewLines += 1
                If line.ClosingJournal Then account.ClosingJournalLines += 1
                If line.TransactionDate < beginningDate Then account.OpeningBalance += line.Debit - line.Credit Else account.Debit += line.Debit : account.Credit += line.Credit : result.Lines.Add(line)
            Next
            If accounts.Count <> ids.Count OrElse ids.Any(Function(id) Not accounts.ContainsKey(id)) Then Throw New InvalidOperationException("CashPositionAccountsChanged")
            For Each account In result.Accounts : account.ClosingBalance = account.OpeningBalance + account.Debit - account.Credit : Next
            Return result
        End Function

        Private Shared Function MakeAccount(row As DataRow) As CashPositionAccountModel
            Return New CashPositionAccountModel With {
                .IdNo = Convert.ToInt16(row("IdNo")), .AccountCode = Convert.ToString(row("AccountCode")),
                .AccountName = Convert.ToString(row("AccountName")), .AccountNameAra = Convert.ToString(row("AccountNameAra")),
                .Active = Not row.IsNull("Active") AndAlso Convert.ToBoolean(row("Active")),
                .ParentIdNo = If(row.Table.Columns.Contains("ParentIdNo") AndAlso Not row.IsNull("ParentIdNo"), CType(Convert.ToInt16(row("ParentIdNo")), Short?), CType(Nothing, Short?)),
                .DetailAccount = Not row.Table.Columns.Contains("DetailAccount") OrElse (Not row.IsNull("DetailAccount") AndAlso Convert.ToBoolean(row("DetailAccount"))),
                .AccountGroup = If(row.Table.Columns.Contains("AccountGroup") AndAlso Not row.IsNull("AccountGroup"), Convert.ToString(row("AccountGroup")), ""),
                .SortKey = If(row.Table.Columns.Contains("SortKey") AndAlso Not row.IsNull("SortKey"), Convert.ToString(row("SortKey")), "")}
        End Function

        Private Shared Function MoneyOrZero(row As DataRow, field As String) As Decimal
            Return If(row.IsNull(field), 0D, Convert.ToDecimal(row(field)))
        End Function

        Private Shared Function NullableFlag(row As DataRow, field As String) As Boolean?
            If row.IsNull(field) Then Return Nothing
            Return Convert.ToBoolean(row(field))
        End Function
    End Class
End Namespace
