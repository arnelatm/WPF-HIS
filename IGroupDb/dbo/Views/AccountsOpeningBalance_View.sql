
CREATE VIEW AccountsOpeningBalance_View
 
AS
select 
	a.BranchID,
	a.FinYear,
	a.TransNbr as TransNo,
	a.TransDate as VDate,
	a.CreditDebit as DrCr,
	a.LedgerID,
	b.LedgerNameEnglish,
	b.LedgerNameArabic, 
	c.ParentID,
	c.GroupNameEnglish,
	c.GroupNameArabic,
	case when a.CreditDebit = 'D' then a.Amount else 0 end DrAmt ,
	case when a.CreditDebit = 'C' then a.Amount else 0 end CrAmt 
From AccountsOpeningBalance a
left outer join AccountsLedger b on a.LedgerID = b.LedgerID 
left outer join AccountsGroup c on b.primarygroupid = c.groupid