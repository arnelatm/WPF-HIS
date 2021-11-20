






CREATE View [dbo].[EmployeeLeaveLatestUpdate_View] As
SELECT [IdNo]
      ,[AppliedBy]
      ,[LeaveIdNo]
      ,[StartDate]
      ,[EndDate]
      ,[FullDay]
      ,[EnteredBy]
      ,[Status] as 'LeaveStatus'
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
      ,'0'
      ,[Note]
      ,[DateCreated]
	  ,[LeaveStatusDate]
	  ,[DateCreated]
      ,[EmployeeIdNo]
      ,[LeaveReason]
      ,[SupervisorIdNo]
 FROM EmployeeLeave_View b where b.LeaveStatus is Null
