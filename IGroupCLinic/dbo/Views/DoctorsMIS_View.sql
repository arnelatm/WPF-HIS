
CREATE VIEW DoctorsMIS_View
 
AS
SELECT 
	DISTINCT(RegistrationNo),
	DoctorID,
	sum(Qty*SalePrice) as GrossAmt,
	sum(DeductibleAmt) as DeductibleAmt,
	sum(NormalDiscountAmt) as Discount,
	sum(ExtraDiscountAmt) as ExtraDiscount,
	sum(RoundOffAmt) as RoundOff,
	sum(BillAmt) as BillAmt,
	EmpNameEnglish,
	CountryIOTA,
	CountryNameEng
FROM clinicInvoice_view 
WHERE Reject<> 1
GROUP BY REGISTRATIONNO,
	DOCTORID,
	EmpNameEnglish,
	CountryIOTA,
	CountryNameEng
