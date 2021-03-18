




CREATE View [dbo].[ProfitCenter_View] as 
with cte as
(
select IDNo
      ,ProfitCenterCode
      ,ProfitCenterName
      ,ProfitCenterNameAra
	  ,ProfitCenterType
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by ProfitCenterName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by ProfitCenterName) / power(10.0,0) as SortKey
 
from ProfitCenter
where ParentIdNo IS NULL
union all
select t.IDNo
      ,t.ProfitCenterCode
      ,t.ProfitCenterName
      ,t.ProfitCenterNameAra
	  ,t.ProfitCenterType
      ,t.ParentIdNo
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.ProfitCenterName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.ProfitCenterName) / power(10.0,levelnumber+1)
 
 from
    cte
join ProfitCenter t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
      ,ProfitCenterCode
      ,ProfitCenterName
      ,ProfitCenterNameAra
	  ,ProfitCenterType
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte