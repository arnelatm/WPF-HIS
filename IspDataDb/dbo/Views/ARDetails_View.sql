











CREATE VIEW [dbo].[ARDetails_View]	
  AS
(SELECT 'AR' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
      ,[RevCostCenterIdNo]
      ,a.[Notes] COLLATE Arabic_CI_AS AS 'Notes'
      ,a.[Posted]
	  ,[CustomerIdNo]
	  ,[InvoiceNo] COLLATE Arabic_CI_AS AS 'InvoiceNo'
	  ,[TransactionDate]
      ,[ReferenceNo] COLLATE Arabic_CI_AS AS 'ReferenceNo'
	  ,[TransactionType] COLLATE SQL_Latin1_General_CP1_CI_AS AS 'TransactionType'
	  ,b.Notes COLLATE Arabic_CI_AS AS 'MainNote'
  FROM [dbo].[ArJournalItem] a
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
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayorIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PayorType]
	  ,b.Notes AS 'MainNote'
  FROM [dbo].[CashReceiptJournalItem] A
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
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [dbo].[CkJournalItem] A
  LEFT OUTER JOIN dbo.CkJournal b
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
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [dbo].[CdJournalItem] A
  LEFT OUTER JOIN dbo.CdJournal b
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
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [dbo].[PcJournalItem] A
  LEFT OUTER JOIN dbo.PcJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='R'
)
UNION
(SELECT 'BB' 
	  ,IdNo
      ,1
      ,IdNo
      ,(Select AccountIdNo from DefaultAccounts where SpecialAccount='AR')
      ,case 
		when OpeningBalance >=0 then OpeningBalance
		else 0
	   end 
      ,case 
		when OpeningBalance < 0 then OpeningBalance * -1
		else 0
	   end 
	  ,0
      ,'Beginning Balance'
      ,1
	  ,IdNo
	  ,'Beg.Bal.'
	  ,(Select LastPostingDate from LastPosting where TransactionName = 'First Record')
      ,'Beg.Bal.'
	  ,case 
		when OpeningBalance >=0 then 'D'
		else 'C'
	   end 
	  ,'Beginning Balance'
  FROM [dbo].Customer 
)
