

CREATE VIEW [dbo].[StockVsMovement_View2]
  AS (select it.ItemNameEnglish,it.item_code,it.branchID,
	   (select sum(stk.pcsqty)/it.pack2/it.pack3 from StockPositionCurrent as stk 
		   where stk.Item_code = it.item_Code and stk.branchid = it.BranchID
		   group by stk.branchid,stk.item_code,stk.WarehouseID) as stockQty,
	    (select sum(itv.QtyBox) from ItemMovement_View as itv 
	       where itv.Item_Code = it.Item_Code and itv.BranchID = it.BranchID 
		   group by itv.branchid,itv.item_code) as itmmvQty,
		(select sum(itv.QtyBox) from ItemMovement_View as itv 
	       where itv.Item_Code = it.Item_Code and itv.BranchID = it.BranchID and itv.PostedInStock = 'Y'
		   group by itv.branchid,itv.item_code ) as itmmvQtyPosted
    FROM itemdetails as IT

)






