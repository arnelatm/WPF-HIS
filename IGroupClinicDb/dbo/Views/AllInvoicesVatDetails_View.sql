















CREATE VIEW [dbo].[AllInvoicesVatDetails_View]
  AS
SELECT cid.InvSource
      ,CID.[Group_Key]									  
      ,InvoiceType
	  ,TransNbr
	  ,SaleType
      ,CID.[BranchID]
	  ,cid.DepartmentID
	  ,DoctorID
	  ,ItemGrossTotal
	  ,ItemDiscountAmt
	  ,ItemVATAmt
	  ,b.InvAdjGrossAmount
	  ,ItemGrossTotal-ItemDiscountAmt+ItemVatAmt as 'ItemNetAmountWithVat' 
	  ,InvExtraDiscount
	  ,Iif(B.InvAdjGrossAmount=0,0,(ItemGrossTotal-ItemDiscountAmt+ItemVatAmt - (InvExtraDiscount-InvRoundOffAmt) / B.InvAdjGrossAmount * (ItemGrossTotal-ItemDiscountAmt))) as 'MyAmount'
	  ,Iif(B.InvAdjGrossAmount=0,0,(ItemGrossTotal-ItemDiscountAmt+ItemVatAmt - (InvExtraDiscount-InvRoundOffAmt) / B.InvAdjGrossAmount * (ItemGrossTotal-ItemDiscountAmt))/(1+ItemVatPercent/100)) as 'AdjNetAmt'
	  ,Iif(B.InvAdjGrossAmount=0,0,((ItemGrossTotal-ItemDiscountAmt+ItemVatAmt - (InvExtraDiscount-InvRoundOffAmt) / B.InvAdjGrossAmount * (ItemGrossTotal-ItemDiscountAmt))*ItemVATPercent/100)/(1+ItemVatPercent/100)) as 'AdjNetVatAmt'
  	  ,Iif(B.InvAdjGrossAmount=0,0,ItemGrossTotal-ItemDiscountAmt+ItemVatAmt - (InvExtraDiscount-InvRoundOffAmt) / B.InvAdjGrossAmount * (ItemGrossTotal-ItemDiscountAmt)) as 'AdjNetAmtWithVat'
	  ,iif(CID.InvVatExemption=0,0,Iif(B.InvAdjGrossAmount=0,0,((ItemGrossTotal-ItemDiscountAmt+ItemVatAmt - (InvExtraDiscount-InvRoundOffAmt) / B.InvAdjGrossAmount * (ItemGrossTotal-ItemDiscountAmt))*ItemVATPercent/100)/(1+ItemVatPercent/100))) as 'AdjExempVatAmt'
	  ,ItemGrossTotal-ItemDiscountAmt as 'ItemNetAmount'
	  ,InvTransDateEnglish
	  ,InvBillAmt
	  ,Rejected
	  ,CompanyID
  FROM [iGroupClinic].[dbo].[AllInvoices_View] as CID
  left join iGroupClinic.Dbo.AllInvoicesSummarized_View B
  ON CID.Group_Key = B.Group_Key and cid.InvSource = b.InvSource