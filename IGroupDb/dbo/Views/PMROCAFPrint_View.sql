
CREATE view 	PMROCAFPrint_View --EMR_OCAF_Print_View
 
as 
select 		a.*,
			b.PatientNameEnglish ,
			b.age,
			b.sex,
			b.AgeYMD ,
			c.countrynameeng,
			d.EmpNameEnglish,
			e.nameenglish as company
from 		PMROpthalDetails		A
left outer join PatientDetails 			B on a.registrationNo =b.registrationNo and a.series=b.series
left outer join CountryMaster 			C on b.CountryIOTA =c.CountryIOTA 
left outer join EmployeeDetails			D on a.doctorid  =d.empid 
left outer join InsuranceDetails		E on b.inscocode  =e.insuranceid