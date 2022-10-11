
CREATE VIEW AccountsGroup_View
 
AS
select 	a.GroupID,
	a.GroupNameEnglish,
	a.GroupNameArabic,
	a.ParentID,
	b.GroupNameEnglish as ParentNameEnglish,
	b.GroupNameArabic as ParentNameArabic,
	Case when a.GroupStatus = 1 then 'Active'
		else 'Deactive' end as GroupStatus,
	a.OpeningBalance,
	a.ClosingBalance
From AccountsGroup a
Left outer join AccountsGroup b on b.GroupID = a.parentID