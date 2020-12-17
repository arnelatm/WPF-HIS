

-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[FuncApStatementOld] 
(	
	-- Add the parameters for the function here
	@SupplierIdNo int, 
	@BeginningDate Date,
	@EndingDate Date
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
		
	SELECT dbo.ApDetails_View.JournalCode, dbo.ApDetails_View.IdNo, dbo.ApDetails_View.Sequence, dbo.ApDetails_View.JournalIdNo, dbo.ApDetails_View.AccountIdNo, dbo.ApDetails_View.Debit, dbo.ApDetails_View.Credit, 
           dbo.ApDetails_View.RevCostCenterIdNo, dbo.ApDetails_View.Notes, dbo.ApDetails_View.Posted, dbo.ApDetails_View.SupplierIdNo, dbo.ApDetails_View.InvoiceNo, dbo.ApDetails_View.TransactionDate, dbo.ApDetails_View.ReferenceNo, 
           dbo.ApDetails_View.TransactionType, dbo.Account.SpecialAccount, dbo.ApDetails_View.MainNote
	FROM   dbo.ApDetails_View INNER JOIN dbo.Account ON dbo.ApDetails_View.AccountIdNo = dbo.Account.IDNo
	WHERE  (dbo.Account.SpecialAccount = 'AP') and dbo.ApDetails_View.SupplierIdNo = @SupplierIdNo and dbo.ApDetails_View.TransactionDate >= @BeginningDate and dbo.ApDetails_View.TransactionDate <= @EndingDate

	Union

	SELECT 'BB' , 0, 1, 0, 0, 
			iIf((Select sum(debit-credit)  from ApStatement_View where SupplierIdNo = @SupplierIdNo and transactiondate < @BeginningDate)>0,(Select sum(debit-credit)  from ApStatement_View where SupplierIdNo = @SupplierIdNo and transactiondate < @BeginningDate),0),
			iIf((Select sum(debit-credit)  from ApStatement_View where SupplierIdNo = @SupplierIdNo and transactiondate < @BeginningDate)<0,(Select sum(debit-credit)  from ApStatement_View where SupplierIdNo = @SupplierIdNo and transactiondate < @BeginningDate),0),
			0, 'Beginning Balance', 0, @SupplierIdNo, 'Beg.Bal.', DateAdd(day,-1,@BeginningDate), 'Beg.Bal.', 
           'B', 'AP', 'Beginning Balance'
	
)