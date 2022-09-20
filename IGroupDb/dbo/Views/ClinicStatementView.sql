CREATE VIEW ClinicStatementView
 
AS
SELECT
	BranchID,
	TransType,
	BillType,
	TransNBR,
	TransDateEnglish,
	RegistrationType,
	RegistrationNo,
	InsCardNo as InsuranceCardNo,
	sum(qty*saleprice) as GrossAmt,
	sum(DiscountPer * Qty * SalePrice /100) as DiscAmt,
	DeductibleAmt,
	ExtraDiscountAmt,
	DeductibleDiscountAmt,
	RoundOffAmt,
	PatientNameEnglish,
	InsuranceNameEnglish
from ClinicInvoice_view where (Reject is null or Reject = 0)
group by
	BranchID,
	TransType,
	BillType,
	TransNBR,
	TransDateEnglish,
	RegistrationType,
	RegistrationNo,
	InsCardNo,
	DeductibleAmt,
	RoundOffAmt,
	ExtraDiscountAmt,
	DeductibleDiscountAmt,
	PatientNameEnglish,
	InsuranceNameEnglish 
--order by registrationno,transnbr