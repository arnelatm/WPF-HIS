








CREATE PROCEDURE  [dbo].[UpdateEmployeeDocumentTVP]
  @MParam EmployeeDocumentUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeeDocument A WHERE A.EmployeeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing Documents
UPDATE a 
SET a.DocumentIdNo = B.DocumentIdNo,
	a.DocumentImage = B.DocumentImage,
	a.DocumentNumber = B.DocumentNumber,
	a.EmployeeIdNo = @GroupIdNo,
	a.IssueDate = B.IssueDate,
	a.ExpiryDate = B.ExpiryDate,
	a.[Sequence] = B.[Sequence]
from EmployeeDocument a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END