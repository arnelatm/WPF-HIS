

CREATE VIEW [dbo].[CashDisbursementJournalTransaction_View]
AS
SELECT        dbo.CashDisbursementJournal.IdNo, dbo.CashDisbursementJournal.TransactionDate, dbo.CashDisbursementJournal.ReferenceNo, dbo.CashDisbursementJournal.Amount, dbo.CashDisbursementJournal.PayeeIdNo, dbo.CashDisbursementJournal.PaymentType, 
                         dbo.CashDisbursementJournal.PayeeName, dbo.CashDisbursementJournalItem.Sequence, dbo.CashDisbursementJournalItem.Debit, dbo.CashDisbursementJournalItem.Credit, dbo.CashDisbursementJournalItem.RevCostCenterIdNo, 
                         dbo.CashDisbursementJournalItem.Notes, dbo.Chart.AccountCode, dbo.Chart.AccountName, dbo.Chart.AccountNameAra, dbo.Customer.CustomerCode, dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, 
                         dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra, dbo.Employee.EmployeeCode, dbo.Employee.EmployeeName, dbo.Employee.EmployeeNameAra, 
                         dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.CashDisbursementJournal.Notes AS PcNote
FROM            dbo.Chart RIGHT OUTER JOIN
                         dbo.CashDisbursementJournalItem ON dbo.Chart.IdNo = dbo.CashDisbursementJournalItem.AccountIdNo LEFT OUTER JOIN
                         dbo.RevCostCenter ON dbo.CashDisbursementJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IdNo RIGHT OUTER JOIN
                         dbo.CashDisbursementJournal ON dbo.CashDisbursementJournalItem.JournalIdNo = dbo.CashDisbursementJournal.IdNo LEFT OUTER JOIN
                         dbo.Customer ON dbo.CashDisbursementJournal.PayeeIdNo = dbo.Customer.IdNo LEFT OUTER JOIN
                         dbo.Supplier ON dbo.CashDisbursementJournal.PayeeIdNo = dbo.Supplier.IdNo LEFT OUTER JOIN
                         dbo.Employee ON dbo.CashDisbursementJournal.PayeeIdNo = dbo.Employee.IdNo