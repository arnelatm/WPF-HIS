CREATE FUNCTION [dbo].[FuncArStatement]
(
    @CustomerIdNo INT,
    @BeginningDate DATE,
    @EndingDate DATE,
    @IncludeUnposted BIT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 0 AS Discount, JournalCode, JournalIdNo,
           Debit - Credit AS Amount, Notes, CustomerIdNo,
           InvoiceNo, TransactionDate, ReferenceNo, TransactionType, MainNote
    FROM dbo.ArStatement_View
    WHERE SpecialAccount IN ('AR', 'CA')
      AND CustomerIdNo = @CustomerIdNo
      AND TransactionDate >= @BeginningDate
      AND TransactionDate <= @EndingDate
      AND (TransactionType = 'B' OR @IncludeUnposted = 1 OR ISNULL(Posted, 0) = 1)

    UNION ALL

    SELECT 0, 'BB', 0,
           ISNULL((SELECT SUM(Debit - Credit)
                   FROM dbo.ArStatement_View
                   WHERE CustomerIdNo = @CustomerIdNo
                     AND TransactionDate < @BeginningDate
                     AND (TransactionType = 'B' OR @IncludeUnposted = 1 OR ISNULL(Posted, 0) = 1)), 0),
           'Beginning Balance', @CustomerIdNo, '', DATEADD(DAY, -1, @BeginningDate),
           '', 'B', 'Beginning Balance'
);
