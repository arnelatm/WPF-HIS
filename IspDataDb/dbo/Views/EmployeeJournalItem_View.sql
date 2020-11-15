



CREATE VIEW [dbo].[EmployeeJournalItem_View]
AS
SELECT        dbo.EmployeeLoanJournalItem.IdNo, dbo.EmployeeLoanJournalItem.Sequence, dbo.EmployeeLoanJournalItem.JournalIdNo, dbo.EmployeeLoanJournalItem.AccountIdNo, dbo.EmployeeLoanJournalItem.TransactionDate, dbo.EmployeeLoanJournalItem.Debit, 
                         dbo.EmployeeLoanJournalItem.Credit, dbo.EmployeeLoanJournalItem.RevCostCenterIdNo, dbo.EmployeeLoanJournalItem.Notes, dbo.EmployeeLoanJournalItem.Posted, dbo.EmployeeLoanJournalItem.DateTimeStamp, dbo.Account.AccountName
FROM            dbo.EmployeeLoanJournal INNER JOIN
                         dbo.EmployeeLoanJournalItem ON dbo.EmployeeLoanJournal.IDNo = dbo.EmployeeLoanJournalItem.JournalIdNo INNER JOIN
                         dbo.Account ON dbo.EmployeeLoanJournalItem.AccountIdNo = dbo.Account.IDNo 
