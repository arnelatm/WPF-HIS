










CREATE VIEW [dbo].[InvoicePharmacyHeader_View]
  AS
With cte as (Select a.Group_key,
		sum(a.ItemGrossPrice) as 'InvGrossPrice'
		from InvoicePharmacyItem_View a
		left join InvoicePharmacyItem_View b
		on a.Group_key = b.Group_key and a.Seq = b.Seq
		group by a.Group_key)
Select	Inv.TransNbr,
		cte.Group_key,
		Inv.TransDateEnglish,
		Inv.InsuranceID as 'CustomerId',
		'400' as 'RevCostCenter',
		Cast(IIf(Inv.TransType='CA',1,0) as Bit) as 'Cash',
		cte.InvGrossPrice,
		(inv.ExtraDiscountAmt-Inv.RoundOffAmt) * IIf(inv.BillType = 'SALE INVOICE',1,-1) as 'InvExtraDiscount',
		inv.BillAmt * IIf(inv.BillType = 'SALE INVOICE',1,-1) as 'BillAmt',
		Cast(0 as Bit) as 'CitizenSale',
		0 as 'Rejected'
		from PharmacyInvoiceGroup Inv
		left join cte
		on cte.Group_key = inv.Trans_key