
CREATE VIEW AccountsVoucher_View
 
AS
select 
	b.Trans_Key,
	b.BranchID,
	b.FinYear,
	b.TransNo,
	b.VDate,
	b.VType,
	b.RefType,
	b.RefNo,
	a.CostCentreID,
	a.SlNo,
	a.DrCr,
	a.LedgerID,
	c.LedgerNameEnglish,
	c.LedgerNameArabic,
	c.ParentID,
	d.GroupNameEnglish,
	d.GroupNameArabic, 
	a.DrAmt,
	a.CrAmt,
	a.EntryDescription,
	b.VDescription,
	b.UserID,
	b.Create_date,
	b.MachineID,
	e.CCNameEnglish,
	b.Status,
	c.LedgerNature 
from AccountsVoucherDetails a
left outer join AccountsVoucherGroup b on a.Group_Key = b.Trans_Key And a.BranchID = b.BranchID
left outer join AccountsLedger c on a.LedgerID = c.LedgerID 
left outer join AccountsGroup d on c.primarygroupid = d.groupid
left outer join CostCentre e on a.CostCentreID = e.AccountID
union all
select 
	1 as Trans_Key,
	a.BranchID,
	a.FinYear,
	a.TransNBR as TransNo,
	a.TransDate as VDate,
	'OPB' as VType,
	'' as RefType,
	0 as RefNo,
	'' as CostCentreID,
	1 as SlNo,
	a.creditdebit as DrCr,
	a.LedgerID,
	c.LedgerNameEnglish,
	c.LedgerNameArabic, 
	c.ParentID,
	d.GroupNameEnglish,
	d.GroupNameArabic,
	case when a.CreditDebit = 'D' then Amount else 0 end as DrAmt,
	case when a.CreditDebit = 'C' then Amount else 0 end as CrAmt,
	'' as EntryDescription,
	'' as VDescription,
	a.UserID,
	a.Create_date,
	a.MachineID,
	'' as CCNameEnglish,
	1 as status,
	1 as LedgerNature
from AccountsOpeningBalance  a
left outer join AccountsLedger c on a.LedgerID = c.LedgerID 
left outer join AccountsGroup d on c.primarygroupid = d.groupid
