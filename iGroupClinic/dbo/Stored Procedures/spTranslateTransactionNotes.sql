








CREATE PROCEDURE  [dbo].[spTranslateTransactionNotes]
  @parameter2 as nVarChar(max), @parameter1 as nVarchar(max)
AS 

BEGIN
    DECLARE @matchValue AS NVARCHAR(MAX) 
    Update GeneralJournalItem set NOTES = @parameter2 FROM GENERALJOURNALITEM where GeneralJournalItem.notes = @parameter1 
	Update GeneralJournal set NOTES = @parameter2 FROM GENERALJOURNALITEM where GeneralJournal.notes = @parameter1 
	Update ArJournalItem set NOTES = @parameter2 FROM ArJournalITEM where ArJournalItem.notes = @parameter1 
	Update ArJournal set NOTES = @parameter2 FROM ArJournalITEM where ArJournal.notes = @parameter1 
    Update ApJournalItem set NOTES = @parameter2 FROM ApJournalITEM where ApJournalItem.notes = @parameter1 
	Update ApJournal set NOTES = @parameter2 FROM ApJournalITEM where ApJournal.notes = @parameter1 
	Update CashReceiptJournalItem set NOTES = @parameter2 FROM CashReceiptJournalITEM where CashReceiptJournalItem.notes = @parameter1 
	Update CashReceiptJournal set NOTES = @parameter2 FROM CashReceiptJournalITEM where CashReceiptJournal.notes = @parameter1 
	Update CdJournalItem set NOTES = @parameter2 FROM CdJournalITEM where CdJournalItem.notes = @parameter1 
	Update CdJournal set NOTES = @parameter2 FROM CdJournalITEM where CdJournal.notes = @parameter1 
	Update PcJournalItem set NOTES = @parameter2 FROM PcJournalITEM where PcJournalItem.notes = @parameter1 
	Update PcJournal set NOTES = @parameter2 FROM PcJournalITEM where PcJournal.notes = @parameter1 
	Update ErJournalItem set NOTES = @parameter2 FROM ErJournalITEM where ErJournalItem.notes = @parameter1 
	Update ErJournal set NOTES = @parameter2 FROM ErJournalITEM where ErJournal.notes = @parameter1 
END