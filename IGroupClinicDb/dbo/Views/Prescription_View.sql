




CREATE VIEW [dbo].[Prescription_View]
AS
SELECT  a.Trans_Key as TransKey, a.TransNBR, a.TransDateEnglish as TransDate, a.PatientType, Iif(a.Series='CA','Cash','Credit') as 'Series', 
        a.RegistrationNo as FileNo, a.DoctorID, b.PatientNameEnglish as PatientName, b.DOB, b.Age, 
		Case when b.AgeYMD = 'Y' then 'year(s)' when b.AgeYMD='M' THEN 'month(s)' when b.AgeYMD = 'D' then 'day(s)' else '' End as 'AgeYmd', 
		Case when b.Sex = 'M' then 'Male' when b.Sex = 'F' then 'Female' Else 'Unknown' End as Gender, 
        c.EmpNameEnglish as DoctorName, a.DoctorID as DoctorCode
FROM    dbo.PMRMedicineGroup a
		INNER JOIN dbo.PatientDetails b
		ON a.RegistrationNo = b.RegistrationNo AND a.Series = b.Series 
		INNER JOIN dbo.EmployeeDetails c
		ON a.DoctorID = c.EmpID
GO



GO


