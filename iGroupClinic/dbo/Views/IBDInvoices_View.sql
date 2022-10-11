




CREATE VIEW [dbo].[IBDInvoices_View]
  AS
  (SELECT 'Diagnosis Center' as 'InvSource'
      ,[Group_Key] 
      ,[SlNo] as 'RowNbr'
      ,[ServiceID] 
      ,[Qty]
	  ,'P' as 'Unit'
	  ,1 as 'PcsQty'
      ,[Price] as 'SalePrice'
      ,iif([DiscAmt]<>0,DiscAmt,Price*DiscPer/100) as 'ItemDiscountAmt'
      ,isnull([VATPercent],0) as 'VATPercent'
      ,isnull(IBD.[VATAmt],0)  as 'VATAmt'
	  ,case when ibd.DiscPer is null then 0 else ibd.DiscPer end as 'DiscountPer'
	  ,case when ibd.DiscAmt	is null then 0 else ibd.DiscAmt end as 'DiscountAmt'
  FROM [iGroupClinic].[dbo].[IBInvoiceDetails] ibd
)