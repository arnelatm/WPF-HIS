





CREATE View [dbo].[PayGroup_View] as 
with cte as
(
select IDNo
      ,PayGroupCode
      ,PayGroupName
      ,PayGroupNameAra
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by PayGroupName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by PayGroupName) / power(10.0,0) as SortKey
 
from PayGroup
where ParentIdNo IS NULL
union all
select t.IDNo
      ,t.PayGroupCode
      ,t.PayGroupName
      ,t.PayGroupNameAra
	  ,t.ParentIdNo
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.PayGroupName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.PayGroupName) / power(10.0,levelnumber+1)
 
 from
    cte
join PayGroup t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
      ,PayGroupCode
      ,PayGroupName
      ,PayGroupNameAra
	  ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte





