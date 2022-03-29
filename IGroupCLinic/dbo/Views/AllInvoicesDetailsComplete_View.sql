

CREATE VIEW [dbo].[AllInvoicesDetailsComplete_View]
  AS
(SELECT 'Clinic' as 'InvSource'
      ,[Group_Key] as 'Group_Key'
      ,iif([InvoiceType]='CA','Cash','Credit') as 'TransType'
	  ,'Sales' as 'SaleType'
      ,CID.[BranchID] as 'BranchID'
      ,CID.[RowNbr] as 'RowNbr'
      ,CID.[ServiceID] as 'ItemCode'
      ,[Qty]
	  ,'P' AS 'Unit'
      ,CID.[PcsQty]
      ,CID.[SalePrice]
	  ,CID.[Qty]*CID.[SalePrice] as 'ItemGrossPrice'
	  ,iif(CID.[DiscountAmt]<>0,CID.DiscountAmt,CID.Qty*CID.SalePrice*CID.DiscountPer/100) as 'ItemDiscountAmt'
	  ,CID.[Qty]*CID.[SalePrice] - iif(CID.[DiscountAmt]<>0,CID.DiscountAmt,CID.Qty*CID.SalePrice*CID.DiscountPer/100) as 'ItemNetAmount'
	  ,(CID.[Qty]*CID.[SalePrice] - iif(CID.[DiscountAmt]<>0,CID.DiscountAmt,CID.Qty*CID.SalePrice*CID.DiscountPer/100)
	   - 
	    (
	     (iif((cig.BillAmt+cig.ExtraDiscountAmt-cig.roundoffamt)= 0
		       ,0
			   ,(cig.ExtraDiscountAmt-cig.RoundOffAmt) 
			    /
			    (cig.BillAmt+cig.ExtraDiscountAmt-cig.roundoffamt) 
			  )
			 * ( CID.[Qty]*CID.[SalePrice] - iif(CID.[DiscountAmt]<>0,CID.DiscountAmt,CID.Qty*CID.SalePrice*CID.DiscountPer/100) )
		 )
	    )
	   ) as 'AdjItemNetAmount'
      ,isnull(cid.VATPercent,0) as 'VATPercent'
      ,isnull(CID.[VATAmt],0) as 'VATAmt'
	  ,CIG.TransNbr
	  ,CIG.TransDateEnglish
	  ,IIF(CID.ROWNBR = 1,CIG.NormalDiscountAmt,0) as 'InvNormalDiscount'
	  ,IIF(CID.ROWNBR=1,CIG.ExtraDiscountAmt,0) as 'InvExtraDiscount'
	  ,IIF(CID.ROWNBR=1,CIG.RoundOffAmt,0) as 'InvRoundoffAmt'
	  ,isnull(IIF(CID.ROWNBR=1,isnull(CIG.VATAmt,0),0),0) as 'InvVatAmt'
	  ,isnull(IIF(CID.ROWNBR=1,isnull(CIG.VATExemption,0),0),0) as 'InvVatExemption'
  	  ,iif(cid.rownbr=1,CIG.BillAmt,0) AS 'BillAmt'
	  ,CIG.NormalDiscountAmt as 'TInvNormalDiscount'
	  ,CIG.ExtraDiscountAmt as 'TInvExtraDiscount'
	  ,CIG.RoundOffAmt as 'TInvRoundoffAmt'
	  ,isnull(CIG.VATAmt,0) as 'TInvVatAmt'
	  ,isnull(CIG.VATExemption,0) as 'TInvVatExemption'
	  ,CIG.BillAmt AS 'TBillAmt'
	  ,cig.Reject as 'Rejected'
	  ,iif(MS.CostCentre='',ED.Costcentre,isNull(ms.CostCentre,ED.CostCentre)) as 'CostCenter'
	  ,CIG.UserID
	  ,cig.DoctorID
	  ,cig.RegistrationNo
	  ,cig.RegistrationType
	  ,pt.PatientNameEnglish
	  ,cig.InsuranceID as 'InsuranceID'
	  ,comp.NameEnglish
	  ,ms.ServiceNameEnglish
  	  ,comp.GroupInsuranceID as 'InsuranceGroupID'
	  ,CIG.ExtraDiscountAmt-CIG.RoundOffAmt AS 'AdjInvExtraDisc'
	  ,CIG.BillAmt+CIG.NormalDiscountAmt+CIG.ExtraDiscountAmt-isnull(CIG.VATAmt,0)+isnull(CIG.VATExemption,0)-CIG.RoundOffAmt AS 'InvGrossAmt'
	  ,iif(isnull(CIG.VATExemption,0)=0,0,isnull(CID.[VATAmt],0)) as 'ItemVatExemption'
	  ,pt.Series
	  ,Concat(pt.IqamaNo,'') as 'IqamaNo'
	  ,cm.CountryNameEng as 'CountryName'
  FROM [iGroupClinic].[dbo].[ClinicInvoiceDetails] as CID
  left outer join dbo.ClinicInvoiceGroup as CIG
  on CID.Group_Key = CIG.Trans_Key
  left OUTER join  dbo.MedicalServices as MS
  on CID.ServiceID = ms.ServiceID
  left outer join dbo.patientdetails as Pt
  on CIG.RegistrationNo = pt.registrationno and upper(cig.RegistrationType) = upper(pt.PatientType)
  left outer join dbo.InsuranceDetails as Comp
  on CIG.InsuranceID = COMP.InsuranceID
  left outer join employeedetails as ED
  on CIG.DoctorID = ed.EmpID
  left outer join countrymaster as CM
  on pt.countryiota = cm.countryIota)

UNION
  (SELECT 'Diagnosis Center' as 'InvSource'
      ,[Group_Key]
	  ,[TransType] as 'InvoiceType'
	  ,'Sales' as 'SaleType'
	  ,ibg.BranchID
      ,[SlNo] as 'RowNbr'
      ,ibd.ServiceID as 'ItemCode'
      ,[Qty]
	  ,'P' as 'Unit'
	  ,1 as 'PcsQty'
      ,[Price] as 'SalePrice'
 	  ,[Qty]*[Price] as 'ItemGrossPrice'
      ,iif([DiscAmt]<>0,DiscAmt,Qty*Price*DiscPer/100) as 'ItemDiscountAmt'
	  ,[Qty]*[Price] - iif([DiscAmt]<>0,DiscAmt,Qty*Price*DiscPer/100) as 'ItemNetAmount'  	  
 	  ,([Qty]*[Price] - iif([DiscAmt]<>0,DiscAmt,Qty*Price*DiscPer/100)  
	   -
	   (     
	   iif((ibg.NetAmt+ibg.ExtraDiscountAmt)= 0
	       ,0
		   ,ibg.ExtraDiscountAmt
		    /
			(ibg.NetAmt+ibg.ExtraDiscountAmt)
		  )
			* ([Qty]*[Price] - iif([DiscAmt]<>0,DiscAmt,Qty*Price*DiscPer/100)) 	   
	   ) 
	   ) as 'AdjItemNetAmount'  	  
      ,isnull(ibd.VATPercent,0)
      ,isnull(IBD.[VATAmt],0)
	  ,ibg.TransNbr
	  ,ibg.TransDateEnglish
	  ,IIF(ibd.SlNo=1,ibg.DiscountAmt,0) as 'InvNormalDiscount'
	  ,IIF(ibd.SlNo=1,ibg.ExtraDiscountAmt,0) as 'InvExtraDiscount'
	  ,0  as 'InvRoundoffAmt'
	  ,isnull(IIF(ibd.SlNo=1,isnull(ibg.VATAmt,0),0),0) as 'InvVatAmt'
	  ,isnull(IIF(ibd.SlNo=1,isnull(ibg.VATExemption,0),0),0) as 'InvVatExemption'
	  ,iif(ibd.SlNo=1,ibg.NetAmt,0) AS 'BillAmt'
	  ,ibg.DiscountAmt as 'TInvNormalDiscount'
	  ,ibg.ExtraDiscountAmt as 'TInvExtraDiscount'
	  ,0  as 'TInvRoundoffAmt'
	  ,isnull(ibg.VATAmt,0) as 'TInvVatAmt'
	  ,isnull(ibg.VATExemption,0) as 'TInvVatExemption'
	  ,ibg.NetAmt AS 'TBillAmt'
	  ,ibg.Rejected 
 	  ,'301'
	  ,IBG.UserID
	  ,ibg.DoctorID
	  ,ibg.RegistrationNo
	  ,'Out Patient'
	  ,ibg.PatientName
	  ,ibg.CompanyID
 	  ,comp.NameEnglish
	  ,ms.ServiceNameEnglish
   	  ,comp.GroupInsuranceID as 'InsuranceGroupID'
	  ,ibg.ExtraDiscountAmt
	  ,ibg.NetAmt+ibg.DiscountAmt+ibg.ExtraDiscountAmt-isnull(ibg.VATAmt,0)+isnull(ibg.VATExemption,0) AS 'InvGrossAmt'
	  ,iif(isnull(ibg.VATExemption,0)=0,0,isnull(ibd.[VATAmt],0)) as 'ItemVatExemption'
	  ,pt.Series
	  ,concat(ibg.border_iqama,'') as 'IqamaNo'
	  ,cm.CountryNameEng
  FROM [iGroupClinic].[dbo].[IBInvoiceDetails] ibd
  left outer join dbo.IBInvoiceGroup as ibg
  on ibd.Group_Key = ibg.Trans_Key
  left outer join dbo.patientdetails as Pt
  on ibg.RegistrationNo = pt.registrationno 
  left outer join dbo.InsuranceDetails as Comp
  on IBG.CompanyID = COMP.InsuranceID
  left outer join  dbo.MedicalServices as MS
  on ibd.ServiceID = ms.ServiceID
  left outer join countrymaster as CM
  on pt.countryiota = cm.countryIota)

UNION 

  (SELECT 'Pharmacy' as 'InvSource'
      ,[Group_Key]
      ,iif([InvoiceType]='CA','Cash','Credit') as 'InvoiceType'
	  ,iif([SaleType]='SALE RETURN','Sales Return','Sales') as 'SaleType'
	  ,PHD.[BranchID]
	  ,[RowNbr]
      ,phd.Item_Code as 'ItemCode'
      ,[Qty]
      ,[Unit] 
      ,[PcsQty]
      ,[SalePrice]
   	  ,[Qty]*[SalePrice] as 'ItemGrossPrice'
      ,iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100) as 'ItemDiscountAmt'
	  ,[Qty]*[SalePrice] - iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100) as 'ItemNetAmount'
	  ,([Qty]*[SalePrice] - iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100) 
	   -
	   (iif((phg.BillAmt+phg.ExtraDiscountAmt-phg.roundoffamt) = 0
            ,0
			,(phg.ExtraDiscountAmt-phg.RoundOffAmt)
			 /  	
		     (phg.BillAmt+phg.ExtraDiscountAmt-phg.roundoffamt) 
			)
  	    * iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100)
       )
	   ) as 'AdjItemNetAmount'
      ,isnull(PHD.[VATPercent],0) as 'VATPercent'
      ,isnull(PHD.[VATAmt],0) as 'VATAmount'
	  ,PHG.TransNbr
	  ,PHG.TransDateEnglish
	  ,IIF(PHD.ROWNBR = 1,PHG.NormalDiscountAmt,0) as 'InvNormalDiscount'
	  ,IIF(PHD.ROWNBR=1,PHG.ExtraDiscountAmt,0) as 'InvExtraDiscount'
	  ,IIF(PHD.ROWNBR=1,PHG.RoundOffAmt,0) as 'InvRoundoffAmt'
	  ,isnull(IIF(PHD.ROWNBR=1,isnull(PHG.VATAmt,0),0),0) as 'InvVatAmt'
	  ,0 as 'InvVatExemption'
	  ,iif(PHD.rownbr=1,PHG.BillAmt,0) AS 'BillAmt'
	  ,PHG.NormalDiscountAmt as 'TInvNormalDiscount'
	  ,PHG.ExtraDiscountAmt as 'TInvExtraDiscount'
	  ,PHG.RoundOffAmt as 'TInvRoundoffAmt'
	  ,isnull(PHG.VATAmt,0) as 'TInvVatAmt'
	  ,0 as 'TInvVatExemption'
	  ,PHG.BillAmt AS 'TBillAmt'
	  ,0 as 'Rejected'
	  ,PHG.UserID
	  ,'500'
	  ,phg.DoctorID
	  ,phg.RegistrationNo
	  ,phg.RegistrationType
	  ,pt.PatientNameEnglish
	  ,phg.InsuranceID
	  ,comp.NameEnglish
	  ,itd.ItemNameEnglish
  	  ,comp.GroupInsuranceID as 'InsuranceGroupID'
      ,phg.ExtraDiscountAmt-phg.RoundOffAmt
	  ,phg.BillAmt+phg.NormalDiscountAmt+phg.ExtraDiscountAmt-isnull(phg.VATAmt,0)-phg.RoundOffAmt AS 'InvGrossAmt'
	  ,0 
	  ,pt.Series
	  ,concat(pt.IqamaNo,'') as 'IqamaNo'
	  ,cm.CountryNameEng
  FROM [iGroupClinic].[dbo].[PharmacyInvoiceDetails] as PHD
  left outer join dbo.PharmacyInvoiceGroup as PHG
  on PHD.Group_Key = PHG.Trans_Key
  left outer  join dbo.patientdetails as Pt
  on PHG.RegistrationNo = pt.registrationno and upper(PHG.RegistrationType) = upper(pt.PatientType)
  left outer  join dbo.InsuranceDetails as Comp
  on phg.InsuranceID = COMP.InsuranceID
  left outer  join dbo.ItemDetails as itd 
  on phd.Item_Code = itd.Item_Code and phd.BranchID = itd.branchid 
  left outer join countrymaster as CM
  on pt.countryiota = cm.countryIota)
 
