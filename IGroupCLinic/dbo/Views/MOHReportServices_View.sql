


CREATE VIEW [dbo].[MOHReportServices_View]
  AS
  (SELECT 
  CAST(A.RegistrationNo AS VARCHAR) +  A.RegistrationType as 'FileNoNType',
  A.REGISTRATIONTYPE, 
  B.Sex,
  a.doctorid,
  a.ItemCode,
  IIF(B.CountryIOTA like 'SAU','SAUDI','NON-SAUDI') AS 'Nationality',
  b.Create_Date,
  invSource,
  InvoiceType as 'TransType',
  saleType,
  iif(InvoiceType='Cash','CA','CR') as 'BillType',
  Group_Key,
  transdateenglish,
  transnbr,
  rejected,
  c.DepartmentID
  FROM [iGroupClinic].[dbo].[AllInvoicesDetails_View] as A
  LEFT JOIN   PatientDetails AS B 
  ON A.RegistrationNo = B.RegistrationNo AND A.RegistrationType = B.PatientType
  left join MedicalServices as c
  on a.ItemCode = c.ServiceID
  where a.Rejected = 0 and not invSource='Pharmacy' )