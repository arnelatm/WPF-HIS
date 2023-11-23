













CREATE PROC [dbo].[InsertEmployeeLeaveEarnedApprovalItemTvp]
  @MParam EmployeeLeaveEarnedApprovalItemInsert READONLY
AS 
INSERT  INTO EmployeeLeaveEarnedApprovalItem (ApprovalNote, EmployeeLeaveEarnedApprovalIdNo, EmployeeLeaveEarnedIdNo, [Status] )
        SELECT  ApprovalNote, EmployeeLeaveEarnedApprovalIdNo, EmployeeLeaveEarnedIdNo, [Status]
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeLeaveEarnedApprovalItem ON;