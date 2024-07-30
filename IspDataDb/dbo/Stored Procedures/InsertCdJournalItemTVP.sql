




cREATE PROC [dbo].[InsertCdJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CdJournalItem (AccountIdNo, ContactIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo, ContactIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CdJournalItem ON;