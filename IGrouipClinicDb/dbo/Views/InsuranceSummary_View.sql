
CREATE VIEW InsuranceSummary_View
 
AS
SELECT  
	a.*,
--	0 AS CLAIMNO,
	case when b.AltServiceID is null then 0 else 1 end as ClaimNo,
	c.Logo 
from insuranceprocesseddata_view a
left outer join InsuranceConsultations_View b on a.serviceid = b.altserviceid and a.InsuranceGroupID = b.InsuranceID
left outer join InsuranceCoLogo c on a.InsuranceGroupID = c.InsuranceID