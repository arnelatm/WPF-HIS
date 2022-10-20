
CREATE VIEW InsuranceProcessedData_View
 
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
	a.InsCardNo,
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
	case when d.altserviceid is null then a.ServiceID else d.altserviceid end as ServiceID,
	case when d.altserviceid is null then a.ServiceDescription else d.AltServiceNameEnglish end as ServiceDescription,
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
	a.UserID,
	a.Create_Date,
	a.MachineID,
	b.InsSoapNo,
	b.InsSoapCode,
	c.NameEnglish as CoInsuranceNameEnglish,
	e.ProviderCode
From InsuranceAlteredData a
left outer join PatientDetails b on a.RegistrationNo = b.RegistrationNo AND b.Series = 'CR' AND (upper(b.patientType) = 'INSURANCE' OR upper(b.PatientType) = 'CREDIT') 
left outer join InsuranceDetails c on a.UnderInsCoCode = c.InsuranceID 
left outer join InsuranceAltServicePriceList d on a.serviceid = d.serviceid and a.insuranceid = d.insuranceid
left outer join InsuranceDetails e on a.InsuranceID = e.InsuranceID