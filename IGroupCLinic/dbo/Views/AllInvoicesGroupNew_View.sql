


CREATE VIEW [dbo].[AllInvoicesGroupNew_View]
  AS
(SELECT 'Clinic' as 'InvType'
      ,[BranchID]
      ,[TransNbr]
	  ,iif([BillType]='CA','Cash','Credit') as 'TransType'
      ,[TransDateEnglish]
	  ,[DoctorID]
	  ,[InsuranceID]
	  ,[UserID]
	  ,[BillAmt]+[NormalDiscountAmt]+[ExtraDiscountAmt]-[RoundOffAmt]-isnull(VatAmt,0)+isnull(VatExemption,0) as 'GrossAmt'
	  ,[NormalDiscountAmt]
	  ,[ExtraDiscountAmt]
	  ,[DeductibleAmt]
	  ,[DeductibleDiscountAmt]
	  ,[RoundOffAmt] 
	  ,[NormalDiscountAmt]+[ExtraDiscountAmt]-[RoundOffAmt] as 'DiscountAmt'
	  ,[BillAmt] 
      ,isnull([VATAmt],0) as 'TotVatAmt'
	  ,isnull([VATExemption],0) as 'TotVatExemption'
	  ,[Reject] as 'Rejected'
  FROM [iGroupClinic].[dbo].[ClinicInvoiceGroup])

  UNION
      (SELECT 'Diagnosis Center'
	  ,[BranchID]
	  ,TransNBR
	  ,[TransType]
      ,[TransDateEnglish]
      ,[DoctorID]
	  ,[CompanyID]
	  ,[UserID]
      ,[GrossAmt]
      ,[DiscountAmt] as 'NormalDiscountAmt'
      ,[ExtraDiscountAmt]
	  ,0 as 'DeductibleAmt'
	  ,0 as 'DeductibleDiscountAmt'
      ,0 as 'RoundOffAmt'
	  ,DiscountAmt+ExtraDiscountAmt AS 'DiscountAmt'
	  ,NetAmt as 'BillAmt'
      ,isnull([VATAmt],0) as 'TotVATAmt'
  	  ,isnull([VATExemption],0) as 'TotVatExemption'
	  ,[Rejected]
  FROM [iGroupClinic].[dbo].[IBInvoiceGroup])
UNION 
  SELECT 'Pharmacy'
      ,[BranchID]
      ,TransNbr
      ,iif([TransType]='CA','Cash','Credit') as 'TransType'
      ,[TransDateEnglish]
      ,[DoctorID]
	  ,[InsuranceID]
	  ,[UserID]
	  ,[BillAmt]+[NormalDiscountAmt]+[ExtraDiscountAmt]-[RoundOffAmt]-isnull([VATAmt],0) as 'GrossAmt'
	  ,[NormalDiscountAmt]
	  ,[ExtraDiscountAmt]
	  ,[DeductibleAmt]
	  ,[DeductibleDiscountAmt]
	  ,[RoundOffAmt] 
	  ,[NormalDiscountAmt]+[ExtraDiscountAmt]+[RoundOffAmt] as 'DiscountAmt'
      ,[BillAmt]
      ,isnull([VATAmt],0) as 'TotVatAmt'
   	  ,0 as 'TotVatExemption'
	  ,0 as 'Rejected'
  FROM [iGroupClinic].[dbo].[PharmacyInvoiceGroup]





