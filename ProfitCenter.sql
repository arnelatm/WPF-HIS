USE [ISPDATA]
GO

/****** Object:  View [dbo].[ProfitCenter_View]    Script Date: 10/03/2020 12:14:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




alter View [dbo].[ProfitCenter_View] as 
with cte as
(
select IdNo
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
select t.IdNo
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
   
select IdNo
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





GO

