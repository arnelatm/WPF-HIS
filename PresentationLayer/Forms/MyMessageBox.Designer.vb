Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.LIBRARIES.CBaseControlsLibrary
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class MyMessageBox
    Inherits BfMain

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(MyMessageBox))
        Me.btnCancel = New CButton()
        Me.btnYes = New CButton()
        Me.btnNo = New CButton()
        Me.pctError = New PictureBox()
        Me.pctInfo = New PictureBox()
        Me.pctQuestion = New PictureBox()
        Me.pctWarning = New PictureBox()
        Me.btnOk = New CButton()
        Me.txtMessage = New TextBox()
        CType(Me.MyErrorProvider, ISupportInitialize).BeginInit()
        CType(Me.pctError, ISupportInitialize).BeginInit()
        CType(Me.pctInfo, ISupportInitialize).BeginInit()
        CType(Me.pctQuestion, ISupportInitialize).BeginInit()
        CType(Me.pctWarning, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = AnchorStyles.Bottom
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackColor = Color.Lime
        Me.btnCancel.Location = New Point(171, 60)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New Size(80, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        '
        'btnYes
        '
        Me.btnYes.Anchor = AnchorStyles.Bottom
        Me.btnYes.AutoSize = True
        Me.btnYes.BackColor = Color.Lime
        Me.btnYes.Location = New Point(258, 60)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New Size(75, 23)
        Me.btnYes.TabIndex = 1
        Me.btnYes.Text = "Yes"
        '
        'btnNo
        '
        Me.btnNo.Anchor = AnchorStyles.Bottom
        Me.btnNo.AutoSize = True
        Me.btnNo.BackColor = Color.Lime
        Me.btnNo.Location = New Point(340, 60)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New Size(76, 23)
        Me.btnNo.TabIndex = 2
        Me.btnNo.Text = "No"
        '
        'pctError
        '
        Me.pctError.BackColor = SystemColors.Control
        Me.pctError.Image = CType(resources.GetObject("pctError.Image"), Image)
        Me.pctError.Location = New Point(2, 2)
        Me.pctError.Name = "pctError"
        Me.pctError.Size = New Size(45, 45)
        Me.pctError.SizeMode = PictureBoxSizeMode.StretchImage
        Me.pctError.TabIndex = 9
        Me.pctError.TabStop = False
        Me.pctError.Visible = False
        '
        'pctInfo
        '
        Me.pctInfo.Image = CType(resources.GetObject("pctInfo.Image"), Image)
        Me.pctInfo.Location = New Point(2, 2)
        Me.pctInfo.Name = "pctInfo"
        Me.pctInfo.Size = New Size(45, 45)
        Me.pctInfo.TabIndex = 11
        Me.pctInfo.TabStop = False
        Me.pctInfo.Visible = False
        '
        'pctQuestion
        '
        Me.pctQuestion.Image = CType(resources.GetObject("pctQuestion.Image"), Image)
        Me.pctQuestion.Location = New Point(2, 2)
        Me.pctQuestion.Name = "pctQuestion"
        Me.pctQuestion.Size = New Size(45, 45)
        Me.pctQuestion.TabIndex = 12
        Me.pctQuestion.TabStop = False
        Me.pctQuestion.Visible = False
        '
        'pctWarning
        '
        Me.pctWarning.Image = CType(resources.GetObject("pctWarning.Image"), Image)
        Me.pctWarning.Location = New Point(2, 2)
        Me.pctWarning.Name = "pctWarning"
        Me.pctWarning.Size = New Size(45, 45)
        Me.pctWarning.TabIndex = 13
        Me.pctWarning.TabStop = False
        Me.pctWarning.Visible = False
        '
        'btnOk
        '
        Me.btnOk.Anchor = AnchorStyles.Bottom
        Me.btnOk.AutoSize = True
        Me.btnOk.BackColor = Color.Lime
        Me.btnOk.Location = New Point(89, 60)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New Size(76, 23)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Ok"
        '
        'txtMessage
        '
        Me.txtMessage.BorderStyle = BorderStyle.None
        Me.txtMessage.Location = New Point(53, 9)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New Size(419, 45)
        Me.txtMessage.TabIndex = 16
        '
        'MyMessageBox
        '
        Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Me.ClientSize = New Size(484, 86)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.pctWarning)
        Me.Controls.Add(Me.pctQuestion)
        Me.Controls.Add(Me.pctInfo)
        Me.Controls.Add(Me.pctError)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.btnCancel)
        Me.MinimumSize = New Size(500, 125)
        Me.Name = "MyMessageBox"
        Me.Text = "Message"
        CType(Me.MyErrorProvider, ISupportInitialize).EndInit()
        CType(Me.pctError, ISupportInitialize).EndInit()
        CType(Me.pctInfo, ISupportInitialize).EndInit()
        CType(Me.pctQuestion, ISupportInitialize).EndInit()
        CType(Me.pctWarning, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As CButton
    Friend WithEvents btnYes As CButton
    Friend WithEvents btnNo As CButton
    Public WithEvents pctError As PictureBox
    Public WithEvents pctInfo As PictureBox
    Public WithEvents pctQuestion As PictureBox
    Public WithEvents pctWarning As PictureBox
    Friend WithEvents btnOk As CButton
    Friend WithEvents txtMessage As TextBox
End Class
