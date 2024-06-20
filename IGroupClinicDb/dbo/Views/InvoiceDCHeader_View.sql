









CREATE VIEW [dbo].[InvoiceDCHeader_View]
  AS
With cte as (Select a.Group_key,
		sum(a.ItemGrossPrice) as 'InvGrossPrice'
		from InvoiceDCItem_View a
		left join InvoiceDCItem_View b
		on a.Group_key = b.Group_key and a.Seq = b.Seq
		group by a.Group_key)
Select	Inv.TransNbr,
		cte.Group_key,
		Inv.TransDateEnglish,
		Inv.CompanyID as 'CustomerId',
		'301' as 'RevCostCenter',
		Cast(Iif(Inv.TransType='Cash',1,0) as Bit) as 'Cash',
		cte.InvGrossPrice,
		inv.ExtraDiscountAmt as 'InvExtraDiscount',
		inv.NetAmt as 'BillAmt',
		Cast(Iif(Inv.VatExemption=0,0,1) as Bit) as 'CitizenSale',
		inv.Rejected 
		from IBInvoiceGroup Inv
		left join cte
		on cte.Group_key = inv.Trans_key