










CREATE View [dbo].[EmployeeLeaveLatestApproval_View] As
SELECT [IdNo]
      ,[EmployeeLeaveApprovalIdNo]
      ,[EnteredBy]
      ,[LeaveIdNo]
      ,[StartDate]
      ,[EndDate]
      ,[FullDay]
      ,[ApprovedBy]
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
      ,[EnteredBy]
      ,[LeaveIdNo]
      ,[StartDate]
      ,[EndDate]
      ,[FullDay]
      ,[ApprovedBy]
      ,'0'
      ,[Note]
      ,[DateCreated]
	  ,[LeaveStatusDate]
	  ,[DateCreated]
      ,[EmployeeIdNo]
      ,[LeaveReason]
      ,[SupervisorIdNo]
 FROM EmployeeLeaveList_View b where b.LeaveStatus is Null