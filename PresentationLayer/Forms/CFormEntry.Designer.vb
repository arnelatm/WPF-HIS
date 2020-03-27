Imports System.ComponentModel
Imports AATM.LIBRARIES.CBaseControlsLibrary
Imports AATM.LIBRARIES.LocalizationUtilities
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class CFormEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CFormEntry))
        Dim SecurityPresenter1 As AATM.PresentationLayer.Presenters.SecurityPresenter = New AATM.PresentationLayer.Presenters.SecurityPresenter()
        Me._localizableMessage1 = New AATM.Libraries.LocalizationUtilities.LocalizableMessage()
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
        Me.btnDebugSwitch = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.floNavigationAndRecordCounter = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floNavigationButtons.SuspendLayout
        Me.floNavigationAndRecordCounter.SuspendLayout
        Me.SuspendLayout
        '
        'floNavigationButtons
        '
        Me.floNavigationButtons.AutoSize = true
        Me.floNavigationButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.floNavigationButtons.BackColor = System.Drawing.Color.Transparent
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
        Me.floNavigationButtons.Controls.Add(Me.btnDebugSwitch)
        Me.floNavigationButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.floNavigationAndRecordCounter.SetFlowBreak(Me.floNavigationButtons, true)
        Me.floNavigationButtons.Location = New System.Drawing.Point(3, 3)
        Me.floNavigationButtons.Name = "floNavigationButtons"
        Me.floNavigationButtons.Size = New System.Drawing.Size(797, 77)
        Me.floNavigationButtons.TabIndex = 12
        '
        'LblRecordCount
        '
        Me.LblRecordCount.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblRecordCount.AutoSize = true
        Me.LblRecordCount.DisplayOnly = true
        Me.LblRecordCount.EditingMode = false
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
        Me.btnArabic.BackColor = System.Drawing.Color.Transparent
        Me.btnArabic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnArabic.DesignerSelected = false
        Me.btnArabic.DisplayOnly = true
        Me.btnArabic.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnArabic.ImageIndex = 0
        Me.btnArabic.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnArabic.Location = New System.Drawing.Point(127, 3)
        Me.btnArabic.Name = "btnArabic"
        Me.btnArabic.OriginalImageName = Nothing
        Me.btnArabic.SecurityKey = ""
        Me.btnArabic.Size = New System.Drawing.Size(32, 23)
        Me.btnArabic.TabIndex = 14
        Me.btnArabic.Tag = "Arabic"
        Me.btnArabic.Text = "ع"
        Me.btnArabic.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnOriginal
        '
        Me.btnOriginal.BackColor = System.Drawing.Color.Transparent
        Me.btnOriginal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOriginal.DesignerSelected = false
        Me.btnOriginal.DisplayOnly = true
        Me.btnOriginal.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOriginal.ImageIndex = 0
        Me.btnOriginal.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOriginal.Location = New System.Drawing.Point(165, 3)
        Me.btnOriginal.Name = "btnOriginal"
        Me.btnOriginal.OriginalImageName = ""
        Me.btnOriginal.SecurityKey = ""
        Me.btnOriginal.Size = New System.Drawing.Size(39, 23)
        Me.btnOriginal.TabIndex = 13
        Me.btnOriginal.Text = "Eng"
        Me.btnOriginal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CButton1
        '
        Me.CButton1.BackColor = System.Drawing.Color.Lime
        Me.CButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CButton1.DesignerSelected = false
        Me.CButton1.DisplayOnly = true
        Me.floNavigationButtons.SetFlowBreak(Me.CButton1, true)
        Me.CButton1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CButton1.ImageIndex = 0
        Me.CButton1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CButton1.Location = New System.Drawing.Point(210, 3)
        Me.CButton1.Name = "CButton1"
        Me.CButton1.OriginalImageName = ""
        Me.CButton1.SecurityKey = ""
        Me.CButton1.Size = New System.Drawing.Size(110, 23)
        Me.CButton1.TabIndex = 17
        Me.CButton1.Text = "Translate This Form"
        Me.CButton1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.Lime
        Me.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnAdd.DesignerSelected = false
        Me.BtnAdd.DisplayOnly = true
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"),System.Drawing.Image)
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnAdd.ImageIndex = 0
        Me.BtnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnAdd.Location = New System.Drawing.Point(3, 32)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.OriginalImageName = "Add"
        Me.BtnAdd.SecurityKey = ""
        Me.BtnAdd.Size = New System.Drawing.Size(61, 42)
        Me.BtnAdd.TabIndex = 1
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.Lime
        Me.BtnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnEdit.DesignerSelected = false
        Me.BtnEdit.DisplayOnly = true
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"),System.Drawing.Image)
        Me.BtnEdit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnEdit.ImageIndex = 0
        Me.BtnEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnEdit.Location = New System.Drawing.Point(70, 32)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.OriginalImageName = "Edit"
        Me.BtnEdit.SecurityKey = ""
        Me.BtnEdit.Size = New System.Drawing.Size(53, 42)
        Me.BtnEdit.TabIndex = 2
        Me.BtnEdit.Text = "&Edit"
        Me.BtnEdit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.Lime
        Me.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDelete.DesignerSelected = false
        Me.BtnDelete.DisplayOnly = true
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"),System.Drawing.Image)
        Me.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnDelete.ImageIndex = 0
        Me.BtnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnDelete.Location = New System.Drawing.Point(129, 32)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.OriginalImageName = "Delete"
        Me.BtnDelete.SecurityKey = ""
        Me.BtnDelete.Size = New System.Drawing.Size(59, 42)
        Me.BtnDelete.TabIndex = 6
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Lime
        Me.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSave.DesignerSelected = false
        Me.BtnSave.DisplayOnly = true
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"),System.Drawing.Image)
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSave.ImageIndex = 0
        Me.BtnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnSave.Location = New System.Drawing.Point(194, 32)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.OriginalImageName = "Save"
        Me.BtnSave.SecurityKey = ""
        Me.BtnSave.Size = New System.Drawing.Size(53, 42)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnFind
        '
        Me.BtnFind.BackColor = System.Drawing.Color.Lime
        Me.BtnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFind.DesignerSelected = false
        Me.BtnFind.DisplayOnly = true
        Me.BtnFind.Image = CType(resources.GetObject("BtnFind.Image"),System.Drawing.Image)
        Me.BtnFind.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnFind.ImageIndex = 0
        Me.BtnFind.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnFind.Location = New System.Drawing.Point(253, 32)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.OriginalImageName = "Find"
        Me.BtnFind.SecurityKey = ""
        Me.BtnFind.Size = New System.Drawing.Size(79, 42)
        Me.BtnFind.TabIndex = 8
        Me.BtnFind.Text = "&Find Next"
        Me.BtnFind.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnFirst
        '
        Me.BtnFirst.BackColor = System.Drawing.Color.Lime
        Me.BtnFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnFirst.DesignerSelected = false
        Me.BtnFirst.DisplayOnly = true
        Me.BtnFirst.Image = CType(resources.GetObject("BtnFirst.Image"),System.Drawing.Image)
        Me.BtnFirst.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnFirst.ImageIndex = 0
        Me.BtnFirst.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnFirst.Location = New System.Drawing.Point(338, 32)
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.OriginalImageName = "First"
        Me.BtnFirst.SecurityKey = ""
        Me.BtnFirst.Size = New System.Drawing.Size(53, 42)
        Me.BtnFirst.TabIndex = 9
        Me.BtnFirst.Text = "F&irst"
        Me.BtnFirst.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnPrev
        '
        Me.BtnPrev.BackColor = System.Drawing.Color.Lime
        Me.BtnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPrev.DesignerSelected = false
        Me.BtnPrev.DisplayOnly = true
        Me.BtnPrev.Image = CType(resources.GetObject("BtnPrev.Image"),System.Drawing.Image)
        Me.BtnPrev.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnPrev.ImageIndex = 0
        Me.BtnPrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnPrev.Location = New System.Drawing.Point(397, 32)
        Me.BtnPrev.Name = "BtnPrev"
        Me.BtnPrev.OriginalImageName = "Previous"
        Me.BtnPrev.SecurityKey = ""
        Me.BtnPrev.Size = New System.Drawing.Size(69, 42)
        Me.BtnPrev.TabIndex = 10
        Me.BtnPrev.Text = "&Previous"
        Me.BtnPrev.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnNext
        '
        Me.BtnNext.BackColor = System.Drawing.Color.Lime
        Me.BtnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnNext.DesignerSelected = false
        Me.BtnNext.DisplayOnly = true
        Me.BtnNext.Image = CType(resources.GetObject("BtnNext.Image"),System.Drawing.Image)
        Me.BtnNext.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnNext.ImageIndex = 0
        Me.BtnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnNext.Location = New System.Drawing.Point(472, 32)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.OriginalImageName = "Next"
        Me.BtnNext.SecurityKey = ""
        Me.BtnNext.Size = New System.Drawing.Size(53, 42)
        Me.BtnNext.TabIndex = 11
        Me.BtnNext.Text = "&Next"
        Me.BtnNext.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnLast
        '
        Me.BtnLast.BackColor = System.Drawing.Color.Lime
        Me.BtnLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnLast.DesignerSelected = false
        Me.BtnLast.DisplayOnly = true
        Me.BtnLast.Image = CType(resources.GetObject("BtnLast.Image"),System.Drawing.Image)
        Me.BtnLast.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnLast.ImageIndex = 0
        Me.BtnLast.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnLast.Location = New System.Drawing.Point(531, 32)
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.OriginalImageName = "Last"
        Me.BtnLast.SecurityKey = ""
        Me.BtnLast.Size = New System.Drawing.Size(53, 42)
        Me.BtnLast.TabIndex = 12
        Me.BtnLast.Text = "&Last"
        Me.BtnLast.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnUndo
        '
        Me.BtnUndo.BackColor = System.Drawing.Color.Lime
        Me.BtnUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnUndo.CausesValidation = false
        Me.BtnUndo.DesignerSelected = false
        Me.BtnUndo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnUndo.DisplayOnly = true
        Me.BtnUndo.Image = CType(resources.GetObject("BtnUndo.Image"),System.Drawing.Image)
        Me.BtnUndo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnUndo.ImageIndex = 0
        Me.BtnUndo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnUndo.Location = New System.Drawing.Point(590, 32)
        Me.BtnUndo.Name = "BtnUndo"
        Me.BtnUndo.OriginalImageName = "Undo"
        Me.BtnUndo.SecurityKey = ""
        Me.BtnUndo.Size = New System.Drawing.Size(54, 42)
        Me.BtnUndo.TabIndex = 13
        Me.BtnUndo.Text = "&Undo"
        Me.BtnUndo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnQuit
        '
        Me.BtnQuit.BackColor = System.Drawing.Color.Lime
        Me.BtnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnQuit.DesignerSelected = false
        Me.BtnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnQuit.DisplayOnly = true
        Me.BtnQuit.Image = CType(resources.GetObject("BtnQuit.Image"),System.Drawing.Image)
        Me.BtnQuit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnQuit.ImageIndex = 0
        Me.BtnQuit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnQuit.Location = New System.Drawing.Point(650, 32)
        Me.BtnQuit.Name = "BtnQuit"
        Me.BtnQuit.OriginalImageName = "Quit"
        Me.BtnQuit.SecurityKey = ""
        Me.BtnQuit.Size = New System.Drawing.Size(53, 42)
        Me.BtnQuit.TabIndex = 14
        Me.BtnQuit.Text = "&Quit"
        Me.BtnQuit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnDebugSwitch
        '
        Me.btnDebugSwitch.BackColor = System.Drawing.Color.Lime
        Me.btnDebugSwitch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDebugSwitch.DesignerSelected = false
        Me.btnDebugSwitch.DisplayOnly = true
        Me.btnDebugSwitch.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDebugSwitch.ImageIndex = 0
        Me.btnDebugSwitch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDebugSwitch.Location = New System.Drawing.Point(709, 32)
        Me.btnDebugSwitch.Name = "btnDebugSwitch"
        Me.btnDebugSwitch.OriginalImageName = "Save"
        Me.btnDebugSwitch.SecurityKey = ""
        Me.btnDebugSwitch.Size = New System.Drawing.Size(85, 42)
        Me.btnDebugSwitch.TabIndex = 18
        Me.btnDebugSwitch.Text = "Turn On Debugger"
        Me.btnDebugSwitch.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'floNavigationAndRecordCounter
        '
        Me.floNavigationAndRecordCounter.AutoSize = true
        Me.floNavigationAndRecordCounter.BackColor = System.Drawing.Color.Transparent
        Me.floNavigationAndRecordCounter.Controls.Add(Me.floNavigationButtons)
        Me.floNavigationAndRecordCounter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.floNavigationAndRecordCounter.Location = New System.Drawing.Point(0, 488)
        Me.floNavigationAndRecordCounter.Name = "floNavigationAndRecordCounter"
        Me.floNavigationAndRecordCounter.Size = New System.Drawing.Size(865, 83)
        Me.floNavigationAndRecordCounter.TabIndex = 0
        '
        'CFormEntry
        '
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"),System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(865, 571)
        Me.Controls.Add(Me.floNavigationAndRecordCounter)
        Me.MinimumSize = New System.Drawing.Size(320, 250)
        Me.Name = "CFormEntry"
        Me.SecurityPresenterObj = SecurityPresenter1
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floNavigationButtons.ResumeLayout(false)
        Me.floNavigationButtons.PerformLayout
        Me.floNavigationAndRecordCounter.ResumeLayout(false)
        Me.floNavigationAndRecordCounter.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Public WithEvents BtnAdd As CButton
    Public WithEvents BtnEdit As CButton
    Public WithEvents BtnDelete As CButton
    Public WithEvents BtnFind As CButton
    Public WithEvents BtnFirst As CButton
    Public WithEvents BtnPrev As CButton
    Public WithEvents BtnNext As CButton
    Public WithEvents BtnLast As CButton
    Public WithEvents BtnUndo As CButton
    Public WithEvents BtnQuit As CButton
    Public WithEvents BtnSave As CButton
    Friend WithEvents floNavigationAndRecordCounter As CFlowLayout
    Public WithEvents floNavigationButtons As CFlowLayout
    Friend WithEvents LblRecordCount As CLabel
    Friend WithEvents _localizableMessage1 As LocalizableMessage
    Friend WithEvents btnOriginal As CButton
    Friend WithEvents btnArabic As CButton
    Friend WithEvents CButton1 As CButton

    Private WithEvents btnDebugSwitch As CButton
End Class
