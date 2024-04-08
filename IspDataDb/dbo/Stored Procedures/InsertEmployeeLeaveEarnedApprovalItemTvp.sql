















CREATE PROC [dbo].[InsertEmployeeLeaveEarnedApprovalItemTvp]
  @MParam EmployeeLeaveEarnedApprovalItemInsert READONLY
AS 
INSERT  INTO EmployeeLeaveEarnedApprovalItem (ApprovalNote, Approved, Disapproved , EmployeeLeaveEarnedApprovalIdNo, EmployeeLeaveEarnedIdNo)
        SELECT  ApprovalNote, Approved, Disapproved, EmployeeLeaveEarnedApprovalIdNo, EmployeeLeaveEarnedIdNo
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeLeaveEarnedApprovalItem ON;