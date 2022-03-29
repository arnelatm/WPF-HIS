
CREATE VIEW StockCompare_View
 
AS
select 	item_code,
	sum(oldqtybox) as OldQtybox,
	sum(newqtybox) as NewQtyBox,
	sum(oldcostamt) as OldCostAmt,
	sum(newcostamt) as NewCostAmt,
	sum(oldsaleamt) as OldSaleAmt,
	sum(newsaleamt) as NewSaleAmt,
	sum(newqtybox - oldqtybox) as DiffQtyBox,
	sum(newcostamt - oldcostamt) as DiffCostAmt,
	sum(newsaleamt - oldsaleamt) as DiffSaleAmt,
	itemnameenglish,
	(Select laststocktakingdate from systemsettings) as stockdate
from StockDifference_View
group by
	item_code,
	itemnameenglish
having sum(oldqtybox) <> sum(newqtybox)
	or sum(newcostamt) <> sum(oldcostamt)
	or sum(newsaleamt) <> sum(oldsaleamt)
