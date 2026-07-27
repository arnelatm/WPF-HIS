















 CREATE View [dbo].[IBLabSampleList_View]
 as  
 SELECT 
 a.IdNo as IdNo
 ,Convert(Date,v.ResultTakenDate) as TakenDate
 ,b.Date as TakenTime
 ,d.FullNumber as LabNo
 ,g.CutIDentity as Border_Iqama
 ,h.PatName as PatientName
 ,Round(CASE WHEN DateDiff(Day,e.CustBirthday,GetDate()) > 365 Then  DateDiff(Day,e.CustBirthday,GetDate())/365.25
       WHEN DateDiff(Day,e.CustBirthday,GetDate()) > 30 Then DateDiff(Day,e.CustBirthday,GetDate())/12
	   ELSE DateDiff(Day,e.CustBirthday,GetDate())
  END,0) as Age
 ,CASE WHEN DateDiff(Day,e.CustBirthday,GetDate()) > 365 Then  'Y'
       WHEN DateDiff(Day,e.CustBirthday,GetDate()) > 30 Then 'M'
	   ELSE 'D'
  END AgeYMD
 ,e.CustNat as CountryNameEng
 ,ISNULL(a.Stool, 0) AS Stool
 ,ISNULL(a.Urine, 0) AS Urine
 ,ISNULL(a.RBS, 0) AS RBS
 ,v.CollectedUser as TakenBy
 ,b.Id as TransNBR
 ,convert(varchar(25), b.Date, 111) as TransDateEnglish
 ,CASE
    WHEN (c.WorkID = N'T2' AND d.NumberingSettingId=4 AND h.HideMedicalSector=0) THEN '2'
    WHEN (c.WorkID = N'T3' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN '1'
	WHEN (c.WorkID = N'T5' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN '1'
	WHEN (c.WorkID = N'T4' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN '3'
	WHEN (c.WorkID = N'T1' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN '4'
	ELSE '0'
  END as IBType
 FROM  dbo.IBLabSampleTaken AS a 
 right outer JOIN kizenClinic.dbo.A1_Invoces b
 on a.Trans_key = b.Id
 left join kizenClinic.dbo.MedicalEmpExamination h
 ON h.PatID = b.CustID
 left JOIN kizenClinic.dbo.A1_OrderWorks c
 on b.Id = c.OrderId
 left JOIN kizenClinic.dbo.JC_TOL_NumberingLog d
 on h.Id = d.SourceId
 left JOIN kizenClinic.dbo.Customers e
 ON h.PatId = e.CustId
 left Join kizenClinic.dbo.RefundedItem_View f
 on b.Id = f.ParentId
 left join kizenClinic.dbo.Customers g
 on b.CustID = g.CustId
 left join kizenClinic.dbo.VisitAnalysesData v
 on v.OrderID = b.ID
 WHERE  b.IsReturn=0 and IsNull(d.FullNumber,'') <> '' and  f.ParentId Is Null
 and (CASE
    WHEN (c.WorkID = N'T2' AND d.NumberingSettingId=4 AND h.HideMedicalSector=0) THEN 'BaladiyaTest'
    WHEN (c.WorkID = N'T3' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN 'IqamaTestNew'
	WHEN (c.WorkID = N'T5' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN 'IqamaTestRenewal'
	WHEN (c.WorkID = N'T1' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN 'FoodDelivery'
	WHEN (c.WorkID = N'T4' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN 'DrivingLicense'
	ELSE 'Nothing'
  END ) <> 'Nothing'