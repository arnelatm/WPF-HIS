


CREATE VIEW [dbo].[InvoiceClinicItem_View]
  AS
With cte as (select Group_key,
					salePrice,
					Qty, 
					VatPercent,
					VatAmt,
					RowNbr,
					iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100) as 'ItemDiscountAmt'
					from ClinicInvoiceDetails)
select  b.TransNbr
		,cte.Group_key
		,cte.RowNbr as 'Seq'
		,salePrice*Qty-ItemDiscountAmt as 'ItemGrossPrice'
		,VatPercent
		,cte.VatAmt as 'ItemVatAmt'
		from cte
		left join ClinicInvoiceGroup b
		on cte.Group_key = b.Trans_Key