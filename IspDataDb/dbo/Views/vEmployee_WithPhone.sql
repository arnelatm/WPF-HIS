CREATE VIEW dbo.vEmployee_WithPhone
AS
SELECT 
    e.IdNo,
    e.EmployeeCode,
    e.EmployeeName,
    ep.PhoneNumber
FROM dbo.Employee e
OUTER APPLY (
    SELECT TOP 1 PhoneNumber
    FROM dbo.EmployeePhone p
    WHERE p.EmployeeIdNo = e.IdNo
      AND p.PhoneTypeIdNo = 1
    ORDER BY p.IdNo ASC   -- 👈 define what "first" means
) ep;

GO

