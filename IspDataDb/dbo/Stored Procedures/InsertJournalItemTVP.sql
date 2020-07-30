






CREATE PROC [dbo].[InsertJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO JournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.JournalItem ON;

