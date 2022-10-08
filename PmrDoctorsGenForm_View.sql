USE [iGroupClinic]
GO

/****** Object:  View [dbo].[PMRDoctorsGenForm_View]    Script Date: 08/10/2022 12:11:39 pm ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER view 	[dbo].[PMRDoctorsGenForm_View]
 
as 
SELECT a.DoctorId,
	a.PMRDateEnglish as PmrDate, 
	a.RegistrationNo as FileNo, 
	case when a.PMRDateEnglish = b.RegistrationDate then 'New' else 'Old' end as [FileType],
	f.PatientType as PType,
	b.PatientNameEnglish as PatientName,
	Cast(a.TokenNo as Int) as Token, 
	IIf(Cast(a.TokenNo as Int)=0,0,1) as Status,
	b.LastConsDate,
	a.Trans_Key,
	(SELECT top 1 MIN( g.Create_Date)
              FROM ClinicInvoiceGroup g
              WHERE a.RegistrationNo = g.RegistrationNo and a.DoctorId = g.DoctorId and a.RegistrationNo = g.RegistrationNo and f.PatientType = g.RegistrationType and a.PMRDateEnglish = g.TransDateEnglish) as InvTime,
	(SELECT top 1 Max( g.TokenNo)
              FROM ClinicInvoiceGroup g
              WHERE a.RegistrationNo = g.RegistrationNo and a.DoctorId = g.DoctorId and a.RegistrationNo = g.RegistrationNo and f.PatientType = g.RegistrationType and a.PMRDateEnglish = g.TransDateEnglish) as TokenNo
FROM PMRTokenDetails a
left outer join PatientDetails b on a.Series = b.Series AND a.RegistrationNo = b.RegistrationNo
left outer join EmployeeDetails e on a.DoctorID = e.EmpID
left outer join [PMRPatientGeneralInfo_View] f on f.TransDateEnglish = a.PMRDateEnglish AND f.DoctorID = a.DoctorID AND f.TokenNo = a.TokenNo 
GO


