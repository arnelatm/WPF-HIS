






















CREATE VIEW [dbo].[InvoicesVat_View]
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
		c.DiscNet AS DiscountAmount, 
		c.InsuranceTahamal as AmountBeforeVat, 
		Iif(a.IsInsurance=1 and c.PatientTahamalPer=0,c.InsuranceTahamalAfterVAT,c.Net) AS NetAmount, 
        c.VATPer, 
		Iif(c.VatPer<>0 and a.CustNat = 'سعودي Saudi Arabian',IIf(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal,c.Total-c.DiscNet),0) as VatableAmountSA,
		Iif(c.VatPer<>0 and a.CustNat <> 'سعودي Saudi Arabian',Iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal,c.Total-c.DiscNet),0) as VatableAmountNS,
		Iif(c.VatPer<>0 and a.CustNat = 'سعودي Saudi Arabian',Iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal * abs(c.VATPer/100),(c.Total-c.DiscNet) * abs(c.VATPer/100)) ,0) as VatAmountSA,
		Iif(c.VatPer<>0 and a.CustNat <> 'سعودي Saudi Arabian',Iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,c.InsuranceTahamal * abs(c.VATPer/100),(c.Total-c.DiscNet) * abs(c.VATPer/100)) ,0) as VatAmountNS,
		Iif(c.VatPer=0, c.Total-c.DiscNet,0) as ZeroVatRateAmount,
		Iif(a.IsInsurance=1 and IsNull(a.InsuranceUpToPer,0) = 0,Iif(c.InsuranceTahamalVatValue=0,c.InsuranceTahamal * abs(c.VATPer/100),0),c.VatExemption) as VatExemption,
		f.CustomField1 as DrCode,
		IsNull(b.ParentId,0) as ParentId,
		e.LatinName as CompanyName,
		iif(a.IsInsurance=1 and c.PatientTahamalPer=0,1,0) as Cash,
		iif(p.Value>= 0,p.Value,0) as PayAmt,
		iif(p.Value < 0,p.Value*-1,0) as PayReturnAmt
FROM dbo.A1_Invoces as a
	left join dbo.a1_Invoces as b on a.Id = b.ParentId
	left JOIN dbo.A1_OrderWorks as c ON a.ID = c.OrderID 
	left JOIN dbo.A1_Works as d ON c.WorkID = d.Code 
	left join dbo.Drs as f on a.DrName = f.DrNmae 
	left JOIN dbo.Insurance_Company as e ON a.InsuranceCompany = e.Code
	LEFT JOIN dbo.A1_payments as p on a.ID = p.OrderId