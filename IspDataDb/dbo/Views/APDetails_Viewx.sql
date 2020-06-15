
CREATE VIEW [dbo].[APDetails_Viewx]	
  AS
(SELECT 'AP' AS 'JournalCode'
	  ,ai.[IdNo]
      ,ai.[Sequence]
      ,ai.[JournalIdNo]
      ,ai.[AccountIdNo]
      ,ai.[Debit]
      ,ai.[Credit]
      ,ai.[ProfitCenterIdNo]
      ,ai.[Notes]
      ,ai.[Posted]
	  ,b.[SupplierIdNo]
	  ,b.[InvoiceNo]
	  ,b.[TransactionDate]
      ,b.[ReferenceNo]
	  ,b.[TransactionType]
	  ,b.Notes AS 'MainNote'
  FROM [ApJournalItem] aS ai
  LEFT OUTER JOIN ApJournal AS b
  on ai.JournalIdNo = b.IDNo 
)
UNION
(SELECT 'CK'
	  ,ai.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,ai.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[ProfitCenterIdNo]
      ,ai.[Notes]
	  ,ai.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [CheckDisbursementJournalItem] ai
  LEFT OUTER JOIN CheckDisbursementJournal b
  on ai.JournalIdNo = b.IDNo
  WHERE PaymentType='A'
)
UNION
(SELECT 'CD'
	  ,ai.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,ai.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[ProfitCenterIdNo]
      ,ai.[Notes]
	  ,ai.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [CashDisbursementJournalItem] ai
  LEFT OUTER JOIN dbo.CashDisbursementJournal b
  on ai.JournalIdNo = b.IDNo
  WHERE PaymentType='A'
)
UNION
(SELECT 'PC'
	  ,ai.[IdNo]
      ,ai.[Sequence]
	  ,ai.[JournalIdNo]
      ,ai.[AccountIdNo]
      ,ai.[Debit]
      ,ai.[Credit]
	  ,ai.[ProfitCenterIdNo]
      ,ai.[Notes]
	  ,ai.[Posted]
	  ,b.[PayeeIdNo]
	  ,b.[ReferenceNo]
	  ,b.[TransactionDate]
      ,b.[ReferenceNo]
	  ,b.[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [PettyCashJournalItem] as ai
  LEFT OUTER JOIN PettyCashJournal as b
  on ai.JournalIdNo = b.IDNo
  WHERE PaymentType='A'
)
UNION
(SELECT 'CR'
	  ,ai.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,ai.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[ProfitCenterIdNo]
      ,ai.[Notes]
	  ,ai.[Posted]
	  ,[PayorIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PayorType]
	  ,b.Notes AS 'MainNote'
  FROM [CashReceiptJournalItem] as ai
  LEFT OUTER JOIN dbo.CashReceiptJournal as b
  on ai.JournalIdNo = b.IDNo
  WHERE PayorType='R'
)