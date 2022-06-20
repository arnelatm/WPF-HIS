Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PayrollReport
        Inherits AATM.PresentationLayer.Forms.BfMain

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
        Me.lblEndingDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.lblPayrollName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtEndingDate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'lblEndingDate
        '
        Me.lblEndingDate.DisplayOnly = true
        Me.lblEndingDate.EditingMode = false
        Me.lblEndingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEndingDate.Location = New System.Drawing.Point(11, 92)
        Me.lblEndingDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEndingDate.Name = "lblEndingDate"
        Me.lblEndingDate.Size = New System.Drawing.Size(171, 25)
        Me.lblEndingDate.TabIndex = 21
        Me.lblEndingDate.Text = "Ending Date:"
        Me.lblEndingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBeginningDate
        '
        Me.lblBeginningDate.DisplayOnly = true
        Me.lblBeginningDate.EditingMode = false
        Me.lblBeginningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBeginningDate.Location = New System.Drawing.Point(11, 65)
        Me.lblBeginningDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBeginningDate.Name = "lblBeginningDate"
        Me.lblBeginningDate.Size = New System.Drawing.Size(171, 25)
        Me.lblBeginningDate.TabIndex = 20
        Me.lblBeginningDate.Text = "Beginning Date :"
        Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblPayrollIdNo)
        Me.CFlowLayout1.Controls.Add(Me.txtPayrollIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblPayrollName)
        Me.CFlowLayout1.Controls.Add(Me.CTextBox1)
        Me.CFlowLayout1.Controls.Add(Me.lblBeginningDate)
        Me.CFlowLayout1.Controls.Add(Me.txtBeginningDate)
        Me.CFlowLayout1.Controls.Add(Me.lblEndingDate)
        Me.CFlowLayout1.Controls.Add(Me.txtEndingDate)
        Me.CFlowLayout1.Location = New System.Drawing.Point(12, 37)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10)
        Me.CFlowLayout1.Size = New System.Drawing.Size(702, 131)
        Me.CFlowLayout1.TabIndex = 26
        '
        'CLabel2
        '
        Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CLabel2.Location = New System.Drawing.Point(0, 0)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(725, 25)
        Me.CLabel2.TabIndex = 26
        Me.CLabel2.Text = "Payroll Report"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        '
        'btnOk
        '
        Me.btnOk.DesignerSelected = false
        Me.btnOk.DisplayOnly = true
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(249, 174)
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
        Me.btnCancel.DisplayOnly = true
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(355, 174)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(90, 25)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "Cancel"
        '
        'lblPayrollName
        '
        Me.lblPayrollName.DisplayOnly = true
        Me.lblPayrollName.EditingMode = false
        Me.lblPayrollName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayrollName.Location = New System.Drawing.Point(11, 38)
        Me.lblPayrollName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayrollName.Name = "lblPayrollName"
        Me.lblPayrollName.Size = New System.Drawing.Size(171, 25)
        Me.lblPayrollName.TabIndex = 32
        Me.lblPayrollName.Text = "Payroll Description"
        Me.lblPayrollName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPayrollIdNo
        '
        Me.lblPayrollIdNo.DisplayOnly = true
        Me.lblPayrollIdNo.EditingMode = false
        Me.lblPayrollIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayrollIdNo.Location = New System.Drawing.Point(11, 11)
        Me.lblPayrollIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayrollIdNo.Name = "lblPayrollIdNo"
        Me.lblPayrollIdNo.Size = New System.Drawing.Size(171, 25)
        Me.lblPayrollIdNo.TabIndex = 34
        Me.lblPayrollIdNo.Text = "Payroll Number"
        Me.lblPayrollIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPayrollIdNo
        '
        Me.txtPayrollIdNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtPayrollIdNo.BegFindValue = Nothing
        Me.txtPayrollIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayrollIdNo.ComputedValue = false
        Me.txtPayrollIdNo.CustomFormat = Nothing
        Me.txtPayrollIdNo.DataBoundControl = true
        Me.txtPayrollIdNo.EditingMode = true
        Me.txtPayrollIdNo.EndFindValue = Nothing
        Me.txtPayrollIdNo.FieldDescription = Nothing
        Me.txtPayrollIdNo.FieldName = Nothing
        Me.txtPayrollIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayrollIdNo.FindEnabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.txtPayrollIdNo, true)
        Me.txtPayrollIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayrollIdNo.LinkedLabel = Nothing
        Me.txtPayrollIdNo.Location = New System.Drawing.Point(184, 11)
        Me.txtPayrollIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayrollIdNo.MaximumValue = Nothing
        Me.txtPayrollIdNo.MinimumValue = Nothing
        Me.txtPayrollIdNo.Name = "txtPayrollIdNo"
        Me.txtPayrollIdNo.OldValue = Nothing
        Me.txtPayrollIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayrollIdNo.Size = New System.Drawing.Size(112, 23)
        Me.txtPayrollIdNo.TabIndex = 35
        '
        'txtEndingDate
        '
        Me.txtEndingDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtEndingDate.BegFindValue = Nothing
        Me.txtEndingDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEndingDate.ComputedValue = false
        Me.txtEndingDate.CustomFormat = Nothing
        Me.txtEndingDate.DataBoundControl = true
        Me.txtEndingDate.EditingMode = true
        Me.txtEndingDate.EndFindValue = Nothing
        Me.txtEndingDate.FieldDescription = Nothing
        Me.txtEndingDate.FieldName = Nothing
        Me.txtEndingDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtEndingDate.FindEnabled = false
        Me.txtEndingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtEndingDate.LinkedLabel = Nothing
        Me.txtEndingDate.Location = New System.Drawing.Point(184, 92)
        Me.txtEndingDate.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEndingDate.MaximumValue = Nothing
        Me.txtEndingDate.MinimumValue = Nothing
        Me.txtEndingDate.Name = "txtEndingDate"
        Me.txtEndingDate.OldValue = Nothing
        Me.txtEndingDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtEndingDate.Size = New System.Drawing.Size(112, 23)
        Me.txtEndingDate.TabIndex = 36
        '
        'txtBeginningDate
        '
        Me.txtBeginningDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtBeginningDate.BegFindValue = Nothing
        Me.txtBeginningDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBeginningDate.ComputedValue = false
        Me.txtBeginningDate.CustomFormat = Nothing
        Me.txtBeginningDate.DataBoundControl = true
        Me.txtBeginningDate.EditingMode = true
        Me.txtBeginningDate.EndFindValue = Nothing
        Me.txtBeginningDate.FieldDescription = Nothing
        Me.txtBeginningDate.FieldName = Nothing
        Me.txtBeginningDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtBeginningDate.FindEnabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.txtBeginningDate, true)
        Me.txtBeginningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtBeginningDate.LinkedLabel = Nothing
        Me.txtBeginningDate.Location = New System.Drawing.Point(184, 65)
        Me.txtBeginningDate.Margin = New System.Windows.Forms.Padding(1)
        Me.txtBeginningDate.MaximumValue = Nothing
        Me.txtBeginningDate.MinimumValue = Nothing
        Me.txtBeginningDate.Name = "txtBeginningDate"
        Me.txtBeginningDate.OldValue = Nothing
        Me.txtBeginningDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtBeginningDate.Size = New System.Drawing.Size(112, 23)
        Me.txtBeginningDate.TabIndex = 37
        '
        'CTextBox1
        '
        Me.CTextBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CTextBox1.BegFindValue = Nothing
        Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox1.ComputedValue = false
        Me.CTextBox1.CustomFormat = Nothing
        Me.CTextBox1.DataBoundControl = true
        Me.CTextBox1.EditingMode = true
        Me.CTextBox1.EndFindValue = Nothing
        Me.CTextBox1.FieldDescription = Nothing
        Me.CTextBox1.FieldName = Nothing
        Me.CTextBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.CTextBox1.FindEnabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.CTextBox1, true)
        Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CTextBox1.LinkedLabel = Nothing
        Me.CTextBox1.Location = New System.Drawing.Point(184, 38)
        Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox1.MaximumValue = Nothing
        Me.CTextBox1.MinimumValue = Nothing
        Me.CTextBox1.Name = "CTextBox1"
        Me.CTextBox1.OldValue = Nothing
        Me.CTextBox1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.CTextBox1.Size = New System.Drawing.Size(506, 23)
        Me.CTextBox1.TabIndex = 38
        '
        'PayrollReport
        '
        Me.ClientSize = New System.Drawing.Size(726, 208)
        Me.Controls.Add(Me.CLabel2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Controls.Add(Me.CLabel1)
        Me.Name = "PayrollReport"
        Me.Text = "Payroll Report"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)

End Sub
        Friend WithEvents lblEndingDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblBeginningDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents lblPayrollIdNo As CLabel
        Friend WithEvents txtPayrollIdNo As CTextBox
        Friend WithEvents lblPayrollName As CLabel
        Friend WithEvents txtBeginningDate As CTextBox
        Friend WithEvents txtEndingDate As CTextBox
        Friend WithEvents CTextBox1 As CTextBox
    End Class
End NameSpace