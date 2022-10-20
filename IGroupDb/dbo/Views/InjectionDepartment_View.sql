
CREATE VIEW InjectionDepartment_View
 
AS
select 
a.*,
c.ServiceID as UsedService,
c.UserID as StaffID,
c.Create_Date as SavedDate,
c.UsedQty as Dosage,
d.EmpNameEnglish as StaffNameEnglish,
e.ServiceNameEnglish as UsedServiceName
from ClinicInvoice1_View a
left outer join INJVaccineUsage c on a.TransNBR = c.TransNbr and a.TransType = c.TransType 
and a.RegistrationNo = c.RegistrationNo and a.RegistrationType = c.PatientType 
and a.ServiceID = c.IServiceID 
left outer join ClinicNursingStaff d on c.UserID = d.EmpID 
left outer join MedicalServices e on c.ServiceID = e.ServiceID