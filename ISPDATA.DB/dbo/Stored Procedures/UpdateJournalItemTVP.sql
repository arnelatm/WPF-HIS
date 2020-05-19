








CREATE PROCEDURE  [dbo].[UpdateJournalItemTVP]
  @MParam JournalItemUpdate READONLY
AS 
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo ,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = B.JournalIdNo ,
	a.Notes = B.Notes,
	a.ProfitCenterIdNo = B.ProfitCenterIdNo,
    a.[Sequence] = B.[Sequence]
from JournalItem a
JOIN @MParam b
on a.IDNo = b.IDNo

