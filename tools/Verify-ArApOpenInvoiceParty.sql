-- Read-only verification after deploying the focused fix to a restored ISPDATA.
SET NOCOUNT ON;

IF dbo.FnResolveOpenInvoiceParty(1095, 'C', 373) <> 373
   OR dbo.FnResolveOpenInvoiceParty(1095, 'C', 373) IS NULL
    THROW 51900, 'AR first-line customer resolution failed.', 1;
IF dbo.FnResolveOpenInvoiceParty(2107, 'C', 373) <> 1381
   OR dbo.FnResolveOpenInvoiceParty(2107, 'C', 373) IS NULL
    THROW 51901, 'AR second-line customer must override the header.', 1;
IF dbo.FnResolveOpenInvoiceParty(2107, 'S', 373) IS NOT NULL
    THROW 51902, 'Wrong contact type must not fall back to the header.', 1;
IF dbo.FnResolveOpenInvoiceParty(2147483647, 'C', 373) IS NOT NULL
    THROW 51903, 'An unresolved selected contact must not fall back to the header.', 1;
IF ISNULL(dbo.FnResolveOpenInvoiceParty(NULL, 'C', 373), 0) <> 373
   OR ISNULL(dbo.FnResolveOpenInvoiceParty(0, 'C', 373), 0) <> 373
    THROW 51904, 'Missing historical contacts must retain valid header fallback.', 1;

IF (SELECT COUNT(*) FROM dbo.ArOpenInvoice WHERE JournalCode = 'AR' AND JournalIdNo = 11198) <> 2
    THROW 51905, 'AR 11198 must retain its two existing open items.', 1;
IF NOT EXISTS (SELECT 1 FROM dbo.ArOpenInvoice_View
               WHERE IdNo = 2820 AND JournalCode = 'AR' AND JournalIdNo = 11198
                 AND JournalItemIdNo = 10209 AND CustomerIdNo = 373 AND Amount = 51.75 AND Balance = 51.75)
   OR NOT EXISTS (SELECT 1 FROM dbo.ArOpenInvoice_View
                  WHERE IdNo = 2821 AND JournalCode = 'AR' AND JournalIdNo = 11198
                    AND JournalItemIdNo = 10210 AND CustomerIdNo = 1381 AND Amount = -51.75 AND Balance = -51.75)
    THROW 51906, 'AR 11198 open-item ownership or balances are incorrect.', 1;
IF EXISTS (
    SELECT 1 FROM dbo.ArOpenInvoice_View o
    LEFT JOIN dbo.ArStatement_View s ON s.JournalCode = 'AR'
        AND s.JournalIdNo = o.JournalIdNo AND s.IdNo = o.JournalItemIdNo
    WHERE o.JournalCode = 'AR' AND o.JournalIdNo = 11198
      AND (s.IdNo IS NULL OR s.CustomerIdNo <> o.CustomerIdNo
           OR s.Debit - s.Credit <> o.Amount))
    THROW 51907, 'AR statement and open items disagree.', 1;

DECLARE @SupplierContact int, @SupplierId int;
SELECT TOP (1) @SupplierContact = ct.IdNo, @SupplierId = s.IdNo
FROM dbo.Contact ct INNER JOIN dbo.Supplier s ON s.IdNo = ct.CSEIdNo
WHERE ct.CSECode = 'S' ORDER BY ct.IdNo;
IF @SupplierContact IS NULL
    THROW 51908, 'A valid supplier contact is required for the AP resolution test.', 1;
IF ISNULL(dbo.FnResolveOpenInvoiceParty(@SupplierContact, 'S', NULL), 0) <> @SupplierId
   OR dbo.FnResolveOpenInvoiceParty(@SupplierContact, 'C', 373) IS NOT NULL
   OR ISNULL(dbo.FnResolveOpenInvoiceParty(0, 'S', @SupplierId), 0) <> @SupplierId
    THROW 51909, 'AP supplier resolution, type checking, or fallback failed.', 1;

SELECT IdNo, JournalItemIdNo, CustomerIdNo, Amount, PaidAmount, DiscountTaken, Balance
FROM dbo.ArOpenInvoice_View WHERE JournalCode = 'AR' AND JournalIdNo = 11198;
PRINT 'Read-only AR/AP open-item resolution checks passed.';
