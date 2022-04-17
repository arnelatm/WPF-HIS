
CREATE VIEW [dbo].[GeneralJournalItem_View]
AS
SELECT        dbo.GeneralJournalItem.IdNo, dbo.GeneralJournalItem.Sequence, dbo.GeneralJournalItem.JournalIdNo, dbo.GeneralJournalItem.AccountIdNo, dbo.GeneralJournalItem.Debit, dbo.GeneralJournalItem.Credit, 
                         dbo.GeneralJournalItem.RevCostCenterIdNo, dbo.GeneralJournalItem.Notes, dbo.Account.AccountName, dbo.GeneralJournalItem.Debit - dbo.GeneralJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, 
                         dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken, dbo.GeneralJournalItem.PayIdNo,
						 IIf(dbo.Account.SpecialAccount='AR',dbo.Customer.CustomerCode,IIf(dbo.Account.SpecialAccount='AP',dbo.Supplier.SupplierCode, iiF(dbo.Account.SpecialAccount='EL',dbo.Employee.EmployeeCode,''))) as PayCode,
						 IIf(dbo.Account.SpecialAccount='AR',dbo.Customer.CustomerName,IIf(dbo.Account.SpecialAccount='AP',dbo.Supplier.SupplierName, iiF(dbo.Account.SpecialAccount='EL',dbo.Employee.EmployeeName,''))) as PayName,
						 IIf(dbo.Account.SpecialAccount='AR',dbo.Customer.CustomerNameAra,IIf(dbo.Account.SpecialAccount='AP',dbo.Supplier.SupplierNameAra, iiF(dbo.Account.SpecialAccount='EL',dbo.Employee.EmployeeNameAra,''))) as PayNameAra
FROM         dbo.GeneralJournalItem 
		     Left Join dbo.Account ON dbo.GeneralJournalItem.AccountIdNo = dbo.Account.IdNo 
			 Left Join dbo.Customer ON dbo.GeneralJournalItem.PayIdNo = dbo.Customer.IdNo 
			 Left Join dbo.Supplier ON dbo.GeneralJournalItem.PayIdNo = dbo.Supplier.IdNo 
			 Left Join dbo.Employee ON dbo.GeneralJournalItem.PayIdNo = dbo.Employee.IdNo 
			 Left Join dbo.ApOpenInvoice ON dbo.GeneralJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo AND dbo.ApOpenInvoice.JournalCode = 'GJ'

GO



GO




