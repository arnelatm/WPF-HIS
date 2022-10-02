USE [iGroupClinic]
GO

/****** Object:  View [dbo].[PMRMedNInvestigationPrint_View]    Script Date: 02/10/2022 4:58:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE view 	[dbo].PMRPharmacyMedicinePrint_View --[PMRMedicineLabPrint_View]
 
as 
select 	
	'MED' AS InvestigationCode,
	a.[Trans_Key], 
	a.[TransNBR],
	a.[TransType],
	a.[TransDateEnglish],
	a.[PatientType],
	a.[BillType],
	a.[Series],
	a.[RegistrationNo],
	a.[TokenNo],
	a.[InsuranceID],
	a.[InsuranceGroupID],
	a.[DoctorID],
	a.[bp],
	a.[Breathing],
	a.[Height],
	a.[Weight],
	a.[Temprature],
	a.[PulseRate],
	a.[Respiratory],
	a.[VisitNo],
	a.[VisitType],
	a.[DurationOfIllness],
	a.[DurationYMD],
	a.[AdmissionType],
	a.[FixedAlergies],
	a.[DrugAlergies],
	a.[OtherAlergies],
	a.[ChiefComplaint],
	CAST(a.[NoteAlergies] AS NVARCHAR(MAX)) as NoteAlergies,
	a.[SignificantSign],
	a.[OtherCondition],
	Cast(a.[Diagnosis] as NVarchar(max)) as Diagnosis,
	a.[DX_Code1],
	a.[DX_Code2],
	a.[DX_Code3],
	a.[DX_Code4],
	Cast(a.[MedicationNote] as NVarChar(max)) as MedicationNote,
	a.[IllnessType],
	a.[Lmp],
	a.[LmpDate],
	a.[Cmf],
	Cast(a.[CmfNote] as NVarChar(Max)) as CmfNote,
	a.[Los],
	a.[Eda],
	Cast(a.[DoctorRemark] as NVarChar(Max)) as DoctorRemark,
	a.[UserID],
	a.[Create_Date],
	a.[MachineID],
	b.RowNBR,
	b.Item_Code,
	b.Qty,
	b.Unit,
	b.SalePrice,
	b.DiscountPer,
	b.DiscountAmt,
	b.BillAmt,
	b.ItemNameEnglish as ItemNameEnglish,
	b.itemnamearabic as ItemNameArabic,
	b.DosageID, 
	b.DosageEnglish ,
	b.DosageArabic ,
	b.Duration,
	c.PatientNameEnglish ,
	c.Age,
	c.Sex,
	c.AgeYMD ,
	c.Mobile,
	c.IqamaNo,
	d.CountryNameEng,
	e.EMPNameEnglish,
	e.OPDNo ,
	f.NameEnglish as Company,
	g.PharmacyTransNBR,
	g.Printed,
	c.InsCardExpiry,
	k.RegistrationNo as SFDACode,
	m.[Generic name] as GenericName,
	m.[trade name] as TradeName,
    m.[strength value] as StrengthValue,
    m.[unit of strength] as UnitOfStrength,
    m.[dosage form] as DosageForm,
    m.[Volume] as Volume,
    m.[Unit of Volume] as UnitOfVolume,
    m.[Package type] as PackageType,
    m.[Package size] as PackageSize,
	'' as InvestigationRemark
from 	PMRPatientGeneralInfo			A	
left outer join PMRMedicineDetails_View 	B on a.trans_key=b.Trans_key 
left outer join PatientDetails 			C on a.registrationno =c.registrationno and a.series=c.series
left outer join CountryMaster 			D on c.countryiota =d.countryiota 
left outer join EmployeeDetails			E on a.doctorid  =e.empid 
left outer join InsuranceDetails 		F on a.insuranceid  =f.insuranceid
left outer join PMRPharmacyInvoiceGenerated g on a.Trans_Key  =g.PMRTrans_Key AND b.item_Code = g.item_code
left outer join ItemRegistration    k on b.item_code COLLATE database_DEFAULT = k.Item_Code COLLATE database_DEFAULT 
left outer join DrugList            m on k.RegistrationNo  COLLATE database_DEFAULT = m.registrationno COLLATE database_DEFAULT
where ItemNameEnglish Is Not Null OR ItemnameEnglish <> ''
union
select 	
	iiF(G.ServiceGroup='201','LAB','XRY') AS InvestigationCode,
	a.[Trans_Key], 
	a.[TransNBR],
	a.[TransType],
	a.[TransDateEnglish],
	a.[PatientType],
	a.[BillType],
	a.[Series],
	a.[RegistrationNo],
	a.[TokenNo],
	a.[InsuranceID],
	a.[InsuranceGroupID],
	a.[DoctorID],
	a.[bp],
	a.[Breathing],
	a.[Height],
	a.[Weight],
	a.[Temprature],
	a.[PulseRate],
	a.[Respiratory],
	a.[VisitNo],
	a.[VisitType],
	a.[DurationOfIllness],
	a.[DurationYMD],
	a.[AdmissionType],
	a.[FixedAlergies],
	a.[DrugAlergies],
	a.[OtherAlergies],
	a.[ChiefComplaint],
	CAST(a.[NoteAlergies] AS NVARCHAR(MAX)),
	a.[SignificantSign],
	a.[OtherCondition],
	Cast(a.[Diagnosis] as NVarchar(max)),
	a.[DX_Code1],
	a.[DX_Code2],
	a.[DX_Code3],
	a.[DX_Code4],
	Cast(a.[MedicationNote] as NVarChar(max)),
	a.[IllnessType],
	a.[Lmp],
	a.[LmpDate],
	a.[Cmf],
	Cast(a.[CmfNote] as NVarChar(Max)),
	a.[Los],
	a.[Eda],
	Cast(a.[DoctorRemark] as NVarChar(Max)),
	a.[UserID],
	a.[Create_Date],
	a.[MachineID],
	b.RowNBR,
	b.Item_Code,
	b.Qty,
	b.Unit,
	b.SalePrice,
	b.DiscountPer,
	b.DiscountAmt,
	b.BillAmt,
	g.ServiceNameEnglish as ItemNameEnglish,
	g.ServiceNameArabic as ItemNameArabic,
	'', 
	'',
	'',
	'',
	c.PatientNameEnglish ,
	c.Age,
	c.Sex,
	c.AgeYMD ,
	c.Mobile,
	c.IqamaNo,
	d.CountryNameEng,
	e.EMPNameEnglish,
	e.OPDNo ,
	f.NameEnglish as Company,
	NULL,
	0,
	c.InsCardExpiry,
	'',
	'',
	'',
    '',
    '',
    '',
    0,
    '',
    '',
    '',
	b.InvestigationRemark
from 	PMRPatientGeneralInfo			A	
left outer join PMRPatientInvestigation B on a.trans_key=b.Trans_key 
left outer join PatientDetails 			C on a.registrationno =c.registrationno and a.series=c.series
left outer join CountryMaster 			D on c.countryiota =d.countryiota 
left outer join EmployeeDetails			E on a.doctorid  =e.empid 
left outer join InsuranceDetails 		F on a.insuranceid  =f.insuranceid
left outer join MedicalServices         G on B.Item_Code = g.ServiceID 
where ServiceNameEnglish Is Not Null OR ServiceNameEnglish <> ''
GO


