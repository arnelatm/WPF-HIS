
CREATE VIEW [dbo].[GlLedgersEmployee_View]	
  AS
(SELECT 'ER' Collate SQL_Latin1_General_CP1_CI_AS as 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
      ,a.[RevCostCenterIdNo]
      ,Concat(a.[Notes],' ',b.[Notes]) COLLATE Arabic_CI_AS AS 'Notes'
      ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo] COLLATE Arabic_CI_AS as 'ReferenceNo'
	  ,b.EmployeeIdNo
  FROM [dbo].[ErJournalItem] a
  LEFT OUTER JOIN dbo.ErJournal b
  on a.JournalIdNo = b.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.EmployeeIdNO = e.IdNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
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
      ,Concat(a.[Notes],' ',b.[Notes]) COLLATE Arabic_CI_AS AS 'Notes'
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo] COLLATE Arabic_CI_AS
	  ,b.PayeeIdNo
  FROM [dbo].[CkJournalItem] a
  LEFT OUTER JOIN dbo.CkJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IDNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
  where b.PaymentType = 'E'
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
      ,Concat(a.[Notes] ,' ',b.[Notes]) COLLATE Arabic_CI_AS AS 'Notes'
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo] COLLATE Arabic_CI_AS
	  ,b.PayeeIdNo
  FROM [dbo].[CdJournalItem] a
  LEFT OUTER JOIN dbo.CdJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IDNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
  where b.PaymentType = 'E'
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
      ,Concat(a.[Notes],' ',b.[Notes]) COLLATE Arabic_CI_AS AS 'Notes'
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo] COLLATE Arabic_CI_AS
	  ,b.PayorIdNo
  FROM [dbo].[CashReceiptJournalItem] a
  LEFT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayorIdNo = e.IDNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
  where b.PayorType = 'E'
)
UNION
(SELECT 'PC' COLLATE SQL_Latin1_General_CP1_CI_AS
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,a.[RevCostCenterIdNo]
      ,Concat(a.[Notes] ,' ',b.[Notes]) COLLATE Arabic_CI_AS AS 'Notes'
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo] COLLATE Arabic_CI_AS
	  ,b.PayeeIdNo
  FROM [dbo].[PcJournalItem] a
  LEFT OUTER JOIN dbo.PcJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IDNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
  where b.PaymentType = 'E'
)

GO

