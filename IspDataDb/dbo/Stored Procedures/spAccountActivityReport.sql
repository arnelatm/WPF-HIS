-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	Create Account Activity Movement
-- =============================================
CREATE PROCEDURE spAccountActivityReport 
	-- Add the parameters for the stored procedure here
	@BegDate as Date = '20200101',
	@EndDate as Date = '20201231',
	@BegAcctCode as VarChar(20) = '106',
	@EndAcctCode as VarChar(20) = '106'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
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
	With Cte as 
	(
	select JournalCode,IdNo,[Sequence],JournalIdNo,AccountIdNo,AccountCode,Debit,Credit,RevCostCenterIdNo,Notes,Posted,TransactionDate,ReferenceNo,DocumentNumber,PayDescription,PayDescriptionAra,ClosingJournal,sum(debit-credit) 
			OVER (PARTITION BY ACCOUNTIDNO ORDER BY TRANSACTIONDATE,JOURNALCODE,JOURNALIDNO,IDNO) AS balance from GlStatementNew_View 
			WHERE (TransactionDate >= @BegDataDate and TransactionDate < @BegDate and AccountCode >= @BegAcctCode and AccountCode <= @EndAcctCode AND JournalCode<>'BB') 
			   OR (JournalCode='BB' and TransactionDate = dATEfROMpARTS(YEAR(@BegDatadATE)-1,12,31) AND AccountCode >= @BegAcctCode and AccountCode <= @EndAcctCode)
	),
	cteBB (JournalCode,IdNo,[Sequence],JournalIdNo,AccountIdNo,AccountCode,Debit,Credit,RevCostCenterIdNo,Notes,Posted,TransactionDate,ReferenceNo,DocumentNumber,PayDescription,PayDescriptionAra,ClosingJournal,Balance) as
	(
	Select ' BB',0,0,0,AccountIdNo,AccountCode,Iif(Sum(debit-Credit)>0,Sum(Debit-Credit),0),IIf(SUm(Debit-Credit)<0,Sum(Debit-Credit)*-1,0),0,'Beginning Balance',0,DateAdd(day,-1,@BegDate),'BB','','Beginning Balance','Beginning Balance',0,Sum(debit-Credit) as 'Balance' 
	from cte
	Group by AccountIdNo,AccountCode
	)
	,
	cteCurrent (JournalCode,IdNo,[Sequence],JournalIdNo,AccountIdNo,AccountCode,Debit,Credit,RevCostCenterIdNo,Notes,Posted,TransactionDate,ReferenceNo,DocumentNumber,PayDescription,PayDescriptionAra,ClosingJournal,Balance) as
	(
	select JournalCode,IdNo,[Sequence],JournalIdNo,AccountIdNo,AccountCode,Debit,Credit,RevCostCenterIdNo,Notes,Posted,TransactionDate,ReferenceNo,DocumentNumber,PayDescription,PayDescriptionAra,ClosingJournal,0
		from GlStatementNew_View 
		WHERE (TransactionDate >= @BegDate and TransactionDate <= @EndDate and AccountCode >= @BegAcctCode and AccountCode <= @EndAcctCode AND JournalCode<>'BB')
	)
	,
	cteFullStatement (JournalCode,IdNo,[Sequence],JournalIdNo,AccountIdNo,AccountCode,Debit,Credit,RevCostCenterIdNo,Notes,Posted,TransactionDate,ReferenceNo,DocumentNumber,PayDescription,PayDescriptionAra,ClosingJournal,Balance) as
	( Select * from cteBB
	  Union
	  Select * from cteCurrent
	 )
	 select JournalCode,IdNo,[Sequence],JournalIdNo,AccountIdNo,AccountCode,Debit,Credit,RevCostCenterIdNo,Notes,Posted,TransactionDate,ReferenceNo,DocumentNumber,PayDescription,PayDescriptionAra,ClosingJournal,sum(debit-credit) 
			OVER (PARTITION BY ACCOUNTIDNO ORDER BY TRANSACTIONDATE,JOURNALCODE,JOURNALIDNO,IDNO) AS balance from cteFullStatement
			order by accountcode,transactiondate,journalcode,journalidno,idno
END
