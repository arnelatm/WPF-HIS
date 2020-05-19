




CREATE PROC [dbo].[InsertJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO JournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, ProfitCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, ProfitCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.JournalItem ON;

