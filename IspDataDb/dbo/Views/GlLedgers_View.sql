













CREATE   VIEW [dbo].[GlLedgers_View]	
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
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[InvoiceNo] AS 'DocumentNumber'
	  ,[SupplierName] AS 'PayDescription'
	  ,[SupplierNameAra] AS 'PayDescriptionAra'
  FROM [dbo].[ApJournalItem] a
  LEFT OUTER JOIN dbo.[ApJournal] b
  on a.JournalIdNo = b.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] c
  on b.SupplierIdNo = c.IdNo 
)
UNION
(SELECT 'AR' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
      ,[ProfitCenterIdNo]
      ,a.[Notes]
      ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[InvoiceNo] AS 'DocumentNumber'
	  ,[CustomerName]
	  ,[CustomerNameAra]
  FROM [dbo].[ArJournalItem] a
  LEFT OUTER JOIN dbo.ArJournal b
  on a.JournalIdNo = b.IdNo 
  LEFT OUTER JOIN dbo.[Customer] c
  on b.CustomerIdNo = c.IdNo 
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
  FROM [dbo].[CheckDisbursementJournalItem] a
  LEFT OUTER JOIN dbo.CheckDisbursementJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IDNo 
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
  FROM [dbo].[CashDisbursementJournalItem] a
  LEFT OUTER JOIN dbo.CashDisbursementJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IDNo 
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
      ,a.[Notes]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,Case
		When [ORNUMBER] IS NULL AND [CheckNumber] IS NULL Then ''
		When [ORNUMBER] IS NULL Then 'Chk#'+RTrim([CheckNumber])
		ELSE 'OR# ' + RTrim([ORNUMBER]) + ' / Chk#' + RTrim([CheckNumber])
	   End
	  ,CASE
			WHEN b.PayorType = 'A' then s.SupplierName
			WHEN b.PayorType = 'C' then c.CustomerName
			WHEN b.PayorType = 'R' then s.SupplierName
			WHEN b.PayorType = 'E' then e.EmployeeName
			WHEN b.PayorType = 'O' then b.PayorName
			ELSE b.PayorName
	   END
	  ,CASE
			WHEN b.PayorType = 'A' then s.SupplierNameAra
			WHEN b.PayorType = 'C' then c.CustomerNameAra
			WHEN b.PayorType = 'R' then s.SupplierNameAra
			WHEN b.PayorType = 'E' then e.EmployeeNameAra
			WHEN b.PayorType = 'O' then b.PayorName
			ELSE b.PayorName
	   END
  FROM [dbo].[CashReceiptJournalItem] a
  LEFT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayorIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayorIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayorIdNo = e.IDNo 
)
UNION
(SELECT 'GJ'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[ProfitCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,''
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
  FROM [dbo].[GeneralJournalItem] a
  LEFT OUTER JOIN dbo.GeneralJournal b
  on a.JournalIdNo = b.IdNo
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
  FROM [dbo].[PettyCashJournalItem] a
  LEFT OUTER JOIN dbo.PettyCashJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IDNo 
)
UNION
(SELECT 'SJ'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[ProfitCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,''
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
  FROM [dbo].[SalesJournalItem] a
  LEFT OUTER JOIN dbo.SalesJournal b
  on a.JournalIdNo = b.Idno
)
