














 CREATE View [dbo].[AgentsAndDriverTests_View]
 as 
  SELECT  Distinct b.CustName as PatientName
 ,d.FullNumber as LabNumber
 ,b.Date as DateTime
 ,e.CustNat as Nationality
 ,CAST(b.Date aS Date) as Date
 ,b.Id as InvoiceNumber 
 ,a.ReferenceID as FileNumber
 ,g.CutIDentity as IdentityNumber
 ,~b.IsInsurance as CashOrCredit
 ,CASE
    WHEN (c.WorkID = N'T1' AND d.NumberingSettingId=2 AND a.Type=2) THEN 'FoodDelivery'
    WHEN (c.WorkID = N'T4' AND d.NumberingSettingId=1 AND a.Type=14) THEN 'DriverLicense'
	ELSE 'Nothing'
  END as TestType
 ,d.NumberingSettingId
 ,d.Prefix
 ,a.Type
 ,c.WOrkId
 ,d.SourceId
 ,a.ReferenceId
 ,e.CustID
 FROM   kizenClinic.dbo.JC_ED_Document a
 left JOIN kizenClinic.dbo.A1_OrderWorks c
 left JOIN kizenClinic.dbo.A1_Invoces b
 on b.Id = c.OrderId
 ON a.ReferenceID = b.CustID
 left JOIN kizenClinic.dbo.JC_TOL_NumberingLog d
 on a.Id = d.SourceId
 left JOIN kizenClinic.dbo.Customers e
 ON a.ReferenceId = e.CustId
 left Join kizenClinic.dbo.RefundedItem_View f
 on b.Id = f.ParentId
 left join kizenClinic.dbo.Customers g
 on b.CustID = g.CustId
 WHERE (RTrim(d.Prefix)= 'D-' or RTrim(d.Prefix) = 'F-') and  b.IsReturn=0 and IsNull(d.FullNumber,'') <> '' and f.ParentId Is Null and
     ( (c.WorkID = N'T1' AND d.NumberingSettingId=2 AND a.Type=2) or (c.WorkID = N'T4' AND d.NumberingSettingId=1 AND a.Type=14))

