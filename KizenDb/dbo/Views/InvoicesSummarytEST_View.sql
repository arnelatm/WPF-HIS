





























CREATE VIEW [dbo].[InvoicesSummarytEST_View]
AS
SELECT c.OrderID AS InvoiceNo, 
		Cast(a.Date as Date) as InvoiceDate, 
		a.Date as InvoiceDateTime, 
		a.IsInsurance, 
        a.InsuranceCompany AS CompanyCode, 
		a.IsReturn as IsReturn, 
		Sum(c.Total) as Total, 
		Sum(c.DiscNet+IsNull(c.GeneralDiscount,0)) AS DiscountAmount, 
		Sum(iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal,c.TotalNoVat)) as AmountBeforeVat, 
		Sum(Iif(a.IsInsurance=1 and c.PatientTahamalPer=0,c.InsuranceTahamalAfterVAT,c.Net)) AS NetAmount, 
        Sum(Iif(c.VatPer<>0 and a.CustNat = 'سعودي Saudi Arabian',IIf(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal,c.TotalNoVat),0)) as VatableAmountSA,
		Sum(Iif(c.VatPer<>0 and a.CustNat <> 'سعودي Saudi Arabian',Iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal,c.TotalNoVat),0)) as VatableAmountNS,
		Sum(Iif(c.VatPer<>0 and a.CustNat = 'سعودي Saudi Arabian',Iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal * abs(c.VATPer/100),(c.TotalNoVat) * abs(c.VATPer/100)) ,0)) as VatAmountSA,
		Sum(Iif(c.VatPer<>0 and a.CustNat <> 'سعودي Saudi Arabian',Iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal * abs(c.VATPer/100),(c.TotalNoVat) * abs(c.VATPer/100)) ,0)) as VatAmountNS,
		Sum(IIf(c.VatPer=0,Iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal,c.TotalNoVat),0)) as ZeroVatRateAmount,
		Sum(Iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,Iif(c.InsuranceTahamalVatValue=0,c.InsuranceTahamal * abs(c.VATPer/100),0),c.VatExemption)) as VatExemption,
		iif(a.IsInsurance=1 and c.PatientTahamalPer=0,1,0) as Cash
FROM 	dbo.A1_OrderWorks as c 
	left join dbo.A1_Invoces as a ON a.ID = c.OrderID  
	left join dbo.Drs as f on a.DrName = f.DrNmae 
	left JOIN dbo.Insurance_Company as e ON a.InsuranceCompany = e.Code
	group by c.OrderId,a.Date,a.IsInsurance,a.InsuranceCompany,a.IsReturn,iif(a.IsInsurance=1 and c.PatientTahamalPer=0,1,0)