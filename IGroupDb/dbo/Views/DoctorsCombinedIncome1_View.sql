--- Sum of DoctorsCombinedIncome_View
CREATE view 	DoctorsCombinedIncome1_View
 
as
select 		DoctorID			,
		DoctorNameEnglish			,
		TransDateEnglish			,
		sum(NetCash) as NetCash,
		sum(NetCredit) as NetCredit,
		sum(NetDeductible) as NetDeductible,
		sum(NetDisDedu) as NetDisDedu
from 		DoctorsCombinedIncome_View
group by 	DoctorID			,
		DoctorNameEnglish			,
		transdateenglish