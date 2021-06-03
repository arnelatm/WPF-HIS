













CREATE View [dbo].[GLStatementNew_View] 
as 
( SELECT 'GJ' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.[AccountCode]
      ,a.[Debit]
      ,a.[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]  COLLATE Arabic_CI_AS AS 'Notes'
	  ,a.[Posted]
	  ,[TransactionDate] 
      ,[ReferenceNo] COLLATE Arabic_CI_AS AS 'ReferenceNo'
	  ,'' COLLATE Arabic_CI_AS AS 'DocumentNumber'
	  ,iif(a.[Notes] is Null or a.[Notes] = '',b.Notes,a.Notes) COLLATE Arabic_CI_AS AS 'PayDescription'
	  ,iif(a.[Notes] is Null or a.[Notes] = '',b.Notes,a.Notes) COLLATE Arabic_CI_AS AS 'PayDescriptionAra'
	  ,[ClosingJournal]
  FROM [dbo].[GeneralJournalItem] a
  LEFT OUTER JOIN dbo.GeneralJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
UNION
(SELECT 'AP' 
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
      ,[RevCostCenterIdNo]
      ,iif(a.[Notes] is Null or a.[Notes] = '',b.Notes,a.Notes)
      ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo] 
	  ,[InvoiceNo] 
	  ,[SupplierName] 
	  ,[SupplierNameAra] 
	  ,CAST(0 AS BIT) 
  FROM [dbo].[ApJournalItem] a
  LEFT OUTER JOIN dbo.[ApJournal] b
  on a.JournalIdNo = b.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] c
  on b.SupplierIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
UNION
(SELECT 'AR' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
      ,[RevCostCenterIdNo]
      ,iif(a.[Notes] is Null or a.[Notes] = '',b.Notes,a.Notes)
      ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[InvoiceNo] AS 'DocumentNumber'
	  ,[CustomerName]
	  ,[CustomerNameAra]
	  ,CAST(0 AS BIT)
  FROM [dbo].[ArJournalItem] a
  LEFT OUTER JOIN dbo.ArJournal b
  on a.JournalIdNo = b.IdNo 
  LEFT OUTER JOIN dbo.[Customer] c
  on b.CustomerIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
UNION
(SELECT 'ER' 
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
      ,[RevCostCenterIdNo]
      ,iif(a.[Notes] is Null or a.[Notes] = '',b.Notes,a.Notes)
      ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[ReferenceNo] AS 'DocumentNumber'
	  ,[EmployeeName]
	  ,[EmployeeNameAra]
	  ,CAST(0 AS BIT)
  FROM [dbo].[ErJournalItem] a
  LEFT OUTER JOIN dbo.ErJournal b
  on a.JournalIdNo = b.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.EmployeeIdNO = e.IdNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
UNION
(SELECT 'CK'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,Coalesce('Chk#' + [CheckNumber],'')
	  ,CASE
			WHEN b.PaymentType = 'A' then s.SupplierName
			WHEN b.PaymentType = 'R' then c.CustomerName
			WHEN b.PaymentType = 'S' then s.SupplierName
			WHEN b.PaymentType = 'E' then e.EmployeeName
			WHEN b.PaymentType = 'O' then b.PayeeName
			ELSE b.PayeeName
	   END
	  ,CASE
			WHEN b.PaymentType = 'A' then s.SupplierNameAra
			WHEN b.PaymentType = 'R' then c.CustomerNameAra
			WHEN b.PaymentType = 'S' then s.SupplierNameAra
			WHEN b.PaymentType = 'E' then e.EmployeeNameAra
			WHEN b.PaymentType = 'O' then b.PayeeName
			ELSE b.PayeeName
	   END
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
)
UNION
(SELECT 'CD'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,[RevCostCenterIdNo]
      ,iif(a.[Notes] is Null or a.[Notes] = '',b.Notes,a.Notes)
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,Case
			WHEN b.PayType = '1' then 'Chk#' COLLATE Arabic_CI_AS + [ORNUMBER] COLLATE Arabic_CI_AS
			WHEN b.PayType = '2' then 'Inv#'+[ORNUMBER] 
			WHEN b.PayType = '3' then 'Inv#'+[ORNUMBER] 
	   End
	  ,CASE
			WHEN b.PaymentType = 'A' then s.SupplierName
			WHEN b.PaymentType = 'R' then c.CustomerName
			WHEN b.PaymentType = 'S' then s.SupplierName
			WHEN b.PaymentType = 'E' then e.EmployeeName
			WHEN b.PaymentType = 'O' then b.PayeeName
			ELSE b.PayeeName
	   END
	  ,CASE
			WHEN b.PaymentType = 'A' then s.SupplierNameAra
			WHEN b.PaymentType = 'R' then c.CustomerNameAra
			WHEN b.PaymentType = 'S' then s.SupplierNameAra
			WHEN b.PaymentType = 'E' then e.EmployeeNameAra
			WHEN b.PaymentType = 'O' then b.PayeeName
			ELSE b.PayeeName
	   END
	  ,CAST(0 AS BIT)
  FROM [dbo].[CdJournalItem] a
  LEFT OUTER JOIN dbo.CdJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IDNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
UNION
(SELECT 'CR'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,[RevCostCenterIdNo]
      ,iif(a.[Notes] is Null or a.[Notes] = '',b.Notes,a.Notes)
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,Case
		When [ORNUMBER] IS NULL AND [CheckNumber] IS NULL Then ''
		When [ORNUMBER] IS NULL Then 'Chk#'+RTrim([CheckNumber])
		ELSE 'OR# ' + RTrim([ORNUMBER]) + ' / Chk#' + RTrim([CheckNumber])
	   End
	  ,CASE
			WHEN b.PayorType = 'A' then c.CustomerName
			WHEN b.PayorType = 'C' then c.CustomerName
			WHEN b.PayorType = 'R' then s.SupplierName
			WHEN b.PayorType = 'E' then e.EmployeeName
			WHEN b.PayorType = 'O' then b.PayorName
			ELSE b.PayorName
	   END
	  ,CASE
			WHEN b.PayorType = 'A' then c.CustomerNameAra
			WHEN b.PayorType = 'C' then c.CustomerNameAra
			WHEN b.PayorType = 'R' then s.SupplierNameAra
			WHEN b.PayorType = 'E' then e.EmployeeNameAra
			WHEN b.PayorType = 'O' then b.PayorName
			ELSE b.PayorName
	   END
	  ,CAST(0 AS BIT)
  FROM [dbo].[CashReceiptJournalItem] a
  LEFT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayorIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayorIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayorIdNo = e.IDNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
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
	  ,[RevCostCenterIdNo]
	  ,iif(a.[Notes] is Null or a.[Notes] = '',b.Notes,a.Notes)
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'Inv#'+[ORNUMBER] 
	  ,CASE
			WHEN b.PaymentType = 'A' then s.SupplierName
			WHEN b.PaymentType = 'R' then c.CustomerName
			WHEN b.PaymentType = 'S' then s.SupplierName
			WHEN b.PaymentType = 'E' then e.EmployeeName
			WHEN b.PaymentType = 'O' then b.PayeeName
			ELSE b.PayeeName
	   END
	  ,CASE
			WHEN b.PaymentType = 'A' then s.SupplierNameAra
			WHEN b.PaymentType = 'R' then c.CustomerNameAra
			WHEN b.PaymentType = 'S' then s.SupplierNameAra
			WHEN b.PaymentType = 'E' then e.EmployeeNameAra
			WHEN b.PaymentType = 'O' then b.PayeeName
			ELSE b.PayeeName
	   END
	  ,CAST(0 AS BIT)
  FROM [dbo].[PcJournalItem] a
  LEFT OUTER JOIN dbo.PcJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IDNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
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
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,''
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
	  ,CAST(0 AS BIT)
  FROM [dbo].[SalesJournalItem] a
  LEFT OUTER JOIN dbo.SalesJournal b
  on a.JournalIdNo = b.Idno
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
UNION
(SELECT 'BB'
	  ,0
      ,0
	  ,0
      ,a.[AccountIdNo]
	  ,b.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,0
      ,'Beginning Balance'
	  ,1
	  ,datefromparts(year-1,12,31)
      ,'BB'
	  ,''
	  ,'Beginning Balance'
	  ,'Beginning Balance'
	  ,CAST(0 AS BIT)
  FROM [dbo].ACCOUNTBALANCE a
  JOIN ACCOUNT b
  on a.AccountIdno = b.idno
)