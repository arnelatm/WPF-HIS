




CREATE PROC [dbo].[InsertPurchaseJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO PurchaseJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PurchaseJournalItem ON;