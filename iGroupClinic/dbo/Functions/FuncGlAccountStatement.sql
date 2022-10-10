


CREATE FUNCTION [dbo].[FuncGlAccountStatement](@BegDate Date, @EndDate Date, @BegAcctCode VarChar(5), @EndAcctCode VarChar(5))
RETURNS @Results TABLE (
	JournalCode VarChar(2),
	IdNo int,
	[Sequence] SmallInt,
	JournalIdNo Int,
	AccountIdNo SmallInt,
	AccountCode VarChar(5),
	Debit Money,
	Credit Money,
	RevCostCenterIdNo SmallInt,
	Notes nVarChar(300),
	Posted Bit,
	TransactionDate Date,
	ReferenceNo VarChar(20),
	DocumentNumber VarChar(20),
	PayDescription VarChar(300),
	PayDescriptionAra VarChar(300),
	ClosingJournal Bit,
	Balance Money
	)
AS
Begin
	Declare @BegDataDate Date
	Set @BegDataDate = datefromparts(year(@BegDate),1,1)
	Declare @LastFiscalYearEndDate Date
	Set @LastFiscalYearEndDate = (Select LastPostingDate from LastPosting where TransactionName = 'LastFiscalYearEnd')
	if @BegDate > @LastFiscalYearEndDate 
		Begin
			Set @BegDataDate = DateFromParts(year(@LastFiscalYearEndDate)+1,1,1)
		End
	else
		Begin
			Set @BegDataDate = DateFromParts(Year(@BegDate),1,1)
		end
	Insert @Results
	select *,sum(debit-credit) OVER (PARTITION BY ACCOUNTIDNO ORDER BY TRANSACTIONDATE,JOURNALCODE,JOURNALIDNO,IDNO) AS balance 
	from GlStatementNew_View 
	WHERE (TransactionDate >= @BegDataDate and TransactionDate <= @EndDate and AccountCode >= @BegAcctCode and AccountCode <= @EndAcctCode AND JournalCode<>'BB') 
	   OR (JournalCode='BB' and TransactionDate = dATEfROMpARTS(YEAR(@BegDatadATE)-1,12,31) AND AccountCode >= @BegAcctCode and AccountCode <= @EndAcctCode)
	order by transactiondate
	return
End