



Create VIEW [dbo].[BalanceSheet_View]
AS
Select idno,sum(Debit-Credit) as 'Balance',TransactionDate
from GeneralLedger_View as Gl
group by idno,TransactionDate
