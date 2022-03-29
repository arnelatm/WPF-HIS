
CREATE VIEW DentalClinicInvoice_View
 
AS
SELECT
	b.*
From DentalDoctors a
LEFT OUTER JOIN ClinicInvoice_view b ON a.DoctorID = b.DoctorID
