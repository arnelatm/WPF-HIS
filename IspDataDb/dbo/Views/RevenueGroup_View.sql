



Create View [dbo].[RevenueGroup_View] as 
with cte as
(
select IDNo
      ,RevenueGroupCode
      ,RevenueGroupName
      ,RevenueGroupNameAra
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by RevenueGroupName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by RevenueGroupName) / power(10.0,0) as SortKey
 
from RevenueGroup
where ParentIdNo IS NULL
union all
select t.IDNo
      ,t.RevenueGroupCode
      ,t.RevenueGroupName
      ,t.RevenueGroupNameAra
      ,t.ParentIdNo
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.RevenueGroupName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.RevenueGroupName) / power(10.0,levelnumber+1)
 
 from
    cte
join RevenueGroup t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
      ,RevenueGroupCode
      ,RevenueGroupName
      ,RevenueGroupNameAra
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte





