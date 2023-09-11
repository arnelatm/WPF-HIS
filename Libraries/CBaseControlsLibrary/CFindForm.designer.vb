Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class CFindForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CFindForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtTextToSearch = New System.Windows.Forms.TextBox()
        Me.lblLookFor1 = New System.Windows.Forms.Label()
        Me.RBtnStart = New System.Windows.Forms.RadioButton()
        Me.RBtnAnywhere = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbtTextToSearch = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.txtEndValue = New System.Windows.Forms.TextBox()
        Me.txtBegValue = New System.Windows.Forms.TextBox()
        Me.lblTo1 = New System.Windows.Forms.Label()
        Me.cboTextToSearch = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.dtpEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.dtpBegDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.cgbStringFindOption = New AATM.Libraries.CBaseControlsLibrary.CGroupBox()
        Me.RBtnExactMatch = New System.Windows.Forms.RadioButton()
        Me.chkChecked = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.chkIgnoreCase = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.lblIgnoreCase = New System.Windows.Forms.Label()
        Me.BtnFind = New System.Windows.Forms.Button()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtFieldToSearch = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CDataGridViewWithFooter1 = New AATM.Libraries.CBaseControlsLibrary.cDataGridViewWithFooter()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.cgbStringFindOption.SuspendLayout()
        CType(Me.CDataGridViewWithFooter1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtTextToSearch
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtTextToSearch, 4)
        Me.TxtTextToSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTextToSearch.Location = New System.Drawing.Point(58, 3)
        Me.TxtTextToSearch.Name = "TxtTextToSearch"
        Me.TxtTextToSearch.Size = New System.Drawing.Size(275, 20)
        Me.TxtTextToSearch.TabIndex = 0
        '
        'lblLookFor1
        '
        Me.lblLookFor1.AutoSize = True
        Me.lblLookFor1.BackColor = System.Drawing.Color.Transparent
        Me.lblLookFor1.Location = New System.Drawing.Point(3, 0)
        Me.lblLookFor1.Name = "lblLookFor1"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblLookFor1, 6)
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
        Me.TableLayoutPanel1.Controls.Add(Me.cbtTextToSearch, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtEndValue, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBegValue, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTo1, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLookFor1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTextToSearch, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTextToSearch, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpBegDate, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cgbStringFindOption, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.chkChecked, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnCancel, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.chkIgnoreCase, 3, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIgnoreCase, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnFind, 3, 9)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(10, 45)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(336, 328)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'cbtTextToSearch
        '
        Me.cbtTextToSearch.BackColor = System.Drawing.Color.White
        Me.cbtTextToSearch.BegFindValue = Nothing
        Me.cbtTextToSearch.ChangingSearchValueOnly = False
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbtTextToSearch, 4)
        Me.cbtTextToSearch.CurrentSearchTerm = ""
        Me.cbtTextToSearch.DataValue = Nothing
        Me.cbtTextToSearch.DefaultValue = Nothing
        Me.cbtTextToSearch.DisplayMember = "Name"
        Me.cbtTextToSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbtTextToSearch.DropDownHeight = 21
        Me.cbtTextToSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cbtTextToSearch.Editable = True
        Me.cbtTextToSearch.EditingMode = False
        Me.cbtTextToSearch.EndFindValue = Nothing
        Me.cbtTextToSearch.FieldDescription = Nothing
        Me.cbtTextToSearch.FieldName = Nothing
        Me.cbtTextToSearch.FilterRule = Nothing
        Me.cbtTextToSearch.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cbtTextToSearch.FindEnabled = False
        Me.cbtTextToSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbtTextToSearch.ForeColor = System.Drawing.Color.Black
        Me.cbtTextToSearch.FormattingEnabled = True
        Me.cbtTextToSearch.HideWhenNotEditingOrAdding = False
        Me.cbtTextToSearch.IgnoreCase = False
        Me.cbtTextToSearch.LimitToList = False
        Me.cbtTextToSearch.LinkedLabel = Nothing
        Me.cbtTextToSearch.Location = New System.Drawing.Point(56, 57)
        Me.cbtTextToSearch.Margin = New System.Windows.Forms.Padding(1)
        Me.cbtTextToSearch.MaxDropDownItems = 1
        Me.cbtTextToSearch.Name = "cbtTextToSearch"
        Me.cbtTextToSearch.OldValue = 0
        Me.cbtTextToSearch.OriginalDataSource = Nothing
        Me.cbtTextToSearch.OriginalList = Nothing
        Me.cbtTextToSearch.OverrideDropDownStyleList = False
        Me.cbtTextToSearch.PreviousSearchTerm = Nothing
        Me.cbtTextToSearch.PropertySelector = Nothing
        Me.cbtTextToSearch.Size = New System.Drawing.Size(279, 18)
        Me.cbtTextToSearch.SuggestBoxHeight = 200
        Me.cbtTextToSearch.SuggestCharCount = 0
        Me.cbtTextToSearch.SuggestListOrderRule = Nothing
        Me.cbtTextToSearch.TabIndex = 9
        Me.cbtTextToSearch.TextToSearch = Nothing
        Me.cbtTextToSearch.Translatable = False
        Me.cbtTextToSearch.ValueIsMandatory = False
        Me.cbtTextToSearch.ValueIsNullable = False
        Me.cbtTextToSearch.ValueIsNumeric = False
        Me.cbtTextToSearch.ValueMember = "IdNo"
        '
        'txtEndValue
        '
        Me.txtEndValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEndValue.Location = New System.Drawing.Point(219, 104)
        Me.txtEndValue.Name = "txtEndValue"
        Me.txtEndValue.Size = New System.Drawing.Size(114, 20)
        Me.txtEndValue.TabIndex = 14
        '
        'txtBegValue
        '
        Me.txtBegValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBegValue.Location = New System.Drawing.Point(58, 104)
        Me.txtBegValue.Name = "txtBegValue"
        Me.txtBegValue.Size = New System.Drawing.Size(115, 20)
        Me.txtBegValue.TabIndex = 13
        '
        'lblTo1
        '
        Me.lblTo1.AutoSize = True
        Me.lblTo1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblTo1, 2)
        Me.lblTo1.Location = New System.Drawing.Point(179, 76)
        Me.lblTo1.Name = "lblTo1"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblTo1, 2)
        Me.lblTo1.Size = New System.Drawing.Size(31, 13)
        Me.lblTo1.TabIndex = 6
        Me.lblTo1.Text = "  to   "
        '
        'cboTextToSearch
        '
        Me.cboTextToSearch.AlwaysEditable = True
        Me.cboTextToSearch.BackColor = System.Drawing.Color.White
        Me.cboTextToSearch.BegFindValue = Nothing
        Me.cboTextToSearch.ChangingSearchValueOnly = False
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboTextToSearch, 4)
        Me.cboTextToSearch.CurrentSearchTerm = ""
        Me.cboTextToSearch.DataValue = Nothing
        Me.cboTextToSearch.DefaultValue = Nothing
        Me.cboTextToSearch.DisplayMember = "Name"
        Me.cboTextToSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTextToSearch.DropDownHeight = 21
        Me.cboTextToSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboTextToSearch.Editable = True
        Me.cboTextToSearch.EditingMode = False
        Me.cboTextToSearch.EndFindValue = Nothing
        Me.cboTextToSearch.FieldDescription = Nothing
        Me.cboTextToSearch.FieldName = Nothing
        Me.cboTextToSearch.FilterRule = Nothing
        Me.cboTextToSearch.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboTextToSearch.FindEnabled = False
        Me.cboTextToSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cboTextToSearch.ForeColor = System.Drawing.Color.Black
        Me.cboTextToSearch.FormattingEnabled = True
        Me.cboTextToSearch.HideWhenNotEditingOrAdding = False
        Me.cboTextToSearch.IgnoreCase = False
        Me.cboTextToSearch.LimitToList = False
        Me.cboTextToSearch.LinkedLabel = Nothing
        Me.cboTextToSearch.Location = New System.Drawing.Point(56, 27)
        Me.cboTextToSearch.Margin = New System.Windows.Forms.Padding(1)
        Me.cboTextToSearch.MaxDropDownItems = 1
        Me.cboTextToSearch.Name = "cboTextToSearch"
        Me.cboTextToSearch.OldValue = 0
        Me.cboTextToSearch.OriginalDataSource = Nothing
        Me.cboTextToSearch.OriginalList = Nothing
        Me.cboTextToSearch.OverrideDropDownStyleList = False
        Me.cboTextToSearch.PreviousSearchTerm = Nothing
        Me.cboTextToSearch.PropertySelector = Nothing
        Me.cboTextToSearch.ReadOnlyCombo = False
        Me.cboTextToSearch.Size = New System.Drawing.Size(279, 28)
        Me.cboTextToSearch.SuggestBoxHeight = 200
        Me.cboTextToSearch.SuggestListOrderRule = Nothing
        Me.cboTextToSearch.TabIndex = 3
        Me.cboTextToSearch.TextToSearch = Nothing
        Me.cboTextToSearch.Translatable = False
        Me.cboTextToSearch.ValueIsMandatory = False
        Me.cboTextToSearch.ValueIsNullable = False
        Me.cboTextToSearch.ValueIsNumeric = False
        Me.cboTextToSearch.ValueMember = "IdNo"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpEndDate.AutoSize = True
        Me.dtpEndDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpEndDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndDate.DefaultValue = Nothing
        Me.dtpEndDate.DisplayOnly = False
        Me.dtpEndDate.DtpDefaultValue = Nothing
        Me.dtpEndDate.EditingMode = True
        Me.dtpEndDate.EditsAllowed = False
        Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndDate.LinkedLabel = Nothing
        Me.dtpEndDate.Location = New System.Drawing.Point(217, 77)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ReadOnlyDp = False
        Me.dtpEndDate.SecurityKey = Nothing
        Me.dtpEndDate.ShowLongDate = False
        Me.dtpEndDate.ShowTime = False
        Me.dtpEndDate.Size = New System.Drawing.Size(118, 23)
        Me.dtpEndDate.TabIndex = 10
        Me.dtpEndDate.TargetCalendar = CType(resources.GetObject("dtpEndDate.TargetCalendar"), System.Globalization.Calendar)
        Me.dtpEndDate.Translatable = False
        Me.dtpEndDate.Value = Nothing
        Me.dtpEndDate.ValueIsMandatory = False
        Me.dtpEndDate.ValueIsNullable = False
        '
        'dtpBegDate
        '
        Me.dtpBegDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpBegDate.AutoSize = True
        Me.dtpBegDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpBegDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpBegDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpBegDate.DefaultValue = Nothing
        Me.dtpBegDate.DisplayOnly = False
        Me.dtpBegDate.DtpDefaultValue = Nothing
        Me.dtpBegDate.EditingMode = True
        Me.dtpBegDate.EditsAllowed = False
        Me.dtpBegDate.ForeColor = System.Drawing.Color.Black
        Me.dtpBegDate.LinkedLabel = Nothing
        Me.dtpBegDate.Location = New System.Drawing.Point(56, 77)
        Me.dtpBegDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpBegDate.Name = "dtpBegDate"
        Me.dtpBegDate.ReadOnlyDp = False
        Me.dtpBegDate.SecurityKey = Nothing
        Me.dtpBegDate.ShowLongDate = False
        Me.dtpBegDate.ShowTime = False
        Me.dtpBegDate.Size = New System.Drawing.Size(118, 23)
        Me.dtpBegDate.TabIndex = 9
        Me.dtpBegDate.TargetCalendar = CType(resources.GetObject("dtpBegDate.TargetCalendar"), System.Globalization.Calendar)
        Me.dtpBegDate.Translatable = False
        Me.dtpBegDate.Value = Nothing
        Me.dtpBegDate.ValueIsMandatory = False
        Me.dtpBegDate.ValueIsNullable = False
        '
        'cgbStringFindOption
        '
        Me.cgbStringFindOption.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cgbStringFindOption.AutoSize = True
        Me.cgbStringFindOption.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.cgbStringFindOption, 5)
        Me.cgbStringFindOption.Controls.Add(Me.RBtnStart)
        Me.cgbStringFindOption.Controls.Add(Me.RBtnAnywhere)
        Me.cgbStringFindOption.Controls.Add(Me.RBtnExactMatch)
        Me.cgbStringFindOption.DisplayOnly = True
        Me.cgbStringFindOption.Location = New System.Drawing.Point(106, 152)
        Me.cgbStringFindOption.Name = "cgbStringFindOption"
        Me.cgbStringFindOption.Size = New System.Drawing.Size(124, 101)
        Me.cgbStringFindOption.TabIndex = 7
        Me.cgbStringFindOption.TabStop = False
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
        'chkChecked
        '
        Me.chkChecked.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.chkChecked.BackColor = System.Drawing.Color.White
        Me.chkChecked.BegFindValue = Nothing
        Me.chkChecked.Checked = False
        Me.TableLayoutPanel1.SetColumnSpan(Me.chkChecked, 2)
        Me.chkChecked.EditingMode = True
        Me.chkChecked.EndFindValue = Nothing
        Me.chkChecked.FieldDescription = Nothing
        Me.chkChecked.FieldName = Nothing
        Me.chkChecked.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkChecked.FindEnabled = False
        Me.chkChecked.ForeColor = System.Drawing.Color.Black
        Me.chkChecked.IgnoreCase = False
        Me.chkChecked.LinkedLabel = Nothing
        Me.chkChecked.Location = New System.Drawing.Point(197, 128)
        Me.chkChecked.Margin = New System.Windows.Forms.Padding(1)
        Me.chkChecked.Name = "chkChecked"
        Me.chkChecked.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkChecked.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkChecked.Size = New System.Drawing.Size(20, 20)
        Me.chkChecked.TabIndex = 8
        Me.chkChecked.Text = "UcCheckBox1"
        Me.chkChecked.Translatable = True
        '
        'BtnCancel
        '
        Me.BtnCancel.AutoSize = True
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(58, 291)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(100, 30)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'chkIgnoreCase
        '
        Me.chkIgnoreCase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.chkIgnoreCase.BackColor = System.Drawing.Color.White
        Me.chkIgnoreCase.BegFindValue = Nothing
        Me.chkIgnoreCase.Checked = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.chkIgnoreCase, 2)
        Me.chkIgnoreCase.EditingMode = True
        Me.chkIgnoreCase.EndFindValue = Nothing
        Me.chkIgnoreCase.FieldDescription = Nothing
        Me.chkIgnoreCase.FieldName = Nothing
        Me.chkIgnoreCase.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkIgnoreCase.FindEnabled = False
        Me.chkIgnoreCase.ForeColor = System.Drawing.Color.Black
        Me.chkIgnoreCase.IgnoreCase = False
        Me.chkIgnoreCase.LinkedLabel = Nothing
        Me.chkIgnoreCase.Location = New System.Drawing.Point(197, 257)
        Me.chkIgnoreCase.Margin = New System.Windows.Forms.Padding(1)
        Me.chkIgnoreCase.Name = "chkIgnoreCase"
        Me.chkIgnoreCase.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIgnoreCase.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkIgnoreCase.Size = New System.Drawing.Size(20, 20)
        Me.chkIgnoreCase.TabIndex = 15
        Me.chkIgnoreCase.Text = "UcCheckBox1"
        Me.chkIgnoreCase.Translatable = True
        Me.chkIgnoreCase.Visible = False
        '
        'lblIgnoreCase
        '
        Me.lblIgnoreCase.AutoSize = True
        Me.lblIgnoreCase.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblIgnoreCase, 2)
        Me.lblIgnoreCase.Location = New System.Drawing.Point(3, 256)
        Me.lblIgnoreCase.Name = "lblIgnoreCase"
        Me.lblIgnoreCase.Size = New System.Drawing.Size(70, 13)
        Me.lblIgnoreCase.TabIndex = 16
        Me.lblIgnoreCase.Text = "Ignore Case?"
        Me.lblIgnoreCase.Visible = False
        '
        'BtnFind
        '
        Me.BtnFind.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.BtnFind, 2)
        Me.BtnFind.Location = New System.Drawing.Point(199, 291)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(110, 30)
        Me.BtnFind.TabIndex = 4
        Me.BtnFind.Text = "Find"
        Me.BtnFind.UseVisualStyleBackColor = True
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = True
        Me.CLabel1.BackColor = System.Drawing.Color.Transparent
        Me.CLabel1.DisplayOnly = True
        Me.CLabel1.EditingMode = False
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel1.Location = New System.Drawing.Point(10, 10)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(115, 17)
        Me.CLabel1.TabIndex = 7
        Me.CLabel1.Text = "Field to Search  :"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = True
        '
        'txtFieldToSearch
        '
        Me.txtFieldToSearch.AutoSize = True
        Me.txtFieldToSearch.BackColor = System.Drawing.Color.Transparent
        Me.txtFieldToSearch.DisplayOnly = True
        Me.txtFieldToSearch.EditingMode = False
        Me.txtFieldToSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtFieldToSearch.ForeColor = System.Drawing.Color.Black
        Me.txtFieldToSearch.Location = New System.Drawing.Point(149, 10)
        Me.txtFieldToSearch.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFieldToSearch.Name = "txtFieldToSearch"
        Me.txtFieldToSearch.Size = New System.Drawing.Size(103, 17)
        Me.txtFieldToSearch.TabIndex = 8
        Me.txtFieldToSearch.Text = "Field to Search"
        Me.txtFieldToSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtFieldToSearch.Translatable = True
        '
        'CDataGridViewWithFooter1
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.CDataGridViewWithFooter1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.CDataGridViewWithFooter1.BegFindValue = Nothing
        Me.CDataGridViewWithFooter1.Cached = False
        Me.CDataGridViewWithFooter1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CDataGridViewWithFooter1.DataFilter = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CDataGridViewWithFooter1.DefaultCellStyle = DataGridViewCellStyle2
        Me.CDataGridViewWithFooter1.DgvFooter = Nothing
        Me.CDataGridViewWithFooter1.DisplayOnly = False
        Me.CDataGridViewWithFooter1.Ea = Nothing
        Me.CDataGridViewWithFooter1.EditingMode = False
        Me.CDataGridViewWithFooter1.EndFindValue = Nothing
        Me.CDataGridViewWithFooter1.FieldDescription = Nothing
        Me.CDataGridViewWithFooter1.FieldName = Nothing
        Me.CDataGridViewWithFooter1.FieldsDictionary = Nothing
        Me.CDataGridViewWithFooter1.FindColumnNo = CType(0, Short)
        Me.CDataGridViewWithFooter1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.CDataGridViewWithFooter1.FindEnabled = False
        Me.CDataGridViewWithFooter1.FirstRowDeletionEnabled = True
        Me.CDataGridViewWithFooter1.FirstRowInsertionEnabled = True
        Me.CDataGridViewWithFooter1.IgnoreCase = False
        Me.CDataGridViewWithFooter1.IsDirty = False
        Me.CDataGridViewWithFooter1.Location = New System.Drawing.Point(0, 353)
        Me.CDataGridViewWithFooter1.Name = "CDataGridViewWithFooter1"
        Me.CDataGridViewWithFooter1.Searchable = True
        Me.CDataGridViewWithFooter1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.CDataGridViewWithFooter1.SecurityKey = ""
        Me.CDataGridViewWithFooter1.SequenceColumn = "dgvSequence"
        Me.CDataGridViewWithFooter1.SequenceFieldName = "Sequence"
        Me.CDataGridViewWithFooter1.ShowFooter = False
        Me.CDataGridViewWithFooter1.Size = New System.Drawing.Size(21, 8)
        Me.CDataGridViewWithFooter1.TabIndex = 9
        Me.CDataGridViewWithFooter1.Translatable = True
        '
        'CFindForm
        '
        Me.AcceptButton = Me.BtnFind
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(357, 353)
        Me.Controls.Add(Me.CDataGridViewWithFooter1)
        Me.Controls.Add(Me.txtFieldToSearch)
        Me.Controls.Add(Me.CLabel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CFindForm"
        Me.Text = "Search Record Form"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.cgbStringFindOption.ResumeLayout(False)
        Me.cgbStringFindOption.PerformLayout()
        CType(Me.CDataGridViewWithFooter1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub

    Friend WithEvents TxtTextToSearch As TextBox
    Friend WithEvents lblLookFor1 As Label
    Friend WithEvents RBtnStart As RadioButton
    Friend WithEvents RBtnAnywhere As RadioButton
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Public WithEvents cboTextToSearch As CaComboBox
    Friend WithEvents lblTo1 As Label
    Friend WithEvents chkChecked As UcCheckBox
    Friend WithEvents dtpEndDate As CCustomDateTimePicker
    Friend WithEvents dtpBegDate As CCustomDateTimePicker
    Friend WithEvents RBtnExactMatch As RadioButton
    Friend WithEvents cgbStringFindOption As CGroupBox
    Friend WithEvents txtEndValue As TextBox
    Friend WithEvents txtBegValue As TextBox
    Friend WithEvents CLabel1 As CLabel
    Friend WithEvents txtFieldToSearch As CLabel
    Friend WithEvents chkIgnoreCase As UcCheckBox
    Friend WithEvents lblIgnoreCase As Label
    Friend WithEvents BtnCancel As Button
    Friend WithEvents BtnFind As Button
    Friend WithEvents cbtTextToSearch As CtComboBox
    Friend WithEvents CDataGridViewWithFooter1 As cDataGridViewWithFooter
End Class
