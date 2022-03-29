CREATE view 	PMRUCAFPrint_View --EMR_UCAF_Print_View
 
as 
select 		a.*,
			b.rownbr,
			b.item_code,
			b.qty,
			b.unit,
			b.saleprice,
			b.discountper,
			b.discountamt,
			b.billamt,
			b.itemnameenglish as item_name_e,
			b.itemnamearabic as item_name_a,
			PatientNameEnglish as patient ,
			c.age,
			c.sex,
			c.ageYMD,
			c.iqamano,
			d.empNameEnglish,
			e.countrynameeng,
			D.DeptID as DepartmentID 			
from 		PMRPatientGeneralInfo 			a	
left outer join PMRInvestigationDetail_View 	b on a.trans_key=b.trans_key 
left outer join PatientDetails				c on a.registrationno=c.registrationno and a.series=c.series 
left outer join EmployeeDetails				d on a.doctorid =d.empid
left outer join CountryMaster	 			e on c.countryiota  =e.countryiota 
union all
select 		a.*,
			b.rownbr,
			b.item_code,
			b.qty,
			b.unit,
			b.saleprice,
			b.discountper,
			b.discountamt,
			b.billamt,
			b.itemnameenglish as item_name_e,
			b.itemnamearabic as item_name_a,
			PatientNameEnglish as patient ,
			c.age,
			c.sex,
			c.ageymd,
			c.iqamano,
			d.empnameenglish,
			e.countrynameeng,
			d.DeptID as DepartmentID 			
from 		PMRPatientGeneralInfo 			a	
left outer join PMRMedicineDetails_View 		b on a.Trans_key=b.Trans_key 
left outer join PatientDetails				c on a.registrationno=c.registrationno and a.series=c.series 
left outer join EmployeeDetails				d on a.doctorid =d.empID
left outer join CountryMaster 				e on c.CountryIOTA  =e.CountryIOTA 
