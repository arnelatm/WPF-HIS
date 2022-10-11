
CREATE VIEW DailyCollectionDentalDepartment_View
 
AS
SELECT
	b.*
From DentalDoctors a
LEFT OUTER JOIN DailyCollectionDepartmentWiseClinic_View b ON a.DoctorID = b.DoctorID