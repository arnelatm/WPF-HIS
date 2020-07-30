USE [ISPDATA]
GO

/****** Object:  View [dbo].[RevCostCenter_View]    Script Date: 10/03/2020 12:14:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




alter View [dbo].[RevCostCenter_View] as 
with cte as
(
select IdNo
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
select t.IdNo
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
   
select IdNo
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





GO

