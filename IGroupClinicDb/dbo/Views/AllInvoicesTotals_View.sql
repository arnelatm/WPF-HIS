





CREATE VIEW [dbo].[AllInvoicesTotals_View]
  AS
  Select Group_Key,InvSource,
  Sum(ItemGrossTotal-ItemDiscountAmt) as 'InvAdjGrossAmount'
  FROM [iGroupClinic].[dbo].[AllInvoices_View]
  group by group_key,InvSource