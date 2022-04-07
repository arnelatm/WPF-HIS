






CREATE PROC [dbo].[InsertGeneralJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO GeneralJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, PayIdNo, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, PayIdNo, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.GeneralJournalItem ON;

