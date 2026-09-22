CREATE VIEW [dbo].[ArAging_View]
AS
SELECT CustomerIdNo,
       DATEDIFF(DAY, TransactionDate, CONVERT(DATE, GETDATE())) AS DaysDue,
       SUM(Debit - Credit) AS Balance
FROM dbo.ArStatement_View
WHERE SpecialAccount IN ('AR', 'CA')
  AND TransactionDate <= CONVERT(DATE, GETDATE())
GROUP BY CustomerIdNo,
         DATEDIFF(DAY, TransactionDate, CONVERT(DATE, GETDATE()))
HAVING SUM(Debit - Credit) <> 0;
