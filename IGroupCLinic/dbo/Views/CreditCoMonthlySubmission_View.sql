CREATE VIEW CreditCoMonthlySubmission_View
 
AS
select 
	transnbr,
	registrationno,
	transdateenglish,
	qty,
	saleprice,
	discountper,
	discountamt,
	patientnameenglish,
	servicenameenglish,
	INSURANCEID AS INSURANCEGROUPID,
	'Clinic' as TransType
from clinicinvoice_view 
--where transdateenglish between '2014/05/01' and '2014/05/31' and insuranceid = '1008'
union all
select 
	transnbr,
	registrationno,
	transdateenglish,
	qty,
	saleprice,
	discountper,
	discountamt,
	patientnameenglish,
	itemnameenglish as servicenameenglish,
	INSURANCEID AS INSURANCEGROUPID,
	'Pharmacy' as TransType
from pharmacysales_view 
--where transdateenglish between '2014/05/01' and '2014/05/31' and insuranceid = '1008'
