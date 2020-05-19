





CREATE PROC [dbo].[InsertCheckDisbursementJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO ChequeDisbursementJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, ProfitCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, ProfitCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.ChequeDisbursementJournalItem ON;

