





create PROC [dbo].[InsertEmployeeLoanJournalItemTVP]
  @MParam EmployeeLoanJournalItemInsert READONLY
AS 
INSERT  INTO EmployeeLoanJournalItem (JournalIdNo, Sequence, AccountIdNo, Debit, Credit, ProfitCenterIdNo, Notes)
        SELECT  JournalIdNo, Sequence, AccountIdNo, Debit, Credit, ProfitCenteridNo, Notes
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeLoanJournalItem ON;

