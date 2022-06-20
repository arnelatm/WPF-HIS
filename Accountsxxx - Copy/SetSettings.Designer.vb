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
        Me.components = New System.ComponentModel.Container()
        Me.PropertyGrid = New System.Windows.Forms.PropertyGrid()
        Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.SuspendLayout()
        '
        'PropertyGrid
        '
        Me.PropertyGrid.Location = New System.Drawing.Point(12, 12)
        Me.PropertyGrid.Name = "PropertyGrid"
        Me.PropertyGrid.Size = New System.Drawing.Size(776, 378)
        Me.PropertyGrid.TabIndex = 0
        '
        'CButton1
        '
        Me.CButton1.DesignerSelected = True
        Me.CButton1.DisplayOnly = True
        Me.CButton1.ImageIndex = 0
        Me.CButton1.Location = New System.Drawing.Point(376, 413)
        Me.CButton1.Name = "CButton1"
        Me.CButton1.OriginalImageName = Nothing
        Me.CButton1.SecurityKey = ""
        Me.CButton1.Size = New System.Drawing.Size(124, 25)
        Me.CButton1.TabIndex = 1
        Me.CButton1.Text = "Save Settings"
        '
        'SetSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CButton1)
        Me.Controls.Add(Me.PropertyGrid)
        Me.Name = "SetSettings"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PropertyGrid As PropertyGrid
    Friend WithEvents CButton1 As Libraries.CBaseControlsLibrary.CButton
End Class
