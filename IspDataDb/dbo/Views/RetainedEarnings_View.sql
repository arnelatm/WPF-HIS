






CREATE VIEW [dbo].[RetainedEarnings_View]	
  AS
(Select g.Debit-g.Credit as 'Balance',TransactionDate from  GeneralLedger_View g
left join Chart c
on g.IdNo = c.IdNo
where CHARINDEX(c.AccountGroup,'XCR') > 0 )