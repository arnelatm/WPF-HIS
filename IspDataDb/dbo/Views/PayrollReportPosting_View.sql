

















CREATE VIEW [dbo].[PayrollReportPosting_View]
AS
SELECT  dbo.PayrollDetail.PayrollIdNo,dbo.PayrollDetail.EmployeeIdNo, Sum(IIf(dbo.PayElement.PayElementKind='E',dbo.PayrollPayELement.Amount,dbo.PayrollPayElement.Amount*-1)) as TotalAmount,
		Sum(IIf(dbo.PayElement.PayElementKind='E',dbo.PayrollPayELement.Amount,0)) as TotalEarning, 
		Sum(IIf(dbo.PayElement.PayElementKind<>'E',dbo.PayrollPayELement.Amount,0)) as TotalDeduction,dbo.PayElement.ReportGroupIdNo,
		dbo.PayrollPayElement.PayElementIdNo, dbo.Employee.EmployeeName, dbo.Employee.PayGroupIdNo,dbo.PayElementGroup.PayELementGroupName,dbo.PayGroup.PayGroupName,
		dbo.PayElement.PayElementName,dbo.PayrollDetail.BankTransfer,
		IIf(dbo.PayElement.UsePayGroups=0,dbo.PayElement.AccountIdNo,IsNull(dbo.PayElementAccount.AccountIdNo,dbo.PayELement.AccountIdNo)) as PostAccountIdNo,UsePayGroups,
		IsNull(dbo.Employee.RevCostCenterIdNo,IsNull(dbo.PayGroup.RevCostCenterIdNo,0)) as RevCostCenterIdNo,
	    dbo.Contact.IdNo as ContactIdNo,dbo.RevCostCenter.RevCostCenterName,dbo.RevCostCenter.RevCostCenterCode
		FROM dbo.PayrollDetail 
Left JOIN dbo.PayrollPayElement 
ON dbo.PayrollPayElement.PayrollDetailIdNo = dbo.PayrollDetail.IdNo 
LEFT JOIN dbo.PayElement
ON dbo.PayElement.IdNo = dbo.PayrollPayElement.PayElementIdNo
LEFT JOIN dbo.Employee
ON dbo.PayrollDetail.EmployeeIdNo = dbo.Employee.IdNo
LEFT JOIN dbo.PayElementGroup
ON dbo.PayElement.ReportGroupIdNo = dbo.PayElementGroup.IdNo
LEFT JOIN dbo.PayGroup
on dbo.Employee.PayGroupIdNo = dbo.PayGroup.IdNo
LEFT JOIN dbo.PayElementAccount
on dbo.PayElement.IdNo = dbo.PayElementAccount.PayElementIdNo and dbo.PayElementAccount.PayGroupIdNo = dbo.Employee.PayGroupIdNo
LEFT JOIN dbo.Contact
on dbo.Employee.IdNo = dbo.Contact.CSEIdNo and dbo.Contact.CSECode='E'
Left Join dbo.RevCostCenter
on IsNull(dbo.Employee.RevCostCenterIdNo,IsNull(dbo.PayGroup.RevCostCenterIdNo,0)) = RevCostCenter.IdNo
where dbo.Employee.SponsorType <> '4'
Group by dbo.Employee.PayGroupIdNo,PayGroupName,PayElementGroupName,PayGroupName,UsePayGroups,dbo.Contact.IdNo,dbo.RevCostCenter.RevCostCenterName,dbo.RevCostCenter.RevCostCenterCode,
iif(dbo.PayElement.UsePayGroups=0,dbo.PayElement.AccountIdNo,IsNull(dbo.PayElementAccount.AccountIdNo,dbo.PayELement.AccountIdNo)),
IsNull(dbo.Employee.RevCostCenterIdNo,IsNull(dbo.PayGroup.RevCostCenterIdNo,0)),
PayElementName,dbo.PayrollPayElement.PayElementIdNo,payrollIdNo,EmployeeIdNo,EmployeeName,ReportGroupIdNo,BankTransfer

GO

