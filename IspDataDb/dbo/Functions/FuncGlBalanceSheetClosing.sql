


CREATE FUNCTION [dbo].[FuncGlBalanceSheetClosing] (@StartDate Date, @EndDate Date, @LastFiscalYearEnd Date)
RETURNS TABLE
AS
RETURN
(   SELECT idno, Sum(Balance) as 'Balance'
    FROM [GLBalanceSheet_View]
	/***WHERE (TransactionDate >= @StartDate and TransactionDate <= @EndDate ) ***/
    WHERE (TransactionDate >= @StartDate and TransactionDate <= @EndDate ) 
		   OR (Year(TransactionDate) >= Year(@LastFiscalYearEnd) and Year(TransactionDate) < Year(@EndDate) and  closingjournal = 1) 
	Group By idNo
)

GO

