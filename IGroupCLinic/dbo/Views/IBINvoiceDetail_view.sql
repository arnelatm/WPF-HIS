

create view [dbo].[IBINvoiceDetail_view]
as 
SELECT [Group_Key]
	  ,sum(a.price * a.qty) as Price
	  ,sum(a.discamt) as DiscAmt
      ,sum(a.[VATAmt]) as DetailVat
	  ,transnbr
	  ,b.VATAmt
	  ,b.ExtraDiscountAmt
	  ,b.VATExemption
	  ,b.NetAmt
  FROM [iGroupClinic].[dbo].[IBInvoiceDetails] a
  join ibinvoicegroup b
  on a.group_key=b.Trans_key where
  b.transdateenglish > '2020/12/31'
  group by group_key,transnbr,b.VATAmt,b.Netamt,b.ExtraDiscountAmt,b.VATExemption

