


-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[FuncErSummary] 
(	
	-- Add the parameters for the function here
	@BeginningDate Date,
	@EndingDate Date
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	
	(SELECT dbo.ErDetails_View.EmployeeIdNo,
			Sum(dbo.ErDetails_View.Debit-dbo.ErDetails_View.Credit) as 'Amount', 
			dbo.ErDetails_View.TransactionType
	 FROM   dbo.ErDetails_View INNER JOIN dbo.Account ON dbo.ErDetails_View.AccountIdNo = dbo.Account.IDNo
	 WHERE  dbo.Account.SpecialAccount = 'EL' AND TRANSACTIONDATE>=@BeginningDate AND TRANSACTIONDATE<=@EndingDate
	 Group By dbo.ErDetails_View.EmployeeIdNo,dbo.ErDetails_View.TransactionType 
	)
	Union
	(SELECT dbo.Employee.IdNo,
			ISNULL((Select sum(Debit-Credit) from ErStatement_View where transactiondate < @BeginningDate and ErStatement_View.EmployeeIdNo = dbo.Employee.IdNo),0),
           'B'
	 From dbo.Employee Inner Join dbo.ErStatement_View on dbo.Employee.IdNo = dbo.ErStatement_View.EmployeeIdNo
	)
)