CREATE FUNCTION [dbo].[FuncArStatement]
(
    @CustomerIdNo INT,
    @BeginningDate DATE,
    @EndingDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT 0 AS Discount, JournalCode, JournalIdNo,
           Debit - Credit AS Amount, Notes, CustomerIdNo,
           InvoiceNo, TransactionDate, ReferenceNo, TransactionType, MainNote
    FROM dbo.ArStatement_View
    WHERE SpecialAccount IN ('AR', 'CA', 'SD')
      AND CustomerIdNo = @CustomerIdNo
      AND TransactionDate >= @BeginningDate
      AND TransactionDate <= @EndingDate

    UNION ALL

    SELECT 1, JournalCode, JournalIdNo,
           Credit - Debit, Notes, CustomerIdNo,
           InvoiceNo, TransactionDate, ReferenceNo, TransactionType, MainNote
    FROM dbo.ArStatement_View
    WHERE SpecialAccount = 'SD'
      AND CustomerIdNo = @CustomerIdNo
      AND TransactionDate >= @BeginningDate
      AND TransactionDate <= @EndingDate

    UNION ALL

    SELECT 0, 'BB', 0,
           ISNULL((SELECT SUM(Debit - Credit)
                   FROM dbo.ArStatement_View
                   WHERE CustomerIdNo = @CustomerIdNo
                     AND TransactionDate < @BeginningDate), 0),
           'Beginning Balance', @CustomerIdNo, '', DATEADD(DAY, -1, @BeginningDate),
           '', 'B', 'Beginning Balance'
);
