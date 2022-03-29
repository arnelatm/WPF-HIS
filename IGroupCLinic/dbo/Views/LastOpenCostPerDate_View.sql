
CREATE VIEW dbo.LastOpenCostPerDate_View
AS
SELECT 
	BranchID,
	Item_Code,
	StockDate as 'TransDate',
	CostPrice
  FROM dbo.StockPosition
