CREATE VIEW [dbo].[ApAging_View]
AS
SELECT SupplierIdNo,
       DATEDIFF(DAY, TransactionDate, CONVERT(DATE, GETDATE())) AS DaysDue,
       SUM(Credit - Debit) AS Balance
FROM dbo.ApStatement_View
WHERE SpecialAccount IN ('AP', 'AS')
  AND TransactionDate <= CONVERT(DATE, GETDATE())
GROUP BY SupplierIdNo,
         DATEDIFF(DAY, TransactionDate, CONVERT(DATE, GETDATE()))
HAVING SUM(Credit - Debit) <> 0;
