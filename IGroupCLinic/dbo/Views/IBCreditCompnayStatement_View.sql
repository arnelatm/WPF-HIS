CREATE VIEW IBCreditCompnayStatement_View
  AS
 SELECT BranchID
      ,Trans_Key
      ,Series
      ,RegistrationType
      ,TransType
      ,TransNBR
      ,BillType
      ,RegistrationNo
      ,TransDateEnglish
      ,DoctorID
      ,InsuranceID
      ,InsuranceNameEnglish
      ,NormalDiscountAmt
      ,PreviousBalanceAmt
      ,ExtraDiscountPercent
      ,ExtraDiscountAmt
      ,RoundOffAmt
      ,BillAmt
      ,Remarks
      ,Reject
      ,RejectDate
      ,UserID
      ,MachineID
      ,Create_date
      ,RowNbr
      ,SaleType
      ,ServiceID
      ,DepartmentID
      ,Qty
      ,SalePrice
      ,DiscountPer
      ,DiscountAmt
      ,VATAmt
      ,VatExemption
      ,SaleStatus
      ,PatientNameEnglish
      ,Age
      ,AgeYMD
      ,Sex
      ,CountryIOTA
      ,ServiceNameEnglish
      ,EmpNameEnglish
      ,CountryNameEng
      ,IqamaNo
      ,Mobile
      ,DepartmentNameEnglish
      ,InsuranceGroupID
  FROM CreditCompnayStatement_View
  where REJECT <> 1
  UNION ALL
  SELECT BranchID
      ,Trans_Key
      ,'IBD' as Series
      ,IBDiagnosisDescription as RegistrationType
      ,TransType
      ,TransNBR
      ,case when transtype='Cash' then 'CA' else 'CR' end as BillType
      ,RegistrationNo
      ,TransDateEnglish
      ,DoctorID
      ,COmpanyID as InsuranceID
      ,CompanyName as InsuranceNameEnglish
      ,DiscountAmt as NormalDiscountAmt
      ,0 as PreviousBalanceAmt
      ,ExtraDiscountPer as ExtraDiscountPercent
      ,ExtraDiscountAmt
      ,0 as RoundOffAmt
      ,NetAmt as BillAmt
      ,Remarks
      ,Rejected as Reject
      ,RejectedDate as RejectDate
      ,UserID
      ,MachineID
      ,Create_date
      ,SlNo as RowNbr
      ,case when Rejected = 1 then 'CLINIC RETURN' else 'CLINIC INVOICE' end as SaleType
      ,ServiceID
      ,DepartmentID
      ,Qty
      ,Price as SalePrice
      ,DiscPer as DiscountPer
      ,DiscAmt as DiscountAmt
      ,VATAmount as VATAmt
      ,VATExemption
      ,case when Rejected = 1 then '' else 'SR' end as SaleStatus
      ,PatientName as PatientNameEnglish
      ,Age
      ,AgeYMD
      ,Sex
      ,CountryIOTA
      ,ServiceNameEnglish
      ,'NONE' as EmpNameEnglish
      ,CountryNameEnglish as CountryNameEng
      ,Border_Iqama as IqamaNo
      ,Phone as Mobile
      ,'IQAMA BALADIYA' as DepartmentNameEnglish
      ,CompanyID as InsuranceGroupID
from IBInvoice_View
where Rejected <> 1