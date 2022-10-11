
CREATE VIEW [dbo].[CompanyInvSummary2_View]
AS
SELECT InsuranceId
	   ,Transdateenglish
	   ,[ServiceNameEnglish]
      ,[Qty]
	  ,Round(SalePrice - ItemDiscountAmt/qty,2) as netSalePrice
	  ,Qty * Round(SalePrice - ItemDiscountAmt/qty,2) as ItemGrossAmount
	  ,[VatAmt]
	  ,iif(VatExemption=0,0,vatamt) as ItemVatExemption
	  ,Qty * Round(SalePrice - ItemDiscountAmt/qty,2) + vatamt - iif(VatExemption=0,0,vatamt) as NetAmount        
  FROM [iGroupClinic].[dbo].[IBCLAInvoices_View]
  where BillType = 'CR' and reject = 0