Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class LoginEntryError
        Inherits AATM.PresentationLayer.Forms.BfMain

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
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.textBoxUserName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblUserName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPassword = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.textBoxPassword = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.btnCancel = New CButton()
            Me.btnLogin = New CButton()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'PictureBox1
            '
            Me.PictureBox1.Location = New System.Drawing.Point(13, 12)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(348, 165)
            Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.PictureBox1.TabIndex = 21
            Me.PictureBox1.TabStop = False
            '
            'textBoxUserName
            '
            Me.textBoxUserName.AcceptsReturn = false
            Me.textBoxUserName.AcceptsTab = false
            Me.textBoxUserName.BackColor = System.Drawing.Color.White
            Me.textBoxUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.textBoxUserName.ComputedValue = False
            Me.textBoxUserName.DataBoundControl = True
            Me.textBoxUserName.EditingMode = False
            Me.textBoxUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.textBoxUserName.ForeColor = System.Drawing.Color.Black
            Me.textBoxUserName.LinkedLabel = Nothing
            Me.textBoxUserName.Location = New System.Drawing.Point(148, 21)
            Me.textBoxUserName.Margin = New System.Windows.Forms.Padding(1)
            Me.textBoxUserName.Name = "textBoxUserName"
            Me.textBoxUserName.Size = New System.Drawing.Size(172, 23)
            Me.textBoxUserName.TabIndex = 0
            '
            'lblUserName
            '
            Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblUserName.Location = New System.Drawing.Point(21, 21)
            Me.lblUserName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(125, 23)
            Me.lblUserName.TabIndex = 1
            Me.lblUserName.Text = "User Name"
            Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPassword
            '
            Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPassword.Location = New System.Drawing.Point(21, 46)
            Me.lblPassword.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPassword.Name = "lblPassword"
            Me.lblPassword.Size = New System.Drawing.Size(125, 25)
            Me.lblPassword.TabIndex = 2
            Me.lblPassword.Text = "Password"
            Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'textBoxPassword
            '
            Me.textBoxPassword.AcceptsReturn = false
            Me.textBoxPassword.AcceptsTab = false
            Me.textBoxPassword.BackColor = System.Drawing.Color.White
            Me.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.textBoxPassword.ComputedValue = False
            Me.textBoxPassword.DataBoundControl = True
            Me.textBoxPassword.EditingMode = False
            Me.textBoxPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.textBoxPassword.ForeColor = System.Drawing.Color.Black
            Me.textBoxPassword.LinkedLabel = Nothing
            Me.textBoxPassword.Location = New System.Drawing.Point(148, 46)
            Me.textBoxPassword.Margin = New System.Windows.Forms.Padding(1)
            Me.textBoxPassword.Name = "textBoxPassword"
            Me.textBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.textBoxPassword.Size = New System.Drawing.Size(172, 23)
            Me.textBoxPassword.TabIndex = 3
            '
            'btnCancel
            '
            Me.btnCancel.AutoSize = True
            Me.btnCancel.BackColor = System.Drawing.Color.Lime
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.DisplayOnly = True
            Me.btnCancel.Location = New System.Drawing.Point(86, 298)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(75, 23)
            Me.btnCancel.TabIndex = 24
            Me.btnCancel.Text = "Cancel"
            '
            'btnLogin
            '
            Me.btnLogin.AutoSize = True
            Me.btnLogin.BackColor = System.Drawing.Color.Lime
            Me.btnLogin.DisplayOnly = True
            Me.btnLogin.Location = New System.Drawing.Point(194, 298)
            Me.btnLogin.Name = "btnLogin"
            Me.btnLogin.Size = New System.Drawing.Size(75, 23)
            Me.btnLogin.TabIndex = 25
            Me.btnLogin.Text = "Login"
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.CFlowLayout1.Controls.Add(Me.lblUserName)
            Me.CFlowLayout1.Controls.Add(Me.textBoxUserName)
            Me.CFlowLayout1.Controls.Add(Me.lblPassword)
            Me.CFlowLayout1.Controls.Add(Me.textBoxPassword)
            Me.CFlowLayout1.Location = New System.Drawing.Point(13, 183)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(20)
            Me.CFlowLayout1.Size = New System.Drawing.Size(348, 100)
            Me.CFlowLayout1.TabIndex = 26
            '
            'LoginEntryError
            '
            Me.AcceptButton = Me.btnLogin
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(383, 340)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.btnLogin)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.PictureBox1)
            Me.KeyPreview = True
            Me.Name = "LoginEntryError"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
        Friend WithEvents lblUserName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents textBoxUserName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPassword As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents textBoxPassword As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents btnCancel As CButton
        Friend WithEvents btnLogin As CButton
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    End Class
End Namespace