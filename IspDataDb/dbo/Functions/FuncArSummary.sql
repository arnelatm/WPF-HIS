


-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[FuncArSummary] 
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
	
	(SELECT dbo.ArDetails_View.CustomerIdNo,
			Sum(dbo.ArDetails_View.Debit-dbo.ArDetails_View.Credit) as 'Amount', 
			dbo.ArDetails_View.TransactionType
	 FROM   dbo.ArDetails_View INNER JOIN dbo.Account ON dbo.ArDetails_View.AccountIdNo = dbo.Account.IDNo
	 WHERE  (dbo.Account.SpecialAccount = 'AR' or dbo.Account.SpecialAccount='CA' or dbo.Account.SpecialAccount='SD') AND TRANSACTIONDATE>=@BeginningDate AND TRANSACTIONDATE<=@EndingDate
	 Group By dbo.ArDetails_View.CustomerIdNo,dbo.ARDetails_View.TransactionType 
	)
	Union
	(SELECT dbo.ArDetails_View.CustomerIdNo, 
			Sum(dbo.ArDetails_View.Credit-dbo.ArDetails_View.Debit),
            dbo.ArDetails_View.TransactionType
	 FROM   dbo.ArDetails_View INNER JOIN dbo.Account ON dbo.ArDetails_View.AccountIdNo = dbo.Account.IDNo
	 WHERE  dbo.Account.SpecialAccount='SD' AND TRANSACTIONDATE>=@BeginningDate AND TRANSACTIONDATE<=@EndingDate
	 Group By dbo.ArDetails_View.CustomerIdNo,dbo.ArDetails_View.TransactionType
	)
	Union
	(SELECT dbo.Customer.IdNo,
			ISNULL((Select sum(Debit-Credit) from ArStatement_View where transactiondate < @BeginningDate and ArStatement_View.CustomerIdNo = dbo.Customer.IdNo),0),
           'B'
	 From dbo.Customer Inner Join dbo.ArStatement_View on dbo.Customer.IdNo = dbo.ArStatement_View.CustomerIdNo
	)
)