









CREATE PROCEDURE  [dbo].[UpdateEmployeeDocumentTVP]
  @MParam EmployeeDocumentUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeeDocument A WHERE A.EmployeeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing Documents
UPDATE a 
SET a.DataImageIdNo = B.DataImageIdNo,
	a.DocumentIdNo = B.DocumentIdNo,
	a.DocumentNumber = B.DocumentNumber,
	a.EmployeeIdNo = @GroupIdNo,
	a.ExpiryDate = B.ExpiryDate,
	a.IssueDate = B.IssueDate,	
	a.[Sequence] = B.[Sequence]
from EmployeeDocument a INNER JOIN @MParam As b
on a.IdNo = b.IdNo
WHERE ISNULL(a.DataImageIdNo, 0) <> ISNULL(b.DataImageIdNo, 0)
   OR ISNULL(a.DocumentIdNo, 0) <> ISNULL(b.DocumentIdNo, 0)
   OR ISNULL(a.DocumentNumber, '') <> ISNULL(b.DocumentNumber, '')
   OR ISNULL(a.EmployeeIdNo, 0) <> ISNULL(@GroupIdNo, 0)
   OR ISNULL(a.ExpiryDate, '19000101') <> ISNULL(b.ExpiryDate, '19000101')
   OR ISNULL(a.IssueDate, '19000101') <> ISNULL(b.IssueDate, '19000101')
   OR ISNULL(a.[Sequence], 0) <> ISNULL(b.[Sequence], 0)

END
