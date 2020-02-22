Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class CFindForm
    Inherits CForm

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()> _
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
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TxtTextToSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RBtnStart = New System.Windows.Forms.RadioButton()
        Me.RBtnAnywhere = New System.Windows.Forms.RadioButton()
        Me.BtnFind = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'TxtTextToSearch
        '
        Me.TxtTextToSearch.Location = New System.Drawing.Point(67, 23)
        Me.TxtTextToSearch.Name = "TxtTextToSearch"
        Me.TxtTextToSearch.Size = New System.Drawing.Size(205, 20)
        Me.TxtTextToSearch.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(13, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Look For"
        '
        'RBtnStart
        '
        Me.RBtnStart.AutoSize = true
        Me.RBtnStart.Checked = true
        Me.RBtnStart.Location = New System.Drawing.Point(54, 68)
        Me.RBtnStart.Name = "RBtnStart"
        Me.RBtnStart.Size = New System.Drawing.Size(84, 17)
        Me.RBtnStart.TabIndex = 2
        Me.RBtnStart.TabStop = true
        Me.RBtnStart.Text = "Start of Field"
        Me.RBtnStart.UseVisualStyleBackColor = true
        '
        'RBtnAnywhere
        '
        Me.RBtnAnywhere.AutoSize = true
        Me.RBtnAnywhere.Location = New System.Drawing.Point(54, 92)
        Me.RBtnAnywhere.Name = "RBtnAnywhere"
        Me.RBtnAnywhere.Size = New System.Drawing.Size(112, 17)
        Me.RBtnAnywhere.TabIndex = 3
        Me.RBtnAnywhere.Text = "Anywhere on Field"
        Me.RBtnAnywhere.UseVisualStyleBackColor = true
        '
        'BtnFind
        '
        Me.BtnFind.Location = New System.Drawing.Point(54, 132)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(75, 23)
        Me.BtnFind.TabIndex = 4
        Me.BtnFind.Text = "Find"
        Me.BtnFind.UseVisualStyleBackColor = true
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(158, 132)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = true
        '
        'CFindForm
        '
        Me.AcceptButton = Me.BtnFind
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(284, 171)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnFind)
        Me.Controls.Add(Me.RBtnAnywhere)
        Me.Controls.Add(Me.RBtnStart)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtTextToSearch)
        Me.Name = "CFindForm"
        Me.Text = "Find Field Form"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents TxtTextToSearch As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RBtnStart As RadioButton
    Friend WithEvents RBtnAnywhere As RadioButton
    Friend WithEvents BtnFind As Button
    Friend WithEvents BtnCancel As Button
End Class
