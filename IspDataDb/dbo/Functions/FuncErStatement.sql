CREATE FUNCTION [dbo].[FuncErStatement]
(
    @EmployeeIdNo INT,
    @BeginningDate DATE,
    @EndingDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT JournalCode, IdNo, Sequence, JournalIdNo, AccountIdNo, Debit, Credit,
           RevCostCenterIdNo, Notes, Posted, EmployeeIdNo, InvoiceNo,
           TransactionDate, ReferenceNo, TransactionType, SpecialAccount, MainNote
    FROM dbo.ErStatement_View
    WHERE SpecialAccount = 'EL'
      AND EmployeeIdNo = @EmployeeIdNo
      AND TransactionDate >= @BeginningDate
      AND TransactionDate <= @EndingDate

    UNION

    SELECT 'BB', 0, 1, 0, 0,
           CASE WHEN balance.Amount > 0 THEN balance.Amount ELSE 0 END,
           CASE WHEN balance.Amount < 0 THEN balance.Amount ELSE 0 END,
           0, 'Beginning Balance', 0, @EmployeeIdNo, 'Beg.Bal.',
           DATEADD(DAY, -1, @BeginningDate), 'Beg.Bal.',
           CASE WHEN balance.Amount >= 0 THEN 'D' ELSE 'C' END,
           'EL', 'Beginning Balance'
    FROM (SELECT ISNULL(SUM(Debit - Credit), 0) AS Amount
          FROM dbo.ErStatement_View
          WHERE EmployeeIdNo = @EmployeeIdNo
            AND TransactionDate < @BeginningDate) AS balance
);
