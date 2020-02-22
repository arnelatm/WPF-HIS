Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary
Imports Microsoft.VisualBasic.CompilerServices
Imports AATM.Libraries.LocalizationUtilities
<DesignerGenerated()>
Partial Class BfEntry
    Inherits BfMain

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BfEntry))
        Me.LocalizableContent1 = New LocalizableContent()
        Me._MBDeletionNotAllowed = New LocalizableMessageBox()
        Me._MBAddRecordFailed = New LocalizableMessageBox()
        Me._MBSaveRecordFailed = New LocalizableMessageBox()
        Me._MBRecordNotSaved = New LocalizableMessageBox()
        Me._MBRecordSuccessfullySaved = New LocalizableMessageBox()
        Me._MBUndoEdits = New LocalizableMessageBox()
        Me._MBTextToFindNotFound = New LocalizableMessageBox()
        Me._MBFoundLastRecStartOnFirst = New LocalizableMessageBox()
        Me._MBSaveChangesBeforeMoving = New LocalizableMessageBox()
        Me._MBFirstRecordAlready = New LocalizableMessageBox()
        Me._MBLastRecordAlready = New LocalizableMessageBox()
        Me._MBLastRecordReachedStartFromBeginning = New LocalizableMessageBox()
        Me._MBDeleteRecordFailed = New LocalizableMessageBox()
        Me._MBDeleteRecordAsk = New LocalizableMessageBox()
        Me._MBRecordSuccessfullyDeleted = New LocalizableMessageBox()
        Me._MBDependentRecordExists = New LocalizableMessageBox()
        Me._MBNoChangesMadeNothingToSave = New LocalizableMessageBox()
        Me._MBUniqueConstraintViolated = New LocalizableMessageBox()
        Me._MsgRecordNo = New LocalizableMessage()
        Me._MsgOf = New LocalizableMessage()
        Me._MBDataEntryIsNotUnique = New LocalizableMessage()
        Me._localizableMessage1 = New LocalizableMessage()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.floNavigationButtons = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.LblRecordCount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnArabic = New CButton()
        Me.btnOriginal = New CButton()
        Me.CButton1 = New CButton()
        Me.BtnAdd = New CButton()
        Me.BtnEdit = New CButton()
        Me.BtnDelete = New CButton()
        Me.BtnSave = New CButton()
        Me.BtnFind = New CButton()
        Me.BtnFirst = New CButton()
        Me.BtnPrev = New CButton()
        Me.BtnNext = New CButton()
        Me.BtnLast = New CButton()
        Me.BtnUndo = New CButton()
        Me.BtnQuit = New CButton()
        Me.floNavigationAndRecordCounter = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.floNavigationButtons.SuspendLayout()
        Me.floNavigationAndRecordCounter.SuspendLayout()
        Me.SuspendLayout()
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
        Me.LocalizableContent1.Messages.Add(Me._localizableMessage1)
        '
        '_MBDeletionNotAllowed
        '
        Me._MBDeletionNotAllowed.Caption = "Information"
        Me._MBDeletionNotAllowed.Text = "Deletion not allowed!"
        '
        '_MBAddRecordFailed
        '
        Me._MBAddRecordFailed.Type = MessageBoxType.[Error]
        '
        '_MBSaveRecordFailed
        '
        Me._MBSaveRecordFailed.Caption = "Save Failed"
        Me._MBSaveRecordFailed.Text = "The request to save the record failed!"
        Me._MBSaveRecordFailed.Type = MessageBoxType.[Error]
        '
        '_MBRecordNotSaved
        '
        Me._MBRecordNotSaved.Caption = "Save Failed"
        Me._MBRecordNotSaved.Text = "Record Not Saved!"
        Me._MBRecordNotSaved.Type = MessageBoxType.[Error]
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
        Me._MBUndoEdits.Type = MessageBoxType.Warning
        '
        '_MBTextToFindNotFound
        '
        Me._MBTextToFindNotFound.Caption = "Text Search"
        Me._MBTextToFindNotFound.Text = "Sorry the searched text <{0}> was not found!"
        Me._MBTextToFindNotFound.Type = MessageBoxType.Warning
        '
        '_MBFoundLastRecStartOnFirst
        '
        Me._MBFoundLastRecStartOnFirst.Buttons = System.Windows.Forms.MessageBoxButtons.YesNo
        Me._MBFoundLastRecStartOnFirst.Caption = "Last Record Found."
        Me._MBFoundLastRecStartOnFirst.Text = "This is already the last matching record! Do you want to start search from the fi" &
    "rst record?"
        '
        '_MBSaveChangesBeforeMoving
        '
        Me._MBSaveChangesBeforeMoving.Buttons = System.Windows.Forms.MessageBoxButtons.YesNoCancel
        Me._MBSaveChangesBeforeMoving.Caption = "Changes Made"
        Me._MBSaveChangesBeforeMoving.DefaultButton = System.Windows.Forms.MessageBoxDefaultButton.Button2
        Me._MBSaveChangesBeforeMoving.Text = "Changes have been made to this record.  Press [Yes] to save changes before moving" &
    ", press [No] to Abandon changes, or press [Cancel] to continue editing record? S" &
    "ave Changes ?"
        '
        '_MBFirstRecordAlready
        '
        Me._MBFirstRecordAlready.Caption = "Warning!"
        Me._MBFirstRecordAlready.Text = "This is already the first record!"
        Me._MBFirstRecordAlready.Type = MessageBoxType.Warning
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
        Me._MBLastRecordReachedStartFromBeginning.Text = "This is already the last matching record. Do you want to search again from the st" &
    "art?"
        '
        '_MBDeleteRecordFailed
        '
        Me._MBDeleteRecordFailed.Caption = "Warning!"
        Me._MBDeleteRecordFailed.Text = "Something went wrong during deleteion. Record not deleted!"
        Me._MBDeleteRecordFailed.Type = MessageBoxType.[Error]
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
        Me._MBDependentRecordExists.Type = MessageBoxType.[Error]
        '
        '_MBNoChangesMadeNothingToSave
        '
        Me._MBNoChangesMadeNothingToSave.Text = "No changes made, nothing to save!"
        '
        '_MBUniqueConstraintViolated
        '
        Me._MBUniqueConstraintViolated.Caption = "Duplicate Entries."
        Me._MBUniqueConstraintViolated.Text = "A record with the value <{0}> entered in field <{1}> already exists on file. Dupl" &
    "icates not allowed!"
        Me._MBUniqueConstraintViolated.Type = MessageBoxType.[Error]
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
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "openbriefcase.png")
        Me.ImageList1.Images.SetKeyName(1, "TreeNode.ico")
        '
        'floNavigationButtons
        '
        Me.floNavigationButtons.AutoSize = True
        Me.floNavigationButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.floNavigationButtons.Controls.Add(Me.LblRecordCount)
        Me.floNavigationButtons.Controls.Add(Me.btnArabic)
        Me.floNavigationButtons.Controls.Add(Me.btnOriginal)
        Me.floNavigationButtons.Controls.Add(Me.CButton1)
        Me.floNavigationButtons.Controls.Add(Me.BtnAdd)
        Me.floNavigationButtons.Controls.Add(Me.BtnEdit)
        Me.floNavigationButtons.Controls.Add(Me.BtnDelete)
        Me.floNavigationButtons.Controls.Add(Me.BtnSave)
        Me.floNavigationButtons.Controls.Add(Me.BtnFind)
        Me.floNavigationButtons.Controls.Add(Me.BtnFirst)
        Me.floNavigationButtons.Controls.Add(Me.BtnPrev)
        Me.floNavigationButtons.Controls.Add(Me.BtnNext)
        Me.floNavigationButtons.Controls.Add(Me.BtnLast)
        Me.floNavigationButtons.Controls.Add(Me.BtnUndo)
        Me.floNavigationButtons.Controls.Add(Me.BtnQuit)
        Me.floNavigationButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.floNavigationAndRecordCounter.SetFlowBreak(Me.floNavigationButtons, True)
        Me.floNavigationButtons.Location = New System.Drawing.Point(3, 3)
        Me.floNavigationButtons.Name = "floNavigationButtons"
        Me.floNavigationButtons.Size = New System.Drawing.Size(817, 77)
        Me.floNavigationButtons.TabIndex = 12
        '
        'LblRecordCount
        '
        Me.LblRecordCount.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblRecordCount.AutoSize = True
        Me.LblRecordCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.LblRecordCount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblRecordCount.Location = New System.Drawing.Point(1, 6)
        Me.LblRecordCount.Margin = New System.Windows.Forms.Padding(1)
        Me.LblRecordCount.Name = "LblRecordCount"
        Me.LblRecordCount.Size = New System.Drawing.Size(122, 17)
        Me.LblRecordCount.TabIndex = 16
        Me.LblRecordCount.Text = "Record <x> of <x>"
        Me.LblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnArabic
        '
        Me.btnArabic.BackColor = System.Drawing.Color.Transparent
        Me.btnArabic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnArabic.DesignerSelected = False
        Me.btnArabic.DisplayOnly = True
        Me.btnArabic.ImageIndex = 0
        Me.btnArabic.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnArabic.Location = New System.Drawing.Point(127, 3)
        Me.btnArabic.Name = "btnArabic"
        Me.btnArabic.OriginalImageName = Nothing
        Me.btnArabic.SecurityKey = ""
        Me.btnArabic.Size = New System.Drawing.Size(32, 23)
        Me.btnArabic.TabIndex = 14
        Me.btnArabic.Text = "ع"
        '
        'btnOriginal
        '
        Me.btnOriginal.BackColor = System.Drawing.Color.Transparent
        Me.btnOriginal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOriginal.DesignerSelected = False
        Me.btnOriginal.DisplayOnly = True
        Me.btnOriginal.ImageIndex = 0
        Me.btnOriginal.Location = New System.Drawing.Point(165, 3)
        Me.btnOriginal.Name = "btnOriginal"
        Me.btnOriginal.OriginalImageName = Nothing
        Me.btnOriginal.SecurityKey = ""
        Me.btnOriginal.Size = New System.Drawing.Size(39, 23)
        Me.btnOriginal.TabIndex = 13
        Me.btnOriginal.Text = "Eng"
        '
        'CButton1
        '
        Me.CButton1.BackColor = System.Drawing.Color.Transparent
        Me.CButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CButton1.DesignerSelected = False
        Me.CButton1.DisplayOnly = True
        Me.floNavigationButtons.SetFlowBreak(Me.CButton1, True)
        Me.CButton1.ImageIndex = 0
        Me.CButton1.Location = New System.Drawing.Point(210, 3)
        Me.CButton1.Name = "CButton1"
        Me.CButton1.OriginalImageName = Nothing
        Me.CButton1.SecurityKey = ""
        Me.CButton1.Size = New System.Drawing.Size(111, 23)
        Me.CButton1.TabIndex = 17
        Me.CButton1.Text = "Translate This Form"
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.White
        Me.BtnAdd.DesignerSelected = False
        Me.BtnAdd.DisplayOnly = True
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnAdd.ImageIndex = 0
        Me.BtnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnAdd.Location = New System.Drawing.Point(3, 32)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.OriginalImageName = Nothing
        Me.BtnAdd.SecurityKey = ""
        Me.BtnAdd.Size = New System.Drawing.Size(65, 42)
        Me.BtnAdd.TabIndex = 1
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.White
        Me.BtnEdit.DesignerSelected = False
        Me.BtnEdit.DisplayOnly = True
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), System.Drawing.Image)
        Me.BtnEdit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnEdit.ImageIndex = 0
        Me.BtnEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnEdit.Location = New System.Drawing.Point(74, 32)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.OriginalImageName = Nothing
        Me.BtnEdit.SecurityKey = ""
        Me.BtnEdit.Size = New System.Drawing.Size(65, 42)
        Me.BtnEdit.TabIndex = 2
        Me.BtnEdit.Text = "&Edit"
        Me.BtnEdit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.White
        Me.BtnDelete.DesignerSelected = False
        Me.BtnDelete.DisplayOnly = True
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnDelete.ImageIndex = 0
        Me.BtnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnDelete.Location = New System.Drawing.Point(145, 32)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.OriginalImageName = Nothing
        Me.BtnDelete.SecurityKey = ""
        Me.BtnDelete.Size = New System.Drawing.Size(69, 42)
        Me.BtnDelete.TabIndex = 6
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.DesignerSelected = False
        Me.BtnSave.DisplayOnly = True
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSave.ImageIndex = 0
        Me.BtnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnSave.Location = New System.Drawing.Point(220, 32)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.OriginalImageName = Nothing
        Me.BtnSave.SecurityKey = ""
        Me.BtnSave.Size = New System.Drawing.Size(65, 42)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnFind
        '
        Me.BtnFind.BackColor = System.Drawing.Color.White
        Me.BtnFind.DesignerSelected = False
        Me.BtnFind.DisplayOnly = True
        Me.BtnFind.Image = CType(resources.GetObject("BtnFind.Image"), System.Drawing.Image)
        Me.BtnFind.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnFind.ImageIndex = 0
        Me.BtnFind.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnFind.Location = New System.Drawing.Point(291, 32)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.OriginalImageName = Nothing
        Me.BtnFind.SecurityKey = ""
        Me.BtnFind.Size = New System.Drawing.Size(83, 42)
        Me.BtnFind.TabIndex = 8
        Me.BtnFind.Text = "&Find Next"
        Me.BtnFind.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnFirst
        '
        Me.BtnFirst.BackColor = System.Drawing.Color.White
        Me.BtnFirst.DesignerSelected = False
        Me.BtnFirst.DisplayOnly = True
        Me.BtnFirst.Image = CType(resources.GetObject("BtnFirst.Image"), System.Drawing.Image)
        Me.BtnFirst.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnFirst.ImageIndex = 0
        Me.BtnFirst.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnFirst.Location = New System.Drawing.Point(380, 32)
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.OriginalImageName = Nothing
        Me.BtnFirst.SecurityKey = ""
        Me.BtnFirst.Size = New System.Drawing.Size(65, 42)
        Me.BtnFirst.TabIndex = 9
        Me.BtnFirst.Text = "F&irst"
        Me.BtnFirst.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnPrev
        '
        Me.BtnPrev.BackColor = System.Drawing.Color.White
        Me.BtnPrev.DesignerSelected = False
        Me.BtnPrev.DisplayOnly = True
        Me.BtnPrev.Image = CType(resources.GetObject("BtnPrev.Image"), System.Drawing.Image)
        Me.BtnPrev.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnPrev.ImageIndex = 0
        Me.BtnPrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnPrev.Location = New System.Drawing.Point(451, 32)
        Me.BtnPrev.Name = "BtnPrev"
        Me.BtnPrev.OriginalImageName = Nothing
        Me.BtnPrev.SecurityKey = ""
        Me.BtnPrev.Size = New System.Drawing.Size(79, 42)
        Me.BtnPrev.TabIndex = 10
        Me.BtnPrev.Text = "&Previous"
        Me.BtnPrev.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnNext
        '
        Me.BtnNext.BackColor = System.Drawing.Color.White
        Me.BtnNext.DesignerSelected = False
        Me.BtnNext.DisplayOnly = True
        Me.BtnNext.Image = CType(resources.GetObject("BtnNext.Image"), System.Drawing.Image)
        Me.BtnNext.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnNext.ImageIndex = 0
        Me.BtnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnNext.Location = New System.Drawing.Point(536, 32)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.OriginalImageName = Nothing
        Me.BtnNext.SecurityKey = ""
        Me.BtnNext.Size = New System.Drawing.Size(65, 42)
        Me.BtnNext.TabIndex = 11
        Me.BtnNext.Text = "&Next"
        Me.BtnNext.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnLast
        '
        Me.BtnLast.BackColor = System.Drawing.Color.White
        Me.BtnLast.DesignerSelected = False
        Me.BtnLast.DisplayOnly = True
        Me.BtnLast.Image = CType(resources.GetObject("BtnLast.Image"), System.Drawing.Image)
        Me.BtnLast.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnLast.ImageIndex = 0
        Me.BtnLast.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnLast.Location = New System.Drawing.Point(607, 32)
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.OriginalImageName = Nothing
        Me.BtnLast.SecurityKey = ""
        Me.BtnLast.Size = New System.Drawing.Size(65, 42)
        Me.BtnLast.TabIndex = 12
        Me.BtnLast.Text = "&Last"
        Me.BtnLast.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnUndo
        '
        Me.BtnUndo.BackColor = System.Drawing.Color.White
        Me.BtnUndo.CausesValidation = False
        Me.BtnUndo.DesignerSelected = False
        Me.BtnUndo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnUndo.DisplayOnly = True
        Me.BtnUndo.Image = CType(resources.GetObject("BtnUndo.Image"), System.Drawing.Image)
        Me.BtnUndo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnUndo.ImageIndex = 0
        Me.BtnUndo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnUndo.Location = New System.Drawing.Point(678, 32)
        Me.BtnUndo.Name = "BtnUndo"
        Me.BtnUndo.OriginalImageName = Nothing
        Me.BtnUndo.SecurityKey = ""
        Me.BtnUndo.Size = New System.Drawing.Size(65, 42)
        Me.BtnUndo.TabIndex = 13
        Me.BtnUndo.Text = "&Undo"
        Me.BtnUndo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnQuit
        '
        Me.BtnQuit.BackColor = System.Drawing.Color.White
        Me.BtnQuit.DesignerSelected = False
        Me.BtnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnQuit.DisplayOnly = True
        Me.BtnQuit.Image = CType(resources.GetObject("BtnQuit.Image"), System.Drawing.Image)
        Me.BtnQuit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnQuit.ImageIndex = 0
        Me.BtnQuit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnQuit.Location = New System.Drawing.Point(749, 32)
        Me.BtnQuit.Name = "BtnQuit"
        Me.BtnQuit.OriginalImageName = Nothing
        Me.BtnQuit.SecurityKey = ""
        Me.BtnQuit.Size = New System.Drawing.Size(65, 42)
        Me.BtnQuit.TabIndex = 14
        Me.BtnQuit.Text = "&Quit"
        Me.BtnQuit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'floNavigationAndRecordCounter
        '
        Me.floNavigationAndRecordCounter.AutoSize = True
        Me.floNavigationAndRecordCounter.BackColor = System.Drawing.Color.Transparent
        Me.floNavigationAndRecordCounter.Controls.Add(Me.floNavigationButtons)
        Me.floNavigationAndRecordCounter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.floNavigationAndRecordCounter.Location = New System.Drawing.Point(0, 445)
        Me.floNavigationAndRecordCounter.Name = "floNavigationAndRecordCounter"
        Me.floNavigationAndRecordCounter.Size = New System.Drawing.Size(852, 83)
        Me.floNavigationAndRecordCounter.TabIndex = 0
        '
        'BfEntry
        '
        Me.ClientSize = New System.Drawing.Size(852, 528)
        Me.Controls.Add(Me.floNavigationAndRecordCounter)
        Me.MinimumSize = New System.Drawing.Size(320, 250)
        Me.Name = "BfEntry"
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.floNavigationButtons.ResumeLayout(False)
        Me.floNavigationButtons.PerformLayout()
        Me.floNavigationAndRecordCounter.ResumeLayout(False)
        Me.floNavigationAndRecordCounter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents BtnAdd As CButton
    Protected WithEvents BtnEdit As CButton
    Protected WithEvents BtnDelete As CButton
    Protected WithEvents BtnSave As CButton
    Protected WithEvents BtnFind As CButton
    Protected WithEvents BtnFirst As CButton
    Protected WithEvents BtnPrev As CButton
    Protected WithEvents BtnNext As CButton
    Protected WithEvents BtnLast As CButton
    Protected WithEvents BtnUndo As CButton
    Protected WithEvents BtnQuit As CButton
    Friend WithEvents floNavigationAndRecordCounter As CFlowLayout
    Public WithEvents floNavigationButtons As CFlowLayout
    Friend WithEvents LblRecordCount As CLabel
    Friend WithEvents _localizableMessage1 As LocalizableMessage
    Friend WithEvents btnOriginal As CButton
    Friend WithEvents btnArabic As CButton
    Friend WithEvents CButton1 As CButton
End Class
