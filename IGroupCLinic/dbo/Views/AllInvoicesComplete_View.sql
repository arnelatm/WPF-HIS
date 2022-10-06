
CREATE VIEW [dbo].[AllInvoicesComplete_View]
  AS
(SELECT 'Clinic' as 'InvSource'
      ,[Group_Key] as 'Group_Key'
      ,iif([InvoiceType]='CA','Cash','Credit') as 'BillType'
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
	  ,CID.[Qty]*CID.[SalePrice] - iif(CID.[DiscountAmt]<>0,CID.DiscountAmt,CID.Qty*CID.SalePrice*CID.DiscountPer/100)
	   - 
	   (
	    iif((cig.BillAmt+cig.ExtraDiscountAmt-cig.roundoffamt)= 0
		    ,0
			,(cig.ExtraDiscountAmt-cig.RoundOffAmt)
			 /
			 (cig.BillAmt+cig.ExtraDiscountAmt-cig.roundoffamt) 
			 * ( CID.[Qty]*CID.[SalePrice] - iif(CID.[DiscountAmt]<>0,CID.DiscountAmt,CID.Qty*CID.SalePrice*CID.DiscountPer/100) )
		   )
	   ) as 'AdjItemNetAmount'
      ,isnull([VATPercent],0) as 'VATPercent'
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
	  ,cig.Reject as 'Reject'
	  ,CIG.UserID
	  ,cig.DoctorID
	  ,cig.RegistrationNo
	  ,cig.RegistrationType
	  ,cid.DiscountPer
	  ,pt.Series
  FROM [iGroupClinic].[dbo].[ClinicInvoiceDetails] as CID
  inner join dbo.ClinicInvoiceGroup as CIG
  left outer join PatientDetails AS PT on cig.RegistrationNo=pt.RegistrationNo and upper(cig.RegistrationType)=upper(pt.PatientType) and cig.BranchID=pt.BranchID
  on CID.Group_Key = CIG.Trans_Key)

UNION
  (SELECT 'Diagnosis Center' as 'InvSource'
      ,[Group_Key]
	  ,[TransType]
	  ,'Sales' as 'SaleType'
	  ,ibg.[BranchID]
      ,[SlNo] as 'RowNbr'
      ,[ServiceID] as 'ItemCode'
      ,[Qty]
	  ,'P' as 'Unit'
	  ,1 as 'PcsQty'
      ,[Price] as 'SalePrice'
 	  ,[Qty]*[Price] as 'ItemGrossPrice'
      ,iif([DiscAmt]<>0,DiscAmt,Qty*Price*DiscPer/100) as 'ItemDiscountAmt'
	  ,[Qty]*[Price] - iif([DiscAmt]<>0,DiscAmt,Qty*Price*DiscPer/100) as 'ItemNetAmount'  	  
 	  ,[Qty]*[Price] - iif([DiscAmt]<>0,DiscAmt,Qty*Price*DiscPer/100)  
	   -
	   (     
	   iif((ibg.NetAmt+ibg.ExtraDiscountAmt)= 0
	       ,0
		   ,ibg.ExtraDiscountAmt
		    /
			(ibg.NetAmt+ibg.ExtraDiscountAmt)
			* ([Qty]*[Price] - iif([DiscAmt]<>0,DiscAmt,Qty*Price*DiscPer/100)) 
		  ) 
	   ) 
	   as 'AdjItemNetAmount'  	  
      ,isnull([VATPercent],0)
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
	  ,IBG.UserID
	  ,ibg.DoctorID
	  ,ibg.RegistrationNo
	  ,'Out Patient'
 	  ,ibd.DiscPer
	  ,pt.Series
  FROM [iGroupClinic].[dbo].[IBInvoiceDetails] ibd
  inner join dbo.IBInvoiceGroup as ibg
  left outer join PatientDetails AS PT on ibg.RegistrationNo=pt.RegistrationNo and ibg.BranchID=pt.BranchID
  on ibd.Group_Key = ibg.Trans_Key)

UNION 

  (SELECT 'Pharmacy' as 'InvSource'
      ,[Group_Key]
      ,iif([InvoiceType]='CA','Cash','Credit') 
	  ,iif([SaleType]='SALE RETURN','Sales Return','Sales') as 'SaleType'
	  ,PHD.[BranchID]
	  ,[RowNbr]
      ,[Item_Code] as 'ItemCode'
      ,[Qty]
      ,[Unit] 
      ,[PcsQty]
      ,[SalePrice]
   	  ,[Qty]*[SalePrice] as 'ItemGrossPrice'
      ,iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100) as 'ItemDiscountAmt'
	  ,[Qty]*[SalePrice] - iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100) as 'ItemNetAmount'
	  ,[Qty]*[SalePrice] - iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100) 
	   -
	   (iif( (phg.BillAmt+phg.ExtraDiscountAmt-phg.roundoffamt)  = 0
	        ,0
			,(phg.ExtraDiscountAmt-phg.RoundOffAmt)
		   )
	   /  	
		  (phg.BillAmt+phg.ExtraDiscountAmt-phg.roundoffamt) 
	   * iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100)
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
	  ,0 
	  ,PHG.UserID
	  ,phg.DoctorID
	  ,phg.RegistrationNo
	  ,phg.RegistrationType
	  ,PHD.DiscountPer
	  ,pt.Series
  FROM [iGroupClinic].[dbo].[PharmacyInvoiceDetails] as PHD
  inner join dbo.PharmacyInvoiceGroup as PHG
  left outer join PatientDetails AS PT on phg.RegistrationNo=pt.RegistrationNo and upper(phg.RegistrationType)=upper(pt.PatientType) and phg.BranchID=pt.BranchID
  on PHD.Group_Key = PHG.Trans_Key)