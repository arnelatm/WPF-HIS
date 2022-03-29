CREATE VIEW LABInvestigation_ViewNew
AS 
Select 
	a.TransDateEnglish,
	Convert(varchar(10),a.Create_Date,108) as create_date, 
	Case When a.TransType='CA' then 'Cash' else 'Credit' end as TransType, 
	a.TransNBR, 
	a.TokenNo, 
	a.RegistrationType, 
	a.RegistrationNo, 
	a.PatientNameEnglish, 
	a.CountryNameEng, 
	CASE WHEN a.sex = 'M' then 'Male' else 'Female' end as Sex, 
	str(a.Age)+' '+a.AgeYMD as Age,'' as DOB, 
	a.GroupName, 
	a.InsuranceNameEnglish,
	a.EmpNameEnglish, 
	a.ServiceNameEnglish, 
	a.DepartmentID, 
	a.ServiceID, 
	b.InvestigationID, 
	case when not c.ServiceID is null then 1 else 0 end as ServiceFound, 
	d.status, 
	d.TransNo as ReportNo 
from ClinicInvoice1_View a
left outer Join Lab_DiagnosisItemServices c
on a.ServiceID = c.serviceid AND C.[DEFAULT]=1
left outer join Lab_DiagnosisMasterDetails b 
on c.InvestigationID = b.InvestigationID 
left outer join Lab_InvoiceGroup d 
on a.TransNBR = d.InvoiceNo and a.ServiceID in (Select ServiceID From 
Lab_DiagnosisItemServices Where InvestigationID = d.InvestigationID)






