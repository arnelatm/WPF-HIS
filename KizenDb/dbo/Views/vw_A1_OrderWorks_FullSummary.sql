
CREATE VIEW [dbo].[vw_A1_OrderWorks_FullSummary]
AS
SELECT
    ow.WorkID,
	w.Name as ItemName,
    -- Category Hierarchy
    c.Name AS CategoryName,
    c.Parent AS ParentCategoryName,
	c.Code,
    ISNULL(c.RootParent, c.Parent) AS RootCategoryName,

    MAX(ow.Name) AS WorkName,
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
LEFT JOIN dbo.A1_Categorys c
    ON ow.Category = c.[Name]   -- KEY JOIN
LEFT JOIN dbo.A1_Works w
	on ow.WorkID = w.Code

GROUP BY
    ow.WorkID,
    c.[Name],
	c.Code,
    c.Parent,
    c.RootParent,
	w.Code,
	w.[Name],
    CAST(ow.[Date] AS date);