

















CREATE VIEW [dbo].[InvoicesCreditNew_View]
AS
SELECT a.ID AS InvoiceNo, 
		Cast(a.Date as Date) as InvoiceDate, 
		a.CustID, 
		a.CustName, 
		a.Type, 
		a.DrName, 
		a.DrID, 
		a.IsInsurance, 
        a.InsuranceCompany AS CompanyCode, 
		a.CustIdentity, 
		a.CustNat, 
		a.Clinic, 
		a.IsReturn, 
		c.ID AS InvoiceDetailId, 
		d.Code, 
        d.Name AS ItemName, 
		c.Count, 
		c.Price, 
		c.Total, 
		c.DiscNet+IsNull(c.GeneralDiscount,0) AS DiscountAmount, 
		iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal,c.TotalNoVat) as AmountBeforeVat, 
		Iif(a.IsInsurance=1 and c.PatientTahamalPer=0,c.InsuranceTahamalAfterVAT,c.Net) AS NetAmount, 
		c.VATPer, 
		Iif(c.VatPer<>0 and a.CustNat = 'سعودي Saudi Arabian',IIf(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal,c.TotalNoVat),0) as VatableAmountSA,
		Iif(c.VatPer<>0 and a.CustNat <> 'سعودي Saudi Arabian',Iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal,c.TotalNoVat),0) as VatableAmountNS,
		Iif(c.VatPer<>0 and a.CustNat = 'سعودي Saudi Arabian',Iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal * abs(c.VATPer/100) ,Round(c.TotalNoVat * abs(c.VATPer/100),2 )) ,0) as VatAmountSA,
		Iif(c.VatPer<>0 and a.CustNat <> 'سعودي Saudi Arabian',Iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal * abs(c.VATPer/100),Round(c.TotalNoVat * abs(c.VATPer/100),2 )) ,0) as VatAmountNS,
		IIf(c.VatPer=0,Iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal,c.TotalNoVat),0) as ZeroVatRateAmount,
		Iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,Iif(c.InsuranceTahamalVatValue=0,c.InsuranceTahamal * abs(c.VATPer/100),0),c.VatExemption) as VatExemption,
		iif(a.IsInsurance=1 and c.PatientTahamalPer=0,1,0) as Cash,
		c.InsuranceTahamal * abs(c.VATPer/100) as VatValue, 
		Convert(Varchar(100),e.LatinName) AS CompanyName,
		f.CustomField1 as DrCode,
		Iif(c.VatPer=0,c.InsuranceTahamal,0) as VatExemptAmt,
		IsNull(b.ParentId,0) as ParentId
FROM dbo.A1_Invoces as a
	left join dbo.a1_Invoces as b on a.Id = b.ParentId
	left JOIN dbo.A1_OrderWorks as c ON a.ID = c.OrderID 
	left JOIN dbo.A1_Works as d ON c.WorkID = d.Code 
	LEFT JOIN dbo.Insurance_Company as e ON a.InsuranceCompany = e.Code
	left join dbo.Drs as f on a.DrName = f.DrNmae 
	Left join dbo.[Insurance_Policy] g on a.InsurancePolicy = g.Code and a.InsuranceCompany = g.CompanyCode
	where g.UpToPer=0