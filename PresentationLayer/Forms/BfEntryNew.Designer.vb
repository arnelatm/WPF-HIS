Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.LIBRARIES.CBaseControlsLibrary
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class BfEntryNew
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
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(BfEntryNew))
        Me.floNavigationAndRecordCounter = New CFlowLayout()
        Me.floNavigationButtons = New CFlowLayout()
        Me.LblRecordCount = New CLabel()
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
        Me.btnSaveDebug = New CButton()
        CType(Me.MyErrorProvider, ISupportInitialize).BeginInit()
        Me.floNavigationAndRecordCounter.SuspendLayout()
        Me.floNavigationButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'floNavigationAndRecordCounter
        '
        Me.floNavigationAndRecordCounter.AutoSize = True
        Me.floNavigationAndRecordCounter.Controls.Add(Me.floNavigationButtons)
        Me.floNavigationAndRecordCounter.Dock = DockStyle.Bottom
        Me.floNavigationAndRecordCounter.Location = New Point(0, 464)
        Me.floNavigationAndRecordCounter.Name = "floNavigationAndRecordCounter"
        Me.floNavigationAndRecordCounter.Size = New Size(852, 64)
        Me.floNavigationAndRecordCounter.TabIndex = 1
        '
        'floNavigationButtons
        '
        Me.floNavigationButtons.AutoSize = True
        Me.floNavigationButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink
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
        Me.floNavigationButtons.Controls.Add(Me.btnSaveDebug)
        Me.floNavigationButtons.Dock = DockStyle.Bottom
        Me.floNavigationAndRecordCounter.SetFlowBreak(Me.floNavigationButtons, True)
        Me.floNavigationButtons.Location = New Point(3, 3)
        Me.floNavigationButtons.Name = "floNavigationButtons"
        Me.floNavigationButtons.Size = New Size(805, 58)
        Me.floNavigationButtons.TabIndex = 12
        '
        'LblRecordCount
        '
        Me.LblRecordCount.Anchor = AnchorStyles.None
        Me.LblRecordCount.AutoSize = True
        Me.LblRecordCount.Font = New Font("Microsoft Sans Serif", 10.0!)
        Me.LblRecordCount.ImeMode = ImeMode.NoControl
        Me.LblRecordCount.Location = New Point(1, 6)
        Me.LblRecordCount.Margin = New Padding(1)
        Me.LblRecordCount.Name = "LblRecordCount"
        Me.LblRecordCount.Size = New Size(122, 17)
        Me.LblRecordCount.TabIndex = 16
        Me.LblRecordCount.Text = "Record <x> of <x>"
        Me.LblRecordCount.TextAlign = ContentAlignment.MiddleLeft
        '
        'btnArabic
        '
        Me.btnArabic.AutoSize = True
        Me.btnArabic.BackColor = Color.Transparent
        Me.btnArabic.BackgroundImageLayout = ImageLayout.Stretch
        Me.btnArabic.ImeMode = ImeMode.NoControl
        Me.btnArabic.Location = New Point(127, 3)
        Me.btnArabic.Name = "btnArabic"
        Me.btnArabic.Size = New Size(32, 23)
        Me.btnArabic.TabIndex = 14
        Me.btnArabic.Text = "ع"
        '
        'btnOriginal
        '
        Me.btnOriginal.AutoSize = True
        Me.btnOriginal.BackColor = Color.Transparent
        Me.btnOriginal.BackgroundImageLayout = ImageLayout.Stretch
        Me.btnOriginal.Location = New Point(165, 3)
        Me.btnOriginal.Name = "btnOriginal"
        Me.btnOriginal.Size = New Size(39, 23)
        Me.btnOriginal.TabIndex = 13
        Me.btnOriginal.Text = "Eng"
        '
        'CButton1
        '
        Me.CButton1.AutoSize = True
        Me.CButton1.BackColor = Color.Transparent
        Me.CButton1.BackgroundImageLayout = ImageLayout.Stretch
        Me.floNavigationButtons.SetFlowBreak(Me.CButton1, True)
        Me.CButton1.Location = New Point(210, 3)
        Me.CButton1.Name = "CButton1"
        Me.CButton1.Size = New Size(111, 23)
        Me.CButton1.TabIndex = 17
        Me.CButton1.Text = "Translate This Form"
        '
        'BtnAdd
        '
        Me.BtnAdd.AutoSize = True
        Me.BtnAdd.BackColor = Color.Transparent
        Me.BtnAdd.BackgroundImage = CType(resources.GetObject("BtnAdd.BackgroundImage"), Image)
        Me.BtnAdd.BackgroundImageLayout = ImageLayout.Stretch
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), Image)
        Me.BtnAdd.ImageAlign = ContentAlignment.MiddleLeft
        Me.BtnAdd.ImeMode = ImeMode.NoControl
        Me.BtnAdd.Location = New Point(3, 32)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New Size(56, 23)
        Me.BtnAdd.TabIndex = 1
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextAlign = ContentAlignment.MiddleRight
        '
        'BtnEdit
        '
        Me.BtnEdit.AutoSize = True
        Me.BtnEdit.BackColor = Color.Transparent
        Me.BtnEdit.BackgroundImage = CType(resources.GetObject("BtnEdit.BackgroundImage"), Image)
        Me.BtnEdit.BackgroundImageLayout = ImageLayout.Stretch
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), Image)
        Me.BtnEdit.ImageAlign = ContentAlignment.MiddleLeft
        Me.BtnEdit.ImeMode = ImeMode.NoControl
        Me.BtnEdit.Location = New Point(65, 32)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New Size(56, 23)
        Me.BtnEdit.TabIndex = 2
        Me.BtnEdit.Text = "&Edit"
        Me.BtnEdit.TextAlign = ContentAlignment.MiddleRight
        '
        'BtnDelete
        '
        Me.BtnDelete.AutoSize = True
        Me.BtnDelete.BackColor = Color.Transparent
        Me.BtnDelete.BackgroundImage = CType(resources.GetObject("BtnDelete.BackgroundImage"), Image)
        Me.BtnDelete.BackgroundImageLayout = ImageLayout.Stretch
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), Image)
        Me.BtnDelete.ImageAlign = ContentAlignment.MiddleLeft
        Me.BtnDelete.ImeMode = ImeMode.NoControl
        Me.BtnDelete.Location = New Point(127, 32)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New Size(62, 23)
        Me.BtnDelete.TabIndex = 6
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.TextAlign = ContentAlignment.MiddleRight
        '
        'BtnSave
        '
        Me.BtnSave.AutoSize = True
        Me.BtnSave.BackColor = Color.Transparent
        Me.BtnSave.BackgroundImage = CType(resources.GetObject("BtnSave.BackgroundImage"), Image)
        Me.BtnSave.BackgroundImageLayout = ImageLayout.Stretch
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), Image)
        Me.BtnSave.ImageAlign = ContentAlignment.MiddleLeft
        Me.BtnSave.ImeMode = ImeMode.NoControl
        Me.BtnSave.Location = New Point(195, 32)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New Size(58, 23)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextAlign = ContentAlignment.MiddleRight
        '
        'BtnFind
        '
        Me.BtnFind.AutoSize = True
        Me.BtnFind.BackColor = Color.Transparent
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"), Image)
        Me.BtnFind.BackgroundImageLayout = ImageLayout.Stretch
        Me.BtnFind.Image = CType(resources.GetObject("BtnFind.Image"), Image)
        Me.BtnFind.ImageAlign = ContentAlignment.MiddleLeft
        Me.BtnFind.ImeMode = ImeMode.NoControl
        Me.BtnFind.Location = New Point(259, 32)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New Size(75, 23)
        Me.BtnFind.TabIndex = 8
        Me.BtnFind.Text = "&Find Next"
        Me.BtnFind.TextAlign = ContentAlignment.MiddleRight
        '
        'BtnFirst
        '
        Me.BtnFirst.AutoSize = True
        Me.BtnFirst.BackColor = Color.Transparent
        Me.BtnFirst.BackgroundImage = CType(resources.GetObject("BtnFirst.BackgroundImage"), Image)
        Me.BtnFirst.BackgroundImageLayout = ImageLayout.Stretch
        Me.BtnFirst.Image = CType(resources.GetObject("BtnFirst.Image"), Image)
        Me.BtnFirst.ImageAlign = ContentAlignment.MiddleLeft
        Me.BtnFirst.ImeMode = ImeMode.NoControl
        Me.BtnFirst.Location = New Point(340, 32)
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New Size(54, 23)
        Me.BtnFirst.TabIndex = 9
        Me.BtnFirst.Text = "F&irst"
        Me.BtnFirst.TextAlign = ContentAlignment.MiddleRight
        '
        'BtnPrev
        '
        Me.BtnPrev.AutoSize = True
        Me.BtnPrev.BackColor = Color.Transparent
        Me.BtnPrev.BackgroundImage = CType(resources.GetObject("BtnPrev.BackgroundImage"), Image)
        Me.BtnPrev.BackgroundImageLayout = ImageLayout.Stretch
        Me.BtnPrev.Image = CType(resources.GetObject("BtnPrev.Image"), Image)
        Me.BtnPrev.ImageAlign = ContentAlignment.MiddleLeft
        Me.BtnPrev.ImeMode = ImeMode.NoControl
        Me.BtnPrev.Location = New Point(400, 32)
        Me.BtnPrev.Name = "BtnPrev"
        Me.BtnPrev.Size = New Size(75, 23)
        Me.BtnPrev.TabIndex = 10
        Me.BtnPrev.Text = "&Previous"
        Me.BtnPrev.TextAlign = ContentAlignment.MiddleRight
        '
        'BtnNext
        '
        Me.BtnNext.AutoSize = True
        Me.BtnNext.BackColor = Color.Transparent
        Me.BtnNext.BackgroundImage = CType(resources.GetObject("BtnNext.BackgroundImage"), Image)
        Me.BtnNext.BackgroundImageLayout = ImageLayout.Stretch
        Me.BtnNext.Image = CType(resources.GetObject("BtnNext.Image"), Image)
        Me.BtnNext.ImageAlign = ContentAlignment.MiddleLeft
        Me.BtnNext.ImeMode = ImeMode.NoControl
        Me.BtnNext.Location = New Point(481, 32)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New Size(58, 23)
        Me.BtnNext.TabIndex = 11
        Me.BtnNext.Text = "&Next"
        Me.BtnNext.TextAlign = ContentAlignment.MiddleRight
        '
        'BtnLast
        '
        Me.BtnLast.AutoSize = True
        Me.BtnLast.BackColor = Color.Transparent
        Me.BtnLast.BackgroundImage = CType(resources.GetObject("BtnLast.BackgroundImage"), Image)
        Me.BtnLast.BackgroundImageLayout = ImageLayout.Stretch
        Me.BtnLast.Image = CType(resources.GetObject("BtnLast.Image"), Image)
        Me.BtnLast.ImageAlign = ContentAlignment.MiddleLeft
        Me.BtnLast.ImeMode = ImeMode.NoControl
        Me.BtnLast.Location = New Point(545, 32)
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New Size(52, 23)
        Me.BtnLast.TabIndex = 12
        Me.BtnLast.Text = "&Last"
        Me.BtnLast.TextAlign = ContentAlignment.MiddleRight
        '
        'BtnUndo
        '
        Me.BtnUndo.AutoSize = True
        Me.BtnUndo.BackColor = Color.Transparent
        Me.BtnUndo.BackgroundImage = CType(resources.GetObject("BtnUndo.BackgroundImage"), Image)
        Me.BtnUndo.BackgroundImageLayout = ImageLayout.Stretch
        Me.BtnUndo.CausesValidation = False
        Me.BtnUndo.DialogResult = DialogResult.OK
        Me.BtnUndo.Image = CType(resources.GetObject("BtnUndo.Image"), Image)
        Me.BtnUndo.ImageAlign = ContentAlignment.MiddleLeft
        Me.BtnUndo.ImeMode = ImeMode.NoControl
        Me.BtnUndo.Location = New Point(603, 32)
        Me.BtnUndo.Name = "BtnUndo"
        Me.BtnUndo.Size = New Size(59, 23)
        Me.BtnUndo.TabIndex = 13
        Me.BtnUndo.Text = "&Undo"
        Me.BtnUndo.TextAlign = ContentAlignment.MiddleRight
        '
        'BtnQuit
        '
        Me.BtnQuit.AutoSize = True
        Me.BtnQuit.BackColor = Color.Transparent
        Me.BtnQuit.BackgroundImage = CType(resources.GetObject("BtnQuit.BackgroundImage"), Image)
        Me.BtnQuit.BackgroundImageLayout = ImageLayout.Stretch
        Me.BtnQuit.DialogResult = DialogResult.Cancel
        Me.BtnQuit.Image = CType(resources.GetObject("BtnQuit.Image"), Image)
        Me.BtnQuit.ImageAlign = ContentAlignment.MiddleLeft
        Me.BtnQuit.ImeMode = ImeMode.NoControl
        Me.BtnQuit.Location = New Point(668, 32)
        Me.BtnQuit.Name = "BtnQuit"
        Me.BtnQuit.Size = New Size(54, 23)
        Me.BtnQuit.TabIndex = 14
        Me.BtnQuit.Text = "&Quit"
        Me.BtnQuit.TextAlign = ContentAlignment.MiddleRight
        '
        'btnSaveDebug
        '
        Me.btnSaveDebug.AutoSize = True
        Me.btnSaveDebug.BackColor = Color.Transparent
        Me.btnSaveDebug.BackgroundImage = CType(resources.GetObject("btnSaveDebug.BackgroundImage"), Image)
        Me.btnSaveDebug.BackgroundImageLayout = ImageLayout.Stretch
        Me.btnSaveDebug.Image = CType(resources.GetObject("btnSaveDebug.Image"), Image)
        Me.btnSaveDebug.ImageAlign = ContentAlignment.MiddleLeft
        Me.btnSaveDebug.ImeMode = ImeMode.NoControl
        Me.btnSaveDebug.Location = New Point(728, 32)
        Me.btnSaveDebug.Name = "btnSaveDebug"
        Me.btnSaveDebug.Size = New Size(74, 23)
        Me.btnSaveDebug.TabIndex = 18
        Me.btnSaveDebug.Text = "&SaveDebug"
        Me.btnSaveDebug.TextAlign = ContentAlignment.MiddleRight
        '
        'BfEntryNew
        '
        Me.ClientSize = New Size(852, 528)
        Me.Controls.Add(Me.floNavigationAndRecordCounter)
        Me.Name = "BfEntryNew"
        CType(Me.MyErrorProvider, ISupportInitialize).EndInit()
        Me.floNavigationAndRecordCounter.ResumeLayout(False)
        Me.floNavigationAndRecordCounter.PerformLayout()
        Me.floNavigationButtons.ResumeLayout(False)
        Me.floNavigationButtons.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents floNavigationAndRecordCounter As CFlowLayout
    Public WithEvents floNavigationButtons As CFlowLayout
    Friend WithEvents LblRecordCount As CLabel
    Friend WithEvents btnArabic As CButton
    Friend WithEvents btnOriginal As CButton
    Friend WithEvents CButton1 As CButton
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
    Protected WithEvents btnSaveDebug As CButton
End Class
