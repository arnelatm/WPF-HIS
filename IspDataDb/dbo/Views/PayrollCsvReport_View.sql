







CREATE VIEW [dbo].[PayrollCsvReport_View]
AS
SELECT      dbo.PayrollDetail.PayrollIdNo as 'PayrollIdNo',
			dbo.Bank.BankCode as 'BankName',
			dbo.Employee.IBAN as 'AcctNo',
			Sum(IIf(dbo.PayElement.PayElementKind='E',dbo.PayrollPayELement.Amount,dbo.PayrollPayElement.Amount*-1)) as 'NetPay',
			'' as 'Notes',
			dbo.Employee.EmployeeName as 'EmpName',
			dbo.Employee.NationalIdNo as 'IqamaNo',
			'Jeddah' as 'Address',
			Sum(Iif(dbo.PayElementGroup.PayElementGroupCode = 'BP',dbo.PayrollPayElement.Amount,0)) as 'SalaryEr',
			Sum(Iif(dbo.PayElementGroup.PayElementGroupCode  = 'HA',dbo.PayrollPayElement.Amount,0)) as 'Housing',
			Sum(IIf(dbo.PayElement.PayElementKind='E' and dbo.PayElementGroup.PayElementGroupCode <>'BP' and dbo.PayElementGroup.PayElementGroupCode <>'HA',dbo.PayrollPayELement.Amount,0)) as 'OtherWage',
			Sum(IIf(dbo.PayElement.PayElementKind='D',dbo.PayrollPayELement.Amount,0)) as 'Deductions'
FROM        dbo.PayrollPayElement
			Left Join dbo.PayElement 
			on dbo.PayrollPayElement.PayElementIdNo = dbo.PayElement.IdNo
			INNER JOIN dbo.PayrollDetail 
			ON dbo.PayrollPayElement.PayrollDetailIdNo = dbo.PayrollDetail.IdNo 
			INNER JOIN dbo.Employee
			ON dbo.PayrollDetail.EmployeeIdNo = dbo.Employee.IdNo
			LEFT JOIN dbo.Bank
			On dbo.Employee.BankIdNo = dbo.Bank.IdNo
			LEFT JOIN dbo.PayElementGroup
			on dbo.PayElement.ReportGroupIdNo = dbo.PayElementGroup.IdNo
			where dbo.Employee.Sponsor=1 or dbo.Employee.NationalityCode = 'SA'
Group by dbo.PayrollDetail.PayrollIdNo,payrollIdNo,EmployeeIdNo,IBAN,ReportGroupIdNo,dbo.Bank.BankCode,dbo.Employee.BankAccountNo,dbo.Employee.EmployeeName,dbo.Employee.NationalIdNo