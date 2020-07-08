




CREATE VIEW [dbo].[GLBalanceSheet_View]
AS
Select idno,sum(Debit-Credit) as 'Balance',TransactionDate,ClosingJournal,Posted
from GeneralLedger_View as Gl
group by idno,TransactionDate,ClosingJournal,Posted