CREATE VIEW RevenueReportPrint1_View 
  
AS 
SELECT 
	DoctorID,
	EmpNameEnglish,
	EmpNameArabic,
	TransDateEnglish,
	RegistrationNo,
	case when sum(CashNew)<>0 and sum(CashFollowUp)=0 and sum(CreditNew)=0 and sum(CreditOld)=0 and sum(CreditFollowUp)=0 then 1 else 0 end as CashNew,
	case when sum(CashOld)<>0 and sum(CashFollowUp)=0 and sum(CreditNew)=0 and sum(CreditOld)=0 and sum(CreditFollowUp)=0 then 1 else 0 end as CashOld,
	case when sum(CashFollowUp)<> 0 then 1 else 0 end as CashFollowUp,
	case when sum(CreditNew)<>0 and sum(CreditFollowUp)=0 then 1 else 0 end as CreditNew,
	case when sum(CreditOld)<>0 and sum(CreditFollowUp)=0 then 1 else 0 end as CreditOld,
	case when sum(CreditFollowUp)<>0 then 1 else 0 end as CreditFollowUp,
	sum(BillAmtCash) as BillAmtCash,
	sum(DeductibleAmt) as DeductibleAmt,
	sum(DeductibleRoundOffAmt) as DeductibleRoundOffAmt,
	sum(BillAmtCredit+DeductibleAmt+DeductibleRoundOffAmt) as BillAmtCredit
from RevenueReportPrint_View 
Group By
	DoctorID,
	EmpNameEnglish,
	EmpNameArabic,
	TransDateEnglish,
	RegistrationNo
