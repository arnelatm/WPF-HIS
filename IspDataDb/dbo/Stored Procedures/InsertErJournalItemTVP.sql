








create PROC [dbo].[InsertErJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO ErJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, ProfitCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, ProfitCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.ErJournalItem ON;