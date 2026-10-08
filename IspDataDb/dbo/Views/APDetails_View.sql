
























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
	  ,dbo.FnResolveOpenInvoiceParty(ai.PayIdNo, 'S', b.SupplierIdNo) AS SupplierIdNo
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
	  ,dbo.FnResolveOpenInvoiceParty(ai.PayIdNo, 'S', CASE WHEN b.PaymentType IN ('A','S') THEN b.PayeeIdNo END)
	  ,COALESCE(NULLIF(LTRIM(RTRIM(b.ORNumber)), ''), b.ReferenceNo)
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'P'
	  ,b.Notes AS 'MainNote'
	  ,b.DiscountTaken
	  ,[TransactionDate]
  FROM [CdJournalItem] ai
  LEFT OUTER JOIN dbo.CdJournal b
  on ai.JournalIdNo = b.IDNo
  WHERE b.Cancelled = 0 AND (b.PaymentType='A' OR EXISTS (SELECT 1 FROM dbo.ApOpenInvoice o WHERE o.JournalCode='CD' AND o.JournalIdNo=ai.JournalIdNo AND o.JournalItemIdNo=ai.IdNo))
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
	  ,dbo.FnResolveOpenInvoiceParty(ai.PayIdNo, 'S', CASE WHEN b.PaymentType IN ('A','S') THEN b.PayeeIdNo END)
	  ,COALESCE(NULLIF(LTRIM(RTRIM(b.ORNumber)), ''), b.ReferenceNo)
	  ,b.[TransactionDate]
      ,b.[ReferenceNo]
	  ,'P'
	  ,b.Notes AS 'MainNote'
	  ,b.DiscountTaken
	  ,[TransactionDate]
  FROM [PcJournalItem] as ai
  LEFT OUTER JOIN PcJournal as b
  on ai.JournalIdNo = b.IDNo
  WHERE b.Cancelled = 0 AND (b.PaymentType='A' OR EXISTS (SELECT 1 FROM dbo.ApOpenInvoice o WHERE o.JournalCode='PC' AND o.JournalIdNo=ai.JournalIdNo AND o.JournalItemIdNo=ai.IdNo))
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
	  ,dbo.FnResolveOpenInvoiceParty(ai.PayIdNo, 'S', CASE WHEN b.PayorType='R' THEN b.PayorIdNo END)
	  ,COALESCE(NULLIF(LTRIM(RTRIM(b.ORNumber)), ''), b.ReferenceNo)
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'R'
	  ,Concat(LTrim(b.Notes),IIf(CheckNumber='','',' Chk#'+[CheckNumber])) AS 'MainNote'
	  ,b.[DiscountTaken]
	  ,[TransactionDate]
  FROM [CashReceiptJournalItem] as ai
  LEFT OUTER JOIN dbo.CashReceiptJournal as b
  on ai.JournalIdNo = b.IDNo
  WHERE b.Cancelled = 0 AND (b.PayorType='R' OR EXISTS (SELECT 1 FROM dbo.ApOpenInvoice o WHERE o.JournalCode='CR' AND o.JournalIdNo=ai.JournalIdNo AND o.JournalItemIdNo=ai.IdNo))
)
UNION
(SELECT 'GJ', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit,
        i.RevCostCenterIdNo, i.Notes COLLATE Arabic_CI_AS, i.Posted,
        dbo.FnResolveOpenInvoiceParty(i.PayIdNo, 'S', NULL),
        h.ReferenceNo COLLATE Arabic_CI_AS, h.TransactionDate,
        h.ReferenceNo COLLATE Arabic_CI_AS, 'I', h.Notes COLLATE Arabic_CI_AS,
        0, h.TransactionDate
 FROM dbo.GeneralJournalItem AS i
 INNER JOIN dbo.GeneralJournal AS h ON h.IdNo = i.JournalIdNo
 WHERE h.Cancelled = 0 AND h.ClosingJournal = 0
   AND EXISTS (SELECT 1 FROM dbo.ApOpenInvoice AS o WHERE o.JournalCode = 'GJ'
               AND o.JournalIdNo = i.JournalIdNo AND o.JournalItemIdNo = i.IdNo))
UNION
(SELECT 'ER', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit,
        i.RevCostCenterIdNo, i.Notes COLLATE Arabic_CI_AS, i.Posted,
        dbo.FnResolveOpenInvoiceParty(i.PayIdNo, 'S', NULL),
        h.ReferenceNo COLLATE Arabic_CI_AS, h.TransactionDate,
        h.ReferenceNo COLLATE Arabic_CI_AS, 'I', h.Notes COLLATE Arabic_CI_AS,
        0, h.TransactionDate
 FROM dbo.ErJournalItem AS i
 INNER JOIN dbo.ErJournal AS h ON h.IdNo = i.JournalIdNo
 WHERE h.Cancelled = 0
   AND EXISTS (SELECT 1 FROM dbo.ApOpenInvoice AS o WHERE o.JournalCode = 'ER'
               AND o.JournalIdNo = i.JournalIdNo AND o.JournalItemIdNo = i.IdNo))
UNION
(SELECT 'SJ', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo, i.Debit, i.Credit,
        i.RevCostCenterIdNo, i.Notes COLLATE Arabic_CI_AS, i.Posted,
        dbo.FnResolveOpenInvoiceParty(i.PayIdNo, 'S', NULL),
        h.ReferenceNo COLLATE Arabic_CI_AS, h.TransactionDate,
        h.ReferenceNo COLLATE Arabic_CI_AS, 'I', h.Notes COLLATE Arabic_CI_AS,
        0, h.TransactionDate
 FROM dbo.SalesJournalItem AS i
 INNER JOIN dbo.SalesJournal AS h ON h.IdNo = i.JournalIdNo
 WHERE h.Cancelled = 0
   AND EXISTS (SELECT 1 FROM dbo.ApOpenInvoice AS o WHERE o.JournalCode = 'SJ'
               AND o.JournalIdNo = i.JournalIdNo AND o.JournalItemIdNo = i.IdNo))
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

