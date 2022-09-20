CREATE VIEW dbo.DoctorsPatientPMREntries_View
  AS (Select  
a.TransDateEnglish,
a.doctorid,
a.RegistrationNo,
b.transtype,
c.empNameEnglish
from doctorsPatients_view a
left join [PMRGeneralProfile_View] b
on a.transdateenglish = b.TransDateEnglish and a.doctorid = b.doctorid and a.registrationno = b.RegistrationNo and a.registrationtype = b.PatientType
left join EmployeeDetails c
on a.doctorid = c.empid
group by a.TransDateEnglish,a.doctorid,a.RegistrationNo,b.transtype,c.empNameEnglish
)