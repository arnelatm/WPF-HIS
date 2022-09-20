
CREATE VIEW [dbo].[StockVsMoveWH_View]
  AS (SELECT stk.item_code,
it.itemnameenglish,
SUM(stk.pcsqty/it.pack2/it.pack3) AS 'STKQTY',
(select sum(itv.QtyBox) from ItemMovement_View as itv 
  	 where itv.branchid=stk.branchid and itv.warehouseid=stk.warehouseid and itv.item_code = stk.item_code AND itv.PostedInStock='Y'
	  group by itv.item_code,itv.branchid,itv.warehouseid) as 'itmmvQty',
it.pack1,
it.pack2,
it.pack3,
stk.branchid,
stk.warehouseid
from StockPositionCurrent as STK
JOIN ITEMDETAILS AS IT
ON STK.ITEM_CODE = IT.ITEM_CODE and stk.branchid=it.branchid
GROUP BY STK.BRANCHID,STK.ITEM_CODE,STK.WAREHOUSEID,it.ItemNameEnglish,it.pack1,it.pack2,it.pack3)