CREATE VIEW PharmacyStatementView
 
AS
SELECT
	BranchID,
	TransType,
	BillType,
	TransNBR,
	TransDateEnglish,
	RegistrationType,
	RegistrationNo,
	InsuranceCardNo,
	sum(qty*saleprice) as GrossAmt,
	sum(DiscountPer * Qty * SalePrice /100) as DiscAmt,
	DeductibleAmt,
	PatientNameEnglish,
	InsuranceNameEnglish
from pharmacysales_view 
group by
	BranchID,
	TransType,
	BillType,
	TransNBR,
	TransDateEnglish,
	RegistrationType,
	RegistrationNo,
	InsuranceCardNo,
	DeductibleAmt,
	PatientNameEnglish,
	InsuranceNameEnglish 
--order by registrationno,transnbr