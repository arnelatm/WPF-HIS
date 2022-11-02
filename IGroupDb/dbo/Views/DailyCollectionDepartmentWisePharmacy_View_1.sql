
CREATE VIEW DailyCollectionDepartmentWisePharmacy_View
 
AS

Select 
	b.BranchID,
	b.Trans_Key,
	b.TransType,
	b.TransNbr,
	b.TransDateEnglish,
	b.RegistrationNo,
	case when d.RegistrationDate is null then b.TransDateEnglish else d.RegistrationDate end as RegistrationDate,
	case when d.PatientType is null then 'Cash' else d.PatientType end as RegistrationType,
	case when d.PatientNameEnglish is null then 'Cash Customer' else d.PatientNameEnglish end as PatientNameEnglish,
	b.DoctorID,
	e.EmpNameEnglish as DoctorNameEnglish,
	b.InsuranceID,
	c.NameEnglish as InsuranceNameEnglish,
	b.InsuranceGroupID,
	f.nameenglish as InsuranceTPA,
	b.ExtraDiscountPercent,
	b.ExtraDiscountAmt,
	b.RoundOffamt,
	case when a.SaleStatus = 'SR' then 1 else 0 end as Reject,
	sum(case when g.DepartmentGroupID = '001' then a.Qty * a.saleprice else 0 end) as GrossCON,
	sum(case when g.DepartmentGroupID = '002' or g.departmentgroupid is null then a.Qty * a.saleprice else 0 end) as GrossMCT,
	sum(case when g.DepartmentGroupID = '003' then a.Qty * a.saleprice else 0 end) as GrossXRY,
	sum(case when g.DepartmentGroupID = '004' then a.Qty * a.saleprice else 0 end) as GrossLAB,
	sum(case when g.DepartmentGroupID = '005' then a.Qty * a.saleprice else 0 end) as GrossDNT,
	sum(case when g.DepartmentGroupID = '006' then a.Qty * a.saleprice else 0 end) as GrossOPH,
	sum(case when g.DepartmentGroupID = '007' then a.Qty * a.saleprice else 0 end) as GrossCMD,
	sum(case when g.DepartmentGroupID = '008' then a.Qty * a.saleprice else 0 end) as GrossPHR,
	sum(case when g.DepartmentGroupID = '001' then a.DiscountAmt else 0 end) as DiscCON,
	sum(case when g.DepartmentGroupID = '002' or g.departmentgroupid is null then a.DiscountAmt else 0 end) as DiscMCT,
	sum(case when g.DepartmentGroupID = '003' then a.DiscountAmt else 0 end) as DiscXRY,
	sum(case when g.DepartmentGroupID = '004' then a.DiscountAmt else 0 end) as DiscLAB,
	sum(case when g.DepartmentGroupID = '005' then a.DiscountAmt else 0 end) as DiscDNT,
	sum(case when g.DepartmentGroupID = '006' then a.DiscountAmt else 0 end) as DiscOPH,
	sum(case when g.DepartmentGroupID = '007' then a.DiscountAmt else 0 end) as DiscCMD,
	sum(case when g.DepartmentGroupID = '008' then a.DiscountAmt else 0 end) as DiscPHR,
	sum(case when g.DepartmentGroupID <> '008' then a.DeductibleAmt else 0 end) as CLNdedAmt,
	sum(case when g.DepartmentGroupID = '008' then a.DeductibleAmt else 0 end) as PHRdedAmt,
	'Pharmacy' as InvoiceType
from pharmacyinvoicedetails a
left outer join pharmacyinvoicegroup b on a.group_key = b.trans_key
left outer join insurancedetails c on b.insuranceid = c.insuranceid
left outer join patientdetails d on b.registrationno = d.registrationno and upper(left(b.RegistrationType,2)) = d.Series
left outer join employeedetails e on b.doctorid = e.empid
left outer join insurancedetails f on f.insuranceid = c.Groupinsuranceid and f.insurancetype = 'TPA'
left outer join MedicalDepartments g on '008' = g.departmentgroupid
where (a.SaleStatus is null or a.SaleStatus = '') AND a.Item_Code <> 'PHR-DED'
group by b.BranchID,
	 b.Trans_Key,
	 b.TransType,
	 b.TransNbr,
	 b.TransDateEnglish,
	 b.RegistrationNo,
	 d.RegistrationDate,
	 d.PatientType,
	 d.PatientNameEnglish,
	 b.DoctorID,
	 e.EmpNameEnglish,
	 b.InsuranceID,
	 c.NameEnglish,
	 b.InsuranceGroupID,
	 f.nameenglish,
	 b.ExtraDiscountPercent,
	 b.ExtraDiscountAmt,
	 b.RoundOffamt,
	 a.SaleStatus