





cREATE PROC [dbo].[InsertCkJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CkJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CkJournalItem ON;