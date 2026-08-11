<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gTimePickerCntrl
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.lklAM = New System.Windows.Forms.LinkLabel
        Me.lklPM = New System.Windows.Forms.LinkLabel
        Me.lklNow = New System.Windows.Forms.LinkLabel
        Me.lklNull = New System.Windows.Forms.LinkLabel
        Me.SuspendLayout()
        '
        'lklAM
        '
        Me.lklAM.BackColor = System.Drawing.Color.Transparent
        Me.lklAM.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lklAM.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lklAM.Location = New System.Drawing.Point(148, 9)
        Me.lklAM.Name = "lklAM"
        Me.lklAM.Size = New System.Drawing.Size(30, 14)
        Me.lklAM.TabIndex = 13
        Me.lklAM.TabStop = True
        Me.lklAM.Text = "AM"
        Me.lklAM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lklPM
        '
        Me.lklPM.BackColor = System.Drawing.Color.Transparent
        Me.lklPM.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lklPM.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lklPM.LinkColor = System.Drawing.Color.LightSteelBlue
        Me.lklPM.Location = New System.Drawing.Point(174, 9)
        Me.lklPM.Name = "lklPM"
        Me.lklPM.Size = New System.Drawing.Size(30, 14)
        Me.lklPM.TabIndex = 14
        Me.lklPM.TabStop = True
        Me.lklPM.Text = "PM"
        Me.lklPM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lklNow
        '
        Me.lklNow.BackColor = System.Drawing.Color.Transparent
        Me.lklNow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lklNow.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lklNow.LinkColor = System.Drawing.Color.Blue
        Me.lklNow.Location = New System.Drawing.Point(87, 4)
        Me.lklNow.Name = "lklNow"
        Me.lklNow.Size = New System.Drawing.Size(41, 14)
        Me.lklNow.TabIndex = 15
        Me.lklNow.TabStop = True
        Me.lklNow.Text = "Now"
        Me.lklNow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lklNull
        '
        Me.lklNull.BackColor = System.Drawing.Color.Transparent
        Me.lklNull.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lklNull.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lklNull.LinkColor = System.Drawing.Color.Blue
        Me.lklNull.Location = New System.Drawing.Point(5, 41)
        Me.lklNull.Name = "lklNull"
        Me.lklNull.Size = New System.Drawing.Size(35, 14)
        Me.lklNull.TabIndex = 16
        Me.lklNull.TabStop = True
        Me.lklNull.Text = "Null"
        Me.lklNull.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gTimePickerCntrl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lklNull)
        Me.Controls.Add(Me.lklNow)
        Me.Controls.Add(Me.lklPM)
        Me.Controls.Add(Me.lklAM)
        Me.DoubleBuffered = True
        Me.Name = "gTimePickerCntrl"
        Me.Size = New System.Drawing.Size(214, 210)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lklAM As System.Windows.Forms.LinkLabel
    Friend WithEvents lklPM As System.Windows.Forms.LinkLabel
    Friend WithEvents lklNow As System.Windows.Forms.LinkLabel
    Friend WithEvents lklNull As System.Windows.Forms.LinkLabel

End Class
