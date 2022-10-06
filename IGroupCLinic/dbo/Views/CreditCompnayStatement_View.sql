

cREATE vIEW [dbo].[CreditCompnayStatement_View]
as 
(Select branchid
      ,trans_key
      ,Series
      ,RegistrationDate
      ,RegistrationType
      ,TransType
      ,TransNBR
      ,BillType
      ,RegistrationNo
      ,TransDateEnglish
      ,TransDateHijri
      ,DoctorID
      ,InsuranceID
      ,InsuranceGroupID
      ,InsuranceNameEnglish
      ,NormalDiscountAmt
      ,PreviousBalanceAmt
      ,DeductibleAmt
      ,DeductibleDiscountAmt
      ,ExtraDiscountPercent
      ,ExtraDiscountAmt
      ,RoundOffAmt
      ,BillAmt
      ,Remarks
      ,InsSoapNo
      ,InsSoapCode
      ,InsCardNo
      ,Reject
      ,RejectDate
      ,UserID
      ,MachineID
      ,CreditCardID
      ,CreditCardNo
      ,CreditCardExpiry
      ,Create_Date
      ,RowNbr
      ,SaleType
      ,ServiceID
      ,DepartmentID
      ,qty
      ,SalePrice
      ,CostPrice
      ,DiscountPer
      ,DiscountAmt
      ,deductiblePer
      ,VATAmt
	  ,VATExemption
      ,SaleStatus
      ,CostPrice as costpriceperunit
      ,PatientNameEnglish
      ,age
      ,AgeYMD
      ,Sex
      ,countryIOTA
      ,ServiceNameEnglish
      ,EmpNameEnglish
      ,CountryNameEng
      ,IqamaNo
      ,mobile
      ,phoneO
      ,PhoneR
      ,Address1
      ,Address2
      ,city
      ,groupName
      ,groupInsuranceID
      ,activeinsName
      ,UnderInsuranceID
      ,Co_Ins_Company
      ,DepartmentNameEnglish
      ,TokenNo
      ,OPDFloor
      ,OPDNo
      ,InsServiceID
      ,InsServiceNameEnglish
      ,PrintDept
  FROM ClinicInvoice_View where reject <> 1)
UNION ALL
(  SELECT branchid
      ,trans_key
      ,'CR' as Series
      ,RegistrationDate
      ,RegistrationType
      ,TransType
      ,TransNBR
      ,BillType
      ,RegistrationNo
      ,TransDateEnglish
      ,'' as TransDateHijri
      ,DoctorID
      ,InsuranceID
      ,InsuranceGroupID
      ,InsuranceNameEnglish
      ,NormalDiscountAmt * iif(BillType='SALE RETURN',-1,1) 
      ,0 as PreviousBalanceAmt
      ,DeductibleAmt * iif(BillType='SALE RETURN',-1,1) 
      ,DeductibleDiscountAmt * iif(BillType='SALE RETURN',-1,1) 
      ,ExtraDiscountPercent 
      ,ExtraDiscountAmt * iif(BillType='SALE RETURN',-1,1) 
      ,RoundOffAmt * iif(BillType='SALE RETURN',-1,1) 
      ,BillAmt * iif(BillType='SALE RETURN',-1,1) 
      ,Remarks
      ,'' as InsSoapNo
      ,'' as InsSoapCode
      ,'' as InsCardNo
      ,0 as Reject
      ,'' as RejectDate
      ,UserID
      ,MachineID
      ,CreditCardID
      ,'' as CreditCardNo
      ,'' as CreditCardExpiry
      ,Create_Date
      ,RowNbr
      ,BillType as SaleType
      ,Item_Code as ServiceID
      ,'PHR' as DepartmentID
      ,qty * iif(BillType='SALE RETURN',-1,1) 
      ,SalePrice 
      ,CostPrice 
      ,DiscountPer 
      ,DiscountAmt * iif(BillType='SALE RETURN',-1,1) 
      ,ItemDeductiblePer as deductiblePer
      ,VATAmt * iif(BillType='SALE RETURN',-1,1) 
	  ,0 as VATExemption
      ,SaleStatus
      ,CostPrice as costpriceperunit
      ,PatientNameEnglish
      ,age
      ,AgeYMD
      ,Sex
      ,countryIOTA
      ,ItemNameEnglish as ServiceNameEnglish
      ,DoctorNameENglish as EmpNameEnglish
      ,CountryNameEng
      ,IqamaNo
      ,'' as mobile
      ,'' as phoneO
      ,'' as PhoneR
      ,'' as Address1
      ,'' as Address2
      ,'' as city
      ,InsuranceGroupNameEnglish as groupName
      ,InsuranceGroupID as groupInsuranceID
      ,InsuranceNameEnglish as activeinsName
      ,InsuranceID as UnderInsuranceID
      ,InsuranceID as Co_Ins_Company
      ,'Pharmacy' as DepartmentNameEnglish
      ,0 as TokenNo
      ,'' as OPDFloor
      ,'' as OPDNo
      ,'' as insServiceID
      ,'' as InsServiceNameEnglish
      ,'N' PrintDept
  FROM iGroupClinic.dbo.PharmacySales_View)