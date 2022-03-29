
CREATE VIEW InsuranceConsultations_View
 
AS
select  b.insuranceid,
	b.altserviceid,
	a.serviceid 
from consultationservice a
left outer join insurancealtservicepricelist b on a.serviceid = b.serviceid 
where not b.altserviceid is null AND B.ALTSERVICEID <> '' 
