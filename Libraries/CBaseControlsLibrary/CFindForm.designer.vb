Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class CFindForm
    Inherits CForm

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()> _
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
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TxtTextToSearch = New System.Windows.Forms.TextBox()
        Me.lblLookFor1 = New System.Windows.Forms.Label()
        Me.RBtnStart = New System.Windows.Forms.RadioButton()
        Me.RBtnAnywhere = New System.Windows.Forms.RadioButton()
        Me.BtnFind = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLookFor4 = New System.Windows.Forms.Label()
        Me.lblLookFor3 = New System.Windows.Forms.Label()
        Me.lblLookFor2 = New System.Windows.Forms.Label()
        Me.cboTextToSearch = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpDates = New System.Windows.Forms.TableLayoutPanel()
        Me.dtpBegDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.chkChecked = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.tlpDates.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtTextToSearch
        '
        Me.TxtTextToSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTextToSearch.Location = New System.Drawing.Point(58, 3)
        Me.TxtTextToSearch.Name = "TxtTextToSearch"
        Me.TxtTextToSearch.Size = New System.Drawing.Size(247, 20)
        Me.TxtTextToSearch.TabIndex = 0
        '
        'lblLookFor1
        '
        Me.lblLookFor1.AutoSize = True
        Me.lblLookFor1.BackColor = System.Drawing.Color.Transparent
        Me.lblLookFor1.Location = New System.Drawing.Point(3, 0)
        Me.lblLookFor1.Name = "lblLookFor1"
        Me.lblLookFor1.Size = New System.Drawing.Size(49, 13)
        Me.lblLookFor1.TabIndex = 1
        Me.lblLookFor1.Text = "Look For"
        '
        'RBtnStart
        '
        Me.RBtnStart.AutoSize = True
        Me.RBtnStart.BackColor = System.Drawing.Color.Transparent
        Me.RBtnStart.Checked = True
        Me.RBtnStart.Location = New System.Drawing.Point(58, 112)
        Me.RBtnStart.Name = "RBtnStart"
        Me.RBtnStart.Size = New System.Drawing.Size(84, 17)
        Me.RBtnStart.TabIndex = 2
        Me.RBtnStart.TabStop = True
        Me.RBtnStart.Text = "Start of Field"
        Me.RBtnStart.UseVisualStyleBackColor = False
        '
        'RBtnAnywhere
        '
        Me.RBtnAnywhere.AutoSize = True
        Me.RBtnAnywhere.BackColor = System.Drawing.Color.Transparent
        Me.RBtnAnywhere.Location = New System.Drawing.Point(58, 135)
        Me.RBtnAnywhere.Name = "RBtnAnywhere"
        Me.RBtnAnywhere.Size = New System.Drawing.Size(112, 17)
        Me.RBtnAnywhere.TabIndex = 3
        Me.RBtnAnywhere.Text = "Anywhere on Field"
        Me.RBtnAnywhere.UseVisualStyleBackColor = False
        '
        'BtnFind
        '
        Me.BtnFind.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnFind.Location = New System.Drawing.Point(38, 3)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(75, 23)
        Me.BtnFind.TabIndex = 4
        Me.BtnFind.Text = "Find"
        Me.BtnFind.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(189, 3)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lblLookFor4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLookFor3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLookFor2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLookFor1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTextToSearch, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RBtnAnywhere, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTextToSearch, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.RBtnStart, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.tlpDates, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.chkChecked, 1, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(308, 190)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'lblLookFor4
        '
        Me.lblLookFor4.AutoSize = True
        Me.lblLookFor4.BackColor = System.Drawing.Color.Transparent
        Me.lblLookFor4.Location = New System.Drawing.Point(3, 83)
        Me.lblLookFor4.Name = "lblLookFor4"
        Me.lblLookFor4.Size = New System.Drawing.Size(49, 13)
        Me.lblLookFor4.TabIndex = 7
        Me.lblLookFor4.Text = "Look For"
        '
        'lblLookFor3
        '
        Me.lblLookFor3.AutoSize = True
        Me.lblLookFor3.BackColor = System.Drawing.Color.Transparent
        Me.lblLookFor3.Location = New System.Drawing.Point(3, 52)
        Me.lblLookFor3.Name = "lblLookFor3"
        Me.lblLookFor3.Size = New System.Drawing.Size(49, 13)
        Me.lblLookFor3.TabIndex = 5
        Me.lblLookFor3.Text = "Look For"
        '
        'lblLookFor2
        '
        Me.lblLookFor2.AutoSize = True
        Me.lblLookFor2.BackColor = System.Drawing.Color.Transparent
        Me.lblLookFor2.Location = New System.Drawing.Point(3, 26)
        Me.lblLookFor2.Name = "lblLookFor2"
        Me.lblLookFor2.Size = New System.Drawing.Size(49, 13)
        Me.lblLookFor2.TabIndex = 2
        Me.lblLookFor2.Text = "Look For"
        '
        'cboTextToSearch
        '
        Me.cboTextToSearch.BackColor = System.Drawing.Color.White
        Me.cboTextToSearch.ChangingSearchValueOnly = False
        Me.cboTextToSearch.CurrentSearchTerm = ""
        Me.cboTextToSearch.DefaultValue = Nothing
        Me.cboTextToSearch.DisplayMember = "Name"
        Me.cboTextToSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTextToSearch.EditingMode = True
        Me.cboTextToSearch.FilterRule = Nothing
        Me.cboTextToSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cboTextToSearch.ForeColor = System.Drawing.Color.Black
        Me.cboTextToSearch.FormattingEnabled = True
        Me.cboTextToSearch.HideWhenNotEditingOrAdding = False
        Me.cboTextToSearch.IntegralHeight = False
        Me.cboTextToSearch.LinkedLabel = Nothing
        Me.cboTextToSearch.Location = New System.Drawing.Point(56, 27)
        Me.cboTextToSearch.Margin = New System.Windows.Forms.Padding(1)
        Me.cboTextToSearch.Name = "cboTextToSearch"
        Me.cboTextToSearch.OldValue = 0
        Me.cboTextToSearch.OriginalDataSource = Nothing
        Me.cboTextToSearch.OriginalList = Nothing
        Me.cboTextToSearch.OverrideDropDownStyleList = False
        Me.cboTextToSearch.PreviousSearchTerm = Nothing
        Me.cboTextToSearch.PreviousSelectedIndex = -1
        Me.cboTextToSearch.PropertySelector = Nothing
        Me.cboTextToSearch.ReadOnlyCombo = False
        Me.cboTextToSearch.SearchAnywhere = False
        Me.cboTextToSearch.SearchField = Nothing
        Me.cboTextToSearch.Size = New System.Drawing.Size(251, 24)
        Me.cboTextToSearch.SuggestBoxHeight = 200
        Me.cboTextToSearch.SuggestListOrderRule = Nothing
        Me.cboTextToSearch.TabIndex = 3
        Me.cboTextToSearch.TextToSearch = Nothing
        Me.cboTextToSearch.ValueIsMandatory = False
        Me.cboTextToSearch.ValueIsNullable = False
        Me.cboTextToSearch.ValueIsNumeric = False
        Me.cboTextToSearch.ValueMember = "IdNo"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 2)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnFind, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnCancel, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 158)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(302, 29)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'tlpDates
        '
        Me.tlpDates.ColumnCount = 3
        Me.tlpDates.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDates.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDates.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDates.Controls.Add(Me.dtpBegDate, 0, 0)
        Me.tlpDates.Controls.Add(Me.dtpEndDate, 2, 0)
        Me.tlpDates.Controls.Add(Me.lblTo, 1, 0)
        Me.tlpDates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDates.Location = New System.Drawing.Point(58, 55)
        Me.tlpDates.Name = "tlpDates"
        Me.tlpDates.RowCount = 1
        Me.tlpDates.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDates.Size = New System.Drawing.Size(247, 25)
        Me.tlpDates.TabIndex = 6
        '
        'dtpBegDate
        '
        Me.dtpBegDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBegDate.Location = New System.Drawing.Point(3, 3)
        Me.dtpBegDate.Name = "dtpBegDate"
        Me.dtpBegDate.Size = New System.Drawing.Size(95, 20)
        Me.dtpBegDate.TabIndex = 8
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(141, 3)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(98, 20)
        Me.dtpEndDate.TabIndex = 7
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.BackColor = System.Drawing.Color.Transparent
        Me.lblTo.Location = New System.Drawing.Point(104, 0)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(31, 13)
        Me.lblTo.TabIndex = 6
        Me.lblTo.Text = "  to   "
        '
        'chkChecked
        '
        Me.chkChecked.BackColor = System.Drawing.Color.White
        Me.chkChecked.DisplayOnly = False
        Me.chkChecked.EditingMode = True
        Me.chkChecked.FlatAppearance.BorderSize = 0
        Me.chkChecked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkChecked.ForeColor = System.Drawing.Color.Black
        Me.chkChecked.LinkedLabel = Nothing
        Me.chkChecked.Location = New System.Drawing.Point(56, 84)
        Me.chkChecked.Margin = New System.Windows.Forms.Padding(1)
        Me.chkChecked.Name = "chkChecked"
        Me.chkChecked.NoLabel = True
        Me.chkChecked.OldValue = Nothing
        Me.chkChecked.Size = New System.Drawing.Size(24, 24)
        Me.chkChecked.TabIndex = 8
        Me.chkChecked.Text = "CCheckBox1"
        Me.chkChecked.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkChecked.UseVisualStyleBackColor = True
        '
        'CFindForm
        '
        Me.AcceptButton = Me.BtnFind
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(334, 212)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CFindForm"
        Me.Text = "Find Field Form"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.tlpDates.ResumeLayout(False)
        Me.tlpDates.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TxtTextToSearch As TextBox
    Friend WithEvents lblLookFor1 As Label
    Friend WithEvents RBtnStart As RadioButton
    Friend WithEvents RBtnAnywhere As RadioButton
    Friend WithEvents BtnFind As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblLookFor2 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Public WithEvents cboTextToSearch As CaComboBox
    Friend WithEvents lblLookFor3 As Label
    Friend WithEvents tlpDates As TableLayoutPanel
    Friend WithEvents lblTo As Label
    Friend WithEvents dtpBegDate As DateTimePicker
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents lblLookFor4 As Label
    Friend WithEvents chkChecked As CCheckBox
End Class
