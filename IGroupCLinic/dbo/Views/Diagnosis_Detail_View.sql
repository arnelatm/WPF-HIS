
CREATE view 	Diagnosis_Detail_View
 
as
select 		a.Group_key,
		a.result1,
		a.result2,
		a.suffix1,
		a.suffix2,
		a.cfactor,
		a.printstatus,
		a.s1,
		a.s2,
		a.s3,
		a.s4,
		b.slno,
		b.investigationname1 as observation,
		b.investigationname2 as observation2
from 		Lab_InvoiceDetails a
left outer join  Lab_DiagnosisItemDetails b on a.investigationID=b.investigationID and a.slno=b.slno
