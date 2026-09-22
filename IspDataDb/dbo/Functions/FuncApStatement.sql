CREATE FUNCTION [dbo].[FuncApStatement]
(
    @SupplierIdNo INT,
    @BeginningDate DATE,
    @EndingDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT 0 AS Discount, JournalCode, JournalIdNo,
           Credit - Debit AS Amount, Notes, SupplierIdNo,
           InvoiceNo, TransactionDate, ReferenceNo, TransactionType, MainNote
    FROM dbo.ApStatement_View
    WHERE SpecialAccount IN ('AP', 'AS', 'PD')
      AND SupplierIdNo = @SupplierIdNo
      AND TransactionDate >= @BeginningDate
      AND TransactionDate <= @EndingDate

    UNION ALL

    SELECT 1, JournalCode, JournalIdNo,
           Debit - Credit, Notes, SupplierIdNo,
           InvoiceNo, TransactionDate, ReferenceNo, TransactionType, MainNote
    FROM dbo.ApStatement_View
    WHERE SpecialAccount = 'PD'
      AND SupplierIdNo = @SupplierIdNo
      AND TransactionDate >= @BeginningDate
      AND TransactionDate <= @EndingDate

    UNION ALL

    SELECT 0, 'BB', 0,
           ISNULL((SELECT SUM(Credit - Debit)
                   FROM dbo.ApStatement_View
                   WHERE SupplierIdNo = @SupplierIdNo
                     AND TransactionDate < @BeginningDate
                     AND SpecialAccount = 'AP'), 0),
           'Beginning Balance', @SupplierIdNo, '', DATEADD(DAY, -1, @BeginningDate),
           '', 'B', 'Beginning Balance'
);
