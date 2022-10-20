
create view 	[dbo].[Diagnosis_Report_View1]
as
select 	
		a.BranchID,
 		a.trans_key,
		a.transno,
		a.transdate,
		a.sampleno,
		a.invoicetype,
		a.invoiceno,
		a.invoicedate,
		a.patienttype,
		a.registrationno,
		a.patientnameenglish,
		a.age,
		a.ageymd,
		a.sex,
		a.insuranceid,
		a.doctorid,
		a.remarks,
		a.investigationid, 
		a.userid,
		a.Status,
		b.slno,
		b.investigationname1 as observation,
		b.investigationname2 as observation2,
		c.result1,
		c.result2,
		c.suffix1,
		c.suffix2,
		c.cfactor,
		c.printstatus,
		c.s1,
		c.s2,
		c.s3,
		c.s4,
		d.empnameenglish,
		d.deptID,
		e.nameenglish as company,
		e.GroupInsuranceID as TPA,
		f.investigationname ,
		f.reportheader,
		f.subheader,
		f.column1,
		f.column2,
		f.column3,
		f.columnpage1,
		f.columnpage2,
		f.columnpage3,
		f.footer1,
		f.footer2,
		f.reportid,
		f.inputid,
		g.Mobile,
		g.IqamaNo,
		h.CCNameEnglish as DepartmentName 
from lab_invoicegroup a
left outer join lab_diagnosisitemdetails b on a.investigationid = b.investigationid
left outer join lab_invoicedetails c on a.trans_key = c.group_key and c.investigationid=b.investigationid and c.slno = b.slno
left outer join employeedetails 		d on a.doctorid=d.empid
left outer join InsuranceDetails 		e on a.insuranceid=e.insuranceid
left outer join Lab_DiagnosisMasterDetails 		f on a.investigationid=f.investigationid
left outer join PatientDetails g on a.PatientType = g.PatientType and a.RegistrationNo = g.RegistrationNo 
left outer join CostCentre h on d.DeptID = h.AccountID 
where not b.columnnos is null