










CREATE VIEW [dbo].[VatAdjustedInvoices_View]
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
	  ,[AdjItemDiscount]    
	  ,[ItemGrossPrice] -[AdjItemDiscount] + [VATAmt] - [ItemVatExemption] as 'AdjExtPlusVat'
	  ,iif([VATAmt]=0,0,([ItemGrossPrice] -[AdjItemDiscount] + [VATAmt] )/1.05*.05) as 'AdjItemVat'
	  ,iif(iif([VATAmt]=0,0,([ItemGrossPrice] -[AdjItemDiscount] + [VATAmt] )/1.05*.05)=0,0,iif([VATAmt]=0,0,([ItemGrossPrice] -[AdjItemDiscount] + [VATAmt] )/1.05*.05)) as 'AdjItemVatExemption'
	  ,[ItemGrossPrice] -[AdjItemDiscount] + [VATAmt] - iif([VATAmt]=0,0,([ItemGrossPrice] -[AdjItemDiscount] + [VATAmt])/1.05*.05) as 'AdjExtAmt'
  FROM AllInvoicesVatAdjusted_View
  )