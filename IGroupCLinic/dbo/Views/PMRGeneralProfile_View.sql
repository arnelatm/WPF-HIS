CREATE view 	PMRGeneralProfile_View --EMR_Patient_General_Profile_View
 
as 
select 			a.*,
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
			'' as days,
			'' as dosageenglish ,
			'' as dosageArabic,
			b.DepartmentID,
			c.PatientNameEnglish,
			c.age,
			c.sex,
			c.ageymd,
			c.iqamano,
			d.empnameenglish,
			e.countrynameeng,
			f.nameenglish as Company,
			g.icd_description as icd1_description,
			h.icd_description as icd2_description,
			i.icd_description as icd3_description,
			'' as NoofDays,
			k.DepartmentNameEnglish,
--			'Date' as HistoryType,
			'02' as BranchID,
			l.Analysis1,
			l.Analysis2,
			l.History,
			l.OnExamination,
			'1.Investigation' as ItemType
from 		PMRPatientGeneralInfo 		a	
left outer join PMRInvestigationDetail_View 	b on a.trans_key=b.trans_key 
left outer join PatientDetails			c on a.registrationno=c.registrationno and a.series=c.series 
left outer join EmployeeDetails			d on a.doctorid =d.empid
left outer join CountryMaster	 		e on c.CountryIOTA  =e.countryIOTA 
left outer join InsuranceDetails  		f on a.InsuranceID=f.InsuranceID
left outer join ICD10_Master   			g on a.dx_code1 =g.icd_code 
left outer join ICD10_Master   			h on a.dx_code2  =h.icd_code 
left outer join ICD10_Master   			i on a.dx_code3  =i.icd_code 
Left outer join MedicalDepartments		k on b.DepartmentID = k.DepartmentID
left outer join PMRDentalAnalysis		l on a.Trans_Key = l.Trans_Key
union all
select 			a.*,
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
			'' as days,
			'' as dosageenglish ,
			'' as dosageArabic,
			b.DepartmentID,
			c.PatientNameEnglish,
			c.age,
			c.sex,
			c.ageymd,
			c.iqamano,
			d.empnameenglish,
			e.countrynameeng,
			f.nameenglish as Company,
			g.icd_description as icd1_description,
			h.icd_description as icd2_description,
			i.icd_description as icd3_description,
			'' as NoofDays,
			k.DepartmentNameEnglish,
--			'Date' as HistoryType,
			'02' as BranchID,
			l.Analysis1,
			l.Analysis2,
			l.History,
			l.OnExamination,
			'2.Treatment' as ItemType
from 		PMRPatientGeneralInfo 		a	
left outer join PMRTreatmentDetail_View 	b on a.trans_key=b.trans_key 
left outer join PatientDetails			c on a.registrationno=c.registrationno and a.series=c.series 
left outer join EmployeeDetails			d on a.doctorid =d.empid
left outer join CountryMaster	 		e on c.CountryIOTA  =e.countryIOTA 
left outer join InsuranceDetails  		f on a.InsuranceID=f.InsuranceID
left outer join ICD10_Master   			g on a.dx_code1 =g.icd_code 
left outer join ICD10_Master   			h on a.dx_code2  =h.icd_code 
left outer join ICD10_Master   			i on a.dx_code3  =i.icd_code 
Left outer join MedicalDepartments		k on b.DepartmentID = k.DepartmentID
left outer join PMRDentalAnalysis		l on a.Trans_Key = l.Trans_Key
union all
select 			a.*,
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
			b.days,
			b.dosageEnglish ,
			b.DosageArabic,
			'PHR' as departmentID,
			c.PatientNameEnglish,
			c.age,
			c.sex,
			c.ageymd,
			c.iqamano,
			d.empnameenglish,
			e.countrynameeng,
			f.nameenglish as Compnay,
			g.icd_description as icd1_description,
			h.icd_description as icd2_description,
			i.icd_description as icd3_description,
			j.descriptionenglish as noofdays,
			'Pharmacy' as DepartmentNameEnglish,
--			'Date' as HistoryType,
			'01' as BranchID,
			k.Analysis1,
			k.Analysis2,
			k.History,
			k.OnExamination,
			'3.Pharmacy' as ItemType
from 		PMRPatientGeneralInfo 			a	
left outer join PMRMedicineDetails_View 		b on a.PatientType = b.PatientType AND a.RegistrationNo = b.RegistrationNo AND a.Trans_Key  = b.Trans_Key  --a.trans_key=b.trans_key 
left outer join PatientDetails				c on a.registrationno=c.registrationno and a.series=c.series 
left outer join EmployeeDetails				d on a.doctorid =d.empid
left outer join CountryMaster 				e on c.countryiota  =e.countryiota 
left outer join InsuranceDetails  			f on a.insuranceid=f.insuranceid
left outer join ICD10_Master   				g on a.dx_code1 =g.icd_code 
left outer join ICD10_Master   				h on a.dx_code2  =h.icd_code 
left outer join ICD10_Master   				i on a.dx_code3  =i.icd_code 
left outer join PMRQtyDays	   			j on b.days = j.id
left outer join PMRDentalAnalysis			k on a.Trans_Key = k.Trans_Key
union all
select 			a.*,
			b.rownbr,
			'Tooth # '+b.toothnbr as item_code,
			b.cost as qty,
			b.Treatment as unit,
			0 as saleprice,
			0 as discountper,
			0 as discountamt,
			0 as billamt,
			'Surface :'+b.toothsurface  as itemnameenglish,
			'' as itemnamearabic,
			'' as days,
			b.Remarks as dosageenglish ,
			'' as DosageArabic,
			'DNT' as DepartmentID,
			c.patientnameenglish,
			c.age,
			c.sex,
			c.ageymd,
			c.iqamano,
			d.empnameenglish,
			e.countrynameeng,
			f.nameenglish as cust_name,
			g.icd_description as icd1_description,
			h.icd_description as icd2_description,
			i.icd_description as icd3_description,
			'' as noofdays,
			'Dental' as DepartmentNameEnglish,
--			'Date' as HistoryType,
			'02' as BranchID,
			j.Analysis1,
			j.Analysis2,
			j.History,
			j.OnExamination,
			'4.Teeth' as ItemType
from 		PMRPatientGeneralInfo 			a	
left outer join PMRDentalTeethDescription	 	b on a.trans_key=b.trans_key 
left outer join PatientDetails				c on a.registrationno=c.registrationno and a.series=c.series 
left outer join EmployeeDetails				d on a.doctorid =d.empid
left outer join CountryMaster 				e on c.Countryiota  =e.countryiota 
left outer join InsuranceDetails  			f on a.insuranceid=f.insuranceid
left outer join ICD10_Master   				g on a.dx_code1 =g.icd_code 
left outer join ICD10_Master   				h on a.dx_code2  =h.icd_code 
left outer join ICD10_Master   				i on a.dx_code3  =i.icd_code 
left outer join PMRDentalAnalysis			j on a.Trans_Key = j.Trans_Key
