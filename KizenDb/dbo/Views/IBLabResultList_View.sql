








 CREATE View [dbo].[IBLabResultList_View]
 as  SELECT  a.[IdNo] as IdNo
      ,a.Trans_Key
      ,a.[PassportNumber]
      ,Iif(a.IdNo is Null,0,a.[Clinical]) as Clinical
      ,Iif(a.IdNo is Null,0,a.[Xray]) as Xray
      ,Iif(a.IdNo is Null,0,a.[TBSputum]) as TBSputum
      ,Iif(a.IdNo is Null,0,a.[HIVEliza]) as HIVEliza
      ,Iif(a.IdNo is Null,0,a.[HCVEliza]) as HCVEliza
      ,Iif(a.IdNo is Null,0,a.[HBSAgEliza]) as HBSAgEliza
      ,Iif(a.IdNo is Null,0,a.[Malaria]) as Malaria
      ,Iif(a.IdNo is Null,0,a.[VDRL]) as VDRL
      ,Iif(a.IdNo is Null,0,a.[Widal]) as Widal
      ,Iif(a.IdNo is Null,0,a.[Pregnancy]) as Pregnancy
      ,Iif(a.IdNo is Null,0,a.[BilharziasisUrine]) as BilharziasisUrine
      ,Iif(a.IdNo is Null,0,a.[BilharziasisStool]) as BilharziasisStool
      ,Iif(a.IdNo is Null,0,a.[Shigella]) as Shigella
      ,Iif(a.IdNo is Null,0,a.[Cholera]) as Cholera
 ,h.PatName as PatientName
 ,h.Id as MedExpIdNo
 ,c.id as InvoiceItemIdNo
 ,d.FullNumber as LabNo
 ,h.DateTime
 ,e.CustNat as CountryNameEng
 ,e.CustNat as CountryIota
 ,c.Date as TransactionDate
 ,e.CustJob as Profession
 ,b.Id as InvoiceNo
 ,h.PatID as FileNumber
 ,g.CutIDentity as Border_Iqama
 ,CASE
    WHEN (c.WorkID = N'T2' AND d.NumberingSettingId=4 AND h.HideMedicalSector=0) THEN 'BaladiyaTest'
    WHEN (c.WorkID = N'T3' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN 'IqamaTestNew'
	WHEN (c.WorkID = N'T5' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN 'IqamaTestRenewal'
	ELSE 'Nothing'
  END as TestType
 ,Left(g.CustGender,1) as Sex
 ,CASE
    WHEN (c.WorkID = N'T2' AND d.NumberingSettingId=4 AND h.HideMedicalSector=0) THEN '2'
    WHEN (c.WorkID = N'T3' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN '1'
	WHEN (c.WorkID = N'T5' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN '1'
	ELSE '0'
  END as TransType
 ,CASE
    WHEN (c.WorkID = N'T2' AND d.NumberingSettingId=4 AND h.HideMedicalSector=0) THEN '2'
    WHEN (c.WorkID = N'T3' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN '1'
	WHEN (c.WorkID = N'T5' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN '1'
	ELSE '0'
  END as IbType
 FROM  dbo.IBLabResult AS a 
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
 WHERE  b.IsReturn=0 and IsNull(d.FullNumber,'') <> '' and  f.ParentId Is Null
 and (CASE
    WHEN (c.WorkID = N'T2' AND d.NumberingSettingId=4 AND h.HideMedicalSector=0) THEN 'BaladiyaTest'
    WHEN (c.WorkID = N'T3' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN 'IqamaTestNew'
	WHEN (c.WorkID = N'T5' AND d.NumberingSettingId=3 AND h.HideMedicalSector=1) THEN 'IqamaTestRenewal'
	ELSE 'Nothing'
  END ) <> 'Nothing'