


CREATE VIEW [dbo].[MOHReportIB2_View] as 
SELECT CAST(A.RegistrationNo AS VARCHAR) AS 'FileNoNType',
       a.IBType, a.Sex,a.TransDateEnglish, a.Rejected,a.Create_Date, a.border_iqama,IIF(B.CountryIOTA LIKE 'SAU','SAUDI','NON-SAUDI') AS 'Nationality',
	   c.ServiceID, a.Age, d.ServiceNameEnglish
FROM IBInvoiceGroup AS A 
LEFT OUTER JOIN PatientDetails AS B ON A.RegistrationNo = B.RegistrationNo 
LEFT OUTER JOIN IBInvoiceDetails as C on a.Trans_Key = c.Group_key
LEFT OUTER JOIN MedicalServices as d on c.serviceid = d.ServiceID