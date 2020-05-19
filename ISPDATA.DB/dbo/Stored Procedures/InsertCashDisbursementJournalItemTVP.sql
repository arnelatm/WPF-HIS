



CREATE PROC [dbo].[InsertCashDisbursementJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CashDisbursementJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, ProfitCenterIdNo, Sequence)
        SELECT  AccountIdNo, Credit, Debit, JournalIdNo, Notes, ProfitCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CashDisbursementJournalItem ON;

