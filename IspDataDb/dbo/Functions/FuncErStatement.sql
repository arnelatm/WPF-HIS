
-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[FuncErStatement] 
(	
	-- Add the parameters for the function here
	@EmployeeIdNo int, 
	@BeginningDate Date,
	@EndingDate Date
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
		
	SELECT dbo.ErDetails_View.JournalCode, dbo.ErDetails_View.IdNo, dbo.ErDetails_View.Sequence, dbo.ErDetails_View.JournalIdNo, dbo.ErDetails_View.AccountIdNo, dbo.ErDetails_View.Debit, dbo.ErDetails_View.Credit, 
           dbo.ErDetails_View.RevCostCenterIdNo, dbo.ErDetails_View.Notes, dbo.ErDetails_View.Posted, dbo.ErDetails_View.EmployeeIdNo, dbo.ErDetails_View.InvoiceNo, dbo.ErDetails_View.TransactionDate, dbo.ErDetails_View.ReferenceNo, 
           dbo.ErDetails_View.TransactionType, dbo.Account.SpecialAccount, dbo.ErDetails_View.MainNote
	FROM   dbo.ErDetails_View INNER JOIN dbo.Account ON dbo.ErDetails_View.AccountIdNo = dbo.Account.IDNo
	WHERE  (dbo.Account.SpecialAccount = 'EL') and dbo.ErDetails_View.EmployeeIdNo = @EmployeeIdNo and dbo.ErDetails_View.TransactionDate >= @BeginningDate and dbo.ErDetails_View.TransactionDate <= @EndingDate

	Union

	SELECT 'BB' , 0, 1, 0, 0, 
			iIf((Select sum(debit-credit)  from ErStatement_View where EmployeeIdNo = @EmployeeIdNo and transactiondate < @BeginningDate)>0,(Select sum(debit-credit)  from ErStatement_View where EmployeeIdNo = @EmployeeIdNo and transactiondate < @BeginningDate),0),
			iIf((Select sum(debit-credit)  from ErStatement_View where EmployeeIdNo = @EmployeeIdNo and transactiondate < @BeginningDate)<0,(Select sum(debit-credit)  from ErStatement_View where EmployeeIdNo = @EmployeeIdNo and transactiondate < @BeginningDate),0),
			0, 'Beginning Balance', 0, @EmployeeIdNo, 'Beg.Bal.', DateAdd(day,-1,@BeginningDate), 'Beg.Bal.', 
           'B', 'EL', 'Beginning Balance'
	
)