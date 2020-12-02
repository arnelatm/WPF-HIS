

cREATE VIEW [dbo].[PcJournalTransaction_View]
AS
SELECT        dbo.PcJournal.IdNo, dbo.PcJournal.TransactionDate, dbo.PcJournal.ReferenceNo, dbo.PcJournal.Amount, dbo.PcJournal.PayeeIdNo, 
                         dbo.PcJournal.PaymentType, dbo.PcJournal.PayeeName, dbo.PcJournalItem.Sequence, dbo.PcJournalItem.Debit, dbo.PcJournalItem.Credit, 
                         dbo.PcJournalItem.RevCostCenterIdNo, dbo.PcJournalItem.Notes, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra, dbo.Employee.EmployeeCode, dbo.Employee.EmployeeName, 
                         dbo.Employee.EmployeeNameAra, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.PcJournal.Notes AS PcNote, dbo.BankAccount.BranchName, dbo.Bank.BankCode, 
                         dbo.Bank.BankName, dbo.Bank.BankNameAra
FROM            dbo.BankAccount LEFT OUTER JOIN
                         dbo.Bank ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo RIGHT OUTER JOIN
                         dbo.PcJournal ON dbo.BankAccount.AccountIdNo = dbo.PcJournal.AccountIdNo LEFT OUTER JOIN
                         dbo.Account RIGHT OUTER JOIN
                         dbo.PcJournalItem ON dbo.Account.IdNo = dbo.PcJournalItem.AccountIdNo LEFT OUTER JOIN
                         dbo.RevCostCenter ON dbo.PcJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IDNo ON dbo.PcJournal.IdNo = dbo.PcJournalItem.JournalIdNo LEFT OUTER JOIN
                         dbo.Customer ON dbo.PcJournal.PayeeIdNo = dbo.Customer.IdNo LEFT OUTER JOIN
                         dbo.Supplier ON dbo.PcJournal.PayeeIdNo = dbo.Supplier.IdNo LEFT OUTER JOIN
                         dbo.Employee ON dbo.PcJournal.PayeeIdNo = dbo.Employee.IdNo