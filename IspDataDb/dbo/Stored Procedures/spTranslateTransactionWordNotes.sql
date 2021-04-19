









CREATE PROCEDURE  [dbo].[spTranslateTransactionWordNotes]
  @parameter2 as nVarChar(max), @parameter1 as nVarchar(max)
AS 

BEGIN
    DECLARE @matchValue AS NVARCHAR(MAX) 
	DECLARE @OldValue AS NVARCHAR(mAX)
	DECLARE @NewValue AS NVARCHAR(MAX)
	set @oldValue = RTrim(LTrim(@parameter1))
	set @newValue = RTrim(LTrim(@parameter2))
	SET @matchValue = '%' + @OldValue + '%'
	Update GeneralJournalItem set NOTES = REPLACE(Notes, @OldValue,@NewValue) FROM GENERALJOURNALITEM where notes Like @matchValue 
	Update GeneralJournal SET NOTES = REPLACE(Notes, @OldValue,@NewValue) FROM GENERALJOURNAL where notes like @matchValue
	Update ArJournalItem set NOTES = REPLACE(Notes, @OldValue,@NewValue) FROM ArJournalITEM where notes Like @matchValue 
	Update ArJournal set NOTES = REPLACE(Notes, @OldValue,@NewValue) FROM ArJournal where notes Like @matchValue 
    Update ApJournalItem set NOTES = REPLACE(Notes, @OldValue,@NewValue) FROM ApJournalITEM where notes Like @matchValue 
	Update ApJournal set NOTES = REPLACE(Notes, @OldValue,@NewValue) FROM ApJournal where notes Like @matchValue 
	Update CashReceiptJournalItem set NOTES = REPLACE(Notes, @OldValue,@NewValue) FROM CashReceiptJournalITEM where notes Like @matchValue 
	Update CashReceiptJournal set NOTES = REPLACE(Notes, @OldValue,@NewValue) FROM CashReceiptJournal where notes Like @matchValue 
	Update CdJournalItem set NOTES = REPLACE(Notes, @OldValue,@NewValue) FROM CdJournalITEM where notes Like @matchValue 
	Update CdJournal set NOTES = REPLACE(Notes, @OldValue,@NewValue) FROM CdJournal where notes Like @matchValue 
	Update PcJournalItem set NOTES = REPLACE(Notes, @OldValue,@NewValue) FROM PcJournalITEM where notes Like @matchValue 
	Update PcJournal set NOTES = REPLACE(Notes, @OldValue,@NewValue) FROM PcJournal where notes Like @matchValue 
	Update ErJournalItem set NOTES = REPLACE(Notes, @OldValue,@NewValue) FROM ErJournalITEM where notes Like @matchValue 
	Update ErJournal set NOTES = REPLACE(Notes, @OldValue,@NewValue) FROM ErJournal where notes Like @matchValue 
END