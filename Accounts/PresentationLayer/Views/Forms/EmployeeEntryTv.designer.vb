Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim EventAggregator2 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CFlowLayout6 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblBankIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacBankIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblBankAccountNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtBankAccountNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblOpeningBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtOpeningBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblIban = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtIban = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayFrequency = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPayFrequency = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.bsEarnings = New System.Windows.Forms.BindingSource(Me.components)
        Me.bsDeductions = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.EmployeeTabControl = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
        Me.tbpPersonal = New AATM.Libraries.CBaseControlsLibrary.CTabPage()
        Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.cacGender = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblNationalIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNationalIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.tbpContact = New AATM.Libraries.CBaseControlsLibrary.CTabPage()
        Me.floContactInformation = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridViewPhoneDisplay = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequencePhoneDisplay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullPhoneAra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AreaCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CountryTelIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PhoneNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PhoneTypeIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsPhones = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtZipCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblZipCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPoBox = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPoBox = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacCountryCode = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblCountryCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtProvinceState = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblProvinceState = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtTownCity = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblTownCity = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDistrict = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDistrict = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtStreet = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtEmail = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblEmail = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblStreet = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.tbpEmployment = New System.Windows.Forms.TabPage()
        Me.CFlowLayout5 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblHiredDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpHiredDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.lblReleasedDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpReleasedDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.lblDepartmentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacDepartmentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblDesignationIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacDesignationIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.tbpPayroll = New AATM.Libraries.CBaseControlsLibrary.CTabPage()
        Me.tbpEarningDeductions = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNetTotal = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewEarnings = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequenceEarning = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvEarningIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvEarningAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewDeductions = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequenceDeduction = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvDeductionIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvDeductionAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblEarnings = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNetTotal = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.tbpPhones = New System.Windows.Forms.TabPage()
        Me.DataGridViewPhones = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvPhoneTypeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvCountryTelIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvAreaCode = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.PhoneNumber = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvFullPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvFullPhoneAra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvCountryTelCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEmployeeCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtEmployeeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floMain = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblPaymentMethod = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPaymentMethod = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout6.SuspendLayout
        CType(Me.bsEarnings,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsDeductions,System.ComponentModel.ISupportInitialize).BeginInit
        Me.EmployeeTabControl.SuspendLayout
        Me.tbpPersonal.SuspendLayout
        Me.CFlowLayout3.SuspendLayout
        Me.tbpContact.SuspendLayout
        Me.floContactInformation.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        CType(Me.DataGridViewPhoneDisplay,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsPhones,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tbpEmployment.SuspendLayout
        Me.CFlowLayout5.SuspendLayout
        Me.tbpPayroll.SuspendLayout
        Me.tbpEarningDeductions.SuspendLayout
        Me.TableLayoutPanel2.SuspendLayout
        CType(Me.DataGridViewEarnings,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGridViewDeductions,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tbpPhones.SuspendLayout
        CType(Me.DataGridViewPhones,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floMain.SuspendLayout
        Me.CFlowLayout4.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TreeViewTableName.Size = New System.Drawing.Size(300, 514)
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'CFlowLayout6
        '
        Me.CFlowLayout6.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout6.Controls.Add(Me.lblPaymentMethod)
        Me.CFlowLayout6.Controls.Add(Me.cboPaymentMethod)
        Me.CFlowLayout6.Controls.Add(Me.lblBankIdNo)
        Me.CFlowLayout6.Controls.Add(Me.cacBankIdNo)
        Me.CFlowLayout6.Controls.Add(Me.lblBankAccountNo)
        Me.CFlowLayout6.Controls.Add(Me.txtBankAccountNo)
        Me.CFlowLayout6.Controls.Add(Me.lblBalance)
        Me.CFlowLayout6.Controls.Add(Me.txtBalance)
        Me.CFlowLayout6.Controls.Add(Me.lblOpeningBalance)
        Me.CFlowLayout6.Controls.Add(Me.txtOpeningBalance)
        Me.CFlowLayout6.Controls.Add(Me.lblIban)
        Me.CFlowLayout6.Controls.Add(Me.txtIban)
        Me.CFlowLayout6.Controls.Add(Me.lblPayFrequency)
        Me.CFlowLayout6.Controls.Add(Me.cboPayFrequency)
        Me.CFlowLayout6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CFlowLayout6.Location = New System.Drawing.Point(3, 3)
        Me.CFlowLayout6.Name = "CFlowLayout6"
        Me.CFlowLayout6.Padding = New System.Windows.Forms.Padding(3)
        Me.CFlowLayout6.Size = New System.Drawing.Size(802, 384)
        Me.CFlowLayout6.TabIndex = 293
        '
        'lblBankIdNo
        '
        Me.lblBankIdNo.DisplayOnly = true
        Me.lblBankIdNo.EditingMode = false
        Me.lblBankIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBankIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBankIdNo.Location = New System.Drawing.Point(4, 30)
        Me.lblBankIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBankIdNo.Name = "lblBankIdNo"
        Me.lblBankIdNo.Size = New System.Drawing.Size(185, 23)
        Me.lblBankIdNo.TabIndex = 216
        Me.lblBankIdNo.Text = "Bank Name"
        Me.lblBankIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacBankIdNo
        '
        Me.cacBankIdNo.BackColor = System.Drawing.Color.White
        Me.cacBankIdNo.ChangingSearchValueOnly = false
        Me.cacBankIdNo.CurrentSearchTerm = ""
        Me.cacBankIdNo.DefaultValue = Nothing
        Me.cacBankIdNo.DisplayMember = "Name"
        Me.cacBankIdNo.DropDownHeight = 1
        Me.cacBankIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacBankIdNo.EditingMode = false
        Me.cacBankIdNo.FilterRule = Nothing
        Me.CFlowLayout6.SetFlowBreak(Me.cacBankIdNo, true)
        Me.cacBankIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacBankIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacBankIdNo.FormattingEnabled = true
        Me.cacBankIdNo.HideWhenNotEditingOrAdding = false
        Me.cacBankIdNo.IntegralHeight = false
        Me.cacBankIdNo.LinkedLabel = Me.lblBankIdNo
        Me.cacBankIdNo.Location = New System.Drawing.Point(190, 30)
        Me.cacBankIdNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.cacBankIdNo.Name = "cacBankIdNo"
        Me.cacBankIdNo.OldValue = 0
        Me.cacBankIdNo.OriginalDataSource = Nothing
        Me.cacBankIdNo.OriginalList = Nothing
        Me.cacBankIdNo.OverrideDropDownStyleList = false
        Me.cacBankIdNo.PreviousSearchTerm = Nothing
        Me.cacBankIdNo.PreviousSelectedIndex = -1
        Me.cacBankIdNo.PropertySelector = Nothing
        Me.cacBankIdNo.ReadOnlyCombo = false
        Me.cacBankIdNo.SearchAnywhere = false
        Me.cacBankIdNo.Size = New System.Drawing.Size(201, 24)
        Me.cacBankIdNo.SuggestBoxHeight = 200
        Me.cacBankIdNo.SuggestListOrderRule = Nothing
        Me.cacBankIdNo.TabIndex = 2
        Me.cacBankIdNo.TextToSearch = Nothing
        Me.cacBankIdNo.ValueIsMandatory = false
        Me.cacBankIdNo.ValueIsNullable = false
        Me.cacBankIdNo.ValueIsNumeric = false
        Me.cacBankIdNo.ValueMember = "IdNo"
        '
        'lblBankAccountNo
        '
        Me.lblBankAccountNo.DisplayOnly = true
        Me.lblBankAccountNo.EditingMode = false
        Me.lblBankAccountNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBankAccountNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBankAccountNo.Location = New System.Drawing.Point(4, 56)
        Me.lblBankAccountNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBankAccountNo.Name = "lblBankAccountNo"
        Me.lblBankAccountNo.Size = New System.Drawing.Size(185, 23)
        Me.lblBankAccountNo.TabIndex = 218
        Me.lblBankAccountNo.Text = "Account No."
        Me.lblBankAccountNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBankAccountNo
        '
        Me.txtBankAccountNo.BackColor = System.Drawing.Color.White
        Me.txtBankAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankAccountNo.ComputedValue = false
        Me.txtBankAccountNo.CustomFormat = Nothing
        Me.txtBankAccountNo.DataBoundControl = true
        Me.txtBankAccountNo.EditingMode = false
        Me.CFlowLayout6.SetFlowBreak(Me.txtBankAccountNo, true)
        Me.txtBankAccountNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtBankAccountNo.ForeColor = System.Drawing.Color.Black
        Me.txtBankAccountNo.LinkedLabel = Me.lblBankAccountNo
        Me.txtBankAccountNo.Location = New System.Drawing.Point(191, 56)
        Me.txtBankAccountNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtBankAccountNo.MaximumValue = Nothing
        Me.txtBankAccountNo.MinimumValue = Nothing
        Me.txtBankAccountNo.Name = "txtBankAccountNo"
        Me.txtBankAccountNo.OldValue = Nothing
        Me.txtBankAccountNo.ReadOnly = true
        Me.txtBankAccountNo.Size = New System.Drawing.Size(200, 23)
        Me.txtBankAccountNo.TabIndex = 3
        '
        'lblBalance
        '
        Me.lblBalance.DisplayOnly = true
        Me.lblBalance.EditingMode = false
        Me.lblBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBalance.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBalance.Location = New System.Drawing.Point(4, 81)
        Me.lblBalance.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(185, 23)
        Me.lblBalance.TabIndex = 285
        Me.lblBalance.Text = "Cash Advance Balance"
        Me.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBalance
        '
        Me.txtBalance.BackColor = System.Drawing.Color.White
        Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalance.ComputedValue = false
        Me.txtBalance.CustomFormat = Nothing
        Me.txtBalance.DataBoundControl = true
        Me.txtBalance.DisplayOnly = true
        Me.txtBalance.EditingMode = false
        Me.CFlowLayout6.SetFlowBreak(Me.txtBalance, true)
        Me.txtBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtBalance.ForeColor = System.Drawing.Color.Black
        Me.txtBalance.LinkedLabel = Me.lblBalance
        Me.txtBalance.Location = New System.Drawing.Point(191, 81)
        Me.txtBalance.Margin = New System.Windows.Forms.Padding(1)
        Me.txtBalance.MaximumValue = Nothing
        Me.txtBalance.MinimumValue = Nothing
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.OldValue = Nothing
        Me.txtBalance.ReadOnly = true
        Me.txtBalance.Size = New System.Drawing.Size(200, 23)
        Me.txtBalance.TabIndex = 4
        Me.txtBalance.ValueIsNumeric = true
        '
        'lblOpeningBalance
        '
        Me.lblOpeningBalance.DisplayOnly = true
        Me.lblOpeningBalance.EditingMode = false
        Me.lblOpeningBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblOpeningBalance.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblOpeningBalance.Location = New System.Drawing.Point(4, 106)
        Me.lblOpeningBalance.Margin = New System.Windows.Forms.Padding(1)
        Me.lblOpeningBalance.Name = "lblOpeningBalance"
        Me.lblOpeningBalance.Size = New System.Drawing.Size(185, 23)
        Me.lblOpeningBalance.TabIndex = 284
        Me.lblOpeningBalance.Text = "Open. Bal. (Cash Adv.)"
        Me.lblOpeningBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOpeningBalance
        '
        Me.txtOpeningBalance.BackColor = System.Drawing.Color.White
        Me.txtOpeningBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOpeningBalance.ComputedValue = false
        Me.txtOpeningBalance.CustomFormat = Nothing
        Me.txtOpeningBalance.DataBoundControl = true
        Me.txtOpeningBalance.EditingMode = false
        Me.CFlowLayout6.SetFlowBreak(Me.txtOpeningBalance, true)
        Me.txtOpeningBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtOpeningBalance.ForeColor = System.Drawing.Color.Black
        Me.txtOpeningBalance.LinkedLabel = Me.lblOpeningBalance
        Me.txtOpeningBalance.Location = New System.Drawing.Point(191, 106)
        Me.txtOpeningBalance.Margin = New System.Windows.Forms.Padding(1)
        Me.txtOpeningBalance.MaximumValue = Nothing
        Me.txtOpeningBalance.MinimumValue = Nothing
        Me.txtOpeningBalance.Name = "txtOpeningBalance"
        Me.txtOpeningBalance.OldValue = Nothing
        Me.txtOpeningBalance.ReadOnly = true
        Me.txtOpeningBalance.Size = New System.Drawing.Size(200, 23)
        Me.txtOpeningBalance.TabIndex = 5
        Me.txtOpeningBalance.ValueIsNumeric = true
        '
        'lblIban
        '
        Me.lblIban.DisplayOnly = true
        Me.lblIban.EditingMode = false
        Me.lblIban.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIban.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIban.Location = New System.Drawing.Point(4, 131)
        Me.lblIban.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIban.Name = "lblIban"
        Me.lblIban.Size = New System.Drawing.Size(185, 23)
        Me.lblIban.TabIndex = 220
        Me.lblIban.Text = "IBAN Number"
        Me.lblIban.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIban
        '
        Me.txtIban.BackColor = System.Drawing.Color.White
        Me.txtIban.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIban.ComputedValue = false
        Me.txtIban.CustomFormat = Nothing
        Me.txtIban.DataBoundControl = true
        Me.txtIban.EditingMode = false
        Me.CFlowLayout6.SetFlowBreak(Me.txtIban, true)
        Me.txtIban.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtIban.ForeColor = System.Drawing.Color.Black
        Me.txtIban.LinkedLabel = Me.lblIban
        Me.txtIban.Location = New System.Drawing.Point(191, 131)
        Me.txtIban.Margin = New System.Windows.Forms.Padding(1)
        Me.txtIban.MaximumValue = Nothing
        Me.txtIban.MinimumValue = Nothing
        Me.txtIban.Name = "txtIban"
        Me.txtIban.OldValue = Nothing
        Me.txtIban.ReadOnly = true
        Me.txtIban.Size = New System.Drawing.Size(200, 23)
        Me.txtIban.TabIndex = 6
        '
        'lblPayFrequency
        '
        Me.lblPayFrequency.DisplayOnly = true
        Me.lblPayFrequency.EditingMode = false
        Me.lblPayFrequency.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayFrequency.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPayFrequency.Location = New System.Drawing.Point(4, 156)
        Me.lblPayFrequency.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayFrequency.Name = "lblPayFrequency"
        Me.lblPayFrequency.Size = New System.Drawing.Size(185, 23)
        Me.lblPayFrequency.TabIndex = 286
        Me.lblPayFrequency.Text = "Pay Frequency"
        Me.lblPayFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPayFrequency
        '
        Me.cboPayFrequency.BackColor = System.Drawing.Color.White
        Me.cboPayFrequency.ChangingSearchValueOnly = false
        Me.cboPayFrequency.CurrentSearchTerm = ""
        Me.cboPayFrequency.DefaultValue = Nothing
        Me.cboPayFrequency.DisplayMember = "Name"
        Me.cboPayFrequency.DropDownHeight = 1
        Me.cboPayFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayFrequency.EditingMode = false
        Me.cboPayFrequency.FilterRule = Nothing
        Me.CFlowLayout6.SetFlowBreak(Me.cboPayFrequency, true)
        Me.cboPayFrequency.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPayFrequency.ForeColor = System.Drawing.Color.Black
        Me.cboPayFrequency.FormattingEnabled = true
        Me.cboPayFrequency.HideWhenNotEditingOrAdding = false
        Me.cboPayFrequency.IntegralHeight = false
        Me.cboPayFrequency.LinkedLabel = Me.lblPayFrequency
        Me.cboPayFrequency.Location = New System.Drawing.Point(190, 156)
        Me.cboPayFrequency.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.cboPayFrequency.Name = "cboPayFrequency"
        Me.cboPayFrequency.OldValue = 0
        Me.cboPayFrequency.OriginalDataSource = Nothing
        Me.cboPayFrequency.OriginalList = Nothing
        Me.cboPayFrequency.OverrideDropDownStyleList = false
        Me.cboPayFrequency.PreviousSearchTerm = Nothing
        Me.cboPayFrequency.PreviousSelectedIndex = -1
        Me.cboPayFrequency.PropertySelector = Nothing
        Me.cboPayFrequency.ReadOnlyCombo = false
        Me.cboPayFrequency.SearchAnywhere = false
        Me.cboPayFrequency.Size = New System.Drawing.Size(201, 24)
        Me.cboPayFrequency.SuggestBoxHeight = 200
        Me.cboPayFrequency.SuggestListOrderRule = Nothing
        Me.cboPayFrequency.TabIndex = 7
        Me.cboPayFrequency.TextToSearch = Nothing
        Me.cboPayFrequency.ValueIsMandatory = false
        Me.cboPayFrequency.ValueIsNullable = false
        Me.cboPayFrequency.ValueIsNumeric = false
        Me.cboPayFrequency.ValueMember = "Code"
        '
        'bsEarnings
        '
        Me.bsEarnings.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.EmployeeEarningModel)
        '
        'bsDeductions
        '
        Me.bsDeductions.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.EmployeeDeductionModel)
        '
        'lblEmployeeName
        '
        Me.lblEmployeeName.DisplayOnly = true
        Me.lblEmployeeName.EditingMode = false
        Me.lblEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
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
        Me.txtEmployeeName.ComputedValue = false
        Me.txtEmployeeName.CustomFormat = Nothing
        Me.txtEmployeeName.DataBoundControl = true
        Me.txtEmployeeName.EditingMode = false
        Me.CFlowLayout4.SetFlowBreak(Me.txtEmployeeName, true)
        Me.txtEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtEmployeeName.ForeColor = System.Drawing.Color.Black
        Me.txtEmployeeName.LinkedLabel = Me.lblEmployeeName
        Me.txtEmployeeName.Location = New System.Drawing.Point(186, 26)
        Me.txtEmployeeName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEmployeeName.MaximumValue = Nothing
        Me.txtEmployeeName.MinimumValue = Nothing
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.OldValue = Nothing
        Me.txtEmployeeName.ReadOnly = true
        Me.txtEmployeeName.Size = New System.Drawing.Size(620, 23)
        Me.txtEmployeeName.TabIndex = 2
        Me.txtEmployeeName.ValueIsMandatory = true
        '
        'lblEmployeeNameAra
        '
        Me.lblEmployeeNameAra.DisplayOnly = true
        Me.lblEmployeeNameAra.EditingMode = false
        Me.lblEmployeeNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
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
        Me.txtEmployeeNameAra.ComputedValue = false
        Me.txtEmployeeNameAra.CustomFormat = Nothing
        Me.txtEmployeeNameAra.DataBoundControl = true
        Me.txtEmployeeNameAra.EditingMode = false
        Me.txtEmployeeNameAra.EnglishControl = Me.txtEmployeeName
        Me.CFlowLayout4.SetFlowBreak(Me.txtEmployeeNameAra, true)
        Me.txtEmployeeNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtEmployeeNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtEmployeeNameAra.LinkedLabel = Me.lblEmployeeNameAra
        Me.txtEmployeeNameAra.Location = New System.Drawing.Point(186, 51)
        Me.txtEmployeeNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEmployeeNameAra.MaximumValue = Nothing
        Me.txtEmployeeNameAra.MinimumValue = Nothing
        Me.txtEmployeeNameAra.Name = "txtEmployeeNameAra"
        Me.txtEmployeeNameAra.OldValue = Nothing
        Me.txtEmployeeNameAra.ReadOnly = true
        Me.txtEmployeeNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtEmployeeNameAra.Size = New System.Drawing.Size(620, 23)
        Me.txtEmployeeNameAra.TabIndex = 3
        Me.txtEmployeeNameAra.ValueIsMandatory = true
        '
        'lblGender
        '
        Me.lblGender.DisplayOnly = true
        Me.lblGender.EditingMode = false
        Me.lblGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
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
        Me.lblBirthDate.DisplayOnly = true
        Me.lblBirthDate.EditingMode = false
        Me.lblBirthDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBirthDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBirthDate.Location = New System.Drawing.Point(1, 105)
        Me.lblBirthDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBirthDate.Name = "lblBirthDate"
        Me.lblBirthDate.Size = New System.Drawing.Size(174, 23)
        Me.lblBirthDate.TabIndex = 185
        Me.lblBirthDate.Text = "Date of Birth"
        Me.lblBirthDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpBirthDate.DefaultValue = Nothing
        Me.dtpBirthDate.DisplayOnly = false
        Me.dtpBirthDate.DtpDefaultValue = Nothing
        Me.dtpBirthDate.EditingMode = false
        Me.dtpBirthDate.EditsAllowed = false
        Me.CFlowLayout3.SetFlowBreak(Me.dtpBirthDate, true)
        Me.dtpBirthDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dtpBirthDate.ForeColor = System.Drawing.Color.Black
        Me.dtpBirthDate.LinkedLabel = Me.lblBirthDate
        Me.dtpBirthDate.Location = New System.Drawing.Point(176, 104)
        Me.dtpBirthDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.ReadOnlyDp = false
        Me.dtpBirthDate.SecurityKey = Nothing
        Me.dtpBirthDate.ShowLongDate = false
        Me.dtpBirthDate.ShowTime = false
        Me.dtpBirthDate.Size = New System.Drawing.Size(123, 24)
        Me.dtpBirthDate.TabIndex = 5
        Me.dtpBirthDate.TabStop = false
        Me.dtpBirthDate.TargetCalendar = CType(resources.GetObject("dtpBirthDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpBirthDate.Value = Nothing
        Me.dtpBirthDate.ValueIsMandatory = false
        Me.dtpBirthDate.ValueIsNullable = false
        '
        'lblMaritalStatus
        '
        Me.lblMaritalStatus.DisplayOnly = true
        Me.lblMaritalStatus.EditingMode = false
        Me.lblMaritalStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
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
        Me.cacMaritalStatus.ChangingSearchValueOnly = false
        Me.cacMaritalStatus.CurrentSearchTerm = ""
        Me.cacMaritalStatus.DefaultValue = Nothing
        Me.cacMaritalStatus.DisplayMember = "Name"
        Me.cacMaritalStatus.DropDownHeight = 1
        Me.cacMaritalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacMaritalStatus.EditingMode = false
        Me.cacMaritalStatus.FilterRule = Nothing
        Me.CFlowLayout3.SetFlowBreak(Me.cacMaritalStatus, true)
        Me.cacMaritalStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacMaritalStatus.ForeColor = System.Drawing.Color.Black
        Me.cacMaritalStatus.FormattingEnabled = true
        Me.cacMaritalStatus.HideWhenNotEditingOrAdding = false
        Me.cacMaritalStatus.IntegralHeight = false
        Me.cacMaritalStatus.LinkedLabel = Me.lblMaritalStatus
        Me.cacMaritalStatus.Location = New System.Drawing.Point(177, 27)
        Me.cacMaritalStatus.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.cacMaritalStatus.Name = "cacMaritalStatus"
        Me.cacMaritalStatus.OldValue = 0
        Me.cacMaritalStatus.OriginalDataSource = Nothing
        Me.cacMaritalStatus.OriginalList = Nothing
        Me.cacMaritalStatus.OverrideDropDownStyleList = false
        Me.cacMaritalStatus.PreviousSearchTerm = Nothing
        Me.cacMaritalStatus.PreviousSelectedIndex = -1
        Me.cacMaritalStatus.PropertySelector = Nothing
        Me.cacMaritalStatus.ReadOnlyCombo = false
        Me.cacMaritalStatus.SearchAnywhere = false
        Me.cacMaritalStatus.Size = New System.Drawing.Size(278, 24)
        Me.cacMaritalStatus.SuggestBoxHeight = 200
        Me.cacMaritalStatus.SuggestListOrderRule = Nothing
        Me.cacMaritalStatus.TabIndex = 2
        Me.cacMaritalStatus.TextToSearch = Nothing
        Me.cacMaritalStatus.ValueIsMandatory = false
        Me.cacMaritalStatus.ValueIsNullable = false
        Me.cacMaritalStatus.ValueIsNumeric = false
        Me.cacMaritalStatus.ValueMember = "Code"
        '
        'lblNationalityCode
        '
        Me.lblNationalityCode.DisplayOnly = true
        Me.lblNationalityCode.EditingMode = false
        Me.lblNationalityCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
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
        Me.cacNationalityCode.ChangingSearchValueOnly = false
        Me.cacNationalityCode.CurrentSearchTerm = ""
        Me.cacNationalityCode.DefaultValue = Nothing
        Me.cacNationalityCode.DisplayMember = "Name"
        Me.cacNationalityCode.DropDownHeight = 1
        Me.cacNationalityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacNationalityCode.EditingMode = false
        Me.cacNationalityCode.FilterRule = Nothing
        Me.CFlowLayout3.SetFlowBreak(Me.cacNationalityCode, true)
        Me.cacNationalityCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacNationalityCode.ForeColor = System.Drawing.Color.Black
        Me.cacNationalityCode.FormattingEnabled = true
        Me.cacNationalityCode.HideWhenNotEditingOrAdding = false
        Me.cacNationalityCode.IntegralHeight = false
        Me.cacNationalityCode.LinkedLabel = Me.lblNationalityCode
        Me.cacNationalityCode.Location = New System.Drawing.Point(176, 53)
        Me.cacNationalityCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.cacNationalityCode.Name = "cacNationalityCode"
        Me.cacNationalityCode.OldValue = 0
        Me.cacNationalityCode.OriginalDataSource = Nothing
        Me.cacNationalityCode.OriginalList = Nothing
        Me.cacNationalityCode.OverrideDropDownStyleList = false
        Me.cacNationalityCode.PreviousSearchTerm = Nothing
        Me.cacNationalityCode.PreviousSelectedIndex = -1
        Me.cacNationalityCode.PropertySelector = Nothing
        Me.cacNationalityCode.ReadOnlyCombo = false
        Me.cacNationalityCode.SearchAnywhere = false
        Me.cacNationalityCode.Size = New System.Drawing.Size(279, 24)
        Me.cacNationalityCode.SuggestBoxHeight = 200
        Me.cacNationalityCode.SuggestListOrderRule = Nothing
        Me.cacNationalityCode.TabIndex = 3
        Me.cacNationalityCode.TextToSearch = Nothing
        Me.cacNationalityCode.ValueIsMandatory = false
        Me.cacNationalityCode.ValueIsNullable = false
        Me.cacNationalityCode.ValueIsNumeric = false
        Me.cacNationalityCode.ValueMember = "Code"
        '
        'CLabel5
        '
        Me.CLabel5.DisplayOnly = true
        Me.CLabel5.EditingMode = false
        Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
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
        Me.cacReligionIdNo.ChangingSearchValueOnly = false
        Me.cacReligionIdNo.CurrentSearchTerm = ""
        Me.cacReligionIdNo.DefaultValue = Nothing
        Me.cacReligionIdNo.DisplayMember = "Name"
        Me.cacReligionIdNo.DropDownHeight = 1
        Me.cacReligionIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacReligionIdNo.EditingMode = false
        Me.cacReligionIdNo.FilterRule = Nothing
        Me.CFlowLayout3.SetFlowBreak(Me.cacReligionIdNo, true)
        Me.cacReligionIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacReligionIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacReligionIdNo.FormattingEnabled = true
        Me.cacReligionIdNo.HideWhenNotEditingOrAdding = false
        Me.cacReligionIdNo.IntegralHeight = false
        Me.cacReligionIdNo.LinkedLabel = Me.lblNationalityCode
        Me.cacReligionIdNo.Location = New System.Drawing.Point(177, 79)
        Me.cacReligionIdNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.cacReligionIdNo.Name = "cacReligionIdNo"
        Me.cacReligionIdNo.OldValue = 0
        Me.cacReligionIdNo.OriginalDataSource = Nothing
        Me.cacReligionIdNo.OriginalList = Nothing
        Me.cacReligionIdNo.OverrideDropDownStyleList = false
        Me.cacReligionIdNo.PreviousSearchTerm = Nothing
        Me.cacReligionIdNo.PreviousSelectedIndex = -1
        Me.cacReligionIdNo.PropertySelector = Nothing
        Me.cacReligionIdNo.ReadOnlyCombo = false
        Me.cacReligionIdNo.SearchAnywhere = false
        Me.cacReligionIdNo.Size = New System.Drawing.Size(278, 24)
        Me.cacReligionIdNo.SuggestBoxHeight = 200
        Me.cacReligionIdNo.SuggestListOrderRule = Nothing
        Me.cacReligionIdNo.TabIndex = 4
        Me.cacReligionIdNo.TextToSearch = Nothing
        Me.cacReligionIdNo.ValueIsMandatory = false
        Me.cacReligionIdNo.ValueIsNullable = false
        Me.cacReligionIdNo.ValueIsNumeric = false
        Me.cacReligionIdNo.ValueMember = "IdNo"
        '
        'EmployeeTabControl
        '
        Me.EmployeeTabControl.Controls.Add(Me.tbpPersonal)
        Me.EmployeeTabControl.Controls.Add(Me.tbpContact)
        Me.EmployeeTabControl.Controls.Add(Me.tbpEmployment)
        Me.EmployeeTabControl.Controls.Add(Me.tbpPayroll)
        Me.EmployeeTabControl.Controls.Add(Me.tbpEarningDeductions)
        Me.EmployeeTabControl.Controls.Add(Me.tbpPhones)
        Me.EmployeeTabControl.HotTrack = true
        Me.EmployeeTabControl.Location = New System.Drawing.Point(3, 91)
        Me.EmployeeTabControl.Name = "EmployeeTabControl"
        Me.EmployeeTabControl.SelectedIndex = 0
        Me.EmployeeTabControl.Size = New System.Drawing.Size(820, 420)
        Me.EmployeeTabControl.TabIndex = 5
        '
        'tbpPersonal
        '
        Me.tbpPersonal.BackgroundImage = CType(resources.GetObject("tbpPersonal.BackgroundImage"),System.Drawing.Image)
        Me.tbpPersonal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpPersonal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tbpPersonal.Controls.Add(Me.CFlowLayout3)
        Me.tbpPersonal.Location = New System.Drawing.Point(4, 22)
        Me.tbpPersonal.Name = "tbpPersonal"
        Me.tbpPersonal.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPersonal.Size = New System.Drawing.Size(812, 394)
        Me.tbpPersonal.TabIndex = 0
        Me.tbpPersonal.Text = "Personal Information"
        Me.tbpPersonal.UseVisualStyleBackColor = true
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
        Me.CFlowLayout3.Controls.Add(Me.lblNationalIdNo)
        Me.CFlowLayout3.Controls.Add(Me.txtNationalIdNo)
        Me.CFlowLayout3.Controls.Add(Me.lblNotes)
        Me.CFlowLayout3.Controls.Add(Me.txtNotes)
        Me.CFlowLayout3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CFlowLayout3.Location = New System.Drawing.Point(3, 3)
        Me.CFlowLayout3.Margin = New System.Windows.Forms.Padding(0)
        Me.CFlowLayout3.MinimumSize = New System.Drawing.Size(430, 180)
        Me.CFlowLayout3.Name = "CFlowLayout3"
        Me.CFlowLayout3.Size = New System.Drawing.Size(802, 384)
        Me.CFlowLayout3.TabIndex = 4
        '
        'cacGender
        '
        Me.cacGender.BackColor = System.Drawing.Color.White
        Me.cacGender.ChangingSearchValueOnly = false
        Me.cacGender.CurrentSearchTerm = ""
        Me.cacGender.DefaultValue = Nothing
        Me.cacGender.DisplayMember = "Name"
        Me.cacGender.DropDownHeight = 1
        Me.cacGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacGender.EditingMode = false
        Me.cacGender.FilterRule = Nothing
        Me.CFlowLayout3.SetFlowBreak(Me.cacGender, true)
        Me.cacGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacGender.ForeColor = System.Drawing.Color.Black
        Me.cacGender.FormattingEnabled = true
        Me.cacGender.HideWhenNotEditingOrAdding = false
        Me.cacGender.IntegralHeight = false
        Me.cacGender.LinkedLabel = Me.lblMaritalStatus
        Me.cacGender.Location = New System.Drawing.Point(176, 1)
        Me.cacGender.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.cacGender.Name = "cacGender"
        Me.cacGender.OldValue = 0
        Me.cacGender.OriginalDataSource = Nothing
        Me.cacGender.OriginalList = Nothing
        Me.cacGender.OverrideDropDownStyleList = false
        Me.cacGender.PreviousSearchTerm = Nothing
        Me.cacGender.PreviousSelectedIndex = -1
        Me.cacGender.PropertySelector = Nothing
        Me.cacGender.ReadOnlyCombo = false
        Me.cacGender.SearchAnywhere = false
        Me.cacGender.Size = New System.Drawing.Size(124, 24)
        Me.cacGender.SuggestBoxHeight = 200
        Me.cacGender.SuggestListOrderRule = Nothing
        Me.cacGender.TabIndex = 1
        Me.cacGender.TextToSearch = Nothing
        Me.cacGender.ValueIsMandatory = false
        Me.cacGender.ValueIsNullable = false
        Me.cacGender.ValueIsNumeric = false
        Me.cacGender.ValueMember = "Code"
        '
        'lblNationalIdNo
        '
        Me.lblNationalIdNo.DisplayOnly = true
        Me.lblNationalIdNo.EditingMode = false
        Me.lblNationalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNationalIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNationalIdNo.Location = New System.Drawing.Point(1, 130)
        Me.lblNationalIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNationalIdNo.Name = "lblNationalIdNo"
        Me.lblNationalIdNo.Size = New System.Drawing.Size(174, 23)
        Me.lblNationalIdNo.TabIndex = 265
        Me.lblNationalIdNo.Text = "National ID/Iqama #"
        Me.lblNationalIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNationalIdNo
        '
        Me.txtNationalIdNo.BackColor = System.Drawing.Color.White
        Me.txtNationalIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNationalIdNo.ComputedValue = false
        Me.txtNationalIdNo.CustomFormat = Nothing
        Me.txtNationalIdNo.DataBoundControl = true
        Me.txtNationalIdNo.EditingMode = false
        Me.CFlowLayout3.SetFlowBreak(Me.txtNationalIdNo, true)
        Me.txtNationalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNationalIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtNationalIdNo.LinkedLabel = Me.lblNationalIdNo
        Me.txtNationalIdNo.Location = New System.Drawing.Point(177, 130)
        Me.txtNationalIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNationalIdNo.MaximumValue = Nothing
        Me.txtNationalIdNo.MinimumValue = Nothing
        Me.txtNationalIdNo.Name = "txtNationalIdNo"
        Me.txtNationalIdNo.OldValue = Nothing
        Me.txtNationalIdNo.ReadOnly = true
        Me.txtNationalIdNo.Size = New System.Drawing.Size(200, 23)
        Me.txtNationalIdNo.TabIndex = 6
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNotes.Location = New System.Drawing.Point(1, 155)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(174, 23)
        Me.lblNotes.TabIndex = 271
        Me.lblNotes.Text = "Notes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        Me.CFlowLayout3.SetFlowBreak(Me.txtNotes, true)
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Me.lblNotes
        Me.txtNotes.Location = New System.Drawing.Point(177, 155)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.Size = New System.Drawing.Size(620, 60)
        Me.txtNotes.TabIndex = 7
        Me.txtNotes.ValueIsMandatory = true
        '
        'tbpContact
        '
        Me.tbpContact.BackgroundImage = CType(resources.GetObject("tbpContact.BackgroundImage"),System.Drawing.Image)
        Me.tbpContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tbpContact.Controls.Add(Me.floContactInformation)
        Me.tbpContact.Location = New System.Drawing.Point(4, 22)
        Me.tbpContact.Name = "tbpContact"
        Me.tbpContact.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpContact.Size = New System.Drawing.Size(812, 394)
        Me.tbpContact.TabIndex = 1
        Me.tbpContact.Text = "Contact Information"
        Me.tbpContact.UseVisualStyleBackColor = true
        '
        'floContactInformation
        '
        Me.floContactInformation.BackColor = System.Drawing.Color.Transparent
        Me.floContactInformation.Controls.Add(Me.TableLayoutPanel1)
        Me.floContactInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.floContactInformation.Location = New System.Drawing.Point(3, 3)
        Me.floContactInformation.Name = "floContactInformation"
        Me.floContactInformation.Size = New System.Drawing.Size(802, 384)
        Me.floContactInformation.TabIndex = 8
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.33897!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.28814!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.52543!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.84746!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewPhoneDisplay, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtZipCode, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblZipCode, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPoBox, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPoBox, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.cacCountryCode, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCountryCode, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtProvinceState, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblProvinceState, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTownCity, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTownCity, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDistrict, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDistrict, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtStreet, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtEmail, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEmail, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStreet, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 0, 6)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(794, 382)
        Me.TableLayoutPanel1.TabIndex = 274
        '
        'DataGridViewPhoneDisplay
        '
        Me.DataGridViewPhoneDisplay.AllowUserToAddRows = false
        Me.DataGridViewPhoneDisplay.AllowUserToDeleteRows = false
        Me.DataGridViewPhoneDisplay.AllowUserToResizeColumns = false
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewPhoneDisplay.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewPhoneDisplay.AutoGenerateColumns = false
        Me.DataGridViewPhoneDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPhoneDisplay.ColumnHeadersVisible = false
        Me.DataGridViewPhoneDisplay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequencePhoneDisplay, Me.FullPhone, Me.FullPhoneAra, Me.AreaCodeDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.CountryTelIdNoDataGridViewTextBoxColumn, Me.PhoneNumberDataGridViewTextBoxColumn, Me.PhoneTypeIdNoDataGridViewTextBoxColumn})
        Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewPhoneDisplay, 2)
        Me.DataGridViewPhoneDisplay.DataInGridChanged = false
        Me.DataGridViewPhoneDisplay.DataSource = Me.bsPhones
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewPhoneDisplay.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewPhoneDisplay.DgvFooter = Nothing
        Me.DataGridViewPhoneDisplay.DisplayOnly = true
        Me.DataGridViewPhoneDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewPhoneDisplay.Ea = Nothing
        Me.DataGridViewPhoneDisplay.EditingMode = false
        Me.DataGridViewPhoneDisplay.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewPhoneDisplay.FirstRowDeletionEnabled = true
        Me.DataGridViewPhoneDisplay.FirstRowInsertionEnabled = true
        Me.DataGridViewPhoneDisplay.Location = New System.Drawing.Point(3, 174)
        Me.DataGridViewPhoneDisplay.Name = "DataGridViewPhoneDisplay"
        Me.DataGridViewPhoneDisplay.ReadOnly = true
        Me.DataGridViewPhoneDisplay.RowHeadersVisible = false
        Me.DataGridViewPhoneDisplay.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DataGridViewPhoneDisplay.SequenceColumn = "dgvSequencePhoneDisplay"
        Me.DataGridViewPhoneDisplay.SequenceFieldName = "Sequence"
        Me.DataGridViewPhoneDisplay.ShowFooter = false
        Me.DataGridViewPhoneDisplay.ShowInsertColumnWhenEditing = true
        Me.DataGridViewPhoneDisplay.Size = New System.Drawing.Size(363, 205)
        Me.DataGridViewPhoneDisplay.StartTrackingChanges = false
        Me.DataGridViewPhoneDisplay.TabIndex = 291
        '
        'dgvSequencePhoneDisplay
        '
        Me.dgvSequencePhoneDisplay.DataPropertyName = "Sequence"
        Me.dgvSequencePhoneDisplay.HeaderText = "Seq"
        Me.dgvSequencePhoneDisplay.Name = "dgvSequencePhoneDisplay"
        Me.dgvSequencePhoneDisplay.ReadOnly = true
        Me.dgvSequencePhoneDisplay.Width = 15
        '
        'FullPhone
        '
        Me.FullPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FullPhone.DataPropertyName = "FullPhone"
        Me.FullPhone.HeaderText = "FullPhone"
        Me.FullPhone.Name = "FullPhone"
        Me.FullPhone.ReadOnly = true
        '
        'FullPhoneAra
        '
        Me.FullPhoneAra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FullPhoneAra.DataPropertyName = "FullPhoneAra"
        Me.FullPhoneAra.HeaderText = "FullPhoneAra"
        Me.FullPhoneAra.Name = "FullPhoneAra"
        Me.FullPhoneAra.ReadOnly = true
        Me.FullPhoneAra.Visible = false
        '
        'AreaCodeDataGridViewTextBoxColumn
        '
        Me.AreaCodeDataGridViewTextBoxColumn.DataPropertyName = "AreaCode"
        Me.AreaCodeDataGridViewTextBoxColumn.HeaderText = "AreaCode"
        Me.AreaCodeDataGridViewTextBoxColumn.Name = "AreaCodeDataGridViewTextBoxColumn"
        Me.AreaCodeDataGridViewTextBoxColumn.ReadOnly = true
        Me.AreaCodeDataGridViewTextBoxColumn.Visible = false
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "EmployeeIdNo"
        Me.DataGridViewTextBoxColumn15.HeaderText = "EmployeeIdNo"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = true
        Me.DataGridViewTextBoxColumn15.Visible = false
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "IdNo"
        Me.DataGridViewTextBoxColumn16.HeaderText = "IdNo"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = true
        Me.DataGridViewTextBoxColumn16.Visible = false
        '
        'CountryTelIdNoDataGridViewTextBoxColumn
        '
        Me.CountryTelIdNoDataGridViewTextBoxColumn.DataPropertyName = "CountryTelIdNo"
        Me.CountryTelIdNoDataGridViewTextBoxColumn.HeaderText = "CountryTelIdNo"
        Me.CountryTelIdNoDataGridViewTextBoxColumn.Name = "CountryTelIdNoDataGridViewTextBoxColumn"
        Me.CountryTelIdNoDataGridViewTextBoxColumn.ReadOnly = true
        Me.CountryTelIdNoDataGridViewTextBoxColumn.Visible = false
        '
        'PhoneNumberDataGridViewTextBoxColumn
        '
        Me.PhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber"
        Me.PhoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber"
        Me.PhoneNumberDataGridViewTextBoxColumn.Name = "PhoneNumberDataGridViewTextBoxColumn"
        Me.PhoneNumberDataGridViewTextBoxColumn.ReadOnly = true
        Me.PhoneNumberDataGridViewTextBoxColumn.Visible = false
        '
        'PhoneTypeIdNoDataGridViewTextBoxColumn
        '
        Me.PhoneTypeIdNoDataGridViewTextBoxColumn.DataPropertyName = "PhoneTypeIdNo"
        Me.PhoneTypeIdNoDataGridViewTextBoxColumn.HeaderText = "PhoneTypeIdNo"
        Me.PhoneTypeIdNoDataGridViewTextBoxColumn.Name = "PhoneTypeIdNoDataGridViewTextBoxColumn"
        Me.PhoneTypeIdNoDataGridViewTextBoxColumn.ReadOnly = true
        Me.PhoneTypeIdNoDataGridViewTextBoxColumn.Visible = false
        '
        'bsPhones
        '
        Me.bsPhones.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.EmployeePhoneModel)
        '
        'txtZipCode
        '
        Me.txtZipCode.BackColor = System.Drawing.Color.White
        Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZipCode.ComputedValue = false
        Me.txtZipCode.CustomFormat = Nothing
        Me.txtZipCode.DataBoundControl = true
        Me.txtZipCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtZipCode.EditingMode = false
        Me.txtZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtZipCode.ForeColor = System.Drawing.Color.Black
        Me.txtZipCode.LinkedLabel = Nothing
        Me.txtZipCode.Location = New System.Drawing.Point(509, 127)
        Me.txtZipCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtZipCode.MaximumValue = Nothing
        Me.txtZipCode.MinimumValue = Nothing
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.OldValue = Nothing
        Me.txtZipCode.ReadOnly = true
        Me.txtZipCode.Size = New System.Drawing.Size(284, 23)
        Me.txtZipCode.TabIndex = 290
        '
        'lblZipCode
        '
        Me.lblZipCode.DisplayOnly = true
        Me.lblZipCode.EditingMode = false
        Me.lblZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblZipCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblZipCode.Location = New System.Drawing.Point(370, 127)
        Me.lblZipCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblZipCode.Name = "lblZipCode"
        Me.lblZipCode.Size = New System.Drawing.Size(108, 18)
        Me.lblZipCode.TabIndex = 289
        Me.lblZipCode.Text = "Zip Code"
        Me.lblZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPoBox
        '
        Me.txtPoBox.BackColor = System.Drawing.Color.White
        Me.txtPoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPoBox.ComputedValue = false
        Me.txtPoBox.CustomFormat = Nothing
        Me.txtPoBox.DataBoundControl = true
        Me.txtPoBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPoBox.EditingMode = false
        Me.txtPoBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPoBox.ForeColor = System.Drawing.Color.Black
        Me.txtPoBox.LinkedLabel = Nothing
        Me.txtPoBox.Location = New System.Drawing.Point(162, 127)
        Me.txtPoBox.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPoBox.MaximumValue = Nothing
        Me.txtPoBox.MinimumValue = Nothing
        Me.txtPoBox.Name = "txtPoBox"
        Me.txtPoBox.OldValue = Nothing
        Me.txtPoBox.ReadOnly = true
        Me.txtPoBox.Size = New System.Drawing.Size(206, 23)
        Me.txtPoBox.TabIndex = 288
        '
        'lblPoBox
        '
        Me.lblPoBox.DisplayOnly = true
        Me.lblPoBox.EditingMode = false
        Me.lblPoBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPoBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPoBox.Location = New System.Drawing.Point(1, 127)
        Me.lblPoBox.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPoBox.Name = "lblPoBox"
        Me.lblPoBox.Size = New System.Drawing.Size(116, 18)
        Me.lblPoBox.TabIndex = 287
        Me.lblPoBox.Text = "P.O. Box No."
        Me.lblPoBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacCountryCode
        '
        Me.cacCountryCode.BackColor = System.Drawing.Color.White
        Me.cacCountryCode.ChangingSearchValueOnly = false
        Me.cacCountryCode.CurrentSearchTerm = ""
        Me.cacCountryCode.DefaultValue = Nothing
        Me.cacCountryCode.DisplayMember = "Name"
        Me.cacCountryCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cacCountryCode.DropDownHeight = 1
        Me.cacCountryCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacCountryCode.EditingMode = false
        Me.cacCountryCode.FilterRule = Nothing
        Me.cacCountryCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacCountryCode.ForeColor = System.Drawing.Color.Black
        Me.cacCountryCode.FormattingEnabled = true
        Me.cacCountryCode.HideWhenNotEditingOrAdding = false
        Me.cacCountryCode.IntegralHeight = false
        Me.cacCountryCode.LinkedLabel = Nothing
        Me.cacCountryCode.Location = New System.Drawing.Point(508, 101)
        Me.cacCountryCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.cacCountryCode.Name = "cacCountryCode"
        Me.cacCountryCode.OldValue = 0
        Me.cacCountryCode.OriginalDataSource = Nothing
        Me.cacCountryCode.OriginalList = Nothing
        Me.cacCountryCode.OverrideDropDownStyleList = false
        Me.cacCountryCode.PreviousSearchTerm = Nothing
        Me.cacCountryCode.PreviousSelectedIndex = -1
        Me.cacCountryCode.PropertySelector = Nothing
        Me.cacCountryCode.ReadOnlyCombo = false
        Me.cacCountryCode.SearchAnywhere = false
        Me.cacCountryCode.Size = New System.Drawing.Size(286, 24)
        Me.cacCountryCode.SuggestBoxHeight = 200
        Me.cacCountryCode.SuggestListOrderRule = Nothing
        Me.cacCountryCode.TabIndex = 286
        Me.cacCountryCode.TextToSearch = Nothing
        Me.cacCountryCode.ValueIsMandatory = false
        Me.cacCountryCode.ValueIsNullable = false
        Me.cacCountryCode.ValueIsNumeric = false
        Me.cacCountryCode.ValueMember = "Code"
        '
        'lblCountryCode
        '
        Me.lblCountryCode.DisplayOnly = true
        Me.lblCountryCode.EditingMode = false
        Me.lblCountryCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCountryCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCountryCode.Location = New System.Drawing.Point(370, 101)
        Me.lblCountryCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCountryCode.Name = "lblCountryCode"
        Me.lblCountryCode.Size = New System.Drawing.Size(108, 18)
        Me.lblCountryCode.TabIndex = 285
        Me.lblCountryCode.Text = "Country"
        Me.lblCountryCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProvinceState
        '
        Me.txtProvinceState.BackColor = System.Drawing.Color.White
        Me.txtProvinceState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProvinceState.ComputedValue = false
        Me.txtProvinceState.CustomFormat = Nothing
        Me.txtProvinceState.DataBoundControl = true
        Me.txtProvinceState.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProvinceState.EditingMode = false
        Me.txtProvinceState.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtProvinceState.ForeColor = System.Drawing.Color.Black
        Me.txtProvinceState.LinkedLabel = Nothing
        Me.txtProvinceState.Location = New System.Drawing.Point(162, 101)
        Me.txtProvinceState.Margin = New System.Windows.Forms.Padding(1)
        Me.txtProvinceState.MaximumValue = Nothing
        Me.txtProvinceState.MinimumValue = Nothing
        Me.txtProvinceState.Name = "txtProvinceState"
        Me.txtProvinceState.OldValue = Nothing
        Me.txtProvinceState.ReadOnly = true
        Me.txtProvinceState.Size = New System.Drawing.Size(206, 23)
        Me.txtProvinceState.TabIndex = 284
        '
        'lblProvinceState
        '
        Me.lblProvinceState.DisplayOnly = true
        Me.lblProvinceState.EditingMode = false
        Me.lblProvinceState.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblProvinceState.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProvinceState.Location = New System.Drawing.Point(1, 101)
        Me.lblProvinceState.Margin = New System.Windows.Forms.Padding(1)
        Me.lblProvinceState.Name = "lblProvinceState"
        Me.lblProvinceState.Size = New System.Drawing.Size(116, 18)
        Me.lblProvinceState.TabIndex = 283
        Me.lblProvinceState.Text = "Province/State"
        Me.lblProvinceState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTownCity
        '
        Me.txtTownCity.BackColor = System.Drawing.Color.White
        Me.txtTownCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTownCity.ComputedValue = false
        Me.txtTownCity.CustomFormat = Nothing
        Me.txtTownCity.DataBoundControl = true
        Me.txtTownCity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTownCity.EditingMode = false
        Me.txtTownCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtTownCity.ForeColor = System.Drawing.Color.Black
        Me.txtTownCity.LinkedLabel = Nothing
        Me.txtTownCity.Location = New System.Drawing.Point(509, 76)
        Me.txtTownCity.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTownCity.MaximumValue = Nothing
        Me.txtTownCity.MinimumValue = Nothing
        Me.txtTownCity.Name = "txtTownCity"
        Me.txtTownCity.OldValue = Nothing
        Me.txtTownCity.ReadOnly = true
        Me.txtTownCity.Size = New System.Drawing.Size(284, 23)
        Me.txtTownCity.TabIndex = 282
        '
        'lblTownCity
        '
        Me.lblTownCity.DisplayOnly = true
        Me.lblTownCity.EditingMode = false
        Me.lblTownCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTownCity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTownCity.Location = New System.Drawing.Point(370, 76)
        Me.lblTownCity.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTownCity.Name = "lblTownCity"
        Me.lblTownCity.Size = New System.Drawing.Size(108, 18)
        Me.lblTownCity.TabIndex = 281
        Me.lblTownCity.Text = "Town/City"
        Me.lblTownCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDistrict
        '
        Me.txtDistrict.BackColor = System.Drawing.Color.White
        Me.txtDistrict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistrict.ComputedValue = false
        Me.txtDistrict.CustomFormat = Nothing
        Me.txtDistrict.DataBoundControl = true
        Me.txtDistrict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDistrict.EditingMode = false
        Me.txtDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDistrict.ForeColor = System.Drawing.Color.Black
        Me.txtDistrict.LinkedLabel = Nothing
        Me.txtDistrict.Location = New System.Drawing.Point(162, 76)
        Me.txtDistrict.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDistrict.MaximumValue = Nothing
        Me.txtDistrict.MinimumValue = Nothing
        Me.txtDistrict.Name = "txtDistrict"
        Me.txtDistrict.OldValue = Nothing
        Me.txtDistrict.ReadOnly = true
        Me.txtDistrict.Size = New System.Drawing.Size(206, 23)
        Me.txtDistrict.TabIndex = 280
        '
        'lblDistrict
        '
        Me.lblDistrict.DisplayOnly = true
        Me.lblDistrict.EditingMode = false
        Me.lblDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDistrict.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDistrict.Location = New System.Drawing.Point(1, 76)
        Me.lblDistrict.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDistrict.Name = "lblDistrict"
        Me.lblDistrict.Size = New System.Drawing.Size(116, 18)
        Me.lblDistrict.TabIndex = 279
        Me.lblDistrict.Text = "District"
        Me.lblDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStreet
        '
        Me.txtStreet.BackColor = System.Drawing.Color.White
        Me.txtStreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtStreet, 3)
        Me.txtStreet.ComputedValue = false
        Me.txtStreet.CustomFormat = Nothing
        Me.txtStreet.DataBoundControl = true
        Me.txtStreet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStreet.EditingMode = false
        Me.txtStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtStreet.ForeColor = System.Drawing.Color.Black
        Me.txtStreet.LinkedLabel = Nothing
        Me.txtStreet.Location = New System.Drawing.Point(162, 51)
        Me.txtStreet.Margin = New System.Windows.Forms.Padding(1)
        Me.txtStreet.MaximumValue = Nothing
        Me.txtStreet.MinimumValue = Nothing
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.OldValue = Nothing
        Me.txtStreet.ReadOnly = true
        Me.txtStreet.Size = New System.Drawing.Size(631, 23)
        Me.txtStreet.TabIndex = 278
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.White
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtEmail, 3)
        Me.txtEmail.ComputedValue = false
        Me.txtEmail.CustomFormat = Nothing
        Me.txtEmail.DataBoundControl = true
        Me.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEmail.EditingMode = false
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtEmail.ForeColor = System.Drawing.Color.Black
        Me.txtEmail.LinkedLabel = Nothing
        Me.txtEmail.Location = New System.Drawing.Point(162, 1)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEmail.MaximumValue = Nothing
        Me.txtEmail.MinimumValue = Nothing
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.OldValue = Nothing
        Me.txtEmail.ReadOnly = true
        Me.txtEmail.Size = New System.Drawing.Size(631, 23)
        Me.txtEmail.TabIndex = 274
        '
        'CLabel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel1, 4)
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel1.Location = New System.Drawing.Point(1, 26)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(792, 23)
        Me.CLabel1.TabIndex = 213
        Me.CLabel1.Text = "Home Address"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmail
        '
        Me.lblEmail.DisplayOnly = true
        Me.lblEmail.EditingMode = false
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEmail.Location = New System.Drawing.Point(1, 1)
        Me.lblEmail.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(125, 23)
        Me.lblEmail.TabIndex = 212
        Me.lblEmail.Text = "E-mail Address"
        Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStreet
        '
        Me.lblStreet.AutoSize = true
        Me.lblStreet.DisplayOnly = true
        Me.lblStreet.EditingMode = false
        Me.lblStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblStreet.Location = New System.Drawing.Point(1, 51)
        Me.lblStreet.Margin = New System.Windows.Forms.Padding(1)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(46, 17)
        Me.lblStreet.TabIndex = 277
        Me.lblStreet.Text = "Street"
        Me.lblStreet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CLabel3
        '
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel3.Location = New System.Drawing.Point(1, 152)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(107, 18)
        Me.CLabel3.TabIndex = 292
        Me.CLabel3.Text = "Phones:"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbpEmployment
        '
        Me.tbpEmployment.Controls.Add(Me.CFlowLayout5)
        Me.tbpEmployment.Location = New System.Drawing.Point(4, 22)
        Me.tbpEmployment.Name = "tbpEmployment"
        Me.tbpEmployment.Size = New System.Drawing.Size(812, 394)
        Me.tbpEmployment.TabIndex = 3
        Me.tbpEmployment.Text = "Employment Information"
        Me.tbpEmployment.UseVisualStyleBackColor = true
        '
        'CFlowLayout5
        '
        Me.CFlowLayout5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CFlowLayout5.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout5.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
        Me.CFlowLayout5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CFlowLayout5.Controls.Add(Me.lblHiredDate)
        Me.CFlowLayout5.Controls.Add(Me.dtpHiredDate)
        Me.CFlowLayout5.Controls.Add(Me.lblReleasedDate)
        Me.CFlowLayout5.Controls.Add(Me.dtpReleasedDate)
        Me.CFlowLayout5.Controls.Add(Me.lblDepartmentIdNo)
        Me.CFlowLayout5.Controls.Add(Me.cacDepartmentIdNo)
        Me.CFlowLayout5.Controls.Add(Me.lblDesignationIdNo)
        Me.CFlowLayout5.Controls.Add(Me.cacDesignationIdNo)
        Me.CFlowLayout5.Controls.Add(Me.lblActive)
        Me.CFlowLayout5.Controls.Add(Me.chkActive)
        Me.CFlowLayout5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CFlowLayout5.Location = New System.Drawing.Point(0, 0)
        Me.CFlowLayout5.Name = "CFlowLayout5"
        Me.CFlowLayout5.Padding = New System.Windows.Forms.Padding(3)
        Me.CFlowLayout5.Size = New System.Drawing.Size(812, 394)
        Me.CFlowLayout5.TabIndex = 286
        '
        'lblHiredDate
        '
        Me.lblHiredDate.DisplayOnly = true
        Me.lblHiredDate.EditingMode = false
        Me.lblHiredDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblHiredDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHiredDate.Location = New System.Drawing.Point(4, 4)
        Me.lblHiredDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblHiredDate.Name = "lblHiredDate"
        Me.lblHiredDate.Size = New System.Drawing.Size(174, 24)
        Me.lblHiredDate.TabIndex = 288
        Me.lblHiredDate.Text = "Hired Date"
        Me.lblHiredDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpHiredDate
        '
        Me.dtpHiredDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpHiredDate.DefaultValue = Nothing
        Me.dtpHiredDate.DisplayOnly = false
        Me.dtpHiredDate.DtpDefaultValue = Nothing
        Me.dtpHiredDate.EditingMode = false
        Me.dtpHiredDate.EditsAllowed = false
        Me.CFlowLayout5.SetFlowBreak(Me.dtpHiredDate, true)
        Me.dtpHiredDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dtpHiredDate.ForeColor = System.Drawing.Color.Black
        Me.dtpHiredDate.LinkedLabel = Me.lblHiredDate
        Me.dtpHiredDate.Location = New System.Drawing.Point(179, 3)
        Me.dtpHiredDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpHiredDate.Name = "dtpHiredDate"
        Me.dtpHiredDate.ReadOnlyDp = false
        Me.dtpHiredDate.SecurityKey = Nothing
        Me.dtpHiredDate.ShowLongDate = false
        Me.dtpHiredDate.ShowTime = false
        Me.dtpHiredDate.Size = New System.Drawing.Size(123, 24)
        Me.dtpHiredDate.TabIndex = 1
        Me.dtpHiredDate.TargetCalendar = CType(resources.GetObject("dtpHiredDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpHiredDate.Value = Nothing
        Me.dtpHiredDate.ValueIsMandatory = false
        Me.dtpHiredDate.ValueIsNullable = false
        '
        'lblReleasedDate
        '
        Me.lblReleasedDate.DisplayOnly = true
        Me.lblReleasedDate.EditingMode = false
        Me.lblReleasedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblReleasedDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReleasedDate.Location = New System.Drawing.Point(4, 30)
        Me.lblReleasedDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblReleasedDate.Name = "lblReleasedDate"
        Me.lblReleasedDate.Size = New System.Drawing.Size(174, 24)
        Me.lblReleasedDate.TabIndex = 289
        Me.lblReleasedDate.Text = "Released Date"
        Me.lblReleasedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpReleasedDate
        '
        Me.dtpReleasedDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpReleasedDate.DefaultValue = Nothing
        Me.dtpReleasedDate.DisplayOnly = false
        Me.dtpReleasedDate.DtpDefaultValue = Nothing
        Me.dtpReleasedDate.EditingMode = false
        Me.dtpReleasedDate.EditsAllowed = false
        Me.CFlowLayout5.SetFlowBreak(Me.dtpReleasedDate, true)
        Me.dtpReleasedDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dtpReleasedDate.ForeColor = System.Drawing.Color.Black
        Me.dtpReleasedDate.LinkedLabel = Me.lblReleasedDate
        Me.dtpReleasedDate.Location = New System.Drawing.Point(179, 29)
        Me.dtpReleasedDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpReleasedDate.Name = "dtpReleasedDate"
        Me.dtpReleasedDate.ReadOnlyDp = false
        Me.dtpReleasedDate.SecurityKey = Nothing
        Me.dtpReleasedDate.ShowLongDate = false
        Me.dtpReleasedDate.ShowTime = false
        Me.dtpReleasedDate.Size = New System.Drawing.Size(123, 24)
        Me.dtpReleasedDate.TabIndex = 2
        Me.dtpReleasedDate.TargetCalendar = CType(resources.GetObject("dtpReleasedDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpReleasedDate.Value = Nothing
        Me.dtpReleasedDate.ValueIsMandatory = false
        Me.dtpReleasedDate.ValueIsNullable = false
        '
        'lblDepartmentIdNo
        '
        Me.lblDepartmentIdNo.DisplayOnly = true
        Me.lblDepartmentIdNo.EditingMode = false
        Me.lblDepartmentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDepartmentIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDepartmentIdNo.Location = New System.Drawing.Point(4, 56)
        Me.lblDepartmentIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDepartmentIdNo.Name = "lblDepartmentIdNo"
        Me.lblDepartmentIdNo.Size = New System.Drawing.Size(174, 24)
        Me.lblDepartmentIdNo.TabIndex = 284
        Me.lblDepartmentIdNo.Text = "Department"
        Me.lblDepartmentIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacDepartmentIdNo
        '
        Me.cacDepartmentIdNo.BackColor = System.Drawing.Color.White
        Me.cacDepartmentIdNo.ChangingSearchValueOnly = false
        Me.cacDepartmentIdNo.CurrentSearchTerm = ""
        Me.cacDepartmentIdNo.DefaultValue = Nothing
        Me.cacDepartmentIdNo.DisplayMember = "Name"
        Me.cacDepartmentIdNo.DropDownHeight = 1
        Me.cacDepartmentIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacDepartmentIdNo.EditingMode = false
        Me.cacDepartmentIdNo.FilterRule = Nothing
        Me.CFlowLayout5.SetFlowBreak(Me.cacDepartmentIdNo, true)
        Me.cacDepartmentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacDepartmentIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacDepartmentIdNo.FormattingEnabled = true
        Me.cacDepartmentIdNo.HideWhenNotEditingOrAdding = false
        Me.cacDepartmentIdNo.IntegralHeight = false
        Me.cacDepartmentIdNo.LinkedLabel = Me.lblDepartmentIdNo
        Me.cacDepartmentIdNo.Location = New System.Drawing.Point(179, 56)
        Me.cacDepartmentIdNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.cacDepartmentIdNo.Name = "cacDepartmentIdNo"
        Me.cacDepartmentIdNo.OldValue = 0
        Me.cacDepartmentIdNo.OriginalDataSource = Nothing
        Me.cacDepartmentIdNo.OriginalList = Nothing
        Me.cacDepartmentIdNo.OverrideDropDownStyleList = false
        Me.cacDepartmentIdNo.PreviousSearchTerm = Nothing
        Me.cacDepartmentIdNo.PreviousSelectedIndex = -1
        Me.cacDepartmentIdNo.PropertySelector = Nothing
        Me.cacDepartmentIdNo.ReadOnlyCombo = false
        Me.cacDepartmentIdNo.SearchAnywhere = false
        Me.cacDepartmentIdNo.Size = New System.Drawing.Size(279, 24)
        Me.cacDepartmentIdNo.SuggestBoxHeight = 200
        Me.cacDepartmentIdNo.SuggestListOrderRule = Nothing
        Me.cacDepartmentIdNo.TabIndex = 3
        Me.cacDepartmentIdNo.TextToSearch = Nothing
        Me.cacDepartmentIdNo.ValueIsMandatory = false
        Me.cacDepartmentIdNo.ValueIsNullable = false
        Me.cacDepartmentIdNo.ValueIsNumeric = false
        Me.cacDepartmentIdNo.ValueMember = "IdNo"
        '
        'lblDesignationIdNo
        '
        Me.lblDesignationIdNo.DisplayOnly = true
        Me.lblDesignationIdNo.EditingMode = false
        Me.lblDesignationIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDesignationIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDesignationIdNo.Location = New System.Drawing.Point(4, 82)
        Me.lblDesignationIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDesignationIdNo.Name = "lblDesignationIdNo"
        Me.lblDesignationIdNo.Size = New System.Drawing.Size(175, 24)
        Me.lblDesignationIdNo.TabIndex = 285
        Me.lblDesignationIdNo.Text = "Designation"
        Me.lblDesignationIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacDesignationIdNo
        '
        Me.cacDesignationIdNo.BackColor = System.Drawing.Color.White
        Me.cacDesignationIdNo.ChangingSearchValueOnly = false
        Me.cacDesignationIdNo.CurrentSearchTerm = ""
        Me.cacDesignationIdNo.DefaultValue = Nothing
        Me.cacDesignationIdNo.DisplayMember = "Name"
        Me.cacDesignationIdNo.DropDownHeight = 1
        Me.cacDesignationIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacDesignationIdNo.EditingMode = false
        Me.cacDesignationIdNo.FilterRule = Nothing
        Me.CFlowLayout5.SetFlowBreak(Me.cacDesignationIdNo, true)
        Me.cacDesignationIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacDesignationIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacDesignationIdNo.FormattingEnabled = true
        Me.cacDesignationIdNo.HideWhenNotEditingOrAdding = false
        Me.cacDesignationIdNo.IntegralHeight = false
        Me.cacDesignationIdNo.LinkedLabel = Me.lblDesignationIdNo
        Me.cacDesignationIdNo.Location = New System.Drawing.Point(180, 82)
        Me.cacDesignationIdNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.cacDesignationIdNo.Name = "cacDesignationIdNo"
        Me.cacDesignationIdNo.OldValue = 0
        Me.cacDesignationIdNo.OriginalDataSource = Nothing
        Me.cacDesignationIdNo.OriginalList = Nothing
        Me.cacDesignationIdNo.OverrideDropDownStyleList = false
        Me.cacDesignationIdNo.PreviousSearchTerm = Nothing
        Me.cacDesignationIdNo.PreviousSelectedIndex = -1
        Me.cacDesignationIdNo.PropertySelector = Nothing
        Me.cacDesignationIdNo.ReadOnlyCombo = false
        Me.cacDesignationIdNo.SearchAnywhere = false
        Me.cacDesignationIdNo.Size = New System.Drawing.Size(223, 24)
        Me.cacDesignationIdNo.SuggestBoxHeight = 200
        Me.cacDesignationIdNo.SuggestListOrderRule = Nothing
        Me.cacDesignationIdNo.TabIndex = 4
        Me.cacDesignationIdNo.TextToSearch = Nothing
        Me.cacDesignationIdNo.ValueIsMandatory = false
        Me.cacDesignationIdNo.ValueIsNullable = false
        Me.cacDesignationIdNo.ValueIsNumeric = false
        Me.cacDesignationIdNo.ValueMember = "IdNo"
        '
        'lblActive
        '
        Me.lblActive.DisplayOnly = true
        Me.lblActive.EditingMode = false
        Me.lblActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblActive.Location = New System.Drawing.Point(4, 108)
        Me.lblActive.Margin = New System.Windows.Forms.Padding(1)
        Me.lblActive.Name = "lblActive"
        Me.lblActive.Size = New System.Drawing.Size(175, 24)
        Me.lblActive.TabIndex = 277
        Me.lblActive.Text = "Active?"
        Me.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkActive
        '
        Me.chkActive.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkActive.AutoCheck = false
        Me.chkActive.BackColor = System.Drawing.Color.White
        Me.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActive.DisplayOnly = false
        Me.chkActive.EditingMode = false
        Me.chkActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CFlowLayout5.SetFlowBreak(Me.chkActive, true)
        Me.chkActive.ForeColor = System.Drawing.Color.Black
        Me.chkActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkActive.LinkedLabel = Me.lblActive
        Me.chkActive.Location = New System.Drawing.Point(181, 108)
        Me.chkActive.Margin = New System.Windows.Forms.Padding(1)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.NoLabel = false
        Me.chkActive.OldValue = ""
        Me.chkActive.Size = New System.Drawing.Size(25, 21)
        Me.chkActive.TabIndex = 5
        Me.chkActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActive.UseVisualStyleBackColor = false
        '
        'tbpPayroll
        '
        Me.tbpPayroll.BackgroundImage = CType(resources.GetObject("tbpPayroll.BackgroundImage"),System.Drawing.Image)
        Me.tbpPayroll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpPayroll.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tbpPayroll.Controls.Add(Me.CFlowLayout6)
        Me.tbpPayroll.Location = New System.Drawing.Point(4, 22)
        Me.tbpPayroll.Name = "tbpPayroll"
        Me.tbpPayroll.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPayroll.Size = New System.Drawing.Size(812, 394)
        Me.tbpPayroll.TabIndex = 2
        Me.tbpPayroll.Text = "Payroll Information"
        Me.tbpPayroll.UseVisualStyleBackColor = true
        '
        'tbpEarningDeductions
        '
        Me.tbpEarningDeductions.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
        Me.tbpEarningDeductions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpEarningDeductions.Controls.Add(Me.TableLayoutPanel2)
        Me.tbpEarningDeductions.Location = New System.Drawing.Point(4, 22)
        Me.tbpEarningDeductions.Name = "tbpEarningDeductions"
        Me.tbpEarningDeductions.Size = New System.Drawing.Size(812, 394)
        Me.tbpEarningDeductions.TabIndex = 4
        Me.tbpEarningDeductions.Text = "Earnings & Deductions"
        Me.tbpEarningDeductions.UseVisualStyleBackColor = true
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblNetTotal, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.DataGridViewEarnings, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.CLabel2, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DataGridViewDeductions, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblEarnings, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtNetTotal, 1, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.970179!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.02982!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(812, 394)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'lblNetTotal
        '
        Me.lblNetTotal.AutoSize = true
        Me.lblNetTotal.DisplayOnly = true
        Me.lblNetTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNetTotal.EditingMode = false
        Me.lblNetTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNetTotal.Location = New System.Drawing.Point(1, 369)
        Me.lblNetTotal.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNetTotal.Name = "lblNetTotal"
        Me.lblNetTotal.Size = New System.Drawing.Size(404, 24)
        Me.lblNetTotal.TabIndex = 4
        Me.lblNetTotal.Text = "Net Total:"
        Me.lblNetTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridViewEarnings
        '
        Me.DataGridViewEarnings.AllowUserToOrderColumns = true
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewEarnings.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewEarnings.AutoGenerateColumns = false
        Me.DataGridViewEarnings.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewEarnings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewEarnings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceEarning, Me.dgvEarningIdNo, Me.dgvEarningAmount, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.DataGridViewEarnings.DataInGridChanged = false
        Me.DataGridViewEarnings.DataSource = Me.bsEarnings
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewEarnings.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewEarnings.DgvFooter = Nothing
        Me.DataGridViewEarnings.DisplayOnly = false
        Me.DataGridViewEarnings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewEarnings.Ea = EventAggregator1
        Me.DataGridViewEarnings.EditingMode = false
        Me.DataGridViewEarnings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewEarnings.FirstRowDeletionEnabled = true
        Me.DataGridViewEarnings.FirstRowInsertionEnabled = true
        Me.DataGridViewEarnings.Location = New System.Drawing.Point(3, 21)
        Me.DataGridViewEarnings.Name = "DataGridViewEarnings"
        Me.DataGridViewEarnings.ReadOnly = true
        Me.DataGridViewEarnings.SequenceColumn = "dgvSequenceEarning"
        Me.DataGridViewEarnings.SequenceFieldName = "Sequence"
        Me.DataGridViewEarnings.ShowFooter = true
        Me.DataGridViewEarnings.ShowInsertColumnWhenEditing = true
        Me.DataGridViewEarnings.Size = New System.Drawing.Size(400, 344)
        Me.DataGridViewEarnings.StartTrackingChanges = false
        Me.DataGridViewEarnings.TabIndex = 0
        '
        'dgvSequenceEarning
        '
        Me.dgvSequenceEarning.DataPropertyName = "Sequence"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dgvSequenceEarning.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSequenceEarning.EditingMode = false
        Me.dgvSequenceEarning.HeaderText = "Seq"
        Me.dgvSequenceEarning.MinimumWidth = 30
        Me.dgvSequenceEarning.Name = "dgvSequenceEarning"
        Me.dgvSequenceEarning.ReadOnly = true
        Me.dgvSequenceEarning.Width = 30
        '
        'dgvEarningIdNo
        '
        Me.dgvEarningIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvEarningIdNo.DataPropertyName = "EarningIdNo"
        Me.dgvEarningIdNo.HeaderText = "EarningIdNo"
        Me.dgvEarningIdNo.MinimumWidth = 200
        Me.dgvEarningIdNo.Name = "dgvEarningIdNo"
        Me.dgvEarningIdNo.ReadOnly = true
        Me.dgvEarningIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEarningIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvEarningAmount
        '
        Me.dgvEarningAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.Format = "###,##0.00"
        Me.dgvEarningAmount.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvEarningAmount.EditingMode = false
        Me.dgvEarningAmount.HeaderText = "Amount"
        Me.dgvEarningAmount.MinimumWidth = 80
        Me.dgvEarningAmount.Name = "dgvEarningAmount"
        Me.dgvEarningAmount.ReadOnly = true
        Me.dgvEarningAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEarningAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvEarningAmount.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "EarningCode"
        Me.DataGridViewTextBoxColumn3.HeaderText = "EarningCode"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = true
        Me.DataGridViewTextBoxColumn3.Visible = false
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "EarningName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "EarningName"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = true
        Me.DataGridViewTextBoxColumn4.Visible = false
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "EarningNameAra"
        Me.DataGridViewTextBoxColumn5.HeaderText = "EarningNameAra"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = true
        Me.DataGridViewTextBoxColumn5.Visible = false
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "EarningType"
        Me.DataGridViewTextBoxColumn6.HeaderText = "EarningType"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = true
        Me.DataGridViewTextBoxColumn6.Visible = false
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "EmployeeIdNo"
        Me.DataGridViewTextBoxColumn7.HeaderText = "EmployeeIdNo"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = true
        Me.DataGridViewTextBoxColumn7.Visible = false
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "IdNo"
        Me.DataGridViewTextBoxColumn8.HeaderText = "IdNo"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = true
        Me.DataGridViewTextBoxColumn8.Visible = false
        '
        'CLabel2
        '
        Me.CLabel2.AutoSize = true
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(407, 1)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(141, 16)
        Me.CLabel2.TabIndex = 3
        Me.CLabel2.Text = "Regular Deductions: "
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewDeductions
        '
        Me.DataGridViewDeductions.AllowUserToOrderColumns = true
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewDeductions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewDeductions.AutoGenerateColumns = false
        Me.DataGridViewDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDeductions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceDeduction, Me.dgvDeductionIdNo, Me.dgvDeductionAmount, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14})
        Me.DataGridViewDeductions.DataInGridChanged = false
        Me.DataGridViewDeductions.DataSource = Me.bsDeductions
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewDeductions.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewDeductions.DgvFooter = Nothing
        Me.DataGridViewDeductions.DisplayOnly = false
        Me.DataGridViewDeductions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewDeductions.Ea = EventAggregator2
        Me.DataGridViewDeductions.EditingMode = false
        Me.DataGridViewDeductions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewDeductions.FirstRowDeletionEnabled = true
        Me.DataGridViewDeductions.FirstRowInsertionEnabled = true
        Me.DataGridViewDeductions.Location = New System.Drawing.Point(409, 21)
        Me.DataGridViewDeductions.Name = "DataGridViewDeductions"
        Me.DataGridViewDeductions.ReadOnly = true
        Me.DataGridViewDeductions.SequenceColumn = "dgvSequenceDeduction"
        Me.DataGridViewDeductions.SequenceFieldName = "Sequence"
        Me.DataGridViewDeductions.ShowFooter = false
        Me.DataGridViewDeductions.ShowInsertColumnWhenEditing = true
        Me.DataGridViewDeductions.Size = New System.Drawing.Size(400, 344)
        Me.DataGridViewDeductions.StartTrackingChanges = false
        Me.DataGridViewDeductions.TabIndex = 1
        '
        'dgvSequenceDeduction
        '
        Me.dgvSequenceDeduction.DataPropertyName = "Sequence"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        Me.dgvSequenceDeduction.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvSequenceDeduction.EditingMode = false
        Me.dgvSequenceDeduction.HeaderText = "Seq"
        Me.dgvSequenceDeduction.MinimumWidth = 30
        Me.dgvSequenceDeduction.Name = "dgvSequenceDeduction"
        Me.dgvSequenceDeduction.ReadOnly = true
        Me.dgvSequenceDeduction.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequenceDeduction.Width = 30
        '
        'dgvDeductionIdNo
        '
        Me.dgvDeductionIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvDeductionIdNo.DataPropertyName = "DeductionIdNo"
        Me.dgvDeductionIdNo.HeaderText = "DeductionIdNo"
        Me.dgvDeductionIdNo.MinimumWidth = 200
        Me.dgvDeductionIdNo.Name = "dgvDeductionIdNo"
        Me.dgvDeductionIdNo.ReadOnly = true
        Me.dgvDeductionIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDeductionIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvDeductionAmount
        '
        Me.dgvDeductionAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.Format = "###,##0.00"
        Me.dgvDeductionAmount.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvDeductionAmount.EditingMode = false
        Me.dgvDeductionAmount.HeaderText = "Amount"
        Me.dgvDeductionAmount.MinimumWidth = 80
        Me.dgvDeductionAmount.Name = "dgvDeductionAmount"
        Me.dgvDeductionAmount.ReadOnly = true
        Me.dgvDeductionAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDeductionAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvDeductionAmount.Width = 80
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "DeductionCode"
        Me.DataGridViewTextBoxColumn9.HeaderText = "DeductionCode"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = true
        Me.DataGridViewTextBoxColumn9.Visible = false
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "DeductionName"
        Me.DataGridViewTextBoxColumn10.HeaderText = "DeductionName"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = true
        Me.DataGridViewTextBoxColumn10.Visible = false
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "DeductionNameAra"
        Me.DataGridViewTextBoxColumn11.HeaderText = "DeductionNameAra"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = true
        Me.DataGridViewTextBoxColumn11.Visible = false
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "DeductionType"
        Me.DataGridViewTextBoxColumn12.HeaderText = "DeductionType"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = true
        Me.DataGridViewTextBoxColumn12.Visible = false
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "EmployeeIdNo"
        Me.DataGridViewTextBoxColumn13.HeaderText = "EmployeeIdNo"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = true
        Me.DataGridViewTextBoxColumn13.Visible = false
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "IdNo"
        Me.DataGridViewTextBoxColumn14.HeaderText = "IdNo"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = true
        Me.DataGridViewTextBoxColumn14.Visible = false
        '
        'lblEarnings
        '
        Me.lblEarnings.AutoSize = true
        Me.lblEarnings.DisplayOnly = true
        Me.lblEarnings.EditingMode = false
        Me.lblEarnings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEarnings.Location = New System.Drawing.Point(1, 1)
        Me.lblEarnings.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEarnings.Name = "lblEarnings"
        Me.lblEarnings.Size = New System.Drawing.Size(122, 16)
        Me.lblEarnings.TabIndex = 2
        Me.lblEarnings.Text = "Regular Earnings:"
        Me.lblEarnings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNetTotal
        '
        Me.txtNetTotal.BackColor = System.Drawing.Color.White
        Me.txtNetTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNetTotal.ComputedValue = false
        Me.txtNetTotal.CustomFormat = Nothing
        Me.txtNetTotal.DataBoundControl = true
        Me.txtNetTotal.EditingMode = true
        Me.txtNetTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNetTotal.ForeColor = System.Drawing.Color.Black
        Me.txtNetTotal.LinkedLabel = Nothing
        Me.txtNetTotal.Location = New System.Drawing.Point(407, 369)
        Me.txtNetTotal.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNetTotal.MaximumValue = Nothing
        Me.txtNetTotal.MinimumValue = Nothing
        Me.txtNetTotal.Name = "txtNetTotal"
        Me.txtNetTotal.OldValue = Nothing
        Me.txtNetTotal.Size = New System.Drawing.Size(100, 23)
        Me.txtNetTotal.TabIndex = 5
        Me.txtNetTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbpPhones
        '
        Me.tbpPhones.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
        Me.tbpPhones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpPhones.Controls.Add(Me.DataGridViewPhones)
        Me.tbpPhones.Location = New System.Drawing.Point(4, 22)
        Me.tbpPhones.Name = "tbpPhones"
        Me.tbpPhones.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPhones.Size = New System.Drawing.Size(812, 394)
        Me.tbpPhones.TabIndex = 5
        Me.tbpPhones.Text = "Phones"
        Me.tbpPhones.UseVisualStyleBackColor = true
        '
        'DataGridViewPhones
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewPhones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewPhones.AutoGenerateColumns = false
        Me.DataGridViewPhones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPhones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvPhoneTypeIdNo, Me.dgvCountryTelIdNo, Me.dgvAreaCode, Me.PhoneNumber, Me.dgvFullPhone, Me.dgvFullPhoneAra, Me.dgvCountryTelCode, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.DataGridViewPhones.DataInGridChanged = false
        Me.DataGridViewPhones.DataSource = Me.bsPhones
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewPhones.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewPhones.DgvFooter = Nothing
        Me.DataGridViewPhones.DisplayOnly = false
        Me.DataGridViewPhones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewPhones.Ea = Nothing
        Me.DataGridViewPhones.EditingMode = false
        Me.DataGridViewPhones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewPhones.FirstRowDeletionEnabled = true
        Me.DataGridViewPhones.FirstRowInsertionEnabled = true
        Me.DataGridViewPhones.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewPhones.Name = "DataGridViewPhones"
        Me.DataGridViewPhones.ReadOnly = true
        Me.DataGridViewPhones.SequenceColumn = "dgvSequence"
        Me.DataGridViewPhones.SequenceFieldName = "Sequence"
        Me.DataGridViewPhones.ShowFooter = false
        Me.DataGridViewPhones.ShowInsertColumnWhenEditing = true
        Me.DataGridViewPhones.Size = New System.Drawing.Size(806, 388)
        Me.DataGridViewPhones.StartTrackingChanges = false
        Me.DataGridViewPhones.TabIndex = 273
        '
        'dgvSequence
        '
        Me.dgvSequence.DataPropertyName = "Sequence"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvSequence.DisplayOnly = true
        Me.dgvSequence.EditingMode = false
        Me.dgvSequence.HeaderText = "Seq"
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.ReadOnly = true
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequence.Width = 40
        '
        'dgvPhoneTypeIdNo
        '
        Me.dgvPhoneTypeIdNo.DataPropertyName = "PhoneTypeIdNo"
        Me.dgvPhoneTypeIdNo.HeaderText = "Phone Type Code - Name"
        Me.dgvPhoneTypeIdNo.Name = "dgvPhoneTypeIdNo"
        Me.dgvPhoneTypeIdNo.ReadOnly = true
        Me.dgvPhoneTypeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPhoneTypeIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvCountryTelIdNo
        '
        Me.dgvCountryTelIdNo.DataPropertyName = "CountryTelIdNo"
        Me.dgvCountryTelIdNo.HeaderText = "Country Phone Code"
        Me.dgvCountryTelIdNo.MinimumWidth = 200
        Me.dgvCountryTelIdNo.Name = "dgvCountryTelIdNo"
        Me.dgvCountryTelIdNo.ReadOnly = true
        Me.dgvCountryTelIdNo.Width = 200
        '
        'dgvAreaCode
        '
        Me.dgvAreaCode.DataPropertyName = "AreaCode"
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        Me.dgvAreaCode.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvAreaCode.EditingMode = false
        Me.dgvAreaCode.HeaderText = "Area Code"
        Me.dgvAreaCode.Name = "dgvAreaCode"
        Me.dgvAreaCode.ReadOnly = true
        Me.dgvAreaCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAreaCode.Width = 60
        '
        'PhoneNumber
        '
        Me.PhoneNumber.DataPropertyName = "PhoneNumber"
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        Me.PhoneNumber.DefaultCellStyle = DataGridViewCellStyle14
        Me.PhoneNumber.EditingMode = false
        Me.PhoneNumber.HeaderText = "PhoneNumber"
        Me.PhoneNumber.Name = "PhoneNumber"
        Me.PhoneNumber.ReadOnly = true
        '
        'dgvFullPhone
        '
        Me.dgvFullPhone.DataPropertyName = "FullPhone"
        Me.dgvFullPhone.HeaderText = "FullPhone"
        Me.dgvFullPhone.Name = "dgvFullPhone"
        Me.dgvFullPhone.ReadOnly = true
        Me.dgvFullPhone.Visible = false
        Me.dgvFullPhone.Width = 200
        '
        'dgvFullPhoneAra
        '
        Me.dgvFullPhoneAra.DataPropertyName = "FullPhoneAra"
        Me.dgvFullPhoneAra.HeaderText = "FullPhoneAra"
        Me.dgvFullPhoneAra.Name = "dgvFullPhoneAra"
        Me.dgvFullPhoneAra.ReadOnly = true
        Me.dgvFullPhoneAra.Visible = false
        Me.dgvFullPhoneAra.Width = 200
        '
        'dgvCountryTelCode
        '
        Me.dgvCountryTelCode.DataPropertyName = "CountryTelCode"
        Me.dgvCountryTelCode.HeaderText = "CountryTelCode"
        Me.dgvCountryTelCode.Name = "dgvCountryTelCode"
        Me.dgvCountryTelCode.ReadOnly = true
        Me.dgvCountryTelCode.Visible = false
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "EmployeeIdNo"
        Me.DataGridViewTextBoxColumn1.HeaderText = "EmployeeIdNo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = true
        Me.DataGridViewTextBoxColumn1.Visible = false
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "IdNo"
        Me.DataGridViewTextBoxColumn2.HeaderText = "IdNo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = true
        Me.DataGridViewTextBoxColumn2.Visible = false
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(183, 23)
        Me.lblIdNo.TabIndex = 152
        Me.lblIdNo.Text = "Employee Id No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.Location = New System.Drawing.Point(186, 1)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIdNo.TabIndex = 151
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblEmployeeCode
        '
        Me.lblEmployeeCode.DisplayOnly = true
        Me.lblEmployeeCode.EditingMode = false
        Me.lblEmployeeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
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
        Me.txtEmployeeCode.ComputedValue = false
        Me.txtEmployeeCode.CustomFormat = Nothing
        Me.txtEmployeeCode.DataBoundControl = true
        Me.txtEmployeeCode.EditingMode = false
        Me.CFlowLayout4.SetFlowBreak(Me.txtEmployeeCode, true)
        Me.txtEmployeeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtEmployeeCode.ForeColor = System.Drawing.Color.Black
        Me.txtEmployeeCode.LinkedLabel = Me.lblEmployeeCode
        Me.txtEmployeeCode.Location = New System.Drawing.Point(740, 1)
        Me.txtEmployeeCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEmployeeCode.MaximumValue = Nothing
        Me.txtEmployeeCode.MinimumValue = Nothing
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.OldValue = Nothing
        Me.txtEmployeeCode.ReadOnly = true
        Me.txtEmployeeCode.Size = New System.Drawing.Size(66, 23)
        Me.txtEmployeeCode.TabIndex = 153
        Me.txtEmployeeCode.ValueIsMandatory = true
        '
        'floMain
        '
        Me.floMain.BackColor = System.Drawing.Color.Transparent
        Me.floMain.Controls.Add(Me.CFlowLayout4)
        Me.floMain.Controls.Add(Me.EmployeeTabControl)
        Me.floMain.Dock = System.Windows.Forms.DockStyle.Left
        Me.floMain.Location = New System.Drawing.Point(300, 53)
        Me.floMain.Name = "floMain"
        Me.floMain.Size = New System.Drawing.Size(827, 514)
        Me.floMain.TabIndex = 6
        '
        'CFlowLayout4
        '
        Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout4.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout4.Controls.Add(Me.TxtIdNo)
        Me.CFlowLayout4.Controls.Add(Me.lblEmployeeCode)
        Me.CFlowLayout4.Controls.Add(Me.txtEmployeeCode)
        Me.CFlowLayout4.Controls.Add(Me.lblEmployeeName)
        Me.CFlowLayout4.Controls.Add(Me.txtEmployeeName)
        Me.CFlowLayout4.Controls.Add(Me.lblEmployeeNameAra)
        Me.CFlowLayout4.Controls.Add(Me.txtEmployeeNameAra)
        Me.CFlowLayout4.Location = New System.Drawing.Point(3, 3)
        Me.CFlowLayout4.Name = "CFlowLayout4"
        Me.CFlowLayout4.Size = New System.Drawing.Size(820, 82)
        Me.CFlowLayout4.TabIndex = 6
        '
        'lblPaymentMethod
        '
        Me.lblPaymentMethod.DisplayOnly = true
        Me.lblPaymentMethod.EditingMode = false
        Me.lblPaymentMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPaymentMethod.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPaymentMethod.Location = New System.Drawing.Point(4, 4)
        Me.lblPaymentMethod.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPaymentMethod.Name = "lblPaymentMethod"
        Me.lblPaymentMethod.Size = New System.Drawing.Size(185, 23)
        Me.lblPaymentMethod.TabIndex = 288
        Me.lblPaymentMethod.Text = "Payment Method"
        Me.lblPaymentMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPaymentMethod
        '
        Me.cboPaymentMethod.BackColor = System.Drawing.Color.White
        Me.cboPaymentMethod.ChangingSearchValueOnly = false
        Me.cboPaymentMethod.CurrentSearchTerm = ""
        Me.cboPaymentMethod.DefaultValue = Nothing
        Me.cboPaymentMethod.DisplayMember = "Name"
        Me.cboPaymentMethod.DropDownHeight = 1
        Me.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentMethod.EditingMode = false
        Me.cboPaymentMethod.FilterRule = Nothing
        Me.CFlowLayout6.SetFlowBreak(Me.cboPaymentMethod, true)
        Me.cboPaymentMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPaymentMethod.ForeColor = System.Drawing.Color.Black
        Me.cboPaymentMethod.FormattingEnabled = true
        Me.cboPaymentMethod.HideWhenNotEditingOrAdding = false
        Me.cboPaymentMethod.IntegralHeight = false
        Me.cboPaymentMethod.LinkedLabel = Me.lblPaymentMethod
        Me.cboPaymentMethod.Location = New System.Drawing.Point(190, 4)
        Me.cboPaymentMethod.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.cboPaymentMethod.Name = "cboPaymentMethod"
        Me.cboPaymentMethod.OldValue = 0
        Me.cboPaymentMethod.OriginalDataSource = Nothing
        Me.cboPaymentMethod.OriginalList = Nothing
        Me.cboPaymentMethod.OverrideDropDownStyleList = false
        Me.cboPaymentMethod.PreviousSearchTerm = Nothing
        Me.cboPaymentMethod.PreviousSelectedIndex = -1
        Me.cboPaymentMethod.PropertySelector = Nothing
        Me.cboPaymentMethod.ReadOnlyCombo = false
        Me.cboPaymentMethod.SearchAnywhere = false
        Me.cboPaymentMethod.Size = New System.Drawing.Size(201, 24)
        Me.cboPaymentMethod.SuggestBoxHeight = 200
        Me.cboPaymentMethod.SuggestListOrderRule = Nothing
        Me.cboPaymentMethod.TabIndex = 287
        Me.cboPaymentMethod.TextToSearch = Nothing
        Me.cboPaymentMethod.ValueIsMandatory = false
        Me.cboPaymentMethod.ValueIsNullable = false
        Me.cboPaymentMethod.ValueIsNumeric = false
        Me.cboPaymentMethod.ValueMember = "Code"
        '
        'EmployeeEntryTv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(1134, 567)
        Me.Controls.Add(Me.floMain)
        Me.MinimumSize = New System.Drawing.Size(1150, 470)
        Me.Name = "EmployeeEntryTv"
        Me.Text = "Employee Maintenance Form"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floMain, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout6.ResumeLayout(false)
        Me.CFlowLayout6.PerformLayout
        CType(Me.bsEarnings,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsDeductions,System.ComponentModel.ISupportInitialize).EndInit
        Me.EmployeeTabControl.ResumeLayout(false)
        Me.tbpPersonal.ResumeLayout(false)
        Me.CFlowLayout3.ResumeLayout(false)
        Me.CFlowLayout3.PerformLayout
        Me.tbpContact.ResumeLayout(false)
        Me.floContactInformation.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        CType(Me.DataGridViewPhoneDisplay,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsPhones,System.ComponentModel.ISupportInitialize).EndInit
        Me.tbpEmployment.ResumeLayout(false)
        Me.CFlowLayout5.ResumeLayout(false)
        Me.tbpPayroll.ResumeLayout(false)
        Me.tbpEarningDeductions.ResumeLayout(false)
        Me.TableLayoutPanel2.ResumeLayout(false)
        Me.TableLayoutPanel2.PerformLayout
        CType(Me.DataGridViewEarnings,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGridViewDeductions,System.ComponentModel.ISupportInitialize).EndInit
        Me.tbpPhones.ResumeLayout(false)
        CType(Me.DataGridViewPhones,System.ComponentModel.ISupportInitialize).EndInit
        Me.floMain.ResumeLayout(false)
        Me.CFlowLayout4.ResumeLayout(false)
        Me.CFlowLayout4.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
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
        Friend WithEvents lblBankIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacBankIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblBankAccountNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtBankAccountNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblIban As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtIban As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblEmployeeCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmployeeCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents EmployeeTabControl As Libraries.CBaseControlsLibrary.CTabControl
        Friend WithEvents tbpPersonal As Libraries.CBaseControlsLibrary.CTabPage
        Friend WithEvents tbpContact As Libraries.CBaseControlsLibrary.CTabPage
        Friend WithEvents tbpPayroll As Libraries.CBaseControlsLibrary.CTabPage
        Friend WithEvents CFlowLayout3 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents floMain As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents cacGender As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents CFlowLayout4 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblNationalIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtNationalIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblNotes As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtNotes As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents tbpEmployment As TabPage
        Friend WithEvents CFlowLayout5 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblActive As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents chkActive As Libraries.CBaseControlsLibrary.CCheckBox
        Friend WithEvents lblDepartmentIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacDepartmentIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents cacDesignationIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblDesignationIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblOpeningBalance As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtOpeningBalance As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblBalance As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtBalance As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPayFrequency As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboPayFrequency As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblHiredDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpHiredDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblReleasedDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpReleasedDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents CFlowLayout6 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents bsEarnings As BindingSource
        Friend WithEvents bsDeductions As BindingSource
        Friend WithEvents FrequencyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents RateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents FrequencyDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents RateDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents tbpEarningDeductions As TabPage
        Friend WithEvents DataGridViewEarnings As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents DataGridViewDeductions As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblEarnings As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents DeductionCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DeductionNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DeductionNameAraDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DeductionTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents EmployeeIdNoDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents EarningCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents EarningNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents EarningNameAraDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents EarningTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents EmployeeIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents bsPhones As BindingSource
        Friend WithEvents dgvInternationalCode As Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn
        Friend WithEvents dgvPhoneNumber As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents tbpPhones As TabPage
        Friend WithEvents DataGridViewPhones As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents floContactInformation As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents txtZipCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblZipCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPoBox As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPoBox As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacCountryCode As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblCountryCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtProvinceState As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblProvinceState As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtTownCity As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblTownCity As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDistrict As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblDistrict As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtStreet As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtEmail As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblEmail As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblStreet As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dgvSequence As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents dgvPhoneTypeIdNo As Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn
        Friend WithEvents dgvCountryTelIdNo As Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn
        Friend WithEvents dgvAreaCode As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents PhoneNumber As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents dgvFullPhone As DataGridViewTextBoxColumn
        Friend WithEvents dgvFullPhoneAra As DataGridViewTextBoxColumn
        Friend WithEvents dgvCountryTelCode As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewPhoneDisplay As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents dgvSequencePhoneDisplay As DataGridViewTextBoxColumn
        Friend WithEvents FullPhone As DataGridViewTextBoxColumn
        Friend WithEvents FullPhoneAra As DataGridViewTextBoxColumn
        Friend WithEvents AreaCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
        Friend WithEvents CountryTelIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PhoneNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PhoneTypeIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dgvSequenceEarning As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents dgvEarningIdNo As Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn
        Friend WithEvents dgvEarningAmount As Libraries.CBaseControlsLibrary.CdgvColumnMoney
        Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceDeduction As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents dgvDeductionIdNo As Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn
        Friend WithEvents dgvDeductionAmount As Libraries.CBaseControlsLibrary.CdgvColumnMoney
        Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
        Friend WithEvents lblNetTotal As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtNetTotal As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPaymentMethod As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboPaymentMethod As Libraries.CBaseControlsLibrary.CaComboBox
    End Class

End Namespace