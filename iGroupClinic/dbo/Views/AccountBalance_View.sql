


CREATE VIEW [dbo].[AccountBalance_View]
AS
Select c.idno,c.parentidNo,c.AccountGroup,c.AccountName,c.LevelNumber,sum(gl.Debit-gl.Credit) as 'Balance' ,c.sortKey,gl.TransactionDate
from GeneralLedger_View as Gl
Left join Account_View as c 
on gl.idNo = c.idNo
group by c.sortkey,c.LevelNumber,c.parentidNo,c.idno,c.AccountGroup,c.AccountName,gl.TransactionDate
