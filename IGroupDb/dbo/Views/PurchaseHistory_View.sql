
CREATE VIEW PurchaseHistory_View
 
AS
SELECT 
	a.BranchID,
	a.Item_Code,
	a.ItemNameEnglish,
	b.SupplierNameEnglish,
	c.Batch,
	c.Expiry,
	c.UserQty,
	c.BonusQty,
	(CASE WHEN c.Unit='B' THEN 'Box' ELSE CASE WHEN c.Unit = 'S' THEN 'Strip' ELSE 'Pcs' END END) AS Unit,
	c.CostPrice,
	d.TransDate,
	CASE WHEN d.TransSeries='CA' THEN 'Cash' ELSE 'Credit' END AS TransSeries,
	d.SupplierID,
	d.TransNo,
	d.TransType,
	c.sellingprice,
	c.VATPercent,
	c.VATAmt,
	d.VATAmt as TotalVATAmt  
FROM ItemDetails a,
	SupplierDetails b,
	PurchaseDetails c,
	PurchaseGroup d 
WHERE a.Item_Code=c.Item_Code AND A.BRANCHID = C.BRANCHID
	AND d.SupplierID= b.SupplierID 
	AND c.Group_Key=d.Trans_Key AND c.PurchaseStatus = d.TransType