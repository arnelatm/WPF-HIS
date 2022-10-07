USE [iGroupClinic]
GO

/****** Object:  View [dbo].[PMRDoctorsGenForm_View]    Script Date: 08/10/2022 1:31:27 am ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









CREATE view 	[dbo].[PMRDoctorsGenForm_View]
 
as 
SELECT a.DoctorId,
	a.TransDateEnglish as PmrDate, 
	a.[File No] as FileNo, 
	case when a.transdateenglish = b.RegistrationDate then 'New' else 'Old' end as [FileType],
	a.[Inv Type] as PType,
	b.PatientNameEnglish as PatientName,
	Cast(a.TokenNo as Int) as Token, 
	IIf(Cast(a.TokenNo as Int)=0,0,1) as Status,
	b.LastConsDate,
	a.Trans_Key,
	a.TransType,
	(SELECT MIN( g.Create_Date)
              FROM ClinicInvoiceGroup g
              WHERE a.[File No]= g.RegistrationNo and a.DoctorId = g.DoctorId and a.[File No] = g.RegistrationNo and a.TransType = g.RegistrationType and a.TransDateEnglish = g.TransDateEnglish) as InvTime

FROM [PMRPatientDisplay_View] a 
left outer join PatientDetails b on a.TransType = b.Series AND a.[File No] = b.RegistrationNo
left outer join EmployeeDetails e on a.DoctorID = e.EmpID
GO


