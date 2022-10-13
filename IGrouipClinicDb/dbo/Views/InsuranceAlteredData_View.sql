CREATE VIEW InsuranceAlteredData_View
 
AS

select
	a.BranchID,
	a.TRans_Key,
	a.SeqNo as CS,
	a.InsCardNo,
	a.RegistrationNo,
	a.PatientNameEnglish,
	a.TransNBR,
	a.TransDAteEnglish,
	a.ApprovalNo,
	a.ICD10 as ICD10Code,
	a.Diagnosis1,
	a.Diagnosis2,
	a.Diagnosis3,
	a.ClinicalData,
	a.ClaimType,
	a.ServiceID,
	a.ServiceDescription as ServiceNameEnglish,
	a.TransDateEnglish as TreatmentDate,
	a.Qty,
	a.Amount,
	a.Gross as GrossAmount,
	a.Discount as DiscountAmt,
	a.ADiscount as AdditionalDiscountAmt,
	0 as DeductiblePer,
	a.Deductible as DeductibleAmt,
	a.DoctorID,
	a.DoctorNameEnglish as EmpNameEnglish,
	a.Policy,
	a.InsCoCode as InsuranceID,
	b.NameEnglish,
	a.InsuranceID as InsuranceGroupID,
	c.NameEnglish as GroupInsuranceName,
	a.UnderInsCoCode as UnderInsuranceID,
	d.NameEnglish as UnderInsuranceName,
	a.TrType
From InsuranceAlteredData a
left outer join InsuranceDetails b on a.InsCoCode = b.InsuranceID
left outer join InsuranceDetails c on a.InsuranceID = c.InsuranceID AND c.InsuranceType = 'TPA'
left outer join InsuranceDetails d on a.UnderInsCoCode = d.InsuranceID