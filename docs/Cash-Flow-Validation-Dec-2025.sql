-- Cash-flow discovery for 1-31 December 2025. NOT a deployment script.
-- Executed read-only on 8 September 2026 against the owner-confirmed
-- ISPADMIN2 / ISPDATA test copy. See the companion validation notes for findings.
-- Run only after the restored test server/database and read access are authorized.
-- SELECT-only diagnostics: no procedures, permanent objects, or data changes.
-- Tags identify candidates, not an approved cash scope. Owner confirmed SAR.
SET NOCOUNT ON;
DECLARE @PeriodStart date = '20251201';
DECLARE @PeriodEndExclusive date = '20260101';

-- 1. Capture the selected environment and current close boundaries.
SELECT CONVERT(nvarchar(128), SERVERPROPERTY('ServerName')) AS ServerName,
       DB_NAME() AS DatabaseName, @PeriodStart AS PeriodStart,
       @PeriodEndExclusive AS PeriodEndExclusive;
SELECT TransactionName, LastPostingDate, LastPostingDateOld
FROM dbo.LastPosting ORDER BY TransactionName;

-- 2. Review ALL accounts so missing/incorrect special-account tags can be found.
-- Keep inactive accounts and omit bank numbers/IBANs from the output.
SELECT a.IdNo, a.AccountCode, a.AccountName, a.AccountNameAra,
       a.SpecialAccount, a.DetailAccount, a.Active, a.WithReconciliation,
       CASE WHEN a.SpecialAccount IN ('BA','CS','CK','PC') THEN 1 ELSE 0 END AS TaggedCashCandidate,
       (SELECT COUNT(*) FROM dbo.BankAccount b WHERE b.AccountIdNo = a.IdNo) AS BankLinks
FROM dbo.Account a ORDER BY a.AccountCode;

-- 3. Inspect snapshots; do not silently choose the latest year for a past report.
-- Current fiscal close code treats Year=2025 as 2025 opening, and writes 2026
-- opening after closing 2025. Historical data must confirm this convention.
SELECT [Year], COUNT(*) AS SnapshotRows,
       SUM(CONVERT(decimal(19,4), ISNULL(Debit,0))) AS Debit,
       SUM(CONVERT(decimal(19,4), ISNULL(Credit,0))) AS Credit
FROM dbo.AccountBalance GROUP BY [Year] ORDER BY [Year];
SELECT ab.[Year], ab.AccountIdNo, a.AccountCode, a.AccountName,
       ab.Debit, ab.Credit
FROM dbo.AccountBalance ab LEFT JOIN dbo.Account a ON a.IdNo = ab.AccountIdNo
WHERE ab.[Year] IN (2025,2026)
  AND (a.SpecialAccount IN ('BA','CS','CK','PC') OR a.IdNo IS NULL)
ORDER BY ab.AccountIdNo, ab.[Year];

-- 4. Compare raw header/detail states, retaining cancelled and unknown states.
-- No amount is automatically classified or excluded based on a guessed policy.
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
SELECT h.JournalCode, h.IdNo AS JournalIdNo, h.TransactionDate,
       h.Posted AS HeaderPosted, h.Cancelled, h.ClosingJournal,
       COUNT(i.IdNo) AS ItemCount,
       SUM(CASE WHEN i.IdNo IS NOT NULL AND
           (h.Posted IS NULL OR i.Posted IS NULL OR h.Posted <> i.Posted) THEN 1 ELSE 0 END) AS PostingReviewItems,
       SUM(CASE WHEN i.IdNo IS NOT NULL AND
           (a.IdNo IS NULL OR i.Debit IS NULL OR i.Credit IS NULL OR
            i.Debit < 0 OR i.Credit < 0 OR (i.Debit <> 0 AND i.Credit <> 0)) THEN 1 ELSE 0 END) AS InvalidItems,
       SUM(CONVERT(decimal(19,4),i.Debit)) AS JournalDebit,
       SUM(CONVERT(decimal(19,4),i.Credit)) AS JournalCredit,
       SUM(CONVERT(decimal(19,4),i.Debit) - CONVERT(decimal(19,4),i.Credit)) AS JournalDifference,
       SUM(CASE WHEN a.SpecialAccount IN ('BA','CS','CK','PC') THEN 1 ELSE 0 END) AS TaggedCashLines,
       SUM(CASE WHEN a.SpecialAccount IN ('BA','CS','CK','PC') THEN CONVERT(decimal(19,4),i.Debit) ELSE 0 END) AS TaggedCashDebit,
       SUM(CASE WHEN a.SpecialAccount IN ('BA','CS','CK','PC') THEN CONVERT(decimal(19,4),i.Credit) ELSE 0 END) AS TaggedCashCredit
FROM Headers h
LEFT JOIN Items i ON i.JournalCode = h.JournalCode AND i.JournalIdNo = h.IdNo
LEFT JOIN dbo.Account a ON a.IdNo = i.AccountIdNo
WHERE h.TransactionDate >= @PeriodStart AND h.TransactionDate < @PeriodEndExclusive
GROUP BY h.JournalCode, h.IdNo, h.TransactionDate, h.Posted, h.Cancelled, h.ClosingJournal
ORDER BY h.JournalCode, h.IdNo;

-- 5. Candidate cash detail and all counterparts for transfer/mixed-purpose review.
-- This view excludes Cancelled<>0 and NULL cancellation states, but not unposted.
-- This is a diagnostic listing; do not sum counterpart amounts as cash movements.
-- Both cash debit and credit in a journal suggest review, not a proven transfer.
;WITH CashDocuments AS (
    SELECT DISTINCT gl.JournalCode, gl.JournalIdNo
    FROM dbo.GlLedgers_View gl INNER JOIN dbo.Account a ON a.IdNo = gl.AccountIdNo
    WHERE a.SpecialAccount IN ('BA','CS','CK','PC')
      AND gl.TransactionDate >= @PeriodStart AND gl.TransactionDate < @PeriodEndExclusive
)
SELECT gl.JournalCode, gl.JournalIdNo, gl.IdNo AS ItemIdNo,
       gl.TransactionDate, gl.AccountIdNo, a.AccountCode, a.AccountName,
       gl.Posted AS ItemPosted, gl.ClosingJournal, gl.Debit, gl.Credit,
       CASE WHEN a.SpecialAccount IN ('BA','CS','CK','PC') THEN 1 ELSE 0 END AS TaggedCashCandidate,
       COUNT(*) OVER (PARTITION BY gl.JournalCode, gl.JournalIdNo, gl.IdNo) AS SourceIdentityRows
FROM dbo.GlLedgers_View gl
INNER JOIN CashDocuments d ON d.JournalCode = gl.JournalCode AND d.JournalIdNo = gl.JournalIdNo
LEFT JOIN dbo.Account a ON a.IdNo = gl.AccountIdNo
ORDER BY gl.JournalCode, gl.JournalIdNo, gl.IdNo;
