CREATE VIEW [dbo].[ClinicIBPharmaCombinedInvGroup_View]
  AS (SELECT 0 as  'InvType',Trans_Key,IB.BranchID    ,'Out Patient' AS 'RegistrationType',RegistrationNo    ,TransType                          ,PatientName          ,TransNBR,TransDateEnglish    ,DoctorID,CompanyID               ,ins.NameEnglish as InsuranceName,GrossAmt                                              ,DiscountAmt      ,ExtraDiscountAmt,ExtraDiscountPer    ,0 as 'RoundOffAmt',NetAmt ,Rejected as 'Reject',IB.UserID    ,IB.Create_Date    ,IB.MachineID 
              FROM IBInvoiceGroup AS IB
			  left join insuranceDetails as INS
   				on IB.CompanyID=INS.InsuranceID
       UNION
	   (SELECT 1 as 'InvType',Trans_Key,CIG.BranchID,CIG.RegistrationType,CIG.RegistrationNo,iif(TransType='CA','Cash','Credit'),PD.PatientNameEnglish,TRANSNBR,CIG.TransDateEnglish,DoctorID,CIG.InsuranceID,ins.NameEnglish,BillAmt+NormalDiscountAmt+ExtraDiscountAmt-RoundOffAmt,NormalDiscountAmt,ExtraDiscountAmt,ExtraDiscountPercent,RoundOffAmt       ,BillAmt,Reject  ,CIG.UserID,CIG.Create_Date,CIG.MachineID 
              FROM ClinicInvoiceGroup as CIG
          left Join PatientDetails as PD 
          on CIG.RegistrationType=PD.PatientType and CIG.RegistrationNo=PD.RegistrationNo
		  left join insuranceDetails as INS
		  on CIG.InsuranceID=INS.InsuranceID
	    )
	   UNION
	   (SELECT 3 as 'InvType',Trans_Key,PH.BranchID    ,RegistrationType   ,RegistrationNo    ,iif(TransType='CA','Cash','Credit'),'no name',TransNbr,TransDateEnglish    ,DoctorID,PH.InsuranceID,ins.NameEnglish,BillAmt+NormalDiscountAmt+ExtraDiscountAmt-RoundOffAmt,NormalDiscountAmt,ExtraDiscountAmt,ExtraDiscountPercent             ,RoundOffAmt       ,BillAmt,0       ,ph.UserID     ,ph.Create_Date,ph.MachineID 
              FROM PharmacyInvoiceGroup as PH
		  left join insuranceDetails as INS
		  on PH.InsuranceID=INS.InsuranceID	  
			  ) )