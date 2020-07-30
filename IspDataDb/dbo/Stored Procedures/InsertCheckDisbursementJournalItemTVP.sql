






CREATE PROC [dbo].[InsertCheckDisbursementJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CheckDisbursementJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CheckDisbursementJournalItem ON;

