
CREATE VIEW InsuranceCategory_View
 
AS
SELECT  a.*,
	b.ItemNameEnglish as NameEnglish,
	b.ItemNameArabic as NameArabic
FROM InsuranceCategory a
LEFT OUTER JOIN DeductibleClassMaster b ON a.CategoryID = b.ItemID