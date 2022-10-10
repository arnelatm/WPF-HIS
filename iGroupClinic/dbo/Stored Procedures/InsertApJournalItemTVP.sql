






CREATE PROC [dbo].[InsertApJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO ApJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.ApJournalItem ON;