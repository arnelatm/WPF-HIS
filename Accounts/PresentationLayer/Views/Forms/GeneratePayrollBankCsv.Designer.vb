Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class GeneratePayrollBankCsv
        Inherits AATM.PresentationLayer.Forms.CFormEntry

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeneratePayrollBankCsv))
        Me.lblPayrollName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.cboIdNo = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
            Me.lblPayFrequency = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
            Me.lblPayrollCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayrollCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.dtpStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblPayrollName
            '
            Me.lblPayrollName.BackColor = System.Drawing.Color.Transparent
            Me.lblPayrollName.DisplayOnly = True
            Me.lblPayrollName.EditingMode = False
            Me.lblPayrollName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayrollName.Location = New System.Drawing.Point(1, 1)
            Me.lblPayrollName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayrollName.Name = "lblPayrollName"
            Me.lblPayrollName.Size = New System.Drawing.Size(157, 28)
            Me.lblPayrollName.TabIndex = 1
            Me.lblPayrollName.Text = "Payroll Name"
            Me.lblPayrollName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPayrollName.Translatable = True
            '
            'lblStartDate
            '
            Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
            Me.lblStartDate.DisplayOnly = True
            Me.lblStartDate.EditingMode = False
            Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblStartDate.Location = New System.Drawing.Point(1, 95)
            Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(157, 30)
            Me.lblStartDate.TabIndex = 3
            Me.lblStartDate.Text = "Start Date"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblStartDate.Translatable = True
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblPayrollName)
            Me.CFlowLayout1.Controls.Add(Me.cboIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblPayFrequency)
            Me.CFlowLayout1.Controls.Add(Me.cboPayCycleIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblPayrollCode)
            Me.CFlowLayout1.Controls.Add(Me.txtPayrollCode)
            Me.CFlowLayout1.Controls.Add(Me.lblStartDate)
            Me.CFlowLayout1.Controls.Add(Me.dtpStartDate)
            Me.CFlowLayout1.Controls.Add(Me.lblEndDate)
            Me.CFlowLayout1.Controls.Add(Me.dtpEndDate)
            Me.CFlowLayout1.Location = New System.Drawing.Point(16, 70)
            Me.CFlowLayout1.Margin = New System.Windows.Forms.Padding(4)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(669, 174)
            Me.CFlowLayout1.TabIndex = 4
            '
            'cboIdNo
            '
            Me.cboIdNo.BackColor = System.Drawing.Color.White
            Me.cboIdNo.BegFindValue = Nothing
            Me.cboIdNo.ChangingSearchValueOnly = False
            Me.cboIdNo.CurrentSearchTerm = ""
            Me.cboIdNo.DataValue = Nothing
            Me.cboIdNo.DefaultValue = Nothing
            Me.cboIdNo.DisplayMember = "Name"
            Me.cboIdNo.Editable = True
            Me.cboIdNo.EditingMode = True
            Me.cboIdNo.EndFindValue = Nothing
            Me.cboIdNo.FieldDescription = Nothing
            Me.cboIdNo.FieldName = Nothing
            Me.cboIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboIdNo.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.cboIdNo, True)
            Me.cboIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboIdNo.FormattingEnabled = True
            Me.cboIdNo.HideWhenNotEditingOrAdding = False
            Me.cboIdNo.IgnoreCase = False
            Me.cboIdNo.IntegralHeight = False
            Me.cboIdNo.LimitToList = False
            Me.cboIdNo.LinkedLabel = Nothing
            Me.cboIdNo.Location = New System.Drawing.Point(160, 1)
            Me.cboIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboIdNo.Name = "cboIdNo"
            Me.cboIdNo.OldValue = 0
            Me.cboIdNo.OriginalDataSource = Nothing
            Me.cboIdNo.OriginalList = Nothing
            Me.cboIdNo.OverrideDropDownStyleList = False
            Me.cboIdNo.PreviousSearchTerm = Nothing
            Me.cboIdNo.Size = New System.Drawing.Size(481, 28)
            Me.cboIdNo.SuggestBoxHeight = 200
            Me.cboIdNo.SuggestCharCount = 0
            Me.cboIdNo.TabIndex = 0
            Me.cboIdNo.TextToSearch = Nothing
            Me.cboIdNo.Translatable = False
            Me.cboIdNo.ValueIsMandatory = False
            Me.cboIdNo.ValueIsNullable = False
            Me.cboIdNo.ValueIsNumeric = False
            Me.cboIdNo.ValueMember = "IdNo"
            '
            'lblPayFrequency
            '
            Me.lblPayFrequency.BackColor = System.Drawing.Color.Transparent
            Me.lblPayFrequency.DisplayOnly = True
            Me.lblPayFrequency.EditingMode = False
            Me.lblPayFrequency.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayFrequency.Location = New System.Drawing.Point(1, 31)
            Me.lblPayFrequency.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayFrequency.Name = "lblPayFrequency"
            Me.lblPayFrequency.Size = New System.Drawing.Size(157, 30)
            Me.lblPayFrequency.TabIndex = 8
            Me.lblPayFrequency.Text = "Pay Cycle"
            Me.lblPayFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPayFrequency.Translatable = True
            '
            'cboPayCycleIdNo
            '
            Me.cboPayCycleIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayCycleIdNo.BegFindValue = Nothing
            Me.cboPayCycleIdNo.ChangingSearchValueOnly = False
            Me.cboPayCycleIdNo.CurrentSearchTerm = ""
            Me.cboPayCycleIdNo.DataValue = Nothing
            Me.cboPayCycleIdNo.DefaultValue = Nothing
            Me.cboPayCycleIdNo.DisplayMember = "Name"
            Me.cboPayCycleIdNo.DisplayOnly = True
            Me.cboPayCycleIdNo.DropDownHeight = 24
            Me.cboPayCycleIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboPayCycleIdNo.Editable = True
            Me.cboPayCycleIdNo.EditingMode = False
            Me.cboPayCycleIdNo.EndFindValue = Nothing
            Me.cboPayCycleIdNo.FieldDescription = Nothing
            Me.cboPayCycleIdNo.FieldName = Nothing
            Me.cboPayCycleIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPayCycleIdNo.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.cboPayCycleIdNo, True)
            Me.cboPayCycleIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayCycleIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayCycleIdNo.FormattingEnabled = True
            Me.cboPayCycleIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayCycleIdNo.IgnoreCase = False
            Me.cboPayCycleIdNo.IntegralHeight = False
            Me.cboPayCycleIdNo.LimitToList = False
            Me.cboPayCycleIdNo.LinkedLabel = Nothing
            Me.cboPayCycleIdNo.Location = New System.Drawing.Point(160, 31)
            Me.cboPayCycleIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPayCycleIdNo.MaxDropDownItems = 1
            Me.cboPayCycleIdNo.Name = "cboPayCycleIdNo"
            Me.cboPayCycleIdNo.OldValue = 0
            Me.cboPayCycleIdNo.OriginalDataSource = Nothing
            Me.cboPayCycleIdNo.OriginalList = Nothing
            Me.cboPayCycleIdNo.OverrideDropDownStyleList = False
            Me.cboPayCycleIdNo.PreviousSearchTerm = Nothing
            Me.cboPayCycleIdNo.Size = New System.Drawing.Size(481, 30)
            Me.cboPayCycleIdNo.SuggestBoxHeight = 200
            Me.cboPayCycleIdNo.SuggestCharCount = 0
            Me.cboPayCycleIdNo.TabIndex = 1
            Me.cboPayCycleIdNo.TextToSearch = Nothing
            Me.cboPayCycleIdNo.Translatable = False
            Me.cboPayCycleIdNo.ValueIsMandatory = False
            Me.cboPayCycleIdNo.ValueIsNullable = False
            Me.cboPayCycleIdNo.ValueIsNumeric = False
            Me.cboPayCycleIdNo.ValueMember = "IdNo"
            '
            'lblPayrollCode
            '
            Me.lblPayrollCode.BackColor = System.Drawing.Color.Transparent
            Me.lblPayrollCode.DisplayOnly = True
            Me.lblPayrollCode.EditingMode = False
            Me.lblPayrollCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayrollCode.Location = New System.Drawing.Point(1, 63)
            Me.lblPayrollCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayrollCode.Name = "lblPayrollCode"
            Me.lblPayrollCode.Size = New System.Drawing.Size(157, 30)
            Me.lblPayrollCode.TabIndex = 10
            Me.lblPayrollCode.Text = "Payroll Code"
            Me.lblPayrollCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPayrollCode.Translatable = True
            '
            'txtPayrollCode
            '
            Me.txtPayrollCode.BackColor = System.Drawing.Color.White
            Me.txtPayrollCode.BegFindValue = Nothing
            Me.txtPayrollCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayrollCode.ComputedValue = False
            Me.txtPayrollCode.CustomFormat = Nothing
            Me.txtPayrollCode.DataBoundControl = True
            Me.txtPayrollCode.DisplayOnly = True
            Me.txtPayrollCode.EditingMode = True
            Me.txtPayrollCode.EndFindValue = Nothing
            Me.txtPayrollCode.FieldDescription = Nothing
            Me.txtPayrollCode.FieldName = Nothing
            Me.txtPayrollCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayrollCode.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.txtPayrollCode, True)
            Me.txtPayrollCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayrollCode.ForeColor = System.Drawing.Color.Black
            Me.txtPayrollCode.LinkedLabel = Nothing
            Me.txtPayrollCode.Location = New System.Drawing.Point(160, 63)
            Me.txtPayrollCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayrollCode.MaximumValue = Nothing
            Me.txtPayrollCode.MinimumValue = Nothing
            Me.txtPayrollCode.Name = "txtPayrollCode"
            Me.txtPayrollCode.OldValue = Nothing
            Me.txtPayrollCode.OverrideMaxLength = 0
            Me.txtPayrollCode.ReadOnly = True
            Me.txtPayrollCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayrollCode.Size = New System.Drawing.Size(133, 26)
            Me.txtPayrollCode.TabIndex = 2
            Me.txtPayrollCode.Translatable = False
            '
            'dtpStartDate
            '
            Me.dtpStartDate.AutoSize = True
            Me.dtpStartDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpStartDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpStartDate.DefaultValue = Nothing
            Me.dtpStartDate.DisplayOnly = False
            Me.dtpStartDate.DtpDefaultValue = Nothing
            Me.dtpStartDate.EditingMode = True
            Me.dtpStartDate.EditsAllowed = False
            Me.CFlowLayout1.SetFlowBreak(Me.dtpStartDate, True)
            Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
            Me.dtpStartDate.LinkedLabel = Nothing
            Me.dtpStartDate.Location = New System.Drawing.Point(160, 95)
            Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.ReadOnlyDp = False
            Me.dtpStartDate.SecurityKey = Nothing
            Me.dtpStartDate.ShowLongDate = False
            Me.dtpStartDate.ShowTime = False
            Me.dtpStartDate.Size = New System.Drawing.Size(119, 27)
            Me.dtpStartDate.TabIndex = 11
            Me.dtpStartDate.TargetCalendar = CType(resources.GetObject("dtpStartDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpStartDate.Translatable = False
            Me.dtpStartDate.Value = Nothing
            Me.dtpStartDate.ValueIsMandatory = False
            Me.dtpStartDate.ValueIsNullable = False
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.DisplayOnly = True
            Me.lblEndDate.EditingMode = False
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEndDate.Location = New System.Drawing.Point(1, 127)
            Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Size = New System.Drawing.Size(157, 30)
            Me.lblEndDate.TabIndex = 5
            Me.lblEndDate.Text = "End Date"
            Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEndDate.Translatable = True
            '
            'dtpEndDate
            '
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
            Me.dtpEndDate.Location = New System.Drawing.Point(160, 127)
            Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.ReadOnlyDp = False
            Me.dtpEndDate.SecurityKey = Nothing
            Me.dtpEndDate.ShowLongDate = False
            Me.dtpEndDate.ShowTime = False
            Me.dtpEndDate.Size = New System.Drawing.Size(119, 27)
            Me.dtpEndDate.TabIndex = 12
            Me.dtpEndDate.TargetCalendar = CType(resources.GetObject("dtpEndDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpEndDate.Translatable = False
            Me.dtpEndDate.Value = Nothing
            Me.dtpEndDate.ValueIsMandatory = False
            Me.dtpEndDate.ValueIsNullable = False
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(196, 251)
            Me.btnOk.Margin = New System.Windows.Forms.Padding(4)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(120, 31)
            Me.btnOk.TabIndex = 8
            Me.btnOk.Text = "Ok"
            '
            'btnCancel
            '
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(324, 251)
            Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(120, 31)
            Me.btnCancel.TabIndex = 9
            Me.btnCancel.Text = "Cancel"
            '
            'GeneratePayrollBankCsv
            '
            Me.AcceptButton = Me.btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(689, 294)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.Name = "GeneratePayrollBankCsv"
            Me.Text = "Generate Payroll CSV File"
            Me.Controls.SetChildIndex(Me.btnOk, 0)
            Me.Controls.SetChildIndex(Me.btnCancel, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
            CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents lblPayrollName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblStartDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblEndDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents lblPayFrequency As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblPayrollCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPayrollCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents cboIdNo As Libraries.CBaseControlsLibrary.CdtComboBox
        Friend WithEvents cboPayCycleIdNo As Libraries.CBaseControlsLibrary.CdtComboBox
        Friend WithEvents dtpStartDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents dtpEndDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
    End Class
End NameSpace