
CREATE VIEW [dbo].[AllInvoicesCC_View]
  AS
(SELECT 'Clinic'									  as 'InvSource'
      ,[Group_Key]									  as 'Group_Key'
      ,iif([InvoiceType]='CA','Cash','Credit')		  as 'InvoiceType'
	  ,'Sales'										  as 'SaleType'
      ,CID.[BranchID]								  as 'BranchID'
	  ,cid.DepartmentID									  as 'DepartmentID'
	  ,DoctorID										  as 'DoctorID'
	  ,RowNbr										  as 'RowNbr'
	  ,cid.ServiceID									  as 'ItemCode'
      ,qty*salePrice                                  as 'ItemGrossTotal'
	  ,Round(iif(CID.DiscountAmt<>0,CID.DiscountAmt,Qty*SalePrice*DiscountPer/100),2) as 'ItemDiscountAmt'
      ,isnull(cid.[VATPercent],0)                         as 'ItemVATPercent'
      ,isnull(CID.[VATAmt],0)						  as 'ItemVATAmt'
	  ,CIG.TransNbr									  as 'TransNbr'
	  ,CIG.TransDateEnglish							  as 'InvTransDateEnglish'
	  ,CIG.NormalDiscountAmt						  as 'InvNormalDiscount'
	  ,CIG.ExtraDiscountAmt							  as 'InvExtraDiscount'
	  ,CIG.RoundOffAmt						          as 'InvRoundoffAmt'
	  ,isnull(CIG.VATAmt,0)						      as 'InvVatAmt'
	  ,isnull(CIG.VATExemption,0)					  as 'InvVatExemption'
	  ,CIG.BillAmt						              as 'InvBillAmt'
	  ,cig.Reject                                     as 'Rejected'
	  ,iif(MS.CostCentre='',ED.Costcentre,isNull(ms.CostCentre,ED.CostCentre)) as 'CostCenter'
	  ,(SELECT Round(sum(qty*saleprice),2) 
	    from [ClinicInvoiceDetails] as b
		where b.Group_key = cig.Trans_key) as 'invGrossTotal'
  FROM [iGroupClinic].[dbo].[ClinicInvoiceDetails] as CID
  inner join dbo.ClinicInvoiceGroup as CIG
  on CID.Group_Key = CIG.Trans_Key
  inner join dbo.MedicalServices as MS
  on CID.ServiceID = ms.ServiceID
  inner join employeedetails as ED
  on CIG.DoctorID = ed.EmpID)

UNION

(SELECT 'Diagnosis Center'  
      ,[Group_Key]
	  ,[TransType]  
	  ,'Sales' 
	  ,IBG.[BranchID]
	  ,'301'
	  ,'999'
	  ,slno
	  ,IBD.ServiceID									  as 'ItemID'
      ,[Qty]*[Price]   
      ,Round(iif([DiscAmt]<>0,DiscAmt,Price*DiscPer/100),2)
      ,isnull(IBD.[VATPercent],0)
      ,isnull(IBD.[VATAmt],0)
	  ,ibg.TransNbr
	  ,ibg.TransDateEnglish
	  ,ibg.DiscountAmt
	  ,ibg.ExtraDiscountAmt
	  ,0  
	  ,isnull(ibg.VATAmt,0)
	  ,isnull(ibg.VATExemption,0)
	  ,ibg.NetAmt
	  ,ibg.Rejected 
 	  ,isNull(ms.CostCentre,'999') as 'CostCenter'
	  ,(SELECT Round(sum(qty*[Price]),2) 
	    from [IBInvoiceDetails] as c
		where c.group_Key=ibg.trans_key ) 
  FROM [iGroupClinic].[dbo].[IBInvoiceDetails] as ibd
  inner join dbo.IBInvoiceGroup as ibg
  on ibd.Group_Key = ibg.Trans_Key
  inner join dbo.MedicalServices as MS
  on ibd.ServiceID = ms.ServiceID)
UNION 

(SELECT 'Pharmacy'  
      ,[Group_Key]
      ,iif([InvoiceType]='CA','Cash','Credit') 
	  ,iif([SaleType]='SALE RETURN','Sales Return','Sales')  
	  ,PHD.[BranchID]
	  ,'500'
	  ,iif(DocTorID='','999',isnull(DoctorID,'999'))
	  ,RowNbr 
	  ,Item_Code									  
	  ,iif([SaleType]='SALE RETURN',[Qty]*[SalePrice]*-1,[Qty]*[SalePrice])
      ,Round(iif([SaleType]='SALE RETURN',iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100)*-1,iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100)),2)
      ,isnull(PHD.[VATPercent],0)  
      ,iif([SaleType]='SALE RETURN',isnull(PHD.[VATAmt],0)*-1,isnull(PHD.[VATAmt],0))
	  ,PHG.TransNbr
	  ,PHG.TransDateEnglish
	  ,iif([SaleType]='SALE RETURN',PHG.NormalDiscountAmt*-1,PHG.NormalDiscountAmt)
	  ,iif([SaleType]='SALE RETURN',PHG.ExtraDiscountAmt*-1,PHG.ExtraDiscountAmt)
	  ,iif([SaleType]='SALE RETURN',PHG.RoundOffAmt*-1,PHG.RoundOffAmt)
	  ,iif([SaleType]='SALE RETURN',PHG.VATAmt*-1,PHG.VATAmt)
	  ,0  
	  ,iif([SaleType]='SALE RETURN',PHG.BillAmt*-1,PHG.BillAmt)
	  ,0  
	  ,'500' 
	  ,(SELECT Round(sum(qty*[SalePrice]),2)
	    from [PharmacyInvoiceDetails] as d
		where d.Group_key=phg.Trans_key) * iif([SaleType]='SALE RETURN',-1,1)
  FROM [iGroupClinic].[dbo].[PharmacyInvoiceDetails] as PHD
  inner join dbo.PharmacyInvoiceGroup as PHG
  on PHD.Group_Key = PHG.Trans_Key
  )
  










