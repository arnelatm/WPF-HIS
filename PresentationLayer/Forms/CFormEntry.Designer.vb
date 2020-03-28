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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CFormEntry))
        Dim SecurityPresenter1 As AATM.PresentationLayer.Presenters.SecurityPresenter = New AATM.PresentationLayer.Presenters.SecurityPresenter()
        Me._localizableMessage1 = New AATM.Libraries.LocalizationUtilities.LocalizableMessage()
        Me.FormToolStrip = New System.Windows.Forms.ToolStrip()
        Me.btnFirst = New System.Windows.Forms.ToolStripButton()
        Me.btnPrev = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCurrentRecord = New System.Windows.Forms.ToolStripTextBox()
        Me.tsbTotalRecords = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNext = New System.Windows.Forms.ToolStripButton()
        Me.btnLast = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnFind = New System.Windows.Forms.ToolStripButton()
        Me.btnUndo = New System.Windows.Forms.ToolStripButton()
        Me.btnQuit = New System.Windows.Forms.ToolStripButton()
        Me.btnDebug = New System.Windows.Forms.ToolStripButton()
        Me.btnArabic = New System.Windows.Forms.ToolStripButton()
        Me.btnOriginal = New System.Windows.Forms.ToolStripButton()
        Me.btnTranslate = New System.Windows.Forms.ToolStripButton()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.FormToolStrip.SuspendLayout
        Me.SuspendLayout
        '
        'FormToolStrip
        '
        Me.FormToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFirst, Me.btnPrev, Me.ToolStripSeparator1, Me.tsbCurrentRecord, Me.tsbTotalRecords, Me.ToolStripSeparator2, Me.btnNext, Me.btnLast, Me.ToolStripSeparator3, Me.btnAdd, Me.btnDelete, Me.btnEdit, Me.ToolStripSeparator4, Me.btnSave, Me.btnFind, Me.btnUndo, Me.btnQuit, Me.btnDebug, Me.btnArabic, Me.btnOriginal, Me.btnTranslate})
        Me.FormToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.FormToolStrip.Name = "FormToolStrip"
        Me.FormToolStrip.Size = New System.Drawing.Size(865, 25)
        Me.FormToolStrip.TabIndex = 1
        Me.FormToolStrip.Text = "ToolStrip1"
        '
        'btnFirst
        '
        Me.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFirst.Image = CType(resources.GetObject("btnFirst.Image"),System.Drawing.Image)
        Me.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(23, 22)
        Me.btnFirst.Text = "Go to first record"
        '
        'btnPrev
        '
        Me.btnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPrev.Image = CType(resources.GetObject("btnPrev.Image"),System.Drawing.Image)
        Me.btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(23, 22)
        Me.btnPrev.Text = "Go to previous record"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbCurrentRecord
        '
        Me.tsbCurrentRecord.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.tsbCurrentRecord.Name = "tsbCurrentRecord"
        Me.tsbCurrentRecord.Size = New System.Drawing.Size(50, 25)
        '
        'tsbTotalRecords
        '
        Me.tsbTotalRecords.Name = "tsbTotalRecords"
        Me.tsbTotalRecords.Size = New System.Drawing.Size(35, 22)
        Me.tsbTotalRecords.Text = "of {0}"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnNext
        '
        Me.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"),System.Drawing.Image)
        Me.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(23, 22)
        Me.btnNext.Text = "Go to next record"
        '
        'btnLast
        '
        Me.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLast.Image = CType(resources.GetObject("btnLast.Image"),System.Drawing.Image)
        Me.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(23, 22)
        Me.btnLast.Text = "Go to last record"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnAdd
        '
        Me.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"),System.Drawing.Image)
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(23, 22)
        Me.btnAdd.Text = "Add a new record"
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"),System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(23, 22)
        Me.btnDelete.Text = "Delete current record"
        '
        'btnEdit
        '
        Me.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"),System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(23, 22)
        Me.btnEdit.Text = "Edit current record"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"),System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(23, 22)
        Me.btnSave.Text = "Save changes to current record"
        '
        'btnFind
        '
        Me.btnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"),System.Drawing.Image)
        Me.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(23, 22)
        Me.btnFind.Text = "Find a record"
        '
        'btnUndo
        '
        Me.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUndo.Image = CType(resources.GetObject("btnUndo.Image"),System.Drawing.Image)
        Me.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(23, 22)
        Me.btnUndo.Text = "Undo changes and revert to previous values"
        '
        'btnQuit
        '
        Me.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnQuit.Image = CType(resources.GetObject("btnQuit.Image"),System.Drawing.Image)
        Me.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(23, 22)
        Me.btnQuit.Text = "Exit and close this form"
        '
        'btnDebug
        '
        Me.btnDebug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDebug.Image = CType(resources.GetObject("btnDebug.Image"),System.Drawing.Image)
        Me.btnDebug.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDebug.Name = "btnDebug"
        Me.btnDebug.Size = New System.Drawing.Size(23, 22)
        Me.btnDebug.Text = "Set debugger on."
        '
        'btnArabic
        '
        Me.btnArabic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnArabic.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnArabic.ForeColor = System.Drawing.Color.Green
        Me.btnArabic.Name = "btnArabic"
        Me.btnArabic.Size = New System.Drawing.Size(23, 22)
        Me.btnArabic.Text = "ع"
        Me.btnArabic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnArabic.ToolTipText = "Arabic"
        '
        'btnOriginal
        '
        Me.btnOriginal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnOriginal.ForeColor = System.Drawing.Color.Green
        Me.btnOriginal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOriginal.Name = "btnOriginal"
        Me.btnOriginal.Size = New System.Drawing.Size(24, 22)
        Me.btnOriginal.Text = "En"
        '
        'btnTranslate
        '
        Me.btnTranslate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnTranslate.Font = New System.Drawing.Font("Arial Narrow", 8!, System.Drawing.FontStyle.Bold)
        Me.btnTranslate.ForeColor = System.Drawing.Color.Green
        Me.btnTranslate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnTranslate.Name = "btnTranslate"
        Me.btnTranslate.Size = New System.Drawing.Size(52, 22)
        Me.btnTranslate.Text = "Translate"
        '
        'CFormEntry
        '
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"),System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(865, 571)
        Me.Controls.Add(Me.FormToolStrip)
        Me.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.MinimumSize = New System.Drawing.Size(320, 250)
        Me.Name = "CFormEntry"
        Me.SecurityPresenterObj = SecurityPresenter1
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.FormToolStrip.ResumeLayout(false)
        Me.FormToolStrip.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents _localizableMessage1 As LocalizableMessage
    Friend WithEvents btnFirst As Windows.Forms.ToolStripButton
    Friend WithEvents btnPrev As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbCurrentRecord As Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbTotalRecords As Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNext As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As Windows.Forms.ToolStripSeparator
    Friend WithEvents btnFind As Windows.Forms.ToolStripButton
    Friend WithEvents btnUndo As Windows.Forms.ToolStripButton
    Friend WithEvents btnDebug As Windows.Forms.ToolStripButton
    Friend WithEvents btnQuit As Windows.Forms.ToolStripButton
    Friend WithEvents btnArabic As Windows.Forms.ToolStripButton
    Friend WithEvents btnOriginal As Windows.Forms.ToolStripButton
    Public WithEvents btnSave As Windows.Forms.ToolStripButton
    Protected WithEvents btnLast As Windows.Forms.ToolStripButton
    Protected WithEvents btnAdd As Windows.Forms.ToolStripButton
    Protected WithEvents btnEdit As Windows.Forms.ToolStripButton
    Protected WithEvents btnTranslate As Windows.Forms.ToolStripButton
    Public WithEvents btnDelete As Windows.Forms.ToolStripButton
    Public WithEvents FormToolStrip As Windows.Forms.ToolStrip
End Class
