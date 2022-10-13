CREATE VIEW IBInvoiceDepartmentWise_View
 
AS
Select a.Trans_Key,
		a.BranchID,
		a.IBType,
		a.RegistrationNo,
		a.PatientName,
		a.TransType,
		a.TransNBR,
		a.CompanyID,
		a.DoctorID,
		a.Profession,
		a.countryIOTA,
		a.ExtraDiscountPer,
		a.ExtraDiscountAmt,
		a.Rejected,
		a.UserID,
		CASE WHEN a.IBType = '1' then sum(b.Qty*b.Price) else 0 end as GrossAmtIQAMA,
		CASE WHEN a.IBType = '2' then sum(b.Qty*b.Price) else 0 end as GrossAmtBaladiya,
		CASE WHEN a.IBType = '3' then sum(b.Qty*b.Price) else 0 end as GrossAmtDLicense,
		CASE WHEN a.IBType = '4' then sum(b.Qty*b.Price) else 0 end as GrossAmtMedicalReport,
		CASE WHEN a.IBType = '5' then sum(b.Qty*b.Price) else 0 end as GrossAmtOther,
		case when a.IBType = '1' then sum(case when b.DiscPer > 0 then b.DiscPer * b.qty * b.Price /100 else b.discAmt END) else 0 end as DiscPerAmtIQAMA,
		case when a.IBType = '2' then sum(case when b.DiscPer > 0 then b.DiscPer * b.qty * b.Price /100 else b.discAmt END) else 0 end as DiscPerAmtBaladiya,
		case when a.IBType = '3' then sum(case when b.DiscPer > 0 then b.DiscPer * b.qty * b.Price /100 else b.discAmt END) else 0 end as DiscPerAmtDLicense,
		case when a.IBType = '4' then sum(case when b.DiscPer > 0 then b.DiscPer * b.qty * b.Price /100 else b.discAmt END) else 0 end as DiscPerAmtMedicalReport,
		case when a.IBType = '5' then sum(case when b.DiscPer > 0 then b.DiscPer * b.qty * b.Price /100 else b.discAmt END) else 0 end as DiscPerAmtOther,
		a.VATAmt as TotalVATAmt,
		c.ControlName as IBDiagnosisDescription,
		d.NameEnglish as CompanyName,
		e.ProfessionID,
		f.CountryNameEng as CountryNameEnglish,
		f.CountryNameArabic as CountryNameArabic,
		g.ServiceNameEnglish,
		h.UserNameEnglish    
From IBInvoiceGroup a
Left Outer Join IBInvoiceDetails b on a.Trans_Key = b.Group_Key
left outer join ShortDescription c on a.IBType = c.Code and c.Name_Control = 'IBD'
left outer join InsuranceDetails d on a.CompanyID = d.InsuranceID and d.InsuranceType = 'Credit'
left outer join IBProfessions e on a.Profession  = e.ProfessionName 
left outer join CountryMaster f on a.CountryIOTA = f.CountryIOTA 
left outer join MedicalServices g on b.ServiceID = g.ServiceID 
left outer join usersbank h on a.UserID = h.UserID 
GROUP BY
		a.Trans_Key,
		a.BranchID,
		a.IBType,
		a.RegistrationNo,
		a.PatientName,
		a.TransType,
		a.TransNBR,
		a.CompanyID,
		a.DoctorID,
		a.Profession,
		a.countryIOTA,
		a.ExtraDiscountPer,
		a.ExtraDiscountAmt,
		a.Rejected,
		a.UserID,
		a.VATAmt ,
		c.ControlName,
		d.NameEnglish,
		e.ProfessionID,
		f.CountryNameEng,
		f.CountryNameArabic,
		g.ServiceNameEnglish,
		h.UserNameEnglish