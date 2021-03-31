




CREATE VIEW [dbo].[PayrollReport_View]
AS
SELECT       dbo.PayrollDetail.PayrollIdNo,dbo.PayrollDetail.EmployeeIdNo, Sum(IIf(dbo.PayElement.PayElementKind='E',dbo.PayrollPayELement.Amount,dbo.PayrollPayElement.Amount*-1)) as TotalAmount,
				Sum(IIf(dbo.PayElement.PayElementKind='E',dbo.PayrollPayELement.Amount,0)) as TotalEarning, 
				Sum(IIf(dbo.PayElement.PayElementKind<>'E',dbo.PayrollPayELement.Amount,0)) as TotalDeduction,dbo.PayElement.ReportGroupIdNo
FROM            dbo.PayElement RIGHT OUTER JOIN
                         dbo.PayrollPayElement INNER JOIN
                         dbo.PayrollDetail ON dbo.PayrollPayElement.PayrollDetailIdNo = dbo.PayrollDetail.IdNo ON dbo.PayElement.IdNo = dbo.PayrollPayElement.PayElementIdNo
Group by payrollIdNo,EmployeeIdNo,ReportGroupIdNo