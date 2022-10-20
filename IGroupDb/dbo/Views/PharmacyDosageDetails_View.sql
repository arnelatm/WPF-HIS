CREATE view	PharmacyDosageDetails_View
 
as
select 	a.*,
	b.ItemNameEnglish as item_name,
	c.ItemNameEnglish as Data_E,
	c.ItemNameArabic as data_a,
	d.UserNameenglish as users
from 	PharmacyDosageDetails A
Left Outer Join ItemDetails 		    B ON a.item_code=b.item_code and a.branchid=b.branchid
Left Outer Join MedicineDosageMaster	    C ON a.dosageid=c.itemid
Left Outer Join USERSbank	    	    D ON a.userid=d.userid