


CREATE VIEW [dbo].[GeneralLedgerDept_View]
AS
SELECT dbo.Account_View.IdNo, dbo.Account_View.AccountCode, dbo.Account_View.AccountName, dbo.Account_View.AccountNameAra, dbo.GlLedgers_View.Debit, dbo.GlLedgers_View.Credit, dbo.GlLedgers_View.TransactionDate, 
       dbo.GlLedgers_View.Posted, dbo.GlLedgers_View.JournalCode, dbo.GlLedgers_View.IdNo AS JournalItemIdNo, dbo.GlLedgers_View.JournalIdNo, dbo.Account_View.SortKey, 
       dbo.GlLedgers_View.ClosingJournal,dbo.Account_View.SpecialAccount,dbo.GlLedgers_View.RevCostCenterIdNo
FROM   dbo.Account_View 
	   LEFT OUTER JOIN dbo.GlLedgers_View 
	   ON dbo.Account_View.IdNo = dbo.GlLedgers_View.AccountIdNo