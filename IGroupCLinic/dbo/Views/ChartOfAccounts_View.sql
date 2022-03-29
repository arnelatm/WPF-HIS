
CREATE VIEW ChartOfAccounts_View
 
AS
select 	a.Groupid,
	a.GroupNameEnglish as GroupName,
	a.GroupNameArabic as GroupNameArabic,
	b.groupid as ParentID,
	b.groupnameenglish as Parent,
	b.groupnamearabic as ParentArabic,
	case when a.groupid = a.parentid then 'Primary Group' else 'Sub Group' end as Grp_SGrp,
	case when a.groupid = a.parentid then 'مجموعة ليدجر الابتدائي' else 'الأولية المجموعة الفرعية ليدجر' end as Grp_SGrpArabic,
	b.ParentID as pID,
	a.OrderBy,
	a.OpeningBalance,
	a.CreditAmt,
	a.DebitAmt,
	b.PrimaryGroupID,
	case when a.subledger = 1 then 'Ledger' else 'Group' end as Ledger,
	case when a.subledger = 1 then 'دفتر الحسابات' else 'دفتر الأستاذ المجموعة' end as LedgerArabic,
	a.GroupStatus as Status,
	a.groupcategory
from accountsgroup a
left outer join accountsgroup b on a.parentid = b.groupid
--order by b.groupid,a.groupid desc 
union all
Select 	a.LedgerID as GroupID,
	a.LedgerNameEnglish as GroupName,
	a.LedgerNameArabic as GroupNameArabic,
	a.ParentID,
	b.groupNameEnglish as Parent,
	b.GroupNameArabic as ParentArabic,
	'Ledger' as grp_Sgrp,
	'دفتر الحسابات' as grp_sGrpArabic,
	b.GroupID as pID,
	b.OrderBy+1 as OrderBy,
	a.OpeningBalance,
	a.CreditAmt,
	a.DebitAmt,
	b.parentID as PrimaryGroupID,
	'Ledger' as Ledger,
	'دفتر الحسابات' as LedgerArabic,
	a.LedgerStatus as Status,
	b.groupcategory
from AccountsLedger a
left outer join AccountsGroup b on a.ParentID = b.GroupID
