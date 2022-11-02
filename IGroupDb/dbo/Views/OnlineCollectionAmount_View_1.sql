CREATE VIEW OnlineCollectionAmount_View
 
AS
select 
	TransDateEnglish,
	case when (TransType = 'CA' or TransType = 'Cash') then 'Cash' else 'Credit' end as TransType,
	DoctorID,
	sum(BillAmt) as BillAmt 
from ClinicInvoiceGroup 
Where (Reject is null or reject = 0)
Group By
	TransDateEnglish ,
	TransType ,
	DoctorID
union all 
select 
	TransDateEnglish,
	TransType,
	DoctorID,
	sum(NetAmt)  as BillAmt 
From IBInvoiceGroup 
Where (Rejected  is null or Rejected  = 0)
Group By
	TransDateEnglish ,
	TransType ,
	DoctorID