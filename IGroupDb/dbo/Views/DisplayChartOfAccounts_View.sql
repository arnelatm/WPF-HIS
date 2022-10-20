
CREATE VIEW DisplayChartOfAccounts_View
 
AS
Select 	PrimaryGroupID,
	GroupCategory,
	OrderBy,
	Grp_Sgrp,
	Grp_SgrpArabic,
	OpeningBalance,
	CreditAmt,
	DebitAmt,
	case when groupcategory = '1' 
	     then 'Liability' 
             else 
		case when groupcategory = '2' 
		     then 'Assets' 
		     else 
			case when groupcategory = '3' 
			     then 'Income' 
 			     else  'Expense' 
			end 
		end 
	end as MainGroups,  
	case when groupcategory = '1' 
	     then 'مسئولية' 
             else 
		case when groupcategory = '2' 
		     then 'ممتلكات' 
		     else 
			case when groupcategory = '3' 
			     then 'دخل' 
 			     else  'نفقات' 
			end 
		end 
	end as MainGroupsArabic,  
	groupid,
	space((orderby-1)*5)+GroupName as [Account Head],
	space((orderby-1)*5)+GroupNameArabic as [Account Head Arabic],
	Parent as [Parent Head],
	ParentArabic as [Parent Head Arabic],
	Grp_Sgrp  as [Nature],
	Grp_SgrpArabic as [NatureArabic]
From     ChartOfAccounts_View