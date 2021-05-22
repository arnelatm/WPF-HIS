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
            Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblPeriodicPayment = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPeriodicPayment = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
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
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(155, 23)
            Me.lblIdNo.TabIndex = 163
            Me.lblIdNo.Text = "ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.TxtIdNo, True)
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.Location = New System.Drawing.Point(168, 11)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 159
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblEmployeeIdNo
            '
            Me.lblEmployeeIdNo.DisplayOnly = True
            Me.lblEmployeeIdNo.EditingMode = False
            Me.lblEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEmployeeIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblEmployeeIdNo.Location = New System.Drawing.Point(11, 36)
            Me.lblEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEmployeeIdNo.Name = "lblEmployeeIdNo"
            Me.lblEmployeeIdNo.Size = New System.Drawing.Size(155, 23)
            Me.lblEmployeeIdNo.TabIndex = 165
            Me.lblEmployeeIdNo.Text = "Name"
            Me.lblEmployeeIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEmployeeIdNo.Translatable = True
            '
            'cboEmployeeIdNo
            '
            Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
            Me.cboEmployeeIdNo.BegFindValue = Nothing
            Me.cboEmployeeIdNo.ChangingSearchValueOnly = False
            Me.cboEmployeeIdNo.CurrentSearchTerm = ""
            Me.cboEmployeeIdNo.DefaultValue = Nothing
            Me.cboEmployeeIdNo.DisplayMember = "Name"
            Me.cboEmployeeIdNo.EditingMode = True
            Me.cboEmployeeIdNo.EndFindValue = Nothing
            Me.cboEmployeeIdNo.FieldDescription = Nothing
            Me.cboEmployeeIdNo.FieldName = Nothing
            Me.cboEmployeeIdNo.FilterRule = Nothing
            Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboEmployeeIdNo.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.cboEmployeeIdNo, True)
            Me.cboEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboEmployeeIdNo.FormattingEnabled = True
            Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboEmployeeIdNo.IgnoreCase = False
            Me.cboEmployeeIdNo.IntegralHeight = False
            Me.cboEmployeeIdNo.LinkedLabel = Me.lblEmployeeIdNo
            Me.cboEmployeeIdNo.Location = New System.Drawing.Point(168, 36)
            Me.cboEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
            Me.cboEmployeeIdNo.OldValue = 0
            Me.cboEmployeeIdNo.OriginalDataSource = Nothing
            Me.cboEmployeeIdNo.OriginalList = Nothing
            Me.cboEmployeeIdNo.OverrideDropDownStyleList = False
            Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
            Me.cboEmployeeIdNo.PropertySelector = Nothing
            Me.cboEmployeeIdNo.ReadOnlyCombo = False
            Me.cboEmployeeIdNo.Size = New System.Drawing.Size(418, 24)
            Me.cboEmployeeIdNo.SuggestBoxHeight = 200
            Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
            Me.cboEmployeeIdNo.TabIndex = 272
            Me.cboEmployeeIdNo.TextToSearch = Nothing
            Me.cboEmployeeIdNo.Translatable = False
            Me.cboEmployeeIdNo.ValueIsMandatory = False
            Me.cboEmployeeIdNo.ValueIsNullable = False
            Me.cboEmployeeIdNo.ValueIsNumeric = False
            Me.cboEmployeeIdNo.ValueMember = "IdNo"
            '
            'lblAmount
            '
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAmount.Location = New System.Drawing.Point(11, 62)
            Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(155, 23)
            Me.lblAmount.TabIndex = 276
            Me.lblAmount.Text = "Loan Amount"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblAmount.Translatable = True
            '
            'txtAmount
            '
            Me.txtAmount.BackColor = System.Drawing.Color.White
            Me.txtAmount.BegFindValue = Nothing
            Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = Nothing
            Me.txtAmount.DataBoundControl = True
            Me.txtAmount.EditingMode = True
            Me.txtAmount.EndFindValue = Nothing
            Me.txtAmount.FieldDescription = Nothing
            Me.txtAmount.FieldName = Nothing
            Me.txtAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAmount.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.txtAmount, True)
            Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Me.lblAmount
            Me.txtAmount.Location = New System.Drawing.Point(168, 62)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAmount.Size = New System.Drawing.Size(112, 23)
            Me.txtAmount.TabIndex = 277
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAmount.Translatable = False
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'lblStartDate
            '
            Me.lblStartDate.DisplayOnly = True
            Me.lblStartDate.EditingMode = False
            Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblStartDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblStartDate.Location = New System.Drawing.Point(11, 87)
            Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(155, 23)
            Me.lblStartDate.TabIndex = 168
            Me.lblStartDate.Text = "Start Date"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblStartDate.Translatable = True
            '
            'dtpStartDate
            '
            Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpStartDate.DefaultValue = Nothing
            Me.dtpStartDate.DisplayOnly = False
            Me.dtpStartDate.DtpDefaultValue = Nothing
            Me.dtpStartDate.EditingMode = True
            Me.dtpStartDate.EditsAllowed = False
            Me.CFlowLayout1.SetFlowBreak(Me.dtpStartDate, True)
            Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
            Me.dtpStartDate.LinkedLabel = Me.lblStartDate
            Me.dtpStartDate.Location = New System.Drawing.Point(168, 87)
            Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.ReadOnlyDp = False
            Me.dtpStartDate.SecurityKey = Nothing
            Me.dtpStartDate.ShowLongDate = False
            Me.dtpStartDate.ShowTime = False
            Me.dtpStartDate.Size = New System.Drawing.Size(112, 25)
            Me.dtpStartDate.TabIndex = 273
            Me.dtpStartDate.TargetCalendar = CType(resources.GetObject("dtpStartDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpStartDate.Translatable = False
            Me.dtpStartDate.Value = Nothing
            Me.dtpStartDate.ValueIsMandatory = False
            Me.dtpStartDate.ValueIsNullable = False
            '
            'lblPeriodicPayment
            '
            Me.lblPeriodicPayment.DisplayOnly = True
            Me.lblPeriodicPayment.EditingMode = False
            Me.lblPeriodicPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPeriodicPayment.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPeriodicPayment.Location = New System.Drawing.Point(11, 114)
            Me.lblPeriodicPayment.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPeriodicPayment.Name = "lblPeriodicPayment"
            Me.lblPeriodicPayment.Size = New System.Drawing.Size(155, 23)
            Me.lblPeriodicPayment.TabIndex = 174
            Me.lblPeriodicPayment.Text = "Periodic Payment"
            Me.lblPeriodicPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPeriodicPayment.Translatable = True
            '
            'txtPeriodicPayment
            '
            Me.txtPeriodicPayment.BackColor = System.Drawing.Color.White
            Me.txtPeriodicPayment.BegFindValue = Nothing
            Me.txtPeriodicPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPeriodicPayment.ComputedValue = False
            Me.txtPeriodicPayment.CustomFormat = Nothing
            Me.txtPeriodicPayment.DataBoundControl = True
            Me.txtPeriodicPayment.EditingMode = True
            Me.txtPeriodicPayment.EndFindValue = Nothing
            Me.txtPeriodicPayment.FieldDescription = Nothing
            Me.txtPeriodicPayment.FieldName = Nothing
            Me.txtPeriodicPayment.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPeriodicPayment.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.txtPeriodicPayment, True)
            Me.txtPeriodicPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPeriodicPayment.ForeColor = System.Drawing.Color.Black
            Me.txtPeriodicPayment.LinkedLabel = Me.lblPeriodicPayment
            Me.txtPeriodicPayment.Location = New System.Drawing.Point(168, 114)
            Me.txtPeriodicPayment.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPeriodicPayment.MaximumValue = Nothing
            Me.txtPeriodicPayment.MinimumValue = Nothing
            Me.txtPeriodicPayment.Name = "txtPeriodicPayment"
            Me.txtPeriodicPayment.OldValue = Nothing
            Me.txtPeriodicPayment.ReadOnly = True
            Me.txtPeriodicPayment.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPeriodicPayment.Size = New System.Drawing.Size(112, 23)
            Me.txtPeriodicPayment.TabIndex = 173
            Me.txtPeriodicPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtPeriodicPayment.Translatable = False
            Me.txtPeriodicPayment.ValueIsMandatory = True
            Me.txtPeriodicPayment.ValueIsNumeric = True
            '
            'lblDateCreated
            '
            Me.lblDateCreated.DisplayOnly = True
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

