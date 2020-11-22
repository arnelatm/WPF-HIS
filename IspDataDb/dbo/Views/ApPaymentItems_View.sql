
CREATE VIEW [dbo].[ApPaymentItems_View] as
(SELECT [IdNo]
	  ,'CD' AS 'JournalCode'
      ,[DjIdNo] AS 'JournalIdNo'
      ,[ApOpenInvoiceIdNo] 
      ,[Sequence] 
      ,[Amount]
      ,[DiscountTaken]
  FROM [dbo].[CdOiItem]
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
      ,[DjIdNo]
      ,[ApOpenInvoiceIdNo]
      ,[Sequence]
      ,[Amount]
      ,[DiscountTaken]
  FROM [dbo].[PcOiItem]
)