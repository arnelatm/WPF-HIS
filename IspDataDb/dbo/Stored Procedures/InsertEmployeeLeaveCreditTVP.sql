








CREATE PROC [dbo].[InsertEmployeeLeaveCreditTVP]
  @MParam EmployeeLeaveCreditInsert READONLY
AS 
INSERT  INTO EmployeeLeaveCredit ( AccumulatedLeave, Cumulative, EmployeeIdNo, LeaveAllowed, LeaveIdNo, MaxCarryOver, MaxLimit, PaidPercent, [Sequence])
        SELECT  AccumulatedLeave, Cumulative, EmployeeIdNo, LeaveAllowed, LeaveIdNo, MaxCarryOver, MaxLimit, PaidPercent, [Sequence]
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeLeaveCredit ON;