
CREATE VIEW [dbo].[LABSampleCollectionServices_ViewOk]
AS
SELECT DISTINCT 
                  p.PatientNameEnglish, p.Age, p.AgeYMD, p.DOB, p.Sex, m.ServiceNameEnglish, l.TakenDate, CONVERT(varchar(8), CONVERT(Time, l.TakenTime)) AS TakenTime, CONVERT(Date, c.TransDateEnglish) AS TransDateEnglish, l.SampleNo, 
                  c.RegistrationNo, l.TakenByName, l.TakenByID, c.TransNbr, e.ShortName AS DrNameShort, p.IqamaNo, i.Status
FROM     dbo.Lab_SampleCollectionGroup AS l RIGHT OUTER JOIN
                  dbo.ClinicInvoiceGroup AS c ON l.TransNo = c.TransNbr RIGHT OUTER JOIN
                  dbo.ClinicInvoiceDetails AS a LEFT OUTER JOIN
                  dbo.MedicalServices AS m ON a.ServiceID = m.ServiceID ON c.Trans_Key = a.Group_Key LEFT OUTER JOIN
                  dbo.PatientDetails AS p ON p.RegistrationNo = c.RegistrationNo LEFT OUTER JOIN
                  dbo.EmployeeDetails AS e ON c.DoctorID = e.EmpID FULL OUTER JOIN
                  dbo.Lab_InvoiceGroup AS i ON c.TransNbr = i.InvoiceNo
WHERE  (m.ServiceGroup = '201')