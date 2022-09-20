
CREATE VIEW PharmacyDailyCollectionCalculation_View
 
AS

select
	a.BranchID,
	a.TransNBR,
	a.TransType,
	a.TransDateEnglish,
	d.AcCode,
	d.DepartmentNameEnglish,
	d.SalesCode,
	d.CostOfGoodsCode,
	d.InventoryCode, 
	CONVERT(numeric(10,2),SUM(case when b.saletype = 'SALE INVOICE' THEN b.Qty*b.SalePrice ELSE b.Qty*b.SalePrice*-1 END)) as GrossAmt, 
        CONVERT(numeric(10,2),SUM(case when b.saletype = 'SALE INVOICE' THEN ((b.DiscountAmt*b.Qty)+((b.Qty*b.SalePrice)* b.DiscountPer)/100) ELSE ((b.DiscountAmt*b.Qty)+((b.Qty*b.SalePrice)* b.DiscountPer)/100)*-1 END)+(case when b.saletype = 'SALE INVOICE' THEN SUM(DISTINCT(a.DeductibleDiscountAmt+a.ExtraDiscountAmt))ELSE SUM(DISTINCT(a.DeductibleDiscountAmt+a.ExtraDiscountAmt)) END)) AS DiscountAmt,
	CONVERT(numeric(10,2),SUM(case when b.saletype = 'SALE INVOICE' THEN b.DeductibleAmt else b.DeductibleAmt*-1 end)) as DeductibleAmt,
	CONVERT(numeric(10,2),SUM(case when b.saletype = 'SALE INVOICE' THEN b.Qty*b.CostPrice else b.qty*b.CostPrice*-1 END)) as CostAmt,
	CONVERT(numeric(10,2),a.RoundOffAmt) as RoundOffAmt
from PharmacyInvoiceGroup a
left outer join PharmacyInvoiceDetails b on a.Trans_Key = b.Group_Key
left outer join ItemDetails c on b.item_code = c.item_code and b.Branchid = c.Branchid 
left outer join AccountsSalesDepartments d on c.acct_dept = d.AcCode 
where a.branchid is not null and b.sbt_status is null 
and b.InvoiceType = 'CA' 
and d.accode is not null
and (a.CreditCardNo is null or a.CreditCardNo='')
group by a.BranchID,
	 a.TransType,
	 a.TransNbr,
	 a.TransDateEnglish,
     	 d.AcCode,
	 d.departmentnameenglish,
	 d.SalesCode,
	 d.CostOfGoodsCode,
	 d.InventoryCode,
	 b.SaleType,
	 a.RoundOffAmt