USE [ISPDATA]
GO
/****** Object:  View [dbo].[ARDetails_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





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
      ,a.[Notes]
      ,a.[Posted]
	  ,[CustomerIdNo]
	  ,[InvoiceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[TransactionType]
  FROM [ISPDATA].[dbo].[ArJournalItem] a
  RIGHT OUTER JOIN dbo.ArJournal b
  on a.JournalIdNo = b.IdNo 
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
  FROM [ISPDATA].[dbo].[CashReceiptJournalItem] A
  RIGHT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IdNo
  WHERE PayorType='A'
)
GO
/****** Object:  View [dbo].[ArOpenInvoice_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ArOpenInvoice_View]
AS
SELECT			dbo.ArOpenInvoice.IdNo, dbo.ArOpenInvoice.JournalCode, dbo.ArOpenInvoice.JournalItemIdNo, dbo.ARDetails_View.Debit - dbo.ARDetails_View.Credit AS Amount, dbo.ArOpenInvoice.PaidAmount, 
                dbo.ArOpenInvoice.DiscountTaken, dbo.ARDetails_View.Debit - dbo.ARDetails_View.Credit - dbo.ArOpenInvoice.PaidAmount - dbo.ArOpenInvoice.DiscountTaken AS Balance, 
                dbo.ARDetails_View.Debit - dbo.ARDetails_View.Credit AS InvoiceAmount, dbo.ArOpenInvoice.JournalIdNo, dbo.ARDetails_View.AccountIdNo, dbo.ARDetails_View.CustomerIdNo, 
                dbo.ARDetails_View.ReferenceNo, dbo.ARDetails_View.TransactionType, dbo.ARDetails_View.TransactionDate, dbo.ARDetails_View.InvoiceNo, dbo.ARDetails_View.Notes, dbo.Chart.AccountCode, 
                dbo.Chart.AccountName, dbo.Chart.AccountNameAra, dbo.Chart.SpecialAccount
FROM            dbo.ARDetails_View 
				INNER JOIN dbo.Chart 
				ON dbo.ARDetails_View.AccountIdNo = dbo.Chart.IdNo 
				RIGHT OUTER JOIN dbo.ArOpenInvoice 
				ON dbo.ARDetails_View.IdNo = dbo.ArOpenInvoice.JournalItemIdNo AND dbo.ARDetails_View.JournalCode = dbo.ArOpenInvoice.JournalCode Collate SQL_Latin1_General_CP1_CI_AS
GO
/****** Object:  View [dbo].[APDetails_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE VIEW [dbo].[APDetails_View]	
  AS
(SELECT 'AP' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
      ,[RevCostCenterIdNo]
      ,a.[Notes]
      ,a.[Posted]
	  ,[SupplierIdNo]
	  ,[InvoiceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[TransactionType]
  FROM [ISPDATA].[dbo].[ApJournalItem] a
  RIGHT OUTER JOIN dbo.ApJournal b
  on a.JournalIdNo = b.IdNo 
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
  FROM [ISPDATA].[dbo].[CheckDisbursementJournalItem] A
  RIGHT OUTER JOIN dbo.CheckDisbursementJournal b
  on a.JournalIdNo = b.IdNo
  WHERE PaymentType='A'
)
GO
/****** Object:  View [dbo].[ApOpenInvoice_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ApOpenInvoice_View]
AS
SELECT      dbo.ApOpenInvoice.IdNo, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.JournalItemIdNo, dbo.APDetails_View.Credit - dbo.APDetails_View.Debit AS Amount, dbo.ApOpenInvoice.PaidAmount, 
            dbo.ApOpenInvoice.DiscountTaken, dbo.APDetails_View.Credit - dbo.APDetails_View.Debit - dbo.ApOpenInvoice.PaidAmount - dbo.ApOpenInvoice.DiscountTaken AS Balance, 
            dbo.APDetails_View.Credit - dbo.APDetails_View.Debit AS InvoiceAmount, dbo.ApOpenInvoice.JournalIdNo, dbo.APDetails_View.AccountIdNo, dbo.APDetails_View.SupplierIdNo, dbo.APDetails_View.ReferenceNo, 
            dbo.APDetails_View.TransactionType, dbo.APDetails_View.TransactionDate, dbo.APDetails_View.InvoiceNo, dbo.APDetails_View.Notes, dbo.Chart.AccountName, dbo.Chart.AccountNameAra, 
            dbo.Chart.SpecialAccount, dbo.Chart.AccountCode
FROM        dbo.ApOpenInvoice 
			LEFT OUTER JOIN dbo.APDetails_View 
			ON dbo.ApOpenInvoice.JournalItemIdNo = dbo.APDetails_View.IdNo AND dbo.ApOpenInvoice.JournalCode = dbo.APDetails_View.JournalCode Collate SQL_Latin1_General_CP1_CI_AS
			LEFT OUTER JOIN dbo.Chart 
			ON dbo.APDetails_View.AccountIdNo = dbo.Chart.IdNo
GO
/****** Object:  View [dbo].[PcsOiItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[PcsOiItem_View]
AS
SELECT        dbo.PcsOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, 
                         dbo.ApOpenInvoice_View.Balance + dbo.PcsOiItem.Amount + dbo.PcsOiItem.DiscountTaken AS PreviousBalance, dbo.PcsOiItem.Amount, dbo.PcsOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, 
                         dbo.PcsOiItem.JournalItemIdNo, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.ApOpenInvoice_View.JournalCode, dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, 
                         dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.PcsOiItem.IdNo, dbo.ApOpenInvoice_View.SupplierIdNo, dbo.ApOpenInvoice_View.IdNo AS OpenInvoiceIdNo, 
                         dbo.PcsOiItem.PcsIdNo, dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo
FROM            dbo.PcsOiItem LEFT OUTER JOIN
                         dbo.ApOpenInvoice_View ON dbo.PcsOiItem.JournalItemIdNo = dbo.ApOpenInvoice_View.JournalItemIdNo
GO
/****** Object:  View [dbo].[ApInvoices_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ApInvoices_View]
AS
SELECT        dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.JournalItemIdNo, dbo.APDetails_View.AccountIdNo, dbo.APDetails_View.Debit, dbo.APDetails_View.Credit, dbo.APDetails_View.RevCostCenterIdNo, dbo.APDetails_View.Notes, 
                         dbo.APDetails_View.Posted, dbo.Chart.AccountCode, dbo.Chart.AccountName, dbo.Chart.AccountNameAra, dbo.APDetails_View.SupplierIdNo, dbo.APDetails_View.InvoiceNo, dbo.APDetails_View.TransactionDate, 
                         dbo.APDetails_View.ReferenceNo, dbo.APDetails_View.TransactionType, dbo.ApOpenInvoice.PaidAmount, dbo.ApOpenInvoice.DiscountTaken, dbo.Chart.SpecialAccount, dbo.ApOpenInvoice.IdNo, 
                         dbo.ApOpenInvoice.JournalIdNo
FROM            dbo.ApOpenInvoice 
			LEFT OUTER JOIN dbo.APDetails_View 
			ON dbo.ApOpenInvoice.JournalItemIdNo = dbo.APDetails_View.IdNo AND dbo.ApOpenInvoice.JournalCode = dbo.APDetails_View.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS 
			LEFT OUTER JOIN dbo.Chart 
			ON dbo.APDetails_View.AccountIdNo = dbo.Chart.IdNo 
GO
/****** Object:  View [dbo].[ApJournalItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ApJournalItem_View]
AS
SELECT        dbo.ApJournalItem.IdNo, dbo.ApJournalItem.Sequence, dbo.ApJournalItem.JournalIdNo, dbo.ApJournalItem.AccountIdNo, dbo.ApJournalItem.Debit, dbo.ApJournalItem.Credit, dbo.ApJournalItem.RevCostCenterIdNo, 
                         dbo.ApJournalItem.Notes, dbo.ApJournalItem.Posted, dbo.ApJournalItem.DateTimeStamp, dbo.Chart.AccountName, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.IdNo AS OpenInvoiceIdNo, 
                         dbo.ApJournalItem.Credit - dbo.ApJournalItem.Debit AS OriginalAmount, dbo.ApOpenInvoice.PaidAmount, dbo.ApOpenInvoice.DiscountTaken, dbo.Chart.SpecialAccount, dbo.Chart.AccountNameAra, dbo.Chart.PayeeType
FROM            dbo.ApJournalItem LEFT OUTER JOIN
                         dbo.Chart ON dbo.ApJournalItem.AccountIdNo = dbo.Chart.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.ApJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  View [dbo].[UnpaidOpenInvoices_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UnpaidOpenInvoices_View]
AS
SELECT        dbo.ApJournalItem_View.IdNo, dbo.ApJournalItem_View.JournalIdNo, dbo.ApJournalItem_View.AccountIdNo, dbo.ApJournalItem_View.AccountName, dbo.ApJournalItem_View.AccountNameAra, 
                         dbo.ApJournalItem_View.PaidAmount, dbo.ApJournalItem_View.OpenInvoiceIdNo, dbo.ApJournalItem_View.OriginalAmount, dbo.ApJournalItem_View.OriginalAmount - dbo.ApJournalItem_View.PaidAmount AS Balance, 
                         dbo.ApJournalItem_View.SpecialAccount, dbo.ApJournal.TransactionDate, dbo.ApJournal.SupplierIdNo, dbo.ApJournal.ReferenceNo
FROM            dbo.ApJournalItem_View INNER JOIN
                         dbo.ApJournal ON dbo.ApJournalItem_View.JournalIdNo = dbo.ApJournal.IdNo
WHERE        (dbo.ApJournalItem_View.SpecialAccount = 'AP')
GO
/****** Object:  View [dbo].[GlLedgers_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO














CREATE   VIEW [dbo].[GlLedgers_View]	
  AS
(SELECT 'AP' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
      ,[RevCostCenterIdNo]
      ,a.[Notes]
      ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[InvoiceNo] AS 'DocumentNumber'
	  ,[SupplierName] AS 'PayDescription'
	  ,[SupplierNameAra] AS 'PayDescriptionAra'
  FROM [ISPDATA].[dbo].[ApJournalItem] a
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
      ,[RevCostCenterIdNo]
      ,a.[Notes]
      ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[InvoiceNo] AS 'DocumentNumber'
	  ,[CustomerName]
	  ,[CustomerNameAra]
  FROM [ISPDATA].[dbo].[ArJournalItem] a
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
  FROM [ISPDATA].[dbo].[CheckDisbursementJournalItem] a
  LEFT OUTER JOIN dbo.CheckDisbursementJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IdNo 
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
  FROM [ISPDATA].[dbo].[CashDisbursementJournalItem] a
  LEFT OUTER JOIN dbo.CashDisbursementJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IdNo 
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
  FROM [ISPDATA].[dbo].[CashReceiptJournalItem] a
  LEFT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayorIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayorIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayorIdNo = e.IdNo 
)
UNION
(SELECT 'GJ'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,''
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
  FROM [ISPDATA].[dbo].[GeneralJournalItem] a
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
	  ,[RevCostCenterIdNo]
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
  FROM [ISPDATA].[dbo].[PettyCashJournalItem] a
  LEFT OUTER JOIN dbo.PettyCashJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IdNo 
)
UNION
(SELECT 'SJ'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,''
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
  FROM [ISPDATA].[dbo].[SalesJournalItem] a
  LEFT OUTER JOIN dbo.SalesJournal b
  on a.JournalIdNo = b.Idno
)
GO
/****** Object:  View [dbo].[AccountReconciliationItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[AccountReconciliationItem_View]
AS
SELECT      dbo.AccountReconciliationItem.IdNo, dbo.AccountReconciliationItem.Sequence, dbo.GlLedgers_View.TransactionDate, dbo.GlLedgers_View.IdNo AS JournalItemIdNo, dbo.GlLedgers_View.JournalCode, 
            dbo.AccountReconciliationItem.AccountReconciliationIdNo, dbo.GlLedgers_View.Debit, dbo.GlLedgers_View.DocumentNumber, dbo.GlLedgers_View.Credit, dbo.AccountReconciliationItem.Cleared, dbo.GlLedgers_View.AccountIdNo, dbo.GlLedgers_View.PayDescription, 
            dbo.GlLedgers_View.PayDescriptionAra, dbo.GlLedgers_View.ReferenceNo, dbo.GlLedgers_View.JournalIdNo, dbo.AccountReconciliation.Posted as Reconciled, dbo.AccountReconciliation.Posted
FROM        dbo.Reconciled 
			RIGHT OUTER JOIN dbo.GlLedgers_View 
			ON dbo.Reconciled.JournalCode = dbo.GlLedgers_View.JournalCode Collate SQL_Latin1_General_CP1_CI_AS AND dbo.Reconciled.JournalitemIdNo = dbo.GlLedgers_View.IdNo 
			LEFT OUTER JOIN dbo.AccountReconciliationItem 
			ON dbo.GlLedgers_View.JournalCode = dbo.AccountReconciliationItem.JournalCode Collate SQL_Latin1_General_CP1_CI_AS AND dbo.GlLedgers_View.IdNo = dbo.AccountReconciliationItem.JournalItemIdNo 
			LEFT OUTER JOIN dbo.AccountReconciliation 
			ON dbo.AccountReconciliationItem.AccountReconciliationIdNo = dbo.AccountReconciliation.IdNo
GO
/****** Object:  View [dbo].[GlReconciliation_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[GlReconciliation_View]
AS
SELECT			dbo.GlLedgers_View.JournalCode, dbo.GlLedgers_View.IdNo, dbo.GlLedgers_View.Sequence, dbo.GlLedgers_View.JournalIdNo, dbo.GlLedgers_View.AccountIdNo, dbo.GlLedgers_View.Debit, 
                dbo.GlLedgers_View.Credit,dbo.GlLedgers_View.DocumentNumber, dbo.GlLedgers_View.RevCostCenterIdNo, dbo.GlLedgers_View.Notes, dbo.GlLedgers_View.Posted, dbo.GlLedgers_View.TransactionDate, dbo.GlLedgers_View.ReferenceNo, 
                dbo.GlLedgers_View.PayDescription, dbo.GlLedgers_View.PayDescriptionAra, dbo.Reconciled.IdNo AS Reconciled
FROM            dbo.GlLedgers_View 
				LEFT OUTER JOIN dbo.Reconciled 
				ON dbo.GlLedgers_View.IdNo = dbo.Reconciled.JournalitemIdNo AND dbo.GlLedgers_View.JournalCode = dbo.Reconciled.JournalCode Collate SQL_Latin1_General_CP1_CI_AS
GO
/****** Object:  View [dbo].[CkdOiItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CkdOiItem_View]
AS
SELECT        dbo.CkdOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, 
                         dbo.ApOpenInvoice_View.Balance + dbo.CkdOiItem.Amount + dbo.CkdOiItem.DiscountTaken AS PreviousBalance, dbo.CkdOiItem.Amount, dbo.CkdOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, 
                         dbo.CkdOiItem.JournalItemIdNo, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.ApOpenInvoice_View.JournalCode, dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, 
                         dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.CkdOiItem.IdNo, dbo.ApOpenInvoice_View.SupplierIdNo, dbo.ApOpenInvoice_View.IdNo AS OpenInvoiceIdNo, 
                         dbo.CkdOiItem.CkdIdNo, dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo
FROM            dbo.CkdOiItem LEFT OUTER JOIN
                         dbo.ApOpenInvoice_View ON dbo.CkdOiItem.JournalItemIdNo = dbo.ApOpenInvoice_View.JournalItemIdNo
GO
/****** Object:  View [dbo].[APStatement_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[APStatement_View]
AS
SELECT        dbo.ApDetails_View.JournalCode, dbo.ApDetails_View.IdNo, dbo.ApDetails_View.Sequence, dbo.ApDetails_View.JournalIdNo, dbo.ApDetails_View.AccountIdNo, dbo.ApDetails_View.Debit, dbo.ApDetails_View.Credit, 
                         dbo.ApDetails_View.RevCostCenterIdNo, dbo.ApDetails_View.Notes, dbo.ApDetails_View.Posted, dbo.ApDetails_View.SupplierIdNo, dbo.ApDetails_View.InvoiceNo, dbo.ApDetails_View.TransactionDate, dbo.ApDetails_View.ReferenceNo, 
                         dbo.ApDetails_View.TransactionType, dbo.Chart.SpecialAccount
FROM            dbo.ApDetails_View INNER JOIN
                         dbo.Chart ON dbo.ApDetails_View.AccountIdNo = dbo.Chart.IdNo
WHERE        (dbo.Chart.SpecialAccount = 'AP')
GO
/****** Object:  View [dbo].[CsrOiItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CsrOiItem_View]
AS
SELECT        dbo.CsrOiItem.Sequence, dbo.ArOpenInvoice_View.InvoiceNo, dbo.ArOpenInvoice_View.TransactionDate, 
                         dbo.ArOpenInvoice_View.Balance + dbo.CsrOiItem.Amount + dbo.CsrOiItem.DiscountTaken AS PreviousBalance, dbo.CsrOiItem.Amount, dbo.CsrOiItem.DiscountTaken, dbo.ArOpenInvoice_View.Balance, 
                         dbo.CsrOiItem.JournalItemIdNo, dbo.ArOpenInvoice_View.Amount AS InvoiceAmount, dbo.ArOpenInvoice_View.JournalCode, dbo.ArOpenInvoice_View.JournalItemIdNo AS ArJournalItemIdNo, 
                         dbo.ArOpenInvoice_View.ReferenceNo, dbo.ArOpenInvoice_View.PaidAmount, dbo.CsrOiItem.IdNo, dbo.ArOpenInvoice_View.CustomerIdNo, dbo.ArOpenInvoice_View.IdNo AS OpenInvoiceIdNo, 
                         dbo.CsrOiItem.CsrIdNo, dbo.ArOpenInvoice_View.AccountIdNo, dbo.ArOpenInvoice_View.JournalIdNo
FROM            dbo.CsrOiItem LEFT OUTER JOIN
                         dbo.ArOpenInvoice_View ON dbo.CsrOiItem.JournalItemIdNo = dbo.ArOpenInvoice_View.JournalItemIdNo
GO
/****** Object:  View [dbo].[CadOiItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CadOiItem_View]
AS
SELECT        dbo.CadOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, 
                         dbo.ApOpenInvoice_View.Balance + dbo.CadOiItem.Amount + dbo.CadOiItem.DiscountTaken AS PreviousBalance, dbo.CadOiItem.Amount, dbo.CadOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, 
                         dbo.CadOiItem.JournalItemIdNo, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.ApOpenInvoice_View.JournalCode, dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, 
                         dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.CadOiItem.IdNo, dbo.ApOpenInvoice_View.SupplierIdNo, dbo.ApOpenInvoice_View.IdNo AS OpenInvoiceIdNo, 
                         dbo.CadOiItem.CadIdNo, dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo
FROM            dbo.CadOiItem LEFT OUTER JOIN
                         dbo.ApOpenInvoice_View ON dbo.CadOiItem.JournalItemIdNo = dbo.ApOpenInvoice_View.JournalItemIdNo
GO
/****** Object:  View [dbo].[ArJournalItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ArJournalItem_View]
AS
SELECT        dbo.ArJournalItem.IdNo, dbo.ArOpenInvoice.JournalCode, dbo.ArJournalItem.JournalIdNo, dbo.ArJournalItem.AccountIdNo, dbo.ArJournalItem.Debit, dbo.ArJournalItem.Credit, dbo.ArJournalItem.RevCostCenterIdNo, 
                         dbo.ArJournalItem.Notes, dbo.ArJournalItem.Posted, dbo.ArJournalItem.DateTimeStamp, dbo.Chart.AccountName, dbo.ArOpenInvoice.IdNo AS OpenInvoiceIdNo, 
                         dbo.ArJournalItem.Credit - dbo.ArJournalItem.Debit AS OriginalAmount, dbo.ArOpenInvoice.PaidAmount, dbo.ArOpenInvoice.DiscountTaken, dbo.Chart.SpecialAccount, dbo.Chart.AccountNameAra, dbo.Chart.PayeeType, 
                         dbo.ArJournalItem.Sequence
FROM            dbo.ArJournalItem INNER JOIN
                         dbo.Chart ON dbo.ArJournalItem.AccountIdNo = dbo.Chart.IdNo LEFT OUTER JOIN
                         dbo.ArOpenInvoice ON dbo.ArJournalItem.IdNo = dbo.ArOpenInvoice.JournalItemIdNo
GO
/****** Object:  View [dbo].[Captions_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[Captions_View]
AS
SELECT        dbo.TranslatedCaption.idno, dbo.TranslatedCaption.CaptionIdNo, dbo.TranslatedCaption.LanguageIdNo, dbo.TranslatedCaption.Translated, dbo.Languages.CultureInfoCode, dbo.OriginalCaptions.Caption, dbo.Languages.LanguageCode2
FROM            dbo.TranslatedCaption 
				INNER JOIN dbo.Languages 
				ON dbo.TranslatedCaption.LanguageIdNo = dbo.Languages.IdNo 
				RIGHT OUTER JOIN dbo.OriginalCaptions
				ON dbo.TranslatedCaption.CaptionIdNo = dbo.OriginalCaptions.idno
GO
/****** Object:  View [dbo].[CashDisbursementJournalItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CashDisbursementJournalItem_View]
AS
SELECT        dbo.CashDisbursementJournalItem.AccountIdNo, dbo.CashDisbursementJournalItem.Credit, dbo.CashDisbursementJournalItem.Debit, dbo.CashDisbursementJournalItem.IdNo, 
                         dbo.CashDisbursementJournalItem.JournalIdNo, dbo.CashDisbursementJournalItem.Notes, dbo.CashDisbursementJournalItem.RevCostCenterIdNo, dbo.CashDisbursementJournalItem.Sequence, 
                         dbo.Chart.AccountName, dbo.CashDisbursementJournalItem.Debit - dbo.CashDisbursementJournalItem.Credit AS OriginalAmount, dbo.Chart.PayeeType, dbo.Chart.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CashDisbursementJournal INNER JOIN
                         dbo.CashDisbursementJournalItem ON dbo.CashDisbursementJournal.IdNo = dbo.CashDisbursementJournalItem.JournalIdNo INNER JOIN
                         dbo.Chart ON dbo.CashDisbursementJournalItem.AccountIdNo = dbo.Chart.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CashDisbursementJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  View [dbo].[CashReceiptJournalItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CashReceiptJournalItem_View]
AS
SELECT        dbo.CashReceiptJournalItem.IdNo, dbo.CashReceiptJournalItem.Sequence, dbo.CashReceiptJournalItem.JournalIdNo, dbo.CashReceiptJournalItem.AccountIdNo, dbo.CashReceiptJournalItem.Debit, 
                         dbo.CashReceiptJournalItem.Credit, dbo.CashReceiptJournalItem.RevCostCenterIdNo, dbo.CashReceiptJournalItem.Notes, dbo.CashReceiptJournalItem.Posted, dbo.CashReceiptJournalItem.DateTimeStamp, 
                         dbo.Chart.AccountName, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.IdNo AS OpenInvoiceIdNo, dbo.CashReceiptJournalItem.Credit - dbo.CashReceiptJournalItem.Debit AS OriginalAmount, 
                         dbo.ApOpenInvoice.PaidAmount, dbo.Chart.SpecialAccount, dbo.Chart.AccountNameAra, dbo.Chart.PayeeType, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CashReceiptJournalItem LEFT OUTER JOIN
                         dbo.Chart ON dbo.CashReceiptJournalItem.AccountIdNo = dbo.Chart.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CashReceiptJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  View [dbo].[Chart_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create View [dbo].[Chart_View] as 
with cte as
(
select
    IdNo,
    ParentIdNo,
	AccountCode,
	AccountName,   
	AccountNameAra,
	Notes,
	DetailAccount,
	AccountGroup,
	BYDebit,
	BYCredit,
	Debit,
	Credit,
	NormalBalance,
	CloseDebit,
	CloseCredit,
	PayeeType,
	WithReconciliation,
	IncomeExpSummary,
	SpecialAccount,
	Active,
	DateTimeStamp,
    cast(row_number()over(partition by ParentIdNo order by AccountName) as varchar(max)) as [path],
    0 as levelnumber,
    row_number() over (partition by ParentIdNo order by AccountName) / power(1000.0,0) as SortKey
 
from Chart
where ParentIdNo IS NULL
union all
select
    t.IdNo,
	t.ParentIdNo,
	t.AccountCode,
    t.AccountName,
	t.AccountNameAra,    
	t.Notes,
	t.DetailAccount,
	t.AccountGroup,
	t.BYDebit,
	t.BYCredit,
	t.Debit,
	t.Credit,
	t.NormalBalance,
	t.CloseDebit,
	t.CloseCredit,
	t.PayeeType,
	t.WithReconciliation,
	t.IncomeExpSummary,
	t.SpecialAccount,
	t.Active,
	t.DateTimeStamp,
    [path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.AccountName) as varchar(max)),
    levelnumber+1,
    SortKey + row_number()over(partition by t.ParentIdNo order by t.AccountName) / power(1000.0,levelnumber+1)
 
from
    cte
join Chart t on cte.IdNo = t.ParentIdNo
)
   
select
    IdNo,
	ParentIdNo,
	AccountCode,
    AccountName,
	AccountNameAra,
	Notes,
	DetailAccount,
	AccountGroup,
	BYDebit,
	BYCredit,
	Debit,
	Credit,
	NormalBalance,
	CloseDebit,
	CloseCredit,
	PayeeType,
	WithReconciliation,
	IncomeExpSummary,
	SpecialAccount,
	Active,
	LevelNumber,
	DateTimeStamp,   
    [path],
    SortKey
from cte



GO
/****** Object:  View [dbo].[CheckDisbursementJournalItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CheckDisbursementJournalItem_View]
AS
SELECT        dbo.CheckDisbursementJournalItem.AccountIdNo, dbo.CheckDisbursementJournalItem.Credit, dbo.CheckDisbursementJournalItem.Debit, dbo.CheckDisbursementJournalItem.IdNo, 
                         dbo.CheckDisbursementJournalItem.JournalIdNo, dbo.CheckDisbursementJournalItem.Notes, dbo.CheckDisbursementJournalItem.RevCostCenterIdNo, dbo.CheckDisbursementJournalItem.Sequence, 
                         dbo.Chart.AccountName, dbo.CheckDisbursementJournalItem.Debit - dbo.CheckDisbursementJournalItem.Credit AS OriginalAmount, dbo.Chart.PayeeType, dbo.Chart.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CheckDisbursementJournal INNER JOIN
                         dbo.CheckDisbursementJournalItem ON dbo.CheckDisbursementJournal.IdNo = dbo.CheckDisbursementJournalItem.JournalIdNo INNER JOIN
                         dbo.Chart ON dbo.CheckDisbursementJournalItem.AccountIdNo = dbo.Chart.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CheckDisbursementJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  View [dbo].[RevCostCenter_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE View [dbo].[RevCostCenter_View] as 
with cte as
(
select IdNo
      ,RevCostCenterCode
      ,RevCostCenterName
      ,RevCostCenterNameAra
      ,ParentIdNo
	  ,RevCostCenterIdNo
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by RevCostCenterName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by RevCostCenterName) / power(10.0,0) as SortKey
 
from RevCostCenter
where ParentIdNo IS NULL
union all
select t.IdNo
      ,t.RevCostCenterCode
      ,t.RevCostCenterName
      ,t.RevCostCenterNameAra
	  ,t.ParentIdNo
	  ,t.RevCostCenterIdNo
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.RevCostCenterName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.RevCostCenterName) / power(10.0,levelnumber+1)
 
 from
    cte
join RevCostCenter t on cte.IdNo = t.ParentIdNo
)
   
select IdNo
      ,RevCostCenterCode
      ,RevCostCenterName
      ,RevCostCenterNameAra
	  ,ParentIdNo
	  ,RevCostCenterIdNo
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte





GO
/****** Object:  View [dbo].[Department_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create View [dbo].[Department_View] as 
with cte as
(
select IdNo
      ,DepartmentCode
      ,DepartmentName
      ,DepartmentNameAra
      ,ParentIdNo
      ,Notes
      ,RevCostCenterIdNo
      ,RevCostCenterIdNo
      ,Active
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by DepartmentName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by DepartmentName) / power(10.0,0) as SortKey
 
from Department
where ParentIdNo IS NULL
union all
select t.IdNo
      ,t.DepartmentCode
      ,t.DepartmentName
      ,t.DepartmentNameAra
      ,t.ParentIdNo
      ,t.Notes
      ,t.RevCostCenterIdNo
      ,t.RevCostCenterIdNo
      ,t.Active
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.DepartmentName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.DepartmentName) / power(10.0,levelnumber+1)
 
 from
    cte
join Department t on cte.IdNo = t.ParentIdNo
)
   
select IdNo
      ,DepartmentCode
      ,DepartmentName
      ,DepartmentNameAra
      ,ParentIdNo
      ,Notes
      ,RevCostCenterIdNo
      ,RevCostCenterIdNo
      ,Active
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte



GO
/****** Object:  View [dbo].[EmployeeJournalItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[EmployeeJournalItem_View]
AS
SELECT        dbo.EmployeeLoanJournalItem.IdNo, dbo.EmployeeLoanJournalItem.Sequence, dbo.EmployeeLoanJournalItem.JournalIdNo, dbo.EmployeeLoanJournalItem.AccountIdNo, dbo.EmployeeLoanJournalItem.TransactionDate, dbo.EmployeeLoanJournalItem.Debit, 
                         dbo.EmployeeLoanJournalItem.Credit, dbo.EmployeeLoanJournalItem.RevCostCenterIdNo, dbo.EmployeeLoanJournalItem.Notes, dbo.EmployeeLoanJournalItem.Posted, dbo.EmployeeLoanJournalItem.DateTimeStamp, dbo.Chart.AccountName
FROM            dbo.EmployeeLoanJournal INNER JOIN
                         dbo.EmployeeLoanJournalItem ON dbo.EmployeeLoanJournal.IdNo = dbo.EmployeeLoanJournalItem.JournalIdNo INNER JOIN
                         dbo.Chart ON dbo.EmployeeLoanJournalItem.AccountIdNo = dbo.Chart.IdNo 
GO
/****** Object:  View [dbo].[FormItemsOriginal_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[FormItemsOriginal_View]
AS
SELECT        dbo.FormItems.idno, dbo.FormItems.formIdNo, dbo.FormItems.CaptionIdNo, dbo.OriginalCaptions.Caption, dbo.FormItems.idno AS Expr1, dbo.FormItems.formIdNo AS Expr2, dbo.FormItems.CaptionIdNo AS Expr3, 
                         dbo.SystemForms.FormName, dbo.TranslatedCaption.Translated, dbo.Languages.LanguageCode2, dbo.Languages.CultureInfoCode, dbo.Languages.Language, dbo.TranslatedCaption.LanguageIdNo
FROM            dbo.Languages RIGHT OUTER JOIN
                         dbo.TranslatedCaption ON dbo.Languages.IdNo = dbo.TranslatedCaption.LanguageIdNo RIGHT OUTER JOIN
                         dbo.FormItems LEFT OUTER JOIN
                         dbo.SystemForms ON dbo.FormItems.formIdNo = dbo.SystemForms.IdNo ON dbo.TranslatedCaption.CaptionIdNo = dbo.FormItems.CaptionIdNo LEFT OUTER JOIN
                         dbo.OriginalCaptions ON dbo.FormItems.CaptionIdNo = dbo.OriginalCaptions.idno
GO
/****** Object:  View [dbo].[GeneralJournalItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GeneralJournalItem_View]
AS
SELECT        dbo.GeneralJournalItem.IdNo, dbo.GeneralJournalItem.Sequence, dbo.GeneralJournalItem.JournalIdNo, dbo.GeneralJournalItem.AccountIdNo, dbo.GeneralJournalItem.Debit, dbo.GeneralJournalItem.Credit, 
                         dbo.GeneralJournalItem.RevCostCenterIdNo, dbo.GeneralJournalItem.Notes, dbo.Chart.AccountName, dbo.GeneralJournalItem.Debit - dbo.GeneralJournalItem.Credit AS OriginalAmount, dbo.Chart.PayeeType, 
                         dbo.Chart.SpecialAccount, 0 AS OpenInvoiceIdNo, 0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.GeneralJournal INNER JOIN
                         dbo.GeneralJournalItem ON dbo.GeneralJournal.IdNo = dbo.GeneralJournalItem.JournalIdNo INNER JOIN
                         dbo.Chart ON dbo.GeneralJournalItem.AccountIdNo = dbo.Chart.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.GeneralJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  View [dbo].[GroupAccess_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GroupAccess_View]
AS
SELECT        dbo.SecurityObject.IdNo, dbo.SecurityObject.SecurityObjectName, dbo.SecurityGroup.IdNo AS Expr1, dbo.GroupAccess.Visible, dbo.GroupAccess.Editable, dbo.GroupAccess.SecurityGroupIdNo, 
                         dbo.GroupAccess.SecurityObjectIdNo, dbo.GroupAccess.IdNo AS Expr2, dbo.SecurityGroup.SecurityGroupName
FROM            dbo.SecurityGroup INNER JOIN
                         dbo.GroupAccess ON dbo.SecurityGroup.IdNo = dbo.GroupAccess.SecurityGroupIdNo RIGHT OUTER JOIN
                         dbo.SecurityObject ON dbo.GroupAccess.SecurityObjectIdNo = dbo.SecurityObject.IdNo
GO
/****** Object:  View [dbo].[InputVatAccountTypes]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[InputVatAccountTypes]
AS
SELECT        IdNo, AccountIdNo, AccountTypes, IdNo AS Expr1, AccountTypes AS Expr2, AccountIdNo AS Expr3
FROM            dbo.AccountTypes
WHERE        (AccountTypes = 'VI')
GO
/****** Object:  View [dbo].[PettyCashJournalItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[PettyCashJournalItem_View]
AS
SELECT        dbo.PettyCashJournalItem.AccountIdNo, dbo.PettyCashJournalItem.Credit, dbo.PettyCashJournalItem.Debit, dbo.PettyCashJournalItem.IdNo, 
                         dbo.PettyCashJournalItem.JournalIdNo, dbo.PettyCashJournalItem.Notes, dbo.PettyCashJournalItem.RevCostCenterIdNo, dbo.PettyCashJournalItem.Sequence, 
                         dbo.Chart.AccountName, dbo.PettyCashJournalItem.Debit - dbo.PettyCashJournalItem.Credit AS OriginalAmount, dbo.Chart.PayeeType, dbo.Chart.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.PettyCashJournal INNER JOIN
                         dbo.PettyCashJournalItem ON dbo.PettyCashJournal.IdNo = dbo.PettyCashJournalItem.JournalIdNo INNER JOIN
                         dbo.Chart ON dbo.PettyCashJournalItem.AccountIdNo = dbo.Chart.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.PettyCashJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  View [dbo].[RevCostCenter_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE View [dbo].[RevCostCenter_View] as 
with cte as
(
select IdNo
      ,RevCostCenterCode
      ,RevCostCenterName
      ,RevCostCenterNameAra
	  ,RevCostCenterType
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by RevCostCenterName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by RevCostCenterName) / power(10.0,0) as SortKey
 
from RevCostCenter
where ParentIdNo IS NULL
union all
select t.IdNo
      ,t.RevCostCenterCode
      ,t.RevCostCenterName
      ,t.RevCostCenterNameAra
	  ,t.RevCostCenterType
      ,t.ParentIdNo
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.RevCostCenterName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.RevCostCenterName) / power(10.0,levelnumber+1)
 
 from
    cte
join RevCostCenter t on cte.IdNo = t.ParentIdNo
)
   
select IdNo
      ,RevCostCenterCode
      ,RevCostCenterName
      ,RevCostCenterNameAra
	  ,RevCostCenterType
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte





GO
/****** Object:  View [dbo].[PurchaseJournalItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[PurchaseJournalItem_View]
AS
SELECT        dbo.PurchaseJournalItem.IdNo, dbo.PurchaseJournalItem.Sequence, dbo.PurchaseJournalItem.JournalIdNo, dbo.PurchaseJournalItem.AccountIdNo, dbo.PurchaseJournalItem.Debit, dbo.PurchaseJournalItem.Credit, dbo.PurchaseJournalItem.RevCostCenterIdNo, 
                         dbo.PurchaseJournalItem.Notes, dbo.PurchaseJournalItem.Posted, dbo.PurchaseJournalItem.DateTimeStamp, dbo.Chart.AccountName, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.IdNo AS OpenInvoiceIdNo, 
                         dbo.PurchaseJournalItem.Credit - dbo.PurchaseJournalItem.Debit AS OriginalAmount, dbo.ApOpenInvoice.PaidAmount, dbo.Chart.SpecialAccount, dbo.Chart.AccountNameAra, dbo.Chart.PayeeType
FROM            dbo.PurchaseJournalItem LEFT OUTER JOIN
                         dbo.Chart ON dbo.PurchaseJournalItem.AccountIdNo = dbo.Chart.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.PurchaseJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  View [dbo].[RevenueGroup_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




Create View [dbo].[RevenueGroup_View] as 
with cte as
(
select IdNo
      ,RevenueGroupCode
      ,RevenueGroupName
      ,RevenueGroupNameAra
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by RevenueGroupName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by RevenueGroupName) / power(10.0,0) as SortKey
 
from RevenueGroup
where ParentIdNo IS NULL
union all
select t.IdNo
      ,t.RevenueGroupCode
      ,t.RevenueGroupName
      ,t.RevenueGroupNameAra
      ,t.ParentIdNo
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.RevenueGroupName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.RevenueGroupName) / power(10.0,levelnumber+1)
 
 from
    cte
join RevenueGroup t on cte.IdNo = t.ParentIdNo
)
   
select IdNo
      ,RevenueGroupCode
      ,RevenueGroupName
      ,RevenueGroupNameAra
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte





GO
/****** Object:  View [dbo].[SalesJournalItem_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[SalesJournalItem_View]
AS
SELECT        dbo.SalesJournalItem.IdNo, dbo.SalesJournalItem.Sequence, dbo.SalesJournalItem.JournalIdNo, dbo.SalesJournalItem.AccountIdNo, dbo.SalesJournalItem.Debit, dbo.SalesJournalItem.Credit, 
                         dbo.SalesJournalItem.RevCostCenterIdNo, dbo.Chart.AccountName, dbo.SalesJournalItem.Debit - dbo.SalesJournalItem.Credit AS OriginalAmount, dbo.Chart.PayeeType, dbo.Chart.SpecialAccount, dbo.SalesJournalItem.Notes, 
                         0 AS OpenInvoiceIdNo, 0 AS PaidAmount, 0 AS DiscountTaken
FROM            dbo.SalesJournalItem INNER JOIN
                         dbo.Chart ON dbo.SalesJournalItem.AccountIdNo = dbo.Chart.IdNo
GO
/****** Object:  View [dbo].[SupplierInvoices]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SupplierInvoices]
AS
SELECT        dbo.ApOpenInvoice.IdNo, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.JournalItemIdNo, dbo.ApOpenInvoice.PaidAmount, dbo.ApOpenInvoice.DiscountTaken, dbo.ApJournalItem.Debit, 
                         dbo.ApJournalItem.Credit, dbo.ApJournalItem.RevCostCenterIdNo, dbo.ApJournalItem.Notes, dbo.ApJournalItem.Posted, dbo.ApJournalItem.AccountIdNo, dbo.ApJournalItem.JournalIdNo, dbo.ApJournalItem.Sequence, 
                         dbo.ApJournal.SupplierIdNo, dbo.ApJournal.InvoiceNo, dbo.ApJournal.InvoiceDate, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra
FROM            dbo.Chart INNER JOIN
                         dbo.ApJournalItem ON dbo.Chart.IdNo = dbo.ApJournalItem.AccountIdNo INNER JOIN
                         dbo.ApJournal ON dbo.ApJournalItem.JournalIdNo = dbo.ApJournal.IdNo INNER JOIN
                         dbo.Supplier ON dbo.ApJournal.SupplierIdNo = dbo.Supplier.IdNo RIGHT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.ApJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  View [dbo].[TranslatedCaption_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[TranslatedCaption_View]
AS
SELECT        dbo.TranslatedCaption.idno, dbo.TranslatedCaption.CaptionIdNo, dbo.TranslatedCaption.LanguageIdNo, dbo.TranslatedCaption.Translated, dbo.Languages.CultureInfoCode, dbo.OriginalCaptions.Caption, dbo.Languages.LanguageCode2
FROM            dbo.TranslatedCaption INNER JOIN
                         dbo.Languages ON dbo.TranslatedCaption.LanguageIdNo = dbo.Languages.IdNo INNER JOIN
                         dbo.OriginalCaptions ON dbo.TranslatedCaption.CaptionIdNo = dbo.OriginalCaptions.idno
GO
/****** Object:  View [dbo].[TranslatedMessages_View]    Script Date: 3/27/2020 6:57:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[TranslatedMessages_View]
AS
SELECT        dbo.TranslatedMessages.idno, dbo.TranslatedMessages.MessageIdNo, dbo.TranslatedMessages.TranslatedMessage, dbo.TranslatedMessages.TranslatedCaption, dbo.TranslatedMessages.DateTimeStamp, 
                         dbo.TranslatedMessages.LanguageIdNo, dbo.OriginalMessages.MessageKey, dbo.OriginalMessages.Message, dbo.OriginalMessages.Caption, dbo.OriginalMessages.Notes, dbo.Languages.LanguageCode2, 
                         dbo.Languages.CultureInfoCode
FROM            dbo.TranslatedMessages LEFT OUTER JOIN
                         dbo.Languages ON dbo.TranslatedMessages.LanguageIdNo = dbo.Languages.IdNo RIGHT OUTER JOIN
                         dbo.OriginalMessages ON dbo.TranslatedMessages.MessageIdNo = dbo.OriginalMessages.idno
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[42] 4[29] 3[6] 2) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 255
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "APDetails_View"
            Begin Extent = 
               Top = 24
               Left = 386
               Bottom = 339
               Right = 565
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 6
               Left = 603
               Bottom = 335
               Right = 801
            End
            DisplayFlags = 280
            TopColumn = 6
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 4470
         Alias = 900
         Table = 3780
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApInvoices_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApInvoices_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[49] 4[28] 2[6] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ApJournalItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 156
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 0
               Left = 269
               Bottom = 130
               Right = 467
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 0
               Left = 644
               Bottom = 188
               Right = 821
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 7905
         Alias = 2400
         Table = 2250
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[42] 2[11] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 17
               Left = 19
               Bottom = 391
               Right = 196
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "APDetails_View"
            Begin Extent = 
               Top = 30
               Left = 262
               Bottom = 363
               Right = 441
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 20
               Left = 513
               Bottom = 485
               Right = 712
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 11205
         Alias = 2940
         Table = 3975
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApOpenInvoice_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApOpenInvoice_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ApDetails_View"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 298
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 6
               Left = 255
               Bottom = 298
               Right = 454
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'APStatement_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'APStatement_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[27] 4[53] 2[11] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ArJournalItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 6
               Left = 255
               Bottom = 136
               Right = 454
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ArOpenInvoice"
            Begin Extent = 
               Top = 10
               Left = 575
               Bottom = 201
               Right = 752
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 3345
         Table = 3495
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[34] 2[6] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ARDetails_View"
            Begin Extent = 
               Top = 5
               Left = 467
               Bottom = 271
               Right = 786
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "ArOpenInvoice"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 332
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 47
               Left = 974
               Bottom = 328
               Right = 1172
            End
            DisplayFlags = 280
            TopColumn = 9
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2655
         Alias = 2715
         Table = 2175
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArOpenInvoice_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArOpenInvoice_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CashReceiptJournalItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 6
               Left = 255
               Bottom = 136
               Right = 454
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 88
               Left = 523
               Bottom = 279
               Right = 700
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CashReceiptJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CashReceiptJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[60] 4[12] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ChequeDisbursementJournal"
            Begin Extent = 
               Top = 71
               Left = 1042
               Bottom = 335
               Right = 1296
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "ChequeDisbursementJournalItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 247
               Right = 338
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 20
               Left = 724
               Bottom = 297
               Right = 922
            End
            DisplayFlags = 280
            TopColumn = 10
         End
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 208
               Left = 479
               Bottom = 466
               Right = 656
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2670
         Alias = 3345
         Table = 2955
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CheckDisbursementJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CheckDisbursementJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[28] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CkdOiItem"
            Begin Extent = 
               Top = 5
               Left = 23
               Bottom = 255
               Right = 200
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApOpenInvoice_View"
            Begin Extent = 
               Top = 0
               Left = 251
               Bottom = 289
               Right = 627
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 5475
         Alias = 2040
         Table = 2775
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CkdOiItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CkdOiItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[28] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CsrOiItem"
            Begin Extent = 
               Top = 5
               Left = 23
               Bottom = 255
               Right = 200
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ArOpenInvoice_View"
            Begin Extent = 
               Top = 0
               Left = 251
               Bottom = 289
               Right = 435
            End
            DisplayFlags = 280
            TopColumn = 8
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 5475
         Alias = 2040
         Table = 2775
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CsrOiItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CsrOiItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[62] 4[3] 2[17] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Languages"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 335
               Right = 631
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Translated"
            Begin Extent = 
               Top = 136
               Left = 253
               Bottom = 266
               Right = 423
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FormItems"
            Begin Extent = 
               Top = 37
               Left = 8
               Bottom = 366
               Right = 178
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SystemForms"
            Begin Extent = 
               Top = 8
               Left = 235
               Bottom = 113
               Right = 405
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Original"
            Begin Extent = 
               Top = 284
               Left = 252
               Bottom = 446
               Right = 422
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
       ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FormItemsOriginal_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FormItemsOriginal_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FormItemsOriginal_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GeneralJournal"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 249
               Right = 213
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GeneralJournalItem"
            Begin Extent = 
               Top = 6
               Left = 251
               Bottom = 136
               Right = 430
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 0
               Left = 485
               Bottom = 130
               Right = 684
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 117
               Left = 720
               Bottom = 296
               Right = 897
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneralJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneralJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SecurityObject"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 265
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GroupAccess"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 335
               Right = 467
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SecurityGroup"
            Begin Extent = 
               Top = 0
               Left = 709
               Bottom = 275
               Right = 923
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GroupAccess_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GroupAccess_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AccountTypes"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InputVatAccountTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InputVatAccountTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 273
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApJournalItem"
            Begin Extent = 
               Top = 6
               Left = 253
               Bottom = 292
               Right = 432
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Chart"
            Begin Extent = 
               Top = 6
               Left = 470
               Bottom = 136
               Right = 668
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApJournal"
            Begin Extent = 
               Top = 6
               Left = 706
               Bottom = 335
               Right = 899
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Supplier"
            Begin Extent = 
               Top = 6
               Left = 937
               Bottom = 136
               Right = 1131
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 2040
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SupplierInvoices'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SupplierInvoices'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SupplierInvoices'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Translated"
            Begin Extent = 
               Top = 0
               Left = 17
               Bottom = 313
               Right = 187
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Languages"
            Begin Extent = 
               Top = 150
               Left = 270
               Bottom = 335
               Right = 447
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Original"
            Begin Extent = 
               Top = 21
               Left = 256
               Bottom = 117
               Right = 426
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TranslatedCaption_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TranslatedCaption_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[13] 4[49] 2[19] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TranslatedMessages"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 227
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Languages"
            Begin Extent = 
               Top = 6
               Left = 265
               Bottom = 136
               Right = 442
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OriginalMessages"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3870
         Alias = 900
         Table = 3345
         Output = 2340
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TranslatedMessages_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TranslatedMessages_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[36] 2[5] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ApJournalItem_View"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 309
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApJournal"
            Begin Extent = 
               Top = 13
               Left = 323
               Bottom = 336
               Right = 516
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UnpaidOpenInvoices_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UnpaidOpenInvoices_View'
GO
