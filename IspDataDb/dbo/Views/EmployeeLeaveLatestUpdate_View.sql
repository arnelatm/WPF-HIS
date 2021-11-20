

CREATE View [dbo].[EmployeeLeaveLatestUpdate_View] As
SELECT [IdNo]
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
