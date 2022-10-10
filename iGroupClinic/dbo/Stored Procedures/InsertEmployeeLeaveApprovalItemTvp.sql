












CREATE PROC [dbo].[InsertEmployeeLeaveApprovalItemTvp]
  @MParam EmployeeLeaveApprovalItemInsert READONLY
AS 
INSERT  INTO EmployeeLeaveApprovalItem (ApprovalNote, EmployeeLeaveApprovalIdNo, EmployeeLeaveIdNo, [Status] )
        SELECT  ApprovalNote, EmployeeLeaveApprovalIdNo, EmployeeLeaveidNo, [Status]
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeLeaveApprovalItem ON;