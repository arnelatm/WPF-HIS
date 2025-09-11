Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PayrollPrinting
        Inherits AATM.Presentation.Forms.BfMain

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
            Me.lblSupplierCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayroll = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblSupplierCode
            '
            Me.lblSupplierCode.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplierCode.DisplayOnly = True
            Me.lblSupplierCode.EditingMode = False
            Me.lblSupplierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierCode.Location = New System.Drawing.Point(1, 28)
            Me.lblSupplierCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierCode.Name = "lblSupplierCode"
            Me.lblSupplierCode.Size = New System.Drawing.Size(150, 24)
            Me.lblSupplierCode.TabIndex = 22
            Me.lblSupplierCode.Text = "Payroll Number"
            Me.lblSupplierCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSupplierCode.Translatable = True
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.lblSupplierCode)
            Me.CFlowLayout1.Controls.Add(Me.cboPayroll)
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 12)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(693, 81)
            Me.CFlowLayout1.TabIndex = 26
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.CLabel2.Location = New System.Drawing.Point(1, 1)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(682, 25)
            Me.CLabel2.TabIndex = 26
            Me.CLabel2.Text = "Inventory Report by Warehouse"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.CLabel2.Translatable = True
            '
            'cboPayroll
            '
            Me.cboPayroll.BackColor = System.Drawing.Color.White
            Me.cboPayroll.BegFindValue = Nothing
            Me.cboPayroll.ChangingSearchValueOnly = False
            Me.cboPayroll.CurrentSearchTerm = ""
            Me.cboPayroll.DataValue = Nothing
            Me.cboPayroll.DefaultValue = Nothing
            Me.cboPayroll.DisplayMember = "Name"
            Me.cboPayroll.DropDownHeight = 24
            Me.cboPayroll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboPayroll.Editable = True
            Me.cboPayroll.EditingMode = False
            Me.cboPayroll.EndFindValue = Nothing
            Me.cboPayroll.FieldDescription = Nothing
            Me.cboPayroll.FieldName = Nothing
            Me.cboPayroll.FilterRule = Nothing
            Me.cboPayroll.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPayroll.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.cboPayroll, True)
            Me.cboPayroll.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayroll.ForeColor = System.Drawing.Color.Black
            Me.cboPayroll.FormattingEnabled = True
            Me.cboPayroll.HideWhenNotEditingOrAdding = False
            Me.cboPayroll.IgnoreCase = False
            Me.cboPayroll.IntegralHeight = False
            Me.cboPayroll.LimitToList = False
            Me.cboPayroll.LinkedLabel = Nothing
            Me.cboPayroll.Location = New System.Drawing.Point(153, 28)
            Me.cboPayroll.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPayroll.MaxDropDownItems = 1
            Me.cboPayroll.Name = "cboPayroll"
            Me.cboPayroll.OldValue = 0
            Me.cboPayroll.OriginalDataSource = Nothing
            Me.cboPayroll.OriginalList = Nothing
            Me.cboPayroll.OverrideDropDownStyleList = False
            Me.cboPayroll.PreviousSearchTerm = Nothing
            Me.cboPayroll.PropertySelector = Nothing
            Me.cboPayroll.Size = New System.Drawing.Size(530, 24)
            Me.cboPayroll.SuggestBoxHeight = 200
            Me.cboPayroll.SuggestCharCount = 0
            Me.cboPayroll.SuggestListOrderRule = Nothing
            Me.cboPayroll.TabIndex = 29
            Me.cboPayroll.TextToSearch = Nothing
            Me.cboPayroll.Translatable = False
            Me.cboPayroll.ValueIsMandatory = False
            Me.cboPayroll.ValueIsNullable = False
            Me.cboPayroll.ValueIsNumeric = False
            Me.cboPayroll.ValueMember = "IdNo"
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
            Me.btnOk.DesignerSelected = True
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(235, 108)
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
            Me.btnCancel.Location = New System.Drawing.Point(357, 108)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'PayrollPrinting
            '
            Me.ClientSize = New System.Drawing.Size(716, 146)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.CLabel1)
            Me.DoubleBuffered = True
            Me.Name = "PayrollPrinting"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Text = "Inventory Report"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents lblSupplierCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents cboPayroll As CtComboBox
    End Class
End Namespace