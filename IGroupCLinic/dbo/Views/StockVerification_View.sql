
CREATE VIEW StockVerification_View
 
AS

SELECT  a.ITEM_CODE,
	b.itemnameenglish,
	a.BATCH,
	a.EXPIRY,
	sum(a.OSQty)/(b.pack2*b.pack3) as OSQty,
	sum(a.PurQty)/(b.pack2*b.pack3) as PurQty,
	sum(a.SaleQty)/(b.pack2*b.pack3) as SaleQty,
	sum(a.CurQty)/(b.pack2*b.pack3) as CurQty,
	SUM(a.OSQty+a.PurQty+a.SaleQty+a.CurQty)/(b.pack2*b.pack3) AS Verified
FROM StockPosition_View a
left outer join itemdetails b on a.item_code = b.item_code
group by
	a.ITEM_CODE,
	b.itemnameenglish,
	a.BATCH,
	a.EXPIRY,
	b.pack2,
	b.pack3
