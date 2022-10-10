/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW ApPayments_View AS 
SELECT [ApOpenInvoiceIdNo]
      ,Sum([Amount]) AS 'Amount'
      ,Sum([DiscountTaken]) AS 'DiscountTaken'
  FROM [dbo].[ApPaymentItems_View]
  GROUP BY apopeninvoiceidno