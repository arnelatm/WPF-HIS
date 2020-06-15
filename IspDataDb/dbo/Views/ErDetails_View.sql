


CREATE VIEW [dbo].[ErDetails_View]	
  AS
(SELECT 'ER' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
      ,[ProfitCenterIdNo]
      ,a.[Notes] Collate Arabic_CI_AS As 'Notes'
      ,a.[Posted] 
	  ,[CustomerIdNo]
	  ,[InvoiceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[TransactionType]
	  ,b.Notes Collate Arabic_CI_AS AS 'MainNote'
  FROM [dbo].[ErJournalItem] a
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
      ,a.[Notes] Collate Arabic_CI_AS
	  ,a.[Posted]
	  ,[PayorIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PayorType] 
	  ,b.Notes Collate Arabic_CI_AS AS 'MainNote'
  FROM [dbo].[CashReceiptJournalItem] A
  RIGHT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PayorType='E'
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
      ,a.[Notes] Collate Arabic_CI_AS
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes Collate Arabic_CI_AS AS 'MainNote'
  FROM [dbo].[CheckDisbursementJournalItem] A
  LEFT OUTER JOIN dbo.CheckDisbursementJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='E'
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
      ,a.[Notes] Collate Arabic_CI_AS
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes Collate Arabic_CI_AS AS 'MainNote'
  FROM [dbo].[CashDisbursementJournalItem] A
  LEFT OUTER JOIN dbo.CashDisbursementJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='E'
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
      ,a.[Notes] Collate Arabic_CI_AS
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes Collate Arabic_CI_AS AS 'MainNote'
  FROM [dbo].[PettyCashJournalItem] A
  LEFT OUTER JOIN dbo.PettyCashJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='E'
)