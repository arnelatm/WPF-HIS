




CREATE VIEW [dbo].[InvoiceDCItem_View]
  AS
With cte as (select Group_key,
					Price,
					Qty, 
					VatPercent,
					VatAmt,
					SlNo,
					iif([DiscAmt]<>0,DiscAmt,Qty*Price*DiscPer/100) as 'ItemDiscountAmt'
					from IBInvoiceDetails)
select  b.TransNbr
		,cte.Group_key
		,cte.SlNo as 'Seq'
		,Price*Qty-ItemDiscountAmt as 'ItemGrossPrice'
		,cte.VatPercent
		,cte.VatAmt as 'ItemVatAmt'
		from cte
		left join IBInvoiceGroup b
		on cte.Group_key = b.Trans_Key