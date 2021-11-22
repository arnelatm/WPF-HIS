








CREATE View [dbo].[EmployeeLeaveLatestUpdate_View] As
SELECT [IdNo]
      ,[EmployeeLeaveApprovalIdNo]
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
  FROM [EmployeeLeaveApproval_View]
  Union
  SELECT [IdNo]
      ,Null
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
