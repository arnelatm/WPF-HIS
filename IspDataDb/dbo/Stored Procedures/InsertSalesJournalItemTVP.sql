








CREATE PROC [dbo].[InsertSalesJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
IF EXISTS (
    SELECT 1
    FROM @MParam AS source
    INNER JOIN dbo.SalesJournalItem AS currentItem
        ON currentItem.JournalIdNo = source.JournalIdNo
    INNER JOIN dbo.Reconciled AS r
        ON r.JournalCode = 'SJ' AND r.JournalItemIdNo = currentItem.IdNo
)
    THROW 51540, 'The journal contains a line reserved by an account reconciliation.', 1;

INSERT  INTO SalesJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, PayIdNo, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, PayIdNo, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.SalesJournalItem ON;

