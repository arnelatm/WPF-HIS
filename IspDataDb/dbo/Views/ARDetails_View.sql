


















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
	  ,dbo.FnResolveOpenInvoiceParty(a.PayIdNo, 'C', b.CustomerIdNo) AS CustomerIdNo
	  ,[InvoiceNo] COLLATE Arabic_CI_AS AS 'InvoiceNo'
	  ,[TransactionDate]
      ,[ReferenceNo] COLLATE Arabic_CI_AS AS 'ReferenceNo'
	  ,[TransactionType] COLLATE SQL_Latin1_General_CP1_CI_AS AS 'TransactionType'
	  ,b.Notes COLLATE Arabic_CI_AS AS 'MainNote'
	  ,DueDate
  FROM [dbo].[ArJournalItem] a
  RIGHT OUTER JOIN dbo.ArJournal b
  on a.JournalIdNo = b.IDNo 
  where b.Cancelled = 0
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
	  ,dbo.FnResolveOpenInvoiceParty(a.PayIdNo, 'C', CASE WHEN b.PayorType IN ('A','C') THEN b.PayorIdNo END)
	  ,COALESCE(NULLIF(LTRIM(RTRIM(b.ORNumber)), ''), b.ReferenceNo)
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'P'
	  ,Concat(LTrim(b.Notes),IIf([CheckNumber]='','',' Chk#'+[CheckNumber])) AS 'MainNote'
	  ,[TransactionDate]
  FROM [dbo].[CashReceiptJournalItem] A
  RIGHT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IDNo
  WHERE b.Cancelled = 0 AND (b.PayorType='A' OR EXISTS (SELECT 1 FROM dbo.ArOpenInvoice o WHERE o.JournalCode='CR' AND o.JournalIdNo=a.JournalIdNo AND o.JournalItemIdNo=a.IdNo))
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
	  ,dbo.FnResolveOpenInvoiceParty(a.PayIdNo, 'C', CASE WHEN b.PaymentType='R' THEN b.PayeeIdNo END)
	  ,COALESCE(NULLIF(LTRIM(RTRIM(b.ORNumber)), ''), b.ReferenceNo)
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'R'
	  ,b.Notes AS 'MainNote'
	  ,[TransactionDate]
  FROM [dbo].[CdJournalItem] A
  LEFT OUTER JOIN dbo.CdJournal b
  on a.JournalIdNo = b.IDNo
  WHERE b.Cancelled = 0 AND (b.PaymentType='R' OR EXISTS (SELECT 1 FROM dbo.ArOpenInvoice o WHERE o.JournalCode='CD' AND o.JournalIdNo=a.JournalIdNo AND o.JournalItemIdNo=a.IdNo))
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
	  ,dbo.FnResolveOpenInvoiceParty(a.PayIdNo, 'C', CASE WHEN b.PaymentType='R' THEN b.PayeeIdNo END)
	  ,COALESCE(NULLIF(LTRIM(RTRIM(b.ORNumber)), ''), b.ReferenceNo)
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'R'
	  ,b.Notes AS 'MainNote'
	  ,[TransactionDate]
  FROM [dbo].[PcJournalItem] A
  LEFT OUTER JOIN dbo.PcJournal b
  on a.JournalIdNo = b.IDNo
  WHERE b.Cancelled = 0 AND (b.PaymentType='R' OR EXISTS (SELECT 1 FROM dbo.ArOpenInvoice o WHERE o.JournalCode='PC' AND o.JournalIdNo=a.JournalIdNo AND o.JournalItemIdNo=a.IdNo))
)
UNION
(SELECT 'GJ', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit,
        i.RevCostCenterIdNo, i.Notes COLLATE Arabic_CI_AS, i.Posted,
        dbo.FnResolveOpenInvoiceParty(i.PayIdNo, 'C', NULL),
        h.ReferenceNo COLLATE Arabic_CI_AS, h.TransactionDate,
        h.ReferenceNo COLLATE Arabic_CI_AS, 'D', h.Notes COLLATE Arabic_CI_AS,
        h.TransactionDate
 FROM dbo.GeneralJournalItem AS i
 INNER JOIN dbo.GeneralJournal AS h ON h.IdNo = i.JournalIdNo
 WHERE h.Cancelled = 0 AND h.ClosingJournal = 0
   AND EXISTS (SELECT 1 FROM dbo.ArOpenInvoice AS o WHERE o.JournalCode = 'GJ'
               AND o.JournalIdNo = i.JournalIdNo AND o.JournalItemIdNo = i.IdNo))
UNION
(SELECT 'ER', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit,
        i.RevCostCenterIdNo, i.Notes COLLATE Arabic_CI_AS, i.Posted,
        dbo.FnResolveOpenInvoiceParty(i.PayIdNo, 'C', NULL),
        h.ReferenceNo COLLATE Arabic_CI_AS, h.TransactionDate,
        h.ReferenceNo COLLATE Arabic_CI_AS, 'D', h.Notes COLLATE Arabic_CI_AS,
        h.TransactionDate
 FROM dbo.ErJournalItem AS i
 INNER JOIN dbo.ErJournal AS h ON h.IdNo = i.JournalIdNo
 WHERE h.Cancelled = 0
   AND EXISTS (SELECT 1 FROM dbo.ArOpenInvoice AS o WHERE o.JournalCode = 'ER'
               AND o.JournalIdNo = i.JournalIdNo AND o.JournalItemIdNo = i.IdNo))
UNION
(SELECT 'SJ', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit,
        i.RevCostCenterIdNo, i.Notes COLLATE Arabic_CI_AS, i.Posted,
        dbo.FnResolveOpenInvoiceParty(i.PayIdNo, 'C', NULL),
        h.ReferenceNo COLLATE Arabic_CI_AS, h.TransactionDate,
        h.ReferenceNo COLLATE Arabic_CI_AS, 'D', h.Notes COLLATE Arabic_CI_AS,
        h.TransactionDate
 FROM dbo.SalesJournalItem AS i
 INNER JOIN dbo.SalesJournal AS h ON h.IdNo = i.JournalIdNo
 WHERE h.Cancelled = 0
   AND EXISTS (SELECT 1 FROM dbo.ArOpenInvoice AS o WHERE o.JournalCode = 'SJ'
               AND o.JournalIdNo = i.JournalIdNo AND o.JournalItemIdNo = i.IdNo))
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

GO

