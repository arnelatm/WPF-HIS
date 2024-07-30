





cREATE PROC [dbo].[InsertCkJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CkJournalItem (AccountIdNo, ContactIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo, ContactIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CkJournalItem ON;