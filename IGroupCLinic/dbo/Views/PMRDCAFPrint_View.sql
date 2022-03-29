CREATE view 	PMRDCAFPrint_View
 
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
			b.itemnameenglish,
			b.itemnamearabic,
			c.PatientNameEnglish,
			c.age,
			c.sex,
			c.ageymd,
			c.iqamano,
			d.EmpNameEnglish,
			e.countrynameeng 			
from 		PMRPatientGeneralInfo 		a	
left outer join PMRInvestigationDetail_View 	b on a.trans_key=b.trans_key  
left outer join PatientDetails			c on a.registrationno=c.registrationno and a.series=c.series 
left outer join EmployeeDetails			d on a.doctorid =d.empid
left outer join CountryMaster	 		e on c.countryiota  =e.countryiota 
where a.transtype='DCAF'
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
			b.itemnameenglish,
			b.itemnamearabic,
			c.PatientNameEnglish,
			c.age,
			c.sex,
			c.ageymd,
			c.iqamano,
			d.EmpNameEnglish,
			e.countrynameeng 			
from 		PMRPatientGeneralInfo 		a	
left outer join PMRTreatmentDetail_View 	b on a.trans_key=b.trans_key  
left outer join PatientDetails			c on a.registrationno=c.registrationno and a.series=c.series 
left outer join EmployeeDetails			d on a.doctorid =d.empid
left outer join CountryMaster	 		e on c.countryiota  =e.countryiota 
where a.transtype='DCAF'
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
		b.itemnameenglish,
		b.itemnamearabic,
		c.PatientNameEnglish,
		c.age,
		c.sex,
		c.ageymd,
		c.iqamano,
		d.empnameenglish,
		e.countrynameeng 			
from 		PMRPatientGeneralInfo 			a	
left outer join PMRMedicineDetails_View			b on a.trans_key=b.trans_key 
left outer join PatientDetails				c on a.registrationno=c.registrationno and a.series=c.series 
left outer join EmployeeDetails				d on a.doctorid =d.empID
left outer join CountryMaster	 			e on c.countryiota  =e.countryiota 
where a.transtype='DCAF'
union all
select 		a.*,
		b.rownbr,
		'Tooth # '+b.ToothNBR as item_code,
		1 as qty,
		'' as unit,
		0 as saleprice,
		0 as discountper,
		0 as discountamt,
		0 as billamt,
		'Surface :'+b.ToothSurface  as itemNameEnglish,
		'' as ItemNameArabic,
		c.patientnameenglish,
		c.age,
		c.sex,
		c.ageymd,
		c.iqamano,
		d.empnameenglish,
		e.countrynameeng 			
from 		PMRPatientGeneralInfo 		a	
left outer join PMRDentalTeethDescription 	b on a.trans_key=b.trans_key 
left outer join PatientDetails			c on a.registrationno=c.registrationno and a.series=c.series 
left outer join EmployeeDetails			d on a.doctorid =d.empID
left outer join CountryMaster	 		e on c.countryiota  =e.countryiota 
where a.transtype='DCAF'
