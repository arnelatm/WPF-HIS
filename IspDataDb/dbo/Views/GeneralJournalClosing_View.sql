

CREATE VIEW [dbo].[GeneralJournalClosing_View]
AS
SELECT        dbo.GeneralJournal.*
FROM            dbo.GeneralJournal
WHERE  dbo.GeneralJournal.ClosingJournal = 1
and dbo.GeneralJournal.Cancelled=0

GO

