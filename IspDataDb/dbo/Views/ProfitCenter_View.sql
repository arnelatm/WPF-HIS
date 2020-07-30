



CREATE View [dbo].[RevCostCenter_View] as 
with cte as
(
select IDNo
      ,RevCostCenterCode
      ,RevCostCenterName
      ,RevCostCenterNameAra
	  ,RevCostCenterType
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by RevCostCenterName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by RevCostCenterName) / power(10.0,0) as SortKey
 
from RevCostCenter
where ParentIdNo IS NULL
union all
select t.IDNo
      ,t.RevCostCenterCode
      ,t.RevCostCenterName
      ,t.RevCostCenterNameAra
	  ,t.RevCostCenterType
      ,t.ParentIdNo
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.RevCostCenterName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.RevCostCenterName) / power(10.0,levelnumber+1)
 
 from
    cte
join RevCostCenter t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
      ,RevCostCenterCode
      ,RevCostCenterName
      ,RevCostCenterNameAra
	  ,RevCostCenterType
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte





