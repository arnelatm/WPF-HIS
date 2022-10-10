
CREATE VIEW [dbo].[ArCollections_View] as
SELECT TOP (1000) a.[IdNo]
      ,[JournalCode]
      ,[JournalIdNo]
      ,[JournalItemIdNo]
      ,IsNull(sum(b.amount),0) as 'PaidAmount'
	  ,IsNull(sum(b.DiscountTaken) ,0) as 'DiscountTaken'
  FROM [dbo].[ArOpenInvoice] a
  left join CsrOiItem b
  on a.IdNo = b.ArOpenInvoiceIdNo
  group by a.IdNo,a.JournalCode,a.JournalIdNo, a.JournalItemIdNo