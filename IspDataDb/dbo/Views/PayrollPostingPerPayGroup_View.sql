CREATE View [dbo].[PayrollPostingPerPayGroup_View]
as SELECT PayrollIdNo
      ,iif(Sum([TotalAmount])>=0,Sum(TotalAmount),0) as Debit
	  ,iif(Sum([TotalAmount])<0,Abs(Sum(TotalAmount)),0) as Credit
      ,[PayGroupIdNo]
      ,[PayGroupName]
      ,[PostAccountIdNo]
  FROM [dbo].[PayrollReportPosting_View] 
  group by PayrollIdNo,PayGroupIdNo,PayGroupName,PostAccountIdNo