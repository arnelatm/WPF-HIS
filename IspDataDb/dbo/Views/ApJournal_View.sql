
CREATE VIEW [dbo].[ApJournal_View]
AS
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) a.[IDNo]
      ,a.[SupplierIdNo]
      ,a.[TransactionDate]
      ,a.[ReferenceNo]
      ,a.[TransactionType]
      ,a.[Amount]
      ,a.[AccountIdNo]
      ,a.[DueDate]
      ,a.[SettlementDueDate]
      ,a.[SettlementDiscount]
      ,a.[InvoiceNo]
      ,a.[InvoiceDate]
      ,a.[VatNumber]
      ,a.[VatAmount]
      ,a.[Notes]
      ,a.[Posted]
      ,a.[Cancelled]
      ,a.[DateCreated]
      ,a.[DateTimeStamp]
	  ,dbo.currency_conversion(a.Amount) AS WordAmount
	  ,s.SupplierCode
	  ,s.SupplierNameAra
  FROM [dbo].[ApJournal] a
  Left JOIN dbo.Supplier s
  ON SupplierIdNo = s.IdNo
