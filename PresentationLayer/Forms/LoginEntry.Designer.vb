Imports AATM.Libraries.CBaseControlsLibrary


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginEntry
    Inherits BfMain

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
        Me.btn_Login = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.Label4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.textBoxUserName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.textBoxPassword = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CFlowLayout1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Login
        '
        Me.btn_Login.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Login.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Login.DesignerSelected = False
        Me.btn_Login.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn_Login.DisplayOnly = True
        Me.btn_Login.ForeColor = System.Drawing.Color.Lime
        Me.btn_Login.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Login.ImageIndex = 0
        Me.btn_Login.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Login.Location = New System.Drawing.Point(200, 264)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.OriginalImageName = Nothing
        Me.btn_Login.SecurityKey = ""
        Me.btn_Login.Size = New System.Drawing.Size(75, 33)
        Me.btn_Login.TabIndex = 20
        Me.btn_Login.Text = "Login"
        Me.btn_Login.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.DesignerSelected = False
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.DisplayOnly = True
        Me.btnCancel.ForeColor = System.Drawing.Color.Lime
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(75, 264)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(77, 33)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel.TextShadow = System.Drawing.Color.DarkBlue
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AATM.PresentationLayer.Forms.My.Resources.Resources.Logo
        Me.PictureBox1.Location = New System.Drawing.Point(75, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 150)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CFlowLayout1.Controls.Add(Me.Label4)
        Me.CFlowLayout1.Controls.Add(Me.textBoxUserName)
        Me.CFlowLayout1.Controls.Add(Me.Label3)
        Me.CFlowLayout1.Controls.Add(Me.textBoxPassword)
        Me.CFlowLayout1.Location = New System.Drawing.Point(12, 168)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(20)
        Me.CFlowLayout1.Size = New System.Drawing.Size(325, 85)
        Me.CFlowLayout1.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(20, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 20)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "User Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textBoxUserName
        '
        Me.textBoxUserName.BackColor = System.Drawing.Color.White
        Me.textBoxUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textBoxUserName.ComputedValue = False
        Me.textBoxUserName.CustomFormat = Nothing
        Me.textBoxUserName.DataBoundControl = True
        Me.textBoxUserName.EditingMode = False
        Me.textBoxUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.textBoxUserName.ForeColor = System.Drawing.Color.Black
        Me.textBoxUserName.LinkedLabel = Nothing
        Me.textBoxUserName.Location = New System.Drawing.Point(96, 20)
        Me.textBoxUserName.Margin = New System.Windows.Forms.Padding(0)
        Me.textBoxUserName.Name = "textBoxUserName"
        Me.textBoxUserName.OldValue = Nothing
        Me.textBoxUserName.Size = New System.Drawing.Size(201, 23)
        Me.textBoxUserName.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(20, 43)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 20)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Password:"
        '
        'textBoxPassword
        '
        Me.textBoxPassword.BackColor = System.Drawing.Color.White
        Me.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textBoxPassword.ComputedValue = False
        Me.textBoxPassword.CustomFormat = Nothing
        Me.textBoxPassword.DataBoundControl = True
        Me.textBoxPassword.EditingMode = False
        Me.textBoxPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.textBoxPassword.ForeColor = System.Drawing.Color.Black
        Me.textBoxPassword.LinkedLabel = Nothing
        Me.textBoxPassword.Location = New System.Drawing.Point(96, 43)
        Me.textBoxPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.textBoxPassword.Name = "textBoxPassword"
        Me.textBoxPassword.OldValue = Nothing
        Me.textBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textBoxPassword.Size = New System.Drawing.Size(201, 23)
        Me.textBoxPassword.TabIndex = 21
        Me.textBoxPassword.Text = "1"
        '
        'LoginEntry
        '
        Me.ClientSize = New System.Drawing.Size(349, 309)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_Login)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "LoginEntry"
        Me.Text = "Login Form"
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CFlowLayout1.ResumeLayout(False)
        Me.CFlowLayout1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents btn_Login As CButton
    Friend WithEvents btnCancel As CButton
    Friend WithEvents Label4 As CLabel
    Friend WithEvents textBoxUserName As CTextBox
    Friend WithEvents textBoxPassword As CTextBox
End Class