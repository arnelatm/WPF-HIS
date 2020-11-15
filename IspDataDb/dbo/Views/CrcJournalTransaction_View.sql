


CREATE VIEW [dbo].[CrcJournalTransaction_View]
AS
SELECT        dbo.CashReceiptJournal.TransactionDate, dbo.CashReceiptJournal.ReferenceNo, dbo.CashReceiptJournal.Amount, dbo.CashReceiptJournal.PayorName, 
                         dbo.CashReceiptJournal.CheckNumber, dbo.CashReceiptJournal.CheckDate, dbo.CashReceiptJournal.Notes, dbo.CashReceiptJournal.PayorType, 
                         dbo.CashReceiptJournalItem.Sequence, dbo.CashReceiptJournalItem.Debit, dbo.CashReceiptJournalItem.Credit, dbo.CashReceiptJournalItem.Notes AS CrNotes, dbo.CashReceiptJournal.ORNumber,
                         dbo.BankAccount.BranchName, dbo.Bank.BankName, dbo.Bank.BankNameAra, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Employee.EmployeeCode, dbo.Supplier.SupplierNameAra, 
                         dbo.Employee.EmployeeNameAra, dbo.Employee.EmployeeName, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.CashReceiptJournal.IdNo, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra
FROM            dbo.CashReceiptJournal 
				LEFT OUTER JOIN dbo.CashReceiptJournalItem 
					ON dbo.CashReceiptJournal.IdNo = dbo.CashReceiptJournalItem.JournalIdNo 
				Left Outer Join dbo.Supplier 
					ON dbo.CashReceiptJournal.PayorIdNo = dbo.Supplier.IdNo
				Left Outer Join dbo.Customer
				    ON dbo.CashReceiptJournal.PayorIdNo = dbo.Customer.IdNo 
				Left Outer Join dbo.Employee 
					ON dbo.CashReceiptJournal.PayorIdNo = dbo.Employee.IdNo 
				Left Outer Join dbo.BankAccount 
					ON dbo.CashReceiptJournal.AccountIdNo = dbo.BankAccount.AccountIdNo 
				LEFT OUTER JOIN dbo.Account 
					ON dbo.CashReceiptJournalItem.AccountIdNo = dbo.Account.IdNo 
				LEFT OUTER JOIN dbo.Bank 
					ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo 
				Left Outer Join dbo.RevCostCenter
					On dbo.CashReceiptJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IdNo