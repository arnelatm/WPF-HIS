
CREATE VIEW [dbo].[PharmacyDosageDetails_View] as 
 SELECT a.branchID
      ,a.Trans_key
	  ,a.RowNBR
      ,a.PatientNameEnglish
      ,a.item_code
      ,CONVERT(VARCHAR(10), a.expiry, 111) as 'expiry'
      ,a.dosageID
      ,a.create_date
      ,a.userid
      ,a.machineid
	  ,b.ItemNameEnglish as 'Item_Name'
      ,e.ItemNameEnglish as 'Data_E'
      ,e.ItemNameArabic as 'data_a'
      ,a.userid as 'users'
	  ,b.ItemNameArabic
	  ,d.Sex
	  ,d.Age
	  ,d.RegistrationDate
	  ,d.DOB
	  ,c.RegistrationNo
	  ,c.DoctorID
	  ,f.EmpNameEnglish as 'DoctorNameE'
	  ,f.EmpNameArabic as 'DoctorNameA'
  FROM [iGroupClinic].[dbo].[PharmacyDosageDetails] as a
  left join itemdetails b
  on a.branchID = b.BranchID and a.item_code = b.Item_Code
  left join pharmacyinvoicegroup as c
  on a.trans_key = c.Trans_Key
  left join PatientDetails as d
  on c.RegistrationNo = d.RegistrationNo and c.TransType = d.Series
  left join MedicineDosageMaster as e
  on a.dosageID = e.ItemID 
  left join employeedetails f
  on c.DoctorID = f.EmpID