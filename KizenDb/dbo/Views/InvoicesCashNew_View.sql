
















CREATE VIEW [dbo].[InvoicesCashNew_View]
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
		c.TotalNoVAT as AmountBeforeVat, 
		c.Net as NetAmount, 
        c.VATPer, 
		Iif(c.VatPer<>0 and a.CustNat = 'سعودي Saudi Arabian',c.InsuranceTahamal,0) as VatableAmountSA,
		Iif(c.VatPer<>0 and a.CustNat <> 'سعودي Saudi Arabian',c.InsuranceTahamal,0) as VatableAmountNS,
		VatValue, 
		VatExemption,
		e.LatinName AS CompanyName,
		f.CustomField1 as DrCode,
		Iif(c.VatPer=0,c.TotalNoVat,0) as VatExemptAmt,
		IsNull(b.ParentId,0) as ParentId
FROM dbo.A1_Invoces as a
	left join dbo.a1_Invoces as b on a.Id = b.ParentId
	left JOIN dbo.A1_OrderWorks as c ON a.ID = c.OrderID 
	left JOIN dbo.A1_Works as d ON c.WorkID = d.Code 
	LEFT JOIN dbo.Insurance_Company as e ON a.InsuranceCompany = e.Code
	left join dbo.Drs as f on a.DrName = f.DrNmae 
	Left join dbo.[Insurance_Policy] g on a.InsurancePolicy = g.Code and a.InsuranceCompany = g.CompanyCode
	where g.UpToPer is Null or g.UpToPer=100