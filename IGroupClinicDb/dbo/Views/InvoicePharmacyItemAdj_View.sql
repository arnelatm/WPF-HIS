









CREATE VIEW [dbo].[InvoicePharmacyItemAdj_View]
  AS
with cte as (Select a.TransNbr,
		a.Group_key,
		b.TransDateEnglish,
		b.CustomerId,
		b.RevCostCenter,
		b.Cash,
		a.Seq,
		b.BillAmt,
		b.InvExtraDiscount,
		b.InvGrossPrice,
		b.CitizenSale,
		IIF(B.InvGrossPrice=0,0,a.ItemGrossPrice - b.InvExtraDiscount / b.InvGrossPrice * ItemGrossPrice) as 'AdjItemNetPrice',
		b.Rejected
		from InvoicePharmacyItem_view a
		Inner join InvoicePharmacyHeader_View b
		on a.Group_key = b.Group_key)
Select	cte.TransDateEnglish,
		cte.CustomerId,
		cte.RevCostCenter,
		cte.Cash,
		cte.Group_key,
		cte.TransNbr,
		cte.Seq,
		cte.AdjItemNetPrice,
		iif(cte.CitizenSale=1,0,cte.AdjItemNetPrice * c.VatPercent / 100) as 'AdjVatAmount',
		iif(cte.CitizenSale=1,0,cte.AdjItemNetPrice * c.VatPercent / 100) as 'AdjVatExemption',
		IIf(c.VatPercent=0,cte.AdjItemNetPrice,0) as 'ZeroRatedSale',
		IIf(c.VatPercent<>0 and cte.CitizenSale=1,cte.AdjItemNetPrice,0) as 'CitizenSale',
		IIf(c.VatPercent<>0 and cte.CitizenSale=0,cte.AdjItemNetPrice,0) as 'VatableAmount',
		cte.BillAmt,
		cte.Rejected
		from InvoicePharmacyItem_View c
		left Join cte 
		on cte.Group_key = c.Group_key and cte.Seq = c.Seq