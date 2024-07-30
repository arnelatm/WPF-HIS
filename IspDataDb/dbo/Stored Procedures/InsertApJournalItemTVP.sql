






CREATE PROC [dbo].[InsertApJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO ApJournalItem (AccountIdNo, ContactIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo, ContactIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.ApJournalItem ON;

