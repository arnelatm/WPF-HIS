
CREATE VIEW [dbo].[PurchaseDetail_View]
AS
SELECT        dbo.PurchaseDetail.IdNo, dbo.PurchaseDetail.Sequence, dbo.PurchaseDetail.JournalIdNo, dbo.PurchaseDetail.AccountIdNo, dbo.PurchaseDetail.Debit, dbo.PurchaseDetail.Credit, dbo.PurchaseDetail.RevCostCenterIdNo, 
                         dbo.PurchaseDetail.Notes, dbo.PurchaseDetail.Posted, dbo.PurchaseDetail.DateTimeStamp, dbo.Account.AccountName, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.IdNo AS OpenInvoiceIdNo, 
                         dbo.PurchaseDetail.Credit - dbo.PurchaseDetail.Debit AS OriginalAmount, dbo.ApOpenInvoice.PaidAmount, dbo.Account.SpecialAccount, dbo.Account.AccountNameAra, dbo.Account.PayeeType
FROM            dbo.PurchaseDetail LEFT OUTER JOIN
                         dbo.Account ON dbo.PurchaseDetail.AccountIdNo = dbo.Account.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.PurchaseDetail.IdNo = dbo.ApOpenInvoice.JournalItemIdNo
