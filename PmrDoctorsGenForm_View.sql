USE [iGroupClinic]
GO

/****** Object:  View [dbo].[PMRDoctorsGenForm_View]    Script Date: 09/10/2022 1:17:35 am ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








ALTER view 	[dbo].[PMRDoctorsGenForm_View]
 
as 
SELECT a.DoctorId,
	a.TransDateEnglish as PmrDate, 
	a.RegistrationNo as FileNo, 
	max(a.TokenNo) as TokenNo,
	a.TransType as PType,
	b.PatientNameEnglish as PatientName,
	case when a.TransDateEnglish = b.RegistrationDate then 'New' else 'Old' end as [FileType],
	g.Trans_Key,
	b.LastConsDate,
	Min(a.Create_Date) as InvTime,
	IIf(Cast(Max(a.TokenNo) as Int)=0,0,1) as Status
FROM clinicInvoiceGroup  a
left outer join PatientDetails b on a.RegistrationType = b.PatientType AND a.RegistrationNo = b.RegistrationNo
left outer join [PMRPatientGeneralInfo_View] f on f.TransDateEnglish = a.TransDateEnglish AND f.DoctorID = a.DoctorID AND f.TokenNo = a.TokenNo 
LEFT OUTER JOIN PMRTokenDetails G ON f.trans_key = g.Trans_Key and a.RegistrationNo = g.RegistrationNo and f.Trans_key is not null
group by a.DoctorId,a.TransDateEnglish,a.RegistrationNo,a.TransType,b.RegistrationDate,b.PatientNameEnglish,b.LastConsDate,b.LastConsDate,g.Trans_Key


GO


