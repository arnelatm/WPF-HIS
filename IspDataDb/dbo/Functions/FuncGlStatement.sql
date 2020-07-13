


CREATE FUNCTION [dbo].[FuncGlStatement] (@StartDate Date, @EndDate Date, @LastFiscalYearEnd Date)
RETURNS TABLE
AS
RETURN
(   SELECT idno, Sum(Balance) as 'Balance'
    FROM [GLBalanceSheet_View]
	/***WHERE (TransactionDate >= @StartDate and TransactionDate <= @EndDate ) ***/
    WHERE (TransactionDate >= @StartDate and TransactionDate < @EndDate and  closingjournal = 0 and (SpecialAccount <> 'BI' or SpecialAccount <> 'EI')) 
		   OR 
		  (TransactionDate >= @LastFiscalYearEnd and TransactionDate < @EndDate and  closingjournal = 1 and (SpecialAccount <> 'BI' or SpecialAccount <> 'EI')) 
		   OR
		  (Month(TransactionDate) = Month(@StartDate) and Year(TransactionDate) = Year(@StartDate) and  closingjournal = 0 and SpecialAccount = 'BI')
		   OR 
		  (Month(TransactionDate) = Month(@EndDate) and Year(TransactionDate) = Year(@EndDate) and  closingjournal = 0 and SpecialAccount = 'EI')
		   OR
		  (Month(TransactionDate) = Month(@StartDate) and Year(TransactionDate) = Year(@StartDate) and  closingjournal = 1 and SpecialAccount = 'BI')
		   OR
		  (Month(TransactionDate) = Month(@EndDate) and Year(TransactionDate) = Year(@EndDate) and  closingjournal = 1 and SpecialAccount = 'EI')
	Group By idNo
)