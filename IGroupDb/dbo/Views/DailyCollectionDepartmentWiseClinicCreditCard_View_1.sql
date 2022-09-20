
CREATE VIEW DailyCollectionDepartmentWiseClinicCreditCard_View
 
AS
select 
	b.BranchID,
	b.Trans_Key,
	b.BillType,
	b.TransNBR,
	b.TransDateEnglish,
	b.RegistrationNo,
	c.RegistrationDate,
	c.PatientType as RegistrationType,
	case when c.PatientNameEnglish is null then 'Cash Customer' else c.PatientNameEnglish end as PatientNameEnglish,
	b.DoctorID,
	d.EmpNameEnglish as DoctorNameEnglish,
	b.InsuranceID,
	b.InsuranceNameEnglish,
	b.InsuranceGroupID,
	e.nameenglish as InsuranceTPA,
	b.ExtraDiscountPercent,
	b.ExtradiscountAmt,
	b.RoundOffAmt,
	b.Reject,
	b.UserID,
	i.UserNameEnglish,
	sum(case when h.DepartmentGroupID = '001' then a.Qty * a.saleprice else 0 end) as GrossCON,
	sum(case when h.DepartmentGroupID = '002' or h.DepartmentGroupID is null then a.Qty * a.saleprice else 0 end) as GrossMCT,
	sum(case when h.DepartmentGroupID = '003' then a.Qty * a.saleprice else 0 end) as GrossXRY,
	sum(case when h.DepartmentGroupID = '004' then a.Qty * a.saleprice else 0 end) as GrossLAB,
	sum(case when h.DepartmentGroupID = '005' then a.Qty * a.saleprice else 0 end) as GrossDNT,
	sum(case when h.DepartmentGroupID = '006' then a.Qty * a.saleprice else 0 end) as GrossOPH,
	sum(case when h.DepartmentGroupID = '007' then a.Qty * a.saleprice else 0 end) as GrossCMD,
	sum(case when h.DepartmentGroupID = '008' then a.Qty * a.saleprice else 0 end) as GrossPHR,
	sum(case when h.DepartmentGroupID = '001' then case when a.DiscountAmt=0 then a.qty*a.saleprice*a.discountper/100 else a.discountamt end else 0 end) as DiscCON,
	sum(case when h.DepartmentGroupID = '002' or h.departmentgroupid is null then case when a.DiscountAmt=0 then a.qty*a.saleprice*a.discountper/100 else a.discountamt end else 0 end) as DiscMCT,
	sum(case when h.DepartmentGroupID = '003' then case when a.DiscountAmt=0 then a.qty*a.saleprice*a.discountper/100 else a.discountamt end else 0 end) as DiscXRY,
	sum(case when h.DepartmentGroupID = '004' then case when a.DiscountAmt=0 then a.qty*a.saleprice*a.discountper/100 else a.discountamt end else 0 end) as DiscLAB,
	sum(case when h.DepartmentGroupID = '005' then case when a.DiscountAmt=0 then a.qty*a.saleprice*a.discountper/100 else a.discountamt end else 0 end) as DiscDNT,
	sum(case when h.DepartmentGroupID = '006' then case when a.DiscountAmt=0 then a.qty*a.saleprice*a.discountper/100 else a.discountamt end else 0 end) as DiscOPH,
	sum(case when h.DepartmentGroupID = '007' then case when a.DiscountAmt=0 then a.qty*a.saleprice*a.discountper/100 else a.discountamt end else 0 end) as DiscCMD,
	sum(case when h.DepartmentGroupID = '008' then case when a.DiscountAmt=0 then a.qty*a.saleprice*a.discountper/100 else a.discountamt end else 0 end) as DiscPHR,
	sum(case when h.DepartmentGroupID <> '008' then a.DeductibleAmt else 0 end) as CLNdedAmt,
	case when h.DepartmentGroupID <> '008' then b.DeductibleDiscountAmt else 0 end as CLNdedDiscAmt,
	case when h.DepartmentGroupID <> '008' then b.ExtraDiscountAmt else 0 end as CLNExtraDiscAmt,
	sum(case when h.DepartmentGroupID = '008' then a.DeductibleAmt else 0 end) as PHRdedAmt,
	case when h.DepartmentGroupID = '008' then b.DeductibleDiscountAmt else 0 end as PHRdedDiscAmt,
	case when h.DepartmentGroupID = '008' then b.ExtraDiscountAmt else 0 end as PHRExtraDiscAmt,
	'Clinic' as InvoiceType,
	c.CountryIOTA,
	j.CountryNameEng
from clinicinvoicedetails a
left outer join clinicinvoicegroup b on a.group_key = b.trans_key 
left outer join patientdetails c on b.registrationno = c.registrationno and upper(b.registrationtype) = upper(c.patienttype) 
left outer join employeedetails d on b.doctorid = d.empid
left outer join insurancedetails e on e.insuranceid = b.insurancegroupid and e.insurancetype = 'TPA'
left outer join MedicalServices f on a.ServiceID = f.ServiceID
left outer join InsuranceServicePriceList g on a.serviceID = g.ServiceID and g.InsuranceID = b.InsuranceGroupID
left outer join MedicalDepartments h on h.DepartmentID = (case when f.serviceID is null then g.departmentID else f.DepartmentID end) 
left outer join UsersBank i on b.UserID = i.UserID 
left outer join CountryMaster j on c.CountryIOTA = j.CountryIOTA
where (a.SaleStatus is null or a.SaleStatus = '') and (b.reject = 0 or b.reject is null)
and b.CreditCardNo <> '' and  not b.CreditcardNo is null
group by
	b.BranchID,
	b.Trans_Key,
	b.CreditCardNo,
	b.BillType,
	b.TransNBR,
	b.TransDateEnglish,
	b.RegistrationNo,
	c.RegistrationDate,
	c.PatientType,
	c.PatientNameEnglish,
	b.DoctorID,
	d.EmpNameEnglish,
	b.InsuranceID,
	b.InsuranceNameEnglish,
	b.InsuranceGroupID,
	e.nameenglish,
	b.ExtraDiscountPercent,
	b.ExtradiscountAmt,
	b.RoundOffAmt,
	b.Reject,
        a.SaleStatus,
	c.PatientType,
	h.departmentgroupid,
	b.UserID,
	i.UserNameEnglish,
	b.DeductibleDiscountAmt,
	b.ExtraDiscountAmt,
	c.CountryIOTA,
	j.CountryNameEng