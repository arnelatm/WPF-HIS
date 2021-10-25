
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gTimePicker
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
        Me.txbTime = New gTimeBox
        Me.SuspendLayout()
        '
        'txbTime
        '
        Me.txbTime.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbTime.Location = New System.Drawing.Point(0, 0)
        Me.txbTime.Name = "txbTime"
        Me.txbTime.NullColorA = System.Drawing.Color.LightSteelBlue
        Me.txbTime.NullColorB = System.Drawing.Color.White
        Me.txbTime.NullHatchStyle = System.Drawing.Drawing2D.HatchStyle.WideDownwardDiagonal
        Me.txbTime.NullTextColor = System.Drawing.Color.Black
        Me.txbTime.NullTextInFront = False
        Me.txbTime.Size = New System.Drawing.Size(48, 22)
        Me.txbTime.TabIndex = 1
        '
        'gTimePicker
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.txbTime)
        Me.Name = "gTimePicker"
        Me.Size = New System.Drawing.Size(65, 12)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txbTime As gTimeBox

End Class
