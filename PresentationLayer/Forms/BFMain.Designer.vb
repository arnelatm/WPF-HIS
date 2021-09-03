Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.LIBRARIES.CBaseControlsLibrary
Imports AATM.LIBRARIES.LocalizationUtilities
Imports AATM.Libraries.MessagingLibrary
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class BfMain
    Inherits CForm

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BfMain))
        Me.LocalizableContent1 = New AATM.Libraries.LocalizationUtilities.LocalizableContent()
        Me._MBDeletionNotAllowed = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBAddRecordFailed = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBSaveRecordFailed = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBRecordNotSaved = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBRecordSuccessfullySaved = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBUndoEdits = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBTextToFindNotFound = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBFoundLastRecStartOnFirst = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBSaveChangesBeforeMoving = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBFirstRecordAlready = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBLastRecordAlready = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBLastRecordReachedStartFromBeginning = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBDeleteRecordFailed = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBDeleteRecordAsk = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBRecordSuccessfullyDeleted = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBDependentRecordExists = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBNoChangesMadeNothingToSave = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBUniqueConstraintViolated = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MsgRecordNo = New AATM.Libraries.LocalizationUtilities.LocalizableMessage()
        Me._MsgOf = New AATM.Libraries.LocalizationUtilities.LocalizableMessage()
        Me._MBDataEntryIsNotUnique = New AATM.Libraries.LocalizationUtilities.LocalizableMessage()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TranslatorDAC = New AATM.Libraries.MessagingLibrary.Dac()
        Me.AppDataDAC = New AATM.Libraries.MessagingLibrary.Dac()
        Me.StoreCaptions1 = New AATM.Libraries.MessagingLibrary.StoreCaptions()
        Me.SuspendLayout
        '
        'LocalizableContent1
        '
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBDeletionNotAllowed)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBAddRecordFailed)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBSaveRecordFailed)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBRecordNotSaved)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBRecordSuccessfullySaved)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBUndoEdits)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBTextToFindNotFound)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBFoundLastRecStartOnFirst)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBSaveChangesBeforeMoving)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBFirstRecordAlready)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBLastRecordAlready)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBLastRecordReachedStartFromBeginning)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBDeleteRecordFailed)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBDeleteRecordAsk)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBRecordSuccessfullyDeleted)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBDependentRecordExists)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBNoChangesMadeNothingToSave)
        Me.LocalizableContent1.MessageBoxes.Add(Me._MBUniqueConstraintViolated)
        Me.LocalizableContent1.Messages.Add(Me._MsgRecordNo)
        Me.LocalizableContent1.Messages.Add(Me._MsgOf)
        Me.LocalizableContent1.Messages.Add(Me._MBDataEntryIsNotUnique)
        '
        '_MBDeletionNotAllowed
        '
        Me._MBDeletionNotAllowed.Caption = "Information"
        Me._MBDeletionNotAllowed.Text = "Deletion not allowed!"
        '
        '_MBAddRecordFailed
        '
        Me._MBAddRecordFailed.Type = AATM.Libraries.LocalizationUtilities.MessageBoxType.[Error]
        '
        '_MBSaveRecordFailed
        '
        Me._MBSaveRecordFailed.Caption = "Save Failed"
        Me._MBSaveRecordFailed.Text = "The request to save the record failed!"
        Me._MBSaveRecordFailed.Type = AATM.Libraries.LocalizationUtilities.MessageBoxType.[Error]
        '
        '_MBRecordNotSaved
        '
        Me._MBRecordNotSaved.Caption = "Save Failed"
        Me._MBRecordNotSaved.Text = "Record Not Saved!"
        Me._MBRecordNotSaved.Type = AATM.Libraries.LocalizationUtilities.MessageBoxType.[Error]
        '
        '_MBRecordSuccessfullySaved
        '
        Me._MBRecordSuccessfullySaved.Caption = "Save"
        Me._MBRecordSuccessfullySaved.Text = "Record was successfully saved."
        '
        '_MBUndoEdits
        '
        Me._MBUndoEdits.Buttons = System.Windows.Forms.MessageBoxButtons.YesNo
        Me._MBUndoEdits.Caption = "Undo Edit"
        Me._MBUndoEdits.DefaultButton = System.Windows.Forms.MessageBoxDefaultButton.Button2
        Me._MBUndoEdits.Text = "All your changes will be discarded! Are you sure you want to undo changes? "
        Me._MBUndoEdits.Type = AATM.Libraries.LocalizationUtilities.MessageBoxType.Warning
        '
        '_MBTextToFindNotFound
        '
        Me._MBTextToFindNotFound.Caption = "Text Search"
        Me._MBTextToFindNotFound.Text = "Sorry the searched text <{0}> was not found!"
        Me._MBTextToFindNotFound.Type = AATM.Libraries.LocalizationUtilities.MessageBoxType.Warning
        '
        '_MBFoundLastRecStartOnFirst
        '
        Me._MBFoundLastRecStartOnFirst.Buttons = System.Windows.Forms.MessageBoxButtons.YesNo
        Me._MBFoundLastRecStartOnFirst.Caption = "Last Record Found."
        Me._MBFoundLastRecStartOnFirst.Text = "This is already the last matching record! Do you want to start search from the fi"& _ 
    "rst record?"
        '
        '_MBSaveChangesBeforeMoving
        '
        Me._MBSaveChangesBeforeMoving.Buttons = System.Windows.Forms.MessageBoxButtons.YesNoCancel
        Me._MBSaveChangesBeforeMoving.Caption = "Changes Made"
        Me._MBSaveChangesBeforeMoving.DefaultButton = System.Windows.Forms.MessageBoxDefaultButton.Button2
        Me._MBSaveChangesBeforeMoving.Text = "Changes have been made to this record.  Press [Yes] to save changes before moving"& _ 
    ", press [No] to Abandon changes, or press [Cancel] to continue editing record? S"& _ 
    "ave Changes ?"
        '
        '_MBFirstRecordAlready
        '
        Me._MBFirstRecordAlready.Caption = "Warning!"
        Me._MBFirstRecordAlready.Text = "This is already the first record!"
        Me._MBFirstRecordAlready.Type = AATM.Libraries.LocalizationUtilities.MessageBoxType.Warning
        '
        '_MBLastRecordAlready
        '
        Me._MBLastRecordAlready.Caption = "Last Record Reached."
        Me._MBLastRecordAlready.Text = "This is already the last record!"
        '
        '_MBLastRecordReachedStartFromBeginning
        '
        Me._MBLastRecordReachedStartFromBeginning.Buttons = System.Windows.Forms.MessageBoxButtons.YesNo
        Me._MBLastRecordReachedStartFromBeginning.Caption = "Last Record Found."
        Me._MBLastRecordReachedStartFromBeginning.Text = "This is already the last matching record. Do you want to search again from the st"& _ 
    "art?"
        '
        '_MBDeleteRecordFailed
        '
        Me._MBDeleteRecordFailed.Caption = "Warning!"
        Me._MBDeleteRecordFailed.Text = "Something went wrong during deleteion. Record not deleted!"
        Me._MBDeleteRecordFailed.Type = AATM.Libraries.LocalizationUtilities.MessageBoxType.[Error]
        '
        '_MBDeleteRecordAsk
        '
        Me._MBDeleteRecordAsk.Buttons = System.Windows.Forms.MessageBoxButtons.YesNoCancel
        Me._MBDeleteRecordAsk.Caption = "Warning!"
        Me._MBDeleteRecordAsk.DefaultButton = System.Windows.Forms.MessageBoxDefaultButton.Button2
        Me._MBDeleteRecordAsk.Text = "Are you sure you want to delete this record? "
        '
        '_MBRecordSuccessfullyDeleted
        '
        Me._MBRecordSuccessfullyDeleted.Caption = "Successful Save"
        Me._MBRecordSuccessfullyDeleted.Text = "Record was successfully deleted!"
        '
        '_MBDependentRecordExists
        '
        Me._MBDependentRecordExists.Text = "Dependent record exists, deletion not allowed!"
        Me._MBDependentRecordExists.Type = AATM.Libraries.LocalizationUtilities.MessageBoxType.[Error]
        '
        '_MBNoChangesMadeNothingToSave
        '
        Me._MBNoChangesMadeNothingToSave.Text = "No changes made, nothing to save!"
        '
        '_MBUniqueConstraintViolated
        '
        Me._MBUniqueConstraintViolated.Caption = "Duplicate Entries."
        Me._MBUniqueConstraintViolated.Text = "A record with the value <{0}> entered in field <{1}> already exists on file. Dupl"& _ 
    "icates not allowed!"
        Me._MBUniqueConstraintViolated.Type = AATM.Libraries.LocalizationUtilities.MessageBoxType.[Error]
        '
        '_MsgRecordNo
        '
        Me._MsgRecordNo.Value = "Record number"
        '
        '_MsgOf
        '
        Me._MsgOf.Value = "of"
        '
        '_MBDataEntryIsNotUnique
        '
        Me._MBDataEntryIsNotUnique.Value = "Data entry is not unique"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "openbriefcase.png")
        Me.ImageList1.Images.SetKeyName(1, "TreeNode.ico")
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = ""
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = ""
        '
        'BfMain
        '
        Me.ClientSize = New System.Drawing.Size(1114, 709)
        Me.Name = "BfMain"
        Me.Text = "Base Form"
        Me.ViewDisplayName = ""
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents _MBDeletionNotAllowed As LocalizableMessageBox
    Friend WithEvents _MBAddRecordFailed As LocalizableMessageBox
    Friend WithEvents _MBSaveRecordFailed As LocalizableMessageBox
    Friend WithEvents _MBRecordNotSaved As LocalizableMessageBox
    Friend WithEvents _MBRecordSuccessfullySaved As LocalizableMessageBox
    Friend WithEvents _MBUndoEdits As LocalizableMessageBox
    Friend WithEvents _MBTextToFindNotFound As LocalizableMessageBox
    Friend WithEvents _MBFoundLastRecStartOnFirst As LocalizableMessageBox
    Friend WithEvents _MBSaveChangesBeforeMoving As LocalizableMessageBox
    Friend WithEvents _MBFirstRecordAlready As LocalizableMessageBox
    Friend WithEvents _MBLastRecordAlready As LocalizableMessageBox
    Friend WithEvents _MBLastRecordReachedStartFromBeginning As LocalizableMessageBox
    Friend WithEvents _MBDeleteRecordFailed As LocalizableMessageBox
    Friend WithEvents _MBDeleteRecordAsk As LocalizableMessageBox
    Friend WithEvents _MBRecordSuccessfullyDeleted As LocalizableMessageBox
    Friend WithEvents _MBDependentRecordExists As LocalizableMessageBox
    Friend WithEvents _MBNoChangesMadeNothingToSave As LocalizableMessageBox
    Friend WithEvents _MsgRecordNo As LocalizableMessage
    Friend WithEvents _MsgOf As LocalizableMessage
    Friend WithEvents _MBDataEntryIsNotUnique As LocalizableMessage
    Friend WithEvents LocalizableContent1 As LocalizableContent
    Friend WithEvents _MBUniqueConstraintViolated As LocalizableMessageBox
    Friend WithEvents BackgroundWorker1 As BackgroundWorker
    Protected WithEvents StoreCaptions1 As StoreCaptions
    Public WithEvents TranslatorDAC As Dac
    Public WithEvents AppDataDAC As Dac
End Class
