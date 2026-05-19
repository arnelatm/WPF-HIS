


/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[vw_employees]
as
  SELECT e.[id]
      ,e.[emp_code]
      ,e.[emp_code_digit]
      ,e.[first_name]
      ,e.[last_name]
      ,e.[gender]    
	  ,d.[dept_name] as Department
  FROM [dbo].[personnel_employee] e
  left join [dbo].[personnel_department] d
  on e.department_id = d.id
