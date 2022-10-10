


CREATE View [dbo].[Department_View] as 
with cte as
(
select IDNo
      ,DepartmentCode
      ,DepartmentName
      ,DepartmentNameAra
      ,ParentIdNo
      ,Notes
      ,RevCostCenterIDNo
      ,Active
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by DepartmentName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by DepartmentName) / power(10.0,0) as SortKey
 
from Department
where ParentIdNo IS NULL
union all
select t.IDNo
      ,t.DepartmentCode
      ,t.DepartmentName
      ,t.DepartmentNameAra
      ,t.ParentIdNo
      ,t.Notes
      ,t.RevCostCenterIdNo
      ,t.Active
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.DepartmentName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.DepartmentName) / power(10.0,levelnumber+1)
 
 from
    cte
join Department t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
      ,DepartmentCode
      ,DepartmentName
      ,DepartmentNameAra
      ,ParentIdNo
      ,Notes
      ,RevCostCenterIdNo
      ,Active
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte
