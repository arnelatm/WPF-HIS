
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
      ,[DjIdNo]
      ,[ApOpenInvoiceIdNo]
      ,[Sequence]
      ,[Amount]
      ,[DiscountTaken]
  FROM [dbo].[CkOiItem]
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
