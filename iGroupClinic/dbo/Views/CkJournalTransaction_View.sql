


CREATE VIEW [dbo].[CkJournalTransaction_View]
AS
SELECT        dbo.CkJournal.TransactionDate, dbo.CkJournal.ReferenceNo, dbo.CkJournal.Amount, dbo.CkJournal.PayeeName, 
                         dbo.CkJournal.CheckNumber, dbo.CkJournal.CheckDate, dbo.CkJournal.Notes, dbo.CkJournal.PaymentType, 
                         dbo.CkJournalItem.Sequence, dbo.CkJournalItem.Debit, dbo.CkJournalItem.Credit, dbo.CkJournalItem.Notes AS CkNotes, 
                         dbo.BankAccount.BranchName, dbo.Bank.BankName, dbo.Bank.BankNameAra, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Employee.EmployeeCode, dbo.Supplier.SupplierNameAra, 
                         dbo.Employee.EmployeeNameAra, dbo.Employee.EmployeeName, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.CkJournal.IdNo, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra
FROM            dbo.CkJournal 
				LEFT OUTER JOIN dbo.CkJournalItem 
					ON dbo.CkJournal.IdNo = dbo.CkJournalItem.JournalIdNo 
				Left Outer Join dbo.Supplier 
					ON dbo.CkJournal.PayeeIdNo = dbo.Supplier.IdNo
				Left Outer Join dbo.Customer
				    ON dbo.CkJournal.PayeeIdNo = dbo.Customer.IdNo 
				Left Outer Join dbo.Employee 
					ON dbo.CkJournal.PayeeIdNo = dbo.Employee.IdNo 
				Left Outer Join dbo.BankAccount 
					ON dbo.CkJournal.AccountIdNo = dbo.BankAccount.AccountIdNo 
				LEFT OUTER JOIN dbo.Account 
					ON dbo.CkJournalItem.AccountIdNo = dbo.Account.IdNo 
				LEFT OUTER JOIN dbo.Bank 
					ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo 
				Left Outer Join dbo.RevCostCenter
					On dbo.CkJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IdNo
