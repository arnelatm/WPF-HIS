

CREATE VIEW [dbo].[OvertimeItem_View]
AS
SELECT        dbo.Employee.EmployeeCode, dbo.Employee.EmployeeName, dbo.Employee.EmployeeNameAra, dbo.OvertimeItem.IdNo, dbo.OvertimeItem.EmployeeIdNo, dbo.OvertimeItem.PayrollIdNo, 
                         dbo.OvertimeItem.OvertimeRegular, dbo.OvertimeItem.OvertimeHoliday, dbo.OvertimeItem.OvertimeSpecial
                         FROM dbo.Employee INNER JOIN
                         dbo.OvertimeItem ON dbo.Employee.IdNo = dbo.OvertimeItem.EmployeeIdNo
GO

