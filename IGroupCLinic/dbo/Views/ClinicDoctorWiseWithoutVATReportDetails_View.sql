CREATE VIEW ClinicDoctorWiseWithoutVATReportDetails_View
 
AS
SELECT 
	a.TransNbr,
	a.TransType,  
	a.transdateenglish,
	a.DeductibleAmt,
	a.ExtraDiscountAmt,
	a.DeductibleDiscountAmt, 
	a.roundoffamt,
	a.DoctorID,   
	c.EmpNameEnglish   as DoctorNameEnglish,
	sum(b.qty*b.SalePrice ) as Gross,
	sum(case when b.DiscountAmt = 0 then (b.DiscountPer * b.Qty * b.SalePrice )/100 else b.discountamt end) as DiscountAmt,
	sum(b.vatamt) as vatamt,
	a.Reject  
FROM ClinicInvoiceGroup a
LEFT OUTER JOIN ClinicInvoiceDetails b ON a.Trans_Key = b.Group_Key 
left outer join EmployeeDetails  c on a.DoctorID = c.EmpID   
GROUP BY 
	a.TransNbr,
	a.TransType,  
	a.transdateenglish,
	a.DoctorID,
	a.DeductibleAmt,
	a.ExtraDiscountAmt,
	a.DeductibleDiscountAmt,
	a.roundoffamt,
	a.Reject ,
	c.EmpNameEnglish 
