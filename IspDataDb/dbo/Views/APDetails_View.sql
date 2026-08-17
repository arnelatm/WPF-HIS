
























CREATE VIEW [dbo].[APDetails_View]	
  AS
With FirstRecord(FirstRecordDate) as (Select LastPostingDate from LastPosting where TransactionName = 'Oldest Record')
(SELECT 'AP' AS 'JournalCode'
	  ,ai.[IdNo]
      ,ai.[Sequence]
      ,ai.[JournalIdNo]
      ,ai.[AccountIdNo]
      ,ai.[Debit]
      ,ai.[Credit]
      ,ai.[RevCostCenterIdNo]
      ,ai.[Notes] Collate Arabic_CI_AS AS 'Notes'
      ,ai.[Posted]
	  ,b.[SupplierIdNo]
	  ,b.[InvoiceNo] Collate Arabic_CI_AS AS 'InvoiceNo'
	  ,b.[TransactionDate]
      ,b.[ReferenceNo] Collate Arabic_CI_AS AS 'ReferenceNo'
	  ,b.[TransactionType] Collate SQL_Latin1_General_CP1_CI_AS AS 'TransactionType'
	  ,b.Notes Collate Arabic_CI_AS AS 'MainNote'
	  ,0 as 'DiscountTaken'
	  ,b.DueDate
  FROM [ApJournalItem] aS ai
  LEFT OUTER JOIN ApJournal AS b
  on ai.JournalIdNo = b.IDNo 
  where b.Cancelled = 0
)
UNION
(SELECT 'CD'
	  ,ai.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,ai.[AccountIdNo]
      ,ai.[Debit]
      ,ai.[Credit]
	  ,[RevCostCenterIdNo]
      ,ai.[Notes]
	  ,ai.[Posted]
	  ,[PayeeIdNo]
	  ,[ORNumber]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'P'
	  ,b.Notes AS 'MainNote'
	  ,b.DiscountTaken
	  ,[TransactionDate]
  FROM [CdJournalItem] ai
  LEFT OUTER JOIN dbo.CdJournal b
  on ai.JournalIdNo = b.IDNo
  WHERE PaymentType='A' and b.Cancelled = 0
)
UNION
(SELECT 'PC'
	  ,ai.[IdNo]
      ,ai.[Sequence]
	  ,ai.[JournalIdNo]
      ,ai.[AccountIdNo]
      ,ai.[Debit]
      ,ai.[Credit]
	  ,ai.[RevCostCenterIdNo]
      ,ai.[Notes]
	  ,ai.[Posted]
	  ,b.[PayeeIdNo]
	  ,b.[ORNumber]
	  ,b.[TransactionDate]
      ,b.[ReferenceNo]
	  ,'P'
	  ,b.Notes AS 'MainNote'
	  ,b.DiscountTaken
	  ,[TransactionDate]
  FROM [PcJournalItem] as ai
  LEFT OUTER JOIN PcJournal as b
  on ai.JournalIdNo = b.IDNo
  WHERE PaymentType='A' and b.Cancelled = 0
)
UNION
(SELECT 'CR'
	  ,ai.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,ai.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,Concat(LTrim(ai.[Notes]),IIf(CheckNumber='','',' Chk#'+[CheckNumber]))
	  ,ai.[Posted]
	  ,[PayorIdNo]
	  ,[ORNumber]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'R'
	  ,Concat(LTrim(b.Notes),IIf(CheckNumber='','',' Chk#'+[CheckNumber])) AS 'MainNote'
	  ,b.[DiscountTaken]
	  ,[TransactionDate]
  FROM [CashReceiptJournalItem] as ai
  LEFT OUTER JOIN dbo.CashReceiptJournal as b
  on ai.JournalIdNo = b.IDNo
  WHERE PayorType='R' and b.Cancelled = 0
)
UNION
(SELECT 'BB' 
	  ,IdNo
      ,1
      ,IdNo
      ,(Select AccountIdNo from DefaultAccounts where SpecialAccount='AP')
      ,case 
		when OpeningBalance < 0 then OpeningBalance * -1
		else 0
	   end 
      ,case 
		when OpeningBalance >= 0 then OpeningBalance 
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
	  ,0
	  ,(Select FirstRecordDate from FirstRecord)
  FROM [dbo].Supplier 
)

GO

