






CREATE VIEW [dbo].[GLDeptBalanceSheet_View]
AS
Select idno,sum(Debit-Credit) as 'Balance',TransactionDate,ClosingJournal,Posted,SpecialAccount,RevCostCenterIdNo
from GeneralLedger_View as Gl
group by idno,TransactionDate,ClosingJournal,Posted,SpecialAccount,RevCostCenterIdNo