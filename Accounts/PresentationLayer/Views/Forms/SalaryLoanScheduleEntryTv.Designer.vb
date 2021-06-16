Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SalaryLoanScheduleEntryTv
        Inherits AATM.PresentationLayer.Forms.CFormEntryTvNew

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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalaryLoanScheduleEntryTv))
            Me.floFields = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
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
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floFields.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.floFields)
            Me.SplitContainer1.Size = New System.Drawing.Size(908, 191)
            Me.SplitContainer1.SplitterDistance = 301
            '
            'floFields
            '
            Me.floFields.BackColor = System.Drawing.Color.Transparent
            Me.floFields.Controls.Add(Me.lblIdNo)
            Me.floFields.Controls.Add(Me.TxtIdNo)
            Me.floFields.Controls.Add(Me.lblEmployeeIdNo)
            Me.floFields.Controls.Add(Me.cboEmployeeIdNo)
            Me.floFields.Controls.Add(Me.lblAmount)
            Me.floFields.Controls.Add(Me.txtAmount)
            Me.floFields.Controls.Add(Me.lblStartDate)
            Me.floFields.Controls.Add(Me.dtpStartDate)
            Me.floFields.Controls.Add(Me.lblPeriodicPayment)
            Me.floFields.Controls.Add(Me.txtPeriodicPayment)
            Me.floFields.Controls.Add(Me.lblDateCreated)
            Me.floFields.Controls.Add(Me.txtDateCreated)
            Me.floFields.Dock = System.Windows.Forms.DockStyle.Fill
            Me.floFields.Location = New System.Drawing.Point(0, 0)
            Me.floFields.Margin = New System.Windows.Forms.Padding(10)
            Me.floFields.Name = "floFields"
            Me.floFields.Padding = New System.Windows.Forms.Padding(5, 20, 20, 20)
            Me.floFields.Size = New System.Drawing.Size(603, 191)
            Me.floFields.TabIndex = 0
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(6, 21)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(155, 23)
            Me.lblIdNo.TabIndex = 279
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
            Me.floFields.SetFlowBreak(Me.TxtIdNo, True)
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.Location = New System.Drawing.Point(163, 21)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 278
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
            Me.lblEmployeeIdNo.Location = New System.Drawing.Point(6, 46)
            Me.lblEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEmployeeIdNo.Name = "lblEmployeeIdNo"
            Me.lblEmployeeIdNo.Size = New System.Drawing.Size(155, 23)
            Me.lblEmployeeIdNo.TabIndex = 280
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
            Me.cboEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboEmployeeIdNo.FormattingEnabled = True
            Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboEmployeeIdNo.IgnoreCase = False
            Me.cboEmployeeIdNo.IntegralHeight = False
            Me.cboEmployeeIdNo.LinkedLabel = Me.lblEmployeeIdNo
            Me.cboEmployeeIdNo.Location = New System.Drawing.Point(163, 46)
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
            Me.cboEmployeeIdNo.TabIndex = 284
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
            Me.lblAmount.Location = New System.Drawing.Point(6, 72)
            Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(155, 23)
            Me.lblAmount.TabIndex = 288
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
            Me.floFields.SetFlowBreak(Me.txtAmount, True)
            Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Me.lblAmount
            Me.txtAmount.Location = New System.Drawing.Point(163, 72)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAmount.Size = New System.Drawing.Size(112, 23)
            Me.txtAmount.TabIndex = 289
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
            Me.lblStartDate.Location = New System.Drawing.Point(6, 97)
            Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(155, 23)
            Me.lblStartDate.TabIndex = 281
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
            Me.floFields.SetFlowBreak(Me.dtpStartDate, True)
            Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
            Me.dtpStartDate.LinkedLabel = Me.lblStartDate
            Me.dtpStartDate.Location = New System.Drawing.Point(163, 97)
            Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.ReadOnlyDp = False
            Me.dtpStartDate.SecurityKey = Nothing
            Me.dtpStartDate.ShowLongDate = False
            Me.dtpStartDate.ShowTime = False
            Me.dtpStartDate.Size = New System.Drawing.Size(112, 25)
            Me.dtpStartDate.TabIndex = 285
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
            Me.lblPeriodicPayment.Location = New System.Drawing.Point(6, 124)
            Me.lblPeriodicPayment.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPeriodicPayment.Name = "lblPeriodicPayment"
            Me.lblPeriodicPayment.Size = New System.Drawing.Size(155, 23)
            Me.lblPeriodicPayment.TabIndex = 283
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
            Me.floFields.SetFlowBreak(Me.txtPeriodicPayment, True)
            Me.txtPeriodicPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPeriodicPayment.ForeColor = System.Drawing.Color.Black
            Me.txtPeriodicPayment.LinkedLabel = Me.lblPeriodicPayment
            Me.txtPeriodicPayment.Location = New System.Drawing.Point(163, 124)
            Me.txtPeriodicPayment.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPeriodicPayment.MaximumValue = Nothing
            Me.txtPeriodicPayment.MinimumValue = Nothing
            Me.txtPeriodicPayment.Name = "txtPeriodicPayment"
            Me.txtPeriodicPayment.OldValue = Nothing
            Me.txtPeriodicPayment.ReadOnly = True
            Me.txtPeriodicPayment.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPeriodicPayment.Size = New System.Drawing.Size(112, 23)
            Me.txtPeriodicPayment.TabIndex = 282
            Me.txtPeriodicPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtPeriodicPayment.Translatable = False
            Me.txtPeriodicPayment.ValueIsMandatory = True
            Me.txtPeriodicPayment.ValueIsNumeric = True
            '
            'lblDateCreated
            '
            Me.lblDateCreated.DisplayOnly = True
            Me.lblDateCreated.EditingMode = False
            Me.lblDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDateCreated.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDateCreated.Location = New System.Drawing.Point(6, 149)
            Me.lblDateCreated.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDateCreated.Name = "lblDateCreated"
            Me.lblDateCreated.Size = New System.Drawing.Size(155, 23)
            Me.lblDateCreated.TabIndex = 286
            Me.lblDateCreated.Text = "Date Created"
            Me.lblDateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDateCreated.Translatable = True
            '
            'txtDateCreated
            '
            Me.txtDateCreated.BackColor = System.Drawing.Color.White
            Me.txtDateCreated.BegFindValue = Nothing
            Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDateCreated.ComputedValue = False
            Me.txtDateCreated.CustomFormat = Nothing
            Me.txtDateCreated.DataBoundControl = True
            Me.txtDateCreated.EditingMode = True
            Me.txtDateCreated.EndFindValue = Nothing
            Me.txtDateCreated.FieldDescription = Nothing
            Me.txtDateCreated.FieldName = Nothing
            Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDateCreated.FindEnabled = False
            Me.txtDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Me.lblDateCreated
            Me.txtDateCreated.Location = New System.Drawing.Point(163, 149)
            Me.txtDateCreated.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDateCreated.Size = New System.Drawing.Size(112, 23)
            Me.txtDateCreated.TabIndex = 287
            Me.txtDateCreated.Translatable = False
            Me.txtDateCreated.ValueIsMandatory = True
            '
            'SalaryLoanScheduleEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(908, 244)
            Me.Name = "SalaryLoanScheduleEntryTv"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floFields.ResumeLayout(False)
            Me.floFields.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents floFields As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Public WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblEmployeeIdNo As Libraries.CBaseControlsLibrary.CLabel
        Public WithEvents cboEmployeeIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblAmount As Libraries.CBaseControlsLibrary.CLabel
        Public WithEvents txtAmount As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblStartDate As Libraries.CBaseControlsLibrary.CLabel
        Public WithEvents dtpStartDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblPeriodicPayment As Libraries.CBaseControlsLibrary.CLabel
        Public WithEvents txtPeriodicPayment As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblDateCreated As Libraries.CBaseControlsLibrary.CLabel
        Public WithEvents txtDateCreated As Libraries.CBaseControlsLibrary.CTextBox
    End Class
End NameSpace