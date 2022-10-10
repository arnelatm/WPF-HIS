













CREATE PROCEDURE  [dbo].[UpdatePcJournalsTVP]
  @MParam PcJournalsUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Don't Delete non existent records
-- Update existing PcJournal
UPDATE a 
SET a.CdJournalIdNo = @GroupIdNo,
	a.PcClosed = B.PcClosed
from PcJournal a
JOIN @MParam b
on a.IdNo = b.IdNo

END
