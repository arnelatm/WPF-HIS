







CREATE PROC [dbo].[InsertSalesJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO SalesJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.SalesJournalItem ON;

