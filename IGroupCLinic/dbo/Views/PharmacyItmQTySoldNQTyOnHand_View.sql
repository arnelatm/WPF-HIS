/****** Script for SelectTopNRows command from SSMS  ******/
create view PharmacyItmQTySoldNQTyOnHand_View as 
(select a.item_code, a.itemnameenglish, a.pack1, a.pack2, a.pack3 , d.TBQTy as QTySold,
    ( select sum(c.pcsqty/b.pack2/b.pack3) from ItemDetails as b 
	  left join StockPositionCurrent as c
	      on c.item_code = b.item_code and c.BranchID = b.BranchID
	  	  where b.Item_Code = a.Item_code and b.BranchID = a.BranchID) as QtyOnHand	      
 from ItemDetails as a
    left join TotalPharmacySales_View as d
      on d.item_code = a.item_code 
    where a.BranchID = '01')



