
CREATE view 	Lab_Template_View
 
as
select
Distinct(TemplateID) as TemplateID,
TemplateName
from Lab_InvestigationTemplate 
