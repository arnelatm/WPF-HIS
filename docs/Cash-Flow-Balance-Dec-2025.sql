-- Read-only follow-up for the authorized ISPADMIN2 / ISPDATA test copy.
-- Checks all 2025 lines plus undated/orphan rows (which cannot be date-scoped).
-- Owner-selected initial basis includes posted and unposted, with Cancelled=0.
-- Set @PostedOnly=1 only to compare with the earlier posted-only diagnostic.
-- Missing snapshot rows are tentatively zero and explicitly flagged, not approved.
-- Debits/credits include transfers; these are NOT external cash-flow totals.
-- Full cash-account scope remains subject to owner confirmation. Currency is SAR.
SET NOCOUNT ON;
DECLARE @PostedOnly bit = 0;
;WITH Headers AS (
    SELECT 'GJ' AS JournalCode, IdNo, TransactionDate, Posted, Cancelled, ClosingJournal FROM dbo.GeneralJournal
    UNION ALL SELECT 'AP', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.ApJournal
    UNION ALL SELECT 'AR', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.ArJournal
    UNION ALL SELECT 'ER', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.ErJournal
    UNION ALL SELECT 'CK', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.CkJournal
    UNION ALL SELECT 'CD', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.CdJournal
    UNION ALL SELECT 'CR', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.CashReceiptJournal
    UNION ALL SELECT 'PC', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.PcJournal
    UNION ALL SELECT 'SJ', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.SalesJournal
), Items AS (
    SELECT 'GJ' AS JournalCode, IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.GeneralJournalItem
    UNION ALL SELECT 'AP', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.ApJournalItem
    UNION ALL SELECT 'AR', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.ArJournalItem
    UNION ALL SELECT 'ER', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.ErJournalItem
    UNION ALL SELECT 'CK', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.CkJournalItem
    UNION ALL SELECT 'CD', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.CdJournalItem
    UNION ALL SELECT 'CR', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.CashReceiptJournalItem
    UNION ALL SELECT 'PC', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.PcJournalItem
    UNION ALL SELECT 'SJ', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.SalesJournalItem
)
SELECT COALESCE(h.JournalCode,i.JournalCode) AS JournalCode,
       COUNT(i.IdNo) AS Items,
       SUM(CASE WHEN h.IdNo IS NULL THEN 1 ELSE 0 END) AS OrphanItems,
       SUM(CASE WHEN h.IdNo IS NOT NULL AND h.TransactionDate IS NULL THEN 1 ELSE 0 END) AS UndatedRows,
       SUM(CASE WHEN i.IdNo IS NULL THEN 1 ELSE 0 END) AS EmptyHeaders,
       SUM(CASE WHEN h.Posted IS NULL OR i.Posted IS NULL OR h.Posted<>i.Posted THEN 1 ELSE 0 END) AS PostingReviewRows,
       SUM(CASE WHEN h.Cancelled IS NULL OR h.Cancelled<>0 THEN 1 ELSE 0 END) AS CancellationReviewRows,
       SUM(CASE WHEN h.Posted<>1 OR i.Posted<>1 THEN 1 ELSE 0 END) AS UnpostedRows,
       SUM(CASE WHEN i.IdNo IS NOT NULL AND (a.IdNo IS NULL OR i.Debit IS NULL OR i.Credit IS NULL OR i.Debit<0 OR i.Credit<0 OR (i.Debit<>0 AND i.Credit<>0)) THEN 1 ELSE 0 END) AS InvalidItems,
       SUM(CASE WHEN h.ClosingJournal=1 AND a.SpecialAccount IN ('BA','CS','CK','PC') THEN 1 ELSE 0 END) AS CashClosingLines
FROM Headers h FULL OUTER JOIN Items i ON i.JournalCode=h.JournalCode AND i.JournalIdNo=h.IdNo
LEFT JOIN dbo.Account a ON a.IdNo=i.AccountIdNo
WHERE (h.TransactionDate>='20250101' AND h.TransactionDate<'20260101') OR h.TransactionDate IS NULL
GROUP BY COALESCE(h.JournalCode,i.JournalCode)
ORDER BY JournalCode;
;WITH Headers AS (
    SELECT 'GJ' AS JournalCode, IdNo, TransactionDate, Posted, Cancelled, ClosingJournal FROM dbo.GeneralJournal
    UNION ALL SELECT 'AP', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.ApJournal
    UNION ALL SELECT 'AR', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.ArJournal
    UNION ALL SELECT 'ER', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.ErJournal
    UNION ALL SELECT 'CK', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.CkJournal
    UNION ALL SELECT 'CD', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.CdJournal
    UNION ALL SELECT 'CR', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.CashReceiptJournal
    UNION ALL SELECT 'PC', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.PcJournal
    UNION ALL SELECT 'SJ', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.SalesJournal
), Items AS (
    SELECT 'GJ' AS JournalCode, IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.GeneralJournalItem
    UNION ALL SELECT 'AP', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.ApJournalItem
    UNION ALL SELECT 'AR', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.ArJournalItem
    UNION ALL SELECT 'ER', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.ErJournalItem
    UNION ALL SELECT 'CK', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.CkJournalItem
    UNION ALL SELECT 'CD', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.CdJournalItem
    UNION ALL SELECT 'CR', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.CashReceiptJournalItem
    UNION ALL SELECT 'PC', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.PcJournalItem
    UNION ALL SELECT 'SJ', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.SalesJournalItem
)
, Movement AS (
    SELECT i.AccountIdNo,
           SUM(CASE WHEN h.TransactionDate<'20251201' THEN CONVERT(decimal(19,4),i.Debit)-CONVERT(decimal(19,4),i.Credit) ELSE 0 END) AS BeforeDecember,
           SUM(CASE WHEN h.TransactionDate>='20251201' THEN CONVERT(decimal(19,4),i.Debit) ELSE 0 END) AS DecemberDebit,
           SUM(CASE WHEN h.TransactionDate>='20251201' THEN CONVERT(decimal(19,4),i.Credit) ELSE 0 END) AS DecemberCredit,
           SUM(CASE WHEN h.TransactionDate>='20251201' THEN 1 ELSE 0 END) AS DecemberLines
    FROM Headers h INNER JOIN Items i ON i.JournalCode=h.JournalCode AND i.JournalIdNo=h.IdNo
    WHERE h.TransactionDate>='20250101' AND h.TransactionDate<'20260101'
      AND h.Cancelled=0 AND (@PostedOnly=0 OR (h.Posted=1 AND i.Posted=1))
    GROUP BY i.AccountIdNo
)
SELECT a.IdNo, a.AccountCode, a.AccountName, a.Active,
       CASE WHEN @PostedOnly=1 THEN 'Posted only' ELSE 'Posted and unposted' END AS ReportingBasis,
       CASE WHEN ab.IdNo IS NULL THEN 0 ELSE 1 END AS Has2025Snapshot,
       CASE WHEN nx.IdNo IS NULL THEN 0 ELSE 1 END AS Has2026Snapshot,
       CONVERT(decimal(19,4),ISNULL(ab.Debit,0)-ISNULL(ab.Credit,0))+ISNULL(m.BeforeDecember,0) AS DecemberOpening,
       ISNULL(m.DecemberDebit,0) AS DecemberDebit,
       ISNULL(m.DecemberCredit,0) AS DecemberCredit,
       CONVERT(decimal(19,4),ISNULL(ab.Debit,0)-ISNULL(ab.Credit,0))+ISNULL(m.BeforeDecember,0)+ISNULL(m.DecemberDebit,0)-ISNULL(m.DecemberCredit,0) AS DecemberClosing,
       CONVERT(decimal(19,4),ISNULL(nx.Debit,0)-ISNULL(nx.Credit,0)) AS Opening2026,
       CONVERT(decimal(19,4),ISNULL(ab.Debit,0)-ISNULL(ab.Credit,0))+ISNULL(m.BeforeDecember,0)+ISNULL(m.DecemberDebit,0)-ISNULL(m.DecemberCredit,0)-CONVERT(decimal(19,4),ISNULL(nx.Debit,0)-ISNULL(nx.Credit,0)) AS SnapshotDifference,
       ISNULL(m.DecemberLines,0) AS DecemberLines
FROM dbo.Account a
LEFT JOIN dbo.AccountBalance ab ON ab.AccountIdNo=a.IdNo AND ab.[Year]=2025
LEFT JOIN dbo.AccountBalance nx ON nx.AccountIdNo=a.IdNo AND nx.[Year]=2026
LEFT JOIN Movement m ON m.AccountIdNo=a.IdNo
WHERE a.SpecialAccount IN ('BA','CS','CK','PC')
ORDER BY a.AccountCode;

;WITH Headers AS (
    SELECT 'GJ' AS JournalCode, IdNo, TransactionDate, Posted, Cancelled, ClosingJournal FROM dbo.GeneralJournal
    UNION ALL SELECT 'AP', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.ApJournal
    UNION ALL SELECT 'AR', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.ArJournal
    UNION ALL SELECT 'ER', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.ErJournal
    UNION ALL SELECT 'CK', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.CkJournal
    UNION ALL SELECT 'CD', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.CdJournal
    UNION ALL SELECT 'CR', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.CashReceiptJournal
    UNION ALL SELECT 'PC', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.PcJournal
    UNION ALL SELECT 'SJ', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.SalesJournal
), Items AS (
    SELECT 'GJ' AS JournalCode, IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.GeneralJournalItem
    UNION ALL SELECT 'AP', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.ApJournalItem
    UNION ALL SELECT 'AR', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.ArJournalItem
    UNION ALL SELECT 'ER', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.ErJournalItem
    UNION ALL SELECT 'CK', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.CkJournalItem
    UNION ALL SELECT 'CD', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.CdJournalItem
    UNION ALL SELECT 'CR', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.CashReceiptJournalItem
    UNION ALL SELECT 'PC', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.PcJournalItem
    UNION ALL SELECT 'SJ', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.SalesJournalItem
)
-- Identify orphan, undated and empty rows; orphan dates are unknown, not December.
SELECT COALESCE(h.JournalCode,i.JournalCode) AS JournalCode,
       COALESCE(h.IdNo,i.JournalIdNo) AS JournalIdNo, i.IdNo AS ItemIdNo,
       h.TransactionDate, i.AccountIdNo, a.AccountCode,
       CASE WHEN a.SpecialAccount IN ('BA','CS','CK','PC') THEN 1 ELSE 0 END AS TaggedCashCandidate,
       h.Posted AS HeaderPosted, i.Posted AS ItemPosted, h.Cancelled, i.Debit, i.Credit,
       CASE WHEN h.IdNo IS NULL THEN 'Orphan item' WHEN h.TransactionDate IS NULL THEN 'Undated header' ELSE 'Empty header' END AS ReviewReason
FROM Headers h FULL OUTER JOIN Items i ON i.JournalCode=h.JournalCode AND i.JournalIdNo=h.IdNo
LEFT JOIN dbo.Account a ON a.IdNo=i.AccountIdNo
WHERE h.IdNo IS NULL OR h.TransactionDate IS NULL
   OR (h.TransactionDate>='20250101' AND h.TransactionDate<'20260101' AND i.IdNo IS NULL)
ORDER BY JournalCode, JournalIdNo, ItemIdNo;
;WITH Headers AS (
    SELECT 'GJ' AS JournalCode, IdNo, TransactionDate, Posted, Cancelled, ClosingJournal FROM dbo.GeneralJournal
    UNION ALL SELECT 'AP', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.ApJournal
    UNION ALL SELECT 'AR', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.ArJournal
    UNION ALL SELECT 'ER', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.ErJournal
    UNION ALL SELECT 'CK', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.CkJournal
    UNION ALL SELECT 'CD', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.CdJournal
    UNION ALL SELECT 'CR', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.CashReceiptJournal
    UNION ALL SELECT 'PC', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.PcJournal
    UNION ALL SELECT 'SJ', IdNo, TransactionDate, Posted, Cancelled, CAST(0 AS bit) FROM dbo.SalesJournal
), Items AS (
    SELECT 'GJ' AS JournalCode, IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.GeneralJournalItem
    UNION ALL SELECT 'AP', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.ApJournalItem
    UNION ALL SELECT 'AR', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.ArJournalItem
    UNION ALL SELECT 'ER', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.ErJournalItem
    UNION ALL SELECT 'CK', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.CkJournalItem
    UNION ALL SELECT 'CD', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.CdJournalItem
    UNION ALL SELECT 'CR', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.CashReceiptJournalItem
    UNION ALL SELECT 'PC', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.PcJournalItem
    UNION ALL SELECT 'SJ', IdNo, JournalIdNo, AccountIdNo, Posted, Debit, Credit FROM dbo.SalesJournalItem
)
-- Full-year balance check on all dated source journals, with cancellation exposed.
SELECT h.JournalCode,h.IdNo AS JournalIdNo,h.TransactionDate,h.Cancelled,
       SUM(CONVERT(decimal(19,4),i.Debit)-CONVERT(decimal(19,4),i.Credit)) AS Difference
FROM Headers h INNER JOIN Items i ON i.JournalCode=h.JournalCode AND i.JournalIdNo=h.IdNo
WHERE h.TransactionDate>='20250101' AND h.TransactionDate<'20260101'
GROUP BY h.JournalCode,h.IdNo,h.TransactionDate,h.Cancelled
HAVING SUM(CONVERT(decimal(19,4),i.Debit)-CONVERT(decimal(19,4),i.Credit))<>0
ORDER BY h.JournalCode,h.IdNo;

-- Source identity uniqueness across 2025 in the ledger view.
SELECT JournalCode,JournalIdNo,IdNo,COUNT(*) AS SourceIdentityRows
FROM dbo.GlLedgers_View WHERE TransactionDate>='20250101' AND TransactionDate<'20260101'
GROUP BY JournalCode,JournalIdNo,IdNo HAVING COUNT(*)>1;

-- Imprest movement by month and journal, to understand the negative opening.
SELECT MONTH(TransactionDate) AS MonthNumber, JournalCode,Posted,ClosingJournal,
       COUNT(*) AS Lines,SUM(CONVERT(decimal(19,4),Debit)) AS Debit,
       SUM(CONVERT(decimal(19,4),Credit)) AS Credit
FROM dbo.GlLedgers_View
WHERE AccountIdNo=113 AND TransactionDate>='20250101' AND TransactionDate<'20260101'
GROUP BY MONTH(TransactionDate),JournalCode,Posted,ClosingJournal
ORDER BY MonthNumber,JournalCode;
