











CREATE VIEW [dbo].[CurrentEarnings_View]	
  AS
(Select g.idno,Round(g.Debit-g.Credit,2) as 'Balance',ClosingJournal, TransactionDate from  GeneralLedger_View g
left join Chart c
on g.IdNo = c.IdNo
where CHARINDEX(c.AccountGroup,'XCR') > 0 )