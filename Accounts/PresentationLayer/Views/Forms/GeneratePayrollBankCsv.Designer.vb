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
            Me.cboPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CComboBox()
            Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
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
            Me.lblPayrollName.Size = New System.Drawing.Size(146, 23)
            Me.lblPayrollName.TabIndex = 1
            Me.lblPayrollName.Text = "Payroll Name"
            Me.lblPayrollName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPayrollName.Translatable = True
            '
            'cboPayrollIdNo
            '
            Me.cboPayrollIdNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.cboPayrollIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayrollIdNo.DefaultValue = Nothing
            Me.cboPayrollIdNo.DisplayOnly = False
            Me.cboPayrollIdNo.EditingMode = True
            Me.cboPayrollIdNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.CFlowLayout1.SetFlowBreak(Me.cboPayrollIdNo, True)
            Me.cboPayrollIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayrollIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayrollIdNo.FormattingEnabled = True
            Me.cboPayrollIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayrollIdNo.LinkedLabel = Nothing
            Me.cboPayrollIdNo.Location = New System.Drawing.Point(149, 1)
            Me.cboPayrollIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPayrollIdNo.MaximumValue = Nothing
            Me.cboPayrollIdNo.MinimumValue = Nothing
            Me.cboPayrollIdNo.Name = "cboPayrollIdNo"
            Me.cboPayrollIdNo.OldValue = 0
            Me.cboPayrollIdNo.OriginalDataSource = Nothing
            Me.cboPayrollIdNo.OriginalDropDownStyle = 1
            Me.cboPayrollIdNo.OriginalList = Nothing
            Me.cboPayrollIdNo.ReadOnlyCombo = False
            Me.cboPayrollIdNo.Size = New System.Drawing.Size(332, 24)
            Me.cboPayrollIdNo.TabIndex = 2
            Me.cboPayrollIdNo.Translatable = False
            Me.cboPayrollIdNo.ValueIsMandatory = False
            Me.cboPayrollIdNo.ValueIsNullable = False
            Me.cboPayrollIdNo.ValueIsNumeric = False
            '
            'lblStartDate
            '
            Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
            Me.lblStartDate.DisplayOnly = True
            Me.lblStartDate.EditingMode = False
            Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblStartDate.Location = New System.Drawing.Point(1, 27)
            Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(146, 24)
            Me.lblStartDate.TabIndex = 3
            Me.lblStartDate.Text = "Start Date"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblStartDate.Translatable = True
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblPayrollName)
            Me.CFlowLayout1.Controls.Add(Me.cboPayrollIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblStartDate)
            Me.CFlowLayout1.Controls.Add(Me.txtStartDate)
            Me.CFlowLayout1.Controls.Add(Me.lblEndDate)
            Me.CFlowLayout1.Controls.Add(Me.txtEndDate)
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 57)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(502, 92)
            Me.CFlowLayout1.TabIndex = 4
            '
            'txtStartDate
            '
            Me.txtStartDate.BackColor = System.Drawing.Color.White
            Me.txtStartDate.BegFindValue = Nothing
            Me.txtStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtStartDate.ComputedValue = False
            Me.txtStartDate.CustomFormat = Nothing
            Me.txtStartDate.DataBoundControl = True
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
            Me.txtStartDate.Location = New System.Drawing.Point(149, 27)
            Me.txtStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.txtStartDate.MaximumValue = Nothing
            Me.txtStartDate.MinimumValue = Nothing
            Me.txtStartDate.Name = "txtStartDate"
            Me.txtStartDate.OldValue = Nothing
            Me.txtStartDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtStartDate.Size = New System.Drawing.Size(100, 23)
            Me.txtStartDate.TabIndex = 6
            Me.txtStartDate.Translatable = False
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.DisplayOnly = True
            Me.lblEndDate.EditingMode = False
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEndDate.Location = New System.Drawing.Point(1, 53)
            Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Size = New System.Drawing.Size(146, 24)
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
            Me.txtEndDate.Location = New System.Drawing.Point(149, 53)
            Me.txtEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEndDate.MaximumValue = Nothing
            Me.txtEndDate.MinimumValue = Nothing
            Me.txtEndDate.Name = "txtEndDate"
            Me.txtEndDate.OldValue = Nothing
            Me.txtEndDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtEndDate.Size = New System.Drawing.Size(100, 23)
            Me.txtEndDate.TabIndex = 7
            Me.txtEndDate.Translatable = False
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.DisplayOnly = True
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(160, 155)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(90, 25)
            Me.btnOk.TabIndex = 8
            Me.btnOk.Text = "Ok"
            '
            'btnCancel
            '
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.DisplayOnly = True
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(256, 155)
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
            Me.ClientSize = New System.Drawing.Size(517, 192)
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
        Friend WithEvents cboPayrollIdNo As Libraries.CBaseControlsLibrary.CComboBox
        Friend WithEvents lblStartDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblEndDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents txtStartDate As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtEndDate As Libraries.CBaseControlsLibrary.CTextBox
    End Class
End NameSpace