Namespace PresentationLayer.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SalaryLoanScheduleView
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalaryLoanScheduleView))
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPeriodicPayment = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.txtPeriodicPayment = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout1.Controls.Add(Me.TxtIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblEmployeeIdNo)
        Me.CFlowLayout1.Controls.Add(Me.cboEmployeeIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblAmount)
        Me.CFlowLayout1.Controls.Add(Me.txtAmount)
        Me.CFlowLayout1.Controls.Add(Me.lblStartDate)
        Me.CFlowLayout1.Controls.Add(Me.dtpStartDate)
        Me.CFlowLayout1.Controls.Add(Me.lblPeriodicPayment)
        Me.CFlowLayout1.Controls.Add(Me.txtPeriodicPayment)
        Me.CFlowLayout1.Controls.Add(Me.lblDateCreated)
        Me.CFlowLayout1.Controls.Add(Me.txtDateCreated)
        Me.CFlowLayout1.Location = New System.Drawing.Point(13, 13)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10)
        Me.CFlowLayout1.Size = New System.Drawing.Size(604, 170)
        Me.CFlowLayout1.TabIndex = 1
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(155, 23)
        Me.lblIdNo.TabIndex = 163
        Me.lblIdNo.Text = "ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIdNo.Translatable = true
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.TxtIdNo, true)
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.Location = New System.Drawing.Point(168, 11)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIdNo.TabIndex = 159
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblEmployeeIdNo
        '
        Me.lblEmployeeIdNo.DisplayOnly = true
        Me.lblEmployeeIdNo.EditingMode = false
        Me.lblEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEmployeeIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEmployeeIdNo.Location = New System.Drawing.Point(11, 36)
        Me.lblEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEmployeeIdNo.Name = "lblEmployeeIdNo"
        Me.lblEmployeeIdNo.Size = New System.Drawing.Size(155, 23)
        Me.lblEmployeeIdNo.TabIndex = 165
        Me.lblEmployeeIdNo.Text = "Name"
        Me.lblEmployeeIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEmployeeIdNo.Translatable = true
        '
        'cboEmployeeIdNo
        '
        Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
        Me.cboEmployeeIdNo.BegFindValue = Nothing
        Me.cboEmployeeIdNo.ChangingSearchValueOnly = false
        Me.cboEmployeeIdNo.CurrentSearchTerm = ""
        Me.cboEmployeeIdNo.DefaultValue = Nothing
        Me.cboEmployeeIdNo.DisplayMember = "Name"
        Me.cboEmployeeIdNo.EditingMode = true
        Me.cboEmployeeIdNo.EndFindValue = Nothing
        Me.cboEmployeeIdNo.FieldDescription = Nothing
        Me.cboEmployeeIdNo.FieldName = Nothing
        Me.cboEmployeeIdNo.FilterRule = Nothing
        Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboEmployeeIdNo.FindEnabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.cboEmployeeIdNo, true)
        Me.cboEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboEmployeeIdNo.FormattingEnabled = true
        Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = false
        Me.cboEmployeeIdNo.IgnoreCase = false
        Me.cboEmployeeIdNo.IntegralHeight = false
        Me.cboEmployeeIdNo.LinkedLabel = Me.lblEmployeeIdNo
        Me.cboEmployeeIdNo.Location = New System.Drawing.Point(168, 36)
        Me.cboEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
        Me.cboEmployeeIdNo.OldValue = 0
        Me.cboEmployeeIdNo.OriginalDataSource = Nothing
        Me.cboEmployeeIdNo.OriginalList = Nothing
        Me.cboEmployeeIdNo.OverrideDropDownStyleList = false
        Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
        Me.cboEmployeeIdNo.PropertySelector = Nothing
        Me.cboEmployeeIdNo.ReadOnlyCombo = false
        Me.cboEmployeeIdNo.Size = New System.Drawing.Size(418, 24)
        Me.cboEmployeeIdNo.SuggestBoxHeight = 200
        Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
        Me.cboEmployeeIdNo.TabIndex = 272
        Me.cboEmployeeIdNo.TextToSearch = Nothing
        Me.cboEmployeeIdNo.Translatable = false
        Me.cboEmployeeIdNo.ValueIsMandatory = false
        Me.cboEmployeeIdNo.ValueIsNullable = false
        Me.cboEmployeeIdNo.ValueIsNumeric = false
        Me.cboEmployeeIdNo.ValueMember = "IdNo"
        '
        'lblAmount
        '
        Me.lblAmount.DisplayOnly = true
        Me.lblAmount.EditingMode = false
        Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAmount.Location = New System.Drawing.Point(11, 62)
        Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(155, 23)
        Me.lblAmount.TabIndex = 276
        Me.lblAmount.Text = "Loan Amount"
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAmount.Translatable = true
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.White
        Me.txtAmount.BegFindValue = Nothing
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.ComputedValue = false
        Me.txtAmount.CustomFormat = Nothing
        Me.txtAmount.DataBoundControl = true
        Me.txtAmount.EditingMode = true
        Me.txtAmount.EndFindValue = Nothing
        Me.txtAmount.FieldDescription = Nothing
        Me.txtAmount.FieldName = Nothing
        Me.txtAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtAmount.FindEnabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.txtAmount, true)
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtAmount.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.LinkedLabel = Me.lblPeriodicPayment
        Me.txtAmount.Location = New System.Drawing.Point(168, 62)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtAmount.MaximumValue = Nothing
        Me.txtAmount.MinimumValue = Nothing
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.OldValue = Nothing
        Me.txtAmount.ReadOnly = true
        Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtAmount.Size = New System.Drawing.Size(112, 23)
        Me.txtAmount.TabIndex = 277
        Me.txtAmount.Translatable = false
        Me.txtAmount.ValueIsMandatory = true
        '
        'lblPeriodicPayment
        '
        Me.lblPeriodicPayment.DisplayOnly = true
        Me.lblPeriodicPayment.EditingMode = false
        Me.lblPeriodicPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPeriodicPayment.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPeriodicPayment.Location = New System.Drawing.Point(11, 114)
        Me.lblPeriodicPayment.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPeriodicPayment.Name = "lblPeriodicPayment"
        Me.lblPeriodicPayment.Size = New System.Drawing.Size(155, 23)
        Me.lblPeriodicPayment.TabIndex = 174
        Me.lblPeriodicPayment.Text = "Periodic Payment"
        Me.lblPeriodicPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPeriodicPayment.Translatable = true
        '
        'lblStartDate
        '
        Me.lblStartDate.DisplayOnly = true
        Me.lblStartDate.EditingMode = false
        Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblStartDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStartDate.Location = New System.Drawing.Point(11, 87)
        Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(155, 23)
        Me.lblStartDate.TabIndex = 168
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStartDate.Translatable = true
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
        Me.dtpStartDate.LinkedLabel = Me.lblStartDate
        Me.dtpStartDate.Location = New System.Drawing.Point(168, 87)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ReadOnlyDp = false
        Me.dtpStartDate.SecurityKey = Nothing
        Me.dtpStartDate.ShowLongDate = false
        Me.dtpStartDate.ShowTime = false
        Me.dtpStartDate.Size = New System.Drawing.Size(112, 25)
        Me.dtpStartDate.TabIndex = 273
        Me.dtpStartDate.TargetCalendar = CType(resources.GetObject("dtpStartDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpStartDate.Translatable = false
        Me.dtpStartDate.Value = Nothing
        Me.dtpStartDate.ValueIsMandatory = false
        Me.dtpStartDate.ValueIsNullable = false
        '
        'txtPeriodicPayment
        '
        Me.txtPeriodicPayment.BackColor = System.Drawing.Color.White
        Me.txtPeriodicPayment.BegFindValue = Nothing
        Me.txtPeriodicPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodicPayment.ComputedValue = false
        Me.txtPeriodicPayment.CustomFormat = Nothing
        Me.txtPeriodicPayment.DataBoundControl = true
        Me.txtPeriodicPayment.EditingMode = true
        Me.txtPeriodicPayment.EndFindValue = Nothing
        Me.txtPeriodicPayment.FieldDescription = Nothing
        Me.txtPeriodicPayment.FieldName = Nothing
        Me.txtPeriodicPayment.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPeriodicPayment.FindEnabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.txtPeriodicPayment, true)
        Me.txtPeriodicPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPeriodicPayment.ForeColor = System.Drawing.Color.Black
        Me.txtPeriodicPayment.LinkedLabel = Me.lblPeriodicPayment
        Me.txtPeriodicPayment.Location = New System.Drawing.Point(168, 114)
        Me.txtPeriodicPayment.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPeriodicPayment.MaximumValue = Nothing
        Me.txtPeriodicPayment.MinimumValue = Nothing
        Me.txtPeriodicPayment.Name = "txtPeriodicPayment"
        Me.txtPeriodicPayment.OldValue = Nothing
        Me.txtPeriodicPayment.ReadOnly = true
        Me.txtPeriodicPayment.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPeriodicPayment.Size = New System.Drawing.Size(112, 23)
        Me.txtPeriodicPayment.TabIndex = 173
        Me.txtPeriodicPayment.Translatable = false
        Me.txtPeriodicPayment.ValueIsMandatory = true
        '
        'lblDateCreated
        '
        Me.lblDateCreated.DisplayOnly = true
        Me.lblDateCreated.EditingMode = false
        Me.lblDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDateCreated.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDateCreated.Location = New System.Drawing.Point(11, 139)
        Me.lblDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDateCreated.Name = "lblDateCreated"
        Me.lblDateCreated.Size = New System.Drawing.Size(155, 23)
        Me.lblDateCreated.TabIndex = 274
        Me.lblDateCreated.Text = "Date Created"
        Me.lblDateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDateCreated.Translatable = true
        '
        'txtDateCreated
        '
        Me.txtDateCreated.BackColor = System.Drawing.Color.White
        Me.txtDateCreated.BegFindValue = Nothing
        Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDateCreated.ComputedValue = false
        Me.txtDateCreated.CustomFormat = Nothing
        Me.txtDateCreated.DataBoundControl = true
        Me.txtDateCreated.EditingMode = true
        Me.txtDateCreated.EndFindValue = Nothing
        Me.txtDateCreated.FieldDescription = Nothing
        Me.txtDateCreated.FieldName = Nothing
        Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDateCreated.FindEnabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.txtDateCreated, true)
        Me.txtDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.LinkedLabel = Me.lblDateCreated
        Me.txtDateCreated.Location = New System.Drawing.Point(168, 139)
        Me.txtDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDateCreated.MaximumValue = Nothing
        Me.txtDateCreated.MinimumValue = Nothing
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.ReadOnly = true
        Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDateCreated.Size = New System.Drawing.Size(112, 23)
        Me.txtDateCreated.TabIndex = 275
        Me.txtDateCreated.Translatable = false
        Me.txtDateCreated.ValueIsMandatory = true
        '
        'SalaryLoanScheduleView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "SalaryLoanScheduleView"
        Me.Size = New System.Drawing.Size(629, 197)
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)

End Sub

        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblEmployeeIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblStartDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblPeriodicPayment As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblDateCreated As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblAmount As Libraries.CBaseControlsLibrary.CLabel
        Public WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Public WithEvents cboEmployeeIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Public WithEvents txtPeriodicPayment As Libraries.CBaseControlsLibrary.CTextBox
        Public WithEvents dtpStartDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Public WithEvents txtDateCreated As Libraries.CBaseControlsLibrary.CTextBox
        Public WithEvents txtAmount As Libraries.CBaseControlsLibrary.CTextBox
    End Class
End Namespace

