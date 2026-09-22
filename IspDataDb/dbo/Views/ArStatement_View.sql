CREATE VIEW [dbo].[ArStatement_View]
AS
WITH FirstRecord AS
(
    SELECT LastPostingDate AS FirstRecordDate
    FROM dbo.LastPosting
    WHERE TransactionName = 'First Record'
), Activity AS
(
    SELECT l.JournalCode, l.IdNo, l.Sequence, l.JournalIdNo, l.AccountIdNo,
           l.Debit, l.Credit, l.RevCostCenterIdNo, l.Notes, l.Posted,
           l.PayeeCSEIdNo AS CustomerIdNo, l.InvoiceNo, l.TransactionDate,
           l.ReferenceNo, l.TransactionType, a.SpecialAccount, l.MainNote,
           c.CustomerCode, c.CustomerName, c.CustomerNameAra
    FROM dbo.JournalItemPayeeLedger_View AS l
    INNER JOIN dbo.Account AS a ON a.IdNo = l.AccountIdNo
    INNER JOIN dbo.Customer AS c ON c.IdNo = l.PayeeCSEIdNo
    WHERE l.ExpectedPayeeType = 'C'
      AND a.SpecialAccount IN ('AR', 'CA', 'SD')
)
SELECT JournalCode, IdNo, Sequence, JournalIdNo, AccountIdNo, Debit, Credit,
       RevCostCenterIdNo, Notes, Posted, CustomerIdNo, InvoiceNo,
       TransactionDate, ReferenceNo, TransactionType, SpecialAccount, MainNote,
       CustomerCode, CustomerName, CustomerNameAra
FROM Activity

UNION ALL

SELECT 'BB', c.IdNo, 1, c.IdNo,
       (SELECT AccountIdNo FROM dbo.DefaultAccounts WHERE SpecialAccount = 'AR'),
       CASE WHEN c.OpeningBalance >= 0 THEN c.OpeningBalance ELSE 0 END,
       CASE WHEN c.OpeningBalance < 0 THEN c.OpeningBalance * -1 ELSE 0 END,
       0, 'Beginning Balance', 1, c.IdNo, 'Beg.Bal.',
       (SELECT FirstRecordDate FROM FirstRecord), 'Beg.Bal.', 'B', 'AR',
       'Beginning Balance', c.CustomerCode, c.CustomerName, c.CustomerNameAra
FROM dbo.Customer AS c;

GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ArStatement_View';

GO
