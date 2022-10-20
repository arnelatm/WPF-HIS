
CREATE View [dbo].[PMRPatientDisplayAtPharmacy_View]
 
as 
Select 
	a.Trans_Key,
	a.TransNBR,
	a.TransDateEnglish,
	a.PatientType,
	a.RegistrationNo,
	a.DoctorID, 
	b.Patientnameenglish,
	b.Patientnamearabic,
	b.Mobile,
	b.IqamaNo ,
	c.EmpNameEnglish,
	c.EmpNameArabic,
	c.OPDNo,
	d.Item_Code,
	e.ItemNameEnglish,
	d.Qty,
	d.Unit,
	d.transtype,
	h.PharmacyTransNBR
FROM PMRPatientGeneralInfo a
left outer join PatientDetails b on a.patienttype = b.patienttype and a.registrationno = b.registrationno
left outer join EmployeeDetails c on a.doctorid = c.empid
left outer join PMRPrescription_View d on a.trans_key = d.trans_key
left outer join itemDetails e on d.item_code = e.item_code and e.BranchID = '01'
left outer join InsuranceDetails f on b.inscocode = f.insuranceid
left outer join InsuranceServicePriceList g on f.groupinsuranceid = g.insuranceid and g.serviceid = e.item_code
left outer join PMRPharmacyInvoiceGenerated h on a.Trans_Key = h.PMRTrans_Key and d.Item_Code  = h.item_code
where not d.item_code is null