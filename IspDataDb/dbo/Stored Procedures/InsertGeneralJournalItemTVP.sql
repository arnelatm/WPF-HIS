






CREATE PROC [dbo].[InsertGeneralJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO GeneralJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.GeneralJournalItem ON;

