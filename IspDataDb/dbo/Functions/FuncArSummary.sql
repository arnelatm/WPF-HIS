CREATE FUNCTION [dbo].[FuncArSummary]
(
    @BeginningDate DATE,
    @EndingDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT CustomerIdNo,
           SUM(Debit - Credit) AS Amount,
           TransactionType
    FROM dbo.ArStatement_View
    WHERE SpecialAccount IN ('AR', 'CA', 'SD')
      AND TransactionDate >= @BeginningDate
      AND TransactionDate <= @EndingDate
    GROUP BY CustomerIdNo, TransactionType

    UNION

    SELECT CustomerIdNo,
           SUM(Credit - Debit),
           TransactionType
    FROM dbo.ArStatement_View
    WHERE SpecialAccount = 'SD'
      AND TransactionDate >= @BeginningDate
      AND TransactionDate <= @EndingDate
    GROUP BY CustomerIdNo, TransactionType

    UNION

    SELECT c.IdNo,
           ISNULL(SUM(v.Debit - v.Credit), 0),
           'B'
    FROM dbo.Customer AS c
    LEFT JOIN dbo.ArStatement_View AS v
        ON v.CustomerIdNo = c.IdNo
       AND v.TransactionDate < @BeginningDate
    GROUP BY c.IdNo
);
