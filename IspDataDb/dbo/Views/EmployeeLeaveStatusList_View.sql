Create View EmployeeLeaveStatusList_View
As 
SELECT  a.IdNo, a.AppliedBy, a.LeaveIdNo, a.StartDate, a.EndDate, a.FullDay, b.EnteredBy, b.[Status], b.Note, b.DateCreated 
from EmployeeLeave a  
Left Join EmployeeLeaveStatus b 
On a.IdNo  = b.EmployeeLeaveIdNo