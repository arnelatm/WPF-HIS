
CREATE VIEW 	Items4Analisys_View
 
AS
SELECT 	
		a.TransDateEnglish,
		a.branchid,
		b.Item_code,
		c.ItemGroup,
		CASE when b.Unit = 'B' then b.qty*b.pack2*b.pack3 
			else case when b.unit='S' then b.qty*b.pack3 
			else b.qty end end as QtyInPcs,
		CASE when b.Unit = 'B' then SalePrice 
			else case when b.unit='S' then b.qty*b.pack3 
			else b.qty*b.pack2*b.pack3 end end as SalePrice,
		b.CostPrice,
		b.unit,
		c.pack2,
		c.pack3
FROM PharmacyInvoiceGroup a
LEFT OUTER JOIN PharmacyInvoiceDetails b ON a.branchid = b.branchid AND a.trans_key = b.group_key 
LEFT OUTER JOIN ItemDetails c ON b.branchid = c.branchid AND b.item_code = c.item_code
WHERE  b.SaleStatus IS NULL AND a.BillType = 'SALE INVOICE' AND b.item_code <> 'DEDPHR'