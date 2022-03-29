CREATE view 	PMRAntenatal_View --EMR_Patient_Antenatal_View
 
as 
select 		a.*				,
			b.TransDateEnglish as tdt	,
			b.RowNBR			,
			b.PregnancyWeeks	,
			b.fundalheight	,
			b.presposition	,
			b.engaged,
			b.fm_fhs		,
			b.hb			,
			b.sugar			,
			b.albumin		,
			b.bp			,
			b.ptientweight		,
			b.oedema		,
			b.nextvisit	,
			b.usgkey		,
			b.remarks		,
			c.PatientNameEnglish,
			c.Age,
			c.AgeYMD,
			c.Sex,
			c.CountryIOTA,
			d.countryNameEng,
			e.EmpNameEnglish,
			f.NameEnglish as InsuranceName
from		PMRAntenatalGroup		A
left outer join	PMRAntenatalDetails	B ON a.registrationNo =b.RegistrationNo and a.series=b.series  and a.Trans_Key = b.Group_Key
left outer join	PatientDetails			 		C ON a.registrationno=c.registrationno and a.series=c.series
left outer join	CountryMaster			 		D ON c.CountryIOTA=d.CountryIOTA
left outer join	EmployeeDetails			 		E ON a.DoctorID=e.empID
left outer join	InsuranceDetails		 		F ON c.InsCoCode=f.InsuranceID
