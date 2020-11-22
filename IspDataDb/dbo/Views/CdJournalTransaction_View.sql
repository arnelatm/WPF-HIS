
cREATE VIEW [dbo].[CdJournalTransaction_View]
AS
SELECT        dbo.CdJournal.IdNo, dbo.CdJournal.TransactionDate, dbo.CdJournal.ReferenceNo, dbo.CdJournal.Amount, dbo.CdJournal.PayeeIdNo, 
                         dbo.CdJournal.PaymentType, dbo.CdJournal.PayeeName, dbo.CdJournalItem.Sequence, dbo.CdJournalItem.Debit, dbo.CdJournalItem.Credit, 
                         dbo.CdJournalItem.RevCostCenterIdNo, dbo.CdJournalItem.Notes, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra, dbo.Employee.EmployeeCode, dbo.Employee.EmployeeName, 
                         dbo.Employee.EmployeeNameAra, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.CdJournal.Notes AS CdNote, dbo.BankAccount.BranchName, dbo.Bank.BankCode, 
                         dbo.Bank.BankName, dbo.Bank.BankNameAra
FROM            dbo.BankAccount LEFT OUTER JOIN
                         dbo.Bank ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo RIGHT OUTER JOIN
                         dbo.CdJournal ON dbo.BankAccount.AccountIdNo = dbo.CdJournal.AccountIdNo LEFT OUTER JOIN
                         dbo.Account RIGHT OUTER JOIN
                         dbo.CdJournalItem ON dbo.Account.IdNo = dbo.CdJournalItem.AccountIdNo LEFT OUTER JOIN
                         dbo.RevCostCenter ON dbo.CdJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IDNo ON dbo.CdJournal.IdNo = dbo.CdJournalItem.JournalIdNo LEFT OUTER JOIN
                         dbo.Customer ON dbo.CdJournal.PayeeIdNo = dbo.Customer.IdNo LEFT OUTER JOIN
                         dbo.Supplier ON dbo.CdJournal.PayeeIdNo = dbo.Supplier.IdNo LEFT OUTER JOIN
                         dbo.Employee ON dbo.CdJournal.PayeeIdNo = dbo.Employee.IdNo