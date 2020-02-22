Imports System.ComponentModel
Imports System.Windows.Forms

Partial Public Class FormLogin
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLogin))
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.textBoxPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.textBoxUserName = New System.Windows.Forms.TextBox()
        Me.btn_Login = New Button
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.groupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.Label3)
        Me.groupBox1.Controls.Add(Me.textBoxPassword)
        Me.groupBox1.Controls.Add(Me.Label4)
        Me.groupBox1.Controls.Add(Me.textBoxUserName)
        resources.ApplyResources(Me.groupBox1, "groupBox1")
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.TabStop = False
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'textBoxPassword
        '
        resources.ApplyResources(Me.textBoxPassword, "textBoxPassword")
        Me.textBoxPassword.Name = "textBoxPassword"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'textBoxUserName
        '
        resources.ApplyResources(Me.textBoxUserName, "textBoxUserName")
        Me.textBoxUserName.Name = "textBoxUserName"
        '
        'btn_Login
        '
        resources.ApplyResources(Me.btn_Login, "btn_Login")
        Me.btn_Login.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn_Login.Name = "btn_Login"
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Name = "btnCancel"
        '
        'FormLogin
        '
        Me.AcceptButton = Me.btn_Login
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.Controls.Add(Me.btn_Login)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.groupBox1)
        Me.KeyPreview = True
        Me.Name = "FormLogin"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private groupBox1 As GroupBox
    Friend WithEvents textBoxUserName As TextBox
    Friend WithEvents textBoxPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btn_Login As Button
    Friend WithEvents btnCancel As Button
End Class