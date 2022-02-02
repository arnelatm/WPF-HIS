Update ibinvoicedetails 
set discamt = 70, vatamt=12 
from IBinvoiceDetails a
inner join ibInvoicegroup b
on a.Group_Key = b.trans_key
where (B.transtype = 'Cash' and b.countryIota = 'SAU' and b.TransDateEnglish >= '2021/10/01') AND (b.TransDateEnglish <= '2021/12/31') AND (b.Rejected = 0) AND (a.ServiceID = '302') AND (b.NetAmt = 372.5) AND (a.DiscAmt = 0) AND (a.VATAmt = 22.50)

Update ibinvoicedetails 
set discamt = 0, price=280.50
from IBinvoiceDetails a
inner join ibInvoicegroup b
on a.Group_Key = b.trans_key
where (B.transtype = 'Cash' and b.countryIota = 'SAU' and b.TransDateEnglish >= '2021/10/01') AND (b.TransDateEnglish <= '2021/12/31') AND (b.Rejected = 0) AND (a.ServiceID = '0638') AND (b.NetAmt = 372.5) AND (a.DiscAmt = 50) AND (a.VATAmt = 0)

Update ibinvoicegroup 
set vatamt = 12, discountamt = 70, grossamt = 430.50
from ibinvoicegroup a
inner join ibInvoicedetails b
on a.Trans_Key = b.Group_Key 
where   (B.transtype = 'Cash' and b.countryIota = 'SAU' and a.TransDateEnglish >= '2021/10/01') AND (a.TransDateEnglish <= '2021/12/31') AND (a.Rejected = 0) AND (b.ServiceID = '302') AND (a.NetAmt = 372.5) 



Check for errors:
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [IBType]
      ,[Rejected]
      ,[UserID]
      ,[TransType]
      ,[TransNBR]
      ,[TransDateEnglish]
      ,[GrossAmt]
      ,[DiscountAmt]
      ,[NetAmt]
	  ,[VatAmt]
      ,[ExtraDiscountPer]
      ,[ExtraDiscountAmt]
	  ,VATExemption
	  ,grossamt-DiscountAmt-ExtraDiscountAmt
  FROM [iGroupClinic].[dbo].[IBInvoiceGroup]
 where abs(netamt - (grossamt - discountamt - ExtraDiscountAmt + vatamt - VATExemption)) > 0.01