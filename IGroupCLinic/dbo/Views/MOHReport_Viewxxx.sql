CREATE VIEW dbo.[MOHReport_Viewxxx]
  AS
  (SELECT 
  DISTINCT(CAST(A.RegistrationNo AS VARCHAR) +  A.RegistrationType) as 'FileNoNType',
  A.REGISTRATIONTYPE, 
  B.Sex,
  IIF(B.CountryIOTA like 'SAU','SAUDI','NON-SAUDI') AS 'Nationality',
  Create_Date,
  invSource,
  InvoiceType as 'TransType',
  saleType,
  iif(InvoiceType='Cash','CA','CR') as 'BillType',
  Group_Key,
  transdateenglish,
  transnbr
  FROM [iGroupClinic].[dbo].[AllInvoicesDetails_View] as A
  LEFT JOIN   PatientDetails AS B 
  ON A.RegistrationNo = B.RegistrationNo AND A.RegistrationType = B.PatientType
  where a.Rejected = 0 and not invSource='Pharmacy')

