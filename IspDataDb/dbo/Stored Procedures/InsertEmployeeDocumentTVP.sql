









CREATE PROC [dbo].[InsertEmployeeDocumentTVP]
  @MParam EmployeeDocumentInsert READONLY
AS 
INSERT  INTO EmployeeDocument (DocumentIdNo, DocumentImage, DocumentNumber, EmployeeIdNo, ExpiryDate, IssueDate, Sequence)
        SELECT  DocumentIdNo, DocumentImage, DocumentNumber, EmployeeIdNo, ExpiryDate, IssueDate, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeDocument ON;