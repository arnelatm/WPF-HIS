






CREATE PROC [dbo].[InsertPcJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO PcJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PcJournalItem ON;