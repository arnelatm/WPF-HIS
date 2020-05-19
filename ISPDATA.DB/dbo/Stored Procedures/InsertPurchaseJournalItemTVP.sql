




create PROC [dbo].[InsertPurchaseJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO PurchaseJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, ProfitCenterIdNo, Sequence)
        SELECT  AccountIdNo, Credit, Debit, JournalIdNo, Notes, ProfitCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PurchaseJournalItem ON;

