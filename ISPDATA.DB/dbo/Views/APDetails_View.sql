

CREATE VIEW [dbo].[APDetails_View]	
  AS
(SELECT 'AP' AS 'JournalCode'
	  ,apj.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,apj.[AccountIdNo]
      ,[Debit]
      ,[Credit]
      ,[ProfitCenterIdNo]
      ,apj.[Notes]
      ,apj.[Posted]
	  ,[SupplierIdNo]
	  ,[InvoiceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[TransactionType]
	  ,b.Notes AS 'MainNote'
  FROM [ISPDATA].[dbo].[ApJournalItem] apj
  LEFT OUTER JOIN dbo.ApJournal b
  on a.JournalIdNo = b.IDNo 
)
UNION
(SELECT 'CK'
	  ,cki.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,cki.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[ProfitCenterIdNo]
      ,cki.[Notes]
	  ,cki.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,ck.Notes AS 'MainNote'
  FROM [ISPDATA].[dbo].[CheckDisbursementJournalItem] cki
  LEFT OUTER JOIN dbo.CheckDisbursementJournal ck
  on cki.JournalIdNo = ck.IDNo
  WHERE PaymentType='A'
)
UNION
(SELECT 'CD'
	  ,cdi.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,cdi.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[ProfitCenterIdNo]
      ,cdi.[Notes]
	  ,cdi.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,cd.Notes AS 'MainNote'
  FROM [ISPDATA].[dbo].[CashDisbursementJournalItem] cdi
  LEFT OUTER JOIN dbo.CashDisbursementJournal cd
  on cdi.JournalIdNo = cd.IDNo
  WHERE PaymentType='A'
)
UNION
(SELECT 'PC'
	  ,pci.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,pci.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[ProfitCenterIdNo]
      ,pci.[Notes]
	  ,pci.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,pc.Notes AS 'MainNote'
  FROM [ISPDATA].[dbo].[PettyCashJournalItem] pci
  LEFT OUTER JOIN dbo.PettyCashJournal pc
  on pci.JournalIdNo = pc.IDNo
  WHERE PaymentType='A'
)
UNION
(SELECT 'CR'
	  ,cri.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,cri.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[ProfitCenterIdNo]
      ,cri.[Notes]
	  ,cri.[Posted]
	  ,[PayorIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PayorType]
	  ,cr.Notes AS 'MainNote'
  FROM [ISPDATA].[dbo].[CashReceiptJournalItem] cri
  LEFT OUTER JOIN dbo.CashReceiptJournal cr
  on cri.JournalIdNo = cr.IDNo
  WHERE PayorType='A'
)
