









CREATE   PROC [dbo].[InsertReconciledTVP]
  @MParam ReconciledInsert READONLY
AS 
INSERT  INTO Reconciled ( JournalCode, JournalItemIdNo, ReconciliationIdNo)
        SELECT  JournalCode, JournalItemIdNo, ReconciliationIdNo
        FROM    @MParam
SET IDENTITY_INSERT DBO.Reconciled ON;
