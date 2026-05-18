SELECT 
    b.IdNo,
    b.PayeeIdNo,
    b.Amount AS JournalAmount,
    ISNULL(SUM(a.Amount), 0) AS OI_Total,
    ISNULL(SUM(a.Amount), 0) - b.Amount AS Difference
FROM [ISPDATA].[dbo].[CdJournal] b
LEFT JOIN [ISPDATA].[dbo].[CdOiItem] a
    ON a.djIdNo = b.IdNo
WHERE b.PayeeIdNo IS NOT NULL and B.PaymentType = 'A'
GROUP BY 
    b.IdNo,
    b.PayeeIdNo,
    b.Amount
HAVING 
    ISNULL(SUM(a.Amount), 0) <> b.Amount;