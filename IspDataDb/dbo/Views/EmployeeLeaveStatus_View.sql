
CREATE View [dbo].[EmployeeLeaveStatus_View] 
AS
SELECT *
FROM EmployeeLeaveStatusList_View a
INNER JOIN
    (SELECT EmployeeLeaveIdNo, MAX(DateCreated) AS LatestStatusUpdate
    FROM EmployeeLeaveStatus
    GROUP BY EmployeeLeaveIdNo) b
ON a.IdNo = b.EmployeeLeaveIdNo AND a.LeaveStatusDate = b.LatestStatusUpdate
