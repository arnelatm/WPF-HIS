

CREATE VIEW [dbo].[LabTestsDone_View] as
  SELECT [InvSource]
      ,[ItemCode]
  	  ,MS.ServiceNameEnglish
	  ,MS.CostCentre
      ,[Group_Key]
      ,[InvoiceType]
      ,[SaleType]
      ,INV.BranchID
      ,[RowNbr]
      ,[Qty]
      ,[Unit]
      ,[PcsQty]
      ,[SalePrice]
      ,[ItemDiscountAmt]
      ,INV.VATPercent
      ,[VATAmt]
      ,[TransNbr]
      ,[TransDateEnglish]
      ,[InvNormalDiscount]
      ,[InvExtraDiscount]
      ,[InvRoundoffAmt]
      ,[InvVatAmt]
      ,[InvVatExemption]
      ,[BillAmt]
      ,[Rejected]
      ,inv.UserID
      ,[DoctorID]
      ,[RegistrationNo]
      ,[RegistrationType]
  FROM [iGroupClinic].[dbo].[AllInvoicesDetails_View] as INV
  left join MedicalServices as MS
  on INV.ItemCode = MS.ServiceID
  WHERE MS.CostCentre = '201' or ms.costcentre = '301' AND INV.BRANCHID='02' and Rejected = 0


