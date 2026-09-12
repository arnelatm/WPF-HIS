Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    Public Class CashPositionDao
        Inherits AccountsDao
        Implements ICashPositionDao, IGeneralAccountPositionDao

        Private ReadOnly _cashDb As New Db()

        Public Function GetTransaction(journalCode As String, journalIdNo As Integer,
                                       itemIdNo As Integer) As DataTable Implements ICashPositionDao.GetTransaction
            Return GetTransactionCore(journalCode, journalIdNo, itemIdNo, False)
        End Function

        Public Function GetGeneralTransaction(journalCode As String, journalIdNo As Integer,
                                              itemIdNo As Integer) As DataTable Implements IGeneralAccountPositionDao.GetGeneralTransaction
            Return GetTransactionCore(journalCode, journalIdNo, itemIdNo, True)
        End Function

        Private Function GetTransactionCore(journalCode As String, journalIdNo As Integer,
                                            itemIdNo As Integer, allowAnyDetailAccount As Boolean) As DataTable
            Dim table As String
            Select Case journalCode
                Case "GJ" : table = "GeneralJournal"
                Case "AP" : table = "ApJournal"
                Case "AR" : table = "ArJournal"
                Case "ER" : table = "ErJournal"
                Case "CK" : table = "CkJournal"
                Case "CD" : table = "CdJournal"
                Case "CR" : table = "CashReceiptJournal"
                Case "PC" : table = "PcJournal"
                Case "SJ" : table = "SalesJournal"
                Case Else : Throw New ArgumentException("CashPositionTransactionUnavailable")
            End Select
            ' The anchor identifies the clicked cash line; the result includes the whole voucher.
            Return _cashDb.ExecuteReader(
                "SELECT h.IdNo AS JournalIdNo,h.TransactionDate,h.ReferenceNo,h.Notes AS HeaderNotes," &
                "h.Posted AS HeaderPosted,h.Approved,h.Cancelled," &
                If(journalCode = "GJ", "h.ClosingJournal", "CAST(0 AS bit)") & " AS ClosingJournal," &
                "i.IdNo AS ItemIdNo,i.Sequence,i.AccountIdNo,a.AccountCode,a.AccountName,a.AccountNameAra," &
                "i.Debit,i.Credit,i.Notes,i.Posted AS ItemPosted " &
                "FROM dbo." & table & " h INNER JOIN dbo." & table & "Item i ON i.JournalIdNo=h.IdNo " &
                "LEFT JOIN dbo.Account a ON a.IdNo=i.AccountIdNo " &
                "WHERE h.IdNo=@JournalIdNo AND EXISTS (SELECT 1 FROM dbo." & table & "Item anchor " &
                "INNER JOIN dbo.Account ca ON ca.IdNo=anchor.AccountIdNo " &
                "WHERE anchor.JournalIdNo=h.IdNo AND anchor.IdNo=@ItemIdNo " &
                If(allowAnyDetailAccount, "AND ca.DetailAccount=1", "AND ca.DetailAccount=1 AND ca.SpecialAccount IN ('BA','CS','CK','PC')") & ") " &
                "ORDER BY i.Sequence,i.IdNo", {"@JournalIdNo", journalIdNo, "@ItemIdNo", itemIdNo})
        End Function

        Public Function GetAccounts() As DataTable Implements ICashPositionDao.GetAccounts
            Return _cashDb.ExecuteReader(
                "IF OBJECT_ID(N'dbo.CashFlowAccountRule',N'U') IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.CashFlowAccountRule WHERE IsActive=1 AND IsCashEquivalent=1) " &
                "BEGIN SELECT a.IdNo,a.AccountCode,a.AccountName,a.AccountNameAra,a.Active FROM dbo.Account a INNER JOIN dbo.CashFlowAccountRule r ON r.AccountIdNo=a.IdNo WHERE r.IsActive=1 AND r.IsCashEquivalent=1 ORDER BY a.AccountCode END " &
                "ELSE BEGIN SELECT IdNo,AccountCode,AccountName,AccountNameAra,Active FROM dbo.Account WHERE DetailAccount=1 AND SpecialAccount IN ('BA','CS','CK','PC') ORDER BY AccountCode END")
        End Function

        Public Function GetAllAccounts() As DataTable Implements IGeneralAccountPositionDao.GetAllAccounts
            Return _cashDb.ExecuteReader("SELECT IdNo,ParentIdNo,AccountCode,AccountName,AccountNameAra,Active,DetailAccount,AccountGroup,SortKey FROM dbo.Account_View ORDER BY SortKey,AccountCode")
        End Function

        Public Function GetPosition(beginningDate As Date, endingDate As Date,
                                    accountIds As List(Of Short)) As DataTable Implements ICashPositionDao.GetPosition
            Return GetPositionCore(beginningDate, endingDate, accountIds, True, True)
        End Function

        Public Function GetGeneralPosition(beginningDate As Date, endingDate As Date,
                                           accountIds As List(Of Short), includeClosingEntries As Boolean) As DataTable Implements IGeneralAccountPositionDao.GetGeneralPosition
            Return GetPositionCore(beginningDate, endingDate, accountIds, False, includeClosingEntries)
        End Function

        Private Function GetPositionCore(beginningDate As Date, endingDate As Date,
                                         accountIds As List(Of Short), cashOnly As Boolean, includeClosingEntries As Boolean) As DataTable
            'Only fixed repository-owned table names are composed. All selections/dates are parameters.
            Dim journals = New String(,) {{"GJ", "GeneralJournal"}, {"AP", "ApJournal"},
                {"AR", "ArJournal"}, {"ER", "ErJournal"}, {"CK", "CkJournal"},
                {"CD", "CdJournal"}, {"CR", "CashReceiptJournal"}, {"PC", "PcJournal"}, {"SJ", "SalesJournal"}}
            Dim sources As New List(Of String)
            For index = 0 To journals.GetLength(0) - 1
                Dim code = journals(index, 0)
                Dim table = journals(index, 1)
                sources.Add("SELECT '" & code & "' AS JournalCode,h.IdNo AS JournalIdNo,i.IdNo AS ItemIdNo," &
                    "i.AccountIdNo,h.TransactionDate,CONVERT(nvarchar(100),h.ReferenceNo) COLLATE DATABASE_DEFAULT AS ReferenceNo," &
                    "CONVERT(nvarchar(max),i.Notes) COLLATE DATABASE_DEFAULT AS Notes," &
                    "h.Posted AS HeaderPosted,i.Posted AS ItemPosted," &
                    If(code = "GJ", "h.ClosingJournal", "CAST(0 AS bit)") & " AS ClosingJournal,i.Debit,i.Credit " &
                    "FROM dbo." & table & " h INNER JOIN dbo." & table & "Item i ON i.JournalIdNo=h.IdNo " &
                    "WHERE h.Cancelled=0 AND h.TransactionDate>=@YearStart AND h.TransactionDate<@EndExclusive AND " & If(code = "GJ", "(h.ClosingJournal=0 OR @IncludeClosingEntries=1)", "1=1"))
            Next
            Dim parameters As New List(Of Object) From {
                "@YearStart", New Date(beginningDate.Year, 1, 1), "@EndExclusive", endingDate.AddDays(1),
                "@SnapshotYear", beginningDate.Year}
            parameters.Add("@IncludeClosingEntries")
            parameters.Add(If(includeClosingEntries, 1, 0))
            Dim selection As New List(Of String)
            For index = 0 To accountIds.Count - 1
                Dim name = "@Account" & index.ToString(Globalization.CultureInfo.InvariantCulture)
                selection.Add(name)
                parameters.Add(name)
                parameters.Add(accountIds(index))
            Next
            Dim accountFilter = If(cashOnly, "a.SpecialAccount IN ('BA','CS','CK','PC') AND ", "")
            Dim sql = ";WITH Movements AS (" & String.Join(" UNION ALL ", sources) & "), " &
                "SnapshotStatus AS (SELECT COUNT(*) AS SnapshotRows," &
                "SUM(CONVERT(decimal(19,4),ISNULL(Debit,0))-CONVERT(decimal(19,4),ISNULL(Credit,0))) AS SnapshotDifference " &
                "FROM dbo.AccountBalance WHERE [Year]=@SnapshotYear) " &
                "SELECT a.IdNo,a.AccountCode,a.AccountName,a.AccountNameAra,a.Active," &
                "ab.IdNo AS SnapshotId,ab.Debit AS SnapshotDebit,ab.Credit AS SnapshotCredit," &
                "s.SnapshotRows,s.SnapshotDifference,m.JournalCode,m.JournalIdNo,m.ItemIdNo,m.TransactionDate," &
                "m.ReferenceNo,m.Notes,m.HeaderPosted,m.ItemPosted,m.ClosingJournal,m.Debit,m.Credit " &
                "FROM dbo.Account a CROSS JOIN SnapshotStatus s " &
                "LEFT JOIN dbo.AccountBalance ab ON ab.AccountIdNo=a.IdNo AND ab.[Year]=@SnapshotYear " &
                "LEFT JOIN Movements m ON m.AccountIdNo=a.IdNo " &
                "WHERE a.DetailAccount=1 AND " & accountFilter & "a.IdNo IN (" &
                String.Join(",", selection) & ") ORDER BY a.AccountCode,m.TransactionDate,m.JournalCode,m.JournalIdNo,m.ItemIdNo"
            'ExecuteReader propagates failures; do not return partial balances through Db.Read's legacy catch.
            Return _cashDb.ExecuteReader(sql, parameters.ToArray())
        End Function
    End Class
End Namespace
