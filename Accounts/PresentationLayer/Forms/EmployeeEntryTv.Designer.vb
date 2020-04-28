Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EmployeeEntryTv
        Inherits CFormEntryTv

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeEntryTv))
            Me.floMainDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblDepartmentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacDepartmentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblDesignationIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacDesignationIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblHiredDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpHiredDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblReleasedDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpReleasedDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblArAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacArAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblBankIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacBankIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblBankAccountNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtBankAccountNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIban = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtIban = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblOpeningBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtOpeningBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNationalIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNationalIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEmployeeName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEmployeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEmployeeNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEmployeeNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.lblGender = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblBirthDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpBirthDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblMaritalStatus = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacMaritalStatus = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblNationalityCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacNationalityCode = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacReligionIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.groupBoxContactInfo = New AATM.Libraries.CBaseControlsLibrary.CGroupBox()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblPhone1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPhone1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPhone2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPhone2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEmail = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEmail = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.groupBoxAddress = New AATM.Libraries.CBaseControlsLibrary.CGroupBox()
            Me.floAddress = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblStreet = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtStreet = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDistrict = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDistrict = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTownCity = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtTownCity = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblProvinceState = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtProvinceState = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCountryCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacCountryCode = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPoBox = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPoBox = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblZipCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtZipCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.EmployeeTabControl = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tbpPersonal = New AATM.Libraries.CBaseControlsLibrary.CTabPage()
            Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.cacGender = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.tbpContact = New AATM.Libraries.CBaseControlsLibrary.CTabPage()
            Me.tbpOthers = New AATM.Libraries.CBaseControlsLibrary.CTabPage()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEmployeeCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEmployeeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.EmployeeModelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floMainDisplay.SuspendLayout()
            Me.groupBoxContactInfo.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.groupBoxAddress.SuspendLayout()
            Me.floAddress.SuspendLayout()
            Me.EmployeeTabControl.SuspendLayout()
            Me.tbpPersonal.SuspendLayout()
            Me.CFlowLayout3.SuspendLayout()
            Me.tbpContact.SuspendLayout()
            Me.tbpOthers.SuspendLayout()
            CType(Me.EmployeeModelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.CFlowLayout4.SuspendLayout()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            Me.TreeViewTableName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.TreeViewTableName.Dock = System.Windows.Forms.DockStyle.Left
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            Me.TreeViewTableName.Location = New System.Drawing.Point(0, 53)
            Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.TreeViewTableName.Size = New System.Drawing.Size(300, 418)
            '
            'floMainDisplay
            '
            Me.floMainDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floMainDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floMainDisplay.Controls.Add(Me.lblDepartmentIdNo)
            Me.floMainDisplay.Controls.Add(Me.cacDepartmentIdNo)
            Me.floMainDisplay.Controls.Add(Me.lblDesignationIdNo)
            Me.floMainDisplay.Controls.Add(Me.cacDesignationIdNo)
            Me.floMainDisplay.Controls.Add(Me.lblHiredDate)
            Me.floMainDisplay.Controls.Add(Me.dtpHiredDate)
            Me.floMainDisplay.Controls.Add(Me.lblReleasedDate)
            Me.floMainDisplay.Controls.Add(Me.dtpReleasedDate)
            Me.floMainDisplay.Controls.Add(Me.lblArAccountIdNo)
            Me.floMainDisplay.Controls.Add(Me.cacArAccountIdNo)
            Me.floMainDisplay.Controls.Add(Me.lblBankIdNo)
            Me.floMainDisplay.Controls.Add(Me.cacBankIdNo)
            Me.floMainDisplay.Controls.Add(Me.lblBankAccountNo)
            Me.floMainDisplay.Controls.Add(Me.txtBankAccountNo)
            Me.floMainDisplay.Controls.Add(Me.lblIban)
            Me.floMainDisplay.Controls.Add(Me.txtIban)
            Me.floMainDisplay.Controls.Add(Me.lblOpeningBalance)
            Me.floMainDisplay.Controls.Add(Me.txtOpeningBalance)
            Me.floMainDisplay.Controls.Add(Me.lblBalance)
            Me.floMainDisplay.Controls.Add(Me.txtBalance)
            Me.floMainDisplay.Controls.Add(Me.lblNationalIdNo)
            Me.floMainDisplay.Controls.Add(Me.txtNationalIdNo)
            Me.floMainDisplay.Controls.Add(Me.lblActive)
            Me.floMainDisplay.Controls.Add(Me.chkActive)
            Me.floMainDisplay.Controls.Add(Me.lblNotes)
            Me.floMainDisplay.Controls.Add(Me.txtNotes)
            Me.floMainDisplay.Location = New System.Drawing.Point(2, 2)
            Me.floMainDisplay.Margin = New System.Windows.Forms.Padding(0)
            Me.floMainDisplay.MinimumSize = New System.Drawing.Size(430, 180)
            Me.floMainDisplay.Name = "floMainDisplay"
            Me.floMainDisplay.Size = New System.Drawing.Size(812, 260)
            Me.floMainDisplay.TabIndex = 3
            '
            'lblDepartmentIdNo
            '
            Me.lblDepartmentIdNo.DisplayOnly = True
            Me.lblDepartmentIdNo.EditingMode = False
            Me.lblDepartmentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDepartmentIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDepartmentIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblDepartmentIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDepartmentIdNo.Name = "lblDepartmentIdNo"
            Me.lblDepartmentIdNo.Size = New System.Drawing.Size(174, 24)
            Me.lblDepartmentIdNo.TabIndex = 253
            Me.lblDepartmentIdNo.Text = "Department"
            Me.lblDepartmentIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cacDepartmentIdNo
            '
            Me.cacDepartmentIdNo.BackColor = System.Drawing.Color.White
            Me.cacDepartmentIdNo.ChangingSearchValueOnly = False
            Me.cacDepartmentIdNo.CurrentSearchTerm = ""
            Me.cacDepartmentIdNo.DefaultValue = Nothing
            Me.cacDepartmentIdNo.DisplayMember = "Name"
            Me.cacDepartmentIdNo.DropDownHeight = 200
            Me.cacDepartmentIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacDepartmentIdNo.EditingMode = False
            Me.cacDepartmentIdNo.FilterRule = Nothing
            Me.cacDepartmentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacDepartmentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacDepartmentIdNo.FormattingEnabled = True
            Me.cacDepartmentIdNo.HideWhenNotEditingOrAdding = False
            Me.cacDepartmentIdNo.LinkedLabel = Me.lblDepartmentIdNo
            Me.cacDepartmentIdNo.Location = New System.Drawing.Point(176, 1)
            Me.cacDepartmentIdNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacDepartmentIdNo.Name = "cacDepartmentIdNo"
            Me.cacDepartmentIdNo.OldValue = 0
            Me.cacDepartmentIdNo.OriginalDataSource = Nothing
            Me.cacDepartmentIdNo.OriginalList = Nothing
            Me.cacDepartmentIdNo.OverrideDropDownStyleList = False
            Me.cacDepartmentIdNo.PreviousSearchTerm = Nothing
            Me.cacDepartmentIdNo.PreviousSelectedIndex = -1
            Me.cacDepartmentIdNo.PropertySelector = Nothing
            Me.cacDepartmentIdNo.ReadOnlyCombo = False
            Me.cacDepartmentIdNo.SearchAnywhere = False
            Me.cacDepartmentIdNo.Size = New System.Drawing.Size(279, 24)
            Me.cacDepartmentIdNo.SuggestBoxHeight = 200
            Me.cacDepartmentIdNo.SuggestListOrderRule = Nothing
            Me.cacDepartmentIdNo.TabIndex = 19
            Me.cacDepartmentIdNo.TextToSearch = Nothing
            Me.cacDepartmentIdNo.ValueIsMandatory = False
            Me.cacDepartmentIdNo.ValueIsNullable = False
            Me.cacDepartmentIdNo.ValueIsNumeric = False
            Me.cacDepartmentIdNo.ValueMember = "IdNo"
            '
            'lblDesignationIdNo
            '
            Me.lblDesignationIdNo.DisplayOnly = True
            Me.lblDesignationIdNo.EditingMode = False
            Me.lblDesignationIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDesignationIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDesignationIdNo.Location = New System.Drawing.Point(456, 1)
            Me.lblDesignationIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDesignationIdNo.Name = "lblDesignationIdNo"
            Me.lblDesignationIdNo.Size = New System.Drawing.Size(116, 24)
            Me.lblDesignationIdNo.TabIndex = 254
            Me.lblDesignationIdNo.Text = "Designation"
            Me.lblDesignationIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cacDesignationIdNo
            '
            Me.cacDesignationIdNo.BackColor = System.Drawing.Color.White
            Me.cacDesignationIdNo.ChangingSearchValueOnly = False
            Me.cacDesignationIdNo.CurrentSearchTerm = ""
            Me.cacDesignationIdNo.DefaultValue = Nothing
            Me.cacDesignationIdNo.DisplayMember = "Name"
            Me.cacDesignationIdNo.DropDownHeight = 200
            Me.cacDesignationIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacDesignationIdNo.EditingMode = False
            Me.cacDesignationIdNo.FilterRule = Nothing
            Me.floMainDisplay.SetFlowBreak(Me.cacDesignationIdNo, True)
            Me.cacDesignationIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacDesignationIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacDesignationIdNo.FormattingEnabled = True
            Me.cacDesignationIdNo.HideWhenNotEditingOrAdding = False
            Me.cacDesignationIdNo.LinkedLabel = Me.lblDesignationIdNo
            Me.cacDesignationIdNo.Location = New System.Drawing.Point(573, 1)
            Me.cacDesignationIdNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacDesignationIdNo.Name = "cacDesignationIdNo"
            Me.cacDesignationIdNo.OldValue = 0
            Me.cacDesignationIdNo.OriginalDataSource = Nothing
            Me.cacDesignationIdNo.OriginalList = Nothing
            Me.cacDesignationIdNo.OverrideDropDownStyleList = False
            Me.cacDesignationIdNo.PreviousSearchTerm = Nothing
            Me.cacDesignationIdNo.PreviousSelectedIndex = -1
            Me.cacDesignationIdNo.PropertySelector = Nothing
            Me.cacDesignationIdNo.ReadOnlyCombo = False
            Me.cacDesignationIdNo.SearchAnywhere = False
            Me.cacDesignationIdNo.Size = New System.Drawing.Size(223, 24)
            Me.cacDesignationIdNo.SuggestBoxHeight = 200
            Me.cacDesignationIdNo.SuggestListOrderRule = Nothing
            Me.cacDesignationIdNo.TabIndex = 20
            Me.cacDesignationIdNo.TextToSearch = Nothing
            Me.cacDesignationIdNo.ValueIsMandatory = False
            Me.cacDesignationIdNo.ValueIsNullable = False
            Me.cacDesignationIdNo.ValueIsNumeric = False
            Me.cacDesignationIdNo.ValueMember = "IdNo"
            '
            'lblHiredDate
            '
            Me.lblHiredDate.DisplayOnly = True
            Me.lblHiredDate.EditingMode = False
            Me.lblHiredDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblHiredDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblHiredDate.Location = New System.Drawing.Point(1, 27)
            Me.lblHiredDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblHiredDate.Name = "lblHiredDate"
            Me.lblHiredDate.Size = New System.Drawing.Size(174, 24)
            Me.lblHiredDate.TabIndex = 255
            Me.lblHiredDate.Text = "Hired Date"
            Me.lblHiredDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dtpHiredDate
            '
            Me.dtpHiredDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpHiredDate.DefaultValue = Nothing
            Me.dtpHiredDate.DisplayOnly = False
            Me.dtpHiredDate.DtpDefaultValue = Nothing
            Me.dtpHiredDate.EditingMode = False
            Me.dtpHiredDate.EditsAllowed = False
            Me.dtpHiredDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpHiredDate.ForeColor = System.Drawing.Color.Black
            Me.dtpHiredDate.LinkedLabel = Me.lblHiredDate
            Me.dtpHiredDate.Location = New System.Drawing.Point(176, 26)
            Me.dtpHiredDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpHiredDate.Name = "dtpHiredDate"
            Me.dtpHiredDate.ReadOnlyDp = False
            Me.dtpHiredDate.SecurityKey = Nothing
            Me.dtpHiredDate.ShowLongDate = False
            Me.dtpHiredDate.ShowTime = False
            Me.dtpHiredDate.Size = New System.Drawing.Size(123, 24)
            Me.dtpHiredDate.TabIndex = 21
            Me.dtpHiredDate.TargetCalendar = CType(resources.GetObject("dtpHiredDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpHiredDate.Value = Nothing
            Me.dtpHiredDate.ValueIsMandatory = False
            Me.dtpHiredDate.ValueIsNullable = False
            '
            'lblReleasedDate
            '
            Me.lblReleasedDate.DisplayOnly = True
            Me.lblReleasedDate.EditingMode = False
            Me.lblReleasedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReleasedDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReleasedDate.Location = New System.Drawing.Point(300, 27)
            Me.lblReleasedDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReleasedDate.Name = "lblReleasedDate"
            Me.lblReleasedDate.Size = New System.Drawing.Size(273, 24)
            Me.lblReleasedDate.TabIndex = 257
            Me.lblReleasedDate.Text = "Released Date"
            Me.lblReleasedDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpReleasedDate
            '
            Me.dtpReleasedDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpReleasedDate.DefaultValue = Nothing
            Me.dtpReleasedDate.DisplayOnly = False
            Me.dtpReleasedDate.DtpDefaultValue = Nothing
            Me.dtpReleasedDate.EditingMode = False
            Me.dtpReleasedDate.EditsAllowed = False
            Me.floMainDisplay.SetFlowBreak(Me.dtpReleasedDate, True)
            Me.dtpReleasedDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpReleasedDate.ForeColor = System.Drawing.Color.Black
            Me.dtpReleasedDate.LinkedLabel = Me.lblReleasedDate
            Me.dtpReleasedDate.Location = New System.Drawing.Point(574, 26)
            Me.dtpReleasedDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpReleasedDate.Name = "dtpReleasedDate"
            Me.dtpReleasedDate.ReadOnlyDp = False
            Me.dtpReleasedDate.SecurityKey = Nothing
            Me.dtpReleasedDate.ShowLongDate = False
            Me.dtpReleasedDate.ShowTime = False
            Me.dtpReleasedDate.Size = New System.Drawing.Size(123, 24)
            Me.dtpReleasedDate.TabIndex = 22
            Me.dtpReleasedDate.TargetCalendar = CType(resources.GetObject("dtpReleasedDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpReleasedDate.Value = Nothing
            Me.dtpReleasedDate.ValueIsMandatory = False
            Me.dtpReleasedDate.ValueIsNullable = False
            '
            'lblArAccountIdNo
            '
            Me.lblArAccountIdNo.DisplayOnly = True
            Me.lblArAccountIdNo.EditingMode = False
            Me.lblArAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblArAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblArAccountIdNo.Location = New System.Drawing.Point(1, 53)
            Me.lblArAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblArAccountIdNo.Name = "lblArAccountIdNo"
            Me.lblArAccountIdNo.Size = New System.Drawing.Size(174, 23)
            Me.lblArAccountIdNo.TabIndex = 234
            Me.lblArAccountIdNo.Text = "Override AR Account"
            Me.lblArAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cacArAccountIdNo
            '
            Me.cacArAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cacArAccountIdNo.ChangingSearchValueOnly = False
            Me.cacArAccountIdNo.CurrentSearchTerm = ""
            Me.cacArAccountIdNo.DefaultValue = Nothing
            Me.cacArAccountIdNo.DisplayMember = "Name"
            Me.cacArAccountIdNo.DropDownHeight = 200
            Me.cacArAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacArAccountIdNo.EditingMode = False
            Me.cacArAccountIdNo.FilterRule = Nothing
            Me.floMainDisplay.SetFlowBreak(Me.cacArAccountIdNo, True)
            Me.cacArAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacArAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacArAccountIdNo.FormattingEnabled = True
            Me.cacArAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cacArAccountIdNo.LinkedLabel = Me.lblArAccountIdNo
            Me.cacArAccountIdNo.Location = New System.Drawing.Point(176, 53)
            Me.cacArAccountIdNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacArAccountIdNo.Name = "cacArAccountIdNo"
            Me.cacArAccountIdNo.OldValue = 0
            Me.cacArAccountIdNo.OriginalDataSource = Nothing
            Me.cacArAccountIdNo.OriginalList = Nothing
            Me.cacArAccountIdNo.OverrideDropDownStyleList = False
            Me.cacArAccountIdNo.PreviousSearchTerm = Nothing
            Me.cacArAccountIdNo.PreviousSelectedIndex = -1
            Me.cacArAccountIdNo.PropertySelector = Nothing
            Me.cacArAccountIdNo.ReadOnlyCombo = False
            Me.cacArAccountIdNo.SearchAnywhere = False
            Me.cacArAccountIdNo.Size = New System.Drawing.Size(621, 24)
            Me.cacArAccountIdNo.SuggestBoxHeight = 200
            Me.cacArAccountIdNo.SuggestListOrderRule = Nothing
            Me.cacArAccountIdNo.TabIndex = 23
            Me.cacArAccountIdNo.TextToSearch = Nothing
            Me.cacArAccountIdNo.ValueIsMandatory = False
            Me.cacArAccountIdNo.ValueIsNullable = False
            Me.cacArAccountIdNo.ValueIsNumeric = False
            Me.cacArAccountIdNo.ValueMember = "IdNo"
            '
            'lblBankIdNo
            '
            Me.lblBankIdNo.DisplayOnly = True
            Me.lblBankIdNo.EditingMode = False
            Me.lblBankIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBankIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblBankIdNo.Location = New System.Drawing.Point(1, 79)
            Me.lblBankIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBankIdNo.Name = "lblBankIdNo"
            Me.lblBankIdNo.Size = New System.Drawing.Size(174, 23)
            Me.lblBankIdNo.TabIndex = 216
            Me.lblBankIdNo.Text = "Bank Name"
            Me.lblBankIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cacBankIdNo
            '
            Me.cacBankIdNo.BackColor = System.Drawing.Color.White
            Me.cacBankIdNo.ChangingSearchValueOnly = False
            Me.cacBankIdNo.CurrentSearchTerm = ""
            Me.cacBankIdNo.DefaultValue = Nothing
            Me.cacBankIdNo.DisplayMember = "Name"
            Me.cacBankIdNo.DropDownHeight = 200
            Me.cacBankIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacBankIdNo.EditingMode = False
            Me.cacBankIdNo.FilterRule = Nothing
            Me.cacBankIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacBankIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacBankIdNo.FormattingEnabled = True
            Me.cacBankIdNo.HideWhenNotEditingOrAdding = False
            Me.cacBankIdNo.LinkedLabel = Me.lblBankIdNo
            Me.cacBankIdNo.Location = New System.Drawing.Point(176, 79)
            Me.cacBankIdNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacBankIdNo.Name = "cacBankIdNo"
            Me.cacBankIdNo.OldValue = 0
            Me.cacBankIdNo.OriginalDataSource = Nothing
            Me.cacBankIdNo.OriginalList = Nothing
            Me.cacBankIdNo.OverrideDropDownStyleList = False
            Me.cacBankIdNo.PreviousSearchTerm = Nothing
            Me.cacBankIdNo.PreviousSelectedIndex = -1
            Me.cacBankIdNo.PropertySelector = Nothing
            Me.cacBankIdNo.ReadOnlyCombo = False
            Me.cacBankIdNo.SearchAnywhere = False
            Me.cacBankIdNo.Size = New System.Drawing.Size(279, 24)
            Me.cacBankIdNo.SuggestBoxHeight = 200
            Me.cacBankIdNo.SuggestListOrderRule = Nothing
            Me.cacBankIdNo.TabIndex = 24
            Me.cacBankIdNo.TextToSearch = Nothing
            Me.cacBankIdNo.ValueIsMandatory = False
            Me.cacBankIdNo.ValueIsNullable = False
            Me.cacBankIdNo.ValueIsNumeric = False
            Me.cacBankIdNo.ValueMember = "IdNo"
            '
            'lblBankAccountNo
            '
            Me.lblBankAccountNo.DisplayOnly = True
            Me.lblBankAccountNo.EditingMode = False
            Me.lblBankAccountNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBankAccountNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblBankAccountNo.Location = New System.Drawing.Point(456, 79)
            Me.lblBankAccountNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBankAccountNo.Name = "lblBankAccountNo"
            Me.lblBankAccountNo.Size = New System.Drawing.Size(116, 23)
            Me.lblBankAccountNo.TabIndex = 218
            Me.lblBankAccountNo.Text = "Account No."
            Me.lblBankAccountNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBankAccountNo
            '
            Me.txtBankAccountNo.BackColor = System.Drawing.Color.White
            Me.txtBankAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBankAccountNo.ComputedValue = False
            Me.txtBankAccountNo.CustomFormat = Nothing
            Me.txtBankAccountNo.DataBoundControl = True
            Me.txtBankAccountNo.EditingMode = False
            Me.floMainDisplay.SetFlowBreak(Me.txtBankAccountNo, True)
            Me.txtBankAccountNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtBankAccountNo.ForeColor = System.Drawing.Color.Black
            Me.txtBankAccountNo.LinkedLabel = Me.lblBankAccountNo
            Me.txtBankAccountNo.Location = New System.Drawing.Point(574, 79)
            Me.txtBankAccountNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtBankAccountNo.Name = "txtBankAccountNo"
            Me.txtBankAccountNo.OldValue = Nothing
            Me.txtBankAccountNo.Size = New System.Drawing.Size(222, 23)
            Me.txtBankAccountNo.TabIndex = 25
            '
            'lblIban
            '
            Me.lblIban.DisplayOnly = True
            Me.lblIban.EditingMode = False
            Me.lblIban.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIban.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIban.Location = New System.Drawing.Point(1, 105)
            Me.lblIban.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIban.Name = "lblIban"
            Me.lblIban.Size = New System.Drawing.Size(174, 23)
            Me.lblIban.TabIndex = 220
            Me.lblIban.Text = "IBAN Number"
            Me.lblIban.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtIban
            '
            Me.txtIban.BackColor = System.Drawing.Color.White
            Me.txtIban.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIban.ComputedValue = False
            Me.txtIban.CustomFormat = Nothing
            Me.txtIban.DataBoundControl = True
            Me.txtIban.EditingMode = False
            Me.floMainDisplay.SetFlowBreak(Me.txtIban, True)
            Me.txtIban.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtIban.ForeColor = System.Drawing.Color.Black
            Me.txtIban.LinkedLabel = Me.lblIban
            Me.txtIban.Location = New System.Drawing.Point(177, 105)
            Me.txtIban.Margin = New System.Windows.Forms.Padding(1)
            Me.txtIban.Name = "txtIban"
            Me.txtIban.OldValue = Nothing
            Me.txtIban.Size = New System.Drawing.Size(200, 23)
            Me.txtIban.TabIndex = 26
            '
            'lblOpeningBalance
            '
            Me.lblOpeningBalance.DisplayOnly = True
            Me.lblOpeningBalance.EditingMode = False
            Me.lblOpeningBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblOpeningBalance.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblOpeningBalance.Location = New System.Drawing.Point(1, 130)
            Me.lblOpeningBalance.Margin = New System.Windows.Forms.Padding(1)
            Me.lblOpeningBalance.Name = "lblOpeningBalance"
            Me.lblOpeningBalance.Size = New System.Drawing.Size(174, 23)
            Me.lblOpeningBalance.TabIndex = 30
            Me.lblOpeningBalance.Text = "Opening Balance"
            Me.lblOpeningBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtOpeningBalance
            '
            Me.txtOpeningBalance.BackColor = System.Drawing.Color.White
            Me.txtOpeningBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOpeningBalance.ComputedValue = False
            Me.txtOpeningBalance.CustomFormat = Nothing
            Me.txtOpeningBalance.DataBoundControl = True
            Me.txtOpeningBalance.EditingMode = False
            Me.txtOpeningBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtOpeningBalance.ForeColor = System.Drawing.Color.Black
            Me.txtOpeningBalance.LinkedLabel = Me.lblOpeningBalance
            Me.txtOpeningBalance.Location = New System.Drawing.Point(177, 130)
            Me.txtOpeningBalance.Margin = New System.Windows.Forms.Padding(1)
            Me.txtOpeningBalance.Name = "txtOpeningBalance"
            Me.txtOpeningBalance.OldValue = Nothing
            Me.txtOpeningBalance.Size = New System.Drawing.Size(200, 23)
            Me.txtOpeningBalance.TabIndex = 27
            '
            'lblBalance
            '
            Me.lblBalance.DisplayOnly = True
            Me.lblBalance.EditingMode = False
            Me.lblBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBalance.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblBalance.Location = New System.Drawing.Point(379, 130)
            Me.lblBalance.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBalance.Name = "lblBalance"
            Me.lblBalance.Size = New System.Drawing.Size(194, 23)
            Me.lblBalance.TabIndex = 259
            Me.lblBalance.Text = "Balance"
            Me.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBalance
            '
            Me.txtBalance.BackColor = System.Drawing.Color.White
            Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBalance.ComputedValue = False
            Me.txtBalance.CustomFormat = Nothing
            Me.txtBalance.DataBoundControl = True
            Me.txtBalance.EditingMode = False
            Me.floMainDisplay.SetFlowBreak(Me.txtBalance, True)
            Me.txtBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtBalance.ForeColor = System.Drawing.Color.Black
            Me.txtBalance.LinkedLabel = Me.lblBalance
            Me.txtBalance.Location = New System.Drawing.Point(575, 130)
            Me.txtBalance.Margin = New System.Windows.Forms.Padding(1)
            Me.txtBalance.Name = "txtBalance"
            Me.txtBalance.OldValue = Nothing
            Me.txtBalance.Size = New System.Drawing.Size(222, 23)
            Me.txtBalance.TabIndex = 28
            '
            'lblNationalIdNo
            '
            Me.lblNationalIdNo.DisplayOnly = True
            Me.lblNationalIdNo.EditingMode = False
            Me.lblNationalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNationalIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNationalIdNo.Location = New System.Drawing.Point(1, 155)
            Me.lblNationalIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNationalIdNo.Name = "lblNationalIdNo"
            Me.lblNationalIdNo.Size = New System.Drawing.Size(174, 23)
            Me.lblNationalIdNo.TabIndex = 261
            Me.lblNationalIdNo.Text = "National ID/Iqama #"
            Me.lblNationalIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtNationalIdNo
            '
            Me.txtNationalIdNo.BackColor = System.Drawing.Color.White
            Me.txtNationalIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNationalIdNo.ComputedValue = False
            Me.txtNationalIdNo.CustomFormat = Nothing
            Me.txtNationalIdNo.DataBoundControl = True
            Me.txtNationalIdNo.EditingMode = False
            Me.txtNationalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNationalIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtNationalIdNo.LinkedLabel = Me.lblNationalIdNo
            Me.txtNationalIdNo.Location = New System.Drawing.Point(177, 155)
            Me.txtNationalIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNationalIdNo.Name = "txtNationalIdNo"
            Me.txtNationalIdNo.OldValue = Nothing
            Me.txtNationalIdNo.Size = New System.Drawing.Size(200, 23)
            Me.txtNationalIdNo.TabIndex = 29
            '
            'lblActive
            '
            Me.lblActive.DisplayOnly = True
            Me.lblActive.EditingMode = False
            Me.lblActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblActive.Location = New System.Drawing.Point(379, 155)
            Me.lblActive.Margin = New System.Windows.Forms.Padding(1)
            Me.lblActive.Name = "lblActive"
            Me.lblActive.Size = New System.Drawing.Size(194, 24)
            Me.lblActive.TabIndex = 241
            Me.lblActive.Text = "Active?"
            Me.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkActive
            '
            Me.chkActive.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkActive.BackColor = System.Drawing.Color.White
            Me.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkActive.DisplayOnly = False
            Me.chkActive.EditingMode = False
            Me.chkActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.floMainDisplay.SetFlowBreak(Me.chkActive, True)
            Me.chkActive.ForeColor = System.Drawing.Color.Black
            Me.chkActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkActive.LinkedLabel = Me.lblActive
            Me.chkActive.Location = New System.Drawing.Point(575, 155)
            Me.chkActive.Margin = New System.Windows.Forms.Padding(1)
            Me.chkActive.Name = "chkActive"
            Me.chkActive.Size = New System.Drawing.Size(25, 21)
            Me.chkActive.TabIndex = 30
            Me.chkActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkActive.UseVisualStyleBackColor = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNotes.Location = New System.Drawing.Point(1, 181)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(174, 23)
            Me.lblNotes.TabIndex = 159
            Me.lblNotes.Text = "Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Me.lblNotes
            Me.txtNotes.Location = New System.Drawing.Point(177, 181)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.Size = New System.Drawing.Size(620, 60)
            Me.txtNotes.TabIndex = 35
            Me.txtNotes.ValueIsMandatory = True
            '
            'lblEmployeeName
            '
            Me.lblEmployeeName.DisplayOnly = True
            Me.lblEmployeeName.EditingMode = False
            Me.lblEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEmployeeName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblEmployeeName.Location = New System.Drawing.Point(1, 26)
            Me.lblEmployeeName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEmployeeName.Name = "lblEmployeeName"
            Me.lblEmployeeName.Size = New System.Drawing.Size(183, 23)
            Me.lblEmployeeName.TabIndex = 210
            Me.lblEmployeeName.Text = "Employee Name"
            Me.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtEmployeeName
            '
            Me.txtEmployeeName.BackColor = System.Drawing.Color.White
            Me.txtEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmployeeName.ComputedValue = False
            Me.txtEmployeeName.CustomFormat = Nothing
            Me.txtEmployeeName.DataBoundControl = True
            Me.txtEmployeeName.EditingMode = False
            Me.CFlowLayout4.SetFlowBreak(Me.txtEmployeeName, True)
            Me.txtEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmployeeName.ForeColor = System.Drawing.Color.Black
            Me.txtEmployeeName.LinkedLabel = Me.lblEmployeeName
            Me.txtEmployeeName.Location = New System.Drawing.Point(186, 26)
            Me.txtEmployeeName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeName.Name = "txtEmployeeName"
            Me.txtEmployeeName.OldValue = Nothing
            Me.txtEmployeeName.Size = New System.Drawing.Size(620, 23)
            Me.txtEmployeeName.TabIndex = 2
            Me.txtEmployeeName.ValueIsMandatory = True
            '
            'lblEmployeeNameAra
            '
            Me.lblEmployeeNameAra.DisplayOnly = True
            Me.lblEmployeeNameAra.EditingMode = False
            Me.lblEmployeeNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEmployeeNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblEmployeeNameAra.Location = New System.Drawing.Point(1, 51)
            Me.lblEmployeeNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEmployeeNameAra.Name = "lblEmployeeNameAra"
            Me.lblEmployeeNameAra.Size = New System.Drawing.Size(183, 23)
            Me.lblEmployeeNameAra.TabIndex = 212
            Me.lblEmployeeNameAra.Text = "Employee Name (Arabic)"
            Me.lblEmployeeNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtEmployeeNameAra
            '
            Me.txtEmployeeNameAra.BackColor = System.Drawing.Color.White
            Me.txtEmployeeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmployeeNameAra.ComputedValue = False
            Me.txtEmployeeNameAra.CustomFormat = Nothing
            Me.txtEmployeeNameAra.DataBoundControl = True
            Me.txtEmployeeNameAra.EditingMode = False
            Me.txtEmployeeNameAra.EnglishControl = Me.txtEmployeeName
            Me.CFlowLayout4.SetFlowBreak(Me.txtEmployeeNameAra, True)
            Me.txtEmployeeNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmployeeNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtEmployeeNameAra.LinkedLabel = Me.lblEmployeeNameAra
            Me.txtEmployeeNameAra.Location = New System.Drawing.Point(186, 51)
            Me.txtEmployeeNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeNameAra.Name = "txtEmployeeNameAra"
            Me.txtEmployeeNameAra.OldValue = Nothing
            Me.txtEmployeeNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtEmployeeNameAra.Size = New System.Drawing.Size(620, 23)
            Me.txtEmployeeNameAra.TabIndex = 3
            Me.txtEmployeeNameAra.ValueIsMandatory = True
            '
            'lblGender
            '
            Me.lblGender.DisplayOnly = True
            Me.lblGender.EditingMode = False
            Me.lblGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblGender.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblGender.Location = New System.Drawing.Point(1, 1)
            Me.lblGender.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGender.Name = "lblGender"
            Me.lblGender.Size = New System.Drawing.Size(174, 23)
            Me.lblGender.TabIndex = 183
            Me.lblGender.Text = "Gender"
            Me.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBirthDate
            '
            Me.lblBirthDate.DisplayOnly = True
            Me.lblBirthDate.EditingMode = False
            Me.lblBirthDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBirthDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblBirthDate.Location = New System.Drawing.Point(1, 105)
            Me.lblBirthDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBirthDate.Name = "lblBirthDate"
            Me.lblBirthDate.Size = New System.Drawing.Size(175, 23)
            Me.lblBirthDate.TabIndex = 185
            Me.lblBirthDate.Text = "Date of Birth"
            Me.lblBirthDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dtpBirthDate
            '
            Me.dtpBirthDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpBirthDate.DefaultValue = Nothing
            Me.dtpBirthDate.DisplayOnly = False
            Me.dtpBirthDate.DtpDefaultValue = Nothing
            Me.dtpBirthDate.EditingMode = False
            Me.dtpBirthDate.EditsAllowed = False
            Me.CFlowLayout3.SetFlowBreak(Me.dtpBirthDate, True)
            Me.dtpBirthDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpBirthDate.ForeColor = System.Drawing.Color.Black
            Me.dtpBirthDate.LinkedLabel = Me.lblBirthDate
            Me.dtpBirthDate.Location = New System.Drawing.Point(177, 104)
            Me.dtpBirthDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpBirthDate.Name = "dtpBirthDate"
            Me.dtpBirthDate.ReadOnlyDp = False
            Me.dtpBirthDate.SecurityKey = Nothing
            Me.dtpBirthDate.ShowLongDate = False
            Me.dtpBirthDate.ShowTime = False
            Me.dtpBirthDate.Size = New System.Drawing.Size(123, 24)
            Me.dtpBirthDate.TabIndex = 5
            Me.dtpBirthDate.TargetCalendar = CType(resources.GetObject("dtpBirthDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpBirthDate.Value = Nothing
            Me.dtpBirthDate.ValueIsMandatory = False
            Me.dtpBirthDate.ValueIsNullable = False
            '
            'lblMaritalStatus
            '
            Me.lblMaritalStatus.DisplayOnly = True
            Me.lblMaritalStatus.EditingMode = False
            Me.lblMaritalStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblMaritalStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblMaritalStatus.Location = New System.Drawing.Point(1, 27)
            Me.lblMaritalStatus.Margin = New System.Windows.Forms.Padding(1)
            Me.lblMaritalStatus.Name = "lblMaritalStatus"
            Me.lblMaritalStatus.Size = New System.Drawing.Size(175, 23)
            Me.lblMaritalStatus.TabIndex = 244
            Me.lblMaritalStatus.Text = "Marital Status"
            Me.lblMaritalStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cacMaritalStatus
            '
            Me.cacMaritalStatus.BackColor = System.Drawing.Color.White
            Me.cacMaritalStatus.ChangingSearchValueOnly = False
            Me.cacMaritalStatus.CurrentSearchTerm = ""
            Me.cacMaritalStatus.DefaultValue = Nothing
            Me.cacMaritalStatus.DisplayMember = "Name"
            Me.cacMaritalStatus.DropDownHeight = 200
            Me.cacMaritalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacMaritalStatus.EditingMode = False
            Me.cacMaritalStatus.FilterRule = Nothing
            Me.CFlowLayout3.SetFlowBreak(Me.cacMaritalStatus, True)
            Me.cacMaritalStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacMaritalStatus.ForeColor = System.Drawing.Color.Black
            Me.cacMaritalStatus.FormattingEnabled = True
            Me.cacMaritalStatus.HideWhenNotEditingOrAdding = False
            Me.cacMaritalStatus.LinkedLabel = Me.lblMaritalStatus
            Me.cacMaritalStatus.Location = New System.Drawing.Point(177, 27)
            Me.cacMaritalStatus.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacMaritalStatus.Name = "cacMaritalStatus"
            Me.cacMaritalStatus.OldValue = 0
            Me.cacMaritalStatus.OriginalDataSource = Nothing
            Me.cacMaritalStatus.OriginalList = Nothing
            Me.cacMaritalStatus.OverrideDropDownStyleList = False
            Me.cacMaritalStatus.PreviousSearchTerm = Nothing
            Me.cacMaritalStatus.PreviousSelectedIndex = -1
            Me.cacMaritalStatus.PropertySelector = Nothing
            Me.cacMaritalStatus.ReadOnlyCombo = False
            Me.cacMaritalStatus.SearchAnywhere = False
            Me.cacMaritalStatus.Size = New System.Drawing.Size(278, 24)
            Me.cacMaritalStatus.SuggestBoxHeight = 200
            Me.cacMaritalStatus.SuggestListOrderRule = Nothing
            Me.cacMaritalStatus.TabIndex = 6
            Me.cacMaritalStatus.TextToSearch = Nothing
            Me.cacMaritalStatus.ValueIsMandatory = False
            Me.cacMaritalStatus.ValueIsNullable = False
            Me.cacMaritalStatus.ValueIsNumeric = False
            Me.cacMaritalStatus.ValueMember = "Code"
            '
            'lblNationalityCode
            '
            Me.lblNationalityCode.DisplayOnly = True
            Me.lblNationalityCode.EditingMode = False
            Me.lblNationalityCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNationalityCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNationalityCode.Location = New System.Drawing.Point(1, 53)
            Me.lblNationalityCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNationalityCode.Name = "lblNationalityCode"
            Me.lblNationalityCode.Size = New System.Drawing.Size(174, 24)
            Me.lblNationalityCode.TabIndex = 247
            Me.lblNationalityCode.Text = "Nationality"
            Me.lblNationalityCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cacNationalityCode
            '
            Me.cacNationalityCode.BackColor = System.Drawing.Color.White
            Me.cacNationalityCode.ChangingSearchValueOnly = False
            Me.cacNationalityCode.CurrentSearchTerm = ""
            Me.cacNationalityCode.DefaultValue = Nothing
            Me.cacNationalityCode.DisplayMember = "Name"
            Me.cacNationalityCode.DropDownHeight = 200
            Me.cacNationalityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacNationalityCode.EditingMode = False
            Me.cacNationalityCode.FilterRule = Nothing
            Me.CFlowLayout3.SetFlowBreak(Me.cacNationalityCode, True)
            Me.cacNationalityCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacNationalityCode.ForeColor = System.Drawing.Color.Black
            Me.cacNationalityCode.FormattingEnabled = True
            Me.cacNationalityCode.HideWhenNotEditingOrAdding = False
            Me.cacNationalityCode.LinkedLabel = Me.lblNationalityCode
            Me.cacNationalityCode.Location = New System.Drawing.Point(176, 53)
            Me.cacNationalityCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacNationalityCode.Name = "cacNationalityCode"
            Me.cacNationalityCode.OldValue = 0
            Me.cacNationalityCode.OriginalDataSource = Nothing
            Me.cacNationalityCode.OriginalList = Nothing
            Me.cacNationalityCode.OverrideDropDownStyleList = False
            Me.cacNationalityCode.PreviousSearchTerm = Nothing
            Me.cacNationalityCode.PreviousSelectedIndex = -1
            Me.cacNationalityCode.PropertySelector = Nothing
            Me.cacNationalityCode.ReadOnlyCombo = False
            Me.cacNationalityCode.SearchAnywhere = False
            Me.cacNationalityCode.Size = New System.Drawing.Size(279, 24)
            Me.cacNationalityCode.SuggestBoxHeight = 200
            Me.cacNationalityCode.SuggestListOrderRule = Nothing
            Me.cacNationalityCode.TabIndex = 7
            Me.cacNationalityCode.TextToSearch = Nothing
            Me.cacNationalityCode.ValueIsMandatory = False
            Me.cacNationalityCode.ValueIsNullable = False
            Me.cacNationalityCode.ValueIsNumeric = False
            Me.cacNationalityCode.ValueMember = "Code"
            '
            'CLabel5
            '
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel5.Location = New System.Drawing.Point(1, 79)
            Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel5.Name = "CLabel5"
            Me.CLabel5.Size = New System.Drawing.Size(175, 24)
            Me.CLabel5.TabIndex = 249
            Me.CLabel5.Text = "Religion"
            Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cacReligionIdNo
            '
            Me.cacReligionIdNo.BackColor = System.Drawing.Color.White
            Me.cacReligionIdNo.ChangingSearchValueOnly = False
            Me.cacReligionIdNo.CurrentSearchTerm = ""
            Me.cacReligionIdNo.DefaultValue = Nothing
            Me.cacReligionIdNo.DisplayMember = "Name"
            Me.cacReligionIdNo.DropDownHeight = 200
            Me.cacReligionIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacReligionIdNo.EditingMode = False
            Me.cacReligionIdNo.FilterRule = Nothing
            Me.CFlowLayout3.SetFlowBreak(Me.cacReligionIdNo, True)
            Me.cacReligionIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacReligionIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacReligionIdNo.FormattingEnabled = True
            Me.cacReligionIdNo.HideWhenNotEditingOrAdding = False
            Me.cacReligionIdNo.LinkedLabel = Me.lblNationalityCode
            Me.cacReligionIdNo.Location = New System.Drawing.Point(177, 79)
            Me.cacReligionIdNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacReligionIdNo.Name = "cacReligionIdNo"
            Me.cacReligionIdNo.OldValue = 0
            Me.cacReligionIdNo.OriginalDataSource = Nothing
            Me.cacReligionIdNo.OriginalList = Nothing
            Me.cacReligionIdNo.OverrideDropDownStyleList = False
            Me.cacReligionIdNo.PreviousSearchTerm = Nothing
            Me.cacReligionIdNo.PreviousSelectedIndex = -1
            Me.cacReligionIdNo.PropertySelector = Nothing
            Me.cacReligionIdNo.ReadOnlyCombo = False
            Me.cacReligionIdNo.SearchAnywhere = False
            Me.cacReligionIdNo.Size = New System.Drawing.Size(278, 24)
            Me.cacReligionIdNo.SuggestBoxHeight = 200
            Me.cacReligionIdNo.SuggestListOrderRule = Nothing
            Me.cacReligionIdNo.TabIndex = 8
            Me.cacReligionIdNo.TextToSearch = Nothing
            Me.cacReligionIdNo.ValueIsMandatory = False
            Me.cacReligionIdNo.ValueIsNullable = False
            Me.cacReligionIdNo.ValueIsNumeric = False
            Me.cacReligionIdNo.ValueMember = "IdNo"
            '
            'groupBoxContactInfo
            '
            Me.groupBoxContactInfo.AutoSize = True
            Me.groupBoxContactInfo.BackColor = System.Drawing.Color.Transparent
            Me.groupBoxContactInfo.Controls.Add(Me.CFlowLayout1)
            Me.groupBoxContactInfo.DisplayOnly = True
            Me.groupBoxContactInfo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.groupBoxContactInfo.Location = New System.Drawing.Point(6, 15)
            Me.groupBoxContactInfo.Name = "groupBoxContactInfo"
            Me.groupBoxContactInfo.Size = New System.Drawing.Size(800, 104)
            Me.groupBoxContactInfo.TabIndex = 5
            Me.groupBoxContactInfo.TabStop = False
            Me.groupBoxContactInfo.Text = "Contact Information:"
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblPhone1)
            Me.CFlowLayout1.Controls.Add(Me.txtPhone1)
            Me.CFlowLayout1.Controls.Add(Me.lblPhone2)
            Me.CFlowLayout1.Controls.Add(Me.txtPhone2)
            Me.CFlowLayout1.Controls.Add(Me.lblEmail)
            Me.CFlowLayout1.Controls.Add(Me.txtEmail)
            Me.CFlowLayout1.Location = New System.Drawing.Point(6, 19)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(788, 63)
            Me.CFlowLayout1.TabIndex = 4
            '
            'lblPhone1
            '
            Me.lblPhone1.DisplayOnly = True
            Me.lblPhone1.EditingMode = False
            Me.lblPhone1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPhone1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPhone1.Location = New System.Drawing.Point(1, 1)
            Me.lblPhone1.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPhone1.Name = "lblPhone1"
            Me.lblPhone1.Size = New System.Drawing.Size(165, 23)
            Me.lblPhone1.TabIndex = 201
            Me.lblPhone1.Text = "Main Phone Number"
            Me.lblPhone1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPhone1
            '
            Me.txtPhone1.BackColor = System.Drawing.Color.White
            Me.txtPhone1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPhone1.ComputedValue = False
            Me.txtPhone1.CustomFormat = Nothing
            Me.txtPhone1.DataBoundControl = True
            Me.txtPhone1.EditingMode = False
            Me.txtPhone1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPhone1.ForeColor = System.Drawing.Color.Black
            Me.txtPhone1.LinkedLabel = Me.lblPhone1
            Me.txtPhone1.Location = New System.Drawing.Point(168, 1)
            Me.txtPhone1.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPhone1.Name = "txtPhone1"
            Me.txtPhone1.OldValue = Nothing
            Me.txtPhone1.Size = New System.Drawing.Size(194, 23)
            Me.txtPhone1.TabIndex = 16
            '
            'lblPhone2
            '
            Me.lblPhone2.DisplayOnly = True
            Me.lblPhone2.EditingMode = False
            Me.lblPhone2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPhone2.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPhone2.Location = New System.Drawing.Point(364, 1)
            Me.lblPhone2.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPhone2.Name = "lblPhone2"
            Me.lblPhone2.Size = New System.Drawing.Size(199, 23)
            Me.lblPhone2.TabIndex = 203
            Me.lblPhone2.Text = "Secondary Phone No."
            Me.lblPhone2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPhone2
            '
            Me.txtPhone2.BackColor = System.Drawing.Color.White
            Me.txtPhone2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPhone2.ComputedValue = False
            Me.txtPhone2.CustomFormat = Nothing
            Me.txtPhone2.DataBoundControl = True
            Me.txtPhone2.EditingMode = False
            Me.CFlowLayout1.SetFlowBreak(Me.txtPhone2, True)
            Me.txtPhone2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPhone2.ForeColor = System.Drawing.Color.Black
            Me.txtPhone2.LinkedLabel = Me.lblPhone2
            Me.txtPhone2.Location = New System.Drawing.Point(565, 1)
            Me.txtPhone2.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPhone2.Name = "txtPhone2"
            Me.txtPhone2.OldValue = Nothing
            Me.txtPhone2.Size = New System.Drawing.Size(222, 23)
            Me.txtPhone2.TabIndex = 17
            '
            'lblEmail
            '
            Me.lblEmail.DisplayOnly = True
            Me.lblEmail.EditingMode = False
            Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblEmail.Location = New System.Drawing.Point(1, 26)
            Me.lblEmail.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEmail.Name = "lblEmail"
            Me.lblEmail.Size = New System.Drawing.Size(165, 23)
            Me.lblEmail.TabIndex = 211
            Me.lblEmail.Text = "E-mail Address"
            Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtEmail
            '
            Me.txtEmail.BackColor = System.Drawing.Color.White
            Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmail.ComputedValue = False
            Me.txtEmail.CustomFormat = Nothing
            Me.txtEmail.DataBoundControl = True
            Me.txtEmail.EditingMode = False
            Me.CFlowLayout1.SetFlowBreak(Me.txtEmail, True)
            Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmail.ForeColor = System.Drawing.Color.Black
            Me.txtEmail.LinkedLabel = Me.lblEmail
            Me.txtEmail.Location = New System.Drawing.Point(168, 26)
            Me.txtEmail.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmail.Name = "txtEmail"
            Me.txtEmail.OldValue = Nothing
            Me.txtEmail.Size = New System.Drawing.Size(619, 23)
            Me.txtEmail.TabIndex = 18
            '
            'groupBoxAddress
            '
            Me.groupBoxAddress.AutoSize = True
            Me.groupBoxAddress.BackColor = System.Drawing.Color.Transparent
            Me.groupBoxAddress.Controls.Add(Me.floAddress)
            Me.groupBoxAddress.DisplayOnly = True
            Me.groupBoxAddress.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.groupBoxAddress.Location = New System.Drawing.Point(6, 127)
            Me.groupBoxAddress.Name = "groupBoxAddress"
            Me.groupBoxAddress.Size = New System.Drawing.Size(800, 149)
            Me.groupBoxAddress.TabIndex = 4
            Me.groupBoxAddress.TabStop = False
            Me.groupBoxAddress.Text = "Address"
            '
            'floAddress
            '
            Me.floAddress.BackColor = System.Drawing.Color.Transparent
            Me.floAddress.Controls.Add(Me.lblStreet)
            Me.floAddress.Controls.Add(Me.txtStreet)
            Me.floAddress.Controls.Add(Me.lblDistrict)
            Me.floAddress.Controls.Add(Me.txtDistrict)
            Me.floAddress.Controls.Add(Me.lblTownCity)
            Me.floAddress.Controls.Add(Me.txtTownCity)
            Me.floAddress.Controls.Add(Me.lblProvinceState)
            Me.floAddress.Controls.Add(Me.txtProvinceState)
            Me.floAddress.Controls.Add(Me.lblCountryCode)
            Me.floAddress.Controls.Add(Me.cacCountryCode)
            Me.floAddress.Controls.Add(Me.lblPoBox)
            Me.floAddress.Controls.Add(Me.txtPoBox)
            Me.floAddress.Controls.Add(Me.lblZipCode)
            Me.floAddress.Controls.Add(Me.txtZipCode)
            Me.floAddress.Location = New System.Drawing.Point(6, 19)
            Me.floAddress.Name = "floAddress"
            Me.floAddress.Size = New System.Drawing.Size(788, 108)
            Me.floAddress.TabIndex = 250
            '
            'lblStreet
            '
            Me.lblStreet.DisplayOnly = True
            Me.lblStreet.EditingMode = False
            Me.lblStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblStreet.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblStreet.Location = New System.Drawing.Point(1, 1)
            Me.lblStreet.Margin = New System.Windows.Forms.Padding(1)
            Me.lblStreet.Name = "lblStreet"
            Me.lblStreet.Size = New System.Drawing.Size(165, 23)
            Me.lblStreet.TabIndex = 197
            Me.lblStreet.Text = "Street"
            Me.lblStreet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtStreet
            '
            Me.txtStreet.BackColor = System.Drawing.Color.White
            Me.txtStreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtStreet.ComputedValue = False
            Me.txtStreet.CustomFormat = Nothing
            Me.txtStreet.DataBoundControl = True
            Me.txtStreet.EditingMode = False
            Me.txtStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtStreet.ForeColor = System.Drawing.Color.Black
            Me.txtStreet.LinkedLabel = Me.lblStreet
            Me.txtStreet.Location = New System.Drawing.Point(168, 1)
            Me.txtStreet.Margin = New System.Windows.Forms.Padding(1)
            Me.txtStreet.Name = "txtStreet"
            Me.txtStreet.OldValue = Nothing
            Me.txtStreet.Size = New System.Drawing.Size(278, 23)
            Me.txtStreet.TabIndex = 9
            '
            'lblDistrict
            '
            Me.lblDistrict.DisplayOnly = True
            Me.lblDistrict.EditingMode = False
            Me.lblDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDistrict.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDistrict.Location = New System.Drawing.Point(448, 1)
            Me.lblDistrict.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDistrict.Name = "lblDistrict"
            Me.lblDistrict.Size = New System.Drawing.Size(116, 23)
            Me.lblDistrict.TabIndex = 189
            Me.lblDistrict.Text = "District"
            Me.lblDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDistrict
            '
            Me.txtDistrict.BackColor = System.Drawing.Color.White
            Me.txtDistrict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDistrict.ComputedValue = False
            Me.txtDistrict.CustomFormat = Nothing
            Me.txtDistrict.DataBoundControl = True
            Me.txtDistrict.EditingMode = False
            Me.floAddress.SetFlowBreak(Me.txtDistrict, True)
            Me.txtDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDistrict.ForeColor = System.Drawing.Color.Black
            Me.txtDistrict.LinkedLabel = Me.lblDistrict
            Me.txtDistrict.Location = New System.Drawing.Point(566, 1)
            Me.txtDistrict.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDistrict.Name = "txtDistrict"
            Me.txtDistrict.OldValue = Nothing
            Me.txtDistrict.Size = New System.Drawing.Size(221, 23)
            Me.txtDistrict.TabIndex = 10
            '
            'lblTownCity
            '
            Me.lblTownCity.DisplayOnly = True
            Me.lblTownCity.EditingMode = False
            Me.lblTownCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTownCity.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTownCity.Location = New System.Drawing.Point(1, 26)
            Me.lblTownCity.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTownCity.Name = "lblTownCity"
            Me.lblTownCity.Size = New System.Drawing.Size(165, 23)
            Me.lblTownCity.TabIndex = 198
            Me.lblTownCity.Text = "Town/City"
            Me.lblTownCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtTownCity
            '
            Me.txtTownCity.BackColor = System.Drawing.Color.White
            Me.txtTownCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTownCity.ComputedValue = False
            Me.txtTownCity.CustomFormat = Nothing
            Me.txtTownCity.DataBoundControl = True
            Me.txtTownCity.EditingMode = False
            Me.txtTownCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtTownCity.ForeColor = System.Drawing.Color.Black
            Me.txtTownCity.LinkedLabel = Me.lblTownCity
            Me.txtTownCity.Location = New System.Drawing.Point(168, 26)
            Me.txtTownCity.Margin = New System.Windows.Forms.Padding(1)
            Me.txtTownCity.Name = "txtTownCity"
            Me.txtTownCity.OldValue = Nothing
            Me.txtTownCity.Size = New System.Drawing.Size(278, 23)
            Me.txtTownCity.TabIndex = 11
            '
            'lblProvinceState
            '
            Me.lblProvinceState.DisplayOnly = True
            Me.lblProvinceState.EditingMode = False
            Me.lblProvinceState.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblProvinceState.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblProvinceState.Location = New System.Drawing.Point(448, 26)
            Me.lblProvinceState.Margin = New System.Windows.Forms.Padding(1)
            Me.lblProvinceState.Name = "lblProvinceState"
            Me.lblProvinceState.Size = New System.Drawing.Size(116, 23)
            Me.lblProvinceState.TabIndex = 193
            Me.lblProvinceState.Text = "Province/State"
            Me.lblProvinceState.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtProvinceState
            '
            Me.txtProvinceState.BackColor = System.Drawing.Color.White
            Me.txtProvinceState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProvinceState.ComputedValue = False
            Me.txtProvinceState.CustomFormat = Nothing
            Me.txtProvinceState.DataBoundControl = True
            Me.txtProvinceState.EditingMode = False
            Me.txtProvinceState.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtProvinceState.ForeColor = System.Drawing.Color.Black
            Me.txtProvinceState.LinkedLabel = Me.lblProvinceState
            Me.txtProvinceState.Location = New System.Drawing.Point(566, 26)
            Me.txtProvinceState.Margin = New System.Windows.Forms.Padding(1)
            Me.txtProvinceState.Name = "txtProvinceState"
            Me.txtProvinceState.OldValue = Nothing
            Me.txtProvinceState.Size = New System.Drawing.Size(221, 23)
            Me.txtProvinceState.TabIndex = 12
            '
            'lblCountryCode
            '
            Me.lblCountryCode.DisplayOnly = True
            Me.lblCountryCode.EditingMode = False
            Me.lblCountryCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCountryCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCountryCode.Location = New System.Drawing.Point(1, 51)
            Me.lblCountryCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCountryCode.Name = "lblCountryCode"
            Me.lblCountryCode.Size = New System.Drawing.Size(165, 23)
            Me.lblCountryCode.TabIndex = 195
            Me.lblCountryCode.Text = "Country"
            Me.lblCountryCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cacCountryCode
            '
            Me.cacCountryCode.BackColor = System.Drawing.Color.White
            Me.cacCountryCode.ChangingSearchValueOnly = False
            Me.cacCountryCode.CurrentSearchTerm = ""
            Me.cacCountryCode.DefaultValue = Nothing
            Me.cacCountryCode.DisplayMember = "Name"
            Me.cacCountryCode.DropDownHeight = 200
            Me.cacCountryCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacCountryCode.EditingMode = False
            Me.cacCountryCode.FilterRule = Nothing
            Me.cacCountryCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacCountryCode.ForeColor = System.Drawing.Color.Black
            Me.cacCountryCode.FormattingEnabled = True
            Me.cacCountryCode.HideWhenNotEditingOrAdding = False
            Me.cacCountryCode.LinkedLabel = Me.lblCountryCode
            Me.cacCountryCode.Location = New System.Drawing.Point(167, 51)
            Me.cacCountryCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacCountryCode.Name = "cacCountryCode"
            Me.cacCountryCode.OldValue = 0
            Me.cacCountryCode.OriginalDataSource = Nothing
            Me.cacCountryCode.OriginalList = Nothing
            Me.cacCountryCode.OverrideDropDownStyleList = False
            Me.cacCountryCode.PreviousSearchTerm = Nothing
            Me.cacCountryCode.PreviousSelectedIndex = -1
            Me.cacCountryCode.PropertySelector = Nothing
            Me.cacCountryCode.ReadOnlyCombo = False
            Me.cacCountryCode.SearchAnywhere = False
            Me.cacCountryCode.Size = New System.Drawing.Size(279, 24)
            Me.cacCountryCode.SuggestBoxHeight = 200
            Me.cacCountryCode.SuggestListOrderRule = Nothing
            Me.cacCountryCode.TabIndex = 13
            Me.cacCountryCode.TextToSearch = Nothing
            Me.cacCountryCode.ValueIsMandatory = False
            Me.cacCountryCode.ValueIsNullable = False
            Me.cacCountryCode.ValueIsNumeric = False
            Me.cacCountryCode.ValueMember = "Code"
            '
            'lblPoBox
            '
            Me.lblPoBox.DisplayOnly = True
            Me.lblPoBox.EditingMode = False
            Me.lblPoBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPoBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPoBox.Location = New System.Drawing.Point(447, 51)
            Me.lblPoBox.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPoBox.Name = "lblPoBox"
            Me.lblPoBox.Size = New System.Drawing.Size(116, 23)
            Me.lblPoBox.TabIndex = 199
            Me.lblPoBox.Text = "P.O. Box No."
            Me.lblPoBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPoBox
            '
            Me.txtPoBox.BackColor = System.Drawing.Color.White
            Me.txtPoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPoBox.ComputedValue = False
            Me.txtPoBox.CustomFormat = Nothing
            Me.txtPoBox.DataBoundControl = True
            Me.txtPoBox.EditingMode = False
            Me.txtPoBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPoBox.ForeColor = System.Drawing.Color.Black
            Me.txtPoBox.LinkedLabel = Me.lblPoBox
            Me.txtPoBox.Location = New System.Drawing.Point(565, 51)
            Me.txtPoBox.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPoBox.Name = "txtPoBox"
            Me.txtPoBox.OldValue = Nothing
            Me.txtPoBox.Size = New System.Drawing.Size(72, 23)
            Me.txtPoBox.TabIndex = 14
            '
            'lblZipCode
            '
            Me.lblZipCode.DisplayOnly = True
            Me.lblZipCode.EditingMode = False
            Me.lblZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblZipCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblZipCode.Location = New System.Drawing.Point(1, 77)
            Me.lblZipCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblZipCode.Name = "lblZipCode"
            Me.lblZipCode.Size = New System.Drawing.Size(165, 23)
            Me.lblZipCode.TabIndex = 200
            Me.lblZipCode.Text = "Zip Code"
            Me.lblZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtZipCode
            '
            Me.txtZipCode.BackColor = System.Drawing.Color.White
            Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtZipCode.ComputedValue = False
            Me.txtZipCode.CustomFormat = Nothing
            Me.txtZipCode.DataBoundControl = True
            Me.txtZipCode.EditingMode = False
            Me.txtZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtZipCode.ForeColor = System.Drawing.Color.Black
            Me.txtZipCode.LinkedLabel = Me.lblZipCode
            Me.txtZipCode.Location = New System.Drawing.Point(168, 77)
            Me.txtZipCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtZipCode.Name = "txtZipCode"
            Me.txtZipCode.OldValue = Nothing
            Me.txtZipCode.Size = New System.Drawing.Size(138, 23)
            Me.txtZipCode.TabIndex = 15
            '
            'EmployeeTabControl
            '
            Me.EmployeeTabControl.Controls.Add(Me.tbpPersonal)
            Me.EmployeeTabControl.Controls.Add(Me.tbpContact)
            Me.EmployeeTabControl.Controls.Add(Me.tbpOthers)
            Me.EmployeeTabControl.Location = New System.Drawing.Point(3, 91)
            Me.EmployeeTabControl.Name = "EmployeeTabControl"
            Me.EmployeeTabControl.SelectedIndex = 0
            Me.EmployeeTabControl.Size = New System.Drawing.Size(829, 320)
            Me.EmployeeTabControl.TabIndex = 5
            '
            'tbpPersonal
            '
            Me.tbpPersonal.BackgroundImage = CType(resources.GetObject("tbpPersonal.BackgroundImage"), System.Drawing.Image)
            Me.tbpPersonal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.tbpPersonal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.tbpPersonal.Controls.Add(Me.CFlowLayout3)
            Me.tbpPersonal.Location = New System.Drawing.Point(4, 22)
            Me.tbpPersonal.Name = "tbpPersonal"
            Me.tbpPersonal.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpPersonal.Size = New System.Drawing.Size(821, 294)
            Me.tbpPersonal.TabIndex = 0
            Me.tbpPersonal.Text = "Personal Information"
            Me.tbpPersonal.UseVisualStyleBackColor = True
            '
            'CFlowLayout3
            '
            Me.CFlowLayout3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.CFlowLayout3.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout3.Controls.Add(Me.lblGender)
            Me.CFlowLayout3.Controls.Add(Me.cacGender)
            Me.CFlowLayout3.Controls.Add(Me.lblMaritalStatus)
            Me.CFlowLayout3.Controls.Add(Me.cacMaritalStatus)
            Me.CFlowLayout3.Controls.Add(Me.lblNationalityCode)
            Me.CFlowLayout3.Controls.Add(Me.cacNationalityCode)
            Me.CFlowLayout3.Controls.Add(Me.CLabel5)
            Me.CFlowLayout3.Controls.Add(Me.cacReligionIdNo)
            Me.CFlowLayout3.Controls.Add(Me.lblBirthDate)
            Me.CFlowLayout3.Controls.Add(Me.dtpBirthDate)
            Me.CFlowLayout3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout3.Location = New System.Drawing.Point(3, 3)
            Me.CFlowLayout3.Margin = New System.Windows.Forms.Padding(0)
            Me.CFlowLayout3.MinimumSize = New System.Drawing.Size(430, 180)
            Me.CFlowLayout3.Name = "CFlowLayout3"
            Me.CFlowLayout3.Size = New System.Drawing.Size(811, 284)
            Me.CFlowLayout3.TabIndex = 4
            '
            'cacGender
            '
            Me.cacGender.BackColor = System.Drawing.Color.White
            Me.cacGender.ChangingSearchValueOnly = False
            Me.cacGender.CurrentSearchTerm = ""
            Me.cacGender.DefaultValue = Nothing
            Me.cacGender.DisplayMember = "Name"
            Me.cacGender.DropDownHeight = 200
            Me.cacGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacGender.EditingMode = False
            Me.cacGender.FilterRule = Nothing
            Me.CFlowLayout3.SetFlowBreak(Me.cacGender, True)
            Me.cacGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacGender.ForeColor = System.Drawing.Color.Black
            Me.cacGender.FormattingEnabled = True
            Me.cacGender.HideWhenNotEditingOrAdding = False
            Me.cacGender.LinkedLabel = Me.lblMaritalStatus
            Me.cacGender.Location = New System.Drawing.Point(176, 1)
            Me.cacGender.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacGender.Name = "cacGender"
            Me.cacGender.OldValue = 0
            Me.cacGender.OriginalDataSource = Nothing
            Me.cacGender.OriginalList = Nothing
            Me.cacGender.OverrideDropDownStyleList = False
            Me.cacGender.PreviousSearchTerm = Nothing
            Me.cacGender.PreviousSelectedIndex = -1
            Me.cacGender.PropertySelector = Nothing
            Me.cacGender.ReadOnlyCombo = False
            Me.cacGender.SearchAnywhere = False
            Me.cacGender.Size = New System.Drawing.Size(124, 24)
            Me.cacGender.SuggestBoxHeight = 200
            Me.cacGender.SuggestListOrderRule = Nothing
            Me.cacGender.TabIndex = 250
            Me.cacGender.TextToSearch = Nothing
            Me.cacGender.ValueIsMandatory = False
            Me.cacGender.ValueIsNullable = False
            Me.cacGender.ValueIsNumeric = False
            Me.cacGender.ValueMember = "Code"
            '
            'tbpContact
            '
            Me.tbpContact.BackgroundImage = CType(resources.GetObject("tbpContact.BackgroundImage"), System.Drawing.Image)
            Me.tbpContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.tbpContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.tbpContact.Controls.Add(Me.groupBoxAddress)
            Me.tbpContact.Controls.Add(Me.groupBoxContactInfo)
            Me.tbpContact.Location = New System.Drawing.Point(4, 22)
            Me.tbpContact.Name = "tbpContact"
            Me.tbpContact.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpContact.Size = New System.Drawing.Size(821, 294)
            Me.tbpContact.TabIndex = 1
            Me.tbpContact.Text = "Contact Information"
            Me.tbpContact.UseVisualStyleBackColor = True
            '
            'tbpOthers
            '
            Me.tbpOthers.BackgroundImage = CType(resources.GetObject("tbpOthers.BackgroundImage"), System.Drawing.Image)
            Me.tbpOthers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.tbpOthers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.tbpOthers.Controls.Add(Me.floMainDisplay)
            Me.tbpOthers.Location = New System.Drawing.Point(4, 22)
            Me.tbpOthers.Name = "tbpOthers"
            Me.tbpOthers.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpOthers.Size = New System.Drawing.Size(821, 294)
            Me.tbpOthers.TabIndex = 2
            Me.tbpOthers.Text = "Payroll Information"
            Me.tbpOthers.UseVisualStyleBackColor = True
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.Dock = System.Windows.Forms.DockStyle.Left
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(183, 23)
            Me.lblIdNo.TabIndex = 152
            Me.lblIdNo.Text = "Employee Id No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'TxtIDNo
            '
            Me.TxtIDNo.BackColor = System.Drawing.Color.White
            Me.TxtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIDNo.ComputedValue = False
            Me.TxtIDNo.CustomFormat = Nothing
            Me.TxtIDNo.DataBoundControl = True
            Me.TxtIDNo.DisplayOnly = True
            Me.TxtIDNo.EditingMode = True
            Me.TxtIDNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIDNo.LinkedLabel = Me.lblIdNo
            Me.TxtIDNo.Location = New System.Drawing.Point(186, 1)
            Me.TxtIDNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIDNo.Name = "TxtIDNo"
            Me.TxtIDNo.OldValue = Nothing
            Me.TxtIDNo.ReadOnly = True
            Me.TxtIDNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIDNo.TabIndex = 151
            Me.TxtIDNo.TabStop = False
            '
            'lblEmployeeCode
            '
            Me.lblEmployeeCode.DisplayOnly = True
            Me.lblEmployeeCode.EditingMode = False
            Me.lblEmployeeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEmployeeCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblEmployeeCode.Location = New System.Drawing.Point(250, 1)
            Me.lblEmployeeCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEmployeeCode.Name = "lblEmployeeCode"
            Me.lblEmployeeCode.Size = New System.Drawing.Size(488, 23)
            Me.lblEmployeeCode.TabIndex = 154
            Me.lblEmployeeCode.Text = "Employee Code"
            Me.lblEmployeeCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEmployeeCode
            '
            Me.txtEmployeeCode.BackColor = System.Drawing.Color.White
            Me.txtEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmployeeCode.ComputedValue = False
            Me.txtEmployeeCode.CustomFormat = Nothing
            Me.txtEmployeeCode.DataBoundControl = True
            Me.txtEmployeeCode.EditingMode = False
            Me.CFlowLayout4.SetFlowBreak(Me.txtEmployeeCode, True)
            Me.txtEmployeeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmployeeCode.ForeColor = System.Drawing.Color.Black
            Me.txtEmployeeCode.LinkedLabel = Me.lblEmployeeCode
            Me.txtEmployeeCode.Location = New System.Drawing.Point(740, 1)
            Me.txtEmployeeCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeCode.Name = "txtEmployeeCode"
            Me.txtEmployeeCode.OldValue = Nothing
            Me.txtEmployeeCode.Size = New System.Drawing.Size(66, 23)
            Me.txtEmployeeCode.TabIndex = 153
            Me.txtEmployeeCode.ValueIsMandatory = True
            '
            'EmployeeModelBindingSource
            '
            Me.EmployeeModelBindingSource.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.EmployeeModel)
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.CFlowLayout4)
            Me.CFlowLayout2.Controls.Add(Me.EmployeeTabControl)
            Me.CFlowLayout2.Dock = System.Windows.Forms.DockStyle.Left
            Me.CFlowLayout2.Location = New System.Drawing.Point(300, 53)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(839, 418)
            Me.CFlowLayout2.TabIndex = 6
            '
            'CFlowLayout4
            '
            Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout4.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout4.Controls.Add(Me.TxtIDNo)
            Me.CFlowLayout4.Controls.Add(Me.lblEmployeeCode)
            Me.CFlowLayout4.Controls.Add(Me.txtEmployeeCode)
            Me.CFlowLayout4.Controls.Add(Me.lblEmployeeName)
            Me.CFlowLayout4.Controls.Add(Me.txtEmployeeName)
            Me.CFlowLayout4.Controls.Add(Me.lblEmployeeNameAra)
            Me.CFlowLayout4.Controls.Add(Me.txtEmployeeNameAra)
            Me.CFlowLayout4.Location = New System.Drawing.Point(3, 3)
            Me.CFlowLayout4.Name = "CFlowLayout4"
            Me.CFlowLayout4.Size = New System.Drawing.Size(829, 82)
            Me.CFlowLayout4.TabIndex = 6
            '
            'EmployeeEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1149, 471)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.MinimumSize = New System.Drawing.Size(1165, 480)
            Me.Name = "EmployeeEntryTv"
            Me.Text = "Employee Maintenance Form"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floMainDisplay.ResumeLayout(false)
        Me.floMainDisplay.PerformLayout
        Me.groupBoxContactInfo.ResumeLayout(false)
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.groupBoxAddress.ResumeLayout(false)
        Me.floAddress.ResumeLayout(false)
        Me.floAddress.PerformLayout
        Me.EmployeeTabControl.ResumeLayout(false)
        Me.tbpPersonal.ResumeLayout(false)
        Me.CFlowLayout3.ResumeLayout(false)
        Me.tbpContact.ResumeLayout(false)
        Me.tbpContact.PerformLayout
        Me.tbpOthers.ResumeLayout(false)
        CType(Me.EmployeeModelBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout2.ResumeLayout(false)
        Me.CFlowLayout4.ResumeLayout(false)
        Me.CFlowLayout4.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents floMainDisplay As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblEmployeeName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmployeeName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblEmployeeNameAra As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmployeeNameAra As Libraries.CBaseControlsLibrary.CTextBoxArabic
        Friend WithEvents lblGender As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblBirthDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpBirthDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblMaritalStatus As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacMaritalStatus As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblNationalityCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacNationalityCode As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents CLabel5 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacReligionIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents floAddress As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblStreet As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtStreet As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblDistrict As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDistrict As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblTownCity As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtTownCity As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblProvinceState As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtProvinceState As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblCountryCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacCountryCode As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblPoBox As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPoBox As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblZipCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtZipCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPhone1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPhone1 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPhone2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPhone2 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblEmail As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmail As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblDepartmentIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacDepartmentIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblDesignationIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacDesignationIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblHiredDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpHiredDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblReleasedDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpReleasedDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblArAccountIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacArAccountIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblBankIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacBankIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblBankAccountNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtBankAccountNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblIban As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtIban As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblOpeningBalance As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtOpeningBalance As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblBalance As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtBalance As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblNationalIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtNationalIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblActive As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents chkActive As Libraries.CBaseControlsLibrary.CCheckBox
        Friend WithEvents lblNotes As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtNotes As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents groupBoxAddress As Libraries.CBaseControlsLibrary.CGroupBox
        Friend WithEvents groupBoxContactInfo As Libraries.CBaseControlsLibrary.CGroupBox
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtIDNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblEmployeeCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmployeeCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents EmployeeTabControl As Libraries.CBaseControlsLibrary.CTabControl
        Friend WithEvents tbpPersonal As Libraries.CBaseControlsLibrary.CTabPage
        Friend WithEvents tbpContact As Libraries.CBaseControlsLibrary.CTabPage
        Friend WithEvents tbpOthers As Libraries.CBaseControlsLibrary.CTabPage
        Friend WithEvents CFlowLayout3 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CFlowLayout2 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents cacGender As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents EmployeeModelBindingSource As BindingSource
        Friend WithEvents CFlowLayout4 As Libraries.CBaseControlsLibrary.CFlowLayout
    End Class

End Namespace