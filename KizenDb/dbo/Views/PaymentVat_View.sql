























CREATE VIEW [dbo].[PaymentVat_View]
AS
SELECT i.ID AS InvoiceNo, 
		Cast(p.Date as Date) as InvoiceDate, 
		i.CustID, 
		i.CustName, 
		i.Type, 
		i.DrName, 
		i.DrID, 
		i.IsInsurance, 
        i.InsuranceCompany AS CompanyCode, 
		i.CustIdentity, 
		i.CustNat, 
		i.Clinic, 
		i.IsReturn, 
		c.ID AS InvoiceDetailId, 
		d.Code, 
        d.Name AS ItemName, 
		c.Count, 
		c.Price, 
		c.Total, 
		c.DiscNet AS DiscountAmount, 
		c.InsuranceTahamal as AmountBeforeVat, 
		Iif(i.IsInsurance=1 and c.PatientTahamalPer=0,c.InsuranceTahamalAfterVAT,P.Value) AS NetAmount, 
        c.VATPer, 
		Iif(c.VatPer<>0 and i.CustNat = 'سعودي Saudi Arabian',IIf(i.IsInsurance=1 and IsNull(i.InsuranceUpToPer,0) = 0,c.InsuranceTahamal,c.Total-c.DiscNet),0) as VatableAmountSA,
		Iif(c.VatPer<>0 and i.CustNat <> 'سعودي Saudi Arabian',Iif(i.IsInsurance=1 and IsNull(i.InsuranceUpToPer,0) = 0,c.InsuranceTahamal,c.Total-c.DiscNet),0) as VatableAmountNS,
		Iif(c.VatPer<>0 and i.CustNat = 'سعودي Saudi Arabian',Iif(i.IsInsurance=1 and IsNull(i.InsuranceUpToPer,0) = 0,c.InsuranceTahamal * abs(c.VATPer/100),(c.Total-c.DiscNet) * abs(c.VATPer/100)) ,0) as VatAmountSA,
		Iif(c.VatPer<>0 and i.CustNat <> 'سعودي Saudi Arabian',Iif(i.IsInsurance=1 and IsNull(i.InsuranceUpToPer,0) = 0,c.InsuranceTahamal * abs(c.VATPer/100),(c.Total-c.DiscNet) * abs(c.VATPer/100)) ,0) as VatAmountNS,
		Iif(c.VatPer=0, c.Total-c.DiscNet,0) as ZeroVatRateAmount,
		Iif(i.IsInsurance=1 and IsNull(i.InsuranceUpToPer,0) = 0,Iif(c.InsuranceTahamalVatValue=0,c.InsuranceTahamal * abs(c.VATPer/100),0),c.VatExemption) as VatExemption,
		f.CustomField1 as DrCode,
		IsNull(b.ParentId,0) as ParentId,
		e.LatinName as CompanyName,
		iif(i.IsInsurance=1 and c.PatientTahamalPer=0,1,0) as Cash,
		iif(p.Value>= 0,p.Value,0) as PayAmt,
		iif(p.Value < 0,p.Value*-1,0) as PayReturnAmt
FROM dbo.A1_payments as p 
	left join dbo.A1_Invoces as i on i.ID = p.OrderId
	left join dbo.a1_Invoces as b on i.Id = b.ParentId
	left JOIN dbo.A1_OrderWorks as c ON i.ID = c.OrderID 
	left JOIN dbo.A1_Works as d ON c.WorkID = d.Code 
	left join dbo.Drs as f on i.DrName = f.DrNmae 
	left JOIN dbo.Insurance_Company as e ON i.InsuranceCompany = e.Code