













CREATE VIEW [dbo].[InvoicesCredit_View]
AS
SELECT dbo.A1_Invoces.ID AS InvoiceNo, 
		Cast(dbo.A1_Invoces.Date as Date) as InvoiceDate, 
		dbo.A1_Invoces.CustID, 
		dbo.A1_Invoces.CustName, 
		dbo.A1_Invoces.Type, 
		dbo.A1_Invoces.DrName, 
		dbo.A1_Invoces.DrID, 
		dbo.A1_Invoces.IsInsurance, 
        dbo.A1_Invoces.InsuranceCompany AS CompanyCode, 
		dbo.A1_Invoces.CustIdentity, 
		dbo.A1_Invoces.CustNat, 
		dbo.A1_Invoces.Clinic, 
		dbo.A1_Invoces.IsReturn, 
		dbo.A1_OrderWorks.ID AS InvoiceDetailId, 
		dbo.A1_Works.Code, 
        dbo.A1_Works.Name AS ItemName, 
		dbo.A1_OrderWorks.Count, 
		dbo.A1_OrderWorks.Price, 
		dbo.A1_OrderWorks.Total, 
		dbo.A1_OrderWorks.DiscNet AS DiscountAmount, 
		dbo.A1_OrderWorks.InsuranceTahamal as AmountBeforeVat, 
		dbo.A1_OrderWorks.InsuranceTahamalAfterVAT AS NetAmount, 
        dbo.A1_OrderWorks.VATPer, 
		Iif(dbo.A1_OrderWorks.VatPer<>0 and dbo.A1_Invoces.CustNat = 'سعودي Saudi Arabian',dbo.A1_OrderWorks.InsuranceTahamal,0) as VatableAmountSA,
		Iif(dbo.A1_OrderWorks.VatPer<>0 and dbo.A1_Invoces.CustNat <> 'سعودي Saudi Arabian',dbo.A1_OrderWorks.InsuranceTahamal,0) as VatableAmountNS,
		dbo.A1_OrderWorks.InsuranceTahamal * abs(dbo.A1_OrderWorks.VATPer/100) as VatValue, 
		Iif(dbo.A1_Invoces.CustNat = 'سعودي Saudi Arabian',dbo.A1_OrderWorks.InsuranceTahamal * abs(dbo.A1_OrderWorks.VATPer/100),0) as VatExemption,
		dbo.Insurance_Company.LatinName AS CompanyName,
		dbo.Drs.CustomField1 as DrCode,
		Iif(dbo.A1_OrderWorks.VatPer=0,dbo.A1_OrderWorks.InsuranceTahamal,0) as VatExemptAmt
FROM dbo.A1_Invoces 
	INNER JOIN dbo.A1_OrderWorks ON dbo.A1_Invoces.ID = dbo.A1_OrderWorks.OrderID 
	left JOIN dbo.A1_Works ON dbo.A1_OrderWorks.WorkID = dbo.A1_Works.Code 
	LEFT JOIN dbo.Insurance_Company ON dbo.A1_Invoces.InsuranceCompany = dbo.Insurance_Company.Code
	left join dbo.Drs on dbo.A1_Invoces.DrName = dbo.Drs.DrNmae 
	Left join dbo.[Insurance_Policy] on dbo.A1_Invoces.InsurancePolicy = dbo.Insurance_Policy.Code and dbo.A1_Invoces.InsuranceCompany = dbo.Insurance_Policy.CompanyCode
	where dbo.Insurance_Policy.UpToPer=0
