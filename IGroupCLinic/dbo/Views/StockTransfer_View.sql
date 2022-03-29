CREATE view 	StockTransfer_View
 
as 
select a.BranchId,
		a.BranchFrom,
		a.WarehouseFrom,
		a.BranchTo,
		a.WareHouseTo,
		a.transtype,
		a.TransSeries,
		a.TransDate,
		a.ReqNo,
		a.ReqDate,
		a.AcCodeFrom,
		a.AcCodeTo,
		a.PostInStock,
		a.PostInAccounts,
		a.remarks,
		b.SlNo,
		b.Item_Code,
		b.Batch,
		b.Expiry,
		b.Qty,
		b.Unit,
		b.CostPrice, 
		b.CostInUnit,
		b.Price,
		d.ItemNameEnglish,
		d.Pack1,
		d.Pack2,
		d.Pack3
from StockTransferGroup a
left outer join StockTransferDetails b on a.Primary_Key = b.Group_Key and a.BranchID = b.BranchID 
left outer join ItemDetails d on b.Item_Code = d.Item_Code and b.BranchID =  d.BranchID 
