


 CREATE View [dbo].[EmploymentTests_View]
 as 
  SELECT  a.PatName as PatientName
 ,c.id as InvoiceNumber
 ,d.FullNumber as LabNumber
 ,a.DateTime
 ,e.CustNat as Nationality
 ,c.Date
 ,b.Id
 ,a.PatID as FileNumber
 ,g.CutIDentity as IdentityNumber
 ,CASE
    WHEN (c.WorkID = N'T2' AND d.NumberingSettingId=4 AND a.HideMedicalSector=0) THEN 'BaladiyaTest'
    WHEN (c.WorkID = N'T3' AND d.NumberingSettingId=3 AND a.HideMedicalSector=1) THEN 'IqamaTestNew'
	WHEN (c.WorkID = N'T5' AND d.NumberingSettingId=3 AND a.HideMedicalSector=1) THEN 'IqamaTestRenewal'
	ELSE 'Nothing'
  END as TestType
 FROM   kizenClinic.dbo.MedicalEmpExamination a
 inner JOIN kizenClinic.dbo.A1_OrderWorks c
 inner JOIN kizenClinic.dbo.A1_Invoces b
 on b.Id = c.OrderId
 ON a.PatID = b.CustID
 inner JOIN kizenClinic.dbo.JC_TOL_NumberingLog d
 on a.Id = d.SourceId
 inner JOIN kizenClinic.dbo.Customers e
 ON a.PatId = e.CustId
 left Join kizenClinic.dbo.RefundedItem_View f
 on b.Id = f.ParentId
 left join kizenClinic.dbo.Customers g
 on b.CustID = g.CustId
 WHERE  b.IsReturn=0 and IsNull(d.FullNumber,'') <> '' and f.ParentId Is Null
