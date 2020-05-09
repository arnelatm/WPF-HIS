USE [ISPDATA]
GO

/****** Object:  View [dbo].[CostCenter_View]    Script Date: 3/9/2020 7:47:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER View [dbo].[CostCenter_View] as 
with cte as
(
select IdNo
      ,CostCenterCode
      ,CostCenterName
      ,CostCenterNameAra
      ,ParentIdNo
	  ,ProfitCenterIdNo
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by CostCenterName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by CostCenterName) / power(10.0,0) as SortKey
 
from CostCenter
where ParentIdNo IS NULL
union all
select t.IdNo
      ,t.CostCenterCode
      ,t.CostCenterName
      ,t.CostCenterNameAra
	  ,t.ParentIdNo
	  ,t.ProfitCenterIdNo
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.CostCenterName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.CostCenterName) / power(10.0,levelnumber+1)
 
 from
    cte
join CostCenter t on cte.IdNo = t.ParentIdNo
)
   
select IdNo
      ,CostCenterCode
      ,CostCenterName
      ,CostCenterNameAra
	  ,ParentIdNo
	  ,ProfitCenterIdNo
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte





GO


