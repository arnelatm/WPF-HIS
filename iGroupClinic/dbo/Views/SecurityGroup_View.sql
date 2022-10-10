







CREATE View [dbo].[SecurityGroup_View] as 
with cte as
(
select IDNo
	  ,SecurityGroupCode
      ,SecurityGroupName
      ,SecurityGroupNameAra
      ,ParentIdNo
      ,Notes
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by ParentIdNo) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by  SecurityGroupName) / power(1000.0,0) as SortKey
 
from SecurityGroup
where ParentIdNo IS NULL
union all
select t.IDNo
	  ,t.SecurityGroupCode
      ,t.SecurityGroupName
      ,t.SecurityGroupNameAra
      ,t.ParentIdNo
      ,t.Notes
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.SecurityGroupName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.SecurityGroupName) / power(1000.0,levelnumber+1)
 
 from
    cte
join SecurityGroup t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
	  ,SecurityGroupCode
      ,SecurityGroupName
      ,SecurityGroupNameAra
      ,ParentIdNo
      ,Notes
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte