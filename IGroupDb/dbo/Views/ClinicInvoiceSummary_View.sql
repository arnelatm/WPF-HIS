CREATE VIEW 	ClinicInvoiceSummary_View
 
AS
select 
	BranchID,
	RegistrationType,
	registrationNo,
	TransType,
	TransNBR,
	TransDateEnglish,
	DoctorID,
	InsuranceID,
	InsuranceGroupID,
	InsuranceNameEnglish,
	NormalDiscountAmt,
	case when deductibleamt is null then 0 else DeductibleAmt end as DeductibleAmt,
	case when DeductibleDiscountamt is null then 0 else DeductibleDiscountAmt end as DeductibleDiscountAmt,
	ExtraDiscountAmt,
	RoundOffAmt,
	BillAmt,
	Reject,
	UserID,
	sum(Qty*SalePrice) as GrossAmt,
	case when avg(DiscountPer) > 0 then 
			  sum(Qty*SalePrice*DiscountPer/100) 
		 else
			  sum(DiscountAmt) end as DiscountAmt,
	case when PatientNameEnglish is null then '' else PatientNameEnglish end as PatientNameEnglish,
	CountryIOTA,
	CountryNameEng,
	EmpNameEnglish,
	DepartmentID,
	DepartmentNameEnglish    
from ClinicInvoice_View 
where Reject <> 1
Group By
	BranchID,
	RegistrationType,
	registrationNo,
	TransType,
	TransNBR,
	TransDateEnglish,
	DoctorID,
	InsuranceID,
	InsuranceGroupID,
	InsuranceNameEnglish,
	NormalDiscountAmt,
	DeductibleAmt,
	DeductibleDiscountAmt,
	ExtraDiscountAmt,
	RoundOffAmt,
	BillAmt,
	Reject,
	UserID,
	PatientNameEnglish,
	CountryIOTA,
	CountryNameEng,
	EmpNameEnglish,
	DepartmentID,
	DepartmentNameEnglish