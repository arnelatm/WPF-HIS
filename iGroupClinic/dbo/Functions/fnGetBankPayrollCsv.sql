







-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[fnGetBankPayrollCsv] 
(	
	-- Add the parameters for the function here
	@PayrollIdNo Int
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	
	SELECT [BankName]
      ,[AcctNo]
      ,Sum([NetPay]) as 'NetPay'
      ,[Notes]
      ,[EmpName]
      ,[IqamaNo]
      ,[Address]
      ,Sum([SalaryEr]) as 'SalaryEr'
      ,Sum([Housing]) as 'Housing'
      ,Sum([OtherWage]) as 'OtherWage'
      ,Sum([Deductions]) as 'Deductions'
  FROM [dbo].[PayrollCsvReport_View]
    where bankname is not Null and payrollidno=@PayrollIdNo
  group by PayrollIdNo,BankName,AcctNo,Notes,EmpName,IqamaNo,[Address]

)