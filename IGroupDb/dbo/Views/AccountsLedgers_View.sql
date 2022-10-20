
CREATE VIEW AccountsLedgers_View
 
AS
select 	a.GroupID,
	a.GroupNameEnglish,
	a.ParentID,
	b.GroupNameEnglish as ParentNameEnglish,
	Case when a.GroupStatus = 1 then 'Active'
		else 'Deactive' end as GroupStatus,
	a.OpeningBalance,
	a.ClosingBalance,
	c.LedgerID, 
	c.LedgerNameEnglish,
	c.LedgerNameArabic  
From AccountsLedger c
left outer join AccountsGroup a on c.parentid = a.GroupID 
Left outer join AccountsGroup b on b.GroupID = a.parentID