









CREATE PROC [dbo].[InsertEmployeeDocumentTVP]
  @MParam EmployeeDocumentInsert READONLY
AS 
INSERT  INTO EmployeeDocument (DataImageIdNo, DocumentIdNo, DocumentNumber, EmployeeIdNo, ExpiryDate, IssueDate, Sequence)
        SELECT  DataImageIdNo, DocumentIdNo, DocumentNumber, EmployeeIdNo, ExpiryDate, IssueDate, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeDocument ON;