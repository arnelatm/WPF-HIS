:ON ERROR EXIT
-- Focused schema deployment. Requires explicit target variables, backup and test verification.
-- sqlcmd -S <server> -d <database> -E -b -i tools/Deploy-ArApOpenInvoiceParty.sql -v TargetServer=<server> TargetDatabase=<database>
SET NOCOUNT ON;
SET XACT_ABORT ON;
IF CONVERT(nvarchar(128), SERVERPROPERTY('ServerName')) <> N'$(TargetServer)'
   OR DB_NAME() <> N'$(TargetDatabase)'
    THROW 51990, 'Connection does not match the explicitly selected deployment target.', 1;
BEGIN TRANSACTION;
GO
IF OBJECT_ID('dbo.FnResolveOpenInvoiceParty', 'FN') IS NULL
    EXEC(N'CREATE FUNCTION dbo.FnResolveOpenInvoiceParty(@PayIdNo int, @PartyType char(1), @HeaderPartyIdNo int) RETURNS int AS BEGIN RETURN NULL; END;');
GO

-- Source: IspDataDb/dbo/Functions/FnResolveOpenInvoiceParty.sql
ALTER FUNCTION dbo.FnResolveOpenInvoiceParty
(
    @PayIdNo int,
    @PartyType char(1),
    @HeaderPartyIdNo int
)
RETURNS int
AS
BEGIN
    DECLARE @PartyIdNo int;

    -- PayIdNo is a Contact key, never a Customer/Supplier key.
    -- Header fallback is only for historical lines with no selected contact.
    IF ISNULL(@PayIdNo, 0) = 0
        SET @PartyIdNo = @HeaderPartyIdNo;
    ELSE
        SELECT @PartyIdNo = CSEIdNo
        FROM dbo.Contact
        WHERE IdNo = @PayIdNo AND CSECode = @PartyType;

    IF @PartyType = 'C' AND EXISTS (SELECT 1 FROM dbo.Customer WHERE IdNo = @PartyIdNo)
        RETURN @PartyIdNo;
    IF @PartyType = 'S' AND EXISTS (SELECT 1 FROM dbo.Supplier WHERE IdNo = @PartyIdNo)
        RETURN @PartyIdNo;

    RETURN NULL;
END;
GO

-- Source: IspDataDb/dbo/Views/JournalItemPayeeLedger_View.sql
ALTER VIEW [dbo].[JournalItemPayeeLedger_View]
AS
SELECT 'AP' AS JournalCode, i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo,
       i.Debit, i.Credit, i.RevCostCenterIdNo,
       CONVERT(NVARCHAR(300), i.Notes) COLLATE Arabic_CI_AS AS Notes, i.Posted,
       CASE WHEN a.SpecialAccount = 'AP'
            THEN dbo.FnResolveOpenInvoiceParty(i.PayIdNo, 'S', h.SupplierIdNo)
            ELSE COALESCE(linePayee.PayeeCSEIdNo,
                CASE WHEN payeeType.ExpectedPayeeType = 'S' THEN h.SupplierIdNo END)
       END AS PayeeCSEIdNo,
       CONVERT(NVARCHAR(50), h.InvoiceNo) COLLATE Arabic_CI_AS AS InvoiceNo,
       h.TransactionDate,
       CONVERT(NVARCHAR(50), h.ReferenceNo) COLLATE Arabic_CI_AS AS ReferenceNo,
       CONVERT(VARCHAR(10), COALESCE(h.TransactionType, 'A')) COLLATE SQL_Latin1_General_CP1_CI_AS AS TransactionType,
       CONVERT(NVARCHAR(300), h.Notes) COLLATE Arabic_CI_AS AS MainNote,
       payeeType.ExpectedPayeeType
FROM dbo.ApJournalItem AS i
INNER JOIN dbo.ApJournal AS h ON h.IdNo = i.JournalIdNo
INNER JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
CROSS APPLY (VALUES (CASE WHEN a.SpecialAccount = 'AP' THEN 'S'
                          WHEN a.SpecialAccount = 'AR' THEN 'C'
                          WHEN a.PayeeType IN ('C', 'S', 'E') THEN a.PayeeType
                          WHEN a.SpecialAccount IN ('AP', 'AS', 'PD') THEN 'S'
                          WHEN a.SpecialAccount IN ('AR', 'CA', 'SD') THEN 'C'
                          WHEN a.SpecialAccount = 'EL' THEN 'E' END)) AS payeeType(ExpectedPayeeType)
OUTER APPLY (
    SELECT TOP (1) resolved.PayeeCSEIdNo
    FROM (
        SELECT c.CSEIdNo AS PayeeCSEIdNo, 1 AS Priority
        FROM dbo.Contact_View AS c
        WHERE c.IdNo = i.PayIdNo AND c.CSECode = payeeType.ExpectedPayeeType
        UNION ALL
        SELECT legacy.ContactIdNo, 2
        FROM dbo.CSEContact_View AS legacy
        WHERE legacy.ContactIdNo = i.PayIdNo AND legacy.CSECode = payeeType.ExpectedPayeeType
    ) AS resolved
    ORDER BY resolved.Priority
) AS linePayee
WHERE ISNULL(h.Cancelled, 0) = 0

UNION ALL

SELECT 'AR', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo,
       i.Debit, i.Credit, i.RevCostCenterIdNo,
       CONVERT(NVARCHAR(300), i.Notes) COLLATE Arabic_CI_AS, i.Posted,
       CASE WHEN a.SpecialAccount = 'AR'
            THEN dbo.FnResolveOpenInvoiceParty(i.PayIdNo, 'C', h.CustomerIdNo)
            ELSE COALESCE(linePayee.PayeeCSEIdNo,
                CASE WHEN payeeType.ExpectedPayeeType = 'C' THEN h.CustomerIdNo END)
       END,
       CONVERT(NVARCHAR(50), h.InvoiceNo) COLLATE Arabic_CI_AS,
       h.TransactionDate,
       CONVERT(NVARCHAR(50), h.ReferenceNo) COLLATE Arabic_CI_AS,
       CONVERT(VARCHAR(10), COALESCE(h.TransactionType, 'R')) COLLATE SQL_Latin1_General_CP1_CI_AS,
       CONVERT(NVARCHAR(300), h.Notes) COLLATE Arabic_CI_AS,
       payeeType.ExpectedPayeeType
FROM dbo.ArJournalItem AS i
INNER JOIN dbo.ArJournal AS h ON h.IdNo = i.JournalIdNo
INNER JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
CROSS APPLY (VALUES (CASE WHEN a.SpecialAccount = 'AP' THEN 'S'
                          WHEN a.SpecialAccount = 'AR' THEN 'C'
                          WHEN a.PayeeType IN ('C', 'S', 'E') THEN a.PayeeType
                          WHEN a.SpecialAccount IN ('AP', 'AS', 'PD') THEN 'S'
                          WHEN a.SpecialAccount IN ('AR', 'CA', 'SD') THEN 'C'
                          WHEN a.SpecialAccount = 'EL' THEN 'E' END)) AS payeeType(ExpectedPayeeType)
OUTER APPLY (
    SELECT TOP (1) resolved.PayeeCSEIdNo
    FROM (
        SELECT c.CSEIdNo AS PayeeCSEIdNo, 1 AS Priority
        FROM dbo.Contact_View AS c
        WHERE c.IdNo = i.PayIdNo AND c.CSECode = payeeType.ExpectedPayeeType
        UNION ALL
        SELECT legacy.ContactIdNo, 2
        FROM dbo.CSEContact_View AS legacy
        WHERE legacy.ContactIdNo = i.PayIdNo AND legacy.CSECode = payeeType.ExpectedPayeeType
    ) AS resolved
    ORDER BY resolved.Priority
) AS linePayee
WHERE ISNULL(h.Cancelled, 0) = 0

UNION ALL

SELECT 'CD', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo,
       i.Debit, i.Credit, i.RevCostCenterIdNo,
       CONVERT(NVARCHAR(300), i.Notes) COLLATE Arabic_CI_AS, i.Posted,
       COALESCE(linePayee.PayeeCSEIdNo,
           CASE WHEN (payeeType.ExpectedPayeeType = 'S' AND h.PaymentType = 'A') OR
                          (payeeType.ExpectedPayeeType = 'C' AND h.PaymentType = 'R') OR
                          (payeeType.ExpectedPayeeType = 'E' AND h.PaymentType = 'E')
                THEN h.PayeeIdNo END),
       CONVERT(NVARCHAR(50), h.ORNumber) COLLATE Arabic_CI_AS,
       h.TransactionDate,
       CONVERT(NVARCHAR(50), h.ReferenceNo) COLLATE Arabic_CI_AS,
       CONVERT(VARCHAR(10), COALESCE(h.PaymentType, 'D')) COLLATE SQL_Latin1_General_CP1_CI_AS,
       CONVERT(NVARCHAR(300), h.Notes) COLLATE Arabic_CI_AS,
       payeeType.ExpectedPayeeType
FROM dbo.CdJournalItem AS i
INNER JOIN dbo.CdJournal AS h ON h.IdNo = i.JournalIdNo
INNER JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
CROSS APPLY (VALUES (CASE WHEN a.PayeeType IN ('C', 'S', 'E') THEN a.PayeeType
                          WHEN a.SpecialAccount IN ('AP', 'AS', 'PD') THEN 'S'
                          WHEN a.SpecialAccount IN ('AR', 'CA', 'SD') THEN 'C'
                          WHEN a.SpecialAccount = 'EL' THEN 'E' END)) AS payeeType(ExpectedPayeeType)
OUTER APPLY (
    SELECT TOP (1) resolved.PayeeCSEIdNo
    FROM (
        SELECT c.CSEIdNo AS PayeeCSEIdNo, 1 AS Priority
        FROM dbo.Contact_View AS c
        WHERE c.IdNo = i.PayIdNo AND c.CSECode = payeeType.ExpectedPayeeType
        UNION ALL
        SELECT legacy.ContactIdNo, 2
        FROM dbo.CSEContact_View AS legacy
        WHERE legacy.ContactIdNo = i.PayIdNo AND legacy.CSECode = payeeType.ExpectedPayeeType
    ) AS resolved
    ORDER BY resolved.Priority
) AS linePayee
WHERE ISNULL(h.Cancelled, 0) = 0

UNION ALL

SELECT 'CR', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo,
       i.Debit, i.Credit, i.RevCostCenterIdNo,
       CONVERT(NVARCHAR(300), CONCAT(LTRIM(i.Notes), CASE WHEN ISNULL(h.CheckNumber, '') = '' THEN '' ELSE ' Chk#' + h.CheckNumber END)) COLLATE Arabic_CI_AS,
       i.Posted,
       COALESCE(linePayee.PayeeCSEIdNo,
           CASE WHEN (payeeType.ExpectedPayeeType = 'S' AND h.PayorType = 'R') OR
                          (payeeType.ExpectedPayeeType = 'C' AND h.PayorType = 'A') OR
                          (payeeType.ExpectedPayeeType = 'E' AND h.PayorType = 'E')
                THEN h.PayorIdNo END),
       CONVERT(NVARCHAR(50), h.ORNumber) COLLATE Arabic_CI_AS,
       h.TransactionDate,
       CONVERT(NVARCHAR(50), h.ReferenceNo) COLLATE Arabic_CI_AS,
       CONVERT(VARCHAR(10), COALESCE(h.PayorType, 'R')) COLLATE SQL_Latin1_General_CP1_CI_AS,
       CONVERT(NVARCHAR(300), CONCAT(LTRIM(h.Notes), CASE WHEN ISNULL(h.CheckNumber, '') = '' THEN '' ELSE ' Chk#' + h.CheckNumber END)) COLLATE Arabic_CI_AS,
       payeeType.ExpectedPayeeType
FROM dbo.CashReceiptJournalItem AS i
INNER JOIN dbo.CashReceiptJournal AS h ON h.IdNo = i.JournalIdNo
INNER JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
CROSS APPLY (VALUES (CASE WHEN a.PayeeType IN ('C', 'S', 'E') THEN a.PayeeType
                          WHEN a.SpecialAccount IN ('AP', 'AS', 'PD') THEN 'S'
                          WHEN a.SpecialAccount IN ('AR', 'CA', 'SD') THEN 'C'
                          WHEN a.SpecialAccount = 'EL' THEN 'E' END)) AS payeeType(ExpectedPayeeType)
OUTER APPLY (
    SELECT TOP (1) resolved.PayeeCSEIdNo
    FROM (
        SELECT c.CSEIdNo AS PayeeCSEIdNo, 1 AS Priority
        FROM dbo.Contact_View AS c
        WHERE c.IdNo = i.PayIdNo AND c.CSECode = payeeType.ExpectedPayeeType
        UNION ALL
        SELECT legacy.ContactIdNo, 2
        FROM dbo.CSEContact_View AS legacy
        WHERE legacy.ContactIdNo = i.PayIdNo AND legacy.CSECode = payeeType.ExpectedPayeeType
    ) AS resolved
    ORDER BY resolved.Priority
) AS linePayee
WHERE ISNULL(h.Cancelled, 0) = 0

UNION ALL

SELECT 'CK', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo,
       i.Debit, i.Credit, i.RevCostCenterIdNo,
       CONVERT(NVARCHAR(300), i.Notes) COLLATE Arabic_CI_AS, i.Posted,
       COALESCE(linePayee.PayeeCSEIdNo,
           CASE WHEN (payeeType.ExpectedPayeeType = 'S' AND h.PaymentType = 'A') OR
                          (payeeType.ExpectedPayeeType = 'C' AND h.PaymentType = 'R') OR
                          (payeeType.ExpectedPayeeType = 'E' AND h.PaymentType = 'E')
                THEN h.PayeeIdNo END),
       CONVERT(NVARCHAR(50), h.ORNumber) COLLATE Arabic_CI_AS,
       h.TransactionDate,
       CONVERT(NVARCHAR(50), h.ReferenceNo) COLLATE Arabic_CI_AS,
       CONVERT(VARCHAR(10), COALESCE(h.PaymentType, 'D')) COLLATE SQL_Latin1_General_CP1_CI_AS,
       CONVERT(NVARCHAR(300), h.Notes) COLLATE Arabic_CI_AS,
       payeeType.ExpectedPayeeType
FROM dbo.CkJournalItem AS i
INNER JOIN dbo.CkJournal AS h ON h.IdNo = i.JournalIdNo
INNER JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
CROSS APPLY (VALUES (CASE WHEN a.PayeeType IN ('C', 'S', 'E') THEN a.PayeeType
                          WHEN a.SpecialAccount IN ('AP', 'AS', 'PD') THEN 'S'
                          WHEN a.SpecialAccount IN ('AR', 'CA', 'SD') THEN 'C'
                          WHEN a.SpecialAccount = 'EL' THEN 'E' END)) AS payeeType(ExpectedPayeeType)
OUTER APPLY (
    SELECT TOP (1) resolved.PayeeCSEIdNo
    FROM (
        SELECT c.CSEIdNo AS PayeeCSEIdNo, 1 AS Priority
        FROM dbo.Contact_View AS c
        WHERE c.IdNo = i.PayIdNo AND c.CSECode = payeeType.ExpectedPayeeType
        UNION ALL
        SELECT legacy.ContactIdNo, 2
        FROM dbo.CSEContact_View AS legacy
        WHERE legacy.ContactIdNo = i.PayIdNo AND legacy.CSECode = payeeType.ExpectedPayeeType
    ) AS resolved
    ORDER BY resolved.Priority
) AS linePayee
WHERE ISNULL(h.Cancelled, 0) = 0

UNION ALL

SELECT 'ER', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo,
       i.Debit, i.Credit, i.RevCostCenterIdNo,
       CONVERT(NVARCHAR(300), i.Notes) COLLATE Arabic_CI_AS, i.Posted,
       COALESCE(linePayee.PayeeCSEIdNo,
           CASE WHEN payeeType.ExpectedPayeeType = 'E' THEN h.EmployeeIdNo END),
       CONVERT(NVARCHAR(50), h.ReferenceNo) COLLATE Arabic_CI_AS,
       h.TransactionDate,
       CONVERT(NVARCHAR(50), h.ReferenceNo) COLLATE Arabic_CI_AS,
       CONVERT(VARCHAR(10), COALESCE(h.TransactionType, 'E')) COLLATE SQL_Latin1_General_CP1_CI_AS,
       CONVERT(NVARCHAR(300), h.Notes) COLLATE Arabic_CI_AS,
       payeeType.ExpectedPayeeType
FROM dbo.ErJournalItem AS i
INNER JOIN dbo.ErJournal AS h ON h.IdNo = i.JournalIdNo
INNER JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
CROSS APPLY (VALUES (CASE WHEN a.PayeeType IN ('C', 'S', 'E') THEN a.PayeeType
                          WHEN a.SpecialAccount IN ('AP', 'AS', 'PD') THEN 'S'
                          WHEN a.SpecialAccount IN ('AR', 'CA', 'SD') THEN 'C'
                          WHEN a.SpecialAccount = 'EL' THEN 'E' END)) AS payeeType(ExpectedPayeeType)
OUTER APPLY (
    SELECT TOP (1) resolved.PayeeCSEIdNo
    FROM (
        SELECT c.CSEIdNo AS PayeeCSEIdNo, 1 AS Priority
        FROM dbo.Contact_View AS c
        WHERE c.IdNo = i.PayIdNo AND c.CSECode = payeeType.ExpectedPayeeType
        UNION ALL
        SELECT legacy.ContactIdNo, 2
        FROM dbo.CSEContact_View AS legacy
        WHERE legacy.ContactIdNo = i.PayIdNo AND legacy.CSECode = payeeType.ExpectedPayeeType
    ) AS resolved
    ORDER BY resolved.Priority
) AS linePayee
WHERE ISNULL(h.Cancelled, 0) = 0

UNION ALL

SELECT 'PC', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo,
       i.Debit, i.Credit, i.RevCostCenterIdNo,
       CONVERT(NVARCHAR(300), i.Notes) COLLATE Arabic_CI_AS, i.Posted,
       COALESCE(linePayee.PayeeCSEIdNo,
           CASE WHEN (payeeType.ExpectedPayeeType = 'S' AND h.PaymentType = 'A') OR
                          (payeeType.ExpectedPayeeType = 'C' AND h.PaymentType = 'R') OR
                          (payeeType.ExpectedPayeeType = 'E' AND h.PaymentType = 'E')
                THEN h.PayeeIdNo END),
       CONVERT(NVARCHAR(50), h.ORNumber) COLLATE Arabic_CI_AS,
       h.TransactionDate,
       CONVERT(NVARCHAR(50), h.ReferenceNo) COLLATE Arabic_CI_AS,
       CONVERT(VARCHAR(10), COALESCE(h.PaymentType, 'D')) COLLATE SQL_Latin1_General_CP1_CI_AS,
       CONVERT(NVARCHAR(300), h.Notes) COLLATE Arabic_CI_AS,
       payeeType.ExpectedPayeeType
FROM dbo.PcJournalItem AS i
INNER JOIN dbo.PcJournal AS h ON h.IdNo = i.JournalIdNo
INNER JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
CROSS APPLY (VALUES (CASE WHEN a.PayeeType IN ('C', 'S', 'E') THEN a.PayeeType
                          WHEN a.SpecialAccount IN ('AP', 'AS', 'PD') THEN 'S'
                          WHEN a.SpecialAccount IN ('AR', 'CA', 'SD') THEN 'C'
                          WHEN a.SpecialAccount = 'EL' THEN 'E' END)) AS payeeType(ExpectedPayeeType)
OUTER APPLY (
    SELECT TOP (1) resolved.PayeeCSEIdNo
    FROM (
        SELECT c.CSEIdNo AS PayeeCSEIdNo, 1 AS Priority
        FROM dbo.Contact_View AS c
        WHERE c.IdNo = i.PayIdNo AND c.CSECode = payeeType.ExpectedPayeeType
        UNION ALL
        SELECT legacy.ContactIdNo, 2
        FROM dbo.CSEContact_View AS legacy
        WHERE legacy.ContactIdNo = i.PayIdNo AND legacy.CSECode = payeeType.ExpectedPayeeType
    ) AS resolved
    ORDER BY resolved.Priority
) AS linePayee
WHERE ISNULL(h.Cancelled, 0) = 0

UNION ALL

SELECT 'GJ', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo,
       i.Debit, i.Credit, i.RevCostCenterIdNo,
       CONVERT(NVARCHAR(300), i.Notes) COLLATE Arabic_CI_AS, i.Posted,
       linePayee.PayeeCSEIdNo,
       CONVERT(NVARCHAR(50), h.ReferenceNo) COLLATE Arabic_CI_AS,
       h.TransactionDate,
       CONVERT(NVARCHAR(50), h.ReferenceNo) COLLATE Arabic_CI_AS,
       CONVERT(VARCHAR(10), 'G') COLLATE SQL_Latin1_General_CP1_CI_AS,
       CONVERT(NVARCHAR(300), h.Notes) COLLATE Arabic_CI_AS,
       payeeType.ExpectedPayeeType
FROM dbo.GeneralJournalItem AS i
INNER JOIN dbo.GeneralJournal AS h ON h.IdNo = i.JournalIdNo
INNER JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
CROSS APPLY (VALUES (CASE WHEN a.PayeeType IN ('C', 'S', 'E') THEN a.PayeeType
                          WHEN a.SpecialAccount IN ('AP', 'AS', 'PD') THEN 'S'
                          WHEN a.SpecialAccount IN ('AR', 'CA', 'SD') THEN 'C'
                          WHEN a.SpecialAccount = 'EL' THEN 'E' END)) AS payeeType(ExpectedPayeeType)
OUTER APPLY (
    SELECT TOP (1) resolved.PayeeCSEIdNo
    FROM (
        SELECT c.CSEIdNo AS PayeeCSEIdNo, 1 AS Priority
        FROM dbo.Contact_View AS c
        WHERE c.IdNo = i.PayIdNo AND c.CSECode = payeeType.ExpectedPayeeType
        UNION ALL
        SELECT legacy.ContactIdNo, 2
        FROM dbo.CSEContact_View AS legacy
        WHERE legacy.ContactIdNo = i.PayIdNo AND legacy.CSECode = payeeType.ExpectedPayeeType
    ) AS resolved
    ORDER BY resolved.Priority
) AS linePayee
WHERE ISNULL(h.Cancelled, 0) = 0

UNION ALL

SELECT 'SJ', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo,
       i.Debit, i.Credit, i.RevCostCenterIdNo,
       CONVERT(NVARCHAR(300), i.Notes) COLLATE Arabic_CI_AS, i.Posted,
       linePayee.PayeeCSEIdNo,
       CONVERT(NVARCHAR(50), h.ReferenceNo) COLLATE Arabic_CI_AS,
       h.TransactionDate,
       CONVERT(NVARCHAR(50), h.ReferenceNo) COLLATE Arabic_CI_AS,
       CONVERT(VARCHAR(10), 'S') COLLATE SQL_Latin1_General_CP1_CI_AS,
       CONVERT(NVARCHAR(300), h.Notes) COLLATE Arabic_CI_AS,
       payeeType.ExpectedPayeeType
FROM dbo.SalesJournalItem AS i
INNER JOIN dbo.SalesJournal AS h ON h.IdNo = i.JournalIdNo
INNER JOIN dbo.Account AS a ON a.IdNo = i.AccountIdNo
CROSS APPLY (VALUES (CASE WHEN a.PayeeType IN ('C', 'S', 'E') THEN a.PayeeType
                          WHEN a.SpecialAccount IN ('AP', 'AS', 'PD') THEN 'S'
                          WHEN a.SpecialAccount IN ('AR', 'CA', 'SD') THEN 'C'
                          WHEN a.SpecialAccount = 'EL' THEN 'E' END)) AS payeeType(ExpectedPayeeType)
OUTER APPLY (
    SELECT TOP (1) resolved.PayeeCSEIdNo
    FROM (
        SELECT c.CSEIdNo AS PayeeCSEIdNo, 1 AS Priority
        FROM dbo.Contact_View AS c
        WHERE c.IdNo = i.PayIdNo AND c.CSECode = payeeType.ExpectedPayeeType
        UNION ALL
        SELECT legacy.ContactIdNo, 2
        FROM dbo.CSEContact_View AS legacy
        WHERE legacy.ContactIdNo = i.PayIdNo AND legacy.CSECode = payeeType.ExpectedPayeeType
    ) AS resolved
    ORDER BY resolved.Priority
) AS linePayee
WHERE ISNULL(h.Cancelled, 0) = 0;

GO

-- Source: IspDataDb/dbo/Views/ARDetails_View.sql
ALTER VIEW [dbo].[ARDetails_View]
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
	  ,[PayorIdNo]
	  ,[ORNumber]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'P'
	  ,Concat(LTrim(b.Notes),IIf([CheckNumber]='','',' Chk#'+[CheckNumber])) AS 'MainNote'
	  ,[TransactionDate]
  FROM [dbo].[CashReceiptJournalItem] A
  RIGHT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PayorType='A' and b.Cancelled = 0
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
	  ,[PayeeIdNo]
	  ,[ORNumber]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'R'
	  ,b.Notes AS 'MainNote'
	  ,[TransactionDate]
  FROM [dbo].[CdJournalItem] A
  LEFT OUTER JOIN dbo.CdJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='R' and b.Cancelled = 0
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
	  ,[PayeeIdNo]
	  ,[ORNumber]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'R'
	  ,b.Notes AS 'MainNote'
	  ,[TransactionDate]
  FROM [dbo].[PcJournalItem] A
  LEFT OUTER JOIN dbo.PcJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='R' and b.Cancelled = 0
)
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

-- Source: IspDataDb/dbo/Views/APDetails_View.sql
ALTER VIEW [dbo].[APDetails_View]
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

-- Source: IspDataDb/dbo/Views/ARInvoices_View.sql
ALTER VIEW [dbo].[ARInvoices_View]
  AS
(SELECT 'AR' AS 'JournalCode'
	  ,a.[IdNo]
      ,a.[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit] as 'Amount'
	  ,dbo.FnResolveOpenInvoiceParty(a.PayIdNo, 'C', b.CustomerIdNo) AS CustomerIdNo
	  ,b.[InvoiceNo] COLLATE Arabic_CI_AS AS 'InvoiceNo'
	  ,b.[TransactionDate]
      ,b.[ReferenceNo] COLLATE Arabic_CI_AS AS 'ReferenceNo'
  FROM [dbo].[ArJournalItem] a
  RIGHT OUTER JOIN dbo.ArJournal b
  on a.JournalIdNo = b.IDNo
  LEFT Outer Join [dbo].[Account] c
  on a.AccountIdNo = c.idno
  where c.SpecialAccount='AR' and b.Cancelled = 0
)
UNION
(SELECT 'CR'
	  ,a.[IdNo]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit]
	  ,[PayorIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
  FROM [dbo].[CashReceiptJournalItem] A
  RIGHT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IDNo
  LEFT Outer Join [dbo].[Account] c
  on a.AccountIdNo = c.idno
  WHERE PayorType='A' AND B.UnApplied<>0 and (c.SpecialAccount='CA' OR c.SpecialAccount='AR') and b.Cancelled = 0
)
UNION
(SELECT 'CK'
	  ,a.[IdNo]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
  FROM [dbo].[CkJournalItem] A
  LEFT OUTER JOIN dbo.CkJournal b
  on a.JournalIdNo = b.IDNo
  LEFT Outer Join [dbo].[Account] c
  on a.AccountIdNo = c.idno
  WHERE PaymentType='R' AND C.SpecialAccount='AR' and b.Cancelled = 0
)
UNION
(SELECT 'CD'
	  ,a.[IdNo]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
  FROM [dbo].[CdJournalItem] A
  LEFT OUTER JOIN dbo.CdJournal b
  on a.JournalIdNo = b.IDNo
  LEFT Outer Join [dbo].[Account] c
  on a.AccountIdNo = c.idno
  WHERE PaymentType='R' AND c.SpecialAccount='AR' and b.Cancelled = 0
)
UNION
(SELECT 'PC'
	  ,a.[IdNo]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
  FROM [dbo].[PcJournalItem] A
  LEFT OUTER JOIN dbo.PcJournal b
  on a.JournalIdNo = b.IDNo
  LEFT Outer Join [dbo].[Account] c
  on a.AccountIdNo = c.idno
  WHERE PaymentType='R' AND c.SpecialAccount='AR' and b.Cancelled = 0
)
UNION
(SELECT 'BB'
	  ,IdNo
      ,1
      ,(Select AccountIdNo from DefaultAccounts where SpecialAccount='AR')
      ,OpeningBalance
	  ,IdNo
	  ,'Beg.Bal.'
	  ,(Select LastPostingDate from LastPosting where TransactionName = 'First Record')
      ,'Beg.Bal.'
   FROM [dbo].Customer
)

GO

-- Source: IspDataDb/dbo/Stored Procedures/SaveArJournalAtomic.sql
ALTER PROCEDURE dbo.SaveArJournalAtomic
    @CustomerIdNo int, @TransactionDate date, @ReferenceNo varchar(15)=NULL,
    @TransactionType char(1)=NULL, @Amount money, @AccountIdNo int,
    @DueDate date=NULL, @SettlementDueDate date=NULL,
    @SettlementDiscount decimal(5,2)=NULL, @InvoiceNo varchar(15),
    @InvoiceDate date=NULL, @VatAmount money=NULL, @Notes nvarchar(600),
    @Approved bit=0, @Posted bit=0, @Items dbo.JournalItemInsert READONLY,
    @JournalIdNo int OUTPUT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    IF @TransactionDate >= '20260101' AND NOT EXISTS (SELECT 1 FROM @Items)
        THROW 51100, 'AR journal must contain at least one detail line.', 1;
    IF @TransactionDate >= '20260101' AND EXISTS (SELECT 1 FROM @Items WHERE Debit<0 OR Credit<0 OR (Debit<>0 AND Credit<>0))
        THROW 51101, 'AR detail lines contain invalid debit/credit values.', 1;
    IF @TransactionDate >= '20260101' AND ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items)-(SELECT COALESCE(SUM(Credit),0) FROM @Items)) > 0.00005
        THROW 51102, 'AR journal debits and credits are not balanced.', 1;
    IF EXISTS (
        SELECT 1 FROM @Items i
        INNER JOIN dbo.Account a ON a.IdNo = i.AccountIdNo
        WHERE a.SpecialAccount = 'AR'
          AND (i.Debit <> 0 OR i.Credit <> 0)
          AND (ISNULL(i.PayIdNo, 0) <= 0
            OR dbo.FnResolveOpenInvoiceParty(i.PayIdNo, 'C', @CustomerIdNo) IS NULL))
        THROW 51104, 'AR detail lines require a valid customer contact.', 1;

    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT dbo.ArJournal(CustomerIdNo,TransactionDate,ReferenceNo,TransactionType,Amount,AccountIdNo,DueDate,SettlementDueDate,SettlementDiscount,InvoiceNo,InvoiceDate,Notes,VatAmount,Approved,Posted,Cancelled)
        VALUES(@CustomerIdNo,@TransactionDate,@ReferenceNo,@TransactionType,@Amount,@AccountIdNo,@DueDate,@SettlementDueDate,@SettlementDiscount,@InvoiceNo,@InvoiceDate,@Notes,@VatAmount,@Approved,@Posted,0);
        SET @JournalIdNo=CONVERT(int,SCOPE_IDENTITY());
        INSERT dbo.ArJournalItem(AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence)
        SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;
        IF @TransactionDate >= '20260101' AND ABS((SELECT COALESCE(SUM(Debit),0) FROM dbo.ArJournalItem WHERE JournalIdNo=@JournalIdNo)-(SELECT COALESCE(SUM(Credit),0) FROM dbo.ArJournalItem WHERE JournalIdNo=@JournalIdNo)) > 0.00005
            THROW 51103, 'AR journal is not balanced after insertion.', 1;
        INSERT dbo.ArOpenInvoice(JournalCode,JournalIdNo,JournalItemIdNo,PaidAmount,DiscountTaken)
        SELECT 'AR',@JournalIdNo,i.IdNo,0,0 FROM dbo.ArJournalItem i INNER JOIN dbo.Account a ON a.IdNo=i.AccountIdNo
        WHERE i.JournalIdNo=@JournalIdNo AND a.SpecialAccount='AR';
        IF NULLIF(LTRIM(RTRIM(@ReferenceNo)), '') IS NULL
        BEGIN
            DECLARE @seriesName varchar(20)='GL'+CONVERT(varchar(4),YEAR(@TransactionDate))+RIGHT('0'+CONVERT(varchar(2),MONTH(@TransactionDate)),2),@prefix varchar(10),@maxLength int,@seriesValue int;
            SELECT @seriesValue=Value,@prefix=Prefix,@maxLength=MaxLength FROM dbo.Series WITH(UPDLOCK,HOLDLOCK) WHERE SeriesName=@seriesName;
            IF @prefix IS NULL BEGIN SET @prefix=RIGHT('0'+CONVERT(varchar(2),MONTH(@TransactionDate)),2)+'-'; SET @maxLength=3; SET @seriesValue=0; INSERT dbo.Series(SeriesName,Value,MaxLength,Prefix,Description) VALUES(@seriesName,0,@maxLength,@prefix,'GL Series for '+@seriesName); END;
            SET @seriesValue=@seriesValue+1; UPDATE dbo.Series SET Value=@seriesValue WHERE SeriesName=@seriesName;
            UPDATE dbo.ArJournal SET ReferenceNo=@prefix+RIGHT(REPLICATE('0',@maxLength)+CONVERT(varchar(20),@seriesValue),@maxLength) WHERE IdNo=@JournalIdNo;
        END;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE()<>0 ROLLBACK TRANSACTION; THROW;
    END CATCH;
END;
GO

-- Source: IspDataDb/dbo/Stored Procedures/UpdateArJournalAtomic.sql
ALTER PROCEDURE dbo.UpdateArJournalAtomic
 @JournalIdNo int,@CustomerIdNo int,@TransactionDate date,@ReferenceNo varchar(15)=NULL,@TransactionType char(1)=NULL,@Amount money,@AccountIdNo int,@DueDate date=NULL,@SettlementDueDate date=NULL,@SettlementDiscount decimal(5,2)=NULL,@InvoiceNo varchar(15),@InvoiceDate date=NULL,@Notes nvarchar(600),@VatAmount money=NULL,@Approved bit=0,@Posted bit=0,@Items dbo.JournalItemInsert READONLY
AS
BEGIN
 SET NOCOUNT ON; SET XACT_ABORT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.ArJournal WHERE IdNo=@JournalIdNo) THROW 51110,'AR journal was not found.',1;
 IF EXISTS(SELECT 1 FROM dbo.ArJournal WHERE IdNo=@JournalIdNo AND Posted=1) THROW 51114,'Posted AR journals cannot be edited.',1;
 IF EXISTS(SELECT 1 FROM dbo.Reconciled r INNER JOIN dbo.ArJournalItem i ON i.IdNo=r.JournalItemIdNo WHERE r.JournalCode='AR' AND i.JournalIdNo=@JournalIdNo) THROW 51111,'AR journal contains reconciled detail lines and cannot be edited.',1;
 EXEC dbo.AssertJournalNotReconciliationLocked @JournalCode='AR', @JournalIdNo=@JournalIdNo;
  IF EXISTS(SELECT 1 FROM dbo.ArOpenInvoice o WHERE o.JournalCode='AR' AND (o.JournalIdNo=@JournalIdNo OR EXISTS(SELECT 1 FROM dbo.ArJournalItem i WHERE i.JournalIdNo=@JournalIdNo AND i.IdNo=o.JournalItemIdNo)) AND EXISTS(SELECT 1 FROM dbo.CsrOiItem c WHERE c.ArOpenInvoiceIdNo=o.IdNo)) THROW 51112,'AR journal has CR collections and cannot be edited.',1;
 IF @TransactionDate>='20260101' AND (NOT EXISTS(SELECT 1 FROM @Items) OR ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items)-(SELECT COALESCE(SUM(Credit),0) FROM @Items)) > 0.00005) THROW 51113,'AR journal details are not balanced.',1;
    IF EXISTS (
        SELECT 1 FROM @Items i
        INNER JOIN dbo.Account a ON a.IdNo = i.AccountIdNo
        WHERE a.SpecialAccount = 'AR'
          AND (i.Debit <> 0 OR i.Credit <> 0)
          AND (ISNULL(i.PayIdNo, 0) <= 0
            OR dbo.FnResolveOpenInvoiceParty(i.PayIdNo, 'C', @CustomerIdNo) IS NULL))
        THROW 51115, 'AR detail lines require a valid customer contact.', 1;

 BEGIN TRANSACTION;
 BEGIN TRY
  UPDATE dbo.ArJournal SET CustomerIdNo=@CustomerIdNo,TransactionDate=@TransactionDate,ReferenceNo=@ReferenceNo,TransactionType=@TransactionType,Amount=@Amount,AccountIdNo=@AccountIdNo,DueDate=@DueDate,SettlementDueDate=@SettlementDueDate,SettlementDiscount=@SettlementDiscount,InvoiceNo=@InvoiceNo,InvoiceDate=@InvoiceDate,Notes=@Notes,VatAmount=@VatAmount,Approved=@Approved,Posted=@Posted WHERE IdNo=@JournalIdNo;
   DELETE o FROM dbo.ArOpenInvoice o WHERE o.JournalCode='AR' AND (o.JournalIdNo=@JournalIdNo OR EXISTS(SELECT 1 FROM dbo.ArJournalItem i WHERE i.JournalIdNo=@JournalIdNo AND i.IdNo=o.JournalItemIdNo));
  DELETE FROM dbo.ArJournalItem WHERE JournalIdNo=@JournalIdNo;
  INSERT dbo.ArJournalItem(AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence) SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;
  INSERT dbo.ArOpenInvoice(JournalCode,JournalIdNo,JournalItemIdNo,PaidAmount,DiscountTaken) SELECT 'AR',@JournalIdNo,i.IdNo,0,0 FROM dbo.ArJournalItem i INNER JOIN dbo.Account a ON a.IdNo=i.AccountIdNo WHERE i.JournalIdNo=@JournalIdNo AND a.SpecialAccount='AR';
  COMMIT TRANSACTION;
 END TRY BEGIN CATCH IF XACT_STATE()<>0 ROLLBACK TRANSACTION; THROW; END CATCH;
END;
GO

-- Source: IspDataDb/dbo/Stored Procedures/SaveApJournalAtomic.sql
ALTER PROCEDURE dbo.SaveApJournalAtomic
    @SupplierIdNo int,
    @TransactionDate date,
    @ReferenceNo varchar(15) = NULL,
    @TransactionType char(1) = NULL,
    @Amount money,
    @AccountIdNo int,
    @DueDate date = NULL,
    @SettlementDueDate date = NULL,
    @SettlementDiscount decimal(5,2) = NULL,
    @InvoiceNo varchar(15),
    @InvoiceDate date = NULL,
    @VatNumber varchar(15) = NULL,
    @VatAmount money = NULL,
    @Notes nvarchar(600),
    @Approved bit = 0,
    @Posted bit = 0,
    @Items dbo.JournalItemInsert READONLY,
    @JournalIdNo int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @TransactionDate >= '20260101' AND NOT EXISTS (SELECT 1 FROM @Items)
        THROW 51010, 'AP journal must contain at least one detail line.', 1;

    IF @TransactionDate >= '20260101' AND EXISTS (
        SELECT 1 FROM @Items WHERE Debit < 0 OR Credit < 0 OR (Debit <> 0 AND Credit <> 0))
        THROW 51011, 'AP detail lines contain invalid debit/credit values.', 1;

    IF @TransactionDate >= '20260101' AND EXISTS (
        SELECT 1 FROM @Items WHERE AccountIdNo IS NULL OR AccountIdNo = 0)
        THROW 51012, 'AP detail lines require an account.', 1;

    IF @TransactionDate >= '20260101' AND
       ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items) -
           (SELECT COALESCE(SUM(Credit),0) FROM @Items)) > 0.00005
        THROW 51013, 'AP journal debits and credits are not balanced.', 1;

    IF EXISTS (
        SELECT 1 FROM @Items i
        INNER JOIN dbo.Account a ON a.IdNo = i.AccountIdNo
        WHERE a.SpecialAccount = 'AP'
          AND (i.Debit <> 0 OR i.Credit <> 0)
          AND (ISNULL(i.PayIdNo, 0) <= 0
            OR dbo.FnResolveOpenInvoiceParty(i.PayIdNo, 'S', @SupplierIdNo) IS NULL))
        THROW 51016, 'AP detail lines require a valid supplier contact.', 1;

    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT dbo.ApJournal
        (SupplierIdNo, TransactionDate, ReferenceNo, TransactionType, Amount, AccountIdNo,
         DueDate, SettlementDueDate, SettlementDiscount, InvoiceNo, InvoiceDate, VatNumber,
         VatAmount, Notes, Approved, Posted, Cancelled)
        VALUES
        (@SupplierIdNo, @TransactionDate, @ReferenceNo, @TransactionType, @Amount, @AccountIdNo,
         @DueDate, @SettlementDueDate, @SettlementDiscount, @InvoiceNo, @InvoiceDate, @VatNumber,
         @VatAmount, @Notes, @Approved, @Posted, 0);

        SET @JournalIdNo = CONVERT(int, SCOPE_IDENTITY());

        INSERT dbo.ApJournalItem
        (AccountIdNo, Credit, Debit, JournalIdNo, Notes, PayIdNo, RevCostCenterIdNo, Sequence)
        SELECT AccountIdNo, Credit, Debit, @JournalIdNo, Notes, PayIdNo, RevCostCenterIdNo, Sequence
        FROM @Items;

        IF @TransactionDate >= '20260101' AND
           (SELECT COUNT(*) FROM dbo.ApJournalItem WHERE JournalIdNo = @JournalIdNo) = 0
            THROW 51014, 'AP journal detail insertion failed.', 1;

        IF @TransactionDate >= '20260101' AND
           ABS((SELECT COALESCE(SUM(Debit),0) FROM dbo.ApJournalItem WHERE JournalIdNo = @JournalIdNo) -
               (SELECT COALESCE(SUM(Credit),0) FROM dbo.ApJournalItem WHERE JournalIdNo = @JournalIdNo)) > 0.00005
            THROW 51015, 'AP journal is not balanced after insertion.', 1;

        INSERT dbo.ApOpenInvoice (JournalCode, JournalIdNo, JournalItemIdNo, PaidAmount, DiscountTaken)
        SELECT 'AP', @JournalIdNo, i.IdNo, 0, 0
        FROM dbo.ApJournalItem i
        INNER JOIN dbo.Account a ON a.IdNo = i.AccountIdNo
        WHERE i.JournalIdNo = @JournalIdNo
          AND a.SpecialAccount = 'AP';

        IF @VatNumber IS NOT NULL AND LTRIM(RTRIM(@VatNumber)) <> ''
            UPDATE dbo.Supplier
            SET VatNumber = @VatNumber
            WHERE IdNo = @SupplierIdNo AND (VatNumber IS NULL OR VatNumber = '');

        -- Generate a GL reference only when the user did not supply one.
        IF NULLIF(LTRIM(RTRIM(@ReferenceNo)), '') IS NULL
        BEGIN
            DECLARE @seriesName varchar(20) = 'GL' + CONVERT(varchar(4), YEAR(@TransactionDate)) +
                                              RIGHT('0' + CONVERT(varchar(2), MONTH(@TransactionDate)), 2);
            DECLARE @prefix varchar(10), @maxLength int, @seriesValue int;
            SELECT @seriesValue = Value, @prefix = Prefix, @maxLength = MaxLength
            FROM dbo.Series WITH (UPDLOCK, HOLDLOCK)
            WHERE SeriesName = @seriesName;

            IF @prefix IS NULL
            BEGIN
                SET @prefix = RIGHT('0' + CONVERT(varchar(2), MONTH(@TransactionDate)), 2) + '-';
                SET @maxLength = 3;
                SET @seriesValue = 0;
                INSERT dbo.Series (SeriesName, Value, MaxLength, Prefix, Description)
                VALUES (@seriesName, 0, @maxLength, @prefix, 'GL Series for ' + @seriesName);
            END;

            SET @seriesValue = @seriesValue + 1;
            UPDATE dbo.Series SET Value = @seriesValue WHERE SeriesName = @seriesName;
            UPDATE dbo.ApJournal
            SET ReferenceNo = @prefix + RIGHT(REPLICATE('0', @maxLength) + CONVERT(varchar(20), @seriesValue), @maxLength)
            WHERE IdNo = @JournalIdNo;
        END;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @JournalIdNo = 0;
        THROW;
    END CATCH;
END;
GO

-- Source: IspDataDb/dbo/Stored Procedures/UpdateApJournalAtomic.sql
ALTER PROCEDURE dbo.UpdateApJournalAtomic
    @JournalIdNo int,
    @SupplierIdNo int,
    @TransactionDate date,
    @ReferenceNo varchar(15) = NULL,
    @TransactionType char(1) = NULL,
    @Amount money,
    @AccountIdNo int,
    @DueDate date = NULL,
    @SettlementDueDate date = NULL,
    @SettlementDiscount decimal(5,2) = NULL,
    @InvoiceNo varchar(15),
    @InvoiceDate date = NULL,
    @VatNumber varchar(15) = NULL,
    @VatAmount money = NULL,
    @Notes nvarchar(600),
    @Approved bit = 0,
    @Posted bit = 0,
    @Items dbo.JournalItemInsert READONLY
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.ApJournal WHERE IdNo = @JournalIdNo)
        THROW 51020, 'AP journal was not found.', 1;
    IF EXISTS (SELECT 1 FROM dbo.ApJournal WHERE IdNo = @JournalIdNo AND Posted = 1)
        THROW 51026, 'Posted AP journals cannot be edited.', 1;
    IF EXISTS (SELECT 1 FROM dbo.Reconciled r
               INNER JOIN dbo.ApJournalItem i ON i.IdNo = r.JournalItemIdNo
               WHERE r.JournalCode = 'AP' AND i.JournalIdNo = @JournalIdNo)
        THROW 51025, 'AP journal contains reconciled detail lines and cannot be edited.', 1;
    EXEC dbo.AssertJournalNotReconciliationLocked @JournalCode = 'AP', @JournalIdNo = @JournalIdNo;
    IF @TransactionDate >= '20260101' AND NOT EXISTS (SELECT 1 FROM @Items)
        THROW 51021, 'AP journal must contain at least one detail line.', 1;
    IF EXISTS (SELECT 1 FROM dbo.ApOpenInvoice o
               WHERE o.JournalCode = 'AP'
                 AND (o.JournalIdNo = @JournalIdNo
                   OR EXISTS (SELECT 1 FROM dbo.ApJournalItem i
                              WHERE i.JournalIdNo = @JournalIdNo
                                AND i.IdNo = o.JournalItemIdNo))
                 AND (EXISTS (SELECT 1 FROM dbo.CdOiItem d WHERE d.ApOpenInvoiceIdNo=o.IdNo)
                   OR EXISTS (SELECT 1 FROM dbo.CkOiItem k WHERE k.ApOpenInvoiceIdNo=o.IdNo)
                   OR EXISTS (SELECT 1 FROM dbo.PcOiItem p WHERE p.ApOpenInvoiceIdNo=o.IdNo)))
        THROW 51022, 'AP journal has dependent payment records and cannot be edited.', 1;
    IF @TransactionDate >= '20260101' AND EXISTS (
        SELECT 1 FROM @Items WHERE Debit < 0 OR Credit < 0 OR (Debit <> 0 AND Credit <> 0))
        THROW 51023, 'AP detail lines contain invalid debit/credit values.', 1;
    IF @TransactionDate >= '20260101' AND
       ABS((SELECT COALESCE(SUM(Debit),0) FROM @Items) -
           (SELECT COALESCE(SUM(Credit),0) FROM @Items)) > 0.00005
        THROW 51024, 'AP journal debits and credits are not balanced.', 1;

    IF EXISTS (
        SELECT 1 FROM @Items i
        INNER JOIN dbo.Account a ON a.IdNo = i.AccountIdNo
        WHERE a.SpecialAccount = 'AP'
          AND (i.Debit <> 0 OR i.Credit <> 0)
          AND (ISNULL(i.PayIdNo, 0) <= 0
            OR dbo.FnResolveOpenInvoiceParty(i.PayIdNo, 'S', @SupplierIdNo) IS NULL))
        THROW 51027, 'AP detail lines require a valid supplier contact.', 1;

    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE dbo.ApJournal SET SupplierIdNo=@SupplierIdNo, TransactionDate=@TransactionDate,
            ReferenceNo=@ReferenceNo, TransactionType=@TransactionType, Amount=@Amount,
            AccountIdNo=@AccountIdNo, DueDate=@DueDate, SettlementDueDate=@SettlementDueDate,
            SettlementDiscount=@SettlementDiscount, InvoiceNo=@InvoiceNo, InvoiceDate=@InvoiceDate,
            VatNumber=@VatNumber, VatAmount=@VatAmount, Notes=@Notes, Approved=@Approved, Posted=@Posted
        WHERE IdNo=@JournalIdNo;

        DELETE o
        FROM dbo.ApOpenInvoice o
        WHERE o.JournalCode='AP'
          AND (o.JournalIdNo=@JournalIdNo
            OR EXISTS (SELECT 1 FROM dbo.ApJournalItem i
                       WHERE i.JournalIdNo=@JournalIdNo
                         AND i.IdNo=o.JournalItemIdNo));
        DELETE FROM dbo.ApJournalItem WHERE JournalIdNo=@JournalIdNo;
        INSERT dbo.ApJournalItem (AccountIdNo,Credit,Debit,JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence)
        SELECT AccountIdNo,Credit,Debit,@JournalIdNo,Notes,PayIdNo,RevCostCenterIdNo,Sequence FROM @Items;
        INSERT dbo.ApOpenInvoice (JournalCode,JournalIdNo,JournalItemIdNo,PaidAmount,DiscountTaken)
        SELECT 'AP',@JournalIdNo,i.IdNo,0,0 FROM dbo.ApJournalItem i
        INNER JOIN dbo.Account a ON a.IdNo=i.AccountIdNo
        WHERE i.JournalIdNo=@JournalIdNo AND a.SpecialAccount='AP';
        IF @VatNumber IS NOT NULL AND LTRIM(RTRIM(@VatNumber)) <> ''
            UPDATE dbo.Supplier SET VatNumber=@VatNumber
            WHERE IdNo=@SupplierIdNo AND (VatNumber IS NULL OR VatNumber='');
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

COMMIT TRANSACTION;
GO
