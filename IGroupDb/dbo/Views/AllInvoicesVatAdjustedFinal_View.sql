





CREATE VIEW [dbo].[AllInvoicesVatAdjustedFinal_View]
  AS
  (SELECT [InvSource]
      ,[Group_Key]
      ,[TransType]
      ,[SaleType]
      ,[BranchID]
      ,[RowNbr]
      ,[ItemCode]
      ,[Qty]
      ,[Unit]
      ,[PcsQty]
      ,[SalePrice]
      ,[ItemGrossPrice]
      ,[ItemDiscountAmt]
      ,[ItemNetAmount]
      ,[AdjItemNetAmount]
      ,[VATPercent]
      ,[VATAmt]
      ,[TransNbr]
      ,[TransDateEnglish]
      ,[InvNormalDiscount]
      ,[InvExtraDiscount]
      ,[InvRoundoffAmt]
      ,[InvVatAmt]
      ,[InvVatExemption]
      ,[BillAmt]
      ,[TInvNormalDiscount]
      ,[TInvExtraDiscount]
      ,[TInvRoundoffAmt]
      ,[TInvVatAmt]
      ,[TInvVatExemption]
      ,[TBillAmt]
      ,[Rejected]
      ,[CostCenter]
      ,[UserID]
      ,[DoctorID]
      ,[RegistrationNo]
      ,[RegistrationType]
      ,[PatientNameEnglish]
      ,[InsuranceID]
      ,[NameEnglish]
      ,[ServiceNameEnglish]
      ,[InsuranceGroupID]
      ,[AdjInvExtraDisc]
      ,[InvGrossAmt]
      ,[Series]
      ,[AdditionalItemDiscount]
      ,[AdjItemDiscount]
      ,[AdjExtPlusVat]
      ,[AdjItemVat]
      ,[AdjItemVatExemption]
      ,[AdjExtAmt]
	  ,[IqamaNo]
	  ,iif([TInvVatExemption]<>0,'Saudi Arabia',[CountryName]) as 'CountryName'
	  ,[ItemGrossPrice]-[AdjExtAmt] as 'VAdjDiscount'
	  ,[AdjExtAmt]+[AdjItemVat]-[AdjItemVatExemption] as 'VAdjNetAmt'
	  ,[ItemGrossPrice]-[ItemGrossPrice]+[AdjExtAmt] as 'VAdjExtAmt'
	  ,iif([VatAmt]=0,0,([ItemGrossPrice]-[ItemGrossPrice]+[AdjExtAmt])*0.05) as 'VAdjustedVatAmt'
	  ,iif([TInvVatExemption]=0,
			0,
			iif([VatAmt]=0,
				0,
				([ItemGrossPrice]-[ItemGrossPrice]+[AdjExtAmt])*0.05
			   )
		  ) As 'VAdjVatExemption'
  FROM [iGroupClinic].[dbo].[AllInvoicesVatAdjusted2_View]
)