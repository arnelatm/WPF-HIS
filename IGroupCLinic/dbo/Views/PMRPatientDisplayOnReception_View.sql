CREATE View PMRPatientDisplayOnReception_View
 
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
	e.ServiceNameEnglish,
	d.Qty,
	d.Unit,
	d.InvestigationRemark as remark,
	e.CashPrice,
	case when e.DiscountPercent is null then 0 else e.DiscountPercent end as DiscountPercent,
	case when e.DiscountAmt is null then 0 else e.DiscountAmt end as DiscountAmt,
	'Investigation' as TransType,
	h.ClinicTransNBR,
	h.Printed
FROM PMRPatientGeneralInfo a
left outer join PatientDetails b on a.patienttype = b.patienttype and a.registrationno = b.registrationno
left outer join EmployeeDetails c on a.doctorid = c.empid
left outer join PMRPatientInvestigation d on a.trans_key = d.trans_key
left outer join MedicalServices e on d.item_code = e.serviceid
left outer join InsuranceDetails f on b.inscocode = f.insuranceid
left outer join InsuranceServicePriceList g on f.groupinsuranceid = g.insuranceid and g.serviceid = e.serviceid 
left outer join PMRClinicInvoiceGenerated h on a.Trans_Key = h.PMRTrans_Key and d.Item_Code  = h.serviceid 
where not d.item_code is null
union all
select 
	a.Trans_Key,
	a.TransNBR,
	a.TransDateEnglish,
	a.PatientType,
	a.RegistrationNo,
	a.DoctorID,
	b.patientnameenglish,
	b.patientnamearabic,
	b.Mobile,
	b.IqamaNo ,
	c.empnameenglish,
	c.empnamearabic,
	c.OPDNo,
	d.item_code,
	e.servicenameenglish,
	d.Qty,
	d.Unit,
	d.TreatmentRemark as remark,
	e.CashPrice,
	case when e.DiscountPercent is null then 0 else e.DiscountPercent end as DiscountPercent,
	case when e.DiscountAmt is null then 0 else e.DiscountAmt end as DiscountAmt,
	'Treatment' as TransType,
	h.ClinicTransNBR,
	h.Printed
from pmrpatientgeneralinfo a
left outer join patientdetails b on a.patienttype = b.patienttype and a.registrationno = b.registrationno
left outer join employeedetails c on a.doctorid = c.empid
left outer join pmrpatienttreatment d on a.trans_key = d.trans_key
left outer join medicalservices e on d.item_code = e.serviceid
left outer join InsuranceDetails f on b.inscocode = f.insuranceid
left outer join InsuranceServicePriceList g on f.groupinsuranceid = g.insuranceid and g.serviceid = e.serviceid 
left outer join PMRClinicInvoiceGenerated h on a.Trans_Key = h.PMRTrans_Key and d.Item_Code  = h.serviceid 
where not d.item_code is null
--where a.doctorid = '1018' and a.transdateenglish = '2015/04/30'
