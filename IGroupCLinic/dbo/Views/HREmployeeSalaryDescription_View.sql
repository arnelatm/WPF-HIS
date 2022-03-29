
CREATE VIEW HREmployeeSalaryDescription_View
 
AS
select 	a.empid,
	a.empnameenglish,
	a.DepartmentID,
	c.Department,
	b.Basic,
	b.HRA,
	b.Food,
	b.Transport,
	b.Uniform,
	b.Washing,
	b.Education,
	b.YearlyBonus,
	case when b.MedicalApply=1 then 'Yes' else 'No' end as MedicalApply,
	b.Medical,
	case when b.OTApply=1 then 'Yes' else 'No' end as OTApply,
	case when b.ServiceBenefitsApply=1 then 'Yes' else 'No' end as ServiceBenefitsApply, 
	b.ServiceBenefits,
	b.Others as OtherBenefits,
	b.GOSI,
	a.ServiceStatus
from HREmployeeDetails a
left outer join HREmployeeSalarymaster b on a.empid = b.empid
left outer join EmployeeDepartment c on a.DepartmentID = c.DeptID
