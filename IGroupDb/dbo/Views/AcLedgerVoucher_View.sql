
CREATE VIEW AcLedgerVoucher_View
 
AS
select 
	Trans_Key,
	BranchID,
	FinYear,
	TransNo,
	VDate,
	VType,
	RefType,
	CostCentreID,
	SlNo,
	DrCr,
	LedgerID,
	LedgerNameEnglish,
	LedgerNameArabic,
	ParentID,
	GroupNameEnglish,
	GroupNameArabic, 
	DrAmt,
	CrAmt,
	EntryDescription,
	VDescription,
	CCNameEnglish,
	Status
from AccountsVoucher_View
union all
select 
	1 as Trans_Key,
	a.BranchID,
	a.FinYear,
	a.TransNbr as TransNo,
	a.TransDate as VDate,
	'OPB' as VType,
	'OPB' as RefType,
	'' as CostCentreID,
	1 as SlNo,
	a.CreditDebit as DrCr,
	a.LedgerID,
	b.LedgerNameEnglish,
	b.LedgerNameArabic, 
	c.ParentID,
	c.GroupNameEnglish,
	c.groupnamearabic,
	case when a.CreditDebit = 'D' then a.Amount else 0 end DrAmt ,
	case when a.CreditDebit = 'C' then a.Amount else 0 end CrAmt ,
	'Opening Balance' as EntryDescription,
	'Opening Balance as on ' + a.transDate as VDescription,
	'' as CCNameEnglish,
	1 as Status
From AccountsOpeningBalance a
left outer join AccountsLedger b on a.LedgerID = b.LedgerID 
left outer join AccountsGroup c on b.primarygroupid = c.groupid