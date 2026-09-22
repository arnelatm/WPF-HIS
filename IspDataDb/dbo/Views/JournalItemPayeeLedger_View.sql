CREATE VIEW [dbo].[JournalItemPayeeLedger_View]
AS
SELECT 'AP' AS JournalCode, i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo,
       i.Debit, i.Credit, i.RevCostCenterIdNo,
       CONVERT(NVARCHAR(300), i.Notes) COLLATE Arabic_CI_AS AS Notes, i.Posted,
       COALESCE(linePayee.PayeeCSEIdNo,
           CASE WHEN payeeType.ExpectedPayeeType = 'S' THEN h.SupplierIdNo END) AS PayeeCSEIdNo,
       CONVERT(NVARCHAR(50), h.InvoiceNo) COLLATE Arabic_CI_AS AS InvoiceNo,
       h.TransactionDate,
       CONVERT(NVARCHAR(50), h.ReferenceNo) COLLATE Arabic_CI_AS AS ReferenceNo,
       CONVERT(VARCHAR(10), COALESCE(h.TransactionType, 'A')) COLLATE SQL_Latin1_General_CP1_CI_AS AS TransactionType,
       CONVERT(NVARCHAR(300), h.Notes) COLLATE Arabic_CI_AS AS MainNote,
       payeeType.ExpectedPayeeType
FROM dbo.ApJournalItem AS i
INNER JOIN dbo.ApJournal AS h ON h.IdNo = i.JournalIdNo
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

SELECT 'AR', i.IdNo, i.Sequence, i.JournalIdNo, i.AccountIdNo,
       i.Debit, i.Credit, i.RevCostCenterIdNo,
       CONVERT(NVARCHAR(300), i.Notes) COLLATE Arabic_CI_AS, i.Posted,
       COALESCE(linePayee.PayeeCSEIdNo,
           CASE WHEN payeeType.ExpectedPayeeType = 'C' THEN h.CustomerIdNo END),
       CONVERT(NVARCHAR(50), h.InvoiceNo) COLLATE Arabic_CI_AS,
       h.TransactionDate,
       CONVERT(NVARCHAR(50), h.ReferenceNo) COLLATE Arabic_CI_AS,
       CONVERT(VARCHAR(10), COALESCE(h.TransactionType, 'R')) COLLATE SQL_Latin1_General_CP1_CI_AS,
       CONVERT(NVARCHAR(300), h.Notes) COLLATE Arabic_CI_AS,
       payeeType.ExpectedPayeeType
FROM dbo.ArJournalItem AS i
INNER JOIN dbo.ArJournal AS h ON h.IdNo = i.JournalIdNo
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
