
CREATE VIEW IBServicesAllowed_View
 
AS
SELECT  
		b.IBType,
		a.ServiceID,
		a.ServiceNameEnglish,
		a.ServiceNameArabic,
		a.CashPrice,
		a.CreditPrice,
		a.DiscountPercent, 
		a.DiscountAmt,
		a.NameChange,
		a.PriceChange,
		a.DiscountChange,
		CASE WHEN b.Activate IS NULL THEN 0 ELSE b.Activate end AS activate
FROM MedicalServices a
LEFT OUTER JOIN IBServicesAllowed b on a.ServiceID = b.ServiceID 
