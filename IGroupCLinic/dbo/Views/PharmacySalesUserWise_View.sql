CREATE VIEW PharmacySalesUserWise_View
 
AS
SELECT 
	*
FROM PharmacySales_View 
Where TransType = 'CA' 
--AND (salestatus = '' or salestatus is null)
