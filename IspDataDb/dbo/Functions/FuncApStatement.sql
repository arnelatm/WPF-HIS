

-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[FuncApStatement] 
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
		
	(SELECT 0 AS 'Discount', dbo.ApDetails_View.JournalCode, dbo.ApDetails_View.JournalIdNo, Sum(dbo.ApDetails_View.Credit-dbo.ApDetails_View.Debit) as 'Amount', dbo.ApDetails_View.Notes,
           dbo.ApDetails_View.SupplierIdNo, dbo.ApDetails_View.InvoiceNo, dbo.ApDetails_View.TransactionDate, dbo.ApDetails_View.ReferenceNo, 
           dbo.ApDetails_View.TransactionType, dbo.APDetails_View.MainNote
	FROM   dbo.ApDetails_View INNER JOIN dbo.Account ON dbo.ApDetails_View.AccountIdNo = dbo.Account.IDNo
	WHERE  (dbo.Account.SpecialAccount = 'AP' or  dbo.Account.SpecialAccount = 'AS' OR dbo.Account.SpecialAccount='PD') and SUPPLIERIDNO=@SupplierIdNo AND TRANSACTIONDATE>=@BeginningDate AND TRANSACTIONDATE<=@EndingDate
	Group By dbo.ApDetails_View.JournalCode, dbo.ApDetails_View.JournalIdNo,dbo.ApDetails_View.Notes, dbo.ApDetails_View.SupplierIdNo, dbo.ApDetails_View.InvoiceNo, dbo.ApDetails_View.TransactionDate, dbo.ApDetails_View.ReferenceNo, 
             dbo.ApDetails_View.TransactionType, dbo.APDetails_View.MainNote)
	Union
	(SELECT 1,dbo.ApDetails_View.JournalCode, dbo.ApDetails_View.JournalIdNo, Sum(dbo.ApDetails_View.Debit-dbo.ApDetails_View.Credit), dbo.ApDetails_View.Notes,
           dbo.ApDetails_View.SupplierIdNo, dbo.ApDetails_View.InvoiceNo, dbo.ApDetails_View.TransactionDate, dbo.ApDetails_View.ReferenceNo, 
           dbo.ApDetails_View.TransactionType, dbo.APDetails_View.MainNote
	FROM   dbo.ApDetails_View INNER JOIN dbo.Account ON dbo.ApDetails_View.AccountIdNo = dbo.Account.IDNo
	WHERE  dbo.Account.SpecialAccount='PD' and SUPPLIERIDNO=@SupplierIdNo  AND TRANSACTIONDATE>=@BeginningDate AND TRANSACTIONDATE<=@EndingDate
	Group By dbo.ApDetails_View.JournalCode, dbo.ApDetails_View.JournalIdNo,dbo.ApDetails_View.Notes, dbo.ApDetails_View.SupplierIdNo, dbo.ApDetails_View.InvoiceNo, dbo.ApDetails_View.TransactionDate, dbo.ApDetails_View.ReferenceNo, 
             dbo.ApDetails_View.TransactionType, dbo.APDetails_View.MainNote
	)
	Union
	(SELECT 0,'BB',0, ISNULL((Select sum(credit-debit) from ApStatement_View where SupplierIdNo = @SupplierIdNo and transactiondate < @BeginningDate and SpecialAccount = 'AP'),0), 'Beginning Balance',
           @SupplierIdNo , '' , DateAdd(Day,-1,@BeginningDate), '',
           'B', 'Beginning Balance'
	)
)