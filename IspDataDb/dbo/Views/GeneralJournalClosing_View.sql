
CREATE VIEW [dbo].[GeneralJournalClosing_View]
AS
SELECT        dbo.GeneralJournal.*
FROM            dbo.GeneralJournal
WHERE  dbo.GeneralJournal.ClosingJournal = 1