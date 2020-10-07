Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EmployeeEntryTestOld
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeEntryTestOld))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator2 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Me.bsEarnings = New System.Windows.Forms.BindingSource(Me.components)
            Me.bsDeductions = New System.Windows.Forms.BindingSource(Me.components)
            Me.bsPhones = New System.Windows.Forms.BindingSource(Me.components)
            Me.floEmployeeData = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.floEmployeeMainInfo = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEmployeeCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEmployeeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEmployeeName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEmployeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEmployeeNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEmployeeNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.EmployeeTabControl = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tbpPersonal = New AATM.Libraries.CBaseControlsLibrary.CTabPage()
            Me.floPersonalInfo = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblGender = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacGender = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblMaritalStatus = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacMaritalStatus = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblNationalityCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacNationalityCode = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacReligionIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblBirthDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpBirthDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblNationalIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNationalIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.tbpContact = New AATM.Libraries.CBaseControlsLibrary.CTabPage()
            Me.floContactInformation = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
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
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEmail = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblEmail = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.DataGridViewPhoneDisplay = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.FullPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.FullPhoneAra = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.lblStreet = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.tbpEmployment = New System.Windows.Forms.TabPage()
            Me.floEmploymentInfo = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
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
            Me.floMainDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblBankIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacBankIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblBankAccountNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtBankAccountNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblIbanNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtIban = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblOpeningBalance = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtOpeningBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtBalance = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPayFrequency = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayFrequency = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPaySalariedOrHourly = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPaySalariedOrHourly = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPayRateType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayRateAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPayRateAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayRateType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.tbpEarningDeductions = New System.Windows.Forms.TabPage()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblEarnings = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CFlowLayout7 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.DataGridViewEarnings = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequenceEarning = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.DataGridVewDeductions = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsEarnings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsDeductions, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPhones, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floEmployeeData.SuspendLayout()
            Me.floEmployeeMainInfo.SuspendLayout()
            Me.EmployeeTabControl.SuspendLayout()
            Me.tbpPersonal.SuspendLayout()
            Me.floPersonalInfo.SuspendLayout()
            Me.tbpContact.SuspendLayout()
            Me.floContactInformation.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewPhoneDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbpEmployment.SuspendLayout()
            Me.floEmploymentInfo.SuspendLayout()
            Me.tbpPayroll.SuspendLayout()
            Me.floMainDisplay.SuspendLayout()
            Me.tbpEarningDeductions.SuspendLayout()
            Me.CFlowLayout7.SuspendLayout()
            CType(Me.DataGridViewEarnings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridVewDeductions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.TreeViewTableName.Size = New System.Drawing.Size(300, 486)
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'floEmployeeData
            '
            Me.floEmployeeData.BackColor = System.Drawing.Color.Transparent
            Me.floEmployeeData.Controls.Add(Me.floEmployeeMainInfo)
            Me.floEmployeeData.Controls.Add(Me.EmployeeTabControl)
            Me.floEmployeeData.Dock = System.Windows.Forms.DockStyle.Left
            Me.floEmployeeData.Location = New System.Drawing.Point(300, 53)
            Me.floEmployeeData.Name = "floEmployeeData"
            Me.floEmployeeData.Size = New System.Drawing.Size(840, 486)
            Me.floEmployeeData.TabIndex = 8
            '
            'floEmployeeMainInfo
            '
            Me.floEmployeeMainInfo.BackColor = System.Drawing.Color.Transparent
            Me.floEmployeeMainInfo.Controls.Add(Me.lblIdNo)
            Me.floEmployeeMainInfo.Controls.Add(Me.TxtIdNo)
            Me.floEmployeeMainInfo.Controls.Add(Me.lblEmployeeCode)
            Me.floEmployeeMainInfo.Controls.Add(Me.txtEmployeeCode)
            Me.floEmployeeMainInfo.Controls.Add(Me.lblEmployeeName)
            Me.floEmployeeMainInfo.Controls.Add(Me.txtEmployeeName)
            Me.floEmployeeMainInfo.Controls.Add(Me.lblEmployeeNameAra)
            Me.floEmployeeMainInfo.Controls.Add(Me.txtEmployeeNameAra)
            Me.floEmployeeMainInfo.Location = New System.Drawing.Point(3, 3)
            Me.floEmployeeMainInfo.Name = "floEmployeeMainInfo"
            Me.floEmployeeMainInfo.Size = New System.Drawing.Size(829, 82)
            Me.floEmployeeMainInfo.TabIndex = 6
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
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
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
            Me.floEmployeeMainInfo.SetFlowBreak(Me.txtEmployeeCode, True)
            Me.txtEmployeeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmployeeCode.ForeColor = System.Drawing.Color.Black
            Me.txtEmployeeCode.LinkedLabel = Me.lblEmployeeCode
            Me.txtEmployeeCode.Location = New System.Drawing.Point(740, 1)
            Me.txtEmployeeCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeCode.MaximumValue = Nothing
            Me.txtEmployeeCode.MinimumValue = Nothing
            Me.txtEmployeeCode.Name = "txtEmployeeCode"
            Me.txtEmployeeCode.OldValue = Nothing
            Me.txtEmployeeCode.ReadOnly = True
            Me.txtEmployeeCode.Size = New System.Drawing.Size(66, 23)
            Me.txtEmployeeCode.TabIndex = 153
            Me.txtEmployeeCode.ValueIsMandatory = True
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
            Me.floEmployeeMainInfo.SetFlowBreak(Me.txtEmployeeName, True)
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
            Me.floEmployeeMainInfo.SetFlowBreak(Me.txtEmployeeNameAra, True)
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
            Me.txtEmployeeNameAra.Size = New System.Drawing.Size(620, 23)
            Me.txtEmployeeNameAra.TabIndex = 3
            Me.txtEmployeeNameAra.ValueIsMandatory = True
            '
            'EmployeeTabControl
            '
            Me.EmployeeTabControl.Controls.Add(Me.tbpPersonal)
            Me.EmployeeTabControl.Controls.Add(Me.tbpContact)
            Me.EmployeeTabControl.Controls.Add(Me.tbpEmployment)
            Me.EmployeeTabControl.Controls.Add(Me.tbpPayroll)
            Me.EmployeeTabControl.Controls.Add(Me.tbpEarningDeductions)
            Me.EmployeeTabControl.HotTrack = True
            Me.EmployeeTabControl.Location = New System.Drawing.Point(3, 91)
            Me.EmployeeTabControl.Name = "EmployeeTabControl"
            Me.EmployeeTabControl.SelectedIndex = 0
            Me.EmployeeTabControl.Size = New System.Drawing.Size(829, 387)
            Me.EmployeeTabControl.TabIndex = 5
            '
            'tbpPersonal
            '
            Me.tbpPersonal.BackgroundImage = CType(resources.GetObject("tbpPersonal.BackgroundImage"), System.Drawing.Image)
            Me.tbpPersonal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.tbpPersonal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.tbpPersonal.Controls.Add(Me.floPersonalInfo)
            Me.tbpPersonal.Location = New System.Drawing.Point(4, 22)
            Me.tbpPersonal.Name = "tbpPersonal"
            Me.tbpPersonal.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpPersonal.Size = New System.Drawing.Size(821, 361)
            Me.tbpPersonal.TabIndex = 0
            Me.tbpPersonal.Text = "Personal Information"
            Me.tbpPersonal.UseVisualStyleBackColor = True
            '
            'floPersonalInfo
            '
            Me.floPersonalInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floPersonalInfo.BackColor = System.Drawing.Color.Transparent
            Me.floPersonalInfo.Controls.Add(Me.lblGender)
            Me.floPersonalInfo.Controls.Add(Me.cacGender)
            Me.floPersonalInfo.Controls.Add(Me.lblMaritalStatus)
            Me.floPersonalInfo.Controls.Add(Me.cacMaritalStatus)
            Me.floPersonalInfo.Controls.Add(Me.lblNationalityCode)
            Me.floPersonalInfo.Controls.Add(Me.cacNationalityCode)
            Me.floPersonalInfo.Controls.Add(Me.CLabel5)
            Me.floPersonalInfo.Controls.Add(Me.cacReligionIdNo)
            Me.floPersonalInfo.Controls.Add(Me.lblBirthDate)
            Me.floPersonalInfo.Controls.Add(Me.dtpBirthDate)
            Me.floPersonalInfo.Controls.Add(Me.lblNationalIdNo)
            Me.floPersonalInfo.Controls.Add(Me.txtNationalIdNo)
            Me.floPersonalInfo.Controls.Add(Me.lblNotes)
            Me.floPersonalInfo.Controls.Add(Me.txtNotes)
            Me.floPersonalInfo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.floPersonalInfo.Location = New System.Drawing.Point(3, 3)
            Me.floPersonalInfo.Margin = New System.Windows.Forms.Padding(0)
            Me.floPersonalInfo.MinimumSize = New System.Drawing.Size(430, 180)
            Me.floPersonalInfo.Name = "floPersonalInfo"
            Me.floPersonalInfo.Size = New System.Drawing.Size(811, 351)
            Me.floPersonalInfo.TabIndex = 4
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
            'cacGender
            '
            Me.cacGender.BackColor = System.Drawing.Color.White
            Me.cacGender.ChangingSearchValueOnly = False
            Me.cacGender.CurrentSearchTerm = ""
            Me.cacGender.DefaultValue = Nothing
            Me.cacGender.DisplayMember = "Name"
            Me.cacGender.DropDownHeight = 1
            Me.cacGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacGender.EditingMode = False
            Me.cacGender.FilterRule = Nothing
            Me.floPersonalInfo.SetFlowBreak(Me.cacGender, True)
            Me.cacGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacGender.ForeColor = System.Drawing.Color.Black
            Me.cacGender.FormattingEnabled = True
            Me.cacGender.HideWhenNotEditingOrAdding = False
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
            Me.cacGender.PreviousSelectedIndex = -1
            Me.cacGender.PropertySelector = Nothing
            Me.cacGender.ReadOnlyCombo = False
            Me.cacGender.SearchAnywhere = False
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
            Me.cacMaritalStatus.DropDownHeight = 1
            Me.cacMaritalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacMaritalStatus.EditingMode = False
            Me.cacMaritalStatus.FilterRule = Nothing
            Me.floPersonalInfo.SetFlowBreak(Me.cacMaritalStatus, True)
            Me.cacMaritalStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacMaritalStatus.ForeColor = System.Drawing.Color.Black
            Me.cacMaritalStatus.FormattingEnabled = True
            Me.cacMaritalStatus.HideWhenNotEditingOrAdding = False
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
            Me.cacMaritalStatus.PreviousSelectedIndex = -1
            Me.cacMaritalStatus.PropertySelector = Nothing
            Me.cacMaritalStatus.ReadOnlyCombo = False
            Me.cacMaritalStatus.SearchAnywhere = False
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
            Me.cacNationalityCode.ChangingSearchValueOnly = False
            Me.cacNationalityCode.CurrentSearchTerm = ""
            Me.cacNationalityCode.DefaultValue = Nothing
            Me.cacNationalityCode.DisplayMember = "Name"
            Me.cacNationalityCode.DropDownHeight = 1
            Me.cacNationalityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacNationalityCode.EditingMode = False
            Me.cacNationalityCode.FilterRule = Nothing
            Me.floPersonalInfo.SetFlowBreak(Me.cacNationalityCode, True)
            Me.cacNationalityCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacNationalityCode.ForeColor = System.Drawing.Color.Black
            Me.cacNationalityCode.FormattingEnabled = True
            Me.cacNationalityCode.HideWhenNotEditingOrAdding = False
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
            Me.cacNationalityCode.PreviousSelectedIndex = -1
            Me.cacNationalityCode.PropertySelector = Nothing
            Me.cacNationalityCode.ReadOnlyCombo = False
            Me.cacNationalityCode.SearchAnywhere = False
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
            Me.cacReligionIdNo.DropDownHeight = 1
            Me.cacReligionIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacReligionIdNo.EditingMode = False
            Me.cacReligionIdNo.FilterRule = Nothing
            Me.floPersonalInfo.SetFlowBreak(Me.cacReligionIdNo, True)
            Me.cacReligionIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacReligionIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacReligionIdNo.FormattingEnabled = True
            Me.cacReligionIdNo.HideWhenNotEditingOrAdding = False
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
            Me.cacReligionIdNo.PreviousSelectedIndex = -1
            Me.cacReligionIdNo.PropertySelector = Nothing
            Me.cacReligionIdNo.ReadOnlyCombo = False
            Me.cacReligionIdNo.SearchAnywhere = False
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
            Me.floPersonalInfo.SetFlowBreak(Me.dtpBirthDate, True)
            Me.dtpBirthDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpBirthDate.ForeColor = System.Drawing.Color.Black
            Me.dtpBirthDate.LinkedLabel = Me.lblBirthDate
            Me.dtpBirthDate.Location = New System.Drawing.Point(176, 104)
            Me.dtpBirthDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpBirthDate.Name = "dtpBirthDate"
            Me.dtpBirthDate.ReadOnlyDp = False
            Me.dtpBirthDate.SecurityKey = Nothing
            Me.dtpBirthDate.ShowLongDate = False
            Me.dtpBirthDate.ShowTime = False
            Me.dtpBirthDate.Size = New System.Drawing.Size(123, 24)
            Me.dtpBirthDate.TabIndex = 5
            Me.dtpBirthDate.TabStop = False
            Me.dtpBirthDate.TargetCalendar = CType(resources.GetObject("dtpBirthDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpBirthDate.Value = Nothing
            Me.dtpBirthDate.ValueIsMandatory = False
            Me.dtpBirthDate.ValueIsNullable = False
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
            Me.txtNationalIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNationalIdNo.ComputedValue = False
            Me.txtNationalIdNo.CustomFormat = Nothing
            Me.txtNationalIdNo.DataBoundControl = True
            Me.txtNationalIdNo.EditingMode = False
            Me.floPersonalInfo.SetFlowBreak(Me.txtNationalIdNo, True)
            Me.txtNationalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNationalIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtNationalIdNo.LinkedLabel = Me.lblNationalIdNo
            Me.txtNationalIdNo.Location = New System.Drawing.Point(177, 130)
            Me.txtNationalIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNationalIdNo.MaximumValue = Nothing
            Me.txtNationalIdNo.MinimumValue = Nothing
            Me.txtNationalIdNo.Name = "txtNationalIdNo"
            Me.txtNationalIdNo.OldValue = Nothing
            Me.txtNationalIdNo.ReadOnly = True
            Me.txtNationalIdNo.Size = New System.Drawing.Size(200, 23)
            Me.txtNationalIdNo.TabIndex = 6
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
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.floPersonalInfo.SetFlowBreak(Me.txtNotes, True)
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
            Me.txtNotes.Size = New System.Drawing.Size(620, 60)
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
            Me.tbpContact.Size = New System.Drawing.Size(821, 361)
            Me.tbpContact.TabIndex = 1
            Me.tbpContact.Text = "Contact Information"
            Me.tbpContact.UseVisualStyleBackColor = True
            '
            'floContactInformation
            '
            Me.floContactInformation.BackColor = System.Drawing.Color.Transparent
            Me.floContactInformation.Controls.Add(Me.TableLayoutPanel1)
            Me.floContactInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.floContactInformation.Location = New System.Drawing.Point(3, 3)
            Me.floContactInformation.Name = "floContactInformation"
            Me.floContactInformation.Size = New System.Drawing.Size(811, 351)
            Me.floContactInformation.TabIndex = 7
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 5
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.95744!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.625!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.75!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.125!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.375!))
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
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 4, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtEmail, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblEmail, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewPhoneDisplay, 4, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblStreet, 0, 2)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 7
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 331)
            Me.TableLayoutPanel1.TabIndex = 274
            '
            'txtZipCode
            '
            Me.txtZipCode.BackColor = System.Drawing.Color.White
            Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtZipCode.ComputedValue = False
            Me.txtZipCode.CustomFormat = Nothing
            Me.txtZipCode.DataBoundControl = True
            Me.txtZipCode.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtZipCode.EditingMode = False
            Me.txtZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtZipCode.ForeColor = System.Drawing.Color.Black
            Me.txtZipCode.LinkedLabel = Nothing
            Me.txtZipCode.Location = New System.Drawing.Point(403, 127)
            Me.txtZipCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtZipCode.MaximumValue = Nothing
            Me.txtZipCode.MinimumValue = Nothing
            Me.txtZipCode.Name = "txtZipCode"
            Me.txtZipCode.OldValue = Nothing
            Me.txtZipCode.ReadOnly = True
            Me.txtZipCode.Size = New System.Drawing.Size(223, 23)
            Me.txtZipCode.TabIndex = 290
            '
            'lblZipCode
            '
            Me.lblZipCode.DisplayOnly = True
            Me.lblZipCode.EditingMode = False
            Me.lblZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblZipCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblZipCode.Location = New System.Drawing.Point(293, 127)
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
            Me.txtPoBox.ComputedValue = False
            Me.txtPoBox.CustomFormat = Nothing
            Me.txtPoBox.DataBoundControl = True
            Me.txtPoBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPoBox.EditingMode = False
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
            Me.txtPoBox.Size = New System.Drawing.Size(163, 23)
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
            Me.cacCountryCode.ChangingSearchValueOnly = False
            Me.cacCountryCode.CurrentSearchTerm = ""
            Me.cacCountryCode.DefaultValue = Nothing
            Me.cacCountryCode.DisplayMember = "Name"
            Me.cacCountryCode.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cacCountryCode.DropDownHeight = 1
            Me.cacCountryCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacCountryCode.EditingMode = False
            Me.cacCountryCode.FilterRule = Nothing
            Me.cacCountryCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacCountryCode.ForeColor = System.Drawing.Color.Black
            Me.cacCountryCode.FormattingEnabled = True
            Me.cacCountryCode.HideWhenNotEditingOrAdding = False
            Me.cacCountryCode.IntegralHeight = False
            Me.cacCountryCode.LinkedLabel = Nothing
            Me.cacCountryCode.Location = New System.Drawing.Point(402, 101)
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
            Me.cacCountryCode.Size = New System.Drawing.Size(225, 24)
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
            Me.lblCountryCode.Location = New System.Drawing.Point(293, 101)
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
            Me.txtProvinceState.ComputedValue = False
            Me.txtProvinceState.CustomFormat = Nothing
            Me.txtProvinceState.DataBoundControl = True
            Me.txtProvinceState.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtProvinceState.EditingMode = False
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
            Me.txtProvinceState.Size = New System.Drawing.Size(163, 23)
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
            Me.txtTownCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTownCity.ComputedValue = False
            Me.txtTownCity.CustomFormat = Nothing
            Me.txtTownCity.DataBoundControl = True
            Me.txtTownCity.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtTownCity.EditingMode = False
            Me.txtTownCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtTownCity.ForeColor = System.Drawing.Color.Black
            Me.txtTownCity.LinkedLabel = Nothing
            Me.txtTownCity.Location = New System.Drawing.Point(403, 76)
            Me.txtTownCity.Margin = New System.Windows.Forms.Padding(1)
            Me.txtTownCity.MaximumValue = Nothing
            Me.txtTownCity.MinimumValue = Nothing
            Me.txtTownCity.Name = "txtTownCity"
            Me.txtTownCity.OldValue = Nothing
            Me.txtTownCity.ReadOnly = True
            Me.txtTownCity.Size = New System.Drawing.Size(223, 23)
            Me.txtTownCity.TabIndex = 282
            '
            'lblTownCity
            '
            Me.lblTownCity.DisplayOnly = True
            Me.lblTownCity.EditingMode = False
            Me.lblTownCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTownCity.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTownCity.Location = New System.Drawing.Point(293, 76)
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
            Me.txtDistrict.ComputedValue = False
            Me.txtDistrict.CustomFormat = Nothing
            Me.txtDistrict.DataBoundControl = True
            Me.txtDistrict.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtDistrict.EditingMode = False
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
            Me.txtDistrict.Size = New System.Drawing.Size(163, 23)
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
            Me.txtStreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtStreet, 3)
            Me.txtStreet.ComputedValue = False
            Me.txtStreet.CustomFormat = Nothing
            Me.txtStreet.DataBoundControl = True
            Me.txtStreet.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtStreet.EditingMode = False
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
            Me.txtStreet.Size = New System.Drawing.Size(498, 23)
            Me.txtStreet.TabIndex = 278
            '
            'CLabel3
            '
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel3.Location = New System.Drawing.Point(628, 1)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(171, 23)
            Me.CLabel3.TabIndex = 275
            Me.CLabel3.Text = "Phone Numbers:"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtEmail
            '
            Me.txtEmail.BackColor = System.Drawing.Color.White
            Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtEmail, 3)
            Me.txtEmail.ComputedValue = False
            Me.txtEmail.CustomFormat = Nothing
            Me.txtEmail.DataBoundControl = True
            Me.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtEmail.EditingMode = False
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
            Me.txtEmail.Size = New System.Drawing.Size(498, 23)
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
            Me.CLabel1.Size = New System.Drawing.Size(625, 23)
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
            'DataGridViewPhoneDisplay
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPhoneDisplay.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPhoneDisplay.AutoGenerateColumns = False
            Me.DataGridViewPhoneDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPhoneDisplay.ColumnHeadersVisible = False
            Me.DataGridViewPhoneDisplay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FullPhone, Me.FullPhoneAra})
            Me.DataGridViewPhoneDisplay.DataInGridChanged = False
            Me.DataGridViewPhoneDisplay.DataSource = Me.bsPhones
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPhoneDisplay.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewPhoneDisplay.DisplayOnly = True
            Me.DataGridViewPhoneDisplay.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewPhoneDisplay.Ea = Nothing
            Me.DataGridViewPhoneDisplay.EditingMode = False
            Me.DataGridViewPhoneDisplay.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPhoneDisplay.FirstRowDeletionEnabled = True
            Me.DataGridViewPhoneDisplay.FirstRowInsertionEnabled = True
            Me.DataGridViewPhoneDisplay.Location = New System.Drawing.Point(630, 28)
            Me.DataGridViewPhoneDisplay.Name = "DataGridViewPhoneDisplay"
            Me.DataGridViewPhoneDisplay.ReadOnly = True
            Me.DataGridViewPhoneDisplay.RowHeadersVisible = False
            Me.TableLayoutPanel1.SetRowSpan(Me.DataGridViewPhoneDisplay, 6)
            Me.DataGridViewPhoneDisplay.ScrollBars = System.Windows.Forms.ScrollBars.None
            Me.DataGridViewPhoneDisplay.SequenceColumn = "dgvSequencePhoneDisplay"
            Me.DataGridViewPhoneDisplay.SequenceFieldName = "Sequence"
            Me.DataGridViewPhoneDisplay.ShowInsertColumnWhenEditing = True
            Me.DataGridViewPhoneDisplay.Size = New System.Drawing.Size(167, 300)
            Me.DataGridViewPhoneDisplay.StartTrackingChanges = False
            Me.DataGridViewPhoneDisplay.TabIndex = 273
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
            'tbpEmployment
            '
            Me.tbpEmployment.Controls.Add(Me.floEmploymentInfo)
            Me.tbpEmployment.Location = New System.Drawing.Point(4, 22)
            Me.tbpEmployment.Name = "tbpEmployment"
            Me.tbpEmployment.Size = New System.Drawing.Size(821, 361)
            Me.tbpEmployment.TabIndex = 3
            Me.tbpEmployment.Text = "Employment Information"
            Me.tbpEmployment.UseVisualStyleBackColor = True
            '
            'floEmploymentInfo
            '
            Me.floEmploymentInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floEmploymentInfo.BackColor = System.Drawing.Color.Transparent
            Me.floEmploymentInfo.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.floEmploymentInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floEmploymentInfo.Controls.Add(Me.lblHiredDate)
            Me.floEmploymentInfo.Controls.Add(Me.dtpHiredDate)
            Me.floEmploymentInfo.Controls.Add(Me.lblReleasedDate)
            Me.floEmploymentInfo.Controls.Add(Me.dtpReleasedDate)
            Me.floEmploymentInfo.Controls.Add(Me.lblDepartmentIdNo)
            Me.floEmploymentInfo.Controls.Add(Me.cacDepartmentIdNo)
            Me.floEmploymentInfo.Controls.Add(Me.lblDesignationIdNo)
            Me.floEmploymentInfo.Controls.Add(Me.cacDesignationIdNo)
            Me.floEmploymentInfo.Controls.Add(Me.lblActive)
            Me.floEmploymentInfo.Controls.Add(Me.chkActive)
            Me.floEmploymentInfo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.floEmploymentInfo.Location = New System.Drawing.Point(0, 0)
            Me.floEmploymentInfo.Name = "floEmploymentInfo"
            Me.floEmploymentInfo.Padding = New System.Windows.Forms.Padding(3)
            Me.floEmploymentInfo.Size = New System.Drawing.Size(821, 361)
            Me.floEmploymentInfo.TabIndex = 286
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
            Me.floEmploymentInfo.SetFlowBreak(Me.dtpHiredDate, True)
            Me.dtpHiredDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpHiredDate.ForeColor = System.Drawing.Color.Black
            Me.dtpHiredDate.LinkedLabel = Me.lblHiredDate
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
            Me.floEmploymentInfo.SetFlowBreak(Me.dtpReleasedDate, True)
            Me.dtpReleasedDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpReleasedDate.ForeColor = System.Drawing.Color.Black
            Me.dtpReleasedDate.LinkedLabel = Me.lblReleasedDate
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
            Me.cacDepartmentIdNo.ChangingSearchValueOnly = False
            Me.cacDepartmentIdNo.CurrentSearchTerm = ""
            Me.cacDepartmentIdNo.DefaultValue = Nothing
            Me.cacDepartmentIdNo.DisplayMember = "Name"
            Me.cacDepartmentIdNo.DropDownHeight = 1
            Me.cacDepartmentIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacDepartmentIdNo.EditingMode = False
            Me.cacDepartmentIdNo.FilterRule = Nothing
            Me.floEmploymentInfo.SetFlowBreak(Me.cacDepartmentIdNo, True)
            Me.cacDepartmentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacDepartmentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacDepartmentIdNo.FormattingEnabled = True
            Me.cacDepartmentIdNo.HideWhenNotEditingOrAdding = False
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
            Me.cacDepartmentIdNo.PreviousSelectedIndex = -1
            Me.cacDepartmentIdNo.PropertySelector = Nothing
            Me.cacDepartmentIdNo.ReadOnlyCombo = False
            Me.cacDepartmentIdNo.SearchAnywhere = False
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
            Me.cacDesignationIdNo.ChangingSearchValueOnly = False
            Me.cacDesignationIdNo.CurrentSearchTerm = ""
            Me.cacDesignationIdNo.DefaultValue = Nothing
            Me.cacDesignationIdNo.DisplayMember = "Name"
            Me.cacDesignationIdNo.DropDownHeight = 1
            Me.cacDesignationIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacDesignationIdNo.EditingMode = False
            Me.cacDesignationIdNo.FilterRule = Nothing
            Me.floEmploymentInfo.SetFlowBreak(Me.cacDesignationIdNo, True)
            Me.cacDesignationIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacDesignationIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacDesignationIdNo.FormattingEnabled = True
            Me.cacDesignationIdNo.HideWhenNotEditingOrAdding = False
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
            Me.cacDesignationIdNo.PreviousSelectedIndex = -1
            Me.cacDesignationIdNo.PropertySelector = Nothing
            Me.cacDesignationIdNo.ReadOnlyCombo = False
            Me.cacDesignationIdNo.SearchAnywhere = False
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
            Me.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkActive.DisplayOnly = False
            Me.chkActive.EditingMode = False
            Me.chkActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.floEmploymentInfo.SetFlowBreak(Me.chkActive, True)
            Me.chkActive.ForeColor = System.Drawing.Color.Black
            Me.chkActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkActive.LinkedLabel = Me.lblActive
            Me.chkActive.Location = New System.Drawing.Point(181, 108)
            Me.chkActive.Margin = New System.Windows.Forms.Padding(1)
            Me.chkActive.Name = "chkActive"
            Me.chkActive.NoLabel = False
            Me.chkActive.OldValue = ""
            Me.chkActive.Size = New System.Drawing.Size(25, 21)
            Me.chkActive.TabIndex = 5
            Me.chkActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkActive.UseVisualStyleBackColor = False
            '
            'tbpPayroll
            '
            Me.tbpPayroll.BackgroundImage = CType(resources.GetObject("tbpPayroll.BackgroundImage"), System.Drawing.Image)
            Me.tbpPayroll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.tbpPayroll.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.tbpPayroll.Controls.Add(Me.floMainDisplay)
            Me.tbpPayroll.Location = New System.Drawing.Point(4, 22)
            Me.tbpPayroll.Name = "tbpPayroll"
            Me.tbpPayroll.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpPayroll.Size = New System.Drawing.Size(821, 361)
            Me.tbpPayroll.TabIndex = 2
            Me.tbpPayroll.Text = "Payroll Information"
            Me.tbpPayroll.UseVisualStyleBackColor = True
            '
            'floMainDisplay
            '
            Me.floMainDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floMainDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floMainDisplay.Controls.Add(Me.lblBankIdNo)
            Me.floMainDisplay.Controls.Add(Me.cacBankIdNo)
            Me.floMainDisplay.Controls.Add(Me.lblBankAccountNo)
            Me.floMainDisplay.Controls.Add(Me.txtBankAccountNo)
            Me.floMainDisplay.Controls.Add(Me.lblIbanNumber)
            Me.floMainDisplay.Controls.Add(Me.txtIban)
            Me.floMainDisplay.Controls.Add(Me.lblOpeningBalance)
            Me.floMainDisplay.Controls.Add(Me.txtOpeningBalance)
            Me.floMainDisplay.Controls.Add(Me.lblBalance)
            Me.floMainDisplay.Controls.Add(Me.txtBalance)
            Me.floMainDisplay.Controls.Add(Me.lblPayFrequency)
            Me.floMainDisplay.Controls.Add(Me.cboPayFrequency)
            Me.floMainDisplay.Controls.Add(Me.lblPaySalariedOrHourly)
            Me.floMainDisplay.Controls.Add(Me.cboPaySalariedOrHourly)
            Me.floMainDisplay.Controls.Add(Me.lblPayRateType)
            Me.floMainDisplay.Controls.Add(Me.txtPayRateAmount)
            Me.floMainDisplay.Controls.Add(Me.lblPayRateAmount)
            Me.floMainDisplay.Controls.Add(Me.cboPayRateType)
            Me.floMainDisplay.Location = New System.Drawing.Point(3, 3)
            Me.floMainDisplay.Margin = New System.Windows.Forms.Padding(0)
            Me.floMainDisplay.MinimumSize = New System.Drawing.Size(430, 180)
            Me.floMainDisplay.Name = "floMainDisplay"
            Me.floMainDisplay.Size = New System.Drawing.Size(811, 351)
            Me.floMainDisplay.TabIndex = 3
            '
            'lblBankIdNo
            '
            Me.lblBankIdNo.DisplayOnly = True
            Me.lblBankIdNo.EditingMode = False
            Me.lblBankIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBankIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblBankIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblBankIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBankIdNo.Name = "lblBankIdNo"
            Me.lblBankIdNo.Size = New System.Drawing.Size(185, 23)
            Me.lblBankIdNo.TabIndex = 302
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
            Me.cacBankIdNo.DropDownHeight = 1
            Me.cacBankIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cacBankIdNo.EditingMode = False
            Me.cacBankIdNo.FilterRule = Nothing
            Me.floMainDisplay.SetFlowBreak(Me.cacBankIdNo, True)
            Me.cacBankIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacBankIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacBankIdNo.FormattingEnabled = True
            Me.cacBankIdNo.HideWhenNotEditingOrAdding = False
            Me.cacBankIdNo.IntegralHeight = False
            Me.cacBankIdNo.LinkedLabel = Me.lblBankIdNo
            Me.cacBankIdNo.Location = New System.Drawing.Point(187, 1)
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
            Me.cacBankIdNo.Size = New System.Drawing.Size(201, 24)
            Me.cacBankIdNo.SuggestBoxHeight = 200
            Me.cacBankIdNo.SuggestListOrderRule = Nothing
            Me.cacBankIdNo.TabIndex = 293
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
            Me.lblBankAccountNo.Location = New System.Drawing.Point(1, 27)
            Me.lblBankAccountNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBankAccountNo.Name = "lblBankAccountNo"
            Me.lblBankAccountNo.Size = New System.Drawing.Size(185, 23)
            Me.lblBankAccountNo.TabIndex = 303
            Me.lblBankAccountNo.Text = "Account No."
            Me.lblBankAccountNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtBankAccountNo
            '
            Me.txtBankAccountNo.BackColor = System.Drawing.Color.White
            Me.txtBankAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBankAccountNo.ComputedValue = False
            Me.txtBankAccountNo.CustomFormat = Nothing
            Me.txtBankAccountNo.DataBoundControl = True
            Me.txtBankAccountNo.DisplayOnly = True
            Me.txtBankAccountNo.EditingMode = False
            Me.floMainDisplay.SetFlowBreak(Me.txtBankAccountNo, True)
            Me.txtBankAccountNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtBankAccountNo.ForeColor = System.Drawing.Color.Black
            Me.txtBankAccountNo.LinkedLabel = Me.lblBalance
            Me.txtBankAccountNo.Location = New System.Drawing.Point(188, 27)
            Me.txtBankAccountNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtBankAccountNo.MaximumValue = Nothing
            Me.txtBankAccountNo.MinimumValue = Nothing
            Me.txtBankAccountNo.Name = "txtBankAccountNo"
            Me.txtBankAccountNo.OldValue = Nothing
            Me.txtBankAccountNo.ReadOnly = True
            Me.txtBankAccountNo.Size = New System.Drawing.Size(200, 23)
            Me.txtBankAccountNo.TabIndex = 314
            Me.txtBankAccountNo.ValueIsNumeric = True
            '
            'lblBalance
            '
            Me.lblBalance.DisplayOnly = True
            Me.lblBalance.EditingMode = False
            Me.lblBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBalance.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblBalance.Location = New System.Drawing.Point(1, 102)
            Me.lblBalance.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBalance.Name = "lblBalance"
            Me.lblBalance.Size = New System.Drawing.Size(185, 23)
            Me.lblBalance.TabIndex = 306
            Me.lblBalance.Text = "Cash Advance Balance"
            Me.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIbanNumber
            '
            Me.lblIbanNumber.DisplayOnly = True
            Me.lblIbanNumber.EditingMode = False
            Me.lblIbanNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIbanNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIbanNumber.Location = New System.Drawing.Point(1, 52)
            Me.lblIbanNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIbanNumber.Name = "lblIbanNumber"
            Me.lblIbanNumber.Size = New System.Drawing.Size(185, 23)
            Me.lblIbanNumber.TabIndex = 313
            Me.lblIbanNumber.Text = "IBAN Number"
            Me.lblIbanNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtIban
            '
            Me.txtIban.BackColor = System.Drawing.Color.White
            Me.txtIban.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIban.ComputedValue = False
            Me.txtIban.CustomFormat = Nothing
            Me.txtIban.DataBoundControl = True
            Me.txtIban.DisplayOnly = True
            Me.txtIban.EditingMode = False
            Me.floMainDisplay.SetFlowBreak(Me.txtIban, True)
            Me.txtIban.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtIban.ForeColor = System.Drawing.Color.Black
            Me.txtIban.LinkedLabel = Me.lblBalance
            Me.txtIban.Location = New System.Drawing.Point(188, 52)
            Me.txtIban.Margin = New System.Windows.Forms.Padding(1)
            Me.txtIban.MaximumValue = Nothing
            Me.txtIban.MinimumValue = Nothing
            Me.txtIban.Name = "txtIban"
            Me.txtIban.OldValue = Nothing
            Me.txtIban.ReadOnly = True
            Me.txtIban.Size = New System.Drawing.Size(200, 23)
            Me.txtIban.TabIndex = 312
            Me.txtIban.ValueIsNumeric = True
            '
            'lblOpeningBalance
            '
            Me.lblOpeningBalance.DisplayOnly = True
            Me.lblOpeningBalance.EditingMode = False
            Me.lblOpeningBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblOpeningBalance.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblOpeningBalance.Location = New System.Drawing.Point(1, 77)
            Me.lblOpeningBalance.Margin = New System.Windows.Forms.Padding(1)
            Me.lblOpeningBalance.Name = "lblOpeningBalance"
            Me.lblOpeningBalance.Size = New System.Drawing.Size(185, 23)
            Me.lblOpeningBalance.TabIndex = 305
            Me.lblOpeningBalance.Text = "Open. Bal. (Cash Adv.)"
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
            Me.floMainDisplay.SetFlowBreak(Me.txtOpeningBalance, True)
            Me.txtOpeningBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtOpeningBalance.ForeColor = System.Drawing.Color.Black
            Me.txtOpeningBalance.LinkedLabel = Me.lblOpeningBalance
            Me.txtOpeningBalance.Location = New System.Drawing.Point(188, 77)
            Me.txtOpeningBalance.Margin = New System.Windows.Forms.Padding(1)
            Me.txtOpeningBalance.MaximumValue = Nothing
            Me.txtOpeningBalance.MinimumValue = Nothing
            Me.txtOpeningBalance.Name = "txtOpeningBalance"
            Me.txtOpeningBalance.OldValue = Nothing
            Me.txtOpeningBalance.ReadOnly = True
            Me.txtOpeningBalance.Size = New System.Drawing.Size(200, 23)
            Me.txtOpeningBalance.TabIndex = 296
            Me.txtOpeningBalance.ValueIsNumeric = True
            '
            'txtBalance
            '
            Me.txtBalance.BackColor = System.Drawing.Color.White
            Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBalance.ComputedValue = False
            Me.txtBalance.CustomFormat = Nothing
            Me.txtBalance.DataBoundControl = True
            Me.txtBalance.DisplayOnly = True
            Me.txtBalance.EditingMode = False
            Me.floMainDisplay.SetFlowBreak(Me.txtBalance, True)
            Me.txtBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtBalance.ForeColor = System.Drawing.Color.Black
            Me.txtBalance.LinkedLabel = Me.lblBalance
            Me.txtBalance.Location = New System.Drawing.Point(188, 102)
            Me.txtBalance.Margin = New System.Windows.Forms.Padding(1)
            Me.txtBalance.MaximumValue = Nothing
            Me.txtBalance.MinimumValue = Nothing
            Me.txtBalance.Name = "txtBalance"
            Me.txtBalance.OldValue = Nothing
            Me.txtBalance.ReadOnly = True
            Me.txtBalance.Size = New System.Drawing.Size(200, 23)
            Me.txtBalance.TabIndex = 297
            Me.txtBalance.ValueIsNumeric = True
            '
            'lblPayFrequency
            '
            Me.lblPayFrequency.DisplayOnly = True
            Me.lblPayFrequency.EditingMode = False
            Me.lblPayFrequency.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayFrequency.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPayFrequency.Location = New System.Drawing.Point(1, 127)
            Me.lblPayFrequency.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayFrequency.Name = "lblPayFrequency"
            Me.lblPayFrequency.Size = New System.Drawing.Size(185, 23)
            Me.lblPayFrequency.TabIndex = 307
            Me.lblPayFrequency.Text = "Pay Frequency"
            Me.lblPayFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboPayFrequency
            '
            Me.cboPayFrequency.BackColor = System.Drawing.Color.White
            Me.cboPayFrequency.ChangingSearchValueOnly = False
            Me.cboPayFrequency.CurrentSearchTerm = ""
            Me.cboPayFrequency.DefaultValue = Nothing
            Me.cboPayFrequency.DisplayMember = "Name"
            Me.cboPayFrequency.DropDownHeight = 1
            Me.cboPayFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboPayFrequency.EditingMode = False
            Me.cboPayFrequency.FilterRule = Nothing
            Me.floMainDisplay.SetFlowBreak(Me.cboPayFrequency, True)
            Me.cboPayFrequency.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayFrequency.ForeColor = System.Drawing.Color.Black
            Me.cboPayFrequency.FormattingEnabled = True
            Me.cboPayFrequency.HideWhenNotEditingOrAdding = False
            Me.cboPayFrequency.IntegralHeight = False
            Me.cboPayFrequency.LinkedLabel = Me.lblPayFrequency
            Me.cboPayFrequency.Location = New System.Drawing.Point(187, 127)
            Me.cboPayFrequency.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cboPayFrequency.Name = "cboPayFrequency"
            Me.cboPayFrequency.OldValue = 0
            Me.cboPayFrequency.OriginalDataSource = Nothing
            Me.cboPayFrequency.OriginalList = Nothing
            Me.cboPayFrequency.OverrideDropDownStyleList = False
            Me.cboPayFrequency.PreviousSearchTerm = Nothing
            Me.cboPayFrequency.PreviousSelectedIndex = -1
            Me.cboPayFrequency.PropertySelector = Nothing
            Me.cboPayFrequency.ReadOnlyCombo = False
            Me.cboPayFrequency.SearchAnywhere = False
            Me.cboPayFrequency.Size = New System.Drawing.Size(201, 24)
            Me.cboPayFrequency.SuggestBoxHeight = 200
            Me.cboPayFrequency.SuggestListOrderRule = Nothing
            Me.cboPayFrequency.TabIndex = 298
            Me.cboPayFrequency.TextToSearch = Nothing
            Me.cboPayFrequency.ValueIsMandatory = False
            Me.cboPayFrequency.ValueIsNullable = False
            Me.cboPayFrequency.ValueIsNumeric = False
            Me.cboPayFrequency.ValueMember = "Code"
            '
            'lblPaySalariedOrHourly
            '
            Me.lblPaySalariedOrHourly.DisplayOnly = True
            Me.lblPaySalariedOrHourly.EditingMode = False
            Me.lblPaySalariedOrHourly.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPaySalariedOrHourly.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPaySalariedOrHourly.Location = New System.Drawing.Point(1, 153)
            Me.lblPaySalariedOrHourly.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPaySalariedOrHourly.Name = "lblPaySalariedOrHourly"
            Me.lblPaySalariedOrHourly.Size = New System.Drawing.Size(185, 23)
            Me.lblPaySalariedOrHourly.TabIndex = 308
            Me.lblPaySalariedOrHourly.Text = "Salaried or Hourly"
            Me.lblPaySalariedOrHourly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboPaySalariedOrHourly
            '
            Me.cboPaySalariedOrHourly.BackColor = System.Drawing.Color.White
            Me.cboPaySalariedOrHourly.ChangingSearchValueOnly = False
            Me.cboPaySalariedOrHourly.CurrentSearchTerm = ""
            Me.cboPaySalariedOrHourly.DefaultValue = Nothing
            Me.cboPaySalariedOrHourly.DisplayMember = "Name"
            Me.cboPaySalariedOrHourly.DropDownHeight = 1
            Me.cboPaySalariedOrHourly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboPaySalariedOrHourly.EditingMode = False
            Me.cboPaySalariedOrHourly.FilterRule = Nothing
            Me.floMainDisplay.SetFlowBreak(Me.cboPaySalariedOrHourly, True)
            Me.cboPaySalariedOrHourly.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPaySalariedOrHourly.ForeColor = System.Drawing.Color.Black
            Me.cboPaySalariedOrHourly.FormattingEnabled = True
            Me.cboPaySalariedOrHourly.HideWhenNotEditingOrAdding = False
            Me.cboPaySalariedOrHourly.IntegralHeight = False
            Me.cboPaySalariedOrHourly.LinkedLabel = Me.lblPaySalariedOrHourly
            Me.cboPaySalariedOrHourly.Location = New System.Drawing.Point(187, 153)
            Me.cboPaySalariedOrHourly.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cboPaySalariedOrHourly.Name = "cboPaySalariedOrHourly"
            Me.cboPaySalariedOrHourly.OldValue = 0
            Me.cboPaySalariedOrHourly.OriginalDataSource = Nothing
            Me.cboPaySalariedOrHourly.OriginalList = Nothing
            Me.cboPaySalariedOrHourly.OverrideDropDownStyleList = False
            Me.cboPaySalariedOrHourly.PreviousSearchTerm = Nothing
            Me.cboPaySalariedOrHourly.PreviousSelectedIndex = -1
            Me.cboPaySalariedOrHourly.PropertySelector = Nothing
            Me.cboPaySalariedOrHourly.ReadOnlyCombo = False
            Me.cboPaySalariedOrHourly.SearchAnywhere = False
            Me.cboPaySalariedOrHourly.Size = New System.Drawing.Size(201, 24)
            Me.cboPaySalariedOrHourly.SuggestBoxHeight = 200
            Me.cboPaySalariedOrHourly.SuggestListOrderRule = Nothing
            Me.cboPaySalariedOrHourly.TabIndex = 299
            Me.cboPaySalariedOrHourly.TextToSearch = Nothing
            Me.cboPaySalariedOrHourly.ValueIsMandatory = True
            Me.cboPaySalariedOrHourly.ValueIsNullable = False
            Me.cboPaySalariedOrHourly.ValueIsNumeric = False
            Me.cboPaySalariedOrHourly.ValueMember = "Code"
            '
            'lblPayRateType
            '
            Me.lblPayRateType.DisplayOnly = True
            Me.lblPayRateType.EditingMode = False
            Me.lblPayRateType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayRateType.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPayRateType.Location = New System.Drawing.Point(1, 179)
            Me.lblPayRateType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayRateType.Name = "lblPayRateType"
            Me.lblPayRateType.Size = New System.Drawing.Size(185, 23)
            Me.lblPayRateType.TabIndex = 309
            Me.lblPayRateType.Text = "Pay Rate Type"
            Me.lblPayRateType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPayRateAmount
            '
            Me.txtPayRateAmount.BackColor = System.Drawing.Color.White
            Me.txtPayRateAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayRateAmount.ComputedValue = False
            Me.txtPayRateAmount.CustomFormat = Nothing
            Me.txtPayRateAmount.DataBoundControl = True
            Me.txtPayRateAmount.EditingMode = False
            Me.floMainDisplay.SetFlowBreak(Me.txtPayRateAmount, True)
            Me.txtPayRateAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayRateAmount.ForeColor = System.Drawing.Color.Black
            Me.txtPayRateAmount.LinkedLabel = Me.lblPayRateAmount
            Me.txtPayRateAmount.Location = New System.Drawing.Point(188, 179)
            Me.txtPayRateAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayRateAmount.MaximumValue = Nothing
            Me.txtPayRateAmount.MinimumValue = Nothing
            Me.txtPayRateAmount.Name = "txtPayRateAmount"
            Me.txtPayRateAmount.OldValue = Nothing
            Me.txtPayRateAmount.ReadOnly = True
            Me.txtPayRateAmount.Size = New System.Drawing.Size(200, 23)
            Me.txtPayRateAmount.TabIndex = 301
            Me.txtPayRateAmount.TabStop = False
            Me.txtPayRateAmount.ValueIsNumeric = True
            '
            'lblPayRateAmount
            '
            Me.lblPayRateAmount.DisplayOnly = True
            Me.lblPayRateAmount.EditingMode = False
            Me.lblPayRateAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayRateAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPayRateAmount.Location = New System.Drawing.Point(1, 204)
            Me.lblPayRateAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayRateAmount.Name = "lblPayRateAmount"
            Me.lblPayRateAmount.Size = New System.Drawing.Size(185, 23)
            Me.lblPayRateAmount.TabIndex = 310
            Me.lblPayRateAmount.Text = "Pay Rate Amount"
            Me.lblPayRateAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboPayRateType
            '
            Me.cboPayRateType.BackColor = System.Drawing.Color.White
            Me.cboPayRateType.ChangingSearchValueOnly = False
            Me.cboPayRateType.CurrentSearchTerm = ""
            Me.cboPayRateType.DefaultValue = Nothing
            Me.cboPayRateType.DisplayMember = "Name"
            Me.cboPayRateType.DropDownHeight = 1
            Me.cboPayRateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboPayRateType.EditingMode = False
            Me.cboPayRateType.FilterRule = Nothing
            Me.cboPayRateType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayRateType.ForeColor = System.Drawing.Color.Black
            Me.cboPayRateType.FormattingEnabled = True
            Me.cboPayRateType.HideWhenNotEditingOrAdding = False
            Me.cboPayRateType.IntegralHeight = False
            Me.cboPayRateType.LinkedLabel = Me.lblPayRateType
            Me.cboPayRateType.Location = New System.Drawing.Point(187, 204)
            Me.cboPayRateType.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
            Me.cboPayRateType.Name = "cboPayRateType"
            Me.cboPayRateType.OldValue = 0
            Me.cboPayRateType.OriginalDataSource = Nothing
            Me.cboPayRateType.OriginalList = Nothing
            Me.cboPayRateType.OverrideDropDownStyleList = False
            Me.cboPayRateType.PreviousSearchTerm = Nothing
            Me.cboPayRateType.PreviousSelectedIndex = -1
            Me.cboPayRateType.PropertySelector = Nothing
            Me.cboPayRateType.ReadOnlyCombo = False
            Me.cboPayRateType.SearchAnywhere = False
            Me.cboPayRateType.Size = New System.Drawing.Size(201, 24)
            Me.cboPayRateType.SuggestBoxHeight = 200
            Me.cboPayRateType.SuggestListOrderRule = Nothing
            Me.cboPayRateType.TabIndex = 300
            Me.cboPayRateType.TextToSearch = Nothing
            Me.cboPayRateType.ValueIsMandatory = False
            Me.cboPayRateType.ValueIsNullable = False
            Me.cboPayRateType.ValueIsNumeric = False
            Me.cboPayRateType.ValueMember = "Code"
            '
            'tbpEarningDeductions
            '
            Me.tbpEarningDeductions.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.tbpEarningDeductions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.tbpEarningDeductions.Controls.Add(Me.CLabel2)
            Me.tbpEarningDeductions.Controls.Add(Me.lblEarnings)
            Me.tbpEarningDeductions.Controls.Add(Me.CFlowLayout7)
            Me.tbpEarningDeductions.Location = New System.Drawing.Point(4, 22)
            Me.tbpEarningDeductions.Name = "tbpEarningDeductions"
            Me.tbpEarningDeductions.Size = New System.Drawing.Size(821, 361)
            Me.tbpEarningDeductions.TabIndex = 4
            Me.tbpEarningDeductions.Text = "Earnings & Deductions"
            Me.tbpEarningDeductions.UseVisualStyleBackColor = True
            '
            'CLabel2
            '
            Me.CLabel2.AutoSize = True
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(412, 0)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(141, 17)
            Me.CLabel2.TabIndex = 3
            Me.CLabel2.Text = "Regular Deductions: "
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblEarnings
            '
            Me.lblEarnings.AutoSize = True
            Me.lblEarnings.DisplayOnly = True
            Me.lblEarnings.EditingMode = False
            Me.lblEarnings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEarnings.Location = New System.Drawing.Point(3, 1)
            Me.lblEarnings.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEarnings.Name = "lblEarnings"
            Me.lblEarnings.Size = New System.Drawing.Size(122, 17)
            Me.lblEarnings.TabIndex = 2
            Me.lblEarnings.Text = "Regular Earnings:"
            Me.lblEarnings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'CFlowLayout7
            '
            Me.CFlowLayout7.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout7.Controls.Add(Me.DataGridViewEarnings)
            Me.CFlowLayout7.Controls.Add(Me.DataGridVewDeductions)
            Me.CFlowLayout7.Location = New System.Drawing.Point(3, 21)
            Me.CFlowLayout7.Name = "CFlowLayout7"
            Me.CFlowLayout7.Size = New System.Drawing.Size(815, 337)
            Me.CFlowLayout7.TabIndex = 1
            '
            'DataGridViewEarnings
            '
            Me.DataGridViewEarnings.AllowUserToOrderColumns = True
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewEarnings.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
            Me.DataGridViewEarnings.AutoGenerateColumns = False
            Me.DataGridViewEarnings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewEarnings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceEarning})
            Me.DataGridViewEarnings.DataInGridChanged = False
            Me.DataGridViewEarnings.DataSource = Me.bsEarnings
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewEarnings.DefaultCellStyle = DataGridViewCellStyle5
            Me.DataGridViewEarnings.DisplayOnly = False
            Me.DataGridViewEarnings.Ea = EventAggregator1
            Me.DataGridViewEarnings.EditingMode = False
            Me.DataGridViewEarnings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewEarnings.FirstRowDeletionEnabled = True
            Me.DataGridViewEarnings.FirstRowInsertionEnabled = True
            Me.DataGridViewEarnings.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewEarnings.Name = "DataGridViewEarnings"
            Me.DataGridViewEarnings.ReadOnly = True
            Me.DataGridViewEarnings.SequenceColumn = "dgvSequenceEarning"
            Me.DataGridViewEarnings.SequenceFieldName = "Sequence"
            Me.DataGridViewEarnings.ShowInsertColumnWhenEditing = True
            Me.DataGridViewEarnings.Size = New System.Drawing.Size(403, 333)
            Me.DataGridViewEarnings.StartTrackingChanges = False
            Me.DataGridViewEarnings.TabIndex = 0
            '
            'dgvSequenceEarning
            '
            Me.dgvSequenceEarning.DataPropertyName = "Sequence"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvSequenceEarning.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvSequenceEarning.EditingMode = False
            Me.dgvSequenceEarning.HeaderText = "Seq"
            Me.dgvSequenceEarning.MinimumWidth = 40
            Me.dgvSequenceEarning.Name = "dgvSequenceEarning"
            Me.dgvSequenceEarning.ReadOnly = True
            Me.dgvSequenceEarning.Width = 40
            '
            'DataGridVewDeductions
            '
            Me.DataGridVewDeductions.AllowUserToOrderColumns = True
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridVewDeductions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
            Me.DataGridVewDeductions.AutoGenerateColumns = False
            Me.DataGridVewDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridVewDeductions.DataInGridChanged = False
            Me.DataGridVewDeductions.DataSource = Me.bsDeductions
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridVewDeductions.DefaultCellStyle = DataGridViewCellStyle7
            Me.DataGridVewDeductions.DisplayOnly = False
            Me.DataGridVewDeductions.Ea = EventAggregator2
            Me.DataGridVewDeductions.EditingMode = False
            Me.DataGridVewDeductions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridVewDeductions.FirstRowDeletionEnabled = True
            Me.DataGridVewDeductions.FirstRowInsertionEnabled = True
            Me.DataGridVewDeductions.Location = New System.Drawing.Point(412, 3)
            Me.DataGridVewDeductions.Name = "DataGridVewDeductions"
            Me.DataGridVewDeductions.ReadOnly = True
            Me.DataGridVewDeductions.SequenceColumn = "dgvSequenceDeduction"
            Me.DataGridVewDeductions.SequenceFieldName = "Sequence"
            Me.DataGridVewDeductions.ShowInsertColumnWhenEditing = True
            Me.DataGridVewDeductions.Size = New System.Drawing.Size(387, 333)
            Me.DataGridVewDeductions.StartTrackingChanges = False
            Me.DataGridVewDeductions.TabIndex = 1
            '
            'EmployeeEntryTestOld
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1149, 539)
            Me.Controls.Add(Me.floEmployeeData)
            Me.MinimumSize = New System.Drawing.Size(1165, 480)
            Me.Name = "EmployeeEntryTestOld"
            Me.Text = "Employee Maintenance Form"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floEmployeeData, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsEarnings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsDeductions, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPhones, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floEmployeeData.ResumeLayout(False)
            Me.floEmployeeMainInfo.ResumeLayout(False)
            Me.floEmployeeMainInfo.PerformLayout()
            Me.EmployeeTabControl.ResumeLayout(False)
            Me.tbpPersonal.ResumeLayout(False)
            Me.floPersonalInfo.ResumeLayout(False)
            Me.floPersonalInfo.PerformLayout()
            Me.tbpContact.ResumeLayout(False)
            Me.floContactInformation.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.DataGridViewPhoneDisplay, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbpEmployment.ResumeLayout(False)
            Me.floEmploymentInfo.ResumeLayout(False)
            Me.tbpPayroll.ResumeLayout(False)
            Me.floMainDisplay.ResumeLayout(False)
            Me.floMainDisplay.PerformLayout()
            Me.tbpEarningDeductions.ResumeLayout(False)
            Me.tbpEarningDeductions.PerformLayout()
            Me.CFlowLayout7.ResumeLayout(False)
            CType(Me.DataGridViewEarnings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridVewDeductions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsEarnings As BindingSource
        Friend WithEvents bsDeductions As BindingSource
        Friend WithEvents FrequencyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents RateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents FrequencyDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents RateDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
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
        Friend WithEvents floEmployeeData As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents floEmployeeMainInfo As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblEmployeeCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmployeeCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblEmployeeName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmployeeName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblEmployeeNameAra As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmployeeNameAra As Libraries.CBaseControlsLibrary.CTextBoxArabic
        Friend WithEvents EmployeeTabControl As Libraries.CBaseControlsLibrary.CTabControl
        Friend WithEvents tbpPersonal As Libraries.CBaseControlsLibrary.CTabPage
        Friend WithEvents floPersonalInfo As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblGender As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacGender As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblMaritalStatus As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacMaritalStatus As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblNationalityCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacNationalityCode As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents CLabel5 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacReligionIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblBirthDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpBirthDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblNationalIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtNationalIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblNotes As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtNotes As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents tbpContact As Libraries.CBaseControlsLibrary.CTabPage
        Friend WithEvents tbpEmployment As TabPage
        Friend WithEvents floEmploymentInfo As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblHiredDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpHiredDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblReleasedDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpReleasedDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblDepartmentIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacDepartmentIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblDesignationIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacDesignationIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblActive As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents chkActive As Libraries.CBaseControlsLibrary.CCheckBox
        Friend WithEvents tbpPayroll As Libraries.CBaseControlsLibrary.CTabPage
        Friend WithEvents floMainDisplay As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblBankIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cacBankIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblBankAccountNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtBankAccountNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblBalance As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblIbanNumber As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtIban As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblOpeningBalance As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtOpeningBalance As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtBalance As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPayFrequency As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboPayFrequency As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblPaySalariedOrHourly As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboPaySalariedOrHourly As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblPayRateType As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPayRateAmount As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPayRateAmount As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboPayRateType As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents tbpEarningDeductions As TabPage
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblEarnings As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CFlowLayout7 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents DataGridViewEarnings As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents dgvSequenceEarning As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents dgvEarningIdNo As Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn
        Friend WithEvents dgvEarningAmount As Libraries.CBaseControlsLibrary.CdgvColumnMoney
        Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridVewDeductions As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents dgvSequenceDeduction As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents dgvDeductionIdNo As Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn
        Friend WithEvents dgvDeductionAmount As Libraries.CBaseControlsLibrary.CdgvColumnMoney
        Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
        Friend WithEvents dgvSequence As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents dgvPhoneTypeIdNo As Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn
        Friend WithEvents dgvAreaCode As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents PhoneNumber As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
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
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmail As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblEmail As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents DataGridViewPhoneDisplay As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents dgvSequencePhoneDisplay As Libraries.CBaseControlsLibrary.CdgvColumnText
        Friend WithEvents FullPhone As DataGridViewTextBoxColumn
        Friend WithEvents FullPhoneAra As DataGridViewTextBoxColumn
        Friend WithEvents AreaCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents FullPhoneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents FullPhoneAraDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CountryTelIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PhoneNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PhoneTypeIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents lblStreet As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents AmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
        Friend WithEvents EarningIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
        Friend WithEvents SequenceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents AmountDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
        Friend WithEvents DeductionIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn
        Friend WithEvents SequenceDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    End Class

End Namespace