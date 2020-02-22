Imports AATM.Libraries.CBaseControlsLibrary

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CDTPHijriDate
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dtp = New CButton()
        Me.txtTime = New CTextBox()
        Me.txtLongDate = New CTextBox()
        Me.txtDate = New CMaskedTextBox()
        Me.SuspendLayout()
        '
        'dtp
        '
        Me.dtp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.dtp.Location = New System.Drawing.Point(179, 0)
        Me.dtp.Margin = New System.Windows.Forms.Padding(0)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(18, 20)
        Me.dtp.TabIndex = 14
        Me.dtp.Text = "V"
        '
        'txtTime
        '
        Me.txtTime.AcceptsReturn = false
        Me.txtTime.AcceptsTab = false
        Me.txtTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtTime.DefaultValue = Nothing
        Me.txtTime.Location = New System.Drawing.Point(198, 0)
        Me.txtTime.Margin = New System.Windows.Forms.Padding(0)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.SecurityKey = Nothing
        Me.txtTime.Size = New System.Drawing.Size(65, 20)
        Me.txtTime.TabIndex = 13
        Me.txtTime.ValueIsMandatory = False
        Me.txtTime.ValueIsNullable = True
        Me.txtTime.ValueIsNumeric = False
        Me.txtTime.DisplayOnly = False
        '
        'txtLongDate
        '
        Me.txtLongDate.AcceptsReturn = false
        Me.txtLongDate.AcceptsTab = false
        Me.txtLongDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtLongDate.DefaultValue = Nothing
        Me.txtLongDate.Location = New System.Drawing.Point(2, 0)
        Me.txtLongDate.Margin = New System.Windows.Forms.Padding(0)
        Me.txtLongDate.Name = "txtLongDate"
        Me.txtLongDate.SecurityKey = Nothing
        Me.txtLongDate.Size = New System.Drawing.Size(110, 20)
        Me.txtLongDate.TabIndex = 12
        Me.txtLongDate.ValueIsMandatory = False
        Me.txtLongDate.ValueIsNullable = False
        Me.txtLongDate.ValueIsNumeric = False
        Me.txtLongDate.DisplayOnly = False
        '
        'txtDate
        '
        Me.txtDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDate.DefaultValue = Nothing
        Me.txtDate.EmptyMask = ""
        Me.txtDate.Location = New System.Drawing.Point(113, 0)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.SecurityKey = Nothing
        Me.txtDate.Size = New System.Drawing.Size(65, 20)
        Me.txtDate.TabIndex = 10
        Me.txtDate.ValueIsMandatory = False
        Me.txtDate.ValueIsNullable = True
        Me.txtDate.ValueIsNumeric = False
        Me.txtDate.DisplayOnly = False
        '
        'CDTPHijriDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dtp)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.txtLongDate)
        Me.Controls.Add(Me.txtDate)
        Me.Name = "CDTPHijriDate"
        Me.Size = New System.Drawing.Size(266, 22)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents txtTime As CTextBox
    Friend WithEvents txtLongDate As CTextBox
    Friend WithEvents txtDate As CMaskedTextBox
    Friend WithEvents dtp As CButton
End Class
