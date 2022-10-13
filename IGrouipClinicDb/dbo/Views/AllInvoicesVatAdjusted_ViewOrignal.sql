







CREATE VIEW [dbo].[AllInvoicesVatAdjusted_ViewOrignal]
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
      ,Round(iif(TBillAmt=0,itemGrossPrice,iif(invGrossAmt=0,0,ItemGrossPrice/InvGrossAmt*[AdjInvExtraDisc])+ItemDiscountAmt),2) AS 'AdjItemDiscount'  	  	  
  FROM AllInvoicesDetailsComplete_View)