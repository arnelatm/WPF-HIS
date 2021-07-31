



CREATE VIEW [dbo].[RecurringPayElement_View]
AS
SELECT a.[IdNo]
      ,a.[EmployeeIdNo]
      ,a.[Amount]
      ,a.[StartDate]
	  ,a.[PayElementIdNo]
	  ,a.[PeriodicPayment]
	  ,b.TotalAmount
	  ,a.[DateCreated]
	  FROM [ISPDATA].[dbo].[RecurringPayElement] as a
	  Left Join (select sum(amount) as 'TotalAmount',recurringPayElementIdNo from [ISPDATA].[DBO].[PayrollPayElement] where RecurringPayElementIdNo Is Not Null group by recurringpayelementidno) as b
	  on a.IdNo = b.RecurringPayElementIdNo