

CREATE View [dbo].[EmployeeLeaveLatestUpdate_View] As
SELECT TOP (1000) [IdNo]
      ,[AppliedBy]
      ,[LeaveIdNo]
      ,[StartDate]
      ,[EndDate]
      ,[FullDay]
      ,[EnteredBy]
      ,[Status]
      ,[Note]
      ,[LeaveStatusDate]
	  ,[LatestStatusUpdate]
  FROM [ISPDATA].[dbo].[EmployeeLeaveStatus_View]
  Union
  SELECT [IdNo]
      ,[AppliedBy]
      ,[LeaveIdNo]
      ,[StartDate]
      ,[EndDate]
      ,[FullDay]
      ,[EnteredBy]
      ,[Status]
      ,[Note]
      ,[DateCreated]
	  ,[LeaveStatusDate]
 FROM EmployeeLeave_View b where b.LeaveStatusIdNo is Null