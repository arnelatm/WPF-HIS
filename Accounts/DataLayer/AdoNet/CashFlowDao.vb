Imports System.Collections.Generic
Imports System.Data
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    Public Class CashFlowDao
        Inherits AccountsDao
        Implements ICashFlowDao

        Private ReadOnly _db As New Db()

        Public Function GetAccounts() As DataTable Implements ICashFlowDao.GetAccounts
            Dim sql = "IF OBJECT_ID(N'dbo.CashFlowAccountRule',N'U') IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.CashFlowAccountRule WHERE IsActive=1 AND IsCashEquivalent=1) " &
                      "BEGIN SELECT a.IdNo,a.AccountCode,a.AccountName,a.AccountNameAra,a.Active FROM dbo.Account a INNER JOIN dbo.CashFlowAccountRule r ON r.AccountIdNo=a.IdNo WHERE r.IsActive=1 AND r.IsCashEquivalent=1 ORDER BY a.AccountCode END " &
                      "ELSE BEGIN SELECT IdNo,AccountCode,AccountName,AccountNameAra,Active FROM dbo.Account WHERE DetailAccount=1 AND SpecialAccount IN ('BA','CS','CK','PC') ORDER BY AccountCode END"
            Return _db.ExecuteReader(sql)
        End Function

        Public Function GetAllAccounts() As DataTable Implements ICashFlowDao.GetAllAccounts
            Return _db.ExecuteReader("SELECT IdNo,AccountCode,AccountName,AccountNameAra,Active FROM dbo.Account WHERE DetailAccount=1 ORDER BY AccountCode")
        End Function

        Public Function GetAccountRules() As DataTable Implements ICashFlowDao.GetAccountRules
            Dim sql = "IF OBJECT_ID(N'dbo.CashFlowAccountRule',N'U') IS NULL " &
                      "BEGIN SELECT CAST(NULL AS smallint) AS AccountIdNo,CAST(NULL AS varchar(5)) AS AccountCode,CAST(NULL AS varchar(40)) AS ClassificationCode,CAST(NULL AS varchar(40)) AS CategoryCode,CAST(NULL AS bit) AS IsCashEquivalent,CAST(NULL AS bit) AS IsActive WHERE 1=0 END " &
                      "ELSE SELECT r.AccountIdNo,a.AccountCode,a.AccountName,r.ClassificationCode,r.CategoryCode,r.IsCashEquivalent,r.IsActive FROM dbo.CashFlowAccountRule r INNER JOIN dbo.Account a ON a.IdNo=r.AccountIdNo WHERE r.IsActive=1"
            Return _db.ExecuteReader(sql)
        End Function

        Public Function GetClassifications() As DataTable Implements ICashFlowDao.GetClassifications
            Return _db.ExecuteReader("SELECT Code,Section,Name,NameAra,DisplayOrder FROM dbo.CashFlowClassification WHERE IsActive=1 ORDER BY DisplayOrder,Code")
        End Function

        Public Function SaveAccountRule(accountIdNo As Short, classificationCode As String, categoryCode As String, isCashEquivalent As Boolean) As Integer Implements ICashFlowDao.SaveAccountRule
            Dim c = classificationCode.Replace("'", "''"), category = categoryCode.Replace("'", "''")
            Dim sql = "SET ANSI_NULLS ON; SET QUOTED_IDENTIFIER ON; SET XACT_ABORT ON; UPDATE dbo.CashFlowAccountRule SET IsActive=0 WHERE AccountIdNo=" & accountIdNo.ToString() & "; " &
                      "INSERT dbo.CashFlowAccountRule(AccountIdNo,ClassificationCode,CategoryCode,IsCashEquivalent,IsActive,EffectiveFrom,Notes,CreatedBy) VALUES (" & accountIdNo.ToString() & ",'" & c & "','" & category & "'," & If(isCashEquivalent, "1", "0") & ",1,CONVERT(date,GETDATE()),N'Updated provisionally from Cash Flow Setup',N'Cash Flow Setup');"
            Return _db.ExecuteSqlTransaction("SaveCashFlowAccountRule", sql)
        End Function

        Public Function GetApprovedAllocations() As DataTable Implements ICashFlowDao.GetApprovedAllocations
            Dim sql = "IF OBJECT_ID(N'dbo.CashFlowAllocation',N'U') IS NULL " &
                      "BEGIN SELECT CAST(NULL AS bigint) AS IdNo,CAST(NULL AS char(2)) AS JournalCode,CAST(NULL AS int) AS JournalIdNo,CAST(NULL AS int) AS ItemIdNo,CAST(NULL AS smallint) AS CashAccountIdNo,CAST(NULL AS varchar(40)) AS ClassificationCode,CAST(NULL AS varchar(40)) AS CategoryCode,CAST(NULL AS money) AS Amount,CAST(NULL AS varchar(20)) AS Status WHERE 1=0 END " &
                      "ELSE SELECT IdNo,JournalCode,JournalIdNo,ItemIdNo,CashAccountIdNo,ClassificationCode,CategoryCode,Amount,Status FROM dbo.CashFlowAllocation WHERE Status='Approved'"
            Return _db.ExecuteReader(sql)
        End Function

        Public Function GetLedger(beginningDate As Date, endingDate As Date) As DataTable Implements ICashFlowDao.GetLedger
            Dim sources = New String(,) { {"GJ", "GeneralJournal"}, {"AP", "ApJournal"}, {"AR", "ArJournal"}, {"ER", "ErJournal"}, {"CK", "CkJournal"}, {"CD", "CdJournal"}, {"CR", "CashReceiptJournal"}, {"PC", "PcJournal"}, {"SJ", "SalesJournal"} }
            Dim unions As New List(Of String)
            For n = 0 To sources.GetLength(0) - 1
                Dim code = sources(n, 0)
                Dim table = sources(n, 1)
                unions.Add("SELECT '" & code & "' AS JournalCode,h.IdNo AS JournalIdNo,i.IdNo AS ItemIdNo,i.Sequence,i.AccountIdNo,h.TransactionDate,CONVERT(nvarchar(100),h.ReferenceNo) COLLATE DATABASE_DEFAULT AS ReferenceNo,CONVERT(nvarchar(max),i.Notes) COLLATE DATABASE_DEFAULT AS Notes,h.Posted AS HeaderPosted,i.Posted AS ItemPosted," & If(code = "GJ", "h.ClosingJournal", "CAST(0 AS bit)") & " AS ClosingJournal,i.Debit,i.Credit FROM dbo." & table & " h INNER JOIN dbo." & table & "Item i ON i.JournalIdNo=h.IdNo WHERE h.Cancelled=0 AND h.TransactionDate>=@YearStart AND h.TransactionDate<@EndExclusive")
            Next
            Dim sql = ";WITH M AS (" & String.Join(" UNION ALL ", unions) & ") SELECT a.IdNo,a.ParentIdNo,a.AccountCode,a.AccountName,a.AccountNameAra,a.AccountGroup,a.SpecialAccount,a.Active,ab.Debit AS SnapshotDebit,ab.Credit AS SnapshotCredit,m.JournalCode,m.JournalIdNo,m.ItemIdNo,m.Sequence,m.TransactionDate,m.ReferenceNo,m.Notes,m.HeaderPosted,m.ItemPosted,m.ClosingJournal,m.Debit,m.Credit FROM dbo.Account a LEFT JOIN dbo.AccountBalance ab ON ab.AccountIdNo=a.IdNo AND ab.[Year]=@SnapshotYear LEFT JOIN M m ON m.AccountIdNo=a.IdNo ORDER BY a.AccountCode,m.TransactionDate,m.JournalCode,m.JournalIdNo,m.ItemIdNo"
            Return _db.ExecuteReader(sql, {"@YearStart", New Date(beginningDate.Year, 1, 1), "@EndExclusive", endingDate.AddDays(1), "@SnapshotYear", beginningDate.Year})
        End Function

        Public Function GetTransaction(journalCode As String, journalIdNo As Integer, itemIdNo As Integer) As DataTable Implements ICashFlowDao.GetTransaction
            Return New CashPositionDao().GetTransaction(journalCode, journalIdNo, itemIdNo)
        End Function
    End Class
End Namespace
