




CREATE VIEW [dbo].[ClinicDInvoices_View]
  AS
(SELECT 'Clinic' as 'InvSource'
      ,[Group_Key] as 'Group_Key'
      ,[RowNbr] as 'RowNbr'
      ,[ServiceID] as 'ServiceID'
      ,[Qty]
	  ,'P' AS 'Unit'
      ,[PcsQty]
      ,[SalePrice]
	  ,iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100) as 'ItemDiscountAmt'
      ,isnull([VATPercent],0) as 'VATPercent'
      ,isnull(CID.[VATAmt],0) as 'VATAmt'
	  ,case when cid.DiscountPer is null then 0 else cid.DiscountPer end as 'DiscountPer'
	  ,case when cid.DiscountAmt	is null then 0 else cid.DiscountAmt end as 'DiscountAmt'
  FROM [iGroupClinic].[dbo].[ClinicInvoiceDetails] as CID
)
