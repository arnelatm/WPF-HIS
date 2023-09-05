Namespace PresentationLayer.Presenters.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ContactDateRangeForm
        Inherits AATM.PresentationLayer.Forms.BfMain

        'Form overrides dispose to clean up the component list.
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
            Me.lblContactIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboContactIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dateRange = New AATM.Libraries.CBaseControlsLibrary.DateRangeControl()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblContactIdNo
            '
            Me.lblContactIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblContactIdNo.DisplayOnly = True
            Me.lblContactIdNo.EditingMode = False
            Me.lblContactIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblContactIdNo.Location = New System.Drawing.Point(1, 96)
            Me.lblContactIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblContactIdNo.Name = "lblContactIdNo"
            Me.lblContactIdNo.Size = New System.Drawing.Size(154, 25)
            Me.lblContactIdNo.TabIndex = 29
            Me.lblContactIdNo.Text = "Company"
            Me.lblContactIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblContactIdNo.Translatable = True
            '
            'cboContactIdNo
            '
            Me.cboContactIdNo.BackColor = System.Drawing.Color.White
            Me.cboContactIdNo.BegFindValue = Nothing
            Me.cboContactIdNo.ChangingSearchValueOnly = False
            Me.cboContactIdNo.CurrentSearchTerm = ""
            Me.cboContactIdNo.DataValue = Nothing
            Me.cboContactIdNo.DefaultValue = Nothing
            Me.cboContactIdNo.DisplayMember = "Name"
            Me.cboContactIdNo.DropDownHeight = 23
            Me.cboContactIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboContactIdNo.Editable = True
            Me.cboContactIdNo.EditingMode = False
            Me.cboContactIdNo.EndFindValue = Nothing
            Me.cboContactIdNo.FieldDescription = Nothing
            Me.cboContactIdNo.FieldName = Nothing
            Me.cboContactIdNo.FilterRule = Nothing
            Me.cboContactIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboContactIdNo.FindEnabled = False
            Me.cboContactIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboContactIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboContactIdNo.FormattingEnabled = True
            Me.cboContactIdNo.HideWhenNotEditingOrAdding = False
            Me.cboContactIdNo.IgnoreCase = False
            Me.cboContactIdNo.LimitToList = False
            Me.cboContactIdNo.LinkedLabel = Nothing
            Me.cboContactIdNo.Location = New System.Drawing.Point(157, 96)
            Me.cboContactIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboContactIdNo.MaxDropDownItems = 1
            Me.cboContactIdNo.Name = "cboContactIdNo"
            Me.cboContactIdNo.OldValue = 0
            Me.cboContactIdNo.OriginalDataSource = Nothing
            Me.cboContactIdNo.OriginalList = Nothing
            Me.cboContactIdNo.OverrideDropDownStyleList = False
            Me.cboContactIdNo.PreviousSearchTerm = Nothing
            Me.cboContactIdNo.PropertySelector = Nothing
            Me.cboContactIdNo.Size = New System.Drawing.Size(419, 28)
            Me.cboContactIdNo.SuggestBoxHeight = 200
            Me.cboContactIdNo.SuggestCharCount = 0
            Me.cboContactIdNo.SuggestListOrderRule = Nothing
            Me.cboContactIdNo.TabIndex = 30
            Me.cboContactIdNo.TextToSearch = Nothing
            Me.cboContactIdNo.Translatable = False
            Me.cboContactIdNo.ValueIsMandatory = False
            Me.cboContactIdNo.ValueIsNullable = False
            Me.cboContactIdNo.ValueIsNumeric = False
            Me.cboContactIdNo.ValueMember = "IdNo"
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.dateRange)
            Me.CFlowLayout1.Controls.Add(Me.lblContactIdNo)
            Me.CFlowLayout1.Controls.Add(Me.cboContactIdNo)
            Me.CFlowLayout1.Location = New System.Drawing.Point(14, 11)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(582, 136)
            Me.CFlowLayout1.TabIndex = 31
            '
            'CLabel2
            '
            Me.CLabel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CFlowLayout1.SetFlowBreak(Me.CLabel2, True)
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.CLabel2.Location = New System.Drawing.Point(1, 1)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(581, 25)
            Me.CLabel2.TabIndex = 26
            Me.CLabel2.Text = "Date Range Selection"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.CLabel2.Translatable = True
            '
            'dateRange
            '
            Me.dateRange.BackColor = System.Drawing.Color.Transparent
            Me.dateRange.BeginningDate = Nothing
            Me.dateRange.EndingDate = Nothing
            Me.CFlowLayout1.SetFlowBreak(Me.dateRange, True)
            Me.dateRange.Location = New System.Drawing.Point(3, 30)
            Me.dateRange.Name = "dateRange"
            Me.dateRange.Size = New System.Drawing.Size(274, 62)
            Me.dateRange.TabIndex = 29
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(363, 159)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(83, 25)
            Me.btnCancel.TabIndex = 33
            Me.btnCancel.Text = "Cancel"
            '
            'btnOk
            '
            Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(148, 159)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(83, 25)
            Me.btnOk.TabIndex = 32
            Me.btnOk.Text = "Ok"
            '
            'ContactDateRangeForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(608, 196)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.DoubleBuffered = True
            Me.Name = "ContactDateRangeForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Text = "ContactDateRangeForm"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents lblContactIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboContactIdNo As Libraries.CBaseControlsLibrary.CtComboBox
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dateRange As Libraries.CBaseControlsLibrary.DateRangeControl
        Private WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Private WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
    End Class
End Namespace