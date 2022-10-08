USE [iGroupClinic]
GO

/****** Object:  View [dbo].[PMRDoctorsGenForm_View]    Script Date: 08/10/2022 8:59:35 am ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER view 	[dbo].[PMRDoctorsGenForm_View]
 
as 
SELECT a.DoctorId,
	a.TransDateEnglish as PmrDate, 
	a.RegistrationNo as FileNo, 
	case when a.transdateenglish = b.RegistrationDate then 'New' else 'Old' end as [FileType],
	a.PatientType as PType,
	b.PatientNameEnglish as PatientName,
	Cast(a.TokenNo as Int) as Token, 
	IIf(Cast(a.TokenNo as Int)=0,0,1) as Status,
	b.LastConsDate,
	f.Trans_Key,
	(SELECT MIN( g.Create_Date)
              FROM ClinicInvoiceGroup g
              WHERE a.RegistrationNo = g.RegistrationNo and a.DoctorId = g.DoctorId and a.RegistrationNo = g.RegistrationNo and a.PatientType = g.RegistrationType and a.TransDateEnglish = g.TransDateEnglish) as InvTime
FROM PMRPatientGeneralInfo a 
left outer join PatientDetails b on a.Series = b.Series AND a.RegistrationNo = b.RegistrationNo
left outer join EmployeeDetails e on a.DoctorID = e.EmpID
left outer join PMRTokenDetails f on f.PMRDateEnglish = a.TransDateEnglish AND a.DoctorID = f.DoctorID AND a.TokenNo = f.TokenNo 
GO
