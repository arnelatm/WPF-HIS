CREATE VIEW ClinicCreditCardCollection_View
 
AS
Select 
	BranchID ,
	Trans_key,
	TransNbr,
	TransDateEnglish,
	Sum(Qty*Saleprice) as GrossAmt,
	NormalDiscountAmt,
	DeductibleAmt,
	ExtraDiscountAmt,
	RoundOffAmt   
From ClinicInvoice_View 
Where (Reject is null or Reject = '0') 
and   (CreditCardNo<>'' AND NOT CreditCardNo is null) 
AND BillType = 'CA'  
Group By
	BranchID ,
	Trans_Key,
	TransNBR,
	TransDateEnglish,
	NormalDiscountAmt,
	DeductibleAmt,
	ExtraDiscountAmt,
	RoundOffAmt