

CREATE VIEW [dbo].[ARDetails_View]	
  AS
(SELECT 'AR' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
      ,[ProfitCenterIdNo]
      ,a.[Notes]
      ,a.[Posted]
	  ,[CustomerIdNo]
	  ,[InvoiceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[TransactionType]
	  ,b.Notes AS 'MainNote'
  FROM [ISPDATA].[dbo].[ArJournalItem] a
  RIGHT OUTER JOIN dbo.ArJournal b
  on a.JournalIdNo = b.IDNo 
)
UNION
(SELECT 'CR'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[ProfitCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayorIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PayorType]
	  ,b.Notes AS 'MainNote'
  FROM [ISPDATA].[dbo].[CashReceiptJournalItem] A
  RIGHT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PayorType='A'
)
UNION
(SELECT 'CK'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[ProfitCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [ISPDATA].[dbo].[CheckDisbursementJournalItem] A
  LEFT OUTER JOIN dbo.CheckDisbursementJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='R'
)
UNION
(SELECT 'CD'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[ProfitCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [ISPDATA].[dbo].[CashDisbursementJournalItem] A
  LEFT OUTER JOIN dbo.CashDisbursementJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='R'
)
UNION
(SELECT 'PC'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[ProfitCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [ISPDATA].[dbo].[PettyCashJournalItem] A
  LEFT OUTER JOIN dbo.PettyCashJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='R'
)
