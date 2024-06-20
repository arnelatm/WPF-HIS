

CREATE VIEW [dbo].[InvoicesVatAdjusted_View]
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
	  ,[iTemVatExemption]
      ,[Series]
	  ,[IqamaNo]
	  ,[CountryName]
	  ,Round(iif(TBillAmt=0,
	             itemGrossPrice,
	             iif(invGrossAmt=0,
				     0,
					 iif([AdjInvExtraDisc]<0,
					     0,
						 ItemGrossPrice/InvGrossAmt*[AdjInvExtraDisc]
						)
					)
				),2
			 ) 
			 AS 'AdditionalItemDiscount' 
      ,Round(iif(TBillAmt=0,
	             itemGrossPrice,
	             iif(invGrossAmt=0,
				     0,
					 iif([AdjInvExtraDisc]<0,
					     0,
						 ItemGrossPrice/InvGrossAmt*[AdjInvExtraDisc]
						)
					) + ItemDiscountAmt
				),2
			 ) 
			 AS 'AdjItemDiscount',
	IIf([TBillAmt]=0,
		0,
		ItemNetAmount+VatAmt-
				  Round(iif(TBillAmt=0,
							itemGrossPrice,
							iif(invGrossAmt=0,
								0,
								iif([AdjInvExtraDisc]<0,
									0,
									ItemGrossPrice/InvGrossAmt*[AdjInvExtraDisc]
									)
								)
							),2
						))
			AS 'AdjExtendedAmtPlusVat'	 
  FROM AllInvoicesDetailsComplete_View)