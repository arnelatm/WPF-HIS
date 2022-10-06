

CREATE VIEW [dbo].[IBHInvoices_View]
  AS
(SELECT 'Diagnosis Center' as 'InvSource'
	  ,a.Trans_Key 
	  ,a.TransType as 'TransType'
	  ,'Sales'  as 'SaleType'
	  ,a.BranchID
	  ,'999' as 'DoctorID'
	  ,a.TransNbr
	  ,a.TransDateEnglish
	  ,a.TransDateHijri
	  ,a.DiscountAmt As 'NormalDiscountAmt'
	  ,a.ExtraDiscountAmt as 'ExtraDiscountAmt'
	  ,a.ExtraDiscountPer as 'ExtraDiscountPercent'
	  ,0  as 'RoundOffAmt'
	  ,isnull(a.VATAmt,0)  as 'InvVatAmt'
	  ,isnull(a.VATExemption,0) as 'VatExemption'
	  ,a.NetAmt  as 'BillAmt'
	  ,a.Rejected as 'Reject'
	  ,a.CompanyID as 'InsuranceID'
	  ,a.TokenNo  as 'TokenNo'
	  ,a.RegistrationNo 
	  ,'Out Patient' as 'RegistrationType'
	  ,CONVERT(varchar, a.create_date , 111) as 'RegistrationDate'
	  ,ins.GroupInsuranceId as 'InsuranceGroupID'
	  ,IIf(a.TransType='Cash','CA','CR') as 'BillType'
	  ,0 as 'DeductibleAmt'
	  ,a.Remarks
	  ,a.RejectedDate as 'RejectDate'
	  ,a.UserId
	  ,a.MachineID
	  ,a.Create_Date
	  ,ins.NameEnglish as 'InsuranceNameEnglish'
	  ,a.PatientName as 'PatientNameEnglish'
	  ,a.PatientName as 'PatientNameArabic'
	  ,a.Age				
	  ,a.AgeYMD			
	  ,a.Sex			
	  ,a.CountryIOTA	
	  ,a.Border_Iqama as 'IqamaNo'
	  ,a.Phone as 'Mobile'
	  ,'NONE' as 'EmpNameEnglish'
	  ,'Ground Floor' as 'OPDFloor'
	  ,'DC Reception' as 'OPDNo'
	  ,a.SponsorID
	  ,a.IBType	  
  FROM dbo.IBInvoiceGroup as a
  Left join dbo.InsuranceDetails as ins
  on a.CompanyID = ins.InsuranceID
  )