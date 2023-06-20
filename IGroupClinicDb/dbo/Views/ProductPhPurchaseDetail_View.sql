



CREATE VIEW [dbo].[ProductPhPurchaseDetail_View]
AS
SELECT IIf(a.BranchId='02',1,2) as 'BranchIdNo', a.item_code as 'ProductCode', a.Batch as 'BatchNo', a.Expiry as 'ExpiryDate', a.Pcsqty/b.Pack3/b.pack2 as 'Quantity', 1 as UnitIdNo
      FROM [iGroupClinic].[dbo].[StockPositionCurrent] a
	  left join [iGroupClinic].[dbo].[ItemDetails] b
	  on a.BranchId = b.BranchId and a.item_code = b.Item_code
	  where a.BranchId = '01' and pcsqty <> 0