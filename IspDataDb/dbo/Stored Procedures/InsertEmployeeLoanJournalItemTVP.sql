






CREATE PROC [dbo].[InsertEmployeeLoanJournalItemTVP]
  @MParam EmployeeLoanJournalItemInsert READONLY
AS 
INSERT  INTO EmployeeLoanJournalItem (JournalIdNo, Sequence, AccountIdNo, Debit, Credit, RevCostCenterIdNo, Notes)
        SELECT  JournalIdNo, Sequence, AccountIdNo, Debit, Credit, RevCostCenteridNo, Notes
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeLoanJournalItem ON;

