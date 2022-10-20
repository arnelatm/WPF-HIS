



CREATE view [dbo].[ClinicIBPharmaCombinedInvDetails_View] as
 (  (Select 0 as invType,IBG.TransNBR,IBG.TransDateEnglish,IBG.DOCTORID,GROUP_KEY,SlNo,IBD.ServiceID,MS.DepartmentID,Qty,Price,DiscPer,
				 iif(IBD.DiscAmt<>0,IBD.DISCAMT,Qty*Price*DiscPer/100) as DiscAmt,
				 IBG.CompanyID,IBG.Rejected as Reject,IBG.TransType,
                 iif(ibd.slno=1,IBG.NetAmt,0) as NetAmt,
				 iif(ibd.slNo=1,IBG.ExtraDiscountAmt,0) as ExtraDiscountAmt,
				 0 as RoundOffAmt,
				 iif(ibd.slNo=1,ibg.VATAmt,0) as VATAmt,	
				 ibd.VATAmt as DVATAmt,		 
				 iif(ibd.slNo=1,IBG.VATExemption,0) as VATExemption,
				 ms.CostCentre,
				 ibg.UserID,
				 ibg.RegistrationNo,
				 ibg.Create_Date
	        from IBInvoiceDetails as IBD
			LEFT JOIN IBInvoiceGroup as IBG
			on IBD.Group_Key = IBG.Trans_Key 
			left join MedicalServices as MS
			on IBD.ServiceID = MS.ServiceID
			left join InsuranceDetails AS ins
			on IBG.CompanyID = INS.InsuranceID)
	   UNION
	     (Select 1 AS invType,CIG.TransNbr,CIG.TransDateEnglish,CIG.DOCTORID,Group_Key,RowNbr,CID.ServiceID,MS.DepartmentID,Qty,SalePrice,CID.DiscountPer,
		              iif(CID.DiscountAmt<>0,CID.DiscountAmt,Qty*SalePrice*CID.DiscountPer/100),
					  CIG.InsuranceID,CIG.Reject,IIF(CIG.BillType='CA','Cash','Credit') AS BillType,
                      iif(RowNbr=1,CIG.BillAmt,0),
					  iif(RowNbr=1,CIG.ExtraDiscountAmt,0),
					  iif(RowNbr=1,CIG.RoundOffAmt,0),
					  iif(RowNbr=1,CIG.VATAmt,0) as VATAmt,
					  cid.VATAmt as DVATAmt,	
					  iif(RowNbr=1,CIG.VATExemption,0) as VATExemption,
					  ms.CostCentre,
					  cig.userid,
 					  cig.RegistrationNo,
					  cig.Create_Date
	        from ClinicInvoiceDetails as CID
			left join ClinicInvoiceGroup as CIG
			on CID.Group_Key = CIG.Trans_Key
			left join MedicalServices as MS
			on CID.ServiceID = MS.ServiceID
			left join InsuranceDetails AS ins
			on CIG.InsuranceID = INS.InsuranceID
		  )
       UNION 
	     (Select 3 as invType,PHG.TRANSNBR,PHG.TransDateEnglish,'500',Group_Key,RowNbr,PHD.Item_Code,'500',IIF(PHG.BILLTYPE = 'SALE INVOICE',Qty,QTY*-1),SalePrice,DiscountPer,
		              IIF(PHG.BILLTYPE = 'SALE INVOICE',PHD.DiscountAmt,PHD.DiscountAmt*-1),
					  PHG.InsuranceID,0,IIF(PHG.TransType='CA','Cash','Credit'),
					  IIF(RowNbr=1,iif(PHG.BILLTYPE = 'SALE INVOICE',PHG.BILLAMT,PHG.BillAmt * -1),0),
					  IIF(RowNbr=1,iif(PHG.BILLTYPE = 'SALE INVOICE',PHG.ExtraDiscountAmt,PHG.ExtraDiscountAmt*-1),0),
					  IIF(RowNbr=1,iif(PHG.BILLTYPE = 'SALE INVOICE',PHG.RoundOffAmt,PHG.RoundOffAmt*-1),0),
					  iif(RowNbr=1,iif(PHG.BILLTYPE = 'SALE INVOICE',phg.VATAmt,PHG.VATAmt*-1),0) as VATAmt,
					  iif(PHG.BILLTYPE = 'SALE INVOICE',phd.VATAmt,phd.VATAmt * -1) as DVatAmt,
					  0 as VATExemption,
					  '500',
					  phg.userid,
					  phg.RegistrationNo,
					  PHG.Create_Date
	        from PharmacyInvoiceDetails as PHD
			LEFT JOIN PharmacyInvoiceGroup as PHG
			on PHD.Group_Key = PHG.Trans_Key
			left join itemdetails as IT
			on PHD.Item_Code = IT.Item_Code
			left join InsuranceDetails AS ins
			on PHG.InsuranceID = INS.InsuranceID)
	)