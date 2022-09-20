
CREATE VIEW AccountsIncomeExpense_View
 
AS
SELECT
	a.BranchID,
	A.LedgerID,
	A.VDATE,
	case when a.ledgerid like '4%' then SUM(A.CRAMT) else 0 end AS IncomeAmt,
	case when a.ledgerid like '4%' then 0 else SUM(A.DRAMT) end AS ExpenseAmt,
	B.LedgerNameEnglish,
	b.LedgerNameArabic, 
	C.GroupID AS PARENT1,
	C.GroupNameEnglish AS GROUP1,
	c.GroupNameArabic as Group1Arabic,
	D.GroupID AS PARENT3,
	D.GroupNameEnglish ,
	d.groupnamearabic as GroupNameArabic,
	case when a.ledgerid like '4%' then 'I' else 'E' end as IncomeExpense 
FROM 
AccountsVoucher_View A
LEFT OUTER JOIN AccountsLedger B ON A.LedgerID = B.LedgerID 
LEFT OUTER JOIN AccountsGroup_View  C ON B.ParentID = C.GroupID 
LEFT OUTER JOIN AccountsGroup_View D ON C.ParentID = D.GroupID 
WHERE D.ParentID LIKE '4%' OR D.ParentID LIKE '5%'
GROUP BY
	a.BranchID,
	A.LedgerID,
	a.Vdate,
	B.LedgerNameEnglish,
	b.LedgerNameArabic, 
	C.GroupID,
	C.GroupNameEnglish,
	c.GroupNameArabic, 
	D.GroupID,
	D.GroupNameEnglish,
	d.GroupNameArabic