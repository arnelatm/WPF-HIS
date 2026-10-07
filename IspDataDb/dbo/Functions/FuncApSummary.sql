CREATE FUNCTION [dbo].[FuncApSummary]
(
    @BeginningDate DATE,
    @EndingDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT SupplierIdNo,
           SUM(Credit - Debit) AS Amount,
           CASE WHEN TransactionType = 'A' THEN 'P' ELSE TransactionType END AS TransactionType
    FROM dbo.ApStatement_View
    WHERE SpecialAccount IN ('AP', 'AS')
      AND TransactionDate >= @BeginningDate
      AND TransactionDate <= @EndingDate
    GROUP BY SupplierIdNo, CASE WHEN TransactionType = 'A' THEN 'P' ELSE TransactionType END

    UNION

    SELECT s.IdNo,
           ISNULL(SUM(v.Credit - v.Debit), 0),
           'B'
    FROM dbo.Supplier AS s
    LEFT JOIN dbo.ApStatement_View AS v
        ON v.SupplierIdNo = s.IdNo
       AND v.TransactionDate < @BeginningDate
       AND v.SpecialAccount IN ('AP', 'AS')
    GROUP BY s.IdNo
);
