Imports AATM.Libraries.CBaseControlsLibrary

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CFormEntry
    Inherits BFMain

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CFormEntry))
        Me.LocalizableContent1 = New AATM.LocalizationUtilities.LocalizableContent()
        Me._MBDeletionNotAllowed = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBAddRecordFailed = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBSaveRecordFailed = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBRecordNotSaved = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBRecordSuccessfullySaved = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBUndoEdits = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBTextToFindNotFound = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBFoundLastRecStartOnFirst = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBSaveChangesBeforeMoving = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBFirstRecordAlready = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBLastRecordAlready = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBLastRecordReachedStartFromBeginning = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBDeleteRecordFailed = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBDeleteRecordAsk = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBRecordSuccessfullyDeleted = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBDependentRecordExists = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBNoChangesMadeNothingToSave = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MBUniqueConstraintViolated = New AATM.LocalizationUtilities.LocalizableMessageBox()
        Me._MsgRecordNo = New AATM.LocalizationUtilities.LocalizableMessage()
        Me._MsgOf = New AATM.LocalizationUtilities.LocalizableMessage()
        Me._MBDataEntryIsNotUnique = New AATM.LocalizationUtilities.LocalizableMessage()
        Me._localizableMessage1 = New AATM.LocalizationUtilities.LocalizableMessage()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.floNavigationButtons = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.LblRecordCount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnArabic = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnOriginal = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.BtnAdd = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.BtnEdit = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.BtnDelete = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.BtnSave = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.BtnFind = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.BtnFirst = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.BtnPrev = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.BtnNext = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.BtnLast = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.BtnUndo = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.BtnQuit = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.floNavigationAndRecordCounter = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floNavigationButtons.SuspendLayout
        Me.floNavigationAndRecordCounter.SuspendLayout
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
        Me.LocalizableContent1.Messages.Add(Me._localizableMessage1)
        '
        '_MBDeletionNotAllowed
        '
        Me._MBDeletionNotAllowed.Caption = "Information"
        Me._MBDeletionNotAllowed.Text = "Deletion not allowed!"
        '
        '_MBAddRecordFailed
        '
        Me._MBAddRecordFailed.Type = AATM.LocalizationUtilities.MessageBoxType.[Error]
        '
        '_MBSaveRecordFailed
        '
        Me._MBSaveRecordFailed.Caption = "Save Failed"
        Me._MBSaveRecordFailed.Text = "The request to save the record failed!"
        Me._MBSaveRecordFailed.Type = AATM.LocalizationUtilities.MessageBoxType.[Error]
        '
        '_MBRecordNotSaved
        '
        Me._MBRecordNotSaved.Caption = "Save Failed"
        Me._MBRecordNotSaved.Text = "Record Not Saved!"
        Me._MBRecordNotSaved.Type = AATM.LocalizationUtilities.MessageBoxType.[Error]
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
        Me._MBUndoEdits.Type = AATM.LocalizationUtilities.MessageBoxType.Warning
        '
        '_MBTextToFindNotFound
        '
        Me._MBTextToFindNotFound.Caption = "Text Search"
        Me._MBTextToFindNotFound.Text = "Sorry the searched text <{0}> was not found!"
        Me._MBTextToFindNotFound.Type = AATM.LocalizationUtilities.MessageBoxType.Warning
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
        Me._MBFirstRecordAlready.Type = AATM.LocalizationUtilities.MessageBoxType.Warning
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
        Me._MBDeleteRecordFailed.Type = AATM.LocalizationUtilities.MessageBoxType.[Error]
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
        Me._MBDependentRecordExists.Type = AATM.LocalizationUtilities.MessageBoxType.[Error]
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
        Me._MBUniqueConstraintViolated.Type = AATM.LocalizationUtilities.MessageBoxType.[Error]
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
        'floNavigationButtons
        '
        Me.floNavigationButtons.AutoSize = true
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
        Me.floNavigationAndRecordCounter.SetFlowBreak(Me.floNavigationButtons, true)
        Me.floNavigationButtons.Location = New System.Drawing.Point(3, 3)
        Me.floNavigationButtons.Name = "floNavigationButtons"
        Me.floNavigationButtons.Size = New System.Drawing.Size(725, 58)
        Me.floNavigationButtons.TabIndex = 12
        '
        'LblRecordCount
        '
        Me.LblRecordCount.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblRecordCount.AutoSize = true
        Me.LblRecordCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
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
        Me.btnArabic.AutoSize = true
        Me.btnArabic.BackColor = System.Drawing.Color.Transparent
        Me.btnArabic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnArabic.DisplayOnly = true
        Me.btnArabic.FlatAppearance.BorderSize = 0
        Me.btnArabic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnArabic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnArabic.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnArabic.Location = New System.Drawing.Point(127, 3)
        Me.btnArabic.Name = "btnArabic"
        Me.btnArabic.RoundedStyle = false
        Me.btnArabic.Size = New System.Drawing.Size(32, 23)
        Me.btnArabic.TabIndex = 14
        Me.btnArabic.Text = "ع"
        Me.btnArabic.UseVisualStyleBackColor = false
        '
        'btnOriginal
        '
        Me.btnOriginal.AutoSize = true
        Me.btnOriginal.BackColor = System.Drawing.Color.Transparent
        Me.btnOriginal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOriginal.DisplayOnly = true
        Me.btnOriginal.FlatAppearance.BorderSize = 0
        Me.btnOriginal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnOriginal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnOriginal.Location = New System.Drawing.Point(165, 3)
        Me.btnOriginal.Name = "btnOriginal"
        Me.btnOriginal.RoundedStyle = false
        Me.btnOriginal.Size = New System.Drawing.Size(39, 23)
        Me.btnOriginal.TabIndex = 13
        Me.btnOriginal.Text = "Eng"
        Me.btnOriginal.UseVisualStyleBackColor = false
        '
        'CButton1
        '
        Me.CButton1.AutoSize = true
        Me.CButton1.BackColor = System.Drawing.Color.Transparent
        Me.CButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CButton1.DisplayOnly = true
        Me.CButton1.FlatAppearance.BorderSize = 0
        Me.CButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.floNavigationButtons.SetFlowBreak(Me.CButton1, true)
        Me.CButton1.Location = New System.Drawing.Point(210, 3)
        Me.CButton1.Name = "CButton1"
        Me.CButton1.RoundedStyle = false
        Me.CButton1.Size = New System.Drawing.Size(111, 23)
        Me.CButton1.TabIndex = 17
        Me.CButton1.Text = "Translate This Form"
        Me.CButton1.UseVisualStyleBackColor = false
        '
        'BtnAdd
        '
        Me.BtnAdd.AutoSize = true
        Me.BtnAdd.BackColor = System.Drawing.Color.Transparent
        Me.BtnAdd.BackgroundImage = CType(resources.GetObject("BtnAdd.BackgroundImage"),System.Drawing.Image)
        Me.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAdd.DisplayOnly = true
        Me.BtnAdd.FlatAppearance.BorderSize = 0
        Me.BtnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"),System.Drawing.Image)
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnAdd.Location = New System.Drawing.Point(3, 32)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.RoundedStyle = false
        Me.BtnAdd.Size = New System.Drawing.Size(56, 23)
        Me.BtnAdd.TabIndex = 1
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAdd.UseVisualStyleBackColor = false
        '
        'BtnEdit
        '
        Me.BtnEdit.AutoSize = true
        Me.BtnEdit.BackColor = System.Drawing.Color.Transparent
        Me.BtnEdit.BackgroundImage = CType(resources.GetObject("BtnEdit.BackgroundImage"),System.Drawing.Image)
        Me.BtnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnEdit.DisplayOnly = true
        Me.BtnEdit.FlatAppearance.BorderSize = 0
        Me.BtnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"),System.Drawing.Image)
        Me.BtnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnEdit.Location = New System.Drawing.Point(65, 32)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.RoundedStyle = false
        Me.BtnEdit.Size = New System.Drawing.Size(56, 23)
        Me.BtnEdit.TabIndex = 2
        Me.BtnEdit.Text = "&Edit"
        Me.BtnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEdit.UseVisualStyleBackColor = false
        '
        'BtnDelete
        '
        Me.BtnDelete.AutoSize = true
        Me.BtnDelete.BackColor = System.Drawing.Color.Transparent
        Me.BtnDelete.BackgroundImage = CType(resources.GetObject("BtnDelete.BackgroundImage"),System.Drawing.Image)
        Me.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDelete.DisplayOnly = true
        Me.BtnDelete.FlatAppearance.BorderSize = 0
        Me.BtnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"),System.Drawing.Image)
        Me.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnDelete.Location = New System.Drawing.Point(127, 32)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.RoundedStyle = false
        Me.BtnDelete.Size = New System.Drawing.Size(62, 23)
        Me.BtnDelete.TabIndex = 6
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDelete.UseVisualStyleBackColor = false
        '
        'BtnSave
        '
        Me.BtnSave.AutoSize = true
        Me.BtnSave.BackColor = System.Drawing.Color.Transparent
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"),System.Drawing.Image)
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.DisplayOnly = true
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"),System.Drawing.Image)
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnSave.Location = New System.Drawing.Point(195, 32)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.RoundedStyle = false
        Me.BtnSave.Size = New System.Drawing.Size(58, 23)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.UseVisualStyleBackColor = false
        '
        'BtnFind
        '
        Me.BtnFind.AutoSize = true
        Me.BtnFind.BackColor = System.Drawing.Color.Transparent
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"),System.Drawing.Image)
        Me.BtnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFind.DisplayOnly = true
        Me.BtnFind.FlatAppearance.BorderSize = 0
        Me.BtnFind.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFind.Image = CType(resources.GetObject("BtnFind.Image"),System.Drawing.Image)
        Me.BtnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFind.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnFind.Location = New System.Drawing.Point(259, 32)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.RoundedStyle = false
        Me.BtnFind.Size = New System.Drawing.Size(75, 23)
        Me.BtnFind.TabIndex = 8
        Me.BtnFind.Text = "&Find Next"
        Me.BtnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnFind.UseVisualStyleBackColor = false
        '
        'BtnFirst
        '
        Me.BtnFirst.AutoSize = true
        Me.BtnFirst.BackColor = System.Drawing.Color.Transparent
        Me.BtnFirst.BackgroundImage = CType(resources.GetObject("BtnFirst.BackgroundImage"),System.Drawing.Image)
        Me.BtnFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFirst.DisplayOnly = true
        Me.BtnFirst.FlatAppearance.BorderSize = 0
        Me.BtnFirst.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnFirst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFirst.Image = CType(resources.GetObject("BtnFirst.Image"),System.Drawing.Image)
        Me.BtnFirst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFirst.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnFirst.Location = New System.Drawing.Point(340, 32)
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.RoundedStyle = false
        Me.BtnFirst.Size = New System.Drawing.Size(54, 23)
        Me.BtnFirst.TabIndex = 9
        Me.BtnFirst.Text = "F&irst"
        Me.BtnFirst.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnFirst.UseVisualStyleBackColor = false
        '
        'BtnPrev
        '
        Me.BtnPrev.AutoSize = true
        Me.BtnPrev.BackColor = System.Drawing.Color.Transparent
        Me.BtnPrev.BackgroundImage = CType(resources.GetObject("BtnPrev.BackgroundImage"),System.Drawing.Image)
        Me.BtnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPrev.DisplayOnly = true
        Me.BtnPrev.FlatAppearance.BorderSize = 0
        Me.BtnPrev.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnPrev.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrev.Image = CType(resources.GetObject("BtnPrev.Image"),System.Drawing.Image)
        Me.BtnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnPrev.Location = New System.Drawing.Point(400, 32)
        Me.BtnPrev.Name = "BtnPrev"
        Me.BtnPrev.RoundedStyle = false
        Me.BtnPrev.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrev.TabIndex = 10
        Me.BtnPrev.Text = "&Previous"
        Me.BtnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrev.UseVisualStyleBackColor = false
        '
        'BtnNext
        '
        Me.BtnNext.AutoSize = true
        Me.BtnNext.BackColor = System.Drawing.Color.Transparent
        Me.BtnNext.BackgroundImage = CType(resources.GetObject("BtnNext.BackgroundImage"),System.Drawing.Image)
        Me.BtnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNext.DisplayOnly = true
        Me.BtnNext.FlatAppearance.BorderSize = 0
        Me.BtnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNext.Image = CType(resources.GetObject("BtnNext.Image"),System.Drawing.Image)
        Me.BtnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnNext.Location = New System.Drawing.Point(481, 32)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.RoundedStyle = false
        Me.BtnNext.Size = New System.Drawing.Size(58, 23)
        Me.BtnNext.TabIndex = 11
        Me.BtnNext.Text = "&Next"
        Me.BtnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNext.UseVisualStyleBackColor = false
        '
        'BtnLast
        '
        Me.BtnLast.AutoSize = true
        Me.BtnLast.BackColor = System.Drawing.Color.Transparent
        Me.BtnLast.BackgroundImage = CType(resources.GetObject("BtnLast.BackgroundImage"),System.Drawing.Image)
        Me.BtnLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnLast.DisplayOnly = true
        Me.BtnLast.FlatAppearance.BorderSize = 0
        Me.BtnLast.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnLast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLast.Image = CType(resources.GetObject("BtnLast.Image"),System.Drawing.Image)
        Me.BtnLast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLast.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnLast.Location = New System.Drawing.Point(545, 32)
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.RoundedStyle = false
        Me.BtnLast.Size = New System.Drawing.Size(52, 23)
        Me.BtnLast.TabIndex = 12
        Me.BtnLast.Text = "&Last"
        Me.BtnLast.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnLast.UseVisualStyleBackColor = false
        '
        'BtnUndo
        '
        Me.BtnUndo.AutoSize = true
        Me.BtnUndo.BackColor = System.Drawing.Color.Transparent
        Me.BtnUndo.BackgroundImage = CType(resources.GetObject("BtnUndo.BackgroundImage"),System.Drawing.Image)
        Me.BtnUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnUndo.CausesValidation = false
        Me.BtnUndo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnUndo.DisplayOnly = true
        Me.BtnUndo.FlatAppearance.BorderSize = 0
        Me.BtnUndo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnUndo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUndo.Image = CType(resources.GetObject("BtnUndo.Image"),System.Drawing.Image)
        Me.BtnUndo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnUndo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnUndo.Location = New System.Drawing.Point(603, 32)
        Me.BtnUndo.Name = "BtnUndo"
        Me.BtnUndo.RoundedStyle = false
        Me.BtnUndo.Size = New System.Drawing.Size(59, 23)
        Me.BtnUndo.TabIndex = 13
        Me.BtnUndo.Text = "&Undo"
        Me.BtnUndo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnUndo.UseVisualStyleBackColor = false
        '
        'BtnQuit
        '
        Me.BtnQuit.AutoSize = true
        Me.BtnQuit.BackColor = System.Drawing.Color.Transparent
        Me.BtnQuit.BackgroundImage = CType(resources.GetObject("BtnQuit.BackgroundImage"),System.Drawing.Image)
        Me.BtnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnQuit.DisplayOnly = true
        Me.BtnQuit.FlatAppearance.BorderSize = 0
        Me.BtnQuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnQuit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnQuit.Image = CType(resources.GetObject("BtnQuit.Image"),System.Drawing.Image)
        Me.BtnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnQuit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnQuit.Location = New System.Drawing.Point(668, 32)
        Me.BtnQuit.Name = "BtnQuit"
        Me.BtnQuit.RoundedStyle = false
        Me.BtnQuit.Size = New System.Drawing.Size(54, 23)
        Me.BtnQuit.TabIndex = 14
        Me.BtnQuit.Text = "&Quit"
        Me.BtnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnQuit.UseVisualStyleBackColor = false
        '
        'floNavigationAndRecordCounter
        '
        Me.floNavigationAndRecordCounter.AutoSize = true
        Me.floNavigationAndRecordCounter.Controls.Add(Me.floNavigationButtons)
        Me.floNavigationAndRecordCounter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.floNavigationAndRecordCounter.Location = New System.Drawing.Point(0, 464)
        Me.floNavigationAndRecordCounter.Name = "floNavigationAndRecordCounter"
        Me.floNavigationAndRecordCounter.Size = New System.Drawing.Size(852, 64)
        Me.floNavigationAndRecordCounter.TabIndex = 0
        '
        'CFormEntry
        '
        Me.ClientSize = New System.Drawing.Size(852, 528)
        Me.Controls.Add(Me.floNavigationAndRecordCounter)
        Me.MinimumSize = New System.Drawing.Size(320, 250)
        Me.Name = "CFormEntry"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floNavigationButtons.ResumeLayout(false)
        Me.floNavigationButtons.PerformLayout
        Me.floNavigationAndRecordCounter.ResumeLayout(false)
        Me.floNavigationAndRecordCounter.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ImageList1 As Windows.Forms.ImageList
    Friend WithEvents _MBDeletionNotAllowed As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBAddRecordFailed As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBSaveRecordFailed As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBRecordNotSaved As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBRecordSuccessfullySaved As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBUndoEdits As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBTextToFindNotFound As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBFoundLastRecStartOnFirst As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBSaveChangesBeforeMoving As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBFirstRecordAlready As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBLastRecordAlready As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBLastRecordReachedStartFromBeginning As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBDeleteRecordFailed As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBDeleteRecordAsk As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBRecordSuccessfullyDeleted As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBDependentRecordExists As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MBNoChangesMadeNothingToSave As AATM.LocalizationUtilities.LocalizableMessageBox
    Friend WithEvents _MsgRecordNo As AATM.LocalizationUtilities.LocalizableMessage
    Friend WithEvents _MsgOf As AATM.LocalizationUtilities.LocalizableMessage
    Friend WithEvents _MBDataEntryIsNotUnique As AATM.LocalizationUtilities.LocalizableMessage
    Friend WithEvents LocalizableContent1 As AATM.LocalizationUtilities.LocalizableContent
    Friend WithEvents _MBUniqueConstraintViolated As AATM.LocalizationUtilities.LocalizableMessageBox
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
    Friend WithEvents BackgroundWorker1 As ComponentModel.BackgroundWorker
    Friend WithEvents _localizableMessage1 As LocalizationUtilities.LocalizableMessage
    Friend WithEvents btnOriginal As CButton
    Friend WithEvents btnArabic As CButton
    Friend WithEvents CButton1 As CButton
End Class
