CREATE VIEW dbo.[ApPaymentItems_View] as
(SELECT [IdNo]
	  ,'CD' AS 'JournalCode'
      ,[CadIdNo] AS 'JournalIdNo'
      ,[ApOpenInvoiceIdNo] 
      ,[Sequence] 
      ,[Amount]
      ,[DiscountTaken]
  FROM [dbo].[CadOiItem]
)
union
(SELECT [IdNo] 
	  ,'CK'
      ,[CkdIdNo]
      ,[ApOpenInvoiceIdNo]
      ,[Sequence]
      ,[Amount]
      ,[DiscountTaken]
  FROM [dbo].[CkdOiItem]
)
UNION
(SELECT [IdNo]
	  ,'PC'
      ,[PcsIdNo]
      ,[ApOpenInvoiceIdNo]
      ,[Sequence]
      ,[Amount]
      ,[DiscountTaken]
  FROM [dbo].[PcsOiItem]
)