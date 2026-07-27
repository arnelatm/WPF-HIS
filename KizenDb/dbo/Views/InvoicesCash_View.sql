






















CREATE VIEW [dbo].[InvoicesCash_View]
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
		c.Total-c.TotalNoVat AS DiscountAmount, 
		c.TotalNoVat as AmountBeforeVat, 
		c.Net AS NetAmount, 
        c.VATPer, 
		Iif(c.VatPer<>0 and a.CustNat = 'سعودي Saudi Arabian',c.TotalNoVat,0) as VatableAmountSA,
		Iif(c.VatPer<>0 and a.CustNat <> 'سعودي Saudi Arabian',c.TotalNoVat,0) as VatableAmountNS,
		Iif(c.VatPer<>0 and a.CustNat = 'سعودي Saudi Arabian',(c.TotalNoVat) * abs(c.VATPer/100) ,0) as VatAmountSA,
		Iif(c.VatPer<>0 and a.CustNat <> 'سعودي Saudi Arabian',(c.TotalNoVat) * abs(c.VATPer/100) ,0) as VatAmountNS,
		Iif(c.VatPer=0, c.TotalNoVat,0) as ZeroVatRateAmount,
		c.VatExemption,
		f.CustomField1 as DrCode,
		IsNull(b.ParentId,0) as ParentId,
		c.UserName
FROM dbo.A1_Invoces as a
	left join dbo.a1_Invoces as b on a.Id = b.ParentId
	left JOIN dbo.A1_OrderWorks as c ON a.ID = c.OrderID 
	left JOIN dbo.A1_Works as d ON c.WorkID = d.Code 
	left join dbo.Drs as f on a.DrName = f.DrNmae 
	where a.IsInsurance = 0