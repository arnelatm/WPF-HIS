Imports AATM.Libraries.CBaseControlsLibrary
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
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator2 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.CFlowLayout6 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblPaymentMethod = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPaymentMethod = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
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
            Me.lblPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayCycleidNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblDutyHours = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDutyHours = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.bsEarnings = New System.Windows.Forms.BindingSource(Me.components)
            Me.bsDeductions = New System.Windows.Forms.BindingSource(Me.components)
            Me.lblEmployeeName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEmployeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEmployeeNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEmployeeNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.lblGender = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblBirthDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpBirthDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblMaritalStatus = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacMaritalStatus = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblNationalityCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacNationalityCode = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblReligion = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacReligionIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.tbcEmployee = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tbpPersonal = New AATM.Libraries.CBaseControlsLibrary.CTabPage()
            Me.floPersonal = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
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
            Me.dtpHiredDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblReleasedDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpReleasedDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblDepartmentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacDepartmentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblDesignationIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacDesignationIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.tbpPayroll = New AATM.Libraries.CBaseControlsLibrary.CTabPage()
            Me.tbpEarnings = New System.Windows.Forms.TabPage()
            Me.DataGridViewEarnings = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequenceEarning = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvEarningIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvEarningRate = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvEarningUnit = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvEarningAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tbpDeductions = New System.Windows.Forms.TabPage()
            Me.DataGridViewDeductions = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequenceDeduction = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvDeductionIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvDeductionRate = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvDeductionUnit = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvDeductionAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tbpPhones = New System.Windows.Forms.TabPage()
            Me.DataGridViewPhones = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvPhoneTypeIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvCountryTelIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvAreaCode = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.PhoneNumber = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
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
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout6.SuspendLayout
            CType(Me.bsEarnings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsDeductions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbcEmployee.SuspendLayout
            Me.tbpPersonal.SuspendLayout
            Me.floPersonal.SuspendLayout
            Me.tbpContact.SuspendLayout
            Me.floContactInformation.SuspendLayout
            Me.TableLayoutPanel1.SuspendLayout
            CType(Me.DataGridViewPhoneDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPhones, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbpEmployment.SuspendLayout
            Me.CFlowLayout5.SuspendLayout
            Me.tbpPayroll.SuspendLayout
            Me.tbpEarnings.SuspendLayout
            CType(Me.DataGridViewEarnings, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbpDeductions.SuspendLayout
            CType(Me.DataGridViewDeductions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbpPhones.SuspendLayout
            CType(Me.DataGridViewPhones, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floMain.SuspendLayout
            Me.CFlowLayout4.SuspendLayout
            Me.SuspendLayout
            '
            'TreeViewTableName
            '
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.TreeViewTableName.Size = New System.Drawing.Size(300, 461)
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
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
            Me.CFlowLayout6.Controls.Add(Me.lblPayCycleIdNo)
            Me.CFlowLayout6.Controls.Add(Me.cboPayCycleidNo)
            Me.CFlowLayout6.Controls.Add(Me.lblPayGroupIdNo)
            Me.CFlowLayout6.Controls.Add(Me.cboPayGroupIdNo)
            Me.CFlowLayout6.Controls.Add(Me.lblDutyHours)
            Me.CFlowLayout6.Controls.Add(Me.txtDutyHours)
            Me.CFlowLayout6.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout6.Location = New System.Drawing.Point(3, 3)
            Me.CFlowLayout6.Name = "CFlowLayout6"
            Me.CFlowLayout6.Padding = New System.Windows.Forms.Padding(3)
            Me.CFlowLayout6.Size = New System.Drawing.Size(644, 320)
            Me.CFlowLayout6.TabIndex = 293
            '
            'lblPaymentMethod
            '
            Me.lblPaymentMethod.DisplayOnly = True
            Me.lblPaymentMethod.EditingMode = False
            Me.lblPaymentMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.cboPaymentMethod.BegFindValue = Nothing
            Me.cboPaymentMethod.ChangingSearchValueOnly = False
            Me.cboPaymentMethod.CurrentSearchTerm = ""
            Me.cboPaymentMethod.DefaultValue = Nothing
            Me.cboPaymentMethod.DisplayMember = "Name"
            Me.cboPaymentMethod.EditingMode = False
            Me.cboPaymentMethod.EndFindValue = Nothing
            Me.cboPaymentMethod.FieldDescription = Nothing
            Me.cboPaymentMethod.FieldName = Nothing
            Me.cboPaymentMethod.FilterRule = Nothing
            Me.cboPaymentMethod.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPaymentMethod.FindEnabled = False
            Me.CFlowLayout6.SetFlowBreak(Me.cboPaymentMethod, True)
            Me.cboPaymentMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPaymentMethod.ForeColor = System.Drawing.Color.Black
            Me.cboPaymentMethod.FormattingEnabled = True
            Me.cboPaymentMethod.HideWhenNotEditingOrAdding = False
            Me.cboPaymentMethod.IgnoreCase = False
            Me.cboPaymentMethod.IntegralHeight = False
            Me.cboPaymentMethod.LinkedLabel = Me.lblPaymentMethod
            Me.cboPaymentMethod.Location = New System.Drawing.Point(190, 4)
            Me.cboPaymentMethod.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cboPaymentMethod.Name = "cboPaymentMethod"
            Me.cboPaymentMethod.OldValue = 0
            Me.cboPaymentMethod.OriginalDataSource = Nothing
            Me.cboPaymentMethod.OriginalList = Nothing
            Me.cboPaymentMethod.OverrideDropDownStyleList = False
            Me.cboPaymentMethod.PreviousSearchTerm = Nothing
            Me.cboPaymentMethod.PropertySelector = Nothing
            Me.cboPaymentMethod.ReadOnlyCombo = False
            Me.cboPaymentMethod.SecurityKey = ""
            Me.cboPaymentMethod.Size = New System.Drawing.Size(402, 24)
            Me.cboPaymentMethod.SuggestBoxHeight = 200
            Me.cboPaymentMethod.SuggestListOrderRule = Nothing
            Me.cboPaymentMethod.TabIndex = 287
            Me.cboPaymentMethod.TextToSearch = Nothing
            Me.cboPaymentMethod.ValueIsMandatory = False
            Me.cboPaymentMethod.ValueIsNullable = False
            Me.cboPaymentMethod.ValueIsNumeric = False
            Me.cboPaymentMethod.ValueMember = "Code"
            '
            'lblBankIdNo
            '
            Me.lblBankIdNo.DisplayOnly = True
            Me.lblBankIdNo.EditingMode = False
            Me.lblBankIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.cacBankIdNo.BegFindValue = Nothing
            Me.cacBankIdNo.ChangingSearchValueOnly = False
            Me.cacBankIdNo.CurrentSearchTerm = ""
            Me.cacBankIdNo.DefaultValue = Nothing
            Me.cacBankIdNo.DisplayMember = "Name"
            Me.cacBankIdNo.EditingMode = False
            Me.cacBankIdNo.EndFindValue = Nothing
            Me.cacBankIdNo.FieldDescription = Nothing
            Me.cacBankIdNo.FieldName = Nothing
            Me.cacBankIdNo.FilterRule = Nothing
            Me.cacBankIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacBankIdNo.FindEnabled = False
            Me.CFlowLayout6.SetFlowBreak(Me.cacBankIdNo, True)
            Me.cacBankIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacBankIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacBankIdNo.FormattingEnabled = True
            Me.cacBankIdNo.HideWhenNotEditingOrAdding = False
            Me.cacBankIdNo.IgnoreCase = False
            Me.cacBankIdNo.IntegralHeight = False
            Me.cacBankIdNo.LinkedLabel = Me.lblBankIdNo
            Me.cacBankIdNo.Location = New System.Drawing.Point(190, 30)
            Me.cacBankIdNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacBankIdNo.Name = "cacBankIdNo"
            Me.cacBankIdNo.OldValue = 0
            Me.cacBankIdNo.OriginalDataSource = Nothing
            Me.cacBankIdNo.OriginalList = Nothing
            Me.cacBankIdNo.OverrideDropDownStyleList = False
            Me.cacBankIdNo.PreviousSearchTerm = Nothing
            Me.cacBankIdNo.PropertySelector = Nothing
            Me.cacBankIdNo.ReadOnlyCombo = False
            Me.cacBankIdNo.SecurityKey = ""
            Me.cacBankIdNo.Size = New System.Drawing.Size(402, 24)
            Me.cacBankIdNo.SuggestBoxHeight = 200
            Me.cacBankIdNo.SuggestListOrderRule = Nothing
            Me.cacBankIdNo.TabIndex = 2
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
            Me.txtBankAccountNo.BegFindValue = Nothing
            Me.txtBankAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBankAccountNo.ComputedValue = False
            Me.txtBankAccountNo.CustomFormat = Nothing
            Me.txtBankAccountNo.DataBoundControl = True
            Me.txtBankAccountNo.EditingMode = False
            Me.txtBankAccountNo.EndFindValue = Nothing
            Me.txtBankAccountNo.FieldDescription = Nothing
            Me.txtBankAccountNo.FieldName = Nothing
            Me.txtBankAccountNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBankAccountNo.FindEnabled = True
            Me.CFlowLayout6.SetFlowBreak(Me.txtBankAccountNo, True)
            Me.txtBankAccountNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtBankAccountNo.ForeColor = System.Drawing.Color.Black
            Me.txtBankAccountNo.LinkedLabel = Me.lblBankAccountNo
            Me.txtBankAccountNo.Location = New System.Drawing.Point(191, 56)
            Me.txtBankAccountNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtBankAccountNo.MaximumValue = Nothing
            Me.txtBankAccountNo.MinimumValue = Nothing
            Me.txtBankAccountNo.Name = "txtBankAccountNo"
            Me.txtBankAccountNo.OldValue = Nothing
            Me.txtBankAccountNo.ReadOnly = True
            Me.txtBankAccountNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBankAccountNo.SecurityKey = ""
            Me.txtBankAccountNo.Size = New System.Drawing.Size(200, 23)
            Me.txtBankAccountNo.TabIndex = 3
            '
            'lblBalance
            '
            Me.lblBalance.DisplayOnly = True
            Me.lblBalance.EditingMode = False
            Me.lblBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.txtBalance.BegFindValue = Nothing
            Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBalance.ComputedValue = False
            Me.txtBalance.CustomFormat = Nothing
            Me.txtBalance.DataBoundControl = True
            Me.txtBalance.DisplayOnly = True
            Me.txtBalance.EditingMode = False
            Me.txtBalance.EndFindValue = Nothing
            Me.txtBalance.FieldDescription = Nothing
            Me.txtBalance.FieldName = Nothing
            Me.txtBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBalance.FindEnabled = True
            Me.CFlowLayout6.SetFlowBreak(Me.txtBalance, True)
            Me.txtBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtBalance.ForeColor = System.Drawing.Color.Black
            Me.txtBalance.LinkedLabel = Me.lblBalance
            Me.txtBalance.Location = New System.Drawing.Point(191, 81)
            Me.txtBalance.Margin = New System.Windows.Forms.Padding(1)
            Me.txtBalance.MaximumValue = Nothing
            Me.txtBalance.MinimumValue = Nothing
            Me.txtBalance.Name = "txtBalance"
            Me.txtBalance.OldValue = Nothing
            Me.txtBalance.ReadOnly = True
            Me.txtBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBalance.SecurityKey = ""
            Me.txtBalance.Size = New System.Drawing.Size(93, 23)
            Me.txtBalance.TabIndex = 4
            Me.txtBalance.ValueIsNumeric = True
            '
            'lblOpeningBalance
            '
            Me.lblOpeningBalance.DisplayOnly = True
            Me.lblOpeningBalance.EditingMode = False
            Me.lblOpeningBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.txtOpeningBalance.BegFindValue = Nothing
            Me.txtOpeningBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOpeningBalance.ComputedValue = False
            Me.txtOpeningBalance.CustomFormat = Nothing
            Me.txtOpeningBalance.DataBoundControl = True
            Me.txtOpeningBalance.DisplayOnly = True
            Me.txtOpeningBalance.EditingMode = False
            Me.txtOpeningBalance.EndFindValue = Nothing
            Me.txtOpeningBalance.FieldDescription = Nothing
            Me.txtOpeningBalance.FieldName = Nothing
            Me.txtOpeningBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtOpeningBalance.FindEnabled = True
            Me.CFlowLayout6.SetFlowBreak(Me.txtOpeningBalance, True)
            Me.txtOpeningBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtOpeningBalance.ForeColor = System.Drawing.Color.Black
            Me.txtOpeningBalance.LinkedLabel = Me.lblOpeningBalance
            Me.txtOpeningBalance.Location = New System.Drawing.Point(191, 106)
            Me.txtOpeningBalance.Margin = New System.Windows.Forms.Padding(1)
            Me.txtOpeningBalance.MaximumValue = Nothing
            Me.txtOpeningBalance.MinimumValue = Nothing
            Me.txtOpeningBalance.Name = "txtOpeningBalance"
            Me.txtOpeningBalance.OldValue = Nothing
            Me.txtOpeningBalance.ReadOnly = True
            Me.txtOpeningBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtOpeningBalance.SecurityKey = ""
            Me.txtOpeningBalance.Size = New System.Drawing.Size(93, 23)
            Me.txtOpeningBalance.TabIndex = 5
            Me.txtOpeningBalance.ValueIsNumeric = True
            '
            'lblIban
            '
            Me.lblIban.DisplayOnly = True
            Me.lblIban.EditingMode = False
            Me.lblIban.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.txtIban.BegFindValue = Nothing
            Me.txtIban.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIban.ComputedValue = False
            Me.txtIban.CustomFormat = Nothing
            Me.txtIban.DataBoundControl = True
            Me.txtIban.EditingMode = False
            Me.txtIban.EndFindValue = Nothing
            Me.txtIban.FieldDescription = Nothing
            Me.txtIban.FieldName = Nothing
            Me.txtIban.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtIban.FindEnabled = True
            Me.CFlowLayout6.SetFlowBreak(Me.txtIban, True)
            Me.txtIban.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtIban.ForeColor = System.Drawing.Color.Black
            Me.txtIban.LinkedLabel = Me.lblIban
            Me.txtIban.Location = New System.Drawing.Point(191, 131)
            Me.txtIban.Margin = New System.Windows.Forms.Padding(1)
            Me.txtIban.MaximumValue = Nothing
            Me.txtIban.MinimumValue = Nothing
            Me.txtIban.Name = "txtIban"
            Me.txtIban.OldValue = Nothing
            Me.txtIban.ReadOnly = True
            Me.txtIban.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtIban.SecurityKey = ""
            Me.txtIban.Size = New System.Drawing.Size(200, 23)
            Me.txtIban.TabIndex = 6
            '
            'lblPayCycleIdNo
            '
            Me.lblPayCycleIdNo.DisplayOnly = True
            Me.lblPayCycleIdNo.EditingMode = False
            Me.lblPayCycleIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayCycleIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPayCycleIdNo.Location = New System.Drawing.Point(4, 156)
            Me.lblPayCycleIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayCycleIdNo.Name = "lblPayCycleIdNo"
            Me.lblPayCycleIdNo.Size = New System.Drawing.Size(185, 23)
            Me.lblPayCycleIdNo.TabIndex = 286
            Me.lblPayCycleIdNo.Text = "Pay Cycle"
            Me.lblPayCycleIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboPayCycleidNo
            '
            Me.cboPayCycleidNo.BackColor = System.Drawing.Color.White
            Me.cboPayCycleidNo.BegFindValue = Nothing
            Me.cboPayCycleidNo.ChangingSearchValueOnly = False
            Me.cboPayCycleidNo.CurrentSearchTerm = ""
            Me.cboPayCycleidNo.DefaultValue = Nothing
            Me.cboPayCycleidNo.DisplayMember = "Name"
            Me.cboPayCycleidNo.EditingMode = False
            Me.cboPayCycleidNo.EndFindValue = Nothing
            Me.cboPayCycleidNo.FieldDescription = Nothing
            Me.cboPayCycleidNo.FieldName = Nothing
            Me.cboPayCycleidNo.FilterRule = Nothing
            Me.cboPayCycleidNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPayCycleidNo.FindEnabled = False
            Me.CFlowLayout6.SetFlowBreak(Me.cboPayCycleidNo, True)
            Me.cboPayCycleidNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayCycleidNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayCycleidNo.FormattingEnabled = True
            Me.cboPayCycleidNo.HideWhenNotEditingOrAdding = False
            Me.cboPayCycleidNo.IgnoreCase = False
            Me.cboPayCycleidNo.IntegralHeight = False
            Me.cboPayCycleidNo.LinkedLabel = Me.lblPayCycleIdNo
            Me.cboPayCycleidNo.Location = New System.Drawing.Point(190, 156)
            Me.cboPayCycleidNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cboPayCycleidNo.Name = "cboPayCycleidNo"
            Me.cboPayCycleidNo.OldValue = 0
            Me.cboPayCycleidNo.OriginalDataSource = Nothing
            Me.cboPayCycleidNo.OriginalList = Nothing
            Me.cboPayCycleidNo.OverrideDropDownStyleList = False
            Me.cboPayCycleidNo.PreviousSearchTerm = Nothing
            Me.cboPayCycleidNo.PropertySelector = Nothing
            Me.cboPayCycleidNo.ReadOnlyCombo = False
            Me.cboPayCycleidNo.SecurityKey = ""
            Me.cboPayCycleidNo.Size = New System.Drawing.Size(201, 24)
            Me.cboPayCycleidNo.SuggestBoxHeight = 200
            Me.cboPayCycleidNo.SuggestListOrderRule = Nothing
            Me.cboPayCycleidNo.TabIndex = 7
            Me.cboPayCycleidNo.TextToSearch = Nothing
            Me.cboPayCycleidNo.ValueIsMandatory = False
            Me.cboPayCycleidNo.ValueIsNullable = True
            Me.cboPayCycleidNo.ValueIsNumeric = False
            Me.cboPayCycleidNo.ValueMember = "IdNo"
            '
            'lblPayGroupIdNo
            '
            Me.lblPayGroupIdNo.DisplayOnly = True
            Me.lblPayGroupIdNo.EditingMode = False
            Me.lblPayGroupIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayGroupIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPayGroupIdNo.Location = New System.Drawing.Point(4, 183)
            Me.lblPayGroupIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayGroupIdNo.Name = "lblPayGroupIdNo"
            Me.lblPayGroupIdNo.Size = New System.Drawing.Size(185, 23)
            Me.lblPayGroupIdNo.TabIndex = 290
            Me.lblPayGroupIdNo.Text = "Pay Group"
            Me.lblPayGroupIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboPayGroupIdNo
            '
            Me.cboPayGroupIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayGroupIdNo.BegFindValue = Nothing
            Me.cboPayGroupIdNo.ChangingSearchValueOnly = False
            Me.cboPayGroupIdNo.CurrentSearchTerm = ""
            Me.cboPayGroupIdNo.DefaultValue = Nothing
            Me.cboPayGroupIdNo.DisplayMember = "Name"
            Me.cboPayGroupIdNo.EditingMode = False
            Me.cboPayGroupIdNo.EndFindValue = Nothing
            Me.cboPayGroupIdNo.FieldDescription = Nothing
            Me.cboPayGroupIdNo.FieldName = Nothing
            Me.cboPayGroupIdNo.FilterRule = Nothing
            Me.cboPayGroupIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPayGroupIdNo.FindEnabled = False
            Me.CFlowLayout6.SetFlowBreak(Me.cboPayGroupIdNo, True)
            Me.cboPayGroupIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayGroupIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayGroupIdNo.FormattingEnabled = True
            Me.cboPayGroupIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayGroupIdNo.IgnoreCase = False
            Me.cboPayGroupIdNo.IntegralHeight = False
            Me.cboPayGroupIdNo.LinkedLabel = Me.lblPayGroupIdNo
            Me.cboPayGroupIdNo.Location = New System.Drawing.Point(190, 183)
            Me.cboPayGroupIdNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cboPayGroupIdNo.Name = "cboPayGroupIdNo"
            Me.cboPayGroupIdNo.OldValue = 0
            Me.cboPayGroupIdNo.OriginalDataSource = Nothing
            Me.cboPayGroupIdNo.OriginalList = Nothing
            Me.cboPayGroupIdNo.OverrideDropDownStyleList = False
            Me.cboPayGroupIdNo.PreviousSearchTerm = Nothing
            Me.cboPayGroupIdNo.PropertySelector = Nothing
            Me.cboPayGroupIdNo.ReadOnlyCombo = False
            Me.cboPayGroupIdNo.SecurityKey = ""
            Me.cboPayGroupIdNo.Size = New System.Drawing.Size(201, 24)
            Me.cboPayGroupIdNo.SuggestBoxHeight = 200
            Me.cboPayGroupIdNo.SuggestListOrderRule = Nothing
            Me.cboPayGroupIdNo.TabIndex = 289
            Me.cboPayGroupIdNo.TextToSearch = Nothing
            Me.cboPayGroupIdNo.ValueIsMandatory = False
            Me.cboPayGroupIdNo.ValueIsNullable = True
            Me.cboPayGroupIdNo.ValueIsNumeric = False
            Me.cboPayGroupIdNo.ValueMember = "IdNo"
            '
            'lblDutyHours
            '
            Me.lblDutyHours.DisplayOnly = True
            Me.lblDutyHours.EditingMode = False
            Me.lblDutyHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDutyHours.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDutyHours.Location = New System.Drawing.Point(4, 210)
            Me.lblDutyHours.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDutyHours.Name = "lblDutyHours"
            Me.lblDutyHours.Size = New System.Drawing.Size(185, 23)
            Me.lblDutyHours.TabIndex = 292
            Me.lblDutyHours.Text = "Duty Hours"
            Me.lblDutyHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtDutyHours
            '
            Me.txtDutyHours.BackColor = System.Drawing.Color.White
            Me.txtDutyHours.BegFindValue = Nothing
            Me.txtDutyHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDutyHours.ComputedValue = False
            Me.txtDutyHours.CustomFormat = Nothing
            Me.txtDutyHours.DataBoundControl = True
            Me.txtDutyHours.EditingMode = False
            Me.txtDutyHours.EndFindValue = Nothing
            Me.txtDutyHours.FieldDescription = Nothing
            Me.txtDutyHours.FieldName = Nothing
            Me.txtDutyHours.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDutyHours.FindEnabled = True
            Me.CFlowLayout6.SetFlowBreak(Me.txtDutyHours, True)
            Me.txtDutyHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDutyHours.ForeColor = System.Drawing.Color.Black
            Me.txtDutyHours.LinkedLabel = Me.lblDutyHours
            Me.txtDutyHours.Location = New System.Drawing.Point(191, 210)
            Me.txtDutyHours.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDutyHours.MaximumValue = Nothing
            Me.txtDutyHours.MinimumValue = Nothing
            Me.txtDutyHours.Name = "txtDutyHours"
            Me.txtDutyHours.OldValue = Nothing
            Me.txtDutyHours.ReadOnly = True
            Me.txtDutyHours.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDutyHours.SecurityKey = ""
            Me.txtDutyHours.Size = New System.Drawing.Size(93, 23)
            Me.txtDutyHours.TabIndex = 291
            Me.txtDutyHours.ValueIsNumeric = True
            '
            'bsEarnings
            '
            Me.bsEarnings.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.EmployeePayElementModel)
            '
            'bsDeductions
            '
            Me.bsDeductions.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.EmployeePayElementModel)
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
            Me.txtEmployeeName.BegFindValue = Nothing
            Me.txtEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmployeeName.ComputedValue = False
            Me.txtEmployeeName.CustomFormat = Nothing
            Me.txtEmployeeName.DataBoundControl = True
            Me.txtEmployeeName.EditingMode = False
            Me.txtEmployeeName.EndFindValue = Nothing
            Me.txtEmployeeName.FieldDescription = Nothing
            Me.txtEmployeeName.FieldName = Nothing
            Me.txtEmployeeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtEmployeeName.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtEmployeeName, True)
            Me.txtEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmployeeName.ForeColor = System.Drawing.Color.Black
            Me.txtEmployeeName.LinkedLabel = Me.lblEmployeeName
            Me.txtEmployeeName.Location = New System.Drawing.Point(186, 26)
            Me.txtEmployeeName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeName.MaximumValue = Nothing
            Me.txtEmployeeName.MinimumValue = Nothing
            Me.txtEmployeeName.Name = "txtEmployeeName"
            Me.txtEmployeeName.OldValue = Nothing
            Me.txtEmployeeName.ReadOnly = True
            Me.txtEmployeeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtEmployeeName.Size = New System.Drawing.Size(476, 23)
            Me.txtEmployeeName.TabIndex = 2
            Me.txtEmployeeName.ValueIsMandatory = True
            Me.txtEmployeeName.ValueIsUnique = True
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
            Me.txtEmployeeNameAra.BegFindValue = Nothing
            Me.txtEmployeeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmployeeNameAra.ComputedValue = False
            Me.txtEmployeeNameAra.CustomFormat = Nothing
            Me.txtEmployeeNameAra.DataBoundControl = True
            Me.txtEmployeeNameAra.EditingMode = False
            Me.txtEmployeeNameAra.EndFindValue = Nothing
            Me.txtEmployeeNameAra.EnglishControl = Me.txtEmployeeName
            Me.txtEmployeeNameAra.FieldDescription = Nothing
            Me.txtEmployeeNameAra.FieldName = Nothing
            Me.txtEmployeeNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtEmployeeNameAra.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtEmployeeNameAra, True)
            Me.txtEmployeeNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmployeeNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtEmployeeNameAra.LinkedLabel = Me.lblEmployeeNameAra
            Me.txtEmployeeNameAra.Location = New System.Drawing.Point(186, 51)
            Me.txtEmployeeNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeNameAra.MaximumValue = Nothing
            Me.txtEmployeeNameAra.MinimumValue = Nothing
            Me.txtEmployeeNameAra.Name = "txtEmployeeNameAra"
            Me.txtEmployeeNameAra.OldValue = Nothing
            Me.txtEmployeeNameAra.ReadOnly = True
            Me.txtEmployeeNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtEmployeeNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtEmployeeNameAra.Size = New System.Drawing.Size(476, 23)
            Me.txtEmployeeNameAra.TabIndex = 3
            Me.txtEmployeeNameAra.ValueIsMandatory = True
            Me.txtEmployeeNameAra.ValueIsUnique = True
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
            Me.lblBirthDate.Size = New System.Drawing.Size(174, 23)
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
            Me.floPersonal.SetFlowBreak(Me.dtpBirthDate, True)
            Me.dtpBirthDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpBirthDate.ForeColor = System.Drawing.Color.Black
            Me.dtpBirthDate.LinkedLabel = Nothing
            Me.dtpBirthDate.Location = New System.Drawing.Point(176, 104)
            Me.dtpBirthDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpBirthDate.Name = "dtpBirthDate"
            Me.dtpBirthDate.ReadOnlyDp = False
            Me.dtpBirthDate.SecurityKey = Nothing
            Me.dtpBirthDate.ShowLongDate = False
            Me.dtpBirthDate.ShowTime = False
            Me.dtpBirthDate.Size = New System.Drawing.Size(132, 24)
            Me.dtpBirthDate.TabIndex = 5
            Me.dtpBirthDate.TabStop = False
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
            Me.cacMaritalStatus.BegFindValue = Nothing
            Me.cacMaritalStatus.ChangingSearchValueOnly = False
            Me.cacMaritalStatus.CurrentSearchTerm = ""
            Me.cacMaritalStatus.DefaultValue = Nothing
            Me.cacMaritalStatus.DisplayMember = "Name"
            Me.cacMaritalStatus.EditingMode = False
            Me.cacMaritalStatus.EndFindValue = Nothing
            Me.cacMaritalStatus.FieldDescription = Nothing
            Me.cacMaritalStatus.FieldName = Nothing
            Me.cacMaritalStatus.FilterRule = Nothing
            Me.cacMaritalStatus.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacMaritalStatus.FindEnabled = False
            Me.floPersonal.SetFlowBreak(Me.cacMaritalStatus, True)
            Me.cacMaritalStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacMaritalStatus.ForeColor = System.Drawing.Color.Black
            Me.cacMaritalStatus.FormattingEnabled = True
            Me.cacMaritalStatus.HideWhenNotEditingOrAdding = False
            Me.cacMaritalStatus.IgnoreCase = False
            Me.cacMaritalStatus.IntegralHeight = False
            Me.cacMaritalStatus.LinkedLabel = Me.lblMaritalStatus
            Me.cacMaritalStatus.Location = New System.Drawing.Point(177, 27)
            Me.cacMaritalStatus.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacMaritalStatus.Name = "cacMaritalStatus"
            Me.cacMaritalStatus.OldValue = 0
            Me.cacMaritalStatus.OriginalDataSource = Nothing
            Me.cacMaritalStatus.OriginalList = Nothing
            Me.cacMaritalStatus.OverrideDropDownStyleList = False
            Me.cacMaritalStatus.PreviousSearchTerm = Nothing
            Me.cacMaritalStatus.PropertySelector = Nothing
            Me.cacMaritalStatus.ReadOnlyCombo = False
            Me.cacMaritalStatus.Size = New System.Drawing.Size(278, 24)
            Me.cacMaritalStatus.SuggestBoxHeight = 200
            Me.cacMaritalStatus.SuggestListOrderRule = Nothing
            Me.cacMaritalStatus.TabIndex = 2
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
            Me.cacNationalityCode.BegFindValue = Nothing
            Me.cacNationalityCode.ChangingSearchValueOnly = False
            Me.cacNationalityCode.CurrentSearchTerm = ""
            Me.cacNationalityCode.DefaultValue = Nothing
            Me.cacNationalityCode.DisplayMember = "Name"
            Me.cacNationalityCode.EditingMode = False
            Me.cacNationalityCode.EndFindValue = Nothing
            Me.cacNationalityCode.FieldDescription = Nothing
            Me.cacNationalityCode.FieldName = Nothing
            Me.cacNationalityCode.FilterRule = Nothing
            Me.cacNationalityCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacNationalityCode.FindEnabled = False
            Me.floPersonal.SetFlowBreak(Me.cacNationalityCode, True)
            Me.cacNationalityCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacNationalityCode.ForeColor = System.Drawing.Color.Black
            Me.cacNationalityCode.FormattingEnabled = True
            Me.cacNationalityCode.HideWhenNotEditingOrAdding = False
            Me.cacNationalityCode.IgnoreCase = False
            Me.cacNationalityCode.IntegralHeight = False
            Me.cacNationalityCode.LinkedLabel = Me.lblNationalityCode
            Me.cacNationalityCode.Location = New System.Drawing.Point(176, 53)
            Me.cacNationalityCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacNationalityCode.Name = "cacNationalityCode"
            Me.cacNationalityCode.OldValue = 0
            Me.cacNationalityCode.OriginalDataSource = Nothing
            Me.cacNationalityCode.OriginalList = Nothing
            Me.cacNationalityCode.OverrideDropDownStyleList = False
            Me.cacNationalityCode.PreviousSearchTerm = Nothing
            Me.cacNationalityCode.PropertySelector = Nothing
            Me.cacNationalityCode.ReadOnlyCombo = False
            Me.cacNationalityCode.Size = New System.Drawing.Size(279, 24)
            Me.cacNationalityCode.SuggestBoxHeight = 200
            Me.cacNationalityCode.SuggestListOrderRule = Nothing
            Me.cacNationalityCode.TabIndex = 3
            Me.cacNationalityCode.TextToSearch = Nothing
            Me.cacNationalityCode.ValueIsMandatory = False
            Me.cacNationalityCode.ValueIsNullable = False
            Me.cacNationalityCode.ValueIsNumeric = False
            Me.cacNationalityCode.ValueMember = "Code"
            '
            'lblReligion
            '
            Me.lblReligion.DisplayOnly = True
            Me.lblReligion.EditingMode = False
            Me.lblReligion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReligion.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReligion.Location = New System.Drawing.Point(1, 79)
            Me.lblReligion.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReligion.Name = "lblReligion"
            Me.lblReligion.Size = New System.Drawing.Size(175, 24)
            Me.lblReligion.TabIndex = 249
            Me.lblReligion.Text = "Religion"
            Me.lblReligion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cacReligionIdNo
            '
            Me.cacReligionIdNo.BackColor = System.Drawing.Color.White
            Me.cacReligionIdNo.BegFindValue = Nothing
            Me.cacReligionIdNo.ChangingSearchValueOnly = False
            Me.cacReligionIdNo.CurrentSearchTerm = ""
            Me.cacReligionIdNo.DefaultValue = Nothing
            Me.cacReligionIdNo.DisplayMember = "Name"
            Me.cacReligionIdNo.EditingMode = False
            Me.cacReligionIdNo.EndFindValue = Nothing
            Me.cacReligionIdNo.FieldDescription = Nothing
            Me.cacReligionIdNo.FieldName = Nothing
            Me.cacReligionIdNo.FilterRule = Nothing
            Me.cacReligionIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacReligionIdNo.FindEnabled = False
            Me.floPersonal.SetFlowBreak(Me.cacReligionIdNo, True)
            Me.cacReligionIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacReligionIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacReligionIdNo.FormattingEnabled = True
            Me.cacReligionIdNo.HideWhenNotEditingOrAdding = False
            Me.cacReligionIdNo.IgnoreCase = False
            Me.cacReligionIdNo.IntegralHeight = False
            Me.cacReligionIdNo.LinkedLabel = Me.lblNationalityCode
            Me.cacReligionIdNo.Location = New System.Drawing.Point(177, 79)
            Me.cacReligionIdNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacReligionIdNo.Name = "cacReligionIdNo"
            Me.cacReligionIdNo.OldValue = 0
            Me.cacReligionIdNo.OriginalDataSource = Nothing
            Me.cacReligionIdNo.OriginalList = Nothing
            Me.cacReligionIdNo.OverrideDropDownStyleList = False
            Me.cacReligionIdNo.PreviousSearchTerm = Nothing
            Me.cacReligionIdNo.PropertySelector = Nothing
            Me.cacReligionIdNo.ReadOnlyCombo = False
            Me.cacReligionIdNo.Size = New System.Drawing.Size(278, 24)
            Me.cacReligionIdNo.SuggestBoxHeight = 200
            Me.cacReligionIdNo.SuggestListOrderRule = Nothing
            Me.cacReligionIdNo.TabIndex = 4
            Me.cacReligionIdNo.TextToSearch = Nothing
            Me.cacReligionIdNo.ValueIsMandatory = False
            Me.cacReligionIdNo.ValueIsNullable = False
            Me.cacReligionIdNo.ValueIsNumeric = False
            Me.cacReligionIdNo.ValueMember = "IdNo"
            '
            'tbcEmployee
            '
            Me.tbcEmployee.Controls.Add(Me.tbpPersonal)
            Me.tbcEmployee.Controls.Add(Me.tbpContact)
            Me.tbcEmployee.Controls.Add(Me.tbpEmployment)
            Me.tbcEmployee.Controls.Add(Me.tbpPayroll)
            Me.tbcEmployee.Controls.Add(Me.tbpEarnings)
            Me.tbcEmployee.Controls.Add(Me.tbpDeductions)
            Me.tbcEmployee.Controls.Add(Me.tbpPhones)
            Me.tbcEmployee.HotTrack = True
            Me.tbcEmployee.Location = New System.Drawing.Point(3, 91)
            Me.tbcEmployee.Name = "tbcEmployee"
            Me.tbcEmployee.SelectedIndex = 0
            Me.tbcEmployee.Size = New System.Drawing.Size(662, 356)
            Me.tbcEmployee.TabIndex = 6
            '
            'tbpPersonal
            '
            Me.tbpPersonal.BackgroundImage = CType(resources.GetObject("tbpPersonal.BackgroundImage"), System.Drawing.Image)
            Me.tbpPersonal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.tbpPersonal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.tbpPersonal.Controls.Add(Me.floPersonal)
            Me.tbpPersonal.Location = New System.Drawing.Point(4, 22)
            Me.tbpPersonal.Name = "tbpPersonal"
            Me.tbpPersonal.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpPersonal.Size = New System.Drawing.Size(654, 330)
            Me.tbpPersonal.TabIndex = 0
            Me.tbpPersonal.Text = "Personal Information"
            Me.tbpPersonal.UseVisualStyleBackColor = True
            '
            'floPersonal
            '
            Me.floPersonal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floPersonal.BackColor = System.Drawing.Color.Transparent
            Me.floPersonal.Controls.Add(Me.lblGender)
            Me.floPersonal.Controls.Add(Me.cacGender)
            Me.floPersonal.Controls.Add(Me.lblMaritalStatus)
            Me.floPersonal.Controls.Add(Me.cacMaritalStatus)
            Me.floPersonal.Controls.Add(Me.lblNationalityCode)
            Me.floPersonal.Controls.Add(Me.cacNationalityCode)
            Me.floPersonal.Controls.Add(Me.lblReligion)
            Me.floPersonal.Controls.Add(Me.cacReligionIdNo)
            Me.floPersonal.Controls.Add(Me.lblBirthDate)
            Me.floPersonal.Controls.Add(Me.dtpBirthDate)
            Me.floPersonal.Controls.Add(Me.lblNationalIdNo)
            Me.floPersonal.Controls.Add(Me.txtNationalIdNo)
            Me.floPersonal.Controls.Add(Me.lblNotes)
            Me.floPersonal.Controls.Add(Me.txtNotes)
            Me.floPersonal.Dock = System.Windows.Forms.DockStyle.Fill
            Me.floPersonal.Location = New System.Drawing.Point(3, 3)
            Me.floPersonal.Margin = New System.Windows.Forms.Padding(0)
            Me.floPersonal.MinimumSize = New System.Drawing.Size(430, 180)
            Me.floPersonal.Name = "floPersonal"
            Me.floPersonal.Size = New System.Drawing.Size(644, 320)
            Me.floPersonal.TabIndex = 4
            '
            'cacGender
            '
            Me.cacGender.BackColor = System.Drawing.Color.White
            Me.cacGender.BegFindValue = Nothing
            Me.cacGender.ChangingSearchValueOnly = False
            Me.cacGender.CurrentSearchTerm = ""
            Me.cacGender.DefaultValue = Nothing
            Me.cacGender.DisplayMember = "Name"
            Me.cacGender.EditingMode = False
            Me.cacGender.EndFindValue = Nothing
            Me.cacGender.FieldDescription = Nothing
            Me.cacGender.FieldName = Nothing
            Me.cacGender.FilterRule = Nothing
            Me.cacGender.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacGender.FindEnabled = False
            Me.floPersonal.SetFlowBreak(Me.cacGender, True)
            Me.cacGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacGender.ForeColor = System.Drawing.Color.Black
            Me.cacGender.FormattingEnabled = True
            Me.cacGender.HideWhenNotEditingOrAdding = False
            Me.cacGender.IgnoreCase = False
            Me.cacGender.IntegralHeight = False
            Me.cacGender.LinkedLabel = Me.lblMaritalStatus
            Me.cacGender.Location = New System.Drawing.Point(176, 1)
            Me.cacGender.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacGender.Name = "cacGender"
            Me.cacGender.OldValue = 0
            Me.cacGender.OriginalDataSource = Nothing
            Me.cacGender.OriginalList = Nothing
            Me.cacGender.OverrideDropDownStyleList = False
            Me.cacGender.PreviousSearchTerm = Nothing
            Me.cacGender.PropertySelector = Nothing
            Me.cacGender.ReadOnlyCombo = False
            Me.cacGender.Size = New System.Drawing.Size(124, 24)
            Me.cacGender.SuggestBoxHeight = 200
            Me.cacGender.SuggestListOrderRule = Nothing
            Me.cacGender.TabIndex = 1
            Me.cacGender.TextToSearch = Nothing
            Me.cacGender.ValueIsMandatory = False
            Me.cacGender.ValueIsNullable = False
            Me.cacGender.ValueIsNumeric = False
            Me.cacGender.ValueMember = "Code"
            '
            'lblNationalIdNo
            '
            Me.lblNationalIdNo.DisplayOnly = True
            Me.lblNationalIdNo.EditingMode = False
            Me.lblNationalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.txtNationalIdNo.BegFindValue = Nothing
            Me.txtNationalIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNationalIdNo.ComputedValue = False
            Me.txtNationalIdNo.CustomFormat = Nothing
            Me.txtNationalIdNo.DataBoundControl = True
            Me.txtNationalIdNo.EditingMode = True
            Me.txtNationalIdNo.EndFindValue = Nothing
            Me.txtNationalIdNo.FieldDescription = Nothing
            Me.txtNationalIdNo.FieldName = Nothing
            Me.txtNationalIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNationalIdNo.FindEnabled = True
            Me.floPersonal.SetFlowBreak(Me.txtNationalIdNo, True)
            Me.txtNationalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNationalIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtNationalIdNo.LinkedLabel = Me.lblNationalIdNo
            Me.txtNationalIdNo.Location = New System.Drawing.Point(177, 130)
            Me.txtNationalIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNationalIdNo.MaximumValue = Nothing
            Me.txtNationalIdNo.MinimumValue = Nothing
            Me.txtNationalIdNo.Name = "txtNationalIdNo"
            Me.txtNationalIdNo.OldValue = Nothing
            Me.txtNationalIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNationalIdNo.Size = New System.Drawing.Size(200, 23)
            Me.txtNationalIdNo.TabIndex = 6
            Me.txtNationalIdNo.ValueIsNumeric = True
            Me.txtNationalIdNo.ValueIsUniqueBlanksAllowed = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            Me.floPersonal.SetFlowBreak(Me.txtNotes, True)
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Me.lblNotes
            Me.txtNotes.Location = New System.Drawing.Point(177, 155)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Size = New System.Drawing.Size(422, 60)
            Me.txtNotes.TabIndex = 7
            Me.txtNotes.ValueIsMandatory = True
            '
            'tbpContact
            '
            Me.tbpContact.BackgroundImage = CType(resources.GetObject("tbpContact.BackgroundImage"), System.Drawing.Image)
            Me.tbpContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.tbpContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.tbpContact.Controls.Add(Me.floContactInformation)
            Me.tbpContact.Location = New System.Drawing.Point(4, 22)
            Me.tbpContact.Name = "tbpContact"
            Me.tbpContact.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpContact.Size = New System.Drawing.Size(654, 330)
            Me.tbpContact.TabIndex = 1
            Me.tbpContact.Text = "Contact Information"
            Me.tbpContact.UseVisualStyleBackColor = True
            '
            'floContactInformation
            '
            Me.floContactInformation.BackColor = System.Drawing.Color.Transparent
            Me.floContactInformation.Controls.Add(Me.TableLayoutPanel1)
            Me.floContactInformation.Location = New System.Drawing.Point(3, 3)
            Me.floContactInformation.Name = "floContactInformation"
            Me.floContactInformation.Size = New System.Drawing.Size(641, 317)
            Me.floContactInformation.TabIndex = 8
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
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
            Me.TableLayoutPanel1.RowCount = 10
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(638, 322)
            Me.TableLayoutPanel1.TabIndex = 274
            '
            'DataGridViewPhoneDisplay
            '
            Me.DataGridViewPhoneDisplay.AllowUserToAddRows = False
            Me.DataGridViewPhoneDisplay.AllowUserToDeleteRows = False
            Me.DataGridViewPhoneDisplay.AllowUserToResizeColumns = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPhoneDisplay.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPhoneDisplay.AutoGenerateColumns = False
            Me.DataGridViewPhoneDisplay.BegFindValue = Nothing
            Me.DataGridViewPhoneDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPhoneDisplay.ColumnHeadersVisible = False
            Me.DataGridViewPhoneDisplay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequencePhoneDisplay, Me.FullPhone, Me.FullPhoneAra, Me.AreaCodeDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.CountryTelIdNoDataGridViewTextBoxColumn, Me.PhoneNumberDataGridViewTextBoxColumn, Me.PhoneTypeIdNoDataGridViewTextBoxColumn})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewPhoneDisplay, 4)
            Me.DataGridViewPhoneDisplay.DataSource = Me.bsPhones
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPhoneDisplay.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewPhoneDisplay.DgvFooter = Nothing
            Me.DataGridViewPhoneDisplay.DisplayOnly = False
            Me.DataGridViewPhoneDisplay.Ea = Nothing
            Me.DataGridViewPhoneDisplay.EditingMode = False
            Me.DataGridViewPhoneDisplay.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPhoneDisplay.EndFindValue = Nothing
            Me.DataGridViewPhoneDisplay.FieldDescription = Nothing
            Me.DataGridViewPhoneDisplay.FieldName = Nothing
            Me.DataGridViewPhoneDisplay.FieldsDictionary = Nothing
            Me.DataGridViewPhoneDisplay.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPhoneDisplay.FindEnabled = False
            Me.DataGridViewPhoneDisplay.FirstRowDeletionEnabled = True
            Me.DataGridViewPhoneDisplay.FirstRowInsertionEnabled = True
            Me.DataGridViewPhoneDisplay.IgnoreCase = False
            Me.DataGridViewPhoneDisplay.Location = New System.Drawing.Point(3, 174)
            Me.DataGridViewPhoneDisplay.Name = "DataGridViewPhoneDisplay"
            Me.DataGridViewPhoneDisplay.ReadOnly = True
            Me.DataGridViewPhoneDisplay.RowHeadersVisible = False
            Me.DataGridViewPhoneDisplay.ScrollBars = System.Windows.Forms.ScrollBars.None
            Me.DataGridViewPhoneDisplay.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPhoneDisplay.SequenceColumn = "dgvSequencePhoneDisplay"
            Me.DataGridViewPhoneDisplay.SequenceFieldName = "Sequence"
            Me.DataGridViewPhoneDisplay.ShowFooter = False
            Me.DataGridViewPhoneDisplay.ShowInsertColumnWhenEditing = True
            Me.DataGridViewPhoneDisplay.Size = New System.Drawing.Size(363, 140)
            Me.DataGridViewPhoneDisplay.TabIndex = 291
            '
            'dgvSequencePhoneDisplay
            '
            Me.dgvSequencePhoneDisplay.DataPropertyName = "Sequence"
            Me.dgvSequencePhoneDisplay.HeaderText = "Seq"
            Me.dgvSequencePhoneDisplay.Name = "dgvSequencePhoneDisplay"
            Me.dgvSequencePhoneDisplay.ReadOnly = True
            Me.dgvSequencePhoneDisplay.Width = 15
            '
            'FullPhone
            '
            Me.FullPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.FullPhone.DataPropertyName = "FullPhone"
            Me.FullPhone.HeaderText = "FullPhone"
            Me.FullPhone.Name = "FullPhone"
            Me.FullPhone.ReadOnly = True
            '
            'FullPhoneAra
            '
            Me.FullPhoneAra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.FullPhoneAra.DataPropertyName = "FullPhoneAra"
            Me.FullPhoneAra.HeaderText = "FullPhoneAra"
            Me.FullPhoneAra.Name = "FullPhoneAra"
            Me.FullPhoneAra.ReadOnly = True
            Me.FullPhoneAra.Visible = False
            '
            'AreaCodeDataGridViewTextBoxColumn
            '
            Me.AreaCodeDataGridViewTextBoxColumn.DataPropertyName = "AreaCode"
            Me.AreaCodeDataGridViewTextBoxColumn.HeaderText = "AreaCode"
            Me.AreaCodeDataGridViewTextBoxColumn.Name = "AreaCodeDataGridViewTextBoxColumn"
            Me.AreaCodeDataGridViewTextBoxColumn.ReadOnly = True
            Me.AreaCodeDataGridViewTextBoxColumn.Visible = False
            '
            'DataGridViewTextBoxColumn15
            '
            Me.DataGridViewTextBoxColumn15.DataPropertyName = "EmployeeIdNo"
            Me.DataGridViewTextBoxColumn15.HeaderText = "EmployeeIdNo"
            Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
            Me.DataGridViewTextBoxColumn15.ReadOnly = True
            Me.DataGridViewTextBoxColumn15.Visible = False
            '
            'DataGridViewTextBoxColumn16
            '
            Me.DataGridViewTextBoxColumn16.DataPropertyName = "IdNo"
            Me.DataGridViewTextBoxColumn16.HeaderText = "IdNo"
            Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
            Me.DataGridViewTextBoxColumn16.ReadOnly = True
            Me.DataGridViewTextBoxColumn16.Visible = False
            '
            'CountryTelIdNoDataGridViewTextBoxColumn
            '
            Me.CountryTelIdNoDataGridViewTextBoxColumn.DataPropertyName = "CountryTelIdNo"
            Me.CountryTelIdNoDataGridViewTextBoxColumn.HeaderText = "CountryTelIdNo"
            Me.CountryTelIdNoDataGridViewTextBoxColumn.Name = "CountryTelIdNoDataGridViewTextBoxColumn"
            Me.CountryTelIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.CountryTelIdNoDataGridViewTextBoxColumn.Visible = False
            '
            'PhoneNumberDataGridViewTextBoxColumn
            '
            Me.PhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber"
            Me.PhoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber"
            Me.PhoneNumberDataGridViewTextBoxColumn.Name = "PhoneNumberDataGridViewTextBoxColumn"
            Me.PhoneNumberDataGridViewTextBoxColumn.ReadOnly = True
            Me.PhoneNumberDataGridViewTextBoxColumn.Visible = False
            '
            'PhoneTypeIdNoDataGridViewTextBoxColumn
            '
            Me.PhoneTypeIdNoDataGridViewTextBoxColumn.DataPropertyName = "PhoneTypeIdNo"
            Me.PhoneTypeIdNoDataGridViewTextBoxColumn.HeaderText = "PhoneTypeIdNo"
            Me.PhoneTypeIdNoDataGridViewTextBoxColumn.Name = "PhoneTypeIdNoDataGridViewTextBoxColumn"
            Me.PhoneTypeIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.PhoneTypeIdNoDataGridViewTextBoxColumn.Visible = False
            '
            'bsPhones
            '
            Me.bsPhones.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.EmployeePhoneModel)
            '
            'txtZipCode
            '
            Me.txtZipCode.BackColor = System.Drawing.Color.White
            Me.txtZipCode.BegFindValue = Nothing
            Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtZipCode.ComputedValue = False
            Me.txtZipCode.CustomFormat = Nothing
            Me.txtZipCode.DataBoundControl = True
            Me.txtZipCode.EditingMode = False
            Me.txtZipCode.EndFindValue = Nothing
            Me.txtZipCode.FieldDescription = Nothing
            Me.txtZipCode.FieldName = Nothing
            Me.txtZipCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtZipCode.FindEnabled = True
            Me.txtZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtZipCode.ForeColor = System.Drawing.Color.Black
            Me.txtZipCode.LinkedLabel = Nothing
            Me.txtZipCode.Location = New System.Drawing.Point(401, 127)
            Me.txtZipCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtZipCode.MaximumValue = Nothing
            Me.txtZipCode.MinimumValue = Nothing
            Me.txtZipCode.Name = "txtZipCode"
            Me.txtZipCode.OldValue = Nothing
            Me.txtZipCode.ReadOnly = True
            Me.txtZipCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtZipCode.Size = New System.Drawing.Size(193, 23)
            Me.txtZipCode.TabIndex = 290
            '
            'lblZipCode
            '
            Me.lblZipCode.DisplayOnly = True
            Me.lblZipCode.EditingMode = False
            Me.lblZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblZipCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblZipCode.Location = New System.Drawing.Point(316, 127)
            Me.lblZipCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblZipCode.Name = "lblZipCode"
            Me.lblZipCode.Size = New System.Drawing.Size(83, 18)
            Me.lblZipCode.TabIndex = 289
            Me.lblZipCode.Text = "Zip Code"
            Me.lblZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPoBox
            '
            Me.txtPoBox.BackColor = System.Drawing.Color.White
            Me.txtPoBox.BegFindValue = Nothing
            Me.txtPoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPoBox.ComputedValue = False
            Me.txtPoBox.CustomFormat = Nothing
            Me.txtPoBox.DataBoundControl = True
            Me.txtPoBox.EditingMode = False
            Me.txtPoBox.EndFindValue = Nothing
            Me.txtPoBox.FieldDescription = Nothing
            Me.txtPoBox.FieldName = Nothing
            Me.txtPoBox.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPoBox.FindEnabled = True
            Me.txtPoBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPoBox.ForeColor = System.Drawing.Color.Black
            Me.txtPoBox.LinkedLabel = Nothing
            Me.txtPoBox.Location = New System.Drawing.Point(128, 127)
            Me.txtPoBox.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPoBox.MaximumValue = Nothing
            Me.txtPoBox.MinimumValue = Nothing
            Me.txtPoBox.Name = "txtPoBox"
            Me.txtPoBox.OldValue = Nothing
            Me.txtPoBox.ReadOnly = True
            Me.txtPoBox.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPoBox.Size = New System.Drawing.Size(186, 23)
            Me.txtPoBox.TabIndex = 288
            '
            'lblPoBox
            '
            Me.lblPoBox.DisplayOnly = True
            Me.lblPoBox.EditingMode = False
            Me.lblPoBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.cacCountryCode.BegFindValue = Nothing
            Me.cacCountryCode.ChangingSearchValueOnly = False
            Me.cacCountryCode.CurrentSearchTerm = ""
            Me.cacCountryCode.DefaultValue = Nothing
            Me.cacCountryCode.DisplayMember = "Name"
            Me.cacCountryCode.EditingMode = False
            Me.cacCountryCode.EndFindValue = Nothing
            Me.cacCountryCode.FieldDescription = Nothing
            Me.cacCountryCode.FieldName = Nothing
            Me.cacCountryCode.FilterRule = Nothing
            Me.cacCountryCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacCountryCode.FindEnabled = False
            Me.cacCountryCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacCountryCode.ForeColor = System.Drawing.Color.Black
            Me.cacCountryCode.FormattingEnabled = True
            Me.cacCountryCode.HideWhenNotEditingOrAdding = False
            Me.cacCountryCode.IgnoreCase = False
            Me.cacCountryCode.IntegralHeight = False
            Me.cacCountryCode.LinkedLabel = Nothing
            Me.cacCountryCode.Location = New System.Drawing.Point(400, 101)
            Me.cacCountryCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacCountryCode.Name = "cacCountryCode"
            Me.cacCountryCode.OldValue = 0
            Me.cacCountryCode.OriginalDataSource = Nothing
            Me.cacCountryCode.OriginalList = Nothing
            Me.cacCountryCode.OverrideDropDownStyleList = False
            Me.cacCountryCode.PreviousSearchTerm = Nothing
            Me.cacCountryCode.PropertySelector = Nothing
            Me.cacCountryCode.ReadOnlyCombo = False
            Me.cacCountryCode.Size = New System.Drawing.Size(195, 24)
            Me.cacCountryCode.SuggestBoxHeight = 200
            Me.cacCountryCode.SuggestListOrderRule = Nothing
            Me.cacCountryCode.TabIndex = 286
            Me.cacCountryCode.TextToSearch = Nothing
            Me.cacCountryCode.ValueIsMandatory = False
            Me.cacCountryCode.ValueIsNullable = False
            Me.cacCountryCode.ValueIsNumeric = False
            Me.cacCountryCode.ValueMember = "Code"
            '
            'lblCountryCode
            '
            Me.lblCountryCode.DisplayOnly = True
            Me.lblCountryCode.EditingMode = False
            Me.lblCountryCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCountryCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCountryCode.Location = New System.Drawing.Point(316, 101)
            Me.lblCountryCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCountryCode.Name = "lblCountryCode"
            Me.lblCountryCode.Size = New System.Drawing.Size(70, 18)
            Me.lblCountryCode.TabIndex = 285
            Me.lblCountryCode.Text = "Country"
            Me.lblCountryCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtProvinceState
            '
            Me.txtProvinceState.BackColor = System.Drawing.Color.White
            Me.txtProvinceState.BegFindValue = Nothing
            Me.txtProvinceState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProvinceState.ComputedValue = False
            Me.txtProvinceState.CustomFormat = Nothing
            Me.txtProvinceState.DataBoundControl = True
            Me.txtProvinceState.EditingMode = False
            Me.txtProvinceState.EndFindValue = Nothing
            Me.txtProvinceState.FieldDescription = Nothing
            Me.txtProvinceState.FieldName = Nothing
            Me.txtProvinceState.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtProvinceState.FindEnabled = True
            Me.txtProvinceState.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtProvinceState.ForeColor = System.Drawing.Color.Black
            Me.txtProvinceState.LinkedLabel = Nothing
            Me.txtProvinceState.Location = New System.Drawing.Point(128, 101)
            Me.txtProvinceState.Margin = New System.Windows.Forms.Padding(1)
            Me.txtProvinceState.MaximumValue = Nothing
            Me.txtProvinceState.MinimumValue = Nothing
            Me.txtProvinceState.Name = "txtProvinceState"
            Me.txtProvinceState.OldValue = Nothing
            Me.txtProvinceState.ReadOnly = True
            Me.txtProvinceState.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtProvinceState.Size = New System.Drawing.Size(186, 23)
            Me.txtProvinceState.TabIndex = 284
            '
            'lblProvinceState
            '
            Me.lblProvinceState.DisplayOnly = True
            Me.lblProvinceState.EditingMode = False
            Me.lblProvinceState.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.txtTownCity.BegFindValue = Nothing
            Me.txtTownCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTownCity.ComputedValue = False
            Me.txtTownCity.CustomFormat = Nothing
            Me.txtTownCity.DataBoundControl = True
            Me.txtTownCity.EditingMode = False
            Me.txtTownCity.EndFindValue = Nothing
            Me.txtTownCity.FieldDescription = Nothing
            Me.txtTownCity.FieldName = Nothing
            Me.txtTownCity.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTownCity.FindEnabled = True
            Me.txtTownCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtTownCity.ForeColor = System.Drawing.Color.Black
            Me.txtTownCity.LinkedLabel = Nothing
            Me.txtTownCity.Location = New System.Drawing.Point(401, 76)
            Me.txtTownCity.Margin = New System.Windows.Forms.Padding(1)
            Me.txtTownCity.MaximumValue = Nothing
            Me.txtTownCity.MinimumValue = Nothing
            Me.txtTownCity.Name = "txtTownCity"
            Me.txtTownCity.OldValue = Nothing
            Me.txtTownCity.ReadOnly = True
            Me.txtTownCity.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTownCity.Size = New System.Drawing.Size(193, 23)
            Me.txtTownCity.TabIndex = 282
            '
            'lblTownCity
            '
            Me.lblTownCity.DisplayOnly = True
            Me.lblTownCity.EditingMode = False
            Me.lblTownCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTownCity.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTownCity.Location = New System.Drawing.Point(316, 76)
            Me.lblTownCity.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTownCity.Name = "lblTownCity"
            Me.lblTownCity.Size = New System.Drawing.Size(83, 18)
            Me.lblTownCity.TabIndex = 281
            Me.lblTownCity.Text = "Town/City"
            Me.lblTownCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtDistrict
            '
            Me.txtDistrict.BackColor = System.Drawing.Color.White
            Me.txtDistrict.BegFindValue = Nothing
            Me.txtDistrict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDistrict.ComputedValue = False
            Me.txtDistrict.CustomFormat = Nothing
            Me.txtDistrict.DataBoundControl = True
            Me.txtDistrict.EditingMode = False
            Me.txtDistrict.EndFindValue = Nothing
            Me.txtDistrict.FieldDescription = Nothing
            Me.txtDistrict.FieldName = Nothing
            Me.txtDistrict.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDistrict.FindEnabled = True
            Me.txtDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDistrict.ForeColor = System.Drawing.Color.Black
            Me.txtDistrict.LinkedLabel = Nothing
            Me.txtDistrict.Location = New System.Drawing.Point(128, 76)
            Me.txtDistrict.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDistrict.MaximumValue = Nothing
            Me.txtDistrict.MinimumValue = Nothing
            Me.txtDistrict.Name = "txtDistrict"
            Me.txtDistrict.OldValue = Nothing
            Me.txtDistrict.ReadOnly = True
            Me.txtDistrict.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDistrict.Size = New System.Drawing.Size(186, 23)
            Me.txtDistrict.TabIndex = 280
            '
            'lblDistrict
            '
            Me.lblDistrict.DisplayOnly = True
            Me.lblDistrict.EditingMode = False
            Me.lblDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.txtStreet.BegFindValue = Nothing
            Me.txtStreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtStreet, 3)
            Me.txtStreet.ComputedValue = False
            Me.txtStreet.CustomFormat = Nothing
            Me.txtStreet.DataBoundControl = True
            Me.txtStreet.EditingMode = False
            Me.txtStreet.EndFindValue = Nothing
            Me.txtStreet.FieldDescription = Nothing
            Me.txtStreet.FieldName = Nothing
            Me.txtStreet.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtStreet.FindEnabled = True
            Me.txtStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtStreet.ForeColor = System.Drawing.Color.Black
            Me.txtStreet.LinkedLabel = Nothing
            Me.txtStreet.Location = New System.Drawing.Point(128, 51)
            Me.txtStreet.Margin = New System.Windows.Forms.Padding(1)
            Me.txtStreet.MaximumValue = Nothing
            Me.txtStreet.MinimumValue = Nothing
            Me.txtStreet.Name = "txtStreet"
            Me.txtStreet.OldValue = Nothing
            Me.txtStreet.ReadOnly = True
            Me.txtStreet.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtStreet.Size = New System.Drawing.Size(510, 23)
            Me.txtStreet.TabIndex = 278
            '
            'txtEmail
            '
            Me.txtEmail.BackColor = System.Drawing.Color.White
            Me.txtEmail.BegFindValue = Nothing
            Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtEmail, 3)
            Me.txtEmail.ComputedValue = False
            Me.txtEmail.CustomFormat = Nothing
            Me.txtEmail.DataBoundControl = True
            Me.txtEmail.EditingMode = False
            Me.txtEmail.EndFindValue = Nothing
            Me.txtEmail.FieldDescription = Nothing
            Me.txtEmail.FieldName = Nothing
            Me.txtEmail.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtEmail.FindEnabled = True
            Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmail.ForeColor = System.Drawing.Color.Black
            Me.txtEmail.LinkedLabel = Nothing
            Me.txtEmail.Location = New System.Drawing.Point(128, 1)
            Me.txtEmail.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmail.MaximumValue = Nothing
            Me.txtEmail.MinimumValue = Nothing
            Me.txtEmail.Name = "txtEmail"
            Me.txtEmail.OldValue = Nothing
            Me.txtEmail.ReadOnly = True
            Me.txtEmail.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtEmail.Size = New System.Drawing.Size(510, 23)
            Me.txtEmail.TabIndex = 274
            '
            'CLabel1
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel1, 4)
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel1.Location = New System.Drawing.Point(1, 26)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(637, 23)
            Me.CLabel1.TabIndex = 213
            Me.CLabel1.Text = "Home Address"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblEmail
            '
            Me.lblEmail.DisplayOnly = True
            Me.lblEmail.EditingMode = False
            Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.lblStreet.AutoSize = True
            Me.lblStreet.DisplayOnly = True
            Me.lblStreet.EditingMode = False
            Me.lblStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.tbpEmployment.Size = New System.Drawing.Size(654, 330)
            Me.tbpEmployment.TabIndex = 3
            Me.tbpEmployment.Text = "Employment Information"
            Me.tbpEmployment.UseVisualStyleBackColor = True
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
            Me.CFlowLayout5.Size = New System.Drawing.Size(654, 330)
            Me.CFlowLayout5.TabIndex = 286
            '
            'lblHiredDate
            '
            Me.lblHiredDate.DisplayOnly = True
            Me.lblHiredDate.EditingMode = False
            Me.lblHiredDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.dtpHiredDate.DisplayOnly = False
            Me.dtpHiredDate.DtpDefaultValue = Nothing
            Me.dtpHiredDate.EditingMode = False
            Me.dtpHiredDate.EditsAllowed = False
            Me.CFlowLayout5.SetFlowBreak(Me.dtpHiredDate, True)
            Me.dtpHiredDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpHiredDate.ForeColor = System.Drawing.Color.Black
            Me.dtpHiredDate.LinkedLabel = Nothing
            Me.dtpHiredDate.Location = New System.Drawing.Point(179, 3)
            Me.dtpHiredDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpHiredDate.Name = "dtpHiredDate"
            Me.dtpHiredDate.ReadOnlyDp = False
            Me.dtpHiredDate.SecurityKey = Nothing
            Me.dtpHiredDate.ShowLongDate = False
            Me.dtpHiredDate.ShowTime = False
            Me.dtpHiredDate.Size = New System.Drawing.Size(123, 24)
            Me.dtpHiredDate.TabIndex = 1
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
            Me.dtpReleasedDate.DisplayOnly = False
            Me.dtpReleasedDate.DtpDefaultValue = Nothing
            Me.dtpReleasedDate.EditingMode = False
            Me.dtpReleasedDate.EditsAllowed = False
            Me.CFlowLayout5.SetFlowBreak(Me.dtpReleasedDate, True)
            Me.dtpReleasedDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpReleasedDate.ForeColor = System.Drawing.Color.Black
            Me.dtpReleasedDate.LinkedLabel = Nothing
            Me.dtpReleasedDate.Location = New System.Drawing.Point(179, 29)
            Me.dtpReleasedDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpReleasedDate.Name = "dtpReleasedDate"
            Me.dtpReleasedDate.ReadOnlyDp = False
            Me.dtpReleasedDate.SecurityKey = Nothing
            Me.dtpReleasedDate.ShowLongDate = False
            Me.dtpReleasedDate.ShowTime = False
            Me.dtpReleasedDate.Size = New System.Drawing.Size(123, 24)
            Me.dtpReleasedDate.TabIndex = 2
            Me.dtpReleasedDate.TargetCalendar = CType(resources.GetObject("dtpReleasedDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpReleasedDate.Value = Nothing
            Me.dtpReleasedDate.ValueIsMandatory = False
            Me.dtpReleasedDate.ValueIsNullable = False
            '
            'lblDepartmentIdNo
            '
            Me.lblDepartmentIdNo.DisplayOnly = True
            Me.lblDepartmentIdNo.EditingMode = False
            Me.lblDepartmentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.cacDepartmentIdNo.BegFindValue = Nothing
            Me.cacDepartmentIdNo.ChangingSearchValueOnly = False
            Me.cacDepartmentIdNo.CurrentSearchTerm = ""
            Me.cacDepartmentIdNo.DefaultValue = Nothing
            Me.cacDepartmentIdNo.DisplayMember = "Name"
            Me.cacDepartmentIdNo.EditingMode = False
            Me.cacDepartmentIdNo.EndFindValue = Nothing
            Me.cacDepartmentIdNo.FieldDescription = Nothing
            Me.cacDepartmentIdNo.FieldName = Nothing
            Me.cacDepartmentIdNo.FilterRule = Nothing
            Me.cacDepartmentIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacDepartmentIdNo.FindEnabled = False
            Me.CFlowLayout5.SetFlowBreak(Me.cacDepartmentIdNo, True)
            Me.cacDepartmentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacDepartmentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacDepartmentIdNo.FormattingEnabled = True
            Me.cacDepartmentIdNo.HideWhenNotEditingOrAdding = False
            Me.cacDepartmentIdNo.IgnoreCase = False
            Me.cacDepartmentIdNo.IntegralHeight = False
            Me.cacDepartmentIdNo.LinkedLabel = Me.lblDepartmentIdNo
            Me.cacDepartmentIdNo.Location = New System.Drawing.Point(179, 56)
            Me.cacDepartmentIdNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacDepartmentIdNo.Name = "cacDepartmentIdNo"
            Me.cacDepartmentIdNo.OldValue = 0
            Me.cacDepartmentIdNo.OriginalDataSource = Nothing
            Me.cacDepartmentIdNo.OriginalList = Nothing
            Me.cacDepartmentIdNo.OverrideDropDownStyleList = False
            Me.cacDepartmentIdNo.PreviousSearchTerm = Nothing
            Me.cacDepartmentIdNo.PropertySelector = Nothing
            Me.cacDepartmentIdNo.ReadOnlyCombo = False
            Me.cacDepartmentIdNo.Size = New System.Drawing.Size(279, 24)
            Me.cacDepartmentIdNo.SuggestBoxHeight = 200
            Me.cacDepartmentIdNo.SuggestListOrderRule = Nothing
            Me.cacDepartmentIdNo.TabIndex = 3
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
            Me.cacDesignationIdNo.BegFindValue = Nothing
            Me.cacDesignationIdNo.ChangingSearchValueOnly = False
            Me.cacDesignationIdNo.CurrentSearchTerm = ""
            Me.cacDesignationIdNo.DefaultValue = Nothing
            Me.cacDesignationIdNo.DisplayMember = "Name"
            Me.cacDesignationIdNo.EditingMode = False
            Me.cacDesignationIdNo.EndFindValue = Nothing
            Me.cacDesignationIdNo.FieldDescription = Nothing
            Me.cacDesignationIdNo.FieldName = Nothing
            Me.cacDesignationIdNo.FilterRule = Nothing
            Me.cacDesignationIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacDesignationIdNo.FindEnabled = False
            Me.CFlowLayout5.SetFlowBreak(Me.cacDesignationIdNo, True)
            Me.cacDesignationIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacDesignationIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacDesignationIdNo.FormattingEnabled = True
            Me.cacDesignationIdNo.HideWhenNotEditingOrAdding = False
            Me.cacDesignationIdNo.IgnoreCase = False
            Me.cacDesignationIdNo.IntegralHeight = False
            Me.cacDesignationIdNo.LinkedLabel = Me.lblDesignationIdNo
            Me.cacDesignationIdNo.Location = New System.Drawing.Point(180, 82)
            Me.cacDesignationIdNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cacDesignationIdNo.Name = "cacDesignationIdNo"
            Me.cacDesignationIdNo.OldValue = 0
            Me.cacDesignationIdNo.OriginalDataSource = Nothing
            Me.cacDesignationIdNo.OriginalList = Nothing
            Me.cacDesignationIdNo.OverrideDropDownStyleList = False
            Me.cacDesignationIdNo.PreviousSearchTerm = Nothing
            Me.cacDesignationIdNo.PropertySelector = Nothing
            Me.cacDesignationIdNo.ReadOnlyCombo = False
            Me.cacDesignationIdNo.Size = New System.Drawing.Size(223, 24)
            Me.cacDesignationIdNo.SuggestBoxHeight = 200
            Me.cacDesignationIdNo.SuggestListOrderRule = Nothing
            Me.cacDesignationIdNo.TabIndex = 4
            Me.cacDesignationIdNo.TextToSearch = Nothing
            Me.cacDesignationIdNo.ValueIsMandatory = False
            Me.cacDesignationIdNo.ValueIsNullable = False
            Me.cacDesignationIdNo.ValueIsNumeric = False
            Me.cacDesignationIdNo.ValueMember = "IdNo"
            '
            'lblActive
            '
            Me.lblActive.DisplayOnly = True
            Me.lblActive.EditingMode = False
            Me.lblActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.chkActive.AutoCheck = False
            Me.chkActive.BackColor = System.Drawing.Color.White
            Me.chkActive.BegFindValue = Nothing
            Me.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkActive.DisplayOnly = False
            Me.chkActive.EditingMode = False
            Me.chkActive.EndFindValue = Nothing
            Me.chkActive.FieldDescription = Nothing
            Me.chkActive.FieldName = Nothing
            Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkActive.FindEnabled = True
            Me.chkActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CFlowLayout5.SetFlowBreak(Me.chkActive, True)
            Me.chkActive.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.chkActive.ForeColor = System.Drawing.Color.Black
            Me.chkActive.IFindableControl_FindEnabled = False
            Me.chkActive.IgnoreCase = False
            Me.chkActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkActive.LinkedLabel = Me.lblActive
            Me.chkActive.Location = New System.Drawing.Point(181, 108)
            Me.chkActive.Margin = New System.Windows.Forms.Padding(1)
            Me.chkActive.Name = "chkActive"
            Me.chkActive.NoLabel = False
            Me.chkActive.OldValue = ""
            Me.chkActive.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkActive.Size = New System.Drawing.Size(13, 13)
            Me.chkActive.TabIndex = 5
            Me.chkActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkActive.UseVisualStyleBackColor = False
            '
            'tbpPayroll
            '
            Me.tbpPayroll.BackgroundImage = CType(resources.GetObject("tbpPayroll.BackgroundImage"), System.Drawing.Image)
            Me.tbpPayroll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.tbpPayroll.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.tbpPayroll.Controls.Add(Me.CFlowLayout6)
            Me.tbpPayroll.Location = New System.Drawing.Point(4, 22)
            Me.tbpPayroll.Name = "tbpPayroll"
            Me.tbpPayroll.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpPayroll.Size = New System.Drawing.Size(654, 330)
            Me.tbpPayroll.TabIndex = 2
            Me.tbpPayroll.Text = "Payroll Information"
            Me.tbpPayroll.UseVisualStyleBackColor = True
            '
            'tbpEarnings
            '
            Me.tbpEarnings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.tbpEarnings.Controls.Add(Me.DataGridViewEarnings)
            Me.tbpEarnings.Location = New System.Drawing.Point(4, 22)
            Me.tbpEarnings.Name = "tbpEarnings"
            Me.tbpEarnings.Size = New System.Drawing.Size(654, 330)
            Me.tbpEarnings.TabIndex = 4
            Me.tbpEarnings.Text = "Earnings"
            Me.tbpEarnings.UseVisualStyleBackColor = True
            '
            'DataGridViewEarnings
            '
            Me.DataGridViewEarnings.AllowUserToOrderColumns = True
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewEarnings.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
            Me.DataGridViewEarnings.AutoGenerateColumns = False
            Me.DataGridViewEarnings.BackgroundColor = System.Drawing.Color.White
            Me.DataGridViewEarnings.BegFindValue = Nothing
            Me.DataGridViewEarnings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewEarnings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceEarning, Me.dgvEarningIdNo, Me.dgvEarningRate, Me.dgvEarningUnit, Me.dgvEarningAmount, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
            Me.DataGridViewEarnings.DataSource = Me.bsEarnings
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewEarnings.DefaultCellStyle = DataGridViewCellStyle9
            Me.DataGridViewEarnings.DgvFooter = Nothing
            Me.DataGridViewEarnings.DisplayOnly = False
            Me.DataGridViewEarnings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewEarnings.Ea = EventAggregator1
            Me.DataGridViewEarnings.EditingMode = False
            Me.DataGridViewEarnings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewEarnings.EndFindValue = Nothing
            Me.DataGridViewEarnings.FieldDescription = Nothing
            Me.DataGridViewEarnings.FieldName = Nothing
            Me.DataGridViewEarnings.FieldsDictionary = Nothing
            Me.DataGridViewEarnings.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewEarnings.FindEnabled = False
            Me.DataGridViewEarnings.FirstRowDeletionEnabled = True
            Me.DataGridViewEarnings.FirstRowInsertionEnabled = True
            Me.DataGridViewEarnings.IgnoreCase = False
            Me.DataGridViewEarnings.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewEarnings.Name = "DataGridViewEarnings"
            Me.DataGridViewEarnings.ReadOnly = True
            Me.DataGridViewEarnings.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewEarnings.SequenceColumn = "dgvSequenceEarning"
            Me.DataGridViewEarnings.SequenceFieldName = "Sequence"
            Me.DataGridViewEarnings.ShowFooter = True
            Me.DataGridViewEarnings.ShowInsertColumnWhenEditing = True
            Me.DataGridViewEarnings.Size = New System.Drawing.Size(654, 330)
            Me.DataGridViewEarnings.TabIndex = 5
            '
            'dgvSequenceEarning
            '
            Me.dgvSequenceEarning.BegFindValue = Nothing
            Me.dgvSequenceEarning.DataPropertyName = "Sequence"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvSequenceEarning.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvSequenceEarning.EditingMode = False
            Me.dgvSequenceEarning.EndFindValue = Nothing
            Me.dgvSequenceEarning.FieldDescription = Nothing
            Me.dgvSequenceEarning.FieldName = Nothing
            Me.dgvSequenceEarning.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequenceEarning.FindEnabled = False
            Me.dgvSequenceEarning.HeaderText = "Seq"
            Me.dgvSequenceEarning.IgnoreCase = False
            Me.dgvSequenceEarning.MinimumWidth = 30
            Me.dgvSequenceEarning.Name = "dgvSequenceEarning"
            Me.dgvSequenceEarning.ReadOnly = True
            Me.dgvSequenceEarning.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequenceEarning.Width = 30
            '
            'dgvEarningIdNo
            '
            Me.dgvEarningIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvEarningIdNo.DataPropertyName = "PayElementIdNo"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvEarningIdNo.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvEarningIdNo.EditingMode = False
            Me.dgvEarningIdNo.HeaderText = "Earning Name - Code"
            Me.dgvEarningIdNo.Name = "dgvEarningIdNo"
            Me.dgvEarningIdNo.ReadOnly = True
            Me.dgvEarningIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEarningIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvEarningRate
            '
            Me.dgvEarningRate.DataPropertyName = "Rate"
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvEarningRate.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvEarningRate.EditingMode = False
            Me.dgvEarningRate.HeaderText = "Rate / Amount"
            Me.dgvEarningRate.Name = "dgvEarningRate"
            Me.dgvEarningRate.ReadOnly = True
            Me.dgvEarningRate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEarningRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvEarningRate.Width = 80
            '
            'dgvEarningUnit
            '
            Me.dgvEarningUnit.DataPropertyName = "Unit"
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvEarningUnit.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvEarningUnit.EditingMode = False
            Me.dgvEarningUnit.HeaderText = "Unit"
            Me.dgvEarningUnit.Name = "dgvEarningUnit"
            Me.dgvEarningUnit.ReadOnly = True
            Me.dgvEarningUnit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEarningUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvEarningAmount
            '
            Me.dgvEarningAmount.BegFindValue = Nothing
            Me.dgvEarningAmount.DataPropertyName = "Amount"
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.Format = "###,##0.00"
            Me.dgvEarningAmount.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvEarningAmount.EditingMode = False
            Me.dgvEarningAmount.EndFindValue = Nothing
            Me.dgvEarningAmount.FieldDescription = Nothing
            Me.dgvEarningAmount.FieldName = Nothing
            Me.dgvEarningAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvEarningAmount.FindEnabled = False
            Me.dgvEarningAmount.HeaderText = "Payroll Amount"
            Me.dgvEarningAmount.MinimumWidth = 80
            Me.dgvEarningAmount.Name = "dgvEarningAmount"
            Me.dgvEarningAmount.ReadOnly = True
            Me.dgvEarningAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEarningAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvEarningAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvEarningAmount.Width = 80
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.DataPropertyName = "EmployeeIdNo"
            Me.DataGridViewTextBoxColumn7.HeaderText = "EmployeeIdNo"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            Me.DataGridViewTextBoxColumn7.ReadOnly = True
            Me.DataGridViewTextBoxColumn7.Visible = False
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.DataPropertyName = "IdNo"
            Me.DataGridViewTextBoxColumn8.HeaderText = "IdNo"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            Me.DataGridViewTextBoxColumn8.Visible = False
            '
            'tbpDeductions
            '
            Me.tbpDeductions.Controls.Add(Me.DataGridViewDeductions)
            Me.tbpDeductions.Location = New System.Drawing.Point(4, 22)
            Me.tbpDeductions.Name = "tbpDeductions"
            Me.tbpDeductions.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpDeductions.Size = New System.Drawing.Size(654, 330)
            Me.tbpDeductions.TabIndex = 6
            Me.tbpDeductions.Text = "Deductions"
            Me.tbpDeductions.UseVisualStyleBackColor = True
            '
            'DataGridViewDeductions
            '
            Me.DataGridViewDeductions.AllowUserToOrderColumns = True
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewDeductions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
            Me.DataGridViewDeductions.AutoGenerateColumns = False
            Me.DataGridViewDeductions.BegFindValue = Nothing
            Me.DataGridViewDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewDeductions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceDeduction, Me.dgvDeductionIdNo, Me.dgvDeductionRate, Me.dgvDeductionUnit, Me.dgvDeductionAmount, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14})
            Me.DataGridViewDeductions.DataSource = Me.bsDeductions
            DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewDeductions.DefaultCellStyle = DataGridViewCellStyle16
            Me.DataGridViewDeductions.DgvFooter = Nothing
            Me.DataGridViewDeductions.DisplayOnly = False
            Me.DataGridViewDeductions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewDeductions.Ea = EventAggregator2
            Me.DataGridViewDeductions.EditingMode = False
            Me.DataGridViewDeductions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewDeductions.EndFindValue = Nothing
            Me.DataGridViewDeductions.FieldDescription = Nothing
            Me.DataGridViewDeductions.FieldName = Nothing
            Me.DataGridViewDeductions.FieldsDictionary = Nothing
            Me.DataGridViewDeductions.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewDeductions.FindEnabled = False
            Me.DataGridViewDeductions.FirstRowDeletionEnabled = True
            Me.DataGridViewDeductions.FirstRowInsertionEnabled = True
            Me.DataGridViewDeductions.IgnoreCase = False
            Me.DataGridViewDeductions.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewDeductions.Name = "DataGridViewDeductions"
            Me.DataGridViewDeductions.ReadOnly = True
            Me.DataGridViewDeductions.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewDeductions.SequenceColumn = "dgvSequenceDeduction"
            Me.DataGridViewDeductions.SequenceFieldName = "Sequence"
            Me.DataGridViewDeductions.ShowFooter = False
            Me.DataGridViewDeductions.ShowInsertColumnWhenEditing = True
            Me.DataGridViewDeductions.Size = New System.Drawing.Size(648, 324)
            Me.DataGridViewDeductions.TabIndex = 2
            '
            'dgvSequenceDeduction
            '
            Me.dgvSequenceDeduction.BegFindValue = Nothing
            Me.dgvSequenceDeduction.DataPropertyName = "Sequence"
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            Me.dgvSequenceDeduction.DefaultCellStyle = DataGridViewCellStyle11
            Me.dgvSequenceDeduction.EditingMode = False
            Me.dgvSequenceDeduction.EndFindValue = Nothing
            Me.dgvSequenceDeduction.FieldDescription = Nothing
            Me.dgvSequenceDeduction.FieldName = Nothing
            Me.dgvSequenceDeduction.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequenceDeduction.FindEnabled = False
            Me.dgvSequenceDeduction.HeaderText = "Seq"
            Me.dgvSequenceDeduction.IgnoreCase = False
            Me.dgvSequenceDeduction.MinimumWidth = 30
            Me.dgvSequenceDeduction.Name = "dgvSequenceDeduction"
            Me.dgvSequenceDeduction.ReadOnly = True
            Me.dgvSequenceDeduction.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequenceDeduction.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequenceDeduction.Width = 30
            '
            'dgvDeductionIdNo
            '
            Me.dgvDeductionIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvDeductionIdNo.DataPropertyName = "PayElementIdNo"
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            Me.dgvDeductionIdNo.DefaultCellStyle = DataGridViewCellStyle12
            Me.dgvDeductionIdNo.EditingMode = False
            Me.dgvDeductionIdNo.HeaderText = "Deduction Name - Code"
            Me.dgvDeductionIdNo.Name = "dgvDeductionIdNo"
            Me.dgvDeductionIdNo.ReadOnly = True
            Me.dgvDeductionIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDeductionIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvDeductionRate
            '
            Me.dgvDeductionRate.BegFindValue = Nothing
            Me.dgvDeductionRate.DataPropertyName = "Rate"
            DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle13.Format = "###,##0.00"
            Me.dgvDeductionRate.DefaultCellStyle = DataGridViewCellStyle13
            Me.dgvDeductionRate.EditingMode = False
            Me.dgvDeductionRate.EndFindValue = Nothing
            Me.dgvDeductionRate.FieldDescription = Nothing
            Me.dgvDeductionRate.FieldName = Nothing
            Me.dgvDeductionRate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDeductionRate.FindEnabled = False
            Me.dgvDeductionRate.HeaderText = "Rate / Amount"
            Me.dgvDeductionRate.Name = "dgvDeductionRate"
            Me.dgvDeductionRate.ReadOnly = True
            Me.dgvDeductionRate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDeductionRate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDeductionRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDeductionRate.Width = 70
            '
            'dgvDeductionUnit
            '
            Me.dgvDeductionUnit.DataPropertyName = "Unit"
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
            Me.dgvDeductionUnit.DefaultCellStyle = DataGridViewCellStyle14
            Me.dgvDeductionUnit.EditingMode = False
            Me.dgvDeductionUnit.HeaderText = "Unit"
            Me.dgvDeductionUnit.Name = "dgvDeductionUnit"
            Me.dgvDeductionUnit.ReadOnly = True
            Me.dgvDeductionUnit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDeductionUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvDeductionAmount
            '
            Me.dgvDeductionAmount.BegFindValue = Nothing
            Me.dgvDeductionAmount.DataPropertyName = "Amount"
            DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle15.Format = "###,##0.00"
            Me.dgvDeductionAmount.DefaultCellStyle = DataGridViewCellStyle15
            Me.dgvDeductionAmount.EditingMode = False
            Me.dgvDeductionAmount.EndFindValue = Nothing
            Me.dgvDeductionAmount.FieldDescription = Nothing
            Me.dgvDeductionAmount.FieldName = Nothing
            Me.dgvDeductionAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDeductionAmount.FindEnabled = False
            Me.dgvDeductionAmount.HeaderText = "Payroll Amount"
            Me.dgvDeductionAmount.MinimumWidth = 80
            Me.dgvDeductionAmount.Name = "dgvDeductionAmount"
            Me.dgvDeductionAmount.ReadOnly = True
            Me.dgvDeductionAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDeductionAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDeductionAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDeductionAmount.Width = 80
            '
            'DataGridViewTextBoxColumn13
            '
            Me.DataGridViewTextBoxColumn13.DataPropertyName = "EmployeeIdNo"
            Me.DataGridViewTextBoxColumn13.HeaderText = "EmployeeIdNo"
            Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
            Me.DataGridViewTextBoxColumn13.ReadOnly = True
            Me.DataGridViewTextBoxColumn13.Visible = False
            '
            'DataGridViewTextBoxColumn14
            '
            Me.DataGridViewTextBoxColumn14.DataPropertyName = "IdNo"
            Me.DataGridViewTextBoxColumn14.HeaderText = "IdNo"
            Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
            Me.DataGridViewTextBoxColumn14.ReadOnly = True
            Me.DataGridViewTextBoxColumn14.Visible = False
            '
            'tbpPhones
            '
            Me.tbpPhones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.tbpPhones.Controls.Add(Me.DataGridViewPhones)
            Me.tbpPhones.Location = New System.Drawing.Point(4, 22)
            Me.tbpPhones.Name = "tbpPhones"
            Me.tbpPhones.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpPhones.Size = New System.Drawing.Size(654, 330)
            Me.tbpPhones.TabIndex = 5
            Me.tbpPhones.Text = "Phones"
            Me.tbpPhones.UseVisualStyleBackColor = True
            '
            'DataGridViewPhones
            '
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPhones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle17
            Me.DataGridViewPhones.AutoGenerateColumns = False
            Me.DataGridViewPhones.BegFindValue = Nothing
            Me.DataGridViewPhones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPhones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvPhoneTypeIdNo, Me.dgvCountryTelIdNo, Me.dgvAreaCode, Me.PhoneNumber, Me.dgvFullPhone, Me.dgvFullPhoneAra, Me.dgvCountryTelCode, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
            Me.DataGridViewPhones.DataSource = Me.bsPhones
            DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle23.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPhones.DefaultCellStyle = DataGridViewCellStyle23
            Me.DataGridViewPhones.DgvFooter = Nothing
            Me.DataGridViewPhones.DisplayOnly = False
            Me.DataGridViewPhones.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewPhones.Ea = Nothing
            Me.DataGridViewPhones.EditingMode = False
            Me.DataGridViewPhones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPhones.EndFindValue = Nothing
            Me.DataGridViewPhones.FieldDescription = Nothing
            Me.DataGridViewPhones.FieldName = Nothing
            Me.DataGridViewPhones.FieldsDictionary = Nothing
            Me.DataGridViewPhones.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPhones.FindEnabled = False
            Me.DataGridViewPhones.FirstRowDeletionEnabled = True
            Me.DataGridViewPhones.FirstRowInsertionEnabled = True
            Me.DataGridViewPhones.IgnoreCase = False
            Me.DataGridViewPhones.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewPhones.Name = "DataGridViewPhones"
            Me.DataGridViewPhones.ReadOnly = True
            Me.DataGridViewPhones.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPhones.SequenceColumn = "dgvSequence"
            Me.DataGridViewPhones.SequenceFieldName = "Sequence"
            Me.DataGridViewPhones.ShowFooter = False
            Me.DataGridViewPhones.ShowInsertColumnWhenEditing = True
            Me.DataGridViewPhones.Size = New System.Drawing.Size(648, 324)
            Me.DataGridViewPhones.TabIndex = 273
            '
            'dgvSequence
            '
            Me.dgvSequence.BegFindValue = Nothing
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle18
            Me.dgvSequence.DisplayOnly = True
            Me.dgvSequence.EditingMode = False
            Me.dgvSequence.EndFindValue = Nothing
            Me.dgvSequence.FieldDescription = Nothing
            Me.dgvSequence.FieldName = Nothing
            Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequence.FindEnabled = False
            Me.dgvSequence.HeaderText = "Seq"
            Me.dgvSequence.IgnoreCase = False
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequence.Width = 40
            '
            'dgvPhoneTypeIdNo
            '
            Me.dgvPhoneTypeIdNo.DataPropertyName = "PhoneTypeIdNo"
            DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
            Me.dgvPhoneTypeIdNo.DefaultCellStyle = DataGridViewCellStyle19
            Me.dgvPhoneTypeIdNo.EditingMode = False
            Me.dgvPhoneTypeIdNo.HeaderText = "Phone Type Code - Name"
            Me.dgvPhoneTypeIdNo.Name = "dgvPhoneTypeIdNo"
            Me.dgvPhoneTypeIdNo.ReadOnly = True
            Me.dgvPhoneTypeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPhoneTypeIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvCountryTelIdNo
            '
            Me.dgvCountryTelIdNo.DataPropertyName = "CountryTelIdNo"
            DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
            Me.dgvCountryTelIdNo.DefaultCellStyle = DataGridViewCellStyle20
            Me.dgvCountryTelIdNo.EditingMode = False
            Me.dgvCountryTelIdNo.HeaderText = "Country Phone Code"
            Me.dgvCountryTelIdNo.MinimumWidth = 200
            Me.dgvCountryTelIdNo.Name = "dgvCountryTelIdNo"
            Me.dgvCountryTelIdNo.ReadOnly = True
            Me.dgvCountryTelIdNo.Width = 200
            '
            'dgvAreaCode
            '
            Me.dgvAreaCode.BegFindValue = Nothing
            Me.dgvAreaCode.DataPropertyName = "AreaCode"
            DataGridViewCellStyle21.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
            Me.dgvAreaCode.DefaultCellStyle = DataGridViewCellStyle21
            Me.dgvAreaCode.EditingMode = False
            Me.dgvAreaCode.EndFindValue = Nothing
            Me.dgvAreaCode.FieldDescription = Nothing
            Me.dgvAreaCode.FieldName = Nothing
            Me.dgvAreaCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvAreaCode.FindEnabled = False
            Me.dgvAreaCode.HeaderText = "Area Code"
            Me.dgvAreaCode.IgnoreCase = False
            Me.dgvAreaCode.Name = "dgvAreaCode"
            Me.dgvAreaCode.ReadOnly = True
            Me.dgvAreaCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAreaCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvAreaCode.Width = 60
            '
            'PhoneNumber
            '
            Me.PhoneNumber.BegFindValue = Nothing
            Me.PhoneNumber.DataPropertyName = "PhoneNumber"
            DataGridViewCellStyle22.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black
            Me.PhoneNumber.DefaultCellStyle = DataGridViewCellStyle22
            Me.PhoneNumber.EditingMode = False
            Me.PhoneNumber.EndFindValue = Nothing
            Me.PhoneNumber.FieldDescription = Nothing
            Me.PhoneNumber.FieldName = Nothing
            Me.PhoneNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.PhoneNumber.FindEnabled = False
            Me.PhoneNumber.HeaderText = "PhoneNumber"
            Me.PhoneNumber.IgnoreCase = False
            Me.PhoneNumber.Name = "PhoneNumber"
            Me.PhoneNumber.ReadOnly = True
            Me.PhoneNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            '
            'dgvFullPhone
            '
            Me.dgvFullPhone.DataPropertyName = "FullPhone"
            Me.dgvFullPhone.HeaderText = "FullPhone"
            Me.dgvFullPhone.Name = "dgvFullPhone"
            Me.dgvFullPhone.ReadOnly = True
            Me.dgvFullPhone.Visible = False
            Me.dgvFullPhone.Width = 200
            '
            'dgvFullPhoneAra
            '
            Me.dgvFullPhoneAra.DataPropertyName = "FullPhoneAra"
            Me.dgvFullPhoneAra.HeaderText = "FullPhoneAra"
            Me.dgvFullPhoneAra.Name = "dgvFullPhoneAra"
            Me.dgvFullPhoneAra.ReadOnly = True
            Me.dgvFullPhoneAra.Visible = False
            Me.dgvFullPhoneAra.Width = 200
            '
            'dgvCountryTelCode
            '
            Me.dgvCountryTelCode.DataPropertyName = "CountryTelCode"
            Me.dgvCountryTelCode.HeaderText = "CountryTelCode"
            Me.dgvCountryTelCode.Name = "dgvCountryTelCode"
            Me.dgvCountryTelCode.ReadOnly = True
            Me.dgvCountryTelCode.Visible = False
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.DataPropertyName = "EmployeeIdNo"
            Me.DataGridViewTextBoxColumn1.HeaderText = "EmployeeIdNo"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            Me.DataGridViewTextBoxColumn1.Visible = False
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.DataPropertyName = "IdNo"
            Me.DataGridViewTextBoxColumn2.HeaderText = "IdNo"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.ReadOnly = True
            Me.DataGridViewTextBoxColumn2.Visible = False
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
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.Location = New System.Drawing.Point(186, 1)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 151
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.ValueIsNumeric = True
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
            Me.lblEmployeeCode.Size = New System.Drawing.Size(305, 23)
            Me.lblEmployeeCode.TabIndex = 154
            Me.lblEmployeeCode.Text = "Employee Code"
            Me.lblEmployeeCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEmployeeCode
            '
            Me.txtEmployeeCode.BackColor = System.Drawing.Color.White
            Me.txtEmployeeCode.BegFindValue = Nothing
            Me.txtEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmployeeCode.ComputedValue = False
            Me.txtEmployeeCode.CustomFormat = Nothing
            Me.txtEmployeeCode.DataBoundControl = True
            Me.txtEmployeeCode.EditingMode = False
            Me.txtEmployeeCode.EndFindValue = Nothing
            Me.txtEmployeeCode.FieldDescription = Nothing
            Me.txtEmployeeCode.FieldName = Nothing
            Me.txtEmployeeCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtEmployeeCode.FindEnabled = True
            Me.CFlowLayout4.SetFlowBreak(Me.txtEmployeeCode, True)
            Me.txtEmployeeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmployeeCode.ForeColor = System.Drawing.Color.Black
            Me.txtEmployeeCode.LinkedLabel = Me.lblEmployeeCode
            Me.txtEmployeeCode.Location = New System.Drawing.Point(557, 1)
            Me.txtEmployeeCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeCode.MaximumValue = Nothing
            Me.txtEmployeeCode.MinimumValue = Nothing
            Me.txtEmployeeCode.Name = "txtEmployeeCode"
            Me.txtEmployeeCode.OldValue = Nothing
            Me.txtEmployeeCode.ReadOnly = True
            Me.txtEmployeeCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtEmployeeCode.Size = New System.Drawing.Size(105, 23)
            Me.txtEmployeeCode.TabIndex = 153
            Me.txtEmployeeCode.ValueIsMandatory = True
            Me.txtEmployeeCode.ValueIsUnique = True
            '
            'floMain
            '
            Me.floMain.BackColor = System.Drawing.Color.Transparent
            Me.floMain.Controls.Add(Me.CFlowLayout4)
            Me.floMain.Controls.Add(Me.tbcEmployee)
            Me.floMain.Dock = System.Windows.Forms.DockStyle.Left
            Me.floMain.Location = New System.Drawing.Point(300, 53)
            Me.floMain.Name = "floMain"
            Me.floMain.Size = New System.Drawing.Size(681, 461)
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
            Me.CFlowLayout4.Size = New System.Drawing.Size(677, 82)
            Me.CFlowLayout4.TabIndex = 6
            '
            'EmployeeEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(983, 514)
            Me.Controls.Add(Me.floMain)
            Me.Name = "EmployeeEntryTv"
            Me.Text = "Employee Maintenance Form"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floMain, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout6.ResumeLayout(False)
            Me.CFlowLayout6.PerformLayout
            CType(Me.bsEarnings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsDeductions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbcEmployee.ResumeLayout(False)
            Me.tbpPersonal.ResumeLayout(False)
            Me.floPersonal.ResumeLayout(False)
            Me.floPersonal.PerformLayout
            Me.tbpContact.ResumeLayout(False)
            Me.floContactInformation.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout
            CType(Me.DataGridViewPhoneDisplay, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPhones, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbpEmployment.ResumeLayout(False)
            Me.CFlowLayout5.ResumeLayout(False)
            Me.tbpPayroll.ResumeLayout(False)
            Me.tbpEarnings.ResumeLayout(False)
            CType(Me.DataGridViewEarnings, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbpDeductions.ResumeLayout(False)
            CType(Me.DataGridViewDeductions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbpPhones.ResumeLayout(False)
            CType(Me.DataGridViewPhones, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floMain.ResumeLayout(False)
            Me.CFlowLayout4.ResumeLayout(False)
            Me.CFlowLayout4.PerformLayout
            Me.ResumeLayout(False)
            Me.PerformLayout

        End Sub
        Friend WithEvents lblEmployeeName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmployeeName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblEmployeeNameAra As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmployeeNameAra As Libraries.CBaseControlsLibrary.CTextBoxArabic
        Friend WithEvents lblGender As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblBirthDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpBirthDate As CCustomDateTimePicker
        Friend WithEvents lblMaritalStatus As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacMaritalStatus As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblNationalityCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacNationalityCode As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblReligion As Libraries.CBaseControlsLibrary.CLabel
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
        Friend WithEvents tbcEmployee As Libraries.CBaseControlsLibrary.CTabControl
        Friend WithEvents tbpPersonal As Libraries.CBaseControlsLibrary.CTabPage
        Friend WithEvents tbpContact As Libraries.CBaseControlsLibrary.CTabPage
        Friend WithEvents tbpPayroll As Libraries.CBaseControlsLibrary.CTabPage
        Friend WithEvents floPersonal As Libraries.CBaseControlsLibrary.CFlowLayout
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
        Friend WithEvents lblPayCycleIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboPayCycleidNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblHiredDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpHiredDate As CCustomDateTimePicker
        Friend WithEvents lblReleasedDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpReleasedDate As CCustomDateTimePicker
        Friend WithEvents CFlowLayout6 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents bsEarnings As BindingSource
        Friend WithEvents bsDeductions As BindingSource
        Friend WithEvents FrequencyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents RateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents FrequencyDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents RateDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents tbpEarnings As TabPage
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
        Friend WithEvents dgvInternationalCode As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
        Friend WithEvents dgvPhoneNumber As Libraries.CBaseControlsLibrary.CDgvTextColumn
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
        Friend WithEvents dgvSequence As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvPhoneTypeIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
        Friend WithEvents dgvCountryTelIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
        Friend WithEvents dgvAreaCode As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents PhoneNumber As Libraries.CBaseControlsLibrary.CDgvTextColumn
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
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblPaymentMethod As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboPaymentMethod As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblPayGroupIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboPayGroupIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblDutyHours As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDutyHours As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents tbpDeductions As TabPage
        Friend WithEvents DataGridViewDeductions As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents DataGridViewEarnings As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceEarning As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvEarningIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
        Friend WithEvents dgvEarningRate As Libraries.CBaseControlsLibrary.CdgvDecimalColumn
        Friend WithEvents dgvEarningUnit As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
        Friend WithEvents dgvEarningAmount As Libraries.CBaseControlsLibrary.CdgvMoneyColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceDeduction As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvDeductionIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
        Friend WithEvents dgvDeductionRate As Libraries.CBaseControlsLibrary.CdgvMoneyColumn
        Friend WithEvents dgvDeductionUnit As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
        Friend WithEvents dgvDeductionAmount As Libraries.CBaseControlsLibrary.CdgvMoneyColumn
        Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    End Class

End Namespace