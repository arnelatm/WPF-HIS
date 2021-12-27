
CREATE VIEW [dbo].[EmployeeLeave_ViewBackup]
AS
SELECT        dbo.EmployeeLeave.EmployeeIdNo, dbo.EmployeeLeave.IdNo, dbo.EmployeeLeave.LeaveIdNo, dbo.EmployeeLeave.StartDate, dbo.EmployeeLeave.EndDate, dbo.EmployeeLeave.FullDay, dbo.EmployeeLeave.EnteredBy, 
                         dbo.EmployeeLeave.LeaveReason, dbo.EmployeeLeave.DateCreated, dbo.EmployeeLeave.DateTimeStamp, dbo.EmployeeLeaveLatestApproval_View.SupervisorIdNo, 
                         dbo.EmployeeLeaveLatestApproval_View.LatestStatusUpdate, dbo.EmployeeLeaveLatestApproval_View.LeaveStatus, dbo.EmployeeLeave.HolidayIdNo
FROM            dbo.EmployeeLeave INNER JOIN
                         dbo.EmployeeLeaveLatestApproval_View ON dbo.EmployeeLeave.IdNo = dbo.EmployeeLeaveLatestApproval_View.IdNo