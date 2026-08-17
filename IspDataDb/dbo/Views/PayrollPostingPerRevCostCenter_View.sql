

CREATE View [dbo].[PayrollPostingPerRevCostCenter_View]
as SELECT PayrollIdNo
      ,iif(Sum([TotalAmount])>=0,Sum(TotalAmount),0) as Debit
	  ,iif(Sum([TotalAmount])<0,Abs(Sum(TotalAmount)),0) as Credit
      ,RevCostCenterIdNo
	  ,RevCostCenterCode
      ,RevCostCenterName
      ,[PostAccountIdNo]
  FROM [ISPDATA].[dbo].[PayrollReportPosting_View] 
  group by PayrollIdNo,RevCostCenterIdNo,PostAccountIdNo,RevCostCenterName,RevCostCenterCode

GO

