<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl1
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CTextBox2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CTextBox3 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.SuspendLayout()
        '
        'CTextBox1
        '
        Me.CTextBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox1.ComputedValue = False
        Me.CTextBox1.CustomFormat = Nothing
        Me.CTextBox1.DataBoundControl = True
        Me.CTextBox1.EditingMode = False
        Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CTextBox1.LinkedLabel = Nothing
        Me.CTextBox1.Location = New System.Drawing.Point(19, 44)
        Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox1.Name = "CTextBox1"
        Me.CTextBox1.OldValue = Nothing
        Me.CTextBox1.Size = New System.Drawing.Size(100, 23)
        Me.CTextBox1.TabIndex = 0
        '
        'CTextBox2
        '
        Me.CTextBox2.BackColor = System.Drawing.Color.White
        Me.CTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox2.ComputedValue = False
        Me.CTextBox2.CustomFormat = Nothing
        Me.CTextBox2.DataBoundControl = True
        Me.CTextBox2.EditingMode = False
        Me.CTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CTextBox2.LinkedLabel = Nothing
        Me.CTextBox2.Location = New System.Drawing.Point(19, 69)
        Me.CTextBox2.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox2.Name = "CTextBox2"
        Me.CTextBox2.OldValue = Nothing
        Me.CTextBox2.Size = New System.Drawing.Size(100, 23)
        Me.CTextBox2.TabIndex = 1
        '
        'CTextBox3
        '
        Me.CTextBox3.BackColor = System.Drawing.Color.White
        Me.CTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox3.ComputedValue = False
        Me.CTextBox3.CustomFormat = Nothing
        Me.CTextBox3.DataBoundControl = True
        Me.CTextBox3.EditingMode = False
        Me.CTextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CTextBox3.LinkedLabel = Nothing
        Me.CTextBox3.Location = New System.Drawing.Point(19, 94)
        Me.CTextBox3.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox3.Name = "CTextBox3"
        Me.CTextBox3.OldValue = Nothing
        Me.CTextBox3.Size = New System.Drawing.Size(100, 23)
        Me.CTextBox3.TabIndex = 2
        '
        'UserControl1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CTextBox3)
        Me.Controls.Add(Me.CTextBox2)
        Me.Controls.Add(Me.CTextBox1)
        Me.Name = "UserControl1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CTextBox1 As CBaseControlsLibrary.CTextBox
    Friend WithEvents CTextBox2 As CBaseControlsLibrary.CTextBox
    Friend WithEvents CTextBox3 As CBaseControlsLibrary.CTextBox
End Class
