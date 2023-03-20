
CREATE VIEW IBForms_View
 
AS

Select a.*,
		b.BranchNameEnglish,
		b.BranchNameArabic,
		c.CountryNameEng 
From IBInvoiceGroup a
Left Outer Join BranchDetails b on a.BranchID  = b.branchID 
left outer join CountryMaster c on a.CountryIOTA = c.CountryIOTA 
left outer join IQAMAProfessionMaster d on a.Profession = d.ItemID