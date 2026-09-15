













CREATE PROCEDURE  [dbo].[UpdateEmployeeLeaveCreditTVP]
  @MParam EmployeeLeaveCreditUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeeLeaveCredit A WHERE A.EmployeeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing LeaveCredits
UPDATE a 
SET a.AccumulatedLeave = B.AccumulatedLeave,
	a.Cumulative = B.Cumulative,
	a.EmployeeIdNo = @GroupIdNo,
	a.LeaveAllowed = B.LeaveAllowed,
	a.LeaveIdNo = B.LeaveIdNo,
	a.MaxCarryOver = B.MaxCarryOver,
	a.MaxLimit = B.MaxLimit,
	a.NoMaxLimit = B.NoMaxLimit,
	a.PaidPercent = B.PaidPercent,
	a.[Sequence] = B.[Sequence]	
from EmployeeLeaveCredit a INNER JOIN @MParam As b
on a.IdNo = b.IdNo
WHERE EXISTS (SELECT a.AccumulatedLeave, a.Cumulative, a.EmployeeIdNo, a.LeaveAllowed, a.LeaveIdNo,
                     a.MaxCarryOver, a.MaxLimit, a.NoMaxLimit, a.PaidPercent, a.[Sequence]
              EXCEPT SELECT b.AccumulatedLeave, b.Cumulative, @GroupIdNo, b.LeaveAllowed, b.LeaveIdNo,
                     b.MaxCarryOver, b.MaxLimit, b.NoMaxLimit, b.PaidPercent, b.[Sequence])

END
