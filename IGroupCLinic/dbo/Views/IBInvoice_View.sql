

CREATE VIEW [dbo].[IBInvoice_View]
 
AS
Select a.*,
		b.SlNo,
		b.ServiceID,
		b.Qty,
		b.Price,
		b.DiscPer,
		b.DiscAmt,
		b.VATAmt as VATAmount,
		b.VATPercent as VatPercent,
		c.Name_Control as IBDiagnosisDescription,
		d.NameEnglish as CompanyName,
		e.ProfessionID,
		f.CountryNameEng as CountryNameEnglish,
		f.CountryNameArabic as CountryNameArabic,
		g.ServiceNameEnglish,
		(select LabDeptID  from SystemSettings)   as DepartmentID,
		h.SalesmanNameEnglish     
From IBInvoiceGroup a
Left Outer Join IBInvoiceDetails b on a.Trans_Key = b.Group_Key
left outer join ShortDescription c on a.IBType = c.Code and c.ControlName = 'IBD'
left outer join InsuranceDetails d on a.CompanyID = d.InsuranceID and d.InsuranceType = 'Credit'
left outer join IBProfessions e on a.Profession  = e.ProfessionName 
left outer join CountryMaster f on a.CountryIOTA = f.CountryIOTA 
left outer join MedicalServices g on b.ServiceID = g.ServiceID 
left outer join SalesmanDetails h on a.SalesmanID = h.SalesmanID 
