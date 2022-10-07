USE [iGroupClinic]
GO

/****** Object:  View [dbo].[PMRDoctorsFillupCount_View]    Script Date: 08/10/2022 1:28:39 am ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[PMRDoctorsFillupCount_View]
AS
SELECT  dbo.PMRPatientGeneralInfo_View.DoctorId, 
		dbo.PMRPatientGeneralInfo_View.Registrationno, 
		dbo.PMRPatientGeneralInfo_View.TokenNo,
		dbo.PMRPatientGeneralInfo_View.TransDateEnglish,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.DX_Code1,'')='',0,1) as DX_Code1,  
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.DX_Code2,'')='',0,1) as DX_Code2, 
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.DX_Code3,'')='',0,1) as DX_Code3,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.DX_Code4,'')='',0,1) as DX_Code43,   
		IIf(IsNull(Cast(dbo.PMRPatientGeneralInfo_View.Diagnosis as varchar(max)),'')='',0,1) as Diagnosis,   
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.bp,'')='',0,1) as Bp,   
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.Breathing,'')='',0,1) as Breathing,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.Height,'')='',0,1) as Height,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.Weight,'')='',0,1) as Weight,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.Temprature,'')='',0,1) as Temprature,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.PulseRate,'')='',0,1) as PulseRate,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.Respiratory,'')='',0,1) as Respiratory,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.DurationOfIllness,0)=0,0,1) as DurationOfIllness,   
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.ChiefComplaint,'')='',0,1) as ChiefComplaint,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.SignificantSign,'')='',0,1) as SignificantSign,
        IIf(IsNull(dbo.PMRPatientGeneralInfo_View.OtherCondition,'')='',0,1) as OtherCondition,
		IIf(IsNull(Cast(dbo.PMRPatientGeneralInfo_View.MedicationNote AS Varchar(max)),'')='',0,1) as MedicationNote,
		IIf(IsNull(Cast(dbo.PMRPatientGeneralInfo_View.DoctorRemark as VarChar(Max)),'')='',0,1) as DoctorRemark,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.FixedAlergies,'0')='0',0,1) as FixedAleries,
        IIf(IsNull(dbo.PMRPatientGeneralInfo_View.DrugAlergies,'0')='0',0,1) as DrugAlergies,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.OtherAlergies,'0')='0',0,1) as OtherAlergies,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.IllnessType,0)=0,0,1) as IllnessType,
		IIf(IsNull(Cast(dbo.PMRPatientGeneralInfo_View.NoteAlergies as Varchar(max)),'')='',0,1) as NoteAlergies,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.Lmp,'')='',0,1) as Lmp,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.LmpDate,'')='',0,1) as LmpDate,
		IIf(IsNull(Cast(dbo.PMRPatientGeneralInfo_View.CmfNote as Varchar(max)),'')='',0,1) as CmfNote,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.los,0)=0,0,1) as Los,
		IIf(IsNull(dbo.PMRPatientGeneralInfo_View.eda,'')='',0,1) as Eda
		FROM    dbo.PMRPatientGeneralInfo_View 
GO


