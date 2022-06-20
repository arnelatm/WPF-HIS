Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeMedicalReport
        Inherits AATM.PresentationLayer.Forms.BFMain

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
        Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblReportDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpMedicalReportDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblVision = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblHearing = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblBPPulse = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblChestHeart = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblAbdomentDerma = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNeuro = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblFinalResult = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.chkVision = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
        Me.chkBpPulse = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
        Me.chkHearing = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
        Me.chkChestHeart = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
        Me.chkAbdomentDerma = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
        Me.chkNeuro = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
        Me.chkFinalResult = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'lblEmployeeCode
        '
        Me.lblEmployeeCode.DisplayOnly = true
        Me.lblEmployeeCode.EditingMode = false
        Me.lblEmployeeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEmployeeCode.Location = New System.Drawing.Point(1, 28)
        Me.lblEmployeeCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEmployeeCode.Name = "lblEmployeeCode"
        Me.lblEmployeeCode.Size = New System.Drawing.Size(150, 24)
        Me.lblEmployeeCode.TabIndex = 22
        Me.lblEmployeeCode.Text = "Employee Code:"
        Me.lblEmployeeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEmployeeCode.Translatable = true
        '
        'cboEmployeeIdNo
        '
        Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
        Me.cboEmployeeIdNo.BegFindValue = Nothing
        Me.cboEmployeeIdNo.ChangingSearchValueOnly = false
        Me.cboEmployeeIdNo.CurrentSearchTerm = ""
        Me.cboEmployeeIdNo.DataValue = Nothing
        Me.cboEmployeeIdNo.DefaultValue = Nothing
        Me.cboEmployeeIdNo.DisplayMember = "Name"
        Me.cboEmployeeIdNo.EditingMode = true
        Me.cboEmployeeIdNo.EndFindValue = Nothing
        Me.cboEmployeeIdNo.FieldDescription = Nothing
        Me.cboEmployeeIdNo.FieldName = Nothing
        Me.cboEmployeeIdNo.FilterRule = Nothing
        Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboEmployeeIdNo.FindEnabled = false
        Me.cboEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboEmployeeIdNo.FormattingEnabled = true
        Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = false
        Me.cboEmployeeIdNo.IgnoreCase = false
        Me.cboEmployeeIdNo.IntegralHeight = false
        Me.cboEmployeeIdNo.LinkedLabel = Nothing
        Me.cboEmployeeIdNo.Location = New System.Drawing.Point(153, 28)
        Me.cboEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
        Me.cboEmployeeIdNo.OldValue = 0
        Me.cboEmployeeIdNo.OriginalDataSource = Nothing
        Me.cboEmployeeIdNo.OriginalList = Nothing
        Me.cboEmployeeIdNo.OverrideDropDownStyleList = false
        Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
        Me.cboEmployeeIdNo.PropertySelector = Nothing
        Me.cboEmployeeIdNo.ReadOnlyCombo = false
        Me.cboEmployeeIdNo.Size = New System.Drawing.Size(520, 24)
        Me.cboEmployeeIdNo.SuggestBoxHeight = 200
        Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
        Me.cboEmployeeIdNo.TabIndex = 25
        Me.cboEmployeeIdNo.TextToSearch = Nothing
        Me.cboEmployeeIdNo.Translatable = false
        Me.cboEmployeeIdNo.ValueIsMandatory = false
        Me.cboEmployeeIdNo.ValueIsNullable = false
        Me.cboEmployeeIdNo.ValueIsNumeric = false
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
        Me.CFlowLayout1.Location = New System.Drawing.Point(12, 12)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(685, 278)
        Me.CFlowLayout1.TabIndex = 26
        '
        'CLabel2
        '
        Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CLabel2.Location = New System.Drawing.Point(1, 1)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(682, 25)
        Me.CLabel2.TabIndex = 26
        Me.CLabel2.Text = "Employee Information Printing"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLabel2.Translatable = true
        '
        'lblReportDate
        '
        Me.lblReportDate.DisplayOnly = true
        Me.lblReportDate.EditingMode = false
        Me.lblReportDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblReportDate.Location = New System.Drawing.Point(1, 54)
        Me.lblReportDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblReportDate.Name = "lblReportDate"
        Me.lblReportDate.Size = New System.Drawing.Size(150, 24)
        Me.lblReportDate.TabIndex = 27
        Me.lblReportDate.Text = "Medical Report Date:"
        Me.lblReportDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblReportDate.Translatable = true
        '
        'dtpMedicalReportDate
        '
        Me.dtpMedicalReportDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpMedicalReportDate.DefaultValue = Nothing
        Me.dtpMedicalReportDate.DisplayOnly = false
        Me.dtpMedicalReportDate.DtpDefaultValue = Nothing
        Me.dtpMedicalReportDate.EditingMode = true
        Me.dtpMedicalReportDate.EditsAllowed = false
        Me.CFlowLayout1.SetFlowBreak(Me.dtpMedicalReportDate, true)
        Me.dtpMedicalReportDate.ForeColor = System.Drawing.Color.Black
        Me.dtpMedicalReportDate.LinkedLabel = Nothing
        Me.dtpMedicalReportDate.Location = New System.Drawing.Point(153, 54)
        Me.dtpMedicalReportDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpMedicalReportDate.Name = "dtpMedicalReportDate"
        Me.dtpMedicalReportDate.ReadOnlyDp = false
        Me.dtpMedicalReportDate.SecurityKey = Nothing
        Me.dtpMedicalReportDate.ShowLongDate = false
        Me.dtpMedicalReportDate.ShowTime = false
        Me.dtpMedicalReportDate.Size = New System.Drawing.Size(111, 23)
        Me.dtpMedicalReportDate.TabIndex = 28
        Me.dtpMedicalReportDate.TargetCalendar = CType(resources.GetObject("dtpMedicalReportDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpMedicalReportDate.Translatable = false
        Me.dtpMedicalReportDate.Value = Nothing
        Me.dtpMedicalReportDate.ValueIsMandatory = false
        Me.dtpMedicalReportDate.ValueIsNullable = false
        '
        'lblVision
        '
        Me.lblVision.DisplayOnly = true
        Me.lblVision.EditingMode = false
        Me.lblVision.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblVision.Location = New System.Drawing.Point(1, 80)
        Me.lblVision.Margin = New System.Windows.Forms.Padding(1)
        Me.lblVision.Name = "lblVision"
        Me.lblVision.Size = New System.Drawing.Size(204, 24)
        Me.lblVision.TabIndex = 29
        Me.lblVision.Text = "Vision + Eyeglasses"
        Me.lblVision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVision.Translatable = true
        '
        'lblHearing
        '
        Me.lblHearing.DisplayOnly = true
        Me.lblHearing.EditingMode = false
        Me.lblHearing.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblHearing.Location = New System.Drawing.Point(1, 106)
        Me.lblHearing.Margin = New System.Windows.Forms.Padding(1)
        Me.lblHearing.Name = "lblHearing"
        Me.lblHearing.Size = New System.Drawing.Size(204, 24)
        Me.lblHearing.TabIndex = 31
        Me.lblHearing.Text = "Hearing"
        Me.lblHearing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblHearing.Translatable = true
        '
        'lblBPPulse
        '
        Me.lblBPPulse.DisplayOnly = true
        Me.lblBPPulse.EditingMode = false
        Me.lblBPPulse.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBPPulse.Location = New System.Drawing.Point(1, 132)
        Me.lblBPPulse.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBPPulse.Name = "lblBPPulse"
        Me.lblBPPulse.Size = New System.Drawing.Size(204, 24)
        Me.lblBPPulse.TabIndex = 33
        Me.lblBPPulse.Text = "Blood Pressure/Pulse"
        Me.lblBPPulse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBPPulse.Translatable = true
        '
        'lblChestHeart
        '
        Me.lblChestHeart.DisplayOnly = true
        Me.lblChestHeart.EditingMode = false
        Me.lblChestHeart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblChestHeart.Location = New System.Drawing.Point(1, 158)
        Me.lblChestHeart.Margin = New System.Windows.Forms.Padding(1)
        Me.lblChestHeart.Name = "lblChestHeart"
        Me.lblChestHeart.Size = New System.Drawing.Size(204, 24)
        Me.lblChestHeart.TabIndex = 35
        Me.lblChestHeart.Text = "Chest/Heart"
        Me.lblChestHeart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblChestHeart.Translatable = true
        '
        'lblAbdomentDerma
        '
        Me.lblAbdomentDerma.DisplayOnly = true
        Me.lblAbdomentDerma.EditingMode = false
        Me.lblAbdomentDerma.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAbdomentDerma.Location = New System.Drawing.Point(1, 184)
        Me.lblAbdomentDerma.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAbdomentDerma.Name = "lblAbdomentDerma"
        Me.lblAbdomentDerma.Size = New System.Drawing.Size(204, 24)
        Me.lblAbdomentDerma.TabIndex = 37
        Me.lblAbdomentDerma.Text = "Abdoment/Dermatological"
        Me.lblAbdomentDerma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAbdomentDerma.Translatable = true
        '
        'lblNeuro
        '
        Me.lblNeuro.DisplayOnly = true
        Me.lblNeuro.EditingMode = false
        Me.lblNeuro.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNeuro.Location = New System.Drawing.Point(1, 210)
        Me.lblNeuro.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNeuro.Name = "lblNeuro"
        Me.lblNeuro.Size = New System.Drawing.Size(204, 24)
        Me.lblNeuro.TabIndex = 39
        Me.lblNeuro.Text = "Neurological Disorder"
        Me.lblNeuro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNeuro.Translatable = true
        '
        'lblFinalResult
        '
        Me.lblFinalResult.DisplayOnly = true
        Me.lblFinalResult.EditingMode = false
        Me.lblFinalResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblFinalResult.Location = New System.Drawing.Point(1, 236)
        Me.lblFinalResult.Margin = New System.Windows.Forms.Padding(1)
        Me.lblFinalResult.Name = "lblFinalResult"
        Me.lblFinalResult.Size = New System.Drawing.Size(204, 24)
        Me.lblFinalResult.TabIndex = 41
        Me.lblFinalResult.Text = "Final Result"
        Me.lblFinalResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFinalResult.Translatable = true
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(25, 37)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(150, 25)
        Me.CLabel1.TabIndex = 26
        Me.CLabel1.Text = "Beginning Date :"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = true
        '
        'btnOk
        '
        Me.btnOk.DesignerSelected = false
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(233, 296)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.OriginalImageName = Nothing
        Me.btnOk.SecurityKey = ""
        Me.btnOk.Size = New System.Drawing.Size(90, 25)
        Me.btnOk.TabIndex = 27
        Me.btnOk.Text = "Ok"
        '
        'btnCancel
        '
        Me.btnCancel.DesignerSelected = false
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(355, 296)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(90, 25)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "Cancel"
        '
        'chkVision
        '
        Me.chkVision.BegFindValue = Nothing
        Me.chkVision.BoxSize = New System.Drawing.Size(14, 14)
        Me.chkVision.Checked = true
        Me.chkVision.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVision.DisplayOnly = false
        Me.chkVision.EditingMode = true
        Me.chkVision.EndFindValue = Nothing
        Me.chkVision.FieldDescription = Nothing
        Me.chkVision.FieldName = Nothing
        Me.chkVision.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkVision.FindEnabled = false
        Me.chkVision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CFlowLayout1.SetFlowBreak(Me.chkVision, true)
        Me.chkVision.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.chkVision.IFindableControl_FindEnabled = false
        Me.chkVision.IgnoreCase = false
        Me.chkVision.LinkedLabel = Nothing
        Me.chkVision.Location = New System.Drawing.Point(209, 82)
        Me.chkVision.Name = "chkVision"
        Me.chkVision.OldValue = Nothing
        Me.chkVision.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
        Me.chkVision.Size = New System.Drawing.Size(14, 14)
        Me.chkVision.TabIndex = 44
        Me.chkVision.Text = "CCheckBoxNew1"
        Me.chkVision.Translatable = true
        Me.chkVision.UseVisualStyleBackColor = true
        '
        'chkBpPulse
        '
        Me.chkBpPulse.BegFindValue = Nothing
        Me.chkBpPulse.BoxSize = New System.Drawing.Size(14, 14)
        Me.chkBpPulse.Checked = true
        Me.chkBpPulse.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBpPulse.DisplayOnly = false
        Me.chkBpPulse.EditingMode = true
        Me.chkBpPulse.EndFindValue = Nothing
        Me.chkBpPulse.FieldDescription = Nothing
        Me.chkBpPulse.FieldName = Nothing
        Me.chkBpPulse.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkBpPulse.FindEnabled = false
        Me.chkBpPulse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CFlowLayout1.SetFlowBreak(Me.chkBpPulse, true)
        Me.chkBpPulse.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.chkBpPulse.IFindableControl_FindEnabled = false
        Me.chkBpPulse.IgnoreCase = false
        Me.chkBpPulse.LinkedLabel = Nothing
        Me.chkBpPulse.Location = New System.Drawing.Point(209, 134)
        Me.chkBpPulse.Name = "chkBpPulse"
        Me.chkBpPulse.OldValue = Nothing
        Me.chkBpPulse.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
        Me.chkBpPulse.Size = New System.Drawing.Size(14, 14)
        Me.chkBpPulse.TabIndex = 45
        Me.chkBpPulse.Text = "CCheckBoxNew1"
        Me.chkBpPulse.Translatable = true
        Me.chkBpPulse.UseVisualStyleBackColor = true
        '
        'chkHearing
        '
        Me.chkHearing.BegFindValue = Nothing
        Me.chkHearing.BoxSize = New System.Drawing.Size(14, 14)
        Me.chkHearing.Checked = true
        Me.chkHearing.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHearing.DisplayOnly = false
        Me.chkHearing.EditingMode = true
        Me.chkHearing.EndFindValue = Nothing
        Me.chkHearing.FieldDescription = Nothing
        Me.chkHearing.FieldName = Nothing
        Me.chkHearing.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkHearing.FindEnabled = false
        Me.chkHearing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CFlowLayout1.SetFlowBreak(Me.chkHearing, true)
        Me.chkHearing.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.chkHearing.IFindableControl_FindEnabled = false
        Me.chkHearing.IgnoreCase = false
        Me.chkHearing.LinkedLabel = Nothing
        Me.chkHearing.Location = New System.Drawing.Point(209, 108)
        Me.chkHearing.Name = "chkHearing"
        Me.chkHearing.OldValue = Nothing
        Me.chkHearing.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
        Me.chkHearing.Size = New System.Drawing.Size(14, 14)
        Me.chkHearing.TabIndex = 46
        Me.chkHearing.Text = "CCheckBoxNew1"
        Me.chkHearing.Translatable = true
        Me.chkHearing.UseVisualStyleBackColor = true
        '
        'chkChestHeart
        '
        Me.chkChestHeart.BegFindValue = Nothing
        Me.chkChestHeart.BoxSize = New System.Drawing.Size(14, 14)
        Me.chkChestHeart.Checked = true
        Me.chkChestHeart.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkChestHeart.DisplayOnly = false
        Me.chkChestHeart.EditingMode = true
        Me.chkChestHeart.EndFindValue = Nothing
        Me.chkChestHeart.FieldDescription = Nothing
        Me.chkChestHeart.FieldName = Nothing
        Me.chkChestHeart.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkChestHeart.FindEnabled = false
        Me.chkChestHeart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CFlowLayout1.SetFlowBreak(Me.chkChestHeart, true)
        Me.chkChestHeart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.chkChestHeart.IFindableControl_FindEnabled = false
        Me.chkChestHeart.IgnoreCase = false
        Me.chkChestHeart.LinkedLabel = Nothing
        Me.chkChestHeart.Location = New System.Drawing.Point(209, 160)
        Me.chkChestHeart.Name = "chkChestHeart"
        Me.chkChestHeart.OldValue = Nothing
        Me.chkChestHeart.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
        Me.chkChestHeart.Size = New System.Drawing.Size(14, 14)
        Me.chkChestHeart.TabIndex = 47
        Me.chkChestHeart.Text = "CCheckBoxNew1"
        Me.chkChestHeart.Translatable = true
        Me.chkChestHeart.UseVisualStyleBackColor = true
        '
        'chkAbdomentDerma
        '
        Me.chkAbdomentDerma.BegFindValue = Nothing
        Me.chkAbdomentDerma.BoxSize = New System.Drawing.Size(14, 14)
        Me.chkAbdomentDerma.Checked = true
        Me.chkAbdomentDerma.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAbdomentDerma.DisplayOnly = false
        Me.chkAbdomentDerma.EditingMode = true
        Me.chkAbdomentDerma.EndFindValue = Nothing
        Me.chkAbdomentDerma.FieldDescription = Nothing
        Me.chkAbdomentDerma.FieldName = Nothing
        Me.chkAbdomentDerma.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkAbdomentDerma.FindEnabled = false
        Me.chkAbdomentDerma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CFlowLayout1.SetFlowBreak(Me.chkAbdomentDerma, true)
        Me.chkAbdomentDerma.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.chkAbdomentDerma.IFindableControl_FindEnabled = false
        Me.chkAbdomentDerma.IgnoreCase = false
        Me.chkAbdomentDerma.LinkedLabel = Nothing
        Me.chkAbdomentDerma.Location = New System.Drawing.Point(209, 186)
        Me.chkAbdomentDerma.Name = "chkAbdomentDerma"
        Me.chkAbdomentDerma.OldValue = Nothing
        Me.chkAbdomentDerma.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
        Me.chkAbdomentDerma.Size = New System.Drawing.Size(14, 14)
        Me.chkAbdomentDerma.TabIndex = 48
        Me.chkAbdomentDerma.Text = "CCheckBoxNew1"
        Me.chkAbdomentDerma.Translatable = true
        Me.chkAbdomentDerma.UseVisualStyleBackColor = true
        '
        'chkNeuro
        '
        Me.chkNeuro.BegFindValue = Nothing
        Me.chkNeuro.BoxSize = New System.Drawing.Size(14, 14)
        Me.chkNeuro.Checked = true
        Me.chkNeuro.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNeuro.DisplayOnly = false
        Me.chkNeuro.EditingMode = true
        Me.chkNeuro.EndFindValue = Nothing
        Me.chkNeuro.FieldDescription = Nothing
        Me.chkNeuro.FieldName = Nothing
        Me.chkNeuro.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkNeuro.FindEnabled = false
        Me.chkNeuro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CFlowLayout1.SetFlowBreak(Me.chkNeuro, true)
        Me.chkNeuro.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.chkNeuro.IFindableControl_FindEnabled = false
        Me.chkNeuro.IgnoreCase = false
        Me.chkNeuro.LinkedLabel = Nothing
        Me.chkNeuro.Location = New System.Drawing.Point(209, 212)
        Me.chkNeuro.Name = "chkNeuro"
        Me.chkNeuro.OldValue = Nothing
        Me.chkNeuro.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
        Me.chkNeuro.Size = New System.Drawing.Size(14, 14)
        Me.chkNeuro.TabIndex = 49
        Me.chkNeuro.Text = "CCheckBoxNew1"
        Me.chkNeuro.Translatable = true
        Me.chkNeuro.UseVisualStyleBackColor = true
        '
        'chkFinalResult
        '
        Me.chkFinalResult.BegFindValue = Nothing
        Me.chkFinalResult.BoxSize = New System.Drawing.Size(14, 14)
        Me.chkFinalResult.Checked = true
        Me.chkFinalResult.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFinalResult.DisplayOnly = false
        Me.chkFinalResult.EditingMode = true
        Me.chkFinalResult.EndFindValue = Nothing
        Me.chkFinalResult.FieldDescription = Nothing
        Me.chkFinalResult.FieldName = Nothing
        Me.chkFinalResult.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkFinalResult.FindEnabled = false
        Me.chkFinalResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CFlowLayout1.SetFlowBreak(Me.chkFinalResult, true)
        Me.chkFinalResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.chkFinalResult.IFindableControl_FindEnabled = false
        Me.chkFinalResult.IgnoreCase = false
        Me.chkFinalResult.LinkedLabel = Nothing
        Me.chkFinalResult.Location = New System.Drawing.Point(209, 238)
        Me.chkFinalResult.Name = "chkFinalResult"
        Me.chkFinalResult.OldValue = Nothing
        Me.chkFinalResult.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
        Me.chkFinalResult.Size = New System.Drawing.Size(14, 14)
        Me.chkFinalResult.TabIndex = 50
        Me.chkFinalResult.Text = "CCheckBoxNew1"
        Me.chkFinalResult.Translatable = true
        Me.chkFinalResult.UseVisualStyleBackColor = true
        '
        'EmployeeMedicalReport
        '
        Me.ClientSize = New System.Drawing.Size(695, 334)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Controls.Add(Me.CLabel1)
        Me.Name = "EmployeeMedicalReport"
        Me.Text = "Employee Medical Report Printing"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

        Friend WithEvents lblEmployeeCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboEmployeeIdNo As Libraries.CBaseControlsLibrary.CaComboBox
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