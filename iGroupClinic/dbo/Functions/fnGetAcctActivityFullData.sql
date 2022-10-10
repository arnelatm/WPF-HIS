-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[fnGetAcctActivityFullData]
(
	-- Add the parameters for the function here
	@BegDate Date, 
	@EndDate Date,
	@BegAcctCode Varchar(20),
	@EndAcctCode VarChar(20)
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
	select * from dbo.fngetacctactivitycurrentdata(@BegDate,@EndDate,@BegAcctCode,@EndAcctCode)
	union
	 select * from dbo.fnGetAcctActivityPrevBalance(@BegDate,@EndDate,@BegAcctCode,@EndAcctCode)
	Return
END