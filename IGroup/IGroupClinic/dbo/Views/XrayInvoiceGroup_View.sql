



CREATE VIEW [dbo].[XrayInvoiceGroup_View]
 
AS
SELECT
	a.BranchID,
	a.Trans_Key,	
	a.TransType,
	a.TransNBR,
	a.TransDateEnglish,
	a.InvoiceType,
	a.InvoiceNBR,
	a.InvoiceDateEnglish,
	a.RegistrationType,
	a.RegistrationNo,
	a.RegistrationDate,
	a.DoctorID,
	a.PatientName,
	a.PatientNameArabic,
	a.CountryID,
	a.Age,
	a.YMD,
	a.DOB,
	a.PatientID,
	a.PhoneNo,
	a.InsuranceID,
	a.InsuranceNameEnglish,
	a.DeductionCategoryID,
	a.InsuranceGroupID,
	a.InvestigationID,
	a.InvestigationName,
	a.InvestigationDescription,
	a.Reject,
	a.RejectDate,
	b.EmpNameEnglish,
	case when f.sex = 'M' then 'Male' Else 'Female' end As Sex,
	c.NameEnglish as InsuranceGroupName,
	d.ItemNameEnglish as DeductionCategory,
	e.ServiceID,
	g.CountryNameEng
From 	XryInvoiceGroup a
LEFT OUTER JOIN EmployeeDetails b on a.DoctorID = b.EmpID
LEFT OUTER JOIN InsuranceDetails c on a.InsuranceID = c.InsuranceID AND c.InsuranceType = 'TPA'
LEFT OUTER JOIN DeductibleClassMaster d on a.DeductionCategoryID = d.ItemID 
LEFT OUTER JOIN XryInvestigationServices e on a.InvestigationID  = e.InvestigationID 
LEFT OUTER JOIN PatientDetails f on a.RegistrationType = f.PatientType and a.RegistrationNo = f.RegistrationNo 
LEFT OUTER JOIN CountryMaster g on a.CountryID = g.CountryIOTA