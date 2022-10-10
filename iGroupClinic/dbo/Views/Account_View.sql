





CREATE View [dbo].[Account_View] as 
with cte as
(
select
    IdNo,
    ParentIdNo,
	AccountCode,
	AccountName,   
	AccountNameAra,
	Notes,
	DetailAccount,
	AccountGroup,
	BYDebit,
	BYCredit,
	Debit,
	Credit,
	NormalBalance,
	CloseDebit,
	CloseCredit,
	PayeeType,
	WithReconciliation,
	IncomeExpSummary,
	SpecialAccount,
	Active,
	GroupSortOrder,
	DateTimeStamp,
	CASE AccountGroup 
		WHEN 'A' THEN 1
		WHEN 'L' THEN 2
		WHEN 'E' THEN 3
		WHEN 'R' THEN 4
		WHEN 'C' THEN 5
		WHEN 'X' THEN 6
		ELSE 0
	END AS 'AccountGroupOrder',
    cast(row_number()over(partition by ParentIdNo order by ParentIdNo) as varchar(max)) as [path],
    0 as levelnumber,
    row_number() over (partition by ParentIdNo order by ParentIdNo) / power(1000.0,0) as SortKey
 
from Account
where ParentIdNo IS NULL
union all
select
    t.IdNo,
	t.ParentIdNo,
	t.AccountCode,
    t.AccountName,
	t.AccountNameAra,    
	t.Notes,
	t.DetailAccount,
	t.AccountGroup,
	t.BYDebit,
	t.BYCredit,
	t.Debit,
	t.Credit,
	t.NormalBalance,
	t.CloseDebit,
	t.CloseCredit,
	t.PayeeType,
	t.WithReconciliation,
	t.IncomeExpSummary,
	t.SpecialAccount,
	t.Active,
	t.GroupSortOrder,
	t.DateTimeStamp,
	AccountGroupOrder,
    [path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.GroupSortOrder) as varchar(max)),
    levelnumber+1,
    SortKey + row_number()over(partition by t.ParentIdNo order by t.GroupSortOrder) / power(1000.0,levelnumber+1)
 
from
    cte
join Account t on cte.IdNo = t.ParentIdNo
)
   
select
    IdNo,
	ParentIdNo,
	AccountCode,
    AccountName,
	AccountNameAra,
	Notes,
	DetailAccount,
	AccountGroup,
	BYDebit,
	BYCredit,
	Debit,
	Credit,
	NormalBalance,
	CloseDebit,
	CloseCredit,
	PayeeType,
	WithReconciliation,
	IncomeExpSummary,
	SpecialAccount,
	Active,
	LevelNumber,
	LevelNumber+1 AS PLevelNumber,
	DateTimeStamp,   
	AccountGroupOrder,
    [path],
    SortKey
from cte
