
CREATE view 	DoctorsCombinedIncome_View
 
as
select 		DoctorID			,
		DoctorNameEnglish			,
		TransDateEnglish			,
		BillType			,
		(case ltrim(BillType) when 'CA' then (sum(grosscon)+sum(grossmct)+sum(grossxry)+sum(grosslab)+sum(grossdnt)+sum(grossoph)+sum(grosscmd)+sum(grossphr))- 
		(sum(disccon)+sum(discmct)+sum(discxry)+sum(disclab)+sum(discdnt)+sum(discoph)+sum(disccmd)+sum(discphr)+sum(clndeddiscamt)) else 0 end) as NetCash,
		(case ltrim(BillType) when 'CR' then (sum(grosscon)+sum(grossmct)+sum(grossxry)+sum(grosslab)+sum(grossdnt)+sum(grossoph)+sum(grosscmd)+sum(grossphr))- 
		(sum(disccon)+sum(discmct)+sum(discxry)+sum(disclab)+sum(discdnt)+sum(discoph)+sum(disccmd)+sum(discphr)+sum(clndedamt)) else 0 end) as NetCredit,
		sum(clndedamt) as NetDeductible,
		sum(clndeddiscamt) as NetDisDedu
from 		DailyCollectionDepartmentWiseClinic_View
group by 	DoctorID			,
		DoctorNameEnglish			,
		transdateenglish			,
		billtype
