CREATE VIEW HREmployee2_View 
AS /****** Script for SelectTopNRows command from SSMS  ******/
SELECT a.[BranchID]
	  ,a.[FileNo]
      ,a.[EmpID]
      ,a.[AttendenceID]
      ,a.[EmpNameEnglish]
      ,a.[EmpNameArabic]
      ,a.[NationalID]
	  ,b.[CountryNameEng]
	  ,a.[ReligionID]
	  ,c.[DescriptionEng] as Religion
      ,a.[DepartmentID]
	  ,d.[Department]
      ,a.[DesignationID]
	  ,e.[Description] as Designation
      ,a.[JoinDate]
      ,a.[DutyHrs]
      ,a.[ServiceStatus]
      ,a.[Mobile]
      ,a.[eMail]
      ,a.[PassportNo]
      ,a.[PassportExpiry]
      ,a.[IQAMANo]
      ,a.[IQAMAExpiry]
      ,a.[DrvLicense]
	  ,a.[DrvLicenseExpiry]
	  ,a.[InsuranceNo]
      ,a.[InsuranceExpiry]     
      ,a.[GOSI]
	  ,Case When a.empmarketing=1 then 'Y' else 'N' END as MarketingEmployee
	  ,f.OTApply
  FROM [iGroupClinic].[dbo].[HREmployeeDetails] a
LEFT OUTER JOIN countryMaster b on b.countryIOTA = a.NationalID
LEFT OUTER JOIN Religions c on c.ReligionID = a.ReligionID 
LEFT OUTER JOIN EmployeeDepartment d on d.DeptID = a.DepartmentID 
LEFT OUTER JOIN EmployeeDesignation e on e.DesiD = a.DesignationID 
LEFT OUTER JOIN HREmployeesalaryMaster f on a.EmpID = f.EmpID AND a.BranchID = f.BranchID
