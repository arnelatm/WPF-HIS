




CREATE PROC [dbo].[InsertPettyCashJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO PettyCashJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, ProfitCenterIdNo, Sequence)
        SELECT  AccountIdNo, Credit, Debit, JournalIdNo, Notes, ProfitCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PettyCashJournalItem ON;

