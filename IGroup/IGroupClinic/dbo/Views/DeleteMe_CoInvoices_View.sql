















CREATE VIEW [dbo].[DeleteMe_CoInvoices_View]
  AS
(SELECT 'Clinic'									  as 'InvSource'
      ,[Group_Key]									  as 'Trans_Key'
      ,[InvoiceType]								  as 'TransType'
	  ,'Sales'										  as 'SaleType'
      ,CID.[BranchID]								  as 'BranchID'
	  ,DepartmentID									  as 'DepartmentID'
	  ,DoctorID										  as 'DoctorID'
	  ,RowNbr										  as 'RowNbr'
	  ,ServiceID									  as 'ServiceID'
      ,qty*salePrice                                  as 'ItemGrossTotal'
	  ,Round(iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100),2) as 'ItemDiscountAmt'
      ,isnull([VATPercent],0)                         as 'ItemVATPercent'
      ,isnull(CID.[VATAmt],0)						  as 'ItemVATAmt'
	  ,CIG.TransNbr
	  ,CIG.TransDateEnglish
	  ,cig.TransDateHijri
	  ,CIG.NormalDiscountAmt						  
	  ,CIG.ExtraDiscountAmt
	  ,cig.ExtraDiscountPercent
	  ,CIG.RoundOffAmt						          
	  ,isnull(CIG.VATAmt,0)						      as 'VatAmt'
	  ,isnull(CIG.VATExemption,0)					  as 'VatExemption'
	  ,CIG.BillAmt						              as 'BillAmt'
	  ,cig.Reject                                    
	  ,(SELECT Round(sum(qty*saleprice),2) 
	    from [ClinicInvoiceDetails] as b
		where b.Group_key = cig.Trans_key)			  as 'InvGrossTotal'
	  ,Cig.InsuranceID							      as 'InsuranceID'
	  ,cig.TokenNo									  as 'TokenNo'
	  ,cig.RegistrationNo
	  ,cig.RegistrationType	
	  ,cig.RegistrationDate
	  ,cig.InsuranceGroupID
	  ,cig.BillType 	as 'BillType'
	  ,cig.DeductibleAmt
	  ,cig.Remarks
	  ,cig.RejectDate
	  ,cig.UserId
	  ,cig.MachineID
	  ,cig.Create_Date
	  ,cig.InsuranceNameEnglish
	  ,c.PatientNameEnglish
	  ,c.PatientNameArabic	
	  ,c.Age				
	  ,c.AgeYMD			
	  ,c.Sex			
	  ,c.CountryIOTA	
	  ,c.IqamaNo			
	  ,c.Mobile		
  FROM [iGroupClinic].[dbo].[ClinicInvoiceDetails] as CID
  inner join dbo.ClinicInvoiceGroup as CIG
  on CID.Group_Key = CIG.Trans_Key
  left outer join PatientDetails c 
  on cig.RegistrationNo=c.RegistrationNo and upper(cig.RegistrationType)=upper(c.PatientType) and cig.BranchID=c.BranchID)

UNION

(SELECT 'Diagnosis Center'  
      ,[Group_Key]
	  ,[TransType]  
	  ,'Sales' 
	  ,ibg.BranchID
	  ,'301'
	  ,'999'
	  ,slno
	  ,ServiceID									  
      ,[Qty]*[Price]   
      ,Round(iif([DiscAmt]<>0,DiscAmt,Price*DiscPer/100),2)
      ,isnull([VATPercent],0)
      ,isnull(IBD.[VATAmt],0)
	  ,ibg.TransNbr
	  ,ibg.TransDateEnglish
	  ,ibg.TransDateHijri
	  ,ibg.DiscountAmt
	  ,ibg.ExtraDiscountAmt
	  ,ibg.ExtraDiscountPer
	  ,0  
	  ,isnull(ibg.VATAmt,0)
	  ,isnull(ibg.VATExemption,0)
	  ,ibg.NetAmt
	  ,ibg.Rejected 
	  ,(SELECT Round(sum(qty*[Price]),2) 
	    from [IBInvoiceDetails] as c
		where c.group_Key=ibg.trans_key )
	  ,ibg.CompanyID
	  ,ibg.TokenNo
	  ,ibg.RegistrationNo
	  ,ibg.TransType
	  ,'Out Patient'
	  ,ibg.CompanyID
	  ,ibg.TransType 	
	  ,0
	  ,ibg.Remarks
	  ,ibg.RejectedDate
	  ,ibg.UserId
	  ,ibg.MachineID
	  ,ibg.Create_Date
	  ,ins.NameEnglish
	  ,ibg.PatientName
	  ,ibg.PatientName
	  ,ibg.Age				
	  ,ibg.AgeYMD			
	  ,ibg.Sex			
	  ,ibg.CountryIOTA	
	  ,ibg.Border_Iqama
	  ,ibg.Phone
  FROM [iGroupClinic].[dbo].[IBInvoiceDetails] as ibd
  inner join dbo.IBInvoiceGroup as ibg
  on ibd.Group_Key = ibg.Trans_Key
  Left join dbo.InsuranceDetails as ins
  on ibg.CompanyID = ins.InsuranceID
  )