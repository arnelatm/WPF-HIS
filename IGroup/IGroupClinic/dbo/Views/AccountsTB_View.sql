
CREATE VIEW AccountsTB_View 
 
AS
select 	BranchID,
	vDate,
       	LedgerID,
       	LedgerNameEnglish,
		LedgerNameArabic, 
       	ParentID,
       	GroupNameEnglish,
		groupnamearabic,
       	sum(dramt) as dramt,
       	sum(cramt) as cramt
from 
	AccountsVoucher_View
    Where Status = 1
group by
	BranchID,
	vDate,
    	LedgerID,
    	LedgerNameEnglish,
		LedgerNameArabic, 
    	ParentID,
    	GroupNameEnglish,
		GroupNameArabic