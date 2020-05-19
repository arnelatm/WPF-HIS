







CREATE   PROC [dbo].[InsertAccountReconciliationItemTVP]
  @MParam AccountReconciliationItemInsert READONLY
AS 
INSERT  INTO AccountReconciliationItem ( AccountReconciliationIdNo, Cleared, JournalCode, JournalItemIdNo, Sequence )
        SELECT  AccountReconciliationIdNo, Cleared, JournalCode, JournalItemIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.AccountReconciliationItem ON;

