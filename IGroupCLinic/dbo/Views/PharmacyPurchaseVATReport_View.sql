
CREATE VIEW PharmacyPurchaseVATReport_View
 
AS
select 
    BranchID,
	TransType ,
	TransNo,
	TransNo as TransNBR,
	TransDate ,
	TransDate as TransDateEnglish,
	SupplierID,
	SupplierNameEnglish,
	VATNo,
	InvoiceNo,
	InvoiceDate,
	sum(case when vatamt = 0 or vatamt is null then TotalQty*CostPrice  else 0 end) as NonTaxableAmount,
	sum(case when vatamt <>0 then TotalQty*CostPrice  else 0 end) as TaxableAmount,
	sum(VATAmt) as VATAmt,
	0 as Reject
from ItemPurchase_View  
where TransType='PUR' AND BranchID = '01'
group by
	BranchID,
	TransType ,
	TransNo,
	TransDate ,
	SupplierID,
	SupplierNameEnglish,
	VATNo,
	InvoiceNo,
	InvoiceDate
