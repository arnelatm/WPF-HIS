
CREATE VIEW [dbo].[GeneralJournalItem_View]
AS
SELECT        dbo.GeneralJournalItem.IdNo, dbo.GeneralJournalItem.Sequence, dbo.GeneralJournalItem.JournalIdNo, dbo.GeneralJournalItem.AccountIdNo, dbo.GeneralJournalItem.Debit, dbo.GeneralJournalItem.Credit, 
                         dbo.GeneralJournalItem.RevCostCenterIdNo, dbo.GeneralJournalItem.Notes, dbo.Account.AccountName, dbo.GeneralJournalItem.Debit - dbo.GeneralJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, 
                         dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 0 AS PaidAmount, dbo.ApOpenInvoice_View.PaidAmount AS Expr1, dbo.ApOpenInvoice_View.DiscountTaken, dbo.GeneralJournalItem.PayIdNo,
                         ContactData.IdNo AS ContactIdNo,
                         ContactData.CSEIdNo AS ContactCSEIdNo,
                         ContactData.CSECode AS ContactCSECode,
                         ContactData.ContactCode AS ContactCode,
                         ContactData.ContactName AS ContactName,
                         ContactData.ContactNameAra AS ContactNameAra,
                         ContactData.ContactCode AS PayCode,
                         ContactData.ContactName AS PayName,
                         ContactData.ContactNameAra AS PayNameAra
FROM         dbo.GeneralJournalItem 
		     Left Join dbo.Account ON dbo.GeneralJournalItem.AccountIdNo = dbo.Account.IdNo 
			 Left Join dbo.Contact_View AS ContactData ON dbo.GeneralJournalItem.PayIdNo = ContactData.IdNo
				 AND (dbo.Account.PayeeType IS NULL OR dbo.Account.PayeeType = ContactData.CSECode)
			 Left Join dbo.ApOpenInvoice_View ON dbo.GeneralJournalItem.JournalIdNo = dbo.ApOpenInvoice_View.JournalItemIdNo AND dbo.ApOpenInvoice_View.JournalCode = 'GJ'

GO



GO




