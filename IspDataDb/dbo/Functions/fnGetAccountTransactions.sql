

-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[fnGetAccountTransactions] 
(
	-- Add the parameters for the function here
	@BegDate Date, 
	@EndDate Date
)
RETURNS 
@Results TABLE 
(
	-- Add the column definitions for the TABLE variable here
	JournalCode Char(2), 
	IdNo int,
	[Sequence] int,
	JournalIdNo int,
	AccountIdNo int,
	AccountCode VarChar(10),
	Debit Money,
	Credit Money,
	RevCostCenterIdNo Int,
	Notes nVarChar(300),
	Posted bit,
	TransactionDate Date,
	ReferenceNo nVarChar(20),
	DocumentNumber nVarChar(20),
	PayDescription nVarChar(300),
	PayDescriptionAra nVarChar(300),
	ClosingJournal bit,
	Cancelled Bit,
	JournalCodeAra nChar(2)
)
AS
BEGIN
	Insert @Results
	Select JournalCode,IdNo,[Sequence],JournalIdNo,AccountIdNo,AccountCode,Debit,Credit,RevCostCenterIdNo,Notes,Posted,TransactionDate,ReferenceNo,DocumentNumber,PayDescription,PayDescriptionAra,ClosingJournal,Cancelled,JournalCodeAra
	from GlStatement_View 
	WHERE (TransactionDate >= @BegDate and TransactionDate <= @EndDate AND JournalCode<>'BB')
	RETURN 
END

GO

