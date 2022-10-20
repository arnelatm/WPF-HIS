
CREATE VIEW [dbo].[ClinicIBCombinedInvGroupNew_View]
  AS ( SELECT 0 as  'InvType',
			Trans_Key,BranchID,
			'Out Patient' AS 'RegistrationType',
			RegistrationNo,
			TransType,
			PatientName,
			TransNBR,
			TransDateEnglish,
			DoctorID,
			CompanyID,
			GrossAmt,
			DiscountAmt,
			ExtraDiscountAmt,
			ExtraDiscountPer,
			0 as 'RoundOffAmt',
			NetAmt,
			VatAmt,
			VatExemption,
			Rejected as 'Reject',
			UserID,
			Create_Date,
			MachineID 
       FROM IBInvoiceGroup
       UNION
	   (SELECT 1 as 'InvType',
			Trans_Key,
			CIG.BranchID,
			CIG.RegistrationType,
			CIG.RegistrationNo,
			iif(TransType='CA','Cash','Credit'),
			PD.PatientNameEnglish,
			TRANSNBR,
			CIG.TransDateEnglish,
			DoctorID,
			InsuranceID,
			BillAmt+NormalDiscountAmt+ExtraDiscountAmt+RoundOffAmt,
			NormalDiscountAmt,
			ExtraDiscountAmt,
			ExtraDiscountPercent,
			RoundOffAmt,
			BillAmt,
			VatAmt,
			VatExemption,
			Reject,
			CIG.UserID,
			CIG.Create_Date,
			CIG.MachineID 
              FROM ClinicInvoiceGroup as CIG
          left Join PatientDetails as PD 
          on CIG.RegistrationType=PD.PatientType and CIG.RegistrationNo=PD.RegistrationNo
	   ) 
	 )