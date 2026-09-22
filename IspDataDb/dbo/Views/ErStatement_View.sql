CREATE VIEW [dbo].[ErStatement_View]
AS
WITH FirstRecord AS
(
    SELECT LastPostingDate AS FirstRecordDate
    FROM dbo.LastPosting
    WHERE TransactionName = 'First ER Date'
), Activity AS
(
    SELECT l.JournalCode, l.IdNo, l.Sequence, l.JournalIdNo, l.AccountIdNo,
           l.Debit, l.Credit, l.RevCostCenterIdNo, l.Notes, l.Posted,
           l.PayeeCSEIdNo AS EmployeeIdNo, l.InvoiceNo, l.TransactionDate,
           l.ReferenceNo, l.TransactionType, a.SpecialAccount, l.MainNote
    FROM dbo.JournalItemPayeeLedger_View AS l
    INNER JOIN dbo.Account AS a ON a.IdNo = l.AccountIdNo
    WHERE l.ExpectedPayeeType = 'E'
      AND l.PayeeCSEIdNo IS NOT NULL
      AND a.SpecialAccount = 'EL'
)
SELECT JournalCode, IdNo, Sequence, JournalIdNo, AccountIdNo, Debit, Credit,
       RevCostCenterIdNo, Notes, Posted, EmployeeIdNo, InvoiceNo,
       TransactionDate, ReferenceNo, TransactionType, SpecialAccount, MainNote
FROM Activity

UNION ALL

SELECT 'BB', e.IdNo, 1, e.IdNo,
       (SELECT AccountIdNo FROM dbo.DefaultAccounts WHERE SpecialAccount = 'EL'),
       CASE WHEN e.OpeningBalance >= 0 THEN e.OpeningBalance ELSE 0 END,
       CASE WHEN e.OpeningBalance < 0 THEN e.OpeningBalance * -1 ELSE 0 END,
       0, 'Beginning Balance', 1, e.IdNo, 'Beg.Bal.',
       (SELECT FirstRecordDate FROM FirstRecord), 'Beg.Bal.',
       CASE WHEN e.OpeningBalance >= 0 THEN 'D' ELSE 'C' END,
       'EL', 'Beginning Balance'
FROM dbo.Employee AS e;

GO
