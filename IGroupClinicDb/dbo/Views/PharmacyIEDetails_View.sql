
CREATE VIEW PharmacyIEDetails_View
 
AS
SELECT 
a.*,
b.ItemNameEnglish as BeneficiaryDescription
From PharmacyIEDetails a
LEFT OUTER JOIN BeneficiaryMaster b on a.AcCode = b.ItemID