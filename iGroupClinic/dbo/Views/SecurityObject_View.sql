






CREATE View [dbo].[SecurityObject_View] as 
with cte as
(
select IDNo
      ,SecurityObjectName
	  ,SecurityObjectCode
      ,SecurityObjectNameAra
      ,ParentIdNo
      ,Notes
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by ParentIdNo) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by ParentIdNo) / power(1000.0,0) as SortKey
 
from SecurityObject
where ParentIdNo IS NULL
union all
select t.IDNo
      ,t.SecurityObjectName
  	  ,t.SecurityObjectCode
      ,t.SecurityObjectNameAra
      ,t.ParentIdNo
      ,t.Notes
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.SecurityObjectName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.SecurityObjectName) / power(1000.0,levelnumber+1)
 
 from
    cte
join SecurityObject t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
      ,SecurityObjectName
  	  ,SecurityObjectCode
      ,SecurityObjectNameAra
      ,ParentIdNo
      ,Notes
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte


