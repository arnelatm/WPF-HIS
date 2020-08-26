















CREATE VIEW [dbo].[ARInvoices_View]	
  AS
(SELECT 'AR' AS 'JournalCode'
	  ,a.[IdNo] 
      ,a.[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit] as 'Amount'
	  ,b.[CustomerIdNo]
	  ,b.[InvoiceNo] COLLATE Arabic_CI_AS AS 'InvoiceNo'
	  ,b.[TransactionDate]
      ,b.[ReferenceNo] COLLATE Arabic_CI_AS AS 'ReferenceNo'
  FROM [dbo].[ArJournalItem] a
  RIGHT OUTER JOIN dbo.ArJournal b
  on a.JournalIdNo = b.IDNo 
  LEFT Outer Join [dbo].[Chart] c
  on a.AccountIdNo = c.idno
  where c.SpecialAccount='AR'
)
UNION
(SELECT 'CR'
	  ,a.[IdNo]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit]
	  ,[PayorIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
  FROM [dbo].[CashReceiptJournalItem] A
  RIGHT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IDNo
  LEFT Outer Join [dbo].[Chart] c
  on a.AccountIdNo = c.idno 
  WHERE PayorType='A' AND B.UnApplied<>0 and (c.SpecialAccount='CA' OR c.SpecialAccount='AR')
)
UNION
(SELECT 'CK'
	  ,a.[IdNo]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]  
  FROM [dbo].[CheckDisbursementJournalItem] A
  LEFT OUTER JOIN dbo.CheckDisbursementJournal b
  on a.JournalIdNo = b.IDNo
  LEFT Outer Join [dbo].[Chart] c
  on a.AccountIdNo = c.idno
  WHERE PaymentType='R' AND C.SpecialAccount='AR'
)
UNION
(SELECT 'CD'
	  ,a.[IdNo]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
  FROM [dbo].[CashDisbursementJournalItem] A
  LEFT OUTER JOIN dbo.CashDisbursementJournal b
  on a.JournalIdNo = b.IDNo
  LEFT Outer Join [dbo].[Chart] c
  on a.AccountIdNo = c.idno
  WHERE PaymentType='R' AND c.SpecialAccount='AR'
)
UNION
(SELECT 'PC'
	  ,a.[IdNo]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
  FROM [dbo].[PettyCashJournalItem] A
  LEFT OUTER JOIN dbo.PettyCashJournal b
  on a.JournalIdNo = b.IDNo
  LEFT Outer Join [dbo].[Chart] c
  on a.AccountIdNo = c.idno
  WHERE PaymentType='R' AND c.SpecialAccount='AR'
)
UNION
(SELECT 'BB' 
	  ,IdNo
      ,1
      ,(Select AccountIdNo from DefaultAccounts where SpecialAccount='AR')
      ,OpeningBalance
	  ,IdNo
	  ,'Beg.Bal.'
	  ,(Select LastPostingDate from LastPosting where TransactionName = 'First Record')
      ,'Beg.Bal.'
   FROM [dbo].Customer 
)