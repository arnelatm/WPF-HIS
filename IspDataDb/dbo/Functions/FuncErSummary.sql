CREATE FUNCTION [dbo].[FuncErSummary]
(
    @BeginningDate DATE,
    @EndingDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT EmployeeIdNo,
           SUM(Debit - Credit) AS Amount,
           TransactionType
    FROM dbo.ErStatement_View
    WHERE SpecialAccount = 'EL'
      AND TransactionDate >= @BeginningDate
      AND TransactionDate <= @EndingDate
    GROUP BY EmployeeIdNo, TransactionType

    UNION

    SELECT e.IdNo,
           ISNULL(SUM(v.Debit - v.Credit), 0),
           'B'
    FROM dbo.Employee AS e
    LEFT JOIN dbo.ErStatement_View AS v
        ON v.EmployeeIdNo = e.IdNo
       AND v.TransactionDate < @BeginningDate
    GROUP BY e.IdNo
);
