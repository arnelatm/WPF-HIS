
CREATE VIEW [dbo].[InvoiceDetailsSummary_View]
  AS
SELECT Group_Key,Sum(IIf(DiscountAmt=0,SalePrice*(1-DiscountPer)/100,SalePrice-DiscountAmt)) as 'TotalGrossPrice',
       Sum(VATAmt) as 'TotalVatAmt'
  FROM [iGroupClinic].[dbo].[ClinicInvoiceDetails] 
  Group by Group_key