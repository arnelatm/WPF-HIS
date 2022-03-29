
CREATE VIEW LabReport_View
 
AS
select 
	case when a.TransType = 'CA' then 'Cash' else 'Credit' end as TransType,
	a.TransNo,
	a.TransDate,
	a.SampleNo,
	a.ServiceID,
	a.InvestigationID,
	case when a.InvoiceType='CA' then 'Cash' else 'Credit' end as InvoiceType,
	a.InvoiceNo,
	a.InvoiceDate,
	a.RegistrationNo,
	a.PatientNameEnglish,
	str(a.age)+' '+ case when a.AgeYMD='Y' then 'Years' else case when a.AgeYMD = 'M' then 'Months' Else 'Days' end end as Age,
	case when a.Sex='M' then 'Male' else 'Female' end as Sex,
	a.DoctorID,
	b.EmpNameEnglish,
	c.InvestigationName,
	a.UserID,
	a.Status ,
	d.ServiceNameEnglish 
from lab_invoicegroup a
left outer join EmployeeDetails b on a.DoctorID = b.EmpID
left outer join lab_diagnosismasterdetails c on a.InvestigationID = c.InvestigationID
left outer join MedicalServices  d on a.ServiceID  = d.ServiceID 
