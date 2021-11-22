











CREATE PROC [dbo].[InsertEmployeeLeaveApprovalItemTvp]
  @MParam EmployeeLeaveApprovalItemInsert READONLY
AS 
INSERT  INTO EmployeeLeaveApprovalItem (EmployeeLeaveApprovalIdNo, EmployeeLeaveIdNo, Note, [Status] )
        SELECT  EmployeeLeaveApprovalIdNo, EmployeeLeaveidNo, Note, [Status]
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeLeaveApprovalItem ON;