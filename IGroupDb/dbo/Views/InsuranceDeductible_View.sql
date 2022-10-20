
CREATE view 	InsuranceDeductible_View
 
as
select 		a.BranchID			,
		a.transdateenglish		,
		a.transnbr			,
		a.referenceno			,
		a.registrationno		,
		b.patientnameenglish		,
		b.inscardno			,
		a.InsuranceID			,
		a.InsuranceNameEnglish		,
		a.billamt			,
		a.DeductibleAmt			,
		a.deductiblediscountamt, 
		a.billamt as netamt,
		a.doctorid,
		d.EmpNameEnglish as doctor,
		a.DeductibleInvoiceNbr
from 		ClinicInvoiceGroup a
		left outer join patientdetails b on a.registrationno=b.registrationno and a.registrationtype=b.patienttype and a.branchid=b.branchid
		left outer join EmployeeDetails		d on a.doctorid=d.empid
where 		a.DeductibleAmt <> 0 
		and a.billtype='CR'
		and a.RegistrationType='Insurance'
		and (a.reject is null or a.Reject = '0')