<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PasswordGenerator
    Inherits AATM.PresentationLayer.Forms.BFMain

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
        Me.txtUserName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblUserName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPassword = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.btnGenerate = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnQuit = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'txtUserName
        '
        Me.txtUserName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUserName.BegFindValue = Nothing
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserName.ComputedValue = false
        Me.txtUserName.CustomFormat = Nothing
        Me.txtUserName.DataBoundControl = true
        Me.txtUserName.EditingMode = true
        Me.txtUserName.EndFindValue = Nothing
        Me.txtUserName.FieldDescription = Nothing
        Me.txtUserName.FieldName = Nothing
        Me.txtUserName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtUserName.FindEnabled = false
        Me.txtUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtUserName.LinkedLabel = Nothing
        Me.txtUserName.Location = New System.Drawing.Point(124, 36)
        Me.txtUserName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtUserName.MaximumValue = Nothing
        Me.txtUserName.MinimumValue = Nothing
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.OldValue = Nothing
        Me.txtUserName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtUserName.Size = New System.Drawing.Size(203, 23)
        Me.txtUserName.TabIndex = 0
        Me.txtUserName.Translatable = false
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = true
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.DisplayOnly = true
        Me.lblUserName.EditingMode = false
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblUserName.Location = New System.Drawing.Point(13, 36)
        Me.lblUserName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(79, 17)
        Me.lblUserName.TabIndex = 1
        Me.lblUserName.Text = "User Name"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUserName.Translatable = true
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.BackColor = System.Drawing.Color.Transparent
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(13, 67)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(69, 17)
        Me.CLabel1.TabIndex = 2
        Me.CLabel1.Text = "Password"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = true
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.BegFindValue = Nothing
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.ComputedValue = false
        Me.txtPassword.CustomFormat = Nothing
        Me.txtPassword.DataBoundControl = true
        Me.txtPassword.EditingMode = true
        Me.txtPassword.EndFindValue = Nothing
        Me.txtPassword.FieldDescription = Nothing
        Me.txtPassword.FieldName = Nothing
        Me.txtPassword.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPassword.FindEnabled = false
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPassword.LinkedLabel = Nothing
        Me.txtPassword.Location = New System.Drawing.Point(124, 65)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPassword.MaximumValue = Nothing
        Me.txtPassword.MinimumValue = Nothing
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.OldValue = Nothing
        Me.txtPassword.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPassword.Size = New System.Drawing.Size(203, 23)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.Translatable = false
        '
        'btnGenerate
        '
        Me.btnGenerate.DesignerSelected = true
        Me.btnGenerate.ImageIndex = 0
        Me.btnGenerate.Location = New System.Drawing.Point(57, 105)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.OriginalImageName = Nothing
        Me.btnGenerate.SecurityKey = ""
        Me.btnGenerate.Size = New System.Drawing.Size(90, 25)
        Me.btnGenerate.TabIndex = 4
        Me.btnGenerate.Text = "Generate"
        '
        'btnQuit
        '
        Me.btnQuit.DesignerSelected = false
        Me.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnQuit.ImageIndex = 0
        Me.btnQuit.Location = New System.Drawing.Point(199, 105)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.OriginalImageName = Nothing
        Me.btnQuit.SecurityKey = ""
        Me.btnQuit.Size = New System.Drawing.Size(90, 25)
        Me.btnQuit.TabIndex = 5
        Me.btnQuit.Text = "Quit"
        '
        'PasswordGenerator
        '
        Me.AcceptButton = Me.btnGenerate
        Me.CancelButton = Me.btnQuit
        Me.ClientSize = New System.Drawing.Size(345, 145)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.CLabel1)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.txtUserName)
        Me.Name = "PasswordGenerator"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents txtUserName As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents lblUserName As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents txtPassword As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents btnGenerate As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnQuit As Libraries.CBaseControlsLibrary.CButton
End Class
