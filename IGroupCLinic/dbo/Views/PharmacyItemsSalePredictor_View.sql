
/****** Script for SelectTopNRows command from SSMS  ******/
create view [dbo].[PharmacyItemsSalePredictor_View] as 
(select a.item_code, a.itemnameenglish, a.pack1, a.pack2, a.pack3 , d.TBQTy as QTySold,
    ( select sum(c.pcsqty/b.pack2/b.pack3) from ItemDetails as b 
	  left join StockPositionCurrent as c
	      on c.item_code = b.item_code and c.BranchID = b.BranchID
	  	  where b.Item_Code = a.Item_code and b.BranchID = a.BranchID) as QtyOnHand,
	 ( select min(e.expiry) from ItemDetails as f
	  left join StockPositionCurrent as e
	      on e.item_code = f.item_code and e.BranchID = f.BranchID
	  	  where f.Item_Code = a.Item_code and f.BranchID = a.BranchID) as MinExpiryDate,
     ( select max(h.expiry) from ItemDetails as g
	  left join StockPositionCurrent as h
	      on g.item_code = h.item_code and g.BranchID = h.BranchID
	  	  where g.Item_Code = a.Item_code and g.BranchID = a.BranchID) as MaxExpiryDate              
 from ItemDetails as a
    left join TotalPharmacySales_View as d
      on d.item_code = a.item_code 
    where a.BranchID = '01')




