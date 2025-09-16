


CREATE VIEW [dbo].[GlLedgersSummmary_View]	
  AS
(SELECT 'GJ' Collate SQL_Latin1_General_CP1_CI_AS AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.[AccountCode]
      ,a.[Debit]
      ,a.[Credit]
	  ,a.[RevCostCenterIdNo]
	  ,a.[Posted]
	  ,b.[TransactionDate] 
	  ,[ClosingJournal]
  FROM [dbo].[GeneralJournalItem] a
  LEFT OUTER JOIN dbo.GeneralJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
  where b.Cancelled = 0
)
UNION
(SELECT 'AP' Collate SQL_Latin1_General_CP1_CI_AS
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
      ,a.[RevCostCenterIdNo]
      ,a.[Posted]
	  ,[TransactionDate]
      ,CAST(0 AS BIT) 
  FROM [dbo].[ApJournalItem] a
  LEFT OUTER JOIN dbo.[ApJournal] b
  on a.JournalIdNo = b.IdNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
  where b.Cancelled = 0
)
UNION
(SELECT 'AR' Collate SQL_Latin1_General_CP1_CI_AS
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
      ,a.[RevCostCenterIdNo]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,CAST(0 AS BIT)
  FROM [dbo].[ArJournalItem] a
  LEFT OUTER JOIN dbo.ArJournal b
  on a.JournalIdNo = b.IdNo 
  LEFT OUTER JOIN dbo.[Customer] c
  on b.CustomerIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
  where b.Cancelled = 0
)
UNION
(SELECT 'ER' Collate SQL_Latin1_General_CP1_CI_AS
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
      ,a.[RevCostCenterIdNo]
      ,a.[Posted]
	  ,[TransactionDate]
      ,CAST(0 AS BIT)
  FROM [dbo].[ErJournalItem] a
  LEFT OUTER JOIN dbo.ErJournal b
  on a.JournalIdNo = b.IdNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
  where b.Cancelled = 0
)
UNION
(SELECT 'CK' Collate SQL_Latin1_General_CP1_CI_AS
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,a.[RevCostCenterIdNo]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,CAST(0 AS BIT)	
  FROM [dbo].[CkJournalItem] a
  LEFT OUTER JOIN dbo.CkJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IDNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
  where b.Cancelled = 0
)
UNION
(SELECT 'CD' Collate SQL_Latin1_General_CP1_CI_AS
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,a.[RevCostCenterIdNo]
      ,a.[Posted]
	  ,[TransactionDate]
      ,CAST(0 AS BIT)  
  FROM [dbo].[CdJournalItem] a
  LEFT OUTER JOIN dbo.CdJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
  where b.Cancelled = 0
)
UNION
(SELECT 'CR' Collate SQL_Latin1_General_CP1_CI_AS
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,a.[RevCostCenterIdNo]
      ,a.[Posted]
	  ,[TransactionDate]
      ,CAST(0 AS BIT)
  FROM [dbo].[CashReceiptJournalItem] a
  LEFT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
  where b.Cancelled = 0
)
UNION
(SELECT 'PC'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,a.[RevCostCenterIdNo]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,CAST(0 AS BIT)  
  FROM [dbo].[PcJournalItem] a
  LEFT OUTER JOIN dbo.PcJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
  where b.Cancelled = 0
)
UNION
(SELECT 'SJ'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,a.[RevCostCenterIdNo]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,CAST(0 AS BIT)	  
  FROM [dbo].[SalesJournalItem] a
  LEFT OUTER JOIN dbo.SalesJournal b
  on a.JournalIdNo = b.Idno
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
  where b.Cancelled = 0
)