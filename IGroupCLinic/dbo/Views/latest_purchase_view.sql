


CREATE VIEW [dbo].[latest_purchase_view]
as
(SELECT a.[BranchID],a.item_code,max(b.TransDate) as TransDate,a.costprice
  FROM [iGroupClinic].[dbo].[PurchaseDetails] a
  left join PurchaseGroup b
  on a.Group_key = b.Trans_Key and a.BranchID = b.BranchID
  group by a.branchid,a.item_code,b.transdate,costprice)


