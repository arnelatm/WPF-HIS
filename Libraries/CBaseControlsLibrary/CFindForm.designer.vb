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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CFindForm))
        Me.TxtTextToSearch = New System.Windows.Forms.TextBox()
        Me.lblLookFor1 = New System.Windows.Forms.Label()
        Me.RBtnStart = New System.Windows.Forms.RadioButton()
        Me.RBtnAnywhere = New System.Windows.Forms.RadioButton()
        Me.BtnFind = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLookFor4 = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblLookFor3 = New System.Windows.Forms.Label()
        Me.lblLookFor2 = New System.Windows.Forms.Label()
        Me.cboTextToSearch = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.chkChecked = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.dtpEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.dtpBegDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.RBtnExactMatch = New System.Windows.Forms.RadioButton()
        Me.CGroupBox1 = New AATM.Libraries.CBaseControlsLibrary.CGroupBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.CGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtTextToSearch
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtTextToSearch, 4)
        Me.TxtTextToSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTextToSearch.Location = New System.Drawing.Point(58, 3)
        Me.TxtTextToSearch.Name = "TxtTextToSearch"
        Me.TxtTextToSearch.Size = New System.Drawing.Size(270, 20)
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
        Me.RBtnStart.Location = New System.Drawing.Point(6, 42)
        Me.RBtnStart.Name = "RBtnStart"
        Me.RBtnStart.Size = New System.Drawing.Size(84, 17)
        Me.RBtnStart.TabIndex = 2
        Me.RBtnStart.Text = "Start of Field"
        Me.RBtnStart.UseVisualStyleBackColor = False
        '
        'RBtnAnywhere
        '
        Me.RBtnAnywhere.AutoSize = True
        Me.RBtnAnywhere.BackColor = System.Drawing.Color.Transparent
        Me.RBtnAnywhere.Checked = True
        Me.RBtnAnywhere.Location = New System.Drawing.Point(6, 19)
        Me.RBtnAnywhere.Name = "RBtnAnywhere"
        Me.RBtnAnywhere.Size = New System.Drawing.Size(112, 17)
        Me.RBtnAnywhere.TabIndex = 3
        Me.RBtnAnywhere.TabStop = True
        Me.RBtnAnywhere.Text = "Anywhere on Field"
        Me.RBtnAnywhere.UseVisualStyleBackColor = False
        '
        'BtnFind
        '
        Me.BtnFind.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnFind.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.BtnFind, 2)
        Me.BtnFind.Location = New System.Drawing.Point(58, 215)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(55, 23)
        Me.BtnFind.TabIndex = 4
        Me.BtnFind.Text = "Find"
        Me.BtnFind.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnCancel.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.BtnCancel, 3)
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(220, 215)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(61, 23)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CGroupBox1, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLookFor4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTo, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLookFor3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLookFor2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLookFor1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTextToSearch, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTextToSearch, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chkChecked, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpBegDate, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnCancel, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnFind, 0, 6)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(331, 241)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'lblLookFor4
        '
        Me.lblLookFor4.AutoSize = True
        Me.lblLookFor4.BackColor = System.Drawing.Color.Transparent
        Me.lblLookFor4.Location = New System.Drawing.Point(3, 79)
        Me.lblLookFor4.Name = "lblLookFor4"
        Me.lblLookFor4.Size = New System.Drawing.Size(49, 13)
        Me.lblLookFor4.TabIndex = 7
        Me.lblLookFor4.Text = "Look For"
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTo, 2)
        Me.lblTo.Location = New System.Drawing.Point(174, 52)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(31, 13)
        Me.lblTo.TabIndex = 6
        Me.lblTo.Text = "  to   "
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
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboTextToSearch, 4)
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
        Me.cboTextToSearch.SearchPlace = "1"
        Me.cboTextToSearch.SearchField = Nothing
        Me.cboTextToSearch.Size = New System.Drawing.Size(274, 24)
        Me.cboTextToSearch.SuggestBoxHeight = 200
        Me.cboTextToSearch.SuggestListOrderRule = Nothing
        Me.cboTextToSearch.TabIndex = 3
        Me.cboTextToSearch.TextToSearch = Nothing
        Me.cboTextToSearch.ValueIsMandatory = False
        Me.cboTextToSearch.ValueIsNullable = False
        Me.cboTextToSearch.ValueIsNumeric = False
        Me.cboTextToSearch.ValueMember = "IdNo"
        '
        'chkChecked
        '
        Me.chkChecked.BackColor = System.Drawing.Color.White
        Me.chkChecked.DisplayOnly = False
        Me.chkChecked.EditingMode = True
        Me.chkChecked.FindEnabled = False
        Me.chkChecked.FlatAppearance.BorderSize = 0
        Me.chkChecked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkChecked.ForeColor = System.Drawing.Color.Black
        Me.chkChecked.LinkedLabel = Nothing
        Me.chkChecked.Location = New System.Drawing.Point(56, 80)
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
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndDate.DefaultValue = Nothing
        Me.dtpEndDate.DisplayOnly = False
        Me.dtpEndDate.DtpDefaultValue = Nothing
        Me.dtpEndDate.EditingMode = True
        Me.dtpEndDate.EditsAllowed = False
        Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndDate.LinkedLabel = Nothing
        Me.dtpEndDate.Location = New System.Drawing.Point(215, 53)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ReadOnlyDp = False
        Me.dtpEndDate.SecurityKey = Nothing
        Me.dtpEndDate.ShowLongDate = False
        Me.dtpEndDate.ShowTime = False
        Me.dtpEndDate.Size = New System.Drawing.Size(112, 25)
        Me.dtpEndDate.TabIndex = 9
        Me.dtpEndDate.TargetCalendar = CType(resources.GetObject("dtpEndDate.TargetCalendar"), System.Globalization.Calendar)
        Me.dtpEndDate.Value = Nothing
        Me.dtpEndDate.ValueIsMandatory = False
        Me.dtpEndDate.ValueIsNullable = False
        '
        'dtpBegDate
        '
        Me.dtpBegDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpBegDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpBegDate.DefaultValue = Nothing
        Me.dtpBegDate.DisplayOnly = False
        Me.dtpBegDate.DtpDefaultValue = Nothing
        Me.dtpBegDate.EditingMode = True
        Me.dtpBegDate.EditsAllowed = False
        Me.dtpBegDate.ForeColor = System.Drawing.Color.Black
        Me.dtpBegDate.LinkedLabel = Nothing
        Me.dtpBegDate.Location = New System.Drawing.Point(57, 53)
        Me.dtpBegDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpBegDate.Name = "dtpBegDate"
        Me.dtpBegDate.ReadOnlyDp = False
        Me.dtpBegDate.SecurityKey = Nothing
        Me.dtpBegDate.ShowLongDate = False
        Me.dtpBegDate.ShowTime = False
        Me.dtpBegDate.Size = New System.Drawing.Size(112, 25)
        Me.dtpBegDate.TabIndex = 10
        Me.dtpBegDate.TargetCalendar = CType(resources.GetObject("dtpBegDate.TargetCalendar"), System.Globalization.Calendar)
        Me.dtpBegDate.Value = Nothing
        Me.dtpBegDate.ValueIsMandatory = False
        Me.dtpBegDate.ValueIsNullable = False
        '
        'RBtnExactMatch
        '
        Me.RBtnExactMatch.AutoSize = True
        Me.RBtnExactMatch.BackColor = System.Drawing.Color.Transparent
        Me.RBtnExactMatch.Location = New System.Drawing.Point(5, 65)
        Me.RBtnExactMatch.Name = "RBtnExactMatch"
        Me.RBtnExactMatch.Size = New System.Drawing.Size(85, 17)
        Me.RBtnExactMatch.TabIndex = 11
        Me.RBtnExactMatch.Text = "Exact Match"
        Me.RBtnExactMatch.UseVisualStyleBackColor = False
        '
        'CGroupBox1
        '
        Me.CGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CGroupBox1.AutoSize = True
        Me.CGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.CGroupBox1, 5)
        Me.CGroupBox1.Controls.Add(Me.RBtnStart)
        Me.CGroupBox1.Controls.Add(Me.RBtnAnywhere)
        Me.CGroupBox1.Controls.Add(Me.RBtnExactMatch)
        Me.CGroupBox1.DisplayOnly = True
        Me.CGroupBox1.Location = New System.Drawing.Point(103, 108)
        Me.CGroupBox1.Name = "CGroupBox1"
        Me.CGroupBox1.Size = New System.Drawing.Size(124, 101)
        Me.CGroupBox1.TabIndex = 7
        Me.CGroupBox1.TabStop = False
        '
        'CFindForm
        '
        Me.AcceptButton = Me.BtnFind
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(354, 266)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CFindForm"
        Me.Text = "Find Field Form"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.CGroupBox1.ResumeLayout(False)
        Me.CGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtTextToSearch As TextBox
    Friend WithEvents lblLookFor1 As Label
    Friend WithEvents RBtnStart As RadioButton
    Friend WithEvents RBtnAnywhere As RadioButton
    Friend WithEvents BtnFind As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblLookFor2 As Label
    Public WithEvents cboTextToSearch As CaComboBox
    Friend WithEvents lblLookFor3 As Label
    Friend WithEvents lblTo As Label
    Friend WithEvents lblLookFor4 As Label
    Friend WithEvents chkChecked As CCheckBox
    Friend WithEvents dtpEndDate As CCustomDateTimePicker
    Friend WithEvents dtpBegDate As CCustomDateTimePicker
    Friend WithEvents RBtnExactMatch As RadioButton
    Friend WithEvents CGroupBox1 As CGroupBox
End Class
