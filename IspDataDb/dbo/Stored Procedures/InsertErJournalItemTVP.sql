









CREATE PROC [dbo].[InsertErJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
IF EXISTS (
    SELECT 1
    FROM @MParam AS source
    INNER JOIN dbo.ErJournalItem AS currentItem
        ON currentItem.JournalIdNo = source.JournalIdNo
    INNER JOIN dbo.Reconciled AS r
        ON r.JournalCode = 'ER' AND r.JournalItemIdNo = currentItem.IdNo
)
    THROW 51540, 'The journal contains a line reserved by an account reconciliation.', 1;

INSERT  INTO ErJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.ErJournalItem ON;
