CREATE VIEW InsuranceCarsEclaim_View
 
AS

SELECT  
	a.Trans_Key,
	a.TrType,
	a.BranchID,
	a.InsuranceID as InsuranceGroupID,
	a.InsCoCode as InsuranceID,
	a.NameEnglish,
	a.UnderInsCoCode as UnderInsuranceID,
	a.Policy,
	a.SeqNo,
	a.RegistrationNo,
	a.PatientNameEnglish,
	a.TransNBR,
	a.TransDateEnglish,
	a.ApprovalNo,
	a.ICD10,
	a.Diagnosis1,
	a.Diagnosis2,
	a.Diagnosis3,
	a.ClinicalData,
	a.ClaimType,
	a.ServiceID as ServiceID,
	a.ServiceDescription as ServiceDescription,
	a.ServiceDate,
	a.DoctorID,
	a.DoctorNameEnglish,
	a.Qty,
	a.Amount,
	a.Gross,
	a.Discount,
	a.ADiscount,
	a.Deductible,
	a.Net,
--	case when a.CountryIOTA = 'SAU' or a.trtype='Pharmacy' then 0 else a.VATOnCompanyShare end as VATOnCompanyShare,
	a.UserID,
	a.Create_Date,
	a.MachineID,
	g.SoapNo,
	g.SoapCode,
	b.inscardno,
	c.NameEnglish as CoInsuranceNameEnglish,
	h.NameEnglish as GroupInsuranceName
From InsuranceAlteredData a
left outer join PatientDetails b on a.RegistrationNo = b.RegistrationNo AND b.Series = 'CR' AND (upper(b.patientType) = 'INSURANCE' OR upper(b.PatientType) = 'CREDIT') 
left outer join InsuranceDetails c on a.UnderInsCoCode = c.InsuranceID
left outer join InsuranceDetails g on a.InsCoCode = c.InsuranceID
left outer join InsuranceDetails h on a.InsuranceID = h.InsuranceID