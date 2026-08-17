
-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[fnGetAccountActivityPrevBalance] 
(
	-- Add the parameters for the function here
	@BegDate Date, 
	@EndDate Date,
	@AccountIdNo SmallInt
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
	Balance Money
)
AS
BEGIN
	Declare @BegDataDate Date
	Set @BegDataDate = datefromparts(year(@BegDate),1,1)
	Declare @IdNo as Int
	Declare @Balance Decimal(16,2)
	Declare @BegBalance as Money
	Declare @LastFiscalYearEndDate Date
	Set @LastFiscalYearEndDate = (Select LastPostingDate from LastPosting where TransactionName = 'LastFiscalYearEnd' )
	if @BegDate > @LastFiscalYearEndDate 
		Begin Set @BegDataDate = DateFromParts(Year(@LastFiscalYearEndDate)+1,1,1) End
	else
		Begin Set @BegDataDate = DateFromParts(Year(@BegDate),1,1) End;
	-- Fill the table variable with the rows for your result set
	Insert @Results
	Select 'BB' as JournalCode,0 as IdNo,0 as [Sequence],0 as JournalIdNo,AccountIdNo,AccountCode,Iif(Sum(debit-Credit)>0,Sum(Debit-Credit),0) as Debit,IIf(SUm(Debit-Credit)<0,Sum(Debit-Credit)*-1,0) as Credit,
		0 as RevCostCenterIdNo,'Beginning Balance' as Notes,0 as Posted,DateAdd(day,-1,@BegDate) as TransactionDate,'BB' as ReferenceNo,'' as DocumentnUMBER,
		'Beginning Balance' AS PayDescription,'Beginning Balance' as PayDescriptionAra,0 as ClosingJournal,Cancelled,Sum(debit-Credit) as Balance
	from fnGetAccountActivityPreviousData(@BegDate,@EndDate,@AccountIdNo) Group by AccountIdNo,AccountCode,Cancelled
	Return
END

GO

