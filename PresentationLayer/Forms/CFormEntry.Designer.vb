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
        Me.tsbCurrentRecord = New System.Windows.Forms.ToolStripLabel()
        Me.btnOf = New System.Windows.Forms.ToolStripButton()
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
        Me.btnDebug = New System.Windows.Forms.ToolStripButton()
        Me.btnArabic = New System.Windows.Forms.ToolStripButton()
        Me.btnOriginal = New System.Windows.Forms.ToolStripButton()
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.btnQuit = New System.Windows.Forms.ToolStripButton()
        Me.btnTranslate = New System.Windows.Forms.ToolStripButton()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.FormToolStrip.SuspendLayout
        Me.SuspendLayout
        '
        'FormToolStrip
        '
        Me.FormToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFirst, Me.btnPrev, Me.ToolStripSeparator1, Me.tsbCurrentRecord, Me.btnOf, Me.tsbTotalRecords, Me.ToolStripSeparator2, Me.btnNext, Me.btnLast, Me.ToolStripSeparator3, Me.btnAdd, Me.btnDelete, Me.btnEdit, Me.ToolStripSeparator4, Me.btnSave, Me.btnFind, Me.btnUndo, Me.btnDebug, Me.btnArabic, Me.btnOriginal, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton, Me.PrintToolStripButton, Me.toolStripSeparator, Me.toolStripSeparator5, Me.OpenToolStripButton, Me.NewToolStripButton, Me.HelpToolStripButton, Me.btnTranslate, Me.btnQuit})
        Me.FormToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.FormToolStrip.Name = "FormToolStrip"
        Me.FormToolStrip.Size = New System.Drawing.Size(865, 25)
        Me.FormToolStrip.TabIndex = 1
        Me.FormToolStrip.Text = "English"
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
        Me.tsbCurrentRecord.Name = "tsbCurrentRecord"
        Me.tsbCurrentRecord.Size = New System.Drawing.Size(0, 22)
        Me.tsbCurrentRecord.ToolTipText = "Current record number"
        '
        'btnOf
        '
        Me.btnOf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnOf.Image = CType(resources.GetObject("btnOf.Image"),System.Drawing.Image)
        Me.btnOf.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOf.Name = "btnOf"
        Me.btnOf.Size = New System.Drawing.Size(23, 22)
        Me.btnOf.Text = "of"
        '
        'tsbTotalRecords
        '
        Me.tsbTotalRecords.Name = "tsbTotalRecords"
        Me.tsbTotalRecords.Size = New System.Drawing.Size(0, 22)
        Me.tsbTotalRecords.ToolTipText = "Total Number of records"
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
        Me.btnSave.Text = "&Save"
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
        Me.btnArabic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnArabic.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnArabic.Image = CType(resources.GetObject("btnArabic.Image"),System.Drawing.Image)
        Me.btnArabic.Name = "btnArabic"
        Me.btnArabic.Size = New System.Drawing.Size(23, 22)
        Me.btnArabic.Text = "Arabic"
        Me.btnArabic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnArabic.ToolTipText = "Arabic"
        '
        'btnOriginal
        '
        Me.btnOriginal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnOriginal.Image = CType(resources.GetObject("btnOriginal.Image"),System.Drawing.Image)
        Me.btnOriginal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOriginal.Name = "btnOriginal"
        Me.btnOriginal.Size = New System.Drawing.Size(23, 22)
        Me.btnOriginal.Text = "English"
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"),System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CutToolStripButton.Text = "C&ut"
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"),System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopyToolStripButton.Text = "&Copy"
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"),System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PasteToolStripButton.Text = "&Paste"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"),System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"),System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"),System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "&New"
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"),System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.HelpToolStripButton.Text = "He&lp"
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
        'btnTranslate
        '
        Me.btnTranslate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnTranslate.Font = New System.Drawing.Font("Arial Narrow", 8!, System.Drawing.FontStyle.Bold)
        Me.btnTranslate.Image = CType(resources.GetObject("btnTranslate.Image"),System.Drawing.Image)
        Me.btnTranslate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnTranslate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnTranslate.Margin = New System.Windows.Forms.Padding(1)
        Me.btnTranslate.Name = "btnTranslate"
        Me.btnTranslate.Size = New System.Drawing.Size(54, 23)
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
    Protected WithEvents btnLast As Windows.Forms.ToolStripButton
    Protected WithEvents btnAdd As Windows.Forms.ToolStripButton
    Protected WithEvents btnEdit As Windows.Forms.ToolStripButton
    Protected WithEvents btnTranslate As Windows.Forms.ToolStripButton
    Public WithEvents btnDelete As Windows.Forms.ToolStripButton
    Public WithEvents FormToolStrip As Windows.Forms.ToolStrip
    Friend WithEvents btnOf As Windows.Forms.ToolStripButton
    Friend WithEvents tsbCurrentRecord As Windows.Forms.ToolStripLabel
    Friend WithEvents NewToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents OpenToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents CopyToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents PasteToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator5 As Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripButton As Windows.Forms.ToolStripButton
    Public WithEvents btnSave As Windows.Forms.ToolStripButton
End Class
