Imports AATM.Libraries.CBaseControlsLibrary

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CFindForm
    Inherits CForm

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
        Me.TxtTextToSearch = New System.Windows.Forms.TextBox()
        Me.RBtnStart = New System.Windows.Forms.RadioButton()
        Me.RBtnAnywhere = New System.Windows.Forms.RadioButton()
        Me.BtnFind = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.lblTextToSearch = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TxtTextToSearch
        '
        Me.TxtTextToSearch.Location = New System.Drawing.Point(89, 23)
        Me.TxtTextToSearch.Name = "TxtTextToSearch"
        Me.TxtTextToSearch.Size = New System.Drawing.Size(205, 20)
        Me.TxtTextToSearch.TabIndex = 0
        '
        'RBtnStart
        '
        Me.RBtnStart.AutoSize = True
        Me.RBtnStart.BackColor = System.Drawing.Color.Transparent
        Me.RBtnStart.Checked = True
        Me.RBtnStart.Location = New System.Drawing.Point(54, 68)
        Me.RBtnStart.Name = "RBtnStart"
        Me.RBtnStart.Size = New System.Drawing.Size(84, 17)
        Me.RBtnStart.TabIndex = 2
        Me.RBtnStart.TabStop = True
        Me.RBtnStart.Text = "Start of Field"
        Me.RBtnStart.UseVisualStyleBackColor = False
        '
        'RBtnAnywhere
        '
        Me.RBtnAnywhere.AutoSize = True
        Me.RBtnAnywhere.BackColor = System.Drawing.Color.Transparent
        Me.RBtnAnywhere.Location = New System.Drawing.Point(54, 92)
        Me.RBtnAnywhere.Name = "RBtnAnywhere"
        Me.RBtnAnywhere.Size = New System.Drawing.Size(112, 17)
        Me.RBtnAnywhere.TabIndex = 3
        Me.RBtnAnywhere.Text = "Anywhere on Field"
        Me.RBtnAnywhere.UseVisualStyleBackColor = False
        '
        'BtnFind
        '
        Me.BtnFind.Location = New System.Drawing.Point(66, 132)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(75, 23)
        Me.BtnFind.TabIndex = 4
        Me.BtnFind.Text = "Find"
        Me.BtnFind.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(196, 132)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'lblTextToSearch
        '
        Me.lblTextToSearch.AutoSize = True
        Me.lblTextToSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblTextToSearch.DisplayOnly = True
        Me.lblTextToSearch.EditingMode = False
        Me.lblTextToSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblTextToSearch.Location = New System.Drawing.Point(10, 24)
        Me.lblTextToSearch.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTextToSearch.Name = "lblTextToSearch"
        Me.lblTextToSearch.Size = New System.Drawing.Size(64, 17)
        Me.lblTextToSearch.TabIndex = 6
        Me.lblTextToSearch.Text = "Look For"
        Me.lblTextToSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(130, 158)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CFindForm
        '
        Me.AcceptButton = Me.BtnFind
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(334, 196)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblTextToSearch)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnFind)
        Me.Controls.Add(Me.RBtnAnywhere)
        Me.Controls.Add(Me.RBtnStart)
        Me.Controls.Add(Me.TxtTextToSearch)
        Me.Name = "CFindForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Find Field Form"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents TxtTextToSearch As Windows.Forms.TextBox
    Friend WithEvents RBtnStart As Windows.Forms.RadioButton
    Friend WithEvents RBtnAnywhere As Windows.Forms.RadioButton
    Friend WithEvents BtnFind As Windows.Forms.Button
    Friend WithEvents BtnCancel As Windows.Forms.Button
    Friend WithEvents lblTextToSearch As CLabel
    Friend WithEvents Button1 As Button
End Class
