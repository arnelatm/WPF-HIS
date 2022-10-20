CREATE VIEW InsuranceSummaryReport_View
 
AS
select
	a.BranchID,
	a.SeqNo,
	'CR' as BillType,
	a.RegistrationNo,
	a.PatientNameEnglish,
	a.TransNBR,
	a.TransDAteEnglish,
	a.ClaimType,
	a.InsCardNo,
	a.Policy,
	sum(case when d.DepartmentGroupID = '001' then a.Qty * a.Amount else 0 end) as GrossCON,
	sum(case when d.DepartmentGroupID = '002' or d.departmentgroupid is null then a.Qty * a.Amount else 0 end) as GrossMCT,
	sum(case when d.DepartmentGroupID = '003' then a.Qty * a.Amount else 0 end) as GrossXRY,
	sum(case when d.DepartmentGroupID = '004' then a.Qty * a.Amount else 0 end) as GrossLAB,
	sum(case when d.DepartmentGroupID = '005' then a.Qty * a.Amount else 0 end) as GrossDNT,
	sum(case when d.DepartmentGroupID = '006' then a.Qty * a.Amount else 0 end) as GrossOPH,
	sum(case when d.DepartmentGroupID = '007' then a.Qty * a.Amount else 0 end) as GrossCMD,
	sum(case when d.DepartmentGroupID = '008' then a.Qty * a.Amount else 0 end) as GrossPHR,
	sum(case when d.DepartmentGroupID = '001' then a.Discount else 0 end) as DiscCON,
	sum(case when d.DepartmentGroupID = '002' or d.departmentgroupid is null then a.Discount else 0 end) as DiscMCT,
	sum(case when d.DepartmentGroupID = '003' then a.Discount else 0 end) as DiscXRY,
	sum(case when d.DepartmentGroupID = '004' then a.Discount else 0 end) as DiscLAB,
	sum(case when d.DepartmentGroupID = '005' then a.Discount else 0 end) as DiscDNT,
	sum(case when d.DepartmentGroupID = '006' then a.Discount else 0 end) as DiscOPH,
	sum(case when d.DepartmentGroupID = '007' then a.Discount else 0 end) as DiscCMD,
	sum(case when d.DepartmentGroupID = '008' then a.Discount else 0 end) as DiscPHR,
	sum(case when a.TrType = 'Clinic' then a.Deductible else 0 end) as CLNdedAmt,
	sum(case when a.TrType = 'Pharmacy' then a.Deductible else 0 end) as PHRdedAmt,
	a.InsCoCode as InsuranceID,
	a.InsuranceID as InsuranceGroupID,
	a.UnderInsCoCode as UnderInsuranceID,
	a.TrType,
	c.NameEnglish
From InsuranceAlteredData a
left outer join InsuranceServicePriceList b on a.ServiceID = b.ServiceID and a.InsuranceID = b.InsuranceID
left outer join InsuranceDetails c on a.InsCoCode = c.InsuranceID
left outer join MedicalDepartments d on b.departmentid = d.departmentid
where TrType = 'Clinic'

GROUP BY
	a.BranchID,
	a.SeqNo,
	a.RegistrationNo,
	a.PatientNameEnglish,
	a.TransNBR,
	a.TransDAteEnglish,
	a.ClaimType,
	a.InsCoCode,
	a.InsuranceID,
	a.UnderInsCoCode,
	a.TrType,
	c.NameEnglish,
	a.InsCardNo,
	a.Policy
union All
select
	a.BranchID,
	a.SeqNo,
	'CR' as BillType,
	a.RegistrationNo,
	a.PatientNameEnglish,
	a.TransNBR,
	a.TransDAteEnglish,
	a.ClaimType,
	a.InsCardNo,
	a.Policy,
	sum(case when d.DepartmentGroupID = '001' then a.Qty * a.Amount else 0 end) as GrossCON,
	sum(case when d.DepartmentGroupID = '002' or d.departmentgroupid is null then a.Qty * a.Amount else 0 end) as GrossMCT,
	sum(case when d.DepartmentGroupID = '003' then a.Qty * a.Amount else 0 end) as GrossXRY,
	sum(case when d.DepartmentGroupID = '004' then a.Qty * a.Amount else 0 end) as GrossLAB,
	sum(case when d.DepartmentGroupID = '005' then a.Qty * a.Amount else 0 end) as GrossDNT,
	sum(case when d.DepartmentGroupID = '006' then a.Qty * a.Amount else 0 end) as GrossOPH,
	sum(case when d.DepartmentGroupID = '007' then a.Qty * a.Amount else 0 end) as GrossCMD,
	sum(case when d.DepartmentGroupID = '008' then a.Qty * a.Amount else 0 end) as GrossPHR,
	sum(case when d.DepartmentGroupID = '001' then a.Discount else 0 end) as DiscCON,
	sum(case when d.DepartmentGroupID = '002' or d.departmentgroupid is null then a.Discount else 0 end) as DiscMCT,
	sum(case when d.DepartmentGroupID = '003' then a.Discount else 0 end) as DiscXRY,
	sum(case when d.DepartmentGroupID = '004' then a.Discount else 0 end) as DiscLAB,
	sum(case when d.DepartmentGroupID = '005' then a.Discount else 0 end) as DiscDNT,
	sum(case when d.DepartmentGroupID = '006' then a.Discount else 0 end) as DiscOPH,
	sum(case when d.DepartmentGroupID = '007' then a.Discount else 0 end) as DiscCMD,
	sum(case when d.DepartmentGroupID = '008' then a.Discount else 0 end) as DiscPHR,
	sum(case when d.DepartmentGroupID <> '008' then a.Deductible else 0 end) as CLNdedAmt,
	sum(case when d.DepartmentGroupID = '008' then a.Deductible else 0 end) as PHRdedAmt,
	a.InsCoCode as InsuranceID,
	a.InsuranceID as InsuranceGroupID,
	a.UnderInsCoCode as UnderInsuranceID,
	a.TrType,
	c.NameEnglish
From InsuranceAlteredData a
left outer join InsuranceDetails c on a.InsCoCode = c.InsuranceID 
left outer join MedicalDepartments d on  d.departmentgroupid='008' and (d.departmentid = 'PHR' or DepartmentID = '99')
where TrType = 'Pharmacy'
Group By
	a.BranchID,
	a.SeqNo,
	a.RegistrationNo,
	a.PatientNameEnglish,
	a.TransNBR,
	a.TransDAteEnglish,
	a.ClaimType,
	a.InsCoCode,
	a.InsuranceID,
	a.UnderInsCoCode,
	a.TrType,
	c.NameEnglish,
	a.InsCardNo,
	a.Policy