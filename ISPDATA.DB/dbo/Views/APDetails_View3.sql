






CREATE VIEW [dbo].[APDetails_View3]	
  AS
(SELECT 'AP' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
      ,[ProfitCenterIdNo]
      ,a.[Notes]
      ,a.[Posted]
	  ,[SupplierIdNo]
	  ,[InvoiceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[TransactionType]
  FROM [ISPDATA].[dbo].[ApJournalItem] a
  RIGHT OUTER JOIN dbo.ApJournal b
  on a.JournalIdNo = b.IDNo 
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
  FROM [ISPDATA].[dbo].[CheckDisbursementJournalItem] A
  RIGHT OUTER JOIN dbo.CheckDisbursementJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='A'
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
  FROM [ISPDATA].[dbo].[CashDisbursementJournalItem] A
  RIGHT OUTER JOIN dbo.CashDisbursementJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='A'
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
  FROM [ISPDATA].[dbo].[PettyCashJournalItem] A
  RIGHT OUTER JOIN dbo.PettyCashJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='A'
)
