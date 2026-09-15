USE [ISPData];
GO

ALTER VIEW [dbo].[ApInvoices_View]
AS
SELECT
    oi.JournalCode,
    oi.JournalItemIdNo,
    d.AccountIdNo,
    d.Debit,
    d.Credit,
    d.RevCostCenterIdNo,
    d.Notes,
    d.Posted,
    a.AccountCode,
    a.AccountName,
    a.AccountNameAra,
    d.SupplierIdNo,
    d.InvoiceNo,
    d.TransactionDate,
    d.ReferenceNo,
    d.TransactionType,
    oi.PaidAmount,
    oi.DiscountTaken,
    a.SpecialAccount,
    oi.IdNo,
    oi.JournalIdNo,
    s.SupplierCode
FROM dbo.Supplier s
RIGHT OUTER JOIN dbo.APDetails_View d
    ON s.IdNo = d.SupplierIdNo
RIGHT OUTER JOIN dbo.ApOpenInvoice_View oi
    ON d.IdNo = oi.JournalItemIdNo
   AND d.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS = oi.JournalCode
LEFT OUTER JOIN dbo.Account a
    ON d.AccountIdNo = a.IdNo;
GO

ALTER VIEW [dbo].[ApJournalItem_View]
AS
SELECT
    i.IdNo,
    i.Sequence,
    i.JournalIdNo,
    i.AccountIdNo,
    i.Debit,
    i.Credit,
    i.RevCostCenterIdNo,
    i.Notes,
    i.Posted,
    i.DateTimeStamp,
    a.AccountName,
    oi.JournalCode,
    oi.IdNo AS OpenInvoiceIdNo,
    i.Credit - i.Debit AS OriginalAmount,
    oi.PaidAmount,
    oi.DiscountTaken,
    a.SpecialAccount,
    a.AccountNameAra,
    a.PayeeType,
    i.PayIdNo
FROM dbo.ApJournalItem i
LEFT JOIN dbo.ApJournal j
    ON i.JournalIdNo = j.IdNo
LEFT JOIN dbo.Account a
    ON i.AccountIdNo = a.IdNo
LEFT JOIN dbo.ApOpenInvoice_View oi
    ON i.IdNo = oi.JournalItemIdNo
   AND oi.JournalCode = 'AP'
WHERE j.Cancelled = 0;
GO

ALTER VIEW [dbo].[CashReceiptJournalItem_View]
AS
SELECT
    i.IdNo,
    i.Sequence,
    i.JournalIdNo,
    i.AccountIdNo,
    i.Debit,
    i.Credit,
    i.RevCostCenterIdNo,
    i.Notes,
    i.Posted,
    i.DateTimeStamp,
    a.AccountName,
    oi.JournalCode,
    oi.IdNo AS OpenInvoiceIdNo,
    i.Credit - i.Debit AS OriginalAmount,
    oi.PaidAmount,
    a.SpecialAccount,
    a.AccountNameAra,
    a.PayeeType,
    oi.DiscountTaken,
    i.PayIdNo
FROM dbo.CashReceiptJournalItem i
INNER JOIN dbo.CashReceiptJournal j
    ON j.IdNo = i.JournalIdNo
LEFT JOIN dbo.ApOpenInvoice_View oi
    ON i.IdNo = oi.JournalItemIdNo
   AND oi.JournalCode = 'AP'
LEFT JOIN dbo.Account a
    ON i.AccountIdNo = a.IdNo
WHERE j.Cancelled = 0;
GO

ALTER VIEW dbo.CdJournalItem_View
AS
SELECT
    i.AccountIdNo,
    i.Credit,
    i.Debit,
    i.IdNo,
    i.JournalIdNo,
    i.Notes,
    i.RevCostCenterIdNo,
    i.Sequence,
    a.AccountName,
    i.Debit - i.Credit AS OriginalAmount,
    a.PayeeType,
    a.SpecialAccount,
    0 AS OpenInvoiceIdNo,
    0 AS PaidAmount,
    oi.PaidAmount AS Expr1,
    oi.DiscountTaken,
    i.PayIdNo
FROM dbo.CdJournal j
LEFT JOIN dbo.CdJournalItem i
    ON j.IdNo = i.JournalIdNo
LEFT JOIN dbo.Account a
    ON i.AccountIdNo = a.IdNo
LEFT JOIN dbo.ApOpenInvoice_View oi
    ON i.JournalIdNo = oi.JournalItemIdNo;
GO

ALTER VIEW dbo.CkJournalItem_View
AS
SELECT
    i.AccountIdNo,
    i.Credit,
    i.Debit,
    i.IdNo,
    i.JournalIdNo,
    i.Notes,
    i.RevCostCenterIdNo,
    i.Sequence,
    a.AccountName,
    i.Debit - i.Credit AS OriginalAmount,
    a.PayeeType,
    a.SpecialAccount,
    0 AS OpenInvoiceIdNo,
    0 AS PaidAmount,
    oi.PaidAmount AS Expr1,
    oi.DiscountTaken,
    i.PayIdNo
FROM dbo.CkJournal j
LEFT JOIN dbo.CkJournalItem i
    ON j.IdNo = i.JournalIdNo
LEFT JOIN dbo.Account a
    ON i.AccountIdNo = a.IdNo
LEFT JOIN dbo.ApOpenInvoice_View oi
    ON i.JournalIdNo = oi.JournalItemIdNo;
GO

ALTER VIEW [dbo].[GeneralJournalItem_View]
AS
SELECT
    i.IdNo,
    i.Sequence,
    i.JournalIdNo,
    i.AccountIdNo,
    i.Debit,
    i.Credit,
    i.RevCostCenterIdNo,
    i.Notes,
    a.AccountName,
    i.Debit - i.Credit AS OriginalAmount,
    a.PayeeType,
    a.SpecialAccount,
    0 AS OpenInvoiceIdNo,
    0 AS PaidAmount,
    oi.PaidAmount AS Expr1,
    oi.DiscountTaken,
    i.PayIdNo,
    IIF(a.SpecialAccount = 'AR', c.CustomerCode,
        IIF(a.SpecialAccount = 'AP', s.SupplierCode,
            IIF(a.SpecialAccount = 'EL', e.EmployeeCode, ''))) AS PayCode,
    IIF(a.SpecialAccount = 'AR', c.CustomerName,
        IIF(a.SpecialAccount = 'AP', s.SupplierName,
            IIF(a.SpecialAccount = 'EL', e.EmployeeName, ''))) AS PayName,
    IIF(a.SpecialAccount = 'AR', c.CustomerNameAra,
        IIF(a.SpecialAccount = 'AP', s.SupplierNameAra,
            IIF(a.SpecialAccount = 'EL', e.EmployeeNameAra, ''))) AS PayNameAra
FROM dbo.GeneralJournalItem i
LEFT JOIN dbo.Account a
    ON i.AccountIdNo = a.IdNo
LEFT JOIN dbo.Customer c
    ON i.PayIdNo = c.IdNo
LEFT JOIN dbo.Supplier s
    ON i.PayIdNo = s.IdNo
LEFT JOIN dbo.Employee e
    ON i.PayIdNo = e.IdNo
LEFT JOIN dbo.ApOpenInvoice_View oi
    ON i.JournalIdNo = oi.JournalItemIdNo
   AND oi.JournalCode = 'GJ';
GO

ALTER VIEW dbo.PcJournalItem_View
AS
SELECT
    i.AccountIdNo,
    i.Credit,
    i.Debit,
    i.IdNo,
    i.JournalIdNo,
    i.Notes,
    i.RevCostCenterIdNo,
    i.Sequence,
    a.AccountName,
    i.Debit - i.Credit AS OriginalAmount,
    a.PayeeType,
    a.SpecialAccount,
    0 AS OpenInvoiceIdNo,
    0 AS PaidAmount,
    oi.PaidAmount AS Expr1,
    oi.DiscountTaken,
    i.PayIdNo
FROM dbo.PcJournalItem i
LEFT JOIN dbo.Account a
    ON i.AccountIdNo = a.IdNo
LEFT JOIN dbo.ApOpenInvoice_View oi
    ON i.JournalIdNo = oi.JournalItemIdNo
   AND oi.JournalCode = 'PC';
GO

ALTER VIEW [dbo].[SupplierInvoices]
AS
SELECT
    oi.IdNo,
    oi.JournalCode,
    oi.JournalItemIdNo,
    oi.PaidAmount,
    oi.DiscountTaken,
    i.Debit,
    i.Credit,
    i.RevCostCenterIdNo,
    i.Notes,
    i.Posted,
    i.AccountIdNo,
    i.JournalIdNo,
    i.Sequence,
    j.SupplierIdNo,
    j.InvoiceNo,
    j.InvoiceDate,
    s.SupplierCode,
    s.SupplierName,
    s.SupplierNameAra
FROM dbo.Account a
INNER JOIN dbo.ApJournalItem i
    ON a.IdNo = i.AccountIdNo
INNER JOIN dbo.ApJournal j
    ON i.JournalIdNo = j.IdNo
INNER JOIN dbo.Supplier s
    ON j.SupplierIdNo = s.IdNo
RIGHT JOIN dbo.ApOpenInvoice_View oi
    ON i.IdNo = oi.JournalItemIdNo;
GO
