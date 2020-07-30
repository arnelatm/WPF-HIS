






CREATE PROC [dbo].[InsertCashReceiptJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CashReceiptJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CashReceiptJournalItem ON;

