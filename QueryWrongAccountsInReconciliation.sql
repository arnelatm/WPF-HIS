SELECT        TOP (200) a.IdNo, a.AccountReconciliationIdNo, a.JournalCode, a.JournalItemIdNo, a.Cleared, a.Sequence, b.AccountIdNo
FROM            AccountReconciliationItem AS a LEFT OUTER JOIN
                         GlLedgers_View AS b ON a.JournalCode = b.JournalCode AND a.JournalItemIdNo = b.IdNo
WHERE        (a.AccountReconciliationIdNo = 27)