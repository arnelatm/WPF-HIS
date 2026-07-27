
CREATE VIEW [dbo].[vw_A1_OrderWorks_WorkID_Summary]
AS
SELECT
    ow.WorkID,
	w.Code,
	w.Name,
    MAX(ow.Name) AS WorkName,
    MAX(ow.Category) AS Category,

    CAST(ow.[Date] AS date) AS OrderDate,

    COUNT(*) AS LineCount,
    COUNT(DISTINCT ow.OrderID) AS OrderCount,

    SUM(ISNULL(ow.[Count], 0)) AS TotalQuantityUsed,

    SUM(ISNULL(ow.Total, 0)) AS GrossAmount,
    SUM(ISNULL(ow.DiscNet, 0)) AS DiscountAmount,
    SUM(ISNULL(ow.TotalNoVAT, 0)) AS AmountBeforeVAT,
    SUM(ISNULL(ow.VatValue, 0)) AS VATAmount,
    SUM(ISNULL(ow.Net, 0)) AS NetAmount,

    SUM(ISNULL(ow.TotalCost, 0)) AS TotalCost,
    SUM(ISNULL(ow.Net, 0)) - SUM(ISNULL(ow.TotalCost, 0)) AS GrossProfit
FROM dbo.A1_OrderWorks ow
left join dbo.A1_Works w
	on ow.WorkID = w.Code
WHERE ow.WorkID IS NOT NULL
GROUP BY
    ow.WorkID,
	w.Code,
	w.Name,
    CAST(ow.[Date] AS date);