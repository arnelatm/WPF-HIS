Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeMedicalReport
        Inherits AATM.PresentationLayer.Forms.DFormBasic

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeMedicalReport))
        Me.lblEmployeeCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblReportDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpMedicalReportDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblVision = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkVision = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
            Me.lblHearing = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkHearing = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
            Me.lblBPPulse = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkBpPulse = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
            Me.lblChestHeart = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkChestHeart = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
            Me.lblAbdomentDerma = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkAbdomentDerma = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
            Me.lblNeuro = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkNeuro = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
            Me.lblFinalResult = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkFinalResult = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblEmployeeCode
            '
            Me.lblEmployeeCode.BackColor = System.Drawing.Color.Transparent
            Me.lblEmployeeCode.DisplayOnly = True
            Me.lblEmployeeCode.EditingMode = False
            Me.lblEmployeeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEmployeeCode.Location = New System.Drawing.Point(1, 54)
            Me.lblEmployeeCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEmployeeCode.Name = "lblEmployeeCode"
            Me.lblEmployeeCode.Size = New System.Drawing.Size(150, 24)
            Me.lblEmployeeCode.TabIndex = 22
            Me.lblEmployeeCode.Text = "Employee Code:"
            Me.lblEmployeeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEmployeeCode.Translatable = True
            '
            'cboEmployeeIdNo
            '
            Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
            Me.cboEmployeeIdNo.BegFindValue = Nothing
            Me.cboEmployeeIdNo.ChangingSearchValueOnly = False
            Me.cboEmployeeIdNo.CurrentSearchTerm = ""
            Me.cboEmployeeIdNo.DataValue = Nothing
            Me.cboEmployeeIdNo.DefaultValue = Nothing
            Me.cboEmployeeIdNo.DisplayMember = "Name"
            Me.cboEmployeeIdNo.Editable = True
            Me.cboEmployeeIdNo.EditingMode = True
            Me.cboEmployeeIdNo.EndFindValue = Nothing
            Me.cboEmployeeIdNo.FieldDescription = Nothing
            Me.cboEmployeeIdNo.FieldName = Nothing
            Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboEmployeeIdNo.FindEnabled = False
            Me.cboEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboEmployeeIdNo.FormattingEnabled = True
            Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboEmployeeIdNo.IgnoreCase = False
            Me.cboEmployeeIdNo.LimitToList = False
            Me.cboEmployeeIdNo.LinkedLabel = Nothing
            Me.cboEmployeeIdNo.Location = New System.Drawing.Point(153, 54)
            Me.cboEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
            Me.cboEmployeeIdNo.OldValue = 0
            Me.cboEmployeeIdNo.OriginalDataSource = Nothing
            Me.cboEmployeeIdNo.OriginalList = Nothing
            Me.cboEmployeeIdNo.OverrideDropDownStyleList = False
            Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
            Me.cboEmployeeIdNo.Size = New System.Drawing.Size(520, 28)
            Me.cboEmployeeIdNo.SuggestBoxHeight = 200
            Me.cboEmployeeIdNo.SuggestCharCount = 0
            Me.cboEmployeeIdNo.TabIndex = 25
            Me.cboEmployeeIdNo.TextToSearch = Nothing
            Me.cboEmployeeIdNo.Translatable = False
            Me.cboEmployeeIdNo.ValueIsMandatory = False
            Me.cboEmployeeIdNo.ValueIsNullable = False
            Me.cboEmployeeIdNo.ValueIsNumeric = False
            Me.cboEmployeeIdNo.ValueMember = "IdNo"
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.lblEmployeeCode)
            Me.CFlowLayout1.Controls.Add(Me.cboEmployeeIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblReportDate)
            Me.CFlowLayout1.Controls.Add(Me.dtpMedicalReportDate)
            Me.CFlowLayout1.Controls.Add(Me.lblVision)
            Me.CFlowLayout1.Controls.Add(Me.chkVision)
            Me.CFlowLayout1.Controls.Add(Me.lblHearing)
            Me.CFlowLayout1.Controls.Add(Me.chkHearing)
            Me.CFlowLayout1.Controls.Add(Me.lblBPPulse)
            Me.CFlowLayout1.Controls.Add(Me.chkBpPulse)
            Me.CFlowLayout1.Controls.Add(Me.lblChestHeart)
            Me.CFlowLayout1.Controls.Add(Me.chkChestHeart)
            Me.CFlowLayout1.Controls.Add(Me.lblAbdomentDerma)
            Me.CFlowLayout1.Controls.Add(Me.chkAbdomentDerma)
            Me.CFlowLayout1.Controls.Add(Me.lblNeuro)
            Me.CFlowLayout1.Controls.Add(Me.chkNeuro)
            Me.CFlowLayout1.Controls.Add(Me.lblFinalResult)
            Me.CFlowLayout1.Controls.Add(Me.chkFinalResult)
            Me.CFlowLayout1.Location = New System.Drawing.Point(10, 30)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(685, 303)
            Me.CFlowLayout1.TabIndex = 26
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.CLabel2.Location = New System.Drawing.Point(1, 1)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(682, 51)
            Me.CLabel2.TabIndex = 26
            Me.CLabel2.Text = "Employee Information Printing"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.CLabel2.Translatable = True
            '
            'lblReportDate
            '
            Me.lblReportDate.BackColor = System.Drawing.Color.Transparent
            Me.lblReportDate.DisplayOnly = True
            Me.lblReportDate.EditingMode = False
            Me.lblReportDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportDate.Location = New System.Drawing.Point(1, 84)
            Me.lblReportDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportDate.Name = "lblReportDate"
            Me.lblReportDate.Size = New System.Drawing.Size(150, 24)
            Me.lblReportDate.TabIndex = 27
            Me.lblReportDate.Text = "Medical Report Date:"
            Me.lblReportDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblReportDate.Translatable = True
            '
            'dtpMedicalReportDate
            '
            Me.dtpMedicalReportDate.AutoSize = True
            Me.dtpMedicalReportDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpMedicalReportDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpMedicalReportDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpMedicalReportDate.DefaultValue = Nothing
            Me.dtpMedicalReportDate.DisplayOnly = False
            Me.dtpMedicalReportDate.DtpDefaultValue = Nothing
            Me.dtpMedicalReportDate.EditingMode = True
            Me.dtpMedicalReportDate.EditsAllowed = False
            Me.CFlowLayout1.SetFlowBreak(Me.dtpMedicalReportDate, True)
            Me.dtpMedicalReportDate.ForeColor = System.Drawing.Color.Black
            Me.dtpMedicalReportDate.LinkedLabel = Nothing
            Me.dtpMedicalReportDate.Location = New System.Drawing.Point(153, 84)
            Me.dtpMedicalReportDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpMedicalReportDate.Name = "dtpMedicalReportDate"
            Me.dtpMedicalReportDate.ReadOnlyDp = False
            Me.dtpMedicalReportDate.SecurityKey = Nothing
            Me.dtpMedicalReportDate.ShowLongDate = False
            Me.dtpMedicalReportDate.ShowTime = False
            Me.dtpMedicalReportDate.Size = New System.Drawing.Size(119, 27)
            Me.dtpMedicalReportDate.TabIndex = 28
            Me.dtpMedicalReportDate.TargetCalendar = CType(resources.GetObject("dtpMedicalReportDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpMedicalReportDate.Translatable = False
            Me.dtpMedicalReportDate.Value = Nothing
            Me.dtpMedicalReportDate.ValueIsMandatory = False
            Me.dtpMedicalReportDate.ValueIsNullable = False
            '
            'lblVision
            '
            Me.lblVision.BackColor = System.Drawing.Color.Transparent
            Me.lblVision.DisplayOnly = True
            Me.lblVision.EditingMode = False
            Me.lblVision.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVision.Location = New System.Drawing.Point(1, 113)
            Me.lblVision.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVision.Name = "lblVision"
            Me.lblVision.Size = New System.Drawing.Size(204, 24)
            Me.lblVision.TabIndex = 29
            Me.lblVision.Text = "Vision + Eyeglasses"
            Me.lblVision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblVision.Translatable = True
            '
            'chkVision
            '
            Me.chkVision.BegFindValue = Nothing
            Me.chkVision.BoxSize = New System.Drawing.Size(14, 14)
            Me.chkVision.Checked = True
            Me.chkVision.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkVision.DisplayOnly = False
            Me.chkVision.EditingMode = True
            Me.chkVision.EndFindValue = Nothing
            Me.chkVision.FieldDescription = Nothing
            Me.chkVision.FieldName = Nothing
            Me.chkVision.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkVision.FindEnabled = False
            Me.chkVision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CFlowLayout1.SetFlowBreak(Me.chkVision, True)
            Me.chkVision.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.chkVision.IFindableControl_FindEnabled = False
            Me.chkVision.IgnoreCase = False
            Me.chkVision.LinkedLabel = Nothing
            Me.chkVision.Location = New System.Drawing.Point(209, 115)
            Me.chkVision.Name = "chkVision"
            Me.chkVision.OldValue = Nothing
            Me.chkVision.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
            Me.chkVision.Size = New System.Drawing.Size(14, 14)
            Me.chkVision.TabIndex = 44
            Me.chkVision.Text = "CCheckBoxNew1"
            Me.chkVision.Translatable = True
            Me.chkVision.UseVisualStyleBackColor = True
            '
            'lblHearing
            '
            Me.lblHearing.BackColor = System.Drawing.Color.Transparent
            Me.lblHearing.DisplayOnly = True
            Me.lblHearing.EditingMode = False
            Me.lblHearing.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblHearing.Location = New System.Drawing.Point(1, 139)
            Me.lblHearing.Margin = New System.Windows.Forms.Padding(1)
            Me.lblHearing.Name = "lblHearing"
            Me.lblHearing.Size = New System.Drawing.Size(204, 24)
            Me.lblHearing.TabIndex = 31
            Me.lblHearing.Text = "Hearing"
            Me.lblHearing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblHearing.Translatable = True
            '
            'chkHearing
            '
            Me.chkHearing.BegFindValue = Nothing
            Me.chkHearing.BoxSize = New System.Drawing.Size(14, 14)
            Me.chkHearing.Checked = True
            Me.chkHearing.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkHearing.DisplayOnly = False
            Me.chkHearing.EditingMode = True
            Me.chkHearing.EndFindValue = Nothing
            Me.chkHearing.FieldDescription = Nothing
            Me.chkHearing.FieldName = Nothing
            Me.chkHearing.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkHearing.FindEnabled = False
            Me.chkHearing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CFlowLayout1.SetFlowBreak(Me.chkHearing, True)
            Me.chkHearing.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.chkHearing.IFindableControl_FindEnabled = False
            Me.chkHearing.IgnoreCase = False
            Me.chkHearing.LinkedLabel = Nothing
            Me.chkHearing.Location = New System.Drawing.Point(209, 141)
            Me.chkHearing.Name = "chkHearing"
            Me.chkHearing.OldValue = Nothing
            Me.chkHearing.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
            Me.chkHearing.Size = New System.Drawing.Size(14, 14)
            Me.chkHearing.TabIndex = 46
            Me.chkHearing.Text = "CCheckBoxNew1"
            Me.chkHearing.Translatable = True
            Me.chkHearing.UseVisualStyleBackColor = True
            '
            'lblBPPulse
            '
            Me.lblBPPulse.BackColor = System.Drawing.Color.Transparent
            Me.lblBPPulse.DisplayOnly = True
            Me.lblBPPulse.EditingMode = False
            Me.lblBPPulse.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBPPulse.Location = New System.Drawing.Point(1, 165)
            Me.lblBPPulse.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBPPulse.Name = "lblBPPulse"
            Me.lblBPPulse.Size = New System.Drawing.Size(204, 24)
            Me.lblBPPulse.TabIndex = 33
            Me.lblBPPulse.Text = "Blood Pressure/Pulse"
            Me.lblBPPulse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblBPPulse.Translatable = True
            '
            'chkBpPulse
            '
            Me.chkBpPulse.BegFindValue = Nothing
            Me.chkBpPulse.BoxSize = New System.Drawing.Size(14, 14)
            Me.chkBpPulse.Checked = True
            Me.chkBpPulse.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkBpPulse.DisplayOnly = False
            Me.chkBpPulse.EditingMode = True
            Me.chkBpPulse.EndFindValue = Nothing
            Me.chkBpPulse.FieldDescription = Nothing
            Me.chkBpPulse.FieldName = Nothing
            Me.chkBpPulse.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkBpPulse.FindEnabled = False
            Me.chkBpPulse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CFlowLayout1.SetFlowBreak(Me.chkBpPulse, True)
            Me.chkBpPulse.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.chkBpPulse.IFindableControl_FindEnabled = False
            Me.chkBpPulse.IgnoreCase = False
            Me.chkBpPulse.LinkedLabel = Nothing
            Me.chkBpPulse.Location = New System.Drawing.Point(209, 167)
            Me.chkBpPulse.Name = "chkBpPulse"
            Me.chkBpPulse.OldValue = Nothing
            Me.chkBpPulse.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
            Me.chkBpPulse.Size = New System.Drawing.Size(14, 14)
            Me.chkBpPulse.TabIndex = 45
            Me.chkBpPulse.Text = "CCheckBoxNew1"
            Me.chkBpPulse.Translatable = True
            Me.chkBpPulse.UseVisualStyleBackColor = True
            '
            'lblChestHeart
            '
            Me.lblChestHeart.BackColor = System.Drawing.Color.Transparent
            Me.lblChestHeart.DisplayOnly = True
            Me.lblChestHeart.EditingMode = False
            Me.lblChestHeart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblChestHeart.Location = New System.Drawing.Point(1, 191)
            Me.lblChestHeart.Margin = New System.Windows.Forms.Padding(1)
            Me.lblChestHeart.Name = "lblChestHeart"
            Me.lblChestHeart.Size = New System.Drawing.Size(204, 24)
            Me.lblChestHeart.TabIndex = 35
            Me.lblChestHeart.Text = "Chest/Heart"
            Me.lblChestHeart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblChestHeart.Translatable = True
            '
            'chkChestHeart
            '
            Me.chkChestHeart.BegFindValue = Nothing
            Me.chkChestHeart.BoxSize = New System.Drawing.Size(14, 14)
            Me.chkChestHeart.Checked = True
            Me.chkChestHeart.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkChestHeart.DisplayOnly = False
            Me.chkChestHeart.EditingMode = True
            Me.chkChestHeart.EndFindValue = Nothing
            Me.chkChestHeart.FieldDescription = Nothing
            Me.chkChestHeart.FieldName = Nothing
            Me.chkChestHeart.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkChestHeart.FindEnabled = False
            Me.chkChestHeart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CFlowLayout1.SetFlowBreak(Me.chkChestHeart, True)
            Me.chkChestHeart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.chkChestHeart.IFindableControl_FindEnabled = False
            Me.chkChestHeart.IgnoreCase = False
            Me.chkChestHeart.LinkedLabel = Nothing
            Me.chkChestHeart.Location = New System.Drawing.Point(209, 193)
            Me.chkChestHeart.Name = "chkChestHeart"
            Me.chkChestHeart.OldValue = Nothing
            Me.chkChestHeart.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
            Me.chkChestHeart.Size = New System.Drawing.Size(14, 14)
            Me.chkChestHeart.TabIndex = 47
            Me.chkChestHeart.Text = "CCheckBoxNew1"
            Me.chkChestHeart.Translatable = True
            Me.chkChestHeart.UseVisualStyleBackColor = True
            '
            'lblAbdomentDerma
            '
            Me.lblAbdomentDerma.BackColor = System.Drawing.Color.Transparent
            Me.lblAbdomentDerma.DisplayOnly = True
            Me.lblAbdomentDerma.EditingMode = False
            Me.lblAbdomentDerma.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAbdomentDerma.Location = New System.Drawing.Point(1, 217)
            Me.lblAbdomentDerma.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAbdomentDerma.Name = "lblAbdomentDerma"
            Me.lblAbdomentDerma.Size = New System.Drawing.Size(204, 24)
            Me.lblAbdomentDerma.TabIndex = 37
            Me.lblAbdomentDerma.Text = "Abdoment/Dermatological"
            Me.lblAbdomentDerma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblAbdomentDerma.Translatable = True
            '
            'chkAbdomentDerma
            '
            Me.chkAbdomentDerma.BegFindValue = Nothing
            Me.chkAbdomentDerma.BoxSize = New System.Drawing.Size(14, 14)
            Me.chkAbdomentDerma.Checked = True
            Me.chkAbdomentDerma.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkAbdomentDerma.DisplayOnly = False
            Me.chkAbdomentDerma.EditingMode = True
            Me.chkAbdomentDerma.EndFindValue = Nothing
            Me.chkAbdomentDerma.FieldDescription = Nothing
            Me.chkAbdomentDerma.FieldName = Nothing
            Me.chkAbdomentDerma.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkAbdomentDerma.FindEnabled = False
            Me.chkAbdomentDerma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CFlowLayout1.SetFlowBreak(Me.chkAbdomentDerma, True)
            Me.chkAbdomentDerma.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.chkAbdomentDerma.IFindableControl_FindEnabled = False
            Me.chkAbdomentDerma.IgnoreCase = False
            Me.chkAbdomentDerma.LinkedLabel = Nothing
            Me.chkAbdomentDerma.Location = New System.Drawing.Point(209, 219)
            Me.chkAbdomentDerma.Name = "chkAbdomentDerma"
            Me.chkAbdomentDerma.OldValue = Nothing
            Me.chkAbdomentDerma.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
            Me.chkAbdomentDerma.Size = New System.Drawing.Size(14, 14)
            Me.chkAbdomentDerma.TabIndex = 48
            Me.chkAbdomentDerma.Text = "CCheckBoxNew1"
            Me.chkAbdomentDerma.Translatable = True
            Me.chkAbdomentDerma.UseVisualStyleBackColor = True
            '
            'lblNeuro
            '
            Me.lblNeuro.BackColor = System.Drawing.Color.Transparent
            Me.lblNeuro.DisplayOnly = True
            Me.lblNeuro.EditingMode = False
            Me.lblNeuro.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNeuro.Location = New System.Drawing.Point(1, 243)
            Me.lblNeuro.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNeuro.Name = "lblNeuro"
            Me.lblNeuro.Size = New System.Drawing.Size(204, 24)
            Me.lblNeuro.TabIndex = 39
            Me.lblNeuro.Text = "Neurological Disorder"
            Me.lblNeuro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblNeuro.Translatable = True
            '
            'chkNeuro
            '
            Me.chkNeuro.BegFindValue = Nothing
            Me.chkNeuro.BoxSize = New System.Drawing.Size(14, 14)
            Me.chkNeuro.Checked = True
            Me.chkNeuro.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkNeuro.DisplayOnly = False
            Me.chkNeuro.EditingMode = True
            Me.chkNeuro.EndFindValue = Nothing
            Me.chkNeuro.FieldDescription = Nothing
            Me.chkNeuro.FieldName = Nothing
            Me.chkNeuro.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkNeuro.FindEnabled = False
            Me.chkNeuro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CFlowLayout1.SetFlowBreak(Me.chkNeuro, True)
            Me.chkNeuro.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.chkNeuro.IFindableControl_FindEnabled = False
            Me.chkNeuro.IgnoreCase = False
            Me.chkNeuro.LinkedLabel = Nothing
            Me.chkNeuro.Location = New System.Drawing.Point(209, 245)
            Me.chkNeuro.Name = "chkNeuro"
            Me.chkNeuro.OldValue = Nothing
            Me.chkNeuro.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
            Me.chkNeuro.Size = New System.Drawing.Size(14, 14)
            Me.chkNeuro.TabIndex = 49
            Me.chkNeuro.Text = "CCheckBoxNew1"
            Me.chkNeuro.Translatable = True
            Me.chkNeuro.UseVisualStyleBackColor = True
            '
            'lblFinalResult
            '
            Me.lblFinalResult.BackColor = System.Drawing.Color.Transparent
            Me.lblFinalResult.DisplayOnly = True
            Me.lblFinalResult.EditingMode = False
            Me.lblFinalResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblFinalResult.Location = New System.Drawing.Point(1, 269)
            Me.lblFinalResult.Margin = New System.Windows.Forms.Padding(1)
            Me.lblFinalResult.Name = "lblFinalResult"
            Me.lblFinalResult.Size = New System.Drawing.Size(204, 24)
            Me.lblFinalResult.TabIndex = 41
            Me.lblFinalResult.Text = "Final Result"
            Me.lblFinalResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblFinalResult.Translatable = True
            '
            'chkFinalResult
            '
            Me.chkFinalResult.BegFindValue = Nothing
            Me.chkFinalResult.BoxSize = New System.Drawing.Size(14, 14)
            Me.chkFinalResult.Checked = True
            Me.chkFinalResult.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkFinalResult.DisplayOnly = False
            Me.chkFinalResult.EditingMode = True
            Me.chkFinalResult.EndFindValue = Nothing
            Me.chkFinalResult.FieldDescription = Nothing
            Me.chkFinalResult.FieldName = Nothing
            Me.chkFinalResult.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkFinalResult.FindEnabled = False
            Me.chkFinalResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CFlowLayout1.SetFlowBreak(Me.chkFinalResult, True)
            Me.chkFinalResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.chkFinalResult.IFindableControl_FindEnabled = False
            Me.chkFinalResult.IgnoreCase = False
            Me.chkFinalResult.LinkedLabel = Nothing
            Me.chkFinalResult.Location = New System.Drawing.Point(209, 271)
            Me.chkFinalResult.Name = "chkFinalResult"
            Me.chkFinalResult.OldValue = Nothing
            Me.chkFinalResult.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
            Me.chkFinalResult.Size = New System.Drawing.Size(14, 14)
            Me.chkFinalResult.TabIndex = 50
            Me.chkFinalResult.Text = "CCheckBoxNew1"
            Me.chkFinalResult.Translatable = True
            Me.chkFinalResult.UseVisualStyleBackColor = True
            '
            'CLabel1
            '
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(25, 37)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(150, 25)
            Me.CLabel1.TabIndex = 26
            Me.CLabel1.Text = "Beginning Date :"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(241, 347)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(90, 25)
            Me.btnOk.TabIndex = 27
            Me.btnOk.Text = "Ok"
            '
            'btnCancel
            '
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(363, 347)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'EmployeeMedicalReport
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.ClientSize = New System.Drawing.Size(695, 384)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.CLabel1)
            Me.Name = "EmployeeMedicalReport"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.RightToLeftDisplay = "False"
            Me.Text = "Employee Medical Report Printing"
            Me.Controls.SetChildIndex(Me.CLabel1, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
            Me.Controls.SetChildIndex(Me.btnOk, 0)
            Me.Controls.SetChildIndex(Me.btnCancel, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lblEmployeeCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboEmployeeIdNo As Libraries.CBaseControlsLibrary.AtmComboBox
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents lblReportDate As CLabel
        Friend WithEvents dtpMedicalReportDate As CCustomDateTimePicker
        Friend WithEvents lblVision As CLabel
        Friend WithEvents lblHearing As CLabel
        Friend WithEvents lblBPPulse As CLabel
        Friend WithEvents lblChestHeart As CLabel
        Friend WithEvents lblAbdomentDerma As CLabel
        Friend WithEvents lblNeuro As CLabel
        Friend WithEvents lblFinalResult As CLabel
        Friend WithEvents chkVision As CCheckBoxNew
        Friend WithEvents chkHearing As CCheckBoxNew
        Friend WithEvents chkBpPulse As CCheckBoxNew
        Friend WithEvents chkChestHeart As CCheckBoxNew
        Friend WithEvents chkAbdomentDerma As CCheckBoxNew
        Friend WithEvents chkNeuro As CCheckBoxNew
        Friend WithEvents chkFinalResult As CCheckBoxNew
    End Class
End NameSpace