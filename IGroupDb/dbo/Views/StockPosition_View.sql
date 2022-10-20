
CREATE VIEW StockPosition_View
 
AS
select 
	a.item_code,
	a.batch,
	a.expiry,
	sum((a.qtybox*b.pack2*b.pack3)+(a.qtystrips*b.pack3)+a.qtypcs) as OSqty,
	0 as PurQty,
	0 as SaleQty,
	0 as CurQty
from stockposition a
left outer join itemdetails b on a.item_code = b.item_code and a.branchid = b.branchid
where a.item_code is not null
group by
	a.item_code,
	a.batch,
	a.expiry
union all
select 
	item_code,
	batch,
	expiry,
	0 as OSQty,
	sum(case WHEN transtype = 'PUR' THEN (case when unit = 'B' then 
		(userqty+bonusqty)*pack2*pack3
	else
		case when 
			unit = 'S' then 
			(userqty+bonusqty)*pack3
		else
			userqty+bonusqty 
		end 
	end)
	ELSE
	(case when unit = 'B' then 
		(userqty+bonusqty)*pack2*pack3
	else
		case when 
			unit = 'S' then 
			(userqty+bonusqty)*pack3
		else
			userqty+bonusqty 
		end 
	end) * -1
	END) 
	as PurQty,
	0 as SaleQty,
	0 as CurQty
from itempurchase_view where transdate >'2013/03/01'
and item_code is not null
group by item_code,
	batch,
	expiry
union all
SELECT 
	ITEM_CODE,
	BATCH,
	EXPIRY,
	0 as OSQty,
	0 as PurQty,
	SUM(CASE WHEN BILLTYPE = 'SALE INVOICE' THEN
		(CASE WHEN UNIT = 'Box' THEN
		QTY * PACK2*PACK3
		ELSE
		CASE WHEN UNIT = 'Strip' THEN
		QTY * PACK3
		ELSE
		QTY
		END 
		END) * -1
	ELSE
		(CASE WHEN UNIT = 'Box' THEN
		QTY * PACK2*PACK3
		ELSE
		CASE WHEN UNIT = 'Strip' THEN
		QTY * PACK3
		ELSE
		QTY
		END END
		) 
	END) AS SaleQty,
	0 as CurQty 
FROM PHARMACYSALES_VIEW WHERE TRANSDATEENGLISH >'2013/03/01'
and item_code is not null
GROUP BY 
	ITEM_CODE,
	BATCH,
	EXPIRY
union all
select 
	item_code,
	batch,
	convert(varchar(10),expiry,111) as expiry,
	0 as OSQty,
	0 as PurQty,
	0 as SaleQty,
	PCSQty*-1 as CurQty
from StockPositionCurrent
where item_code is not null