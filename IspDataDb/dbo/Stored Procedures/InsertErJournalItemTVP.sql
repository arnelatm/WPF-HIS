









CREATE PROC [dbo].[InsertErJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO ErJournalItem (AccountIdNo, ContactIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo, ContactIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.ErJournalItem ON;