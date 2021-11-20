

CREATE View [dbo].[EmployeeLeaveStatusUpdate_View] As
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
  FROM [EmployeeLeaveStatus_View]
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
 FROM EmployeeLeave_View b where b.LeaveStatus is Null