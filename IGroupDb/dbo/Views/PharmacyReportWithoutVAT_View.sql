
CREATE VIEW PharmacyReportWithoutVAT_View
 
AS
SELECT 
	a.RegistrationNo,
	a.TransNbr,
	a.TransType,  
	a.transdateenglish,
	a.DeductibleAmt,
	a.ExtraDiscountAmt,
	a.DeductibleDiscountAmt, 
	a.roundoffamt,
	'Daily Sales Collection'  as ServiceDescription,
	case when b.saletype = 'SALE INVOICE' THEN sum(b.qty*b.SalePrice ) ELSE sum(b.qty*b.SalePrice )*-1 END as Gross,
	case when b.saletype = 'SALE INVOICE' THEN sum(case when b.DiscountAmt = 0 then (b.DiscountPer * b.Qty * b.SalePrice )/100 else b.discountamt end) ELSE sum(case when b.DiscountAmt = 0 then (b.DiscountPer * b.Qty * b.SalePrice )/100 else b.discountamt end)*-1 END as DiscountAmt,
	case when b.saletype = 'SALE INVOICE' THEN sum(b.vatamt) ELSE sum(b.vatamt)*-1 END as vatamt,
	case when b.saletype = 'SALE INVOICE' THEN 0 else 1 end as Reject 
FROM PharmacyInvoiceGroup a
LEFT OUTER JOIN PharmacyInvoiceDetails b ON a.Trans_Key = b.Group_Key 
where (b.Item_Code <> 'PHR-DED' or b.Item_Code <> 'PHAR-DED' or b.Item_Code <> 'PHR-DEDU') AND (b.VATAmt =0)
GROUP BY 
	a.TransNbr,
	a.TransType,  
	a.transdateenglish,
	a.DeductibleAmt,
	a.ExtraDiscountAmt,
	a.DeductibleDiscountAmt,
	a.roundoffamt,
	b.SaleType,
	a.RegistrationNo