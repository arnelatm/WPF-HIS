CREATE VIEW ClinicHourlyPatientsDetails_View 
AS
SELECT
	BranchID,
	TransNBR,
	RegistrationNo,
	RegistrationDate,
	RegistrationType,
	TransDateEnglish,
	DoctorID,
	EmpNameEnglish,
	sum(CASE when SaleType = 'CLINIC INVOICE' 
		then Qty * SalePrice 
		else Qty * SalePrice * -1 
		end)
		- sum(CASE when SaleType = 'CLINIC INVOICE' 
			then 
				case when DiscountAmt <> 0 
				then DiscountAmt 
				else Qty*saleprice*discountper/100 
				end 
			else case when DiscountAmt <> 0 
				then DiscountAmt 
				else Qty*saleprice*discountper/100 
				end * -1 
			end)
		- sum(DeductibleAmt) 
		- sum(CASE WHEN ExtraDiscountPercent <> 0 
			THEN Qty * SalePrice * ExtraDiscountPercent/ 100 
			ELSE ExtraDiscountAmt 
			END) 
		+ sum(RoundOffAmt) as GrossAmt,
	SUM(CASE when SaleType = 'CLINIC INVOICE' 
		then case when DiscountAmt <> 0 
			then DiscountAmt 
			else Qty*saleprice*discountper/100 
			end 
		else case when DiscountAmt <> 0 
			then DiscountAmt 
			else Qty*saleprice*discountper/100 
			end * -1 
		end) as NormalDiscountAmt,
	sum(DeductibleAmt) as DeductibleAmt,
	sum(RoundoffAmt) as RoundOffAmt,
	sum(CASE WHEN ExtraDiscountPercent <> 0 
		THEN Qty * SalePrice * ExtraDiscountPercent/100 
		ELSE ExtraDiscountAmt 
		END) AS ExtraDiscountAmt,
	sum(CASE when SaleType = 'CLINIC INVOICE' 
		then Qty * SalePrice 
		else Qty * SalePrice * -1 
		end)
		- sum(CASE when SaleType = 'CLINIC INVOICE' 
			then 
				case when DiscountAmt <> 0 
				then DiscountAmt 
				else Qty*saleprice*discountper/100 
				end 
			else case when DiscountAmt <> 0 
				then DiscountAmt 
				else Qty*saleprice*discountper/100 
				end * -1 
			end)
		- sum(DeductibleAmt) 
		- sum(CASE WHEN ExtraDiscountPercent <> 0 
			THEN Qty * SalePrice * ExtraDiscountPercent/ 100 
			ELSE ExtraDiscountAmt 
			END) 
		+ sum(RoundOffAmt) as BillAmt,
	case when TransDateEnglish <> RegistrationDate then 1 else 0 end as OldPatient,
	case when TransDateEnglish = RegistrationDate then 1 else 0 end as NewPatient,
	case when RegistrationType in('Cash','Out Patient','Staff','Cash/Company','Comp Pkg.') then 1 else 0 end as CreditPatient,
	Create_Date
FROM ClinicInvoice_View
WHERE RegistrationDate is not null and (Reject is NULL or Reject ='0')
GROUP BY BranchID,
		TransNBR,
		RegistrationNo,
		RegistrationDate,
		RegistrationType,
		TransDateEnglish,
		DoctorID,
		EmpNameEnglish,
		Create_date