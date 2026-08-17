


/****** Script for SelectTopNRows command from SSMS  ******/
CREATE View [dbo].[PayrollPostingPerEmployee_View]
as SELECT PayrollIdNo,ContactIdNo,[EmployeeIdNo]
      ,iif(Sum([TotalAmount])>=0,Sum(TotalAmount),0) as Debit
	  ,iif(Sum([TotalAmount])<0,Abs(Sum(TotalAmount)),0) as Credit
	  ,[RevCostCenterIdNo]
      ,[EmployeeName]
      ,[PayGroupIdNo]
      ,[PayGroupName]
      ,[PostAccountIdNo]
  FROM [ISPDATA].[dbo].[PayrollReportPosting_View] 
  group by PayrollIdNo,PayGroupIdNo,PayGroupName,RevCostCenterIdNo,EmployeeIdNo,ContactIdNo,EmployeeName,PostAccountIdNo

GO

