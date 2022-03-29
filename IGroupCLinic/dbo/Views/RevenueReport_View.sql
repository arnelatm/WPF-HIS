
CREATE VIEW RevenueReport_View
 
AS
SELECT 
	a.TransType,
	a.TransNBR,
	a.RegistrationNo,
	a.TransDateEnglish,
	a.DoctorID,
	c.EmpNameEnglish,
	c.EmpNameArabic,
	case when b.ServiceID <> 'CLN-DED' then a.BillAmt+a.RoundOffAmt else 0 end as BillAmt,
	case when b.ServiceID = 'CLN-DED' then a.BillAmt else 0 end as DeductibleAmt,
	case when b.ServiceID = 'CLN-DED' then a.RoundOffAmt else 0 end as DeductibleRoundOffAmt,
--	case when a.TransType = 'CA' then a.RoundOffAmt else 0 end as DeductibleRoundOffAmt,
	case when 
		a.TransType = 'CA' 
		AND b.ServiceID <> (select FollowUp From SystemSettings) and b.ServiceID = (Select ServiceID From ConsultationService where ServiceID = b.ServiceID) 
		AND a.TransDateEnglish = a.RegistrationDate then 1 else 0 end as CashNew,
	case when 
		a.TransType = 'CA' 
		AND b.ServiceID <> (select FollowUp From SystemSettings) and b.ServiceID = (Select ServiceID From ConsultationService where ServiceID = b.ServiceID)
		AND a.TransDateEnglish <> a.RegistrationDate then 1 else 0 end as CashOld,
	case when 
		a.TransType = 'CA' 
		AND b.ServiceID = (select FollowUp From SystemSettings) and b.ServiceID = (Select ServiceID From ConsultationService where ServiceID = b.ServiceID)
		then 1 else 0 end as CashFollowUp,
	case when 
		a.TransType <> 'CA' 
		AND b.ServiceID <> (select FollowUp From SystemSettings) and b.ServiceID = (Select ServiceID From ConsultationService where ServiceID = b.ServiceID)
		AND a.TransDateEnglish = a.RegistrationDate then 1 else 0 end as CreditNew,
	case when 
		a.TransType <> 'CA' 
		AND b.ServiceID <> (select FollowUp From SystemSettings) and b.ServiceID = (Select ServiceID From ConsultationService where ServiceID = b.ServiceID)
		AND a.TransDateEnglish <> a.RegistrationDate then 1 else 0 end as CreditOld,
	case when 
		a.TransType <> 'CA' 
		AND b.ServiceID = (select FollowUp From SystemSettings) 
		then 1 else 0 end as CreditFollowUp
from ClinicInvoiceGroup a
left outer join ClinicInvoiceDetails b on a.Trans_Key = b.Group_Key
left outer join employeedetails c on a.doctorid = c.empid
where a.Reject is null or a.Reject = 0
