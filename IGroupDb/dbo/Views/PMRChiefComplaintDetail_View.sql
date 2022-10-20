
CREATE view 	PMRChiefComplaintDetail_View
 
as 
select 		a.*,
		b.ComplaintNameEnglish,
		b.ComplaintNameArabic
from		PMRChiefComplaintSPatient	A
left outer join	PMRChiefComplaints		B ON a.ComplaintID=b.ComplaintID