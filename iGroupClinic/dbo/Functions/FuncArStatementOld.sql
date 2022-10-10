

-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[FuncArStatementOld] 
(	
	-- Add the parameters for the function here
	@CustomerIdNo int, 
	@BeginningDate Date,
	@EndingDate Date
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
		
	SELECT dbo.ArDetails_View.JournalCode, dbo.ArDetails_View.IdNo, dbo.ArDetails_View.Sequence, dbo.ArDetails_View.JournalIdNo, dbo.ArDetails_View.AccountIdNo, dbo.ArDetails_View.Debit, dbo.ArDetails_View.Credit, 
           dbo.ArDetails_View.RevCostCenterIdNo, dbo.ArDetails_View.Notes, dbo.ArDetails_View.Posted, dbo.ArDetails_View.CustomerIdNo, dbo.ArDetails_View.InvoiceNo, dbo.ArDetails_View.TransactionDate, dbo.ArDetails_View.ReferenceNo, 
           dbo.ArDetails_View.TransactionType, dbo.Account.SpecialAccount, dbo.ArDetails_View.MainNote
	FROM   dbo.ArDetails_View INNER JOIN dbo.Account ON dbo.ArDetails_View.AccountIdNo = dbo.Account.IDNo
	WHERE  (dbo.Account.SpecialAccount = 'AR') and dbo.ArDetails_View.CustomerIdNo = @CustomerIdNo and dbo.ArDetails_View.TransactionDate >= @BeginningDate and dbo.ArDetails_View.TransactionDate <= @EndingDate

	Union

	SELECT 'BB' , 0, 1, 0, 0, 
			iIf((Select sum(debit-credit)  from ArStatement_View where CustomerIdNo = @CustomerIdNo and transactiondate < @BeginningDate)>0,(Select sum(debit-credit)  from ArStatement_View where CustomerIdNo = @CustomerIdNo and transactiondate < @BeginningDate),0),
			iIf((Select sum(debit-credit)  from ArStatement_View where CustomerIdNo = @CustomerIdNo and transactiondate < @BeginningDate)<0,(Select sum(debit-credit)  from ArStatement_View where CustomerIdNo = @CustomerIdNo and transactiondate < @BeginningDate),0),
			0, 'Beginning Balance', 0, @CustomerIdNo, 'Beg.Bal.', DateAdd(day,-1,@BeginningDate), 'Beg.Bal.', 
           'B', 'AR', 'Beginning Balance'
	
)