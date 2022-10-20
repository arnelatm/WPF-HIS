CREATE VIEW PMRDisplayPharmacyStock_View
 
AS
SELECT 	a.BranchID,
        A.Item_Code,
        b.ean_code,
        sum(pcsqty)/(b.pack2*pack3) as Qty,
	    B.ItemNameEnglish
FROM StockPositionCurrent a
Left Outer Join ItemDetails b on a.Item_code = b.Item_Code and a.BranchID = b.BranchID
where a.BranchID='01'
group by
      a.BranchID,
      a.Item_Code ,
	  b.ean_code,
	  b.Pack2,
	  b.Pack3,
	  b.ItemNameEnglish