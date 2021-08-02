

















CREATE VIEW [dbo].[ARDetails_View]	
  AS
With FirstRecord(FirstRecordDate) as (Select LastPostingDate from LastPosting where TransactionName = 'First Record')
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
	  ,DueDate
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
      ,Concat(LTrim(a.[Notes]),IIf([CheckNumber]='','',' Chk#'+[CheckNumber]))
	  ,a.[Posted]
	  ,[PayorIdNo]
	  ,[ORNumber]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'P'
	  ,Concat(LTrim(b.Notes),IIf([CheckNumber]='','',' Chk#'+[CheckNumber])) AS 'MainNote'
	  ,[TransactionDate]
  FROM [dbo].[CashReceiptJournalItem] A
  RIGHT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PayorType='A'
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
	  ,[ORNumber]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'R'
	  ,b.Notes AS 'MainNote'
	  ,[TransactionDate]
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
	  ,[ORNumber]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'R'
	  ,b.Notes AS 'MainNote'
	  ,[TransactionDate]
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
	  ,(Select FirstRecordDate from FirstRecord)
      ,'Beg.Bal.'
	  ,'B'
	  ,'Beginning Balance'
	  ,(Select FirstRecordDate from FirstRecord)
  FROM [dbo].Customer 
)
