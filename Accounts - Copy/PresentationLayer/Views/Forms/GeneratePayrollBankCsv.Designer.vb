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
        Me.cboIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblPayFrequency = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblPayrollCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.dtpStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.dtpEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'lblPayrollName
        '
        Me.lblPayrollName.BackColor = System.Drawing.Color.Transparent
        Me.lblPayrollName.DisplayOnly = true
        Me.lblPayrollName.EditingMode = false
        Me.lblPayrollName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayrollName.Location = New System.Drawing.Point(1, 1)
        Me.lblPayrollName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayrollName.Name = "lblPayrollName"
        Me.lblPayrollName.Size = New System.Drawing.Size(118, 23)
        Me.lblPayrollName.TabIndex = 1
        Me.lblPayrollName.Text = "Payroll Name"
        Me.lblPayrollName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPayrollName.Translatable = true
        '
        'lblStartDate
        '
        Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
        Me.lblStartDate.DisplayOnly = true
        Me.lblStartDate.EditingMode = false
        Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblStartDate.Location = New System.Drawing.Point(1, 80)
        Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(118, 24)
        Me.lblStartDate.TabIndex = 3
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStartDate.Translatable = true
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
        Me.CFlowLayout1.Location = New System.Drawing.Point(12, 57)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(502, 141)
        Me.CFlowLayout1.TabIndex = 4
        '
        'cboIdNo
        '
        Me.cboIdNo.BackColor = System.Drawing.Color.White
        Me.cboIdNo.BegFindValue = Nothing
        Me.cboIdNo.ChangingSearchValueOnly = false
        Me.cboIdNo.CurrentSearchTerm = ""
        Me.cboIdNo.DefaultValue = Nothing
        Me.cboIdNo.DisplayMember = "Name"
        Me.cboIdNo.EditingMode = true
        Me.cboIdNo.EndFindValue = Nothing
        Me.cboIdNo.FieldDescription = Nothing
        Me.cboIdNo.FieldName = Nothing
        Me.cboIdNo.FilterRule = Nothing
        Me.cboIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboIdNo.FindEnabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.cboIdNo, true)
        Me.cboIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboIdNo.FormattingEnabled = true
        Me.cboIdNo.HideWhenNotEditingOrAdding = false
        Me.cboIdNo.IgnoreCase = false
        Me.cboIdNo.IntegralHeight = false
        Me.cboIdNo.LinkedLabel = Nothing
        Me.cboIdNo.Location = New System.Drawing.Point(121, 1)
        Me.cboIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboIdNo.Name = "cboIdNo"
        Me.cboIdNo.OldValue = 0
        Me.cboIdNo.OriginalDataSource = Nothing
        Me.cboIdNo.OriginalList = Nothing
        Me.cboIdNo.OverrideDropDownStyleList = false
        Me.cboIdNo.PreviousSearchTerm = Nothing
        Me.cboIdNo.PropertySelector = Nothing
        Me.cboIdNo.ReadOnlyCombo = false
        Me.cboIdNo.Size = New System.Drawing.Size(362, 24)
        Me.cboIdNo.SuggestBoxHeight = 200
        Me.cboIdNo.SuggestListOrderRule = Nothing
        Me.cboIdNo.TabIndex = 0
        Me.cboIdNo.TextToSearch = Nothing
        Me.cboIdNo.Translatable = false
        Me.cboIdNo.ValueIsMandatory = false
        Me.cboIdNo.ValueIsNullable = false
        Me.cboIdNo.ValueIsNumeric = false
        Me.cboIdNo.ValueMember = "IdNo"
        '
        'lblPayFrequency
        '
        Me.lblPayFrequency.BackColor = System.Drawing.Color.Transparent
        Me.lblPayFrequency.DisplayOnly = true
        Me.lblPayFrequency.EditingMode = false
        Me.lblPayFrequency.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayFrequency.Location = New System.Drawing.Point(1, 27)
        Me.lblPayFrequency.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayFrequency.Name = "lblPayFrequency"
        Me.lblPayFrequency.Size = New System.Drawing.Size(118, 24)
        Me.lblPayFrequency.TabIndex = 8
        Me.lblPayFrequency.Text = "Pay Cycle"
        Me.lblPayFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPayFrequency.Translatable = true
        '
        'cboPayCycleIdNo
        '
        Me.cboPayCycleIdNo.BackColor = System.Drawing.Color.White
        Me.cboPayCycleIdNo.BegFindValue = Nothing
        Me.cboPayCycleIdNo.ChangingSearchValueOnly = false
        Me.cboPayCycleIdNo.CurrentSearchTerm = ""
        Me.cboPayCycleIdNo.DefaultValue = Nothing
        Me.cboPayCycleIdNo.DisplayMember = "Name"
        Me.cboPayCycleIdNo.DisplayOnly = true
        Me.cboPayCycleIdNo.DropDownHeight = 21
        Me.cboPayCycleIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboPayCycleIdNo.EditingMode = true
        Me.cboPayCycleIdNo.EndFindValue = Nothing
        Me.cboPayCycleIdNo.FieldDescription = Nothing
        Me.cboPayCycleIdNo.FieldName = Nothing
        Me.cboPayCycleIdNo.FilterRule = Nothing
        Me.cboPayCycleIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPayCycleIdNo.FindEnabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.cboPayCycleIdNo, true)
        Me.cboPayCycleIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPayCycleIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboPayCycleIdNo.FormattingEnabled = true
        Me.cboPayCycleIdNo.HideWhenNotEditingOrAdding = false
        Me.cboPayCycleIdNo.IgnoreCase = false
        Me.cboPayCycleIdNo.IntegralHeight = false
        Me.cboPayCycleIdNo.LinkedLabel = Nothing
        Me.cboPayCycleIdNo.Location = New System.Drawing.Point(121, 27)
        Me.cboPayCycleIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPayCycleIdNo.MaxDropDownItems = 1
        Me.cboPayCycleIdNo.Name = "cboPayCycleIdNo"
        Me.cboPayCycleIdNo.OldValue = 0
        Me.cboPayCycleIdNo.OriginalDataSource = Nothing
        Me.cboPayCycleIdNo.OriginalList = Nothing
        Me.cboPayCycleIdNo.OverrideDropDownStyleList = false
        Me.cboPayCycleIdNo.PreviousSearchTerm = Nothing
        Me.cboPayCycleIdNo.PropertySelector = Nothing
        Me.cboPayCycleIdNo.ReadOnlyCombo = true
        Me.cboPayCycleIdNo.Size = New System.Drawing.Size(362, 25)
        Me.cboPayCycleIdNo.SuggestBoxHeight = 200
        Me.cboPayCycleIdNo.SuggestListOrderRule = Nothing
        Me.cboPayCycleIdNo.TabIndex = 1
        Me.cboPayCycleIdNo.TextToSearch = Nothing
        Me.cboPayCycleIdNo.Translatable = false
        Me.cboPayCycleIdNo.ValueIsMandatory = false
        Me.cboPayCycleIdNo.ValueIsNullable = false
        Me.cboPayCycleIdNo.ValueIsNumeric = false
        Me.cboPayCycleIdNo.ValueMember = "IdNo"
        '
        'lblPayrollCode
        '
        Me.lblPayrollCode.BackColor = System.Drawing.Color.Transparent
        Me.lblPayrollCode.DisplayOnly = true
        Me.lblPayrollCode.EditingMode = false
        Me.lblPayrollCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayrollCode.Location = New System.Drawing.Point(1, 54)
        Me.lblPayrollCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayrollCode.Name = "lblPayrollCode"
        Me.lblPayrollCode.Size = New System.Drawing.Size(118, 24)
        Me.lblPayrollCode.TabIndex = 10
        Me.lblPayrollCode.Text = "Payroll Code"
        Me.lblPayrollCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPayrollCode.Translatable = true
        '
        'txtPayrollCode
        '
        Me.txtPayrollCode.BackColor = System.Drawing.Color.White
        Me.txtPayrollCode.BegFindValue = Nothing
        Me.txtPayrollCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayrollCode.ComputedValue = false
        Me.txtPayrollCode.CustomFormat = Nothing
        Me.txtPayrollCode.DataBoundControl = true
        Me.txtPayrollCode.DisplayOnly = true
        Me.txtPayrollCode.EditingMode = true
        Me.txtPayrollCode.EndFindValue = Nothing
        Me.txtPayrollCode.FieldDescription = Nothing
        Me.txtPayrollCode.FieldName = Nothing
        Me.txtPayrollCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayrollCode.FindEnabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.txtPayrollCode, true)
        Me.txtPayrollCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayrollCode.ForeColor = System.Drawing.Color.Black
        Me.txtPayrollCode.LinkedLabel = Nothing
        Me.txtPayrollCode.Location = New System.Drawing.Point(121, 54)
        Me.txtPayrollCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayrollCode.MaximumValue = Nothing
        Me.txtPayrollCode.MinimumValue = Nothing
        Me.txtPayrollCode.Name = "txtPayrollCode"
        Me.txtPayrollCode.OldValue = Nothing
        Me.txtPayrollCode.ReadOnly = true
        Me.txtPayrollCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayrollCode.Size = New System.Drawing.Size(100, 23)
        Me.txtPayrollCode.TabIndex = 2
        Me.txtPayrollCode.Translatable = false
        '
        'lblEndDate
        '
        Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEndDate.DisplayOnly = true
        Me.lblEndDate.EditingMode = false
        Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEndDate.Location = New System.Drawing.Point(1, 106)
        Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(118, 24)
        Me.lblEndDate.TabIndex = 5
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEndDate.Translatable = true
        '
        'btnOk
        '
        Me.btnOk.DesignerSelected = false
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(147, 204)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.OriginalImageName = Nothing
        Me.btnOk.SecurityKey = ""
        Me.btnOk.Size = New System.Drawing.Size(90, 25)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "Ok"
        '
        'btnCancel
        '
        Me.btnCancel.DesignerSelected = false
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(243, 204)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(90, 25)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpStartDate.DefaultValue = Nothing
        Me.dtpStartDate.DisplayOnly = false
        Me.dtpStartDate.DtpDefaultValue = Nothing
        Me.dtpStartDate.EditingMode = true
        Me.dtpStartDate.EditsAllowed = false
        Me.CFlowLayout1.SetFlowBreak(Me.dtpStartDate, true)
        Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
        Me.dtpStartDate.LinkedLabel = Nothing
        Me.dtpStartDate.Location = New System.Drawing.Point(121, 80)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ReadOnlyDp = false
        Me.dtpStartDate.SecurityKey = Nothing
        Me.dtpStartDate.ShowLongDate = false
        Me.dtpStartDate.ShowTime = false
        Me.dtpStartDate.Size = New System.Drawing.Size(112, 23)
        Me.dtpStartDate.TabIndex = 11
        Me.dtpStartDate.TargetCalendar = CType(resources.GetObject("dtpStartDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpStartDate.Translatable = false
        Me.dtpStartDate.Value = Nothing
        Me.dtpStartDate.ValueIsMandatory = false
        Me.dtpStartDate.ValueIsNullable = false
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndDate.DefaultValue = Nothing
        Me.dtpEndDate.DisplayOnly = false
        Me.dtpEndDate.DtpDefaultValue = Nothing
        Me.dtpEndDate.EditingMode = true
        Me.dtpEndDate.EditsAllowed = false
        Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndDate.LinkedLabel = Nothing
        Me.dtpEndDate.Location = New System.Drawing.Point(121, 106)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ReadOnlyDp = false
        Me.dtpEndDate.SecurityKey = Nothing
        Me.dtpEndDate.ShowLongDate = false
        Me.dtpEndDate.ShowTime = false
        Me.dtpEndDate.Size = New System.Drawing.Size(112, 23)
        Me.dtpEndDate.TabIndex = 12
        Me.dtpEndDate.TargetCalendar = CType(resources.GetObject("dtpEndDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpEndDate.Translatable = false
        Me.dtpEndDate.Value = Nothing
        Me.dtpEndDate.ValueIsMandatory = false
        Me.dtpEndDate.ValueIsNullable = false
        '
        'GeneratePayrollBankCsv
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(517, 239)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
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
        Friend WithEvents cboIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents cboPayCycleIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents dtpStartDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents dtpEndDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
    End Class
End NameSpace