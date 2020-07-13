


CREATE FUNCTION [dbo].[FuncGlIncomeStatementOld] (@StartDate Date, @EndDate Date)
RETURNS TABLE
AS
RETURN
(   SELECT idno, Sum(Balance) as 'Balance'
    FROM [GLBalanceSheet_View]
	WHERE (TransactionDate >= @StartDate and TransactionDate <= @EndDate and  closingjournal = 0 and ((SpecialAccount <> 'BI' and SpecialAccount <> 'EI') or SpecialAccount Is Null)) OR
		  (Month(TransactionDate) = Month(@StartDate) and Year(TransactionDate) = Year(@StartDate) and  closingjournal = 0  and SpecialAccount = 'BI') OR
		  (Month(TransactionDate) = Month(@EndDate) and Year(TransactionDate) = Year(@EndDate) and  closingjournal = 0  and SpecialAccount = 'EI') 
	Group By idNo
)