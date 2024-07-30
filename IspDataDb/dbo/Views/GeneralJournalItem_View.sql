
CREATE VIEW [dbo].[GeneralJournalItem_View]
AS
SELECT        dbo.GeneralJournalItem.IdNo, dbo.GeneralJournalItem.Sequence, dbo.GeneralJournalItem.JournalIdNo, dbo.GeneralJournalItem.AccountIdNo, dbo.GeneralJournalItem.Debit, dbo.GeneralJournalItem.Credit, dbo.GeneralJournalItem.ContactIdNo,
                         dbo.GeneralJournalItem.RevCostCenterIdNo, dbo.GeneralJournalItem.Notes, dbo.Account.AccountName, dbo.GeneralJournalItem.Debit - dbo.GeneralJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, 
                         dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken,
						 dbo.Contact_View.ContactCode as PayCode,
						 dbo.Contact_View.ContactName as PayName,
						 dbo.Contact_View.ContactNameAra as PayNameAra
FROM         dbo.GeneralJournalItem 
		     Left Join dbo.Account ON dbo.GeneralJournalItem.AccountIdNo = dbo.Account.IdNo 
			 Left Join dbo.Contact_View on dbo.GeneralJournalItem.ContactIdNo = dbo.Contact_View.IdNo
			 Left Join dbo.ApOpenInvoice ON dbo.GeneralJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo AND dbo.ApOpenInvoice.JournalCode = 'GJ'

GO



GO




