USE [iGroupClinic]
GO

/****** Object:  View [dbo].[PMRDoctorsFillupStatistics_View]    Script Date: 08/10/2022 1:30:01 am ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[PMRDoctorsFillupStatistics_View]
AS
SELECT  dbo.PMRDoctorsGenForm_View.DoctorId, 
		dbo.PMRDoctorsGenForm_View.PatientName, 
		dbo.PMRDoctorsGenForm_View.FileNo, 
		dbo.PMRMedNInvestigationPrint_View.TransNBR, 
        dbo.PMRMedNInvestigationPrint_View.DX_Code1, 
		dbo.PMRMedNInvestigationPrint_View.DX_Code2, 
		dbo.PMRMedNInvestigationPrint_View.DX_Code3, 
		dbo.PMRMedNInvestigationPrint_View.DX_Code4, 
        dbo.PMRMedNInvestigationPrint_View.Diagnosis, 
		dbo.PMRDoctorsGenForm_View.Token, 
		dbo.PMRMedNInvestigationPrint_View.bp, 
		dbo.PMRMedNInvestigationPrint_View.Breathing, 
        dbo.PMRMedNInvestigationPrint_View.Height, 
		dbo.PMRMedNInvestigationPrint_View.Weight, 
		dbo.PMRMedNInvestigationPrint_View.Temprature, 
		dbo.PMRMedNInvestigationPrint_View.PulseRate, 
        dbo.PMRMedNInvestigationPrint_View.Respiratory, 
		dbo.PMRMedNInvestigationPrint_View.DurationOfIllness, 
		dbo.PMRMedNInvestigationPrint_View.ChiefComplaint, 
		dbo.PMRMedNInvestigationPrint_View.SignificantSign, 
        dbo.PMRMedNInvestigationPrint_View.OtherCondition, 
		dbo.PMRMedNInvestigationPrint_View.MedicationNote, 
		dbo.PMRMedNInvestigationPrint_View.DoctorRemark, 
		dbo.PMRMedNInvestigationPrint_View.Item_Code, 
        dbo.PMRMedNInvestigationPrint_View.TransDateEnglish, 
		dbo.PMRDoctorsGenForm_View.PmrDate
FROM    dbo.PMRDoctorsGenForm_View INNER JOIN
        dbo.PMRMedNInvestigationPrint_View ON dbo.PMRDoctorsGenForm_View.Trans_Key = dbo.PMRMedNInvestigationPrint_View.Trans_Key
GO


