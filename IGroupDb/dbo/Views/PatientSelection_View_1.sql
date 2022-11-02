
CREATE VIEW PatientSelection_View
 
AS
SELECT 
	a.transdateenglish,
	a.registrationno,
	b.empid AS Doct_Code,
	a.MACHINEid,
	a.insuranceid,
	case when c.dx_code1 is null then '' else c.dx_code1 end as dx_code1,
	case when c.dx_code2 is null then '' else c.dx_code2 end as dx_code2,
	case when c.dx_code3 is null then '' else c.dx_code3 end as dx_code3,
	case when c.dx_code4 is null then '' else c.dx_code4 end as dx_code4
FROM insurancealtereddata a
LEFT OUTER JOIN Employeedetails b ON      a.doctorid collate database_default= b.empid collate database_default
LEFT OUTER JOIN PMRPatientGeneralInfo c
     ON a.registrationno = c.registrationno AND upper(c.patienttype) = 'INSURANCE' 
     AND CONVERT(VARCHAR(10),a.transdateENGLISH) = CONVERT(varchar(10),c.transdateENGLISH,111) 
     AND b.empID collate database_default= c.doctORID collate database_default
GROUP BY a.transdateENGLISH,
		 a.regISTRATIONNO,
		 b.empID,
		 a.MACHINEID,
		 a.insuranceid, 
		 c.dx_code1,
		 c.dx_code2,
		 c.dx_code3,
		 c.dx_code4