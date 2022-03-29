CREATE VIEW RevenueReportPrint_View
 
AS
SELECT 
	DoctorID,
	EmpNameEnglish,
	EmpNameArabic,
	TransNbr,
	TransDateEnglish,
	TransType,
	RegistrationNo,
	avg(CashNew) as CashNew,
	avg(CashOld) as CashOld,
	avg(CashFollowUp) as CashFollowUp,
	avg(CreditNew) as CreditNew,
	avg(CreditOld) as CreditOld,
	avg(CreditFollowUp) as CreditFollowUp,
	Case when TransType = 'CA'  then avg(BillAmt) else 0 end as BillAmtCash,
	Case when TransType = 'CA'  then avg(DeductibleAmt) else 0 end as DeductibleAmt,
	Case when TransType = 'CA'  then avg(DeductibleRoundOffAmt) else 0 end as DeductibleRoundOffAmt,
	Case when TransType <> 'CA' then avg(BillAmt) else 0 end as BillAmtCredit
from RevenueReport_View 
Group By
	DoctorID,
	EmpNameEnglish,
	EmpNameArabic,
	TransNbr,
	TransDateEnglish,
	TransType,
	RegistrationNo
