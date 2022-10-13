



























CREATE VIEW [dbo].[ClinicHInvoices_View]
  AS
(SELECT 'Clinic'									  as 'InvSource'
	  ,Trans_Key as Trans_Key
      ,a.TransType
	  ,'Sales'										  as 'SaleType'
	  ,a.BranchID
	  ,a.DoctorID										 
	  ,a.TransNbr
	  ,a.TransDateEnglish
	  ,a.TransDateHijri
	  ,a.NormalDiscountAmt						  
	  ,a.ExtraDiscountAmt
	  ,a.ExtraDiscountPercent
	  ,a.RoundOffAmt						          
	  ,isnull(a.VATAmt,0)						      as 'InvVatAmt'
	  ,isnull(a.VATExemption,0)					      as 'VatExemption'
	  ,a.BillAmt						              as 'BillAmt'
	  ,a.Reject                                    
	  ,a.InsuranceID
	  ,a.TokenNo									  as 'TokenNo'
	  ,a.RegistrationNo
	  ,a.RegistrationType	
	  ,a.RegistrationDate
	  ,a.InsuranceGroupID
	  ,a.BillType 	
	  ,a.DeductibleAmt
	  ,a.Remarks
	  ,a.RejectDate
	  ,a.UserId
	  ,a.MachineID
	  ,a.Create_Date
	  ,a.InsuranceNameEnglish
	  ,c.PatientNameEnglish
	  ,c.PatientNameArabic	
	  ,c.Age				
	  ,c.AgeYMD			
	  ,c.Sex			
	  ,c.CountryIOTA	
	  ,c.IqamaNo			
	  ,c.Mobile		
	  ,e.EmpNameEnglish	
	  ,e.OPDFloor
	  ,e.OPDNo
	  ,'' as 'SponsorID'
	  ,'0' as 'IBType'
  FROM dbo.ClinicInvoiceGroup as a
  left outer join PatientDetails c 
  on a.RegistrationNo=c.RegistrationNo and upper(a.RegistrationType)=upper(c.PatientType) and a.BranchID=c.BranchID
  left outer join EmployeeDetails e 
  on a.DoctorID=e.EmpID 
  )