CREATE VIEW [dbo].[ApStatement_View]
AS
WITH FirstRecord AS
(
    SELECT LastPostingDate AS FirstRecordDate
    FROM dbo.LastPosting
    WHERE TransactionName = 'Oldest Record'
), Activity AS
(
    SELECT l.JournalCode, l.IdNo, l.Sequence, l.JournalIdNo, l.AccountIdNo,
           l.Debit, l.Credit, l.RevCostCenterIdNo, l.Notes, l.Posted,
           l.PayeeCSEIdNo AS SupplierIdNo, l.InvoiceNo, l.TransactionDate,
           l.ReferenceNo, l.TransactionType, a.SpecialAccount, l.MainNote,
           CASE WHEN a.SpecialAccount = 'PD' THEN 1 ELSE 0 END AS PurchaseDiscount
    FROM dbo.JournalItemPayeeLedger_View AS l
    INNER JOIN dbo.Account AS a ON a.IdNo = l.AccountIdNo
    WHERE l.ExpectedPayeeType = 'S'
      AND l.PayeeCSEIdNo IS NOT NULL
      AND a.SpecialAccount IN ('AP', 'AS', 'PD')
)
SELECT JournalCode, IdNo, Sequence, JournalIdNo, AccountIdNo, Debit, Credit,
       RevCostCenterIdNo, Notes, Posted, SupplierIdNo, InvoiceNo,
       TransactionDate, ReferenceNo, TransactionType, SpecialAccount, MainNote,
       PurchaseDiscount
FROM Activity

UNION ALL

SELECT 'BB', s.IdNo, 1, s.IdNo,
       (SELECT AccountIdNo FROM dbo.DefaultAccounts WHERE SpecialAccount = 'AP'),
       CASE WHEN s.OpeningBalance < 0 THEN s.OpeningBalance * -1 ELSE 0 END,
       CASE WHEN s.OpeningBalance >= 0 THEN s.OpeningBalance ELSE 0 END,
       0, 'Beginning Balance', 1, s.IdNo, 'Beg.Bal.',
       (SELECT FirstRecordDate FROM FirstRecord), 'Beg.Bal.', 'B', 'AP',
       'Beginning Balance', 0
FROM dbo.Supplier AS s;

GO

EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ApStatement_View';

GO
