
CREATE VIEW AccountsAgeingSummary_View
 
AS
select 
		a.SupplierID,
		a.SupplierNameEnglish,
		a.SupplierNameArabic, 
		c.vdate,
		sum(c.cramt) as Amt
from SupplierDetails a
left outer join AccountsVoucher_view c on a.AC_Code  = c.LedgerID 
where c.vtype = 'PUJ' or c.VType = 'PMT' and (c.CrAmt <> 0)
and c.status = 1
group by
a.SupplierID,
a.SupplierNameEnglish,
a.SupplierNameArabic, 
c.VDate  
