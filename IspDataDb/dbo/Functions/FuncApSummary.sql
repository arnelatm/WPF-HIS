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
           TransactionType
    FROM dbo.ApStatement_View
    WHERE SpecialAccount IN ('AP', 'AS', 'PD')
      AND TransactionDate >= @BeginningDate
      AND TransactionDate <= @EndingDate
    GROUP BY SupplierIdNo, TransactionType

    UNION

    SELECT SupplierIdNo,
           SUM(Debit - Credit),
           'S'
    FROM dbo.ApStatement_View
    WHERE SpecialAccount = 'PD'
      AND TransactionDate >= @BeginningDate
      AND TransactionDate <= @EndingDate
    GROUP BY SupplierIdNo, TransactionType

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
