<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetSettings
    Inherits AATM.Libraries.BaseControlsLibrary.BForm

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
        Me.PropertyGrid = New System.Windows.Forms.PropertyGrid()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'PropertyGrid
        '
        Me.PropertyGrid.Location = New System.Drawing.Point(12, 12)
        Me.PropertyGrid.Name = "PropertyGrid"
        Me.PropertyGrid.Size = New System.Drawing.Size(776, 378)
        Me.PropertyGrid.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Location = New System.Drawing.Point(342, 396)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(101, 21)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save Settings"
        Me.btnSave.UseVisualStyleBackColor = false
        '
        'SetSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(800, 429)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.PropertyGrid)
        Me.Name = "SetSettings"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents PropertyGrid As PropertyGrid
    Friend WithEvents btnSave As Button
End Class
