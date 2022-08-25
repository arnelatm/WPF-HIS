









CREATE PROC [dbo].[InsertEmployeeDocumentTVP]
  @MParam EmployeeDocumentInsert READONLY
AS 
INSERT  INTO EmployeeDocument (DocumentIdNo, DocumentNumber, EmployeeIdNo, ExpiryDate, Image, IssueDate, Sequence)
        SELECT  DocumentIdNo, DocumentNumber, EmployeeIdNo, ExpiryDate, Image, IssueDate, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeDocument ON;