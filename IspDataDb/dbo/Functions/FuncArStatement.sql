

-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[FuncArStatement] 
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
		
	(SELECT 0 AS 'Discount', dbo.ArDetails_View.JournalCode, dbo.ArDetails_View.JournalIdNo, Sum(dbo.ArDetails_View.Debit-dbo.ArDetails_View.Credit) as 'Amount', dbo.ArDetails_View.Notes,
           dbo.ArDetails_View.CustomerIdNo, dbo.ArDetails_View.InvoiceNo, dbo.ArDetails_View.TransactionDate, dbo.ArDetails_View.ReferenceNo, 
           dbo.ArDetails_View.TransactionType, dbo.ArDetails_View.MainNote
	FROM   dbo.ArDetails_View INNER JOIN dbo.Account ON dbo.ArDetails_View.AccountIdNo = dbo.Account.IDNo
	WHERE  (dbo.Account.SpecialAccount = 'AR' or dbo.Account.SpecialAccount='SD') and CustomerIDNO=@CustomerIdNo AND TRANSACTIONDATE>=@BeginningDate AND TRANSACTIONDATE<@EndingDate
	Group By dbo.ArDetails_View.JournalCode, dbo.ArDetails_View.JournalIdNo,dbo.ArDetails_View.Notes, dbo.ArDetails_View.CustomerIdNo, dbo.ArDetails_View.InvoiceNo, dbo.ArDetails_View.TransactionDate, dbo.ArDetails_View.ReferenceNo, 
             dbo.ArDetails_View.TransactionType, dbo.ArDetails_View.MainNote)
	Union
	(SELECT 1,dbo.ArDetails_View.JournalCode, dbo.ArDetails_View.JournalIdNo, Sum(dbo.ArDetails_View.Credit-dbo.ArDetails_View.Debit), dbo.ArDetails_View.Notes,
           dbo.ArDetails_View.CustomerIdNo, dbo.ArDetails_View.InvoiceNo, dbo.ArDetails_View.TransactionDate, dbo.ArDetails_View.ReferenceNo, 
           dbo.ArDetails_View.TransactionType, dbo.ArDetails_View.MainNote
	FROM   dbo.ArDetails_View INNER JOIN dbo.Account ON dbo.ArDetails_View.AccountIdNo = dbo.Account.IDNo
	WHERE  dbo.Account.SpecialAccount='SD' and CustomerIDNO=@CustomerIdNo  AND TRANSACTIONDATE>=@BeginningDate AND TRANSACTIONDATE<@EndingDate
	Group By dbo.ArDetails_View.JournalCode, dbo.ArDetails_View.JournalIdNo,dbo.ArDetails_View.Notes, dbo.ArDetails_View.CustomerIdNo, dbo.ArDetails_View.InvoiceNo, dbo.ArDetails_View.TransactionDate, dbo.ArDetails_View.ReferenceNo, 
             dbo.ArDetails_View.TransactionType, dbo.ArDetails_View.MainNote
	)
	Union
	(SELECT 0,'BB',0, ISNULL((Select sum(Debit-Credit) from ArStatement_View where CustomerIdNo = @CustomerIdNo and transactiondate < @BeginningDate),0), 'Beginning Balance',
           @CustomerIdNo , '' , DateAdd(Day,-1,@BeginningDate), '',
           'B', 'Beginning Balance'
	)
)