


CREATE FUNCTION [dbo].[FuncAccountBalance] (@IdNo Integer,@StartDate Date, @EndDate Date, @LastFiscalYearEnd Date)
RETURNS TABLE
AS
RETURN
(   SELECT Sum(Balance) as 'Balance'
    FROM [GLBalanceSheet_View]
	/***WHERE (TransactionDate >= @StartDate and TransactionDate <= @EndDate ) ***/
    WHERE IdNo = @IdNo and (TransactionDate >= @StartDate and TransactionDate <= @EndDate and  closingjournal = 0) 
		   OR (Year(TransactionDate) >= Year(@LastFiscalYearEnd) and Year(TransactionDate) < Year(@EndDate) and  closingjournal = 1) 
	
)