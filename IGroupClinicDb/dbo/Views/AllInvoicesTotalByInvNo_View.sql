















CREATE VIEW [dbo].[AllInvoicesTotalByInvNo_View]
  AS
SELECT cid.InvSource
      ,CID.[Group_Key]									  
      ,InvoiceType
	  ,TransNbr
	  ,SaleType
	  ,Sum(ItemGrossTotal) as 'InvItemGrossTotal'
	  ,Sum(ItemDiscountAmt) as 'InvItemDiscountAmt'
	  ,Sum(ItemVATAmt) as 'InvItemVatAmt'
	  ,InvTransDateEnglish
	  ,CompanyID
  FROM [iGroupClinic].[dbo].[AllInvoices_View] as CID
  left join iGroupClinic.Dbo.AllInvoicesSummarized_View B
  ON CID.Group_Key = B.Group_Key and cid.InvSource = b.InvSource
  where CID.Rejected=0 
  Group by CID.Group_Key,CID.InvSource,CID.SaleType,CID.InvoiceType,CID.TransNbr,CID.InvTransDateEnglish,CID.CompanyId