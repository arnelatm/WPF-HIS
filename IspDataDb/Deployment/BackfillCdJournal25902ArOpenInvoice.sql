-- Run only after deploying the updated ARDetails_View to a restored test database.
-- Verify the journal identity and customer contact before applying to the intended server.
SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF (
    SELECT COUNT(*)
    FROM dbo.CdJournal AS h
    INNER JOIN dbo.CdJournalItem AS i ON i.JournalIdNo = h.IdNo
    INNER JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
    WHERE h.IdNo = 25902 AND h.ReferenceNo = '10-002' AND h.PaymentType = 'O'
      AND h.Cancelled = 0 AND i.Sequence = 3 AND i.Debit = 100 AND i.Credit = 0
      AND a.SpecialAccount = 'AR'
      AND dbo.FnResolveOpenInvoiceParty(i.PayIdNo, 'C', NULL) IS NOT NULL
 ) <> 1
    THROW 51300, 'CD 25902 line 3 does not match the expected customer receivable.', 1;

INSERT dbo.ArOpenInvoice (JournalCode, JournalIdNo, JournalItemIdNo)
SELECT 'CD', h.IdNo, i.IdNo
FROM dbo.CdJournal AS h
INNER JOIN dbo.CdJournalItem AS i ON i.JournalIdNo = h.IdNo
INNER JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
WHERE h.IdNo = 25902 AND h.ReferenceNo = '10-002' AND h.PaymentType = 'O'
  AND h.Cancelled = 0 AND i.Sequence = 3 AND i.Debit = 100 AND i.Credit = 0
  AND a.SpecialAccount = 'AR'
  AND dbo.FnResolveOpenInvoiceParty(i.PayIdNo, 'C', NULL) IS NOT NULL
  AND NOT EXISTS (
      SELECT 1 FROM dbo.ArOpenInvoice AS o WITH (UPDLOCK, HOLDLOCK)
      WHERE o.JournalCode = 'CD' AND o.JournalIdNo = h.IdNo AND o.JournalItemIdNo = i.IdNo
  );

COMMIT TRANSACTION;
