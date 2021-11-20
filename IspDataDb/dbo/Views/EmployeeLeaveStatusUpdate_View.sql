



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
	  ,[DateCreated]
      ,[EmployeeIdNo]
      ,[LeaveReason]
      ,[SupervisorIdNo]
  FROM [EmployeeLeaveStatus_View]
  Union
  SELECT [IdNo]
      ,[AppliedBy]
      ,[LeaveIdNo]
      ,[StartDate]
      ,[EndDate]
      ,[FullDay]
      ,[EnteredBy]
      ,[LeaveStatus]
      ,[Note]
      ,[DateCreated]
	  ,[LeaveStatusDate]
	  ,[DateCreated]
      ,[EmployeeIdNo]
      ,[LeaveReason]
      ,[SupervisorIdNo]
 FROM EmployeeLeave_View b where b.LeaveStatus is Null