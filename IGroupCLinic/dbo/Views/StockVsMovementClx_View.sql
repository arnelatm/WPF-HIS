

CREATE VIEW [dbo].[StockVsMovementClx_View]
  AS (select it.ItemNameEnglish,it.item_code,it.branchID,
	   (select sum(stk.pcsqty)/it.pack2/it.pack3 from StockPositionCurrent as stk 
		   where stk.Item_code = it.item_Code and stk.branchid = it.BranchID and stk.WarehouseID = '01'
		   group by stk.branchid,stk.item_code,stk.warehouseid) as stockQty,
	    (select sum(itv.QtyBox) from ItemMovement_View as itv 
	       where itv.Item_Code = it.Item_Code and itv.BranchID = it.BranchID and itv.warehouseid = '01'
		   group by itv.branchid,itv.item_code,itv.warehouseid) as itmmvQty,
		(select sum(itv.QtyBox) from ItemMovement_View as itv 
	       where itv.Item_Code = it.Item_Code and itv.BranchID = it.BranchID and itv.warehouseid = '01' and itv.PostedInStock = 'N'
		   group by itv.branchid,itv.item_code,itv.warehouseid) as itmmvqtyUnposted
    FROM itemdetails as IT

)







