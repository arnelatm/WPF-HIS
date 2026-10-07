CREATE FUNCTION [dbo].[FuncApStatement]
(
    @SupplierIdNo INT,
    @BeginningDate DATE,
    @EndingDate DATE,
    @IncludeUnposted BIT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 0 AS Discount, JournalCode, JournalIdNo,
           Credit - Debit AS Amount, Notes, SupplierIdNo,
           InvoiceNo, TransactionDate, ReferenceNo, TransactionType, MainNote, Posted
    FROM dbo.ApStatement_View
    WHERE SpecialAccount IN ('AP', 'AS')
      AND SupplierIdNo = @SupplierIdNo
      AND TransactionDate >= @BeginningDate
      AND TransactionDate <= @EndingDate
      AND (TransactionType = 'B' OR @IncludeUnposted = 1 OR ISNULL(Posted, 0) = 1)

    UNION ALL

    SELECT 0, 'BB', 0,
           ISNULL((SELECT SUM(Credit - Debit)
                   FROM dbo.ApStatement_View
                   WHERE SupplierIdNo = @SupplierIdNo
                     AND TransactionDate < @BeginningDate
                     AND SpecialAccount IN ('AP', 'AS')
                     AND (TransactionType = 'B' OR @IncludeUnposted = 1 OR ISNULL(Posted, 0) = 1)), 0),
           'Beginning Balance', @SupplierIdNo, '', DATEADD(DAY, -1, @BeginningDate),
           '', 'B', 'Beginning Balance', CAST(1 AS BIT)
);
