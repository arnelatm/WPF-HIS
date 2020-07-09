



CREATE FUNCTION [dbo].[FuncAcctStatement] (@StartDate Date, @EndDate Date, @BegAccountCode VarChar, @EndAccountCode VarChar)
RETURNS TABLE
AS
RETURN
(   SELECT *,sum(debit-Credit) OVER (PARTITION BY AccountIdNo ORDER By TransactionDate,JournalCode,JournalIdNo,Sequence,idno) AS RTBalance
	FROM dbo.GlLedgers_View 
	WHERE transactiondate >= @StartDate AND 
		  transactiondate <= @EndDate and 
		  AccountCode >= @BegAccountCode and 
		  AccountCode <= @EndAccountCode
)