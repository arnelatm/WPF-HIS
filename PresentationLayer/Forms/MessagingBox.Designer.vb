Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.LIBRARIES.CBaseControlsLibrary
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class MessagingBox
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MessagingBox))
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnYes = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnNo = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.pctError = New System.Windows.Forms.PictureBox()
        Me.pctInfo = New System.Windows.Forms.PictureBox()
        Me.pctQuestion = New System.Windows.Forms.PictureBox()
        Me.pctWarning = New System.Windows.Forms.PictureBox()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pctError,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pctInfo,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pctQuestion,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pctWarning,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.BackColor = System.Drawing.Color.Lime
        Me.btnCancel.DesignerSelected = false
        Me.btnCancel.DisplayOnly = true
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(171, 60)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(80, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        '
        'btnYes
        '
        Me.btnYes.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnYes.BackColor = System.Drawing.Color.Lime
        Me.btnYes.DesignerSelected = false
        Me.btnYes.DisplayOnly = true
        Me.btnYes.ImageIndex = 0
        Me.btnYes.Location = New System.Drawing.Point(258, 60)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.OriginalImageName = Nothing
        Me.btnYes.SecurityKey = ""
        Me.btnYes.Size = New System.Drawing.Size(75, 23)
        Me.btnYes.TabIndex = 1
        Me.btnYes.Text = "Yes"
        '
        'btnNo
        '
        Me.btnNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNo.BackColor = System.Drawing.Color.Lime
        Me.btnNo.DesignerSelected = false
        Me.btnNo.DisplayOnly = true
        Me.btnNo.ImageIndex = 0
        Me.btnNo.Location = New System.Drawing.Point(340, 60)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.OriginalImageName = Nothing
        Me.btnNo.SecurityKey = ""
        Me.btnNo.Size = New System.Drawing.Size(76, 23)
        Me.btnNo.TabIndex = 2
        Me.btnNo.Text = "No"
        '
        'pctError
        '
        Me.pctError.BackColor = System.Drawing.SystemColors.Control
        Me.pctError.Image = CType(resources.GetObject("pctError.Image"),System.Drawing.Image)
        Me.pctError.Location = New System.Drawing.Point(2, 2)
        Me.pctError.Name = "pctError"
        Me.pctError.Size = New System.Drawing.Size(45, 45)
        Me.pctError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctError.TabIndex = 9
        Me.pctError.TabStop = false
        Me.pctError.Visible = false
        '
        'pctInfo
        '
        Me.pctInfo.Image = CType(resources.GetObject("pctInfo.Image"),System.Drawing.Image)
        Me.pctInfo.Location = New System.Drawing.Point(2, 2)
        Me.pctInfo.Name = "pctInfo"
        Me.pctInfo.Size = New System.Drawing.Size(45, 45)
        Me.pctInfo.TabIndex = 11
        Me.pctInfo.TabStop = false
        Me.pctInfo.Visible = false
        '
        'pctQuestion
        '
        Me.pctQuestion.Image = CType(resources.GetObject("pctQuestion.Image"),System.Drawing.Image)
        Me.pctQuestion.Location = New System.Drawing.Point(2, 2)
        Me.pctQuestion.Name = "pctQuestion"
        Me.pctQuestion.Size = New System.Drawing.Size(45, 45)
        Me.pctQuestion.TabIndex = 12
        Me.pctQuestion.TabStop = false
        Me.pctQuestion.Visible = false
        '
        'pctWarning
        '
        Me.pctWarning.Image = CType(resources.GetObject("pctWarning.Image"),System.Drawing.Image)
        Me.pctWarning.Location = New System.Drawing.Point(2, 2)
        Me.pctWarning.Name = "pctWarning"
        Me.pctWarning.Size = New System.Drawing.Size(45, 45)
        Me.pctWarning.TabIndex = 13
        Me.pctWarning.TabStop = false
        Me.pctWarning.Visible = false
        '
        'btnOk
        '
        Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOk.BackColor = System.Drawing.Color.Lime
        Me.btnOk.DesignerSelected = false
        Me.btnOk.DisplayOnly = true
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(89, 60)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.OriginalImageName = Nothing
        Me.btnOk.SecurityKey = ""
        Me.btnOk.Size = New System.Drawing.Size(76, 23)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Ok"
        '
        'txtMessage
        '
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMessage.Location = New System.Drawing.Point(53, 9)
        Me.txtMessage.Multiline = true
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(419, 45)
        Me.txtMessage.TabIndex = 16
        '
        'MessagingBox
        '
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.BackgroundImage = Nothing
        Me.ClientSize = New System.Drawing.Size(484, 86)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.pctWarning)
        Me.Controls.Add(Me.pctQuestion)
        Me.Controls.Add(Me.pctInfo)
        Me.Controls.Add(Me.pctError)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.btnCancel)
        Me.MinimumSize = New System.Drawing.Size(500, 125)
        Me.Name = "MessagingBox"
        Me.Text = "Message"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pctError,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pctInfo,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pctQuestion,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pctWarning,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents btnCancel As CButton
    Friend WithEvents btnYes As CButton
    Friend WithEvents btnNo As CButton
    Public WithEvents pctError As PictureBox
    Public WithEvents pctInfo As PictureBox
    Public WithEvents pctQuestion As PictureBox
    Public WithEvents pctWarning As PictureBox
    Public WithEvents btnOk As CButton
    Public WithEvents txtMessage As TextBox
End Class
