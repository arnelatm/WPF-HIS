Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class GeneratePayrollBankCsv
        Inherits AATM.PresentationLayer.Forms.CFormEntryNew

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
            Me.lblPayrollName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.cboIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPayFrequency = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPayrollCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayrollCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtStartDate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEndDate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
            Me.lblPayrollName.Size = New System.Drawing.Size(118, 23)
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
            Me.lblStartDate.Location = New System.Drawing.Point(1, 80)
            Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(118, 24)
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
            Me.CFlowLayout1.Controls.Add(Me.txtStartDate)
            Me.CFlowLayout1.Controls.Add(Me.lblEndDate)
            Me.CFlowLayout1.Controls.Add(Me.txtEndDate)
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 57)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(502, 141)
            Me.CFlowLayout1.TabIndex = 4
            '
            'cboIdNo
            '
            Me.cboIdNo.BackColor = System.Drawing.Color.White
            Me.cboIdNo.BegFindValue = Nothing
            Me.cboIdNo.ChangingSearchValueOnly = False
            Me.cboIdNo.CurrentSearchTerm = ""
            Me.cboIdNo.DefaultValue = Nothing
            Me.cboIdNo.DisplayMember = "Name"
            Me.cboIdNo.EditingMode = True
            Me.cboIdNo.EndFindValue = Nothing
            Me.cboIdNo.FieldDescription = Nothing
            Me.cboIdNo.FieldName = Nothing
            Me.cboIdNo.FilterRule = Nothing
            Me.cboIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboIdNo.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.cboIdNo, True)
            Me.cboIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboIdNo.FormattingEnabled = True
            Me.cboIdNo.HideWhenNotEditingOrAdding = False
            Me.cboIdNo.IgnoreCase = False
            Me.cboIdNo.IntegralHeight = False
            Me.cboIdNo.LinkedLabel = Nothing
            Me.cboIdNo.Location = New System.Drawing.Point(121, 1)
            Me.cboIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboIdNo.Name = "cboIdNo"
            Me.cboIdNo.OldValue = 0
            Me.cboIdNo.OriginalDataSource = Nothing
            Me.cboIdNo.OriginalList = Nothing
            Me.cboIdNo.OverrideDropDownStyleList = False
            Me.cboIdNo.PreviousSearchTerm = Nothing
            Me.cboIdNo.PropertySelector = Nothing
            Me.cboIdNo.ReadOnlyCombo = False
            Me.cboIdNo.Size = New System.Drawing.Size(362, 24)
            Me.cboIdNo.SuggestBoxHeight = 200
            Me.cboIdNo.SuggestListOrderRule = Nothing
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
            Me.lblPayFrequency.Location = New System.Drawing.Point(1, 27)
            Me.lblPayFrequency.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayFrequency.Name = "lblPayFrequency"
            Me.lblPayFrequency.Size = New System.Drawing.Size(118, 24)
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
            Me.cboPayCycleIdNo.DefaultValue = Nothing
            Me.cboPayCycleIdNo.DisplayMember = "Name"
            Me.cboPayCycleIdNo.DisplayOnly = True
            Me.cboPayCycleIdNo.DropDownHeight = 21
            Me.cboPayCycleIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboPayCycleIdNo.EditingMode = True
            Me.cboPayCycleIdNo.EndFindValue = Nothing
            Me.cboPayCycleIdNo.FieldDescription = Nothing
            Me.cboPayCycleIdNo.FieldName = Nothing
            Me.cboPayCycleIdNo.FilterRule = Nothing
            Me.cboPayCycleIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPayCycleIdNo.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.cboPayCycleIdNo, True)
            Me.cboPayCycleIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayCycleIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayCycleIdNo.FormattingEnabled = True
            Me.cboPayCycleIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayCycleIdNo.IgnoreCase = False
            Me.cboPayCycleIdNo.IntegralHeight = False
            Me.cboPayCycleIdNo.LinkedLabel = Nothing
            Me.cboPayCycleIdNo.Location = New System.Drawing.Point(121, 27)
            Me.cboPayCycleIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPayCycleIdNo.MaxDropDownItems = 1
            Me.cboPayCycleIdNo.Name = "cboPayCycleIdNo"
            Me.cboPayCycleIdNo.OldValue = 0
            Me.cboPayCycleIdNo.OriginalDataSource = Nothing
            Me.cboPayCycleIdNo.OriginalList = Nothing
            Me.cboPayCycleIdNo.OverrideDropDownStyleList = False
            Me.cboPayCycleIdNo.PreviousSearchTerm = Nothing
            Me.cboPayCycleIdNo.PropertySelector = Nothing
            Me.cboPayCycleIdNo.ReadOnlyCombo = True
            Me.cboPayCycleIdNo.Size = New System.Drawing.Size(362, 25)
            Me.cboPayCycleIdNo.SuggestBoxHeight = 200
            Me.cboPayCycleIdNo.SuggestListOrderRule = Nothing
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
            Me.lblPayrollCode.Location = New System.Drawing.Point(1, 54)
            Me.lblPayrollCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayrollCode.Name = "lblPayrollCode"
            Me.lblPayrollCode.Size = New System.Drawing.Size(118, 24)
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
            Me.txtPayrollCode.Location = New System.Drawing.Point(121, 54)
            Me.txtPayrollCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayrollCode.MaximumValue = Nothing
            Me.txtPayrollCode.MinimumValue = Nothing
            Me.txtPayrollCode.Name = "txtPayrollCode"
            Me.txtPayrollCode.OldValue = Nothing
            Me.txtPayrollCode.ReadOnly = True
            Me.txtPayrollCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayrollCode.Size = New System.Drawing.Size(100, 23)
            Me.txtPayrollCode.TabIndex = 2
            Me.txtPayrollCode.Translatable = False
            '
            'txtStartDate
            '
            Me.txtStartDate.BackColor = System.Drawing.Color.White
            Me.txtStartDate.BegFindValue = Nothing
            Me.txtStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtStartDate.ComputedValue = False
            Me.txtStartDate.CustomFormat = Nothing
            Me.txtStartDate.DataBoundControl = True
            Me.txtStartDate.DisplayOnly = True
            Me.txtStartDate.EditingMode = True
            Me.txtStartDate.EndFindValue = Nothing
            Me.txtStartDate.FieldDescription = Nothing
            Me.txtStartDate.FieldName = Nothing
            Me.txtStartDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtStartDate.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.txtStartDate, True)
            Me.txtStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtStartDate.ForeColor = System.Drawing.Color.Black
            Me.txtStartDate.LinkedLabel = Nothing
            Me.txtStartDate.Location = New System.Drawing.Point(121, 80)
            Me.txtStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.txtStartDate.MaximumValue = Nothing
            Me.txtStartDate.MinimumValue = Nothing
            Me.txtStartDate.Name = "txtStartDate"
            Me.txtStartDate.OldValue = Nothing
            Me.txtStartDate.ReadOnly = True
            Me.txtStartDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtStartDate.Size = New System.Drawing.Size(100, 23)
            Me.txtStartDate.TabIndex = 3
            Me.txtStartDate.Translatable = False
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.DisplayOnly = True
            Me.lblEndDate.EditingMode = False
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEndDate.Location = New System.Drawing.Point(1, 106)
            Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Size = New System.Drawing.Size(118, 24)
            Me.lblEndDate.TabIndex = 5
            Me.lblEndDate.Text = "End Date"
            Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEndDate.Translatable = True
            '
            'txtEndDate
            '
            Me.txtEndDate.BackColor = System.Drawing.Color.White
            Me.txtEndDate.BegFindValue = Nothing
            Me.txtEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEndDate.ComputedValue = False
            Me.txtEndDate.CustomFormat = Nothing
            Me.txtEndDate.DataBoundControl = True
            Me.txtEndDate.DisplayOnly = True
            Me.txtEndDate.EditingMode = True
            Me.txtEndDate.EndFindValue = Nothing
            Me.txtEndDate.FieldDescription = Nothing
            Me.txtEndDate.FieldName = Nothing
            Me.txtEndDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtEndDate.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.txtEndDate, True)
            Me.txtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEndDate.ForeColor = System.Drawing.Color.Black
            Me.txtEndDate.LinkedLabel = Nothing
            Me.txtEndDate.Location = New System.Drawing.Point(121, 106)
            Me.txtEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEndDate.MaximumValue = Nothing
            Me.txtEndDate.MinimumValue = Nothing
            Me.txtEndDate.Name = "txtEndDate"
            Me.txtEndDate.OldValue = Nothing
            Me.txtEndDate.ReadOnly = True
            Me.txtEndDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtEndDate.Size = New System.Drawing.Size(100, 23)
            Me.txtEndDate.TabIndex = 4
            Me.txtEndDate.Translatable = False
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.DisplayOnly = True
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
            Me.btnCancel.DesignerSelected = True
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.DisplayOnly = True
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(243, 204)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 25)
            Me.btnCancel.TabIndex = 9
            Me.btnCancel.Text = "Cancel"
            '
            'GeneratePayrollBankCsv
            '
            Me.AcceptButton = Me.btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
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
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lblPayrollName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblStartDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblEndDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents txtStartDate As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtEndDate As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPayFrequency As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblPayrollCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPayrollCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents cboIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents cboPayCycleIdNo As Libraries.CBaseControlsLibrary.CaComboBox
    End Class
End NameSpace