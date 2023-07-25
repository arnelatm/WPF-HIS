






-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[FuncApSummary] 
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
	
	(SELECT dbo.ApDetails_View.SupplierIdNo,
			Sum(dbo.ApDetails_View.Credit-dbo.ApDetails_View.Debit) as 'Amount', 
			dbo.ApDetails_View.TransactionType
	 FROM   dbo.ApDetails_View INNER JOIN dbo.Account ON dbo.ApDetails_View.AccountIdNo = dbo.Account.IDNo
	 WHERE  (dbo.Account.SpecialAccount = 'AP' or dbo.Account.SpecialAccount = 'AS'  OR dbo.Account.SpecialAccount='PD') AND TRANSACTIONDATE>=@BeginningDate AND TRANSACTIONDATE<=@EndingDate
	 Group By dbo.ApDetails_View.SupplierIdNo,dbo.ApDetails_View.TransactionType 
	)
	Union
	(SELECT dbo.ApDetails_View.SupplierIdNo, 
			Sum(dbo.ApDetails_View.Debit-dbo.ApDetails_View.Credit),
            'S'
	 FROM   dbo.ApDetails_View INNER JOIN dbo.Account ON dbo.ApDetails_View.AccountIdNo = dbo.Account.IDNo
	 WHERE  dbo.Account.SpecialAccount='PD' AND TRANSACTIONDATE>=@BeginningDate AND TRANSACTIONDATE<=@EndingDate
	 Group By dbo.ApDetails_View.SupplierIdNo,dbo.ApDetails_View.TransactionType
	)
	Union
	(SELECT dbo.Supplier.IdNo,
			ISNULL((Select sum(Credit-Debit) from ApStatement_View where transactiondate < @BeginningDate and ApStatement_View.SupplierIdNo = dbo.Supplier.IdNo and ApStatement_View.SpecialAccount='AP'),0),
           'B'
	 From dbo.Supplier Inner Join dbo.ApStatement_View on dbo.Supplier.IdNo = dbo.ApStatement_View.SupplierIdNo
	)
)