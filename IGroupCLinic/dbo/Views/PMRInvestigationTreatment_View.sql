CREATE View PMRInvestigationTreatment_View
 
as 
select * from pmrinvestigationdetail_View
union all
select * from pmrtreatmentdetail_view
