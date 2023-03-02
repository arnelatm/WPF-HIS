Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class CDataGridFindForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CDataGridFindForm))
        Me.TxtTextToSearch = New System.Windows.Forms.TextBox()
        Me.lblLookFor1 = New System.Windows.Forms.Label()
        Me.RBtnStart = New System.Windows.Forms.RadioButton()
        Me.RBtnAnywhere = New System.Windows.Forms.RadioButton()
        Me.BtnFind = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtEndValue = New System.Windows.Forms.TextBox()
        Me.txtBegValue = New System.Windows.Forms.TextBox()
        Me.lblTo1 = New System.Windows.Forms.Label()
        Me.cboTextToSearch = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.dtpEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.dtpBegDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.CGroupBox1 = New AATM.Libraries.CBaseControlsLibrary.CGroupBox()
        Me.RBtnExactMatch = New System.Windows.Forms.RadioButton()
        Me.chkChecked = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.chkIgnoreCase = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.lblIgnoreCase = New System.Windows.Forms.Label()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtFieldToSearch = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkFindAll = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout
        Me.CGroupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'TxtTextToSearch
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtTextToSearch, 4)
        Me.TxtTextToSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTextToSearch.Location = New System.Drawing.Point(58, 3)
        Me.TxtTextToSearch.Name = "TxtTextToSearch"
        Me.TxtTextToSearch.Size = New System.Drawing.Size(274, 20)
        Me.TxtTextToSearch.TabIndex = 0
        '
        'lblLookFor1
        '
        Me.lblLookFor1.AutoSize = true
        Me.lblLookFor1.BackColor = System.Drawing.Color.Transparent
        Me.lblLookFor1.Location = New System.Drawing.Point(3, 0)
        Me.lblLookFor1.Name = "lblLookFor1"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblLookFor1, 5)
        Me.lblLookFor1.Size = New System.Drawing.Size(49, 13)
        Me.lblLookFor1.TabIndex = 1
        Me.lblLookFor1.Text = "Look For"
        '
        'RBtnStart
        '
        Me.RBtnStart.AutoSize = true
        Me.RBtnStart.BackColor = System.Drawing.Color.Transparent
        Me.RBtnStart.Location = New System.Drawing.Point(6, 42)
        Me.RBtnStart.Name = "RBtnStart"
        Me.RBtnStart.Size = New System.Drawing.Size(84, 17)
        Me.RBtnStart.TabIndex = 2
        Me.RBtnStart.Text = "Start of Field"
        Me.RBtnStart.UseVisualStyleBackColor = false
        '
        'RBtnAnywhere
        '
        Me.RBtnAnywhere.AutoSize = true
        Me.RBtnAnywhere.BackColor = System.Drawing.Color.Transparent
        Me.RBtnAnywhere.Checked = true
        Me.RBtnAnywhere.Location = New System.Drawing.Point(6, 19)
        Me.RBtnAnywhere.Name = "RBtnAnywhere"
        Me.RBtnAnywhere.Size = New System.Drawing.Size(112, 17)
        Me.RBtnAnywhere.TabIndex = 3
        Me.RBtnAnywhere.TabStop = true
        Me.RBtnAnywhere.Text = "Anywhere on Field"
        Me.RBtnAnywhere.UseVisualStyleBackColor = false
        '
        'BtnFind
        '
        Me.BtnFind.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnFind.AutoSize = true
        Me.TableLayoutPanel1.SetColumnSpan(Me.BtnFind, 2)
        Me.BtnFind.Location = New System.Drawing.Point(246, 292)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(37, 23)
        Me.BtnFind.TabIndex = 4
        Me.BtnFind.Text = "Find"
        Me.BtnFind.UseVisualStyleBackColor = true
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnCancel.AutoSize = true
        Me.TableLayoutPanel1.SetColumnSpan(Me.BtnCancel, 3)
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(67, 292)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(61, 23)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = true
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.txtEndValue, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBegValue, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTo1, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLookFor1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTextToSearch, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTextToSearch, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpBegDate, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CGroupBox1, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.chkChecked, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.chkIgnoreCase, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIgnoreCase, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnFind, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnCancel, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.chkFindAll, 3, 8)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(11, 29)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(335, 331)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'txtEndValue
        '
        Me.txtEndValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEndValue.Location = New System.Drawing.Point(218, 80)
        Me.txtEndValue.Name = "txtEndValue"
        Me.txtEndValue.Size = New System.Drawing.Size(114, 20)
        Me.txtEndValue.TabIndex = 14
        '
        'txtBegValue
        '
        Me.txtBegValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBegValue.Location = New System.Drawing.Point(58, 80)
        Me.txtBegValue.Name = "txtBegValue"
        Me.txtBegValue.Size = New System.Drawing.Size(114, 20)
        Me.txtBegValue.TabIndex = 13
        '
        'lblTo1
        '
        Me.lblTo1.AutoSize = true
        Me.lblTo1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTo1, 2)
        Me.lblTo1.Location = New System.Drawing.Point(178, 52)
        Me.lblTo1.Name = "lblTo1"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblTo1, 2)
        Me.lblTo1.Size = New System.Drawing.Size(31, 13)
        Me.lblTo1.TabIndex = 6
        Me.lblTo1.Text = "  to   "
        '
        'cboTextToSearch
        '
        Me.cboTextToSearch.BackColor = System.Drawing.Color.White
        Me.cboTextToSearch.BegFindValue = Nothing
        Me.cboTextToSearch.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboTextToSearch, 4)
        Me.cboTextToSearch.CurrentSearchTerm = ""
        Me.cboTextToSearch.DataValue = Nothing
        Me.cboTextToSearch.DefaultValue = Nothing
        Me.cboTextToSearch.DisplayMember = "Name"
        Me.cboTextToSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTextToSearch.EditingMode = true
        Me.cboTextToSearch.EndFindValue = Nothing
        Me.cboTextToSearch.FieldDescription = Nothing
        Me.cboTextToSearch.FieldName = Nothing
        Me.cboTextToSearch.FilterRule = Nothing
        Me.cboTextToSearch.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboTextToSearch.FindEnabled = false
        Me.cboTextToSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboTextToSearch.ForeColor = System.Drawing.Color.Black
        Me.cboTextToSearch.FormattingEnabled = true
        Me.cboTextToSearch.HideWhenNotEditingOrAdding = false
        Me.cboTextToSearch.IgnoreCase = false
        Me.cboTextToSearch.IntegralHeight = false
        Me.cboTextToSearch.LinkedLabel = Nothing
        Me.cboTextToSearch.Location = New System.Drawing.Point(56, 27)
        Me.cboTextToSearch.Margin = New System.Windows.Forms.Padding(1)
        Me.cboTextToSearch.Name = "cboTextToSearch"
        Me.cboTextToSearch.OldValue = 0
        Me.cboTextToSearch.OriginalDataSource = Nothing
        Me.cboTextToSearch.OriginalList = Nothing
        Me.cboTextToSearch.OverrideDropDownStyleList = false
        Me.cboTextToSearch.PreviousSearchTerm = Nothing
        Me.cboTextToSearch.PropertySelector = Nothing
        Me.cboTextToSearch.ReadOnlyCombo = false
        Me.cboTextToSearch.Size = New System.Drawing.Size(278, 24)
        Me.cboTextToSearch.SuggestBoxHeight = 200
        Me.cboTextToSearch.SuggestListOrderRule = Nothing
        Me.cboTextToSearch.TabIndex = 3
        Me.cboTextToSearch.TextToSearch = Nothing
        Me.cboTextToSearch.Translatable = false
        Me.cboTextToSearch.ValueIsMandatory = false
        Me.cboTextToSearch.ValueIsNullable = false
        Me.cboTextToSearch.ValueIsNumeric = false
        Me.cboTextToSearch.ValueMember = "IdNo"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpEndDate.AutoSize = true
        Me.dtpEndDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpEndDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndDate.DefaultValue = Nothing
        Me.dtpEndDate.DisplayOnly = false
        Me.dtpEndDate.DtpDefaultValue = Nothing
        Me.dtpEndDate.EditingMode = true
        Me.dtpEndDate.EditsAllowed = false
        Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndDate.LinkedLabel = Nothing
        Me.dtpEndDate.Location = New System.Drawing.Point(216, 53)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ReadOnlyDp = false
        Me.dtpEndDate.SecurityKey = Nothing
        Me.dtpEndDate.ShowLongDate = false
        Me.dtpEndDate.ShowTime = false
        Me.dtpEndDate.Size = New System.Drawing.Size(118, 23)
        Me.dtpEndDate.TabIndex = 10
        Me.dtpEndDate.TargetCalendar = CType(resources.GetObject("dtpEndDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpEndDate.Translatable = false
        Me.dtpEndDate.Value = Nothing
        Me.dtpEndDate.ValueIsMandatory = false
        Me.dtpEndDate.ValueIsNullable = false
        '
        'dtpBegDate
        '
        Me.dtpBegDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpBegDate.AutoSize = true
        Me.dtpBegDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpBegDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpBegDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpBegDate.DefaultValue = Nothing
        Me.dtpBegDate.DisplayOnly = false
        Me.dtpBegDate.DtpDefaultValue = Nothing
        Me.dtpBegDate.EditingMode = true
        Me.dtpBegDate.EditsAllowed = false
        Me.dtpBegDate.ForeColor = System.Drawing.Color.Black
        Me.dtpBegDate.LinkedLabel = Nothing
        Me.dtpBegDate.Location = New System.Drawing.Point(56, 53)
        Me.dtpBegDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpBegDate.Name = "dtpBegDate"
        Me.dtpBegDate.ReadOnlyDp = false
        Me.dtpBegDate.SecurityKey = Nothing
        Me.dtpBegDate.ShowLongDate = false
        Me.dtpBegDate.ShowTime = false
        Me.dtpBegDate.Size = New System.Drawing.Size(118, 23)
        Me.dtpBegDate.TabIndex = 9
        Me.dtpBegDate.TargetCalendar = CType(resources.GetObject("dtpBegDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpBegDate.Translatable = false
        Me.dtpBegDate.Value = Nothing
        Me.dtpBegDate.ValueIsMandatory = false
        Me.dtpBegDate.ValueIsNullable = false
        '
        'CGroupBox1
        '
        Me.CGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CGroupBox1.AutoSize = true
        Me.CGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.CGroupBox1, 5)
        Me.CGroupBox1.Controls.Add(Me.RBtnStart)
        Me.CGroupBox1.Controls.Add(Me.RBtnAnywhere)
        Me.CGroupBox1.Controls.Add(Me.RBtnExactMatch)
        Me.CGroupBox1.DisplayOnly = true
        Me.CGroupBox1.Location = New System.Drawing.Point(105, 128)
        Me.CGroupBox1.Name = "CGroupBox1"
        Me.CGroupBox1.Size = New System.Drawing.Size(124, 101)
        Me.CGroupBox1.TabIndex = 7
        Me.CGroupBox1.TabStop = false
        '
        'RBtnExactMatch
        '
        Me.RBtnExactMatch.AutoSize = true
        Me.RBtnExactMatch.BackColor = System.Drawing.Color.Transparent
        Me.RBtnExactMatch.Location = New System.Drawing.Point(5, 65)
        Me.RBtnExactMatch.Name = "RBtnExactMatch"
        Me.RBtnExactMatch.Size = New System.Drawing.Size(85, 17)
        Me.RBtnExactMatch.TabIndex = 11
        Me.RBtnExactMatch.Text = "Exact Match"
        Me.RBtnExactMatch.UseVisualStyleBackColor = false
        '
        'chkChecked
        '
        Me.chkChecked.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.chkChecked.BackColor = System.Drawing.Color.White
        Me.chkChecked.BegFindValue = Nothing
        Me.chkChecked.Checked = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.chkChecked, 2)
        Me.chkChecked.EditingMode = true
        Me.chkChecked.EndFindValue = Nothing
        Me.chkChecked.FieldDescription = Nothing
        Me.chkChecked.FieldName = Nothing
        Me.chkChecked.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkChecked.FindEnabled = false
        Me.chkChecked.ForeColor = System.Drawing.Color.Black
        Me.chkChecked.IgnoreCase = false
        Me.chkChecked.LinkedLabel = Nothing
        Me.chkChecked.Location = New System.Drawing.Point(196, 104)
        Me.chkChecked.Margin = New System.Windows.Forms.Padding(1)
        Me.chkChecked.Name = "chkChecked"
        Me.chkChecked.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkChecked.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkChecked.Size = New System.Drawing.Size(20, 20)
        Me.chkChecked.TabIndex = 8
        Me.chkChecked.Text = "UcCheckBox1"
        Me.chkChecked.Translatable = true
        '
        'chkIgnoreCase
        '
        Me.chkIgnoreCase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.chkIgnoreCase.BackColor = System.Drawing.Color.White
        Me.chkIgnoreCase.BegFindValue = Nothing
        Me.chkIgnoreCase.Checked = true
        Me.TableLayoutPanel1.SetColumnSpan(Me.chkIgnoreCase, 2)
        Me.chkIgnoreCase.EditingMode = true
        Me.chkIgnoreCase.EndFindValue = Nothing
        Me.chkIgnoreCase.FieldDescription = Nothing
        Me.chkIgnoreCase.FieldName = Nothing
        Me.chkIgnoreCase.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkIgnoreCase.FindEnabled = false
        Me.chkIgnoreCase.ForeColor = System.Drawing.Color.Black
        Me.chkIgnoreCase.IgnoreCase = false
        Me.chkIgnoreCase.LinkedLabel = Nothing
        Me.chkIgnoreCase.Location = New System.Drawing.Point(196, 233)
        Me.chkIgnoreCase.Margin = New System.Windows.Forms.Padding(1)
        Me.chkIgnoreCase.Name = "chkIgnoreCase"
        Me.chkIgnoreCase.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIgnoreCase.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkIgnoreCase.Size = New System.Drawing.Size(20, 20)
        Me.chkIgnoreCase.TabIndex = 15
        Me.chkIgnoreCase.Text = "UcCheckBox1"
        Me.chkIgnoreCase.Translatable = true
        Me.chkIgnoreCase.Visible = false
        '
        'lblIgnoreCase
        '
        Me.lblIgnoreCase.AutoSize = true
        Me.lblIgnoreCase.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblIgnoreCase, 2)
        Me.lblIgnoreCase.Location = New System.Drawing.Point(3, 232)
        Me.lblIgnoreCase.Name = "lblIgnoreCase"
        Me.lblIgnoreCase.Size = New System.Drawing.Size(70, 13)
        Me.lblIgnoreCase.TabIndex = 16
        Me.lblIgnoreCase.Text = "Ignore Case?"
        Me.lblIgnoreCase.Visible = false
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.BackColor = System.Drawing.Color.Transparent
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(10, 6)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(111, 17)
        Me.CLabel1.TabIndex = 7
        Me.CLabel1.Text = "Field to Search :"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = true
        '
        'txtFieldToSearch
        '
        Me.txtFieldToSearch.AutoSize = true
        Me.txtFieldToSearch.BackColor = System.Drawing.Color.Transparent
        Me.txtFieldToSearch.DisplayOnly = true
        Me.txtFieldToSearch.EditingMode = false
        Me.txtFieldToSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtFieldToSearch.ForeColor = System.Drawing.Color.Black
        Me.txtFieldToSearch.Location = New System.Drawing.Point(124, 6)
        Me.txtFieldToSearch.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFieldToSearch.Name = "txtFieldToSearch"
        Me.txtFieldToSearch.Size = New System.Drawing.Size(103, 17)
        Me.txtFieldToSearch.TabIndex = 8
        Me.txtFieldToSearch.Text = "Field to Search"
        Me.txtFieldToSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtFieldToSearch.Translatable = true
        '
        'chkFindAll
        '
        Me.chkFindAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.chkFindAll.BackColor = System.Drawing.Color.White
        Me.chkFindAll.BegFindValue = Nothing
        Me.chkFindAll.Checked = true
        Me.TableLayoutPanel1.SetColumnSpan(Me.chkFindAll, 2)
        Me.chkFindAll.EditingMode = true
        Me.chkFindAll.EndFindValue = Nothing
        Me.chkFindAll.FieldDescription = Nothing
        Me.chkFindAll.FieldName = Nothing
        Me.chkFindAll.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkFindAll.FindEnabled = false
        Me.chkFindAll.ForeColor = System.Drawing.Color.Black
        Me.chkFindAll.IgnoreCase = false
        Me.chkFindAll.LinkedLabel = Nothing
        Me.chkFindAll.Location = New System.Drawing.Point(196, 255)
        Me.chkFindAll.Margin = New System.Windows.Forms.Padding(1)
        Me.chkFindAll.Name = "chkFindAll"
        Me.chkFindAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkFindAll.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkFindAll.Size = New System.Drawing.Size(20, 20)
        Me.chkFindAll.TabIndex = 17
        Me.chkFindAll.Text = "UcCheckBox1"
        Me.chkFindAll.Translatable = true
        Me.chkFindAll.Visible = false
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Location = New System.Drawing.Point(3, 254)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Find All?"
        Me.Label1.Visible = false
        '
        'CDataGridFindForm
        '
        Me.AcceptButton = Me.BtnFind
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(358, 376)
        Me.Controls.Add(Me.txtFieldToSearch)
        Me.Controls.Add(Me.CLabel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CDataGridFindForm"
        Me.Text = "Find Field Form"
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.CGroupBox1.ResumeLayout(false)
        Me.CGroupBox1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents TxtTextToSearch As TextBox
    Friend WithEvents lblLookFor1 As Label
    Friend WithEvents RBtnStart As RadioButton
    Friend WithEvents RBtnAnywhere As RadioButton
    Friend WithEvents BtnFind As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Public WithEvents cboTextToSearch As CaComboBox
    Friend WithEvents lblTo1 As Label
    Friend WithEvents chkChecked As UcCheckBox
    Friend WithEvents dtpEndDate As CCustomDateTimePicker
    Friend WithEvents dtpBegDate As CCustomDateTimePicker
    Friend WithEvents RBtnExactMatch As RadioButton
    Friend WithEvents CGroupBox1 As CGroupBox
    Friend WithEvents txtEndValue As TextBox
    Friend WithEvents txtBegValue As TextBox
    Friend WithEvents CLabel1 As CLabel
    Friend WithEvents txtFieldToSearch As CLabel
    Friend WithEvents chkIgnoreCase As UcCheckBox
    Friend WithEvents lblIgnoreCase As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chkFindAll As UcCheckBox
End Class
