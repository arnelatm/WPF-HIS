<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GTinScanner
    Inherits AATM.Libraries.CBaseControlsLibrary.CForm

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
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtQrCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.SuspendLayout()
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = True
        Me.CLabel1.BackColor = System.Drawing.Color.Transparent
        Me.CLabel1.DisplayOnly = True
        Me.CLabel1.EditingMode = False
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel1.Location = New System.Drawing.Point(13, 13)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(102, 17)
        Me.CLabel1.TabIndex = 0
        Me.CLabel1.Text = "Scan QR Code"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = True
        '
        'txtQrCode
        '
        Me.txtQrCode.BackColor = System.Drawing.Color.White
        Me.txtQrCode.BegFindValue = Nothing
        Me.txtQrCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQrCode.ComputedValue = False
        Me.txtQrCode.CustomFormat = Nothing
        Me.txtQrCode.DataBoundControl = True
        Me.txtQrCode.EditingMode = True
        Me.txtQrCode.EndFindValue = Nothing
        Me.txtQrCode.FieldDescription = Nothing
        Me.txtQrCode.FieldName = Nothing
        Me.txtQrCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtQrCode.FindEnabled = False
        Me.txtQrCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtQrCode.ForeColor = System.Drawing.Color.Black
        Me.txtQrCode.LinkedLabel = Nothing
        Me.txtQrCode.Location = New System.Drawing.Point(16, 35)
        Me.txtQrCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtQrCode.MaximumValue = Nothing
        Me.txtQrCode.MinimumValue = Nothing
        Me.txtQrCode.Name = "txtQrCode"
        Me.txtQrCode.OldValue = Nothing
        Me.txtQrCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtQrCode.Size = New System.Drawing.Size(417, 23)
        Me.txtQrCode.TabIndex = 1
        Me.txtQrCode.Translatable = False
        '
        'btnCancel
        '
        Me.btnCancel.DesignerSelected = False
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(107, 63)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(90, 25)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.DesignerSelected = False
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(233, 63)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.OriginalImageName = Nothing
        Me.btnOk.SecurityKey = ""
        Me.btnOk.Size = New System.Drawing.Size(90, 25)
        Me.btnOk.TabIndex = 3
        Me.btnOk.Text = "Ok"
        '
        'GTinScanner
        '
        Me.AcceptButton = Me.btnOk
        Me.ClientSize = New System.Drawing.Size(438, 97)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtQrCode)
        Me.Controls.Add(Me.CLabel1)
        Me.Name = "GTinScanner"
        Me.Text = "GTIN Scanner"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents txtQrCode As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
End Class
