



CREATE VIEW [dbo].[CashCompanyInvDetails_View]
AS
(SELECT InsuranceId
	   ,Transdateenglish
	   ,[ServiceNameEnglish]
      ,[Qty]
	  ,Round(SalePrice - ItemDiscountAmt/qty,2) as netSalePrice
	  ,Qty * Round(SalePrice - ItemDiscountAmt/qty,2) as ItemGrossAmount
	  ,[VatAmt]
	  ,iif(VatExemption=0,0,vatamt) as ItemVatExemption
	  ,Qty * Round(SalePrice - ItemDiscountAmt/qty,2) + vatamt - iif(VatExemption=0,0,vatamt) as NetAmount        
  FROM [iGroupClinic].[dbo].[IBCLAInvoices_View]
  where BillType = 'CA' and reject = 0
  )