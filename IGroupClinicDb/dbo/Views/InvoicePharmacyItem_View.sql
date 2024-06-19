



CREATE VIEW [dbo].[InvoicePharmacyItem_View]
  AS
With cte as (select Group_key,
					salePrice,
					Qty, 
					VatPercent,
					VatAmt,
					RowNbr,
					iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100) as 'ItemDiscountAmt'
					from PharmacyInvoiceDetails)
select  b.TransNbr
		,cte.Group_key
		,cte.RowNbr as 'Seq'
		,(salePrice*Qty-ItemDiscountAmt)*iif(b.BillType='SALE INVOICE',1,-1) as 'ItemGrossPrice'
		,VatPercent
		,cte.VatAmt *iif(b.BillType = 'SALE INVOICE',1,-1) as 'ItemVatAmt' 
		from cte
		left join PharmacyInvoiceGroup b
		on cte.Group_key = b.Trans_Key