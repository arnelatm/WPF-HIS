





CREATE PROC [dbo].[InsertCashReceiptJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CashReceiptJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, ProfitCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, ProfitCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CashReceiptJournalItem ON;

