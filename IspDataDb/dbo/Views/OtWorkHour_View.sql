

CREATE VIEW [dbo].[OtWorkHour_View]
AS
SELECT        dbo.Employee.EmployeeCode, dbo.Employee.EmployeeName, dbo.Employee.EmployeeNameAra, dbo.OtWorkHour.IdNo, dbo.OtWorkHour.EmployeeIdNo, dbo.OtWorkHour.PayrollIdNo, 
                         dbo.OtWorkHour.OvertimeRegular, dbo.OtWorkHour.OvertimeHoliday, dbo.OtWorkHour.OvertimeSpecial
                         FROM dbo.Employee INNER JOIN
                         dbo.OtWorkHour ON dbo.Employee.IdNo = dbo.OtWorkHour.EmployeeIdNo
GO

