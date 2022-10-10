








CREATE PROC [dbo].[InsertArJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO ArJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.ArJournalItem ON;