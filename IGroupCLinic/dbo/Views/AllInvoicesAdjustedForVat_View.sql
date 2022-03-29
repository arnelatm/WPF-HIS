












CREATE VIEW [dbo].[AllInvoicesAdjustedForVat_View]
  AS
/****** Script for SelectTopNRows command from SSMS  ******/
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
	  ,[IqamaNo]
	  ,[AdjExtendedAmtPlusVat] as 'AdjExtPlusVat'
	  ,iif([TInvVatExemption]<>0,
	       [VATAmt],
		   iif([VATAmt]=0,
		       0,
			   [AdjExtendedAmtPlusVat]/1.05*0.05
			  )
		  ) as 'AdjItemVat'
	  ,iif([TInvVatExemption]=0,
			0,
			iif([TInvVatExemption]<>0,
				[VATAmt],
				iif([VATAmt]=0,
					0,
					[ItemNetAmount]-[AdditionalItemDiscount]/1.05*0.05
					)
				)
			) As 'AdjItemVatExemption'
	  ,[AdjExtendedAmtPlusVat] - iif([TInvVatExemption]<>0,
									 [VATAmt],
									 iif([VATAmt]=0,
										 0,
										[AdjExtendedAmtPlusVat]/1.05*0.05
										)
									) As 'AdjExtAmt'
  FROM AllInvoicesVatAdjusted_View
  )







