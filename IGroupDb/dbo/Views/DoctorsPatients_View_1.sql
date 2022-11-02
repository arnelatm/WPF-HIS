CREATE VIEW dbo.DoctorsPatients_View
  AS (SELECT [TransDateEnglish]
      ,RegistrationType
      ,[RegistrationNo]
	  ,DoctorID
  FROM [iGroupClinic].[dbo].[ClinicInvoiceGroup] a
  inner join ClinicInvoiceDetails b
  on a.Trans_Key = b.Group_Key 
  inner join MedicalServices c
  on b.ServiceID = c.ServiceID 
  where c.DepartmentID='CON' and reject = 0 and (RegistrationType='Cash' or RegistrationType='Credit'  or RegistrationType='Staff' or RegistrationType = 'Cash/Company' )
  group by transdateenglish,registrationtype,registrationno,doctorid)