




CREATE VIEW [dbo].[CdJournalTransaction_View]
AS
SELECT        dbo.CdJournal.TransactionDate, dbo.CdJournal.ReferenceNo, dbo.CdJournal.Amount, dbo.CdJournal.PayeeName, 
                         dbo.CdJournal.CheckNumber, dbo.CdJournal.CheckDate, dbo.CdJournal.Notes, dbo.CdJournal.PaymentType, 
                         dbo.CdJournalItem.Sequence, dbo.CdJournalItem.Debit, dbo.CdJournalItem.Credit, dbo.CdJournalItem.Notes AS CdNotes, 
                         dbo.BankAccount.BranchName, dbo.Bank.BankName, dbo.Bank.BankNameAra, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Employee.EmployeeCode, dbo.Supplier.SupplierNameAra, 
                         dbo.Employee.EmployeeNameAra, dbo.Employee.EmployeeName, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.CdJournal.IdNo, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra
FROM            dbo.CdJournal 
				LEFT OUTER JOIN dbo.CdJournalItem 
					ON dbo.CdJournal.IdNo = dbo.CdJournalItem.JournalIdNo 
				Left Outer Join dbo.Supplier 
					ON dbo.CdJournal.PayeeIdNo = dbo.Supplier.IdNo
				Left Outer Join dbo.Customer
				    ON dbo.CdJournal.PayeeIdNo = dbo.Customer.IdNo 
				Left Outer Join dbo.Employee 
					ON dbo.CdJournal.PayeeIdNo = dbo.Employee.IdNo 
				Left Outer Join dbo.BankAccount 
					ON dbo.CdJournal.AccountIdNo = dbo.BankAccount.AccountIdNo 
				LEFT OUTER JOIN dbo.Account 
					ON dbo.CdJournalItem.AccountIdNo = dbo.Account.IdNo 
				LEFT OUTER JOIN dbo.Bank 
					ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo 
				Left Outer Join dbo.RevCostCenter
					On dbo.CdJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IdNo