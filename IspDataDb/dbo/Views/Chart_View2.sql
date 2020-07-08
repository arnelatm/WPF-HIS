



CREATE View [dbo].[Chart_View2] as 
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
    cast(row_number() OVER (partition by ParentIdNo order by ParentIdNo) as varchar(max)) as [path],
    0 as levelnumber,
    row_number() over (partition by ParentIdNo order by ParentIdNo) / power(1000.0,0) as SortKey
 
from Chart
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
    [path] +'-'+ cast(row_number() OVER (partition by t.ParentIdNo order by t.GroupSortOrder) as varchar(max)),
    levelnumber+1,
    SortKey + row_number() OVER (partition by t.ParentIdNo order by t.GroupSortOrder) / power(1000.0,levelnumber+1)
 
from
    cte
join Chart t on cte.IdNo = t.ParentIdNo
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
	GroupSortOrder,
	DateTimeStamp,   
    [path],
    SortKey
from cte