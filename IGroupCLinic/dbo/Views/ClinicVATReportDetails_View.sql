
CREATE VIEW ClinicVATReportDetails_View
 
AS
SELECT 
	a.RegistrationNo,
	c.IqamaNo,
	c.PatientNameEnglish,
	c.CountryIOTA as CountryID, 
	a.TransNbr,
	a.TransType,  
	a.transdateenglish,
	a.DeductibleAmt,
	a.ExtraDiscountAmt,
	a.DeductibleDiscountAmt, 
	a.roundoffamt,  
	'Daily Collection'  as ServiceDescription,
	sum(b.qty*b.SalePrice ) as Gross,
	sum(case when b.DiscountAmt = 0 then (b.DiscountPer * b.Qty * b.SalePrice )/100 else b.discountamt end) as DiscountAmt,
	sum(b.vatamt) as vatamt,
	case when c.CountryIOTA = 'SAU' then sum(b.VATAmt) else 0 end as VATExemption,
	a.Reject  
FROM ClinicInvoiceGroup a
LEFT OUTER JOIN ClinicInvoiceDetails b ON a.Trans_Key = b.Group_Key 
left outer join PatientDetails c on a.RegistrationNo = c.RegistrationNo and upper(a.RegistrationType) = upper(c.PatientType) 
--where a.TransType ='Cash'
GROUP BY 
	a.TransNbr,
	a.TransType,  
	a.transdateenglish,
	a.DeductibleAmt,
	a.ExtraDiscountAmt,
	a.DeductibleDiscountAmt,
	a.roundoffamt,
	c.CountryIOTA ,
	a.Reject ,
	a.RegistrationNo,
	c.IqamaNo,
	c.PatientNameEnglish
UNION ALL
SELECT 
	a.RegistrationNo,
	a.Border_iqama as IqamaNo,
	a.PatientName as PatientNameEnglish,
	a.CountryIOTA as CountryID, 
	a.TransNbr,
	a.TransType,  
	a.transdateenglish,
	0 as DeductibleAmt,
	a.ExtraDiscountAmt,
	0 as DeductibleDiscountAmt, 
	0 as roundoffamt,  
	'Daily Collection'  as ServiceDescription,
	sum(b.qty*b.Price ) as Gross,
	sum(case when b.DiscAmt = 0 then (b.DiscPer * b.Qty * b.Price )/100 else b.discamt end) as DiscountAmt,
	sum(b.vatamt) as vatamt,
	case when a.CountryIOTA = 'SAU' then sum(b.VATAmt) else 0 end as VATExemption,
	a.Rejected as Reject  
FROM IBInvoiceGroup  a
LEFT OUTER JOIN ibInvoiceDetails b ON a.Trans_Key = b.Group_Key 
--where a.TransType ='Cash'
GROUP BY 
	a.TransNbr,
	a.TransType,  
	a.transdateenglish,
	a.ExtraDiscountAmt,
	a.CountryIOTA ,
	a.Rejected  ,
	a.RegistrationNo,
	a.Border_Iqama,
	a.PatientName
