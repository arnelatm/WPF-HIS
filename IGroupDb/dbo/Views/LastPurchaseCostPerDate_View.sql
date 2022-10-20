CREATE VIEW dbo.LastPurchaseCostPerDate_View
AS
SELECT a.branchid,a.item_code,b.TransDate,a.costprice 
			FROM [iGroupClinic].[dbo].[PurchaseDetails] a
			left join PurchaseGroup b
			on a.Group_key = b.Trans_Key 
			group by a.branchid,a.item_code,b.transdate,costprice