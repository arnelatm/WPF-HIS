
CREATE VIEW [dbo].[ClinicInvoice_XView]
  AS
(select a.BranchID,
	a.Trans_Key,
	c.Series,
	c.RegistrationDate,
	a.RegistrationType,
	a.TransType,
	a.TransNbr,
	a.BillType,
	a.RegistrationNo,
	a.TransDateEnglish,
	a.TransDateHijri,
	a.DoctorID,
	a.InsuranceID,
	a.InsuranceGroupID,
	a.InsuranceNameEnglish,
	a.NormalDiscountAmt,
	a.PreviousBalanceAmt,
	a.DeductibleAmt,
	a.DeductibleDiscountAmt,
	a.ExtraDiscountPercent,
	a.ExtraDiscountAmt,
	a.RoundOffAmt,
	a.VATAmt as TotalVatAmt,
	a.VATExemption,
	a.BillAmt,
	a.Remarks,
	c.InsSoapNo,
	c.InsCardNo,
	a.Reject,
	a.RejectDate,
	a.UserID,
	a.MachineID,
	a.CreditCardNo,
	a.CreditCardExpiry,
	CONVERT(datetime,a.Create_Date) AS Create_Date,
	b.RowNbr,
	b.SaleType,
	b.ServiceID,
	-- case when (e.DeptID = " or e.DeptID is null) then case when n.serviceID is null then d.DeptID else n.DepartmetnID else e.DeptID end end as DepartmetnID,
	-- e.DeptID as DepartmentID, 
	d.DepartmentID,
	case when b.qty is null then 1 else b.Qty end as Qty,
	case when b.SalePrice is null then 0 else b.SalePrice end as SalePrice,
	case when b.CostPrice is null then 0 else b.costPricePerUnit end as CostPrice,
	case when b.DiscountPer is null then 0 else b.DiscountPer end as DiscountPer,
	case when b.DiscountAmt is null then 0 else b.DiscountAmt end as DiscountAmt,
	case when b.DeductiblePer is null then 0 else b.DeductiblePer end as DeductiblePer,
	case when b.VATPercent is null then 0 else b.VATPercent end as VATPercent,
	case when b.VATAmt is null then 0 else b.VATAmt end as VATAmt,
	b.SaleStatus,
	b.costPricePerUnit,
	c.PatientNameEnglish,
	c.PatientNameArabic,
	c.Age,
	c.AgeYMD,
	c.Sex,
	c.CountryIOTA,
	case when n.ServiceID is null then d.ServiceNameEnglish else n.ServiceNameEnglish end as ServiceNameEnglish,
	case when n.ServiceID is null or d.ServiceNameArabic is null or d.ServiceNameArabic='' then d.ServiceNameArabic else n.ServiceNameEnglish end as ServiceNameArabic,
	e.EmpNameEnglish,
	e.EmpNameArabic,
	f.CountryNameEng,
	f.CountryNameArabic,
	c.IqamaNo,
	c.Mobile,
	c.PhoneO,
	c.PHoneR,
	c.Address1,
	c.Address2,
	c.City,
	k.NameEnglish as GroupName,
	h.GroupInsuranceID,
	l.NameEnglish as activeInsName,
	h.UnderInsuranceID,
	m.NameEnglish as co_ins_company,
	g.DepartmentNameEnglish,
	a.TokenNo,
	e.OPDFloor,
	e.OPDNo,
	n.ServiceID as insServiceID,
	n.ServiceNameEnglish as InsServiceNameEnglish,
	case when (d.DepartmentID = 'INJ' and a.InsuranceID='') or (d.DepartmentID='VAC' and a.InsuranceID='') then 'Y' else 'N' end as PrintDept,
	a.ReferenceNo as ApprovalNo
from ClinicInvoiceGroup a
left outer join ClinicInvoiceDetails b 
on a.trans_key = b.group_key and a.branchid = b.Branchid
left outer join patientdetails c 
on a.registrationno=c.RegistrationNo and upper(a.RegistrationType)=upper(c.PatientType) and a.BranchID = c.BranchID
left outer join MedicalServices d 
on b.ServiceID=d.ServiceID and a.BranchID=d.BranchID 
left outer join EmployeeDetails e 
on a.DoctorID = e.EmpID
left outer join CountryMaster f

on c.CountryIOTA COLLATE database_Default = f.CountryIOTA COLLATE database_default 
left outer join InsuranceDetails h 
on a.InsuranceID = h.InsuranceID and upper(left(a.Registrationtype,4))=upper(left(h.insuranceType,4))
left outer join InsuranceDetails k 
on h.GroupInsuranceID=k.InsuranceID and upper(left(h.insuranceType,4))=upper(left(k.insurancetype,4))
left outer join InsuranceDetails l
on h.GroupInsuranceID=l.InsuranceID and upper(left(h.insurancetype,4))=upper(left(l.insurancetype,4))
left outer join InsuranceDetails m 
on h.UnderInsuranceID=m.InsuranceID and upper(left(h.insurancetype,4))=upper(left(m.insurancetype,4))
left outer join InsuranceServicePriceList n 
on b.ServiceID=n.ServiceID and n.InsuranceID=a.InsuranceGroupID
left outer join MedicalDepartments g
on g.DepartmentID=(case when n.serviceid is null then d.Departmentid else n.Departmentid end)
)

