/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].latest_purchase_2018_view
  AS
(Select purchasedetails.item_code,costprice
from 
(SELECT [Item_Code],max(b.TransDate) as Created_at
  FROM [iGroupClinic].[dbo].[PurchaseDetails] a
  join PurchaseGroup b
  on a.Group_key = b.Trans_Key
  where b.BranchID = '02' and b.TransDate < '2019/01/01'
  group by item_code) as latest_purchase
inner join purchasedetails
on purchasedetails.item_code = latest_purchase.item_code 
inner join purchasegroup 
on purchasedetails.Group_key = PurchaseGroup.Trans_Key
and PurchaseGroup.TransDate = latest_purchase.Created_at)