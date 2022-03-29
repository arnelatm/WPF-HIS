


CREATE VIEW [dbo].[DeleteMe_AllCoInvoicesDetails_View]
  AS
(SELECT 'Clinic' as 'InvSource'
      ,[Group_Key] as 'Group_Key'
      ,iif([InvoiceType]='CA','Cash','Credit') as 'InvoiceType'
	  ,'Sales' as 'SaleType'
      ,CID.[BranchID] as 'BranchID'
      ,[RowNbr] as 'RowNbr'
      ,[ServiceID] as 'ServiceID'
      ,[Qty]
	  ,'P' AS 'Unit'
      ,[PcsQty]
      ,[SalePrice]
	  ,iif([DiscountAmt]<>0,DiscountAmt,Qty*SalePrice*DiscountPer/100) as 'ItemDiscountAmt'
      ,isnull([VATPercent],0) as 'VATPercent'
      ,isnull(CID.[VATAmt],0) as 'VATAmt'
	  ,CIG.TransNbr
	  ,CIG.TransDateEnglish
	  ,IIF(CID.ROWNBR = 1,CIG.NormalDiscountAmt,0) as 'InvNormalDiscount'
	  ,IIF(CID.ROWNBR=1,CIG.ExtraDiscountAmt,0) as 'InvExtraDiscount'
	  ,IIF(CID.ROWNBR=1,CIG.RoundOffAmt,0) as 'InvRoundoffAmt'
	  ,isnull(IIF(CID.ROWNBR=1,CIG.VATAmt,0),0) as 'InvVatAmt'
	  ,isnull(IIF(CID.ROWNBR=1,CIG.VATExemption,0),0) as 'InvVatExemption'
	  ,iif(cid.rownbr=1,CIG.BillAmt,0) AS 'BillAmt'
	  ,cig.Reject as 'Rejected'
	  ,CIG.UserID
	  ,cig.DoctorID
	  ,cig.RegistrationNo
	  ,cig.RegistrationType
      ,CIG.TransDateHijri
      ,CIG.InsuranceNameEnglish
      ,CIG.NormalDiscountAmt
      ,CIG.PreviousBalanceAmt
      ,CIG.DeductibleAmt
      ,CIG.DeductibleDiscountAmt
      ,CIG.ExtraDiscountPercent
      ,CIG.ExtraDiscountAmt
      ,CIG.RoundOffAmt
      ,CIG.VATExemption
      ,CIG.Remarks
      ,CIG.Reject
      ,CIG.RejectDate
      ,CIG.MachineID
      ,CIG.Create_Date
	  ,case when cid.DiscountPer is null then 0 else cid.DiscountPer end as 'DiscountPer'
	  ,case when cid.DiscountAmt	is null then 0 else cid.DiscountAmt end as 'DiscountAmt'
  FROM [iGroupClinic].[dbo].[ClinicInvoiceDetails] as CID
  inner join dbo.ClinicInvoiceGroup as CIG
  on CID.Group_Key = CIG.Trans_Key)

UNION
  (SELECT 'Diagnosis Center' as 'InvSource'
      ,[Group_Key]
	  ,[TransType] as 'InvoiceType'
	  ,'Sales' as 'SaleType'
	  ,ibg.BranchID
      ,[SlNo] as 'RowNbr'
      ,[ServiceID] as 'ItemCode'
      ,[Qty]
	  ,'P' as 'Unit'
	  ,1 as 'PcsQty'
      ,[Price] as 'SalePrice'
      ,iif([DiscAmt]<>0,DiscAmt,Price*DiscPer/100) as 'ItemDiscountAmt'
      ,isnull([VATPercent],0)
      ,isnull(IBD.[VATAmt],0)
	  ,ibg.TransNbr
	  ,ibg.TransDateEnglish
	  ,IIF(ibd.SlNo=1,ibg.DiscountAmt,0) as 'InvNormalDiscount'
	  ,IIF(ibd.SlNo=1,ibg.ExtraDiscountAmt,0) as 'InvExtraDiscount'
	  ,0  as 'InvRoundoffAmt'
	  ,isnull(IIF(ibd.SlNo=1,ibg.VATAmt,0),0) as 'InvVatAmt'
	  ,isnull(IIF(ibd.SlNo=1,ibg.VATExemption,0),0) as 'InvVatExemption'
	  ,iif(ibd.SlNo=1,ibg.NetAmt,0) AS 'BillAmt'
	  ,ibg.Rejected 
	  ,IBG.UserID
	  ,ibg.DoctorID
	  ,ibg.RegistrationNo
	  ,'Out Patient'
      ,Ibg.TransDateHijri
      ,ins.NameEnglish
      ,Ibg.DiscountAmt
      ,0
      ,0
      ,0
      ,Ibg.ExtraDiscountPer
      ,Ibg.ExtraDiscountAmt
      ,0
      ,Ibg.VATExemption
      ,Ibg.Remarks
      ,Ibg.Rejected
      ,Ibg.RejectedDate
      ,Ibg.MachineID
      ,Ibg.Create_Date
	  ,case when ibd.DiscPer is null then 0 else ibd.DiscPer end 
	  ,case when ibd.DiscAmt	is null then 0 else ibd.DiscAmt end 
  FROM [iGroupClinic].[dbo].[IBInvoiceDetails] ibd
  inner join dbo.IBInvoiceGroup as ibg
  Left Outer join dbo.InsuranceDetails Ins on ibg.CompanyID = ins.InsuranceID
  on ibd.Group_Key = ibg.Trans_Key)

