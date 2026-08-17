




CREATE PROC [dbo].[InsertCdJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CdJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CdJournalItem ON;

GO

