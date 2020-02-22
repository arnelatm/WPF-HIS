Imports AATM.Libraries.CBaseControlsLibrary

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TdpDateTime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TdpDateTime))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dtp = New CDateTimePicker()
        Me.txtTime = New CTextBox()
        Me.txtLongDate = New CTextBox()
        Me.txtDate = New CMaskedTextBox()
        Me.SuspendLayout()
        '
        'dtp
        '
        Me.dtp.DefaultValue = Nothing
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        resources.ApplyResources(Me.dtp, "dtp")
        Me.dtp.Name = "dtp"
        Me.dtp.ReadOnlyDP = True
        Me.dtp.SecurityKey = Nothing
        Me.dtp.TabStop = False
        Me.dtp.Value = New Date(2018, 11, 4, 12, 41, 29, 896)
        Me.dtp.ValueIsMandatory = False
        Me.dtp.DisplayOnly = False
        '
        'txtTime
        '
        Me.txtTime.AcceptsReturn = false
        Me.txtTime.AcceptsTab = false
        Me.txtTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtTime.DefaultValue = Nothing
        resources.ApplyResources(Me.txtTime, "txtTime")
        Me.txtTime.Name = "txtTime"
        Me.txtTime.SecurityKey = Nothing
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
        resources.ApplyResources(Me.txtLongDate, "txtLongDate")
        Me.txtLongDate.Name = "txtLongDate"
        Me.txtLongDate.SecurityKey = Nothing
        Me.txtLongDate.ValueIsMandatory = False
        Me.txtLongDate.ValueIsNullable = False
        Me.txtLongDate.ValueIsNumeric = False
        Me.txtLongDate.DisplayOnly = False
        '
        'txtDate
        '
        Me.txtDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDate.Culture = New System.Globalization.CultureInfo("en-GB")
        Me.txtDate.DefaultValue = Nothing
        Me.txtDate.EmptyMask = ""
        resources.ApplyResources(Me.txtDate, "txtDate")
        Me.txtDate.Name = "txtDate"
        Me.txtDate.SecurityKey = Nothing
        Me.txtDate.ValueIsMandatory = False
        Me.txtDate.ValueIsNullable = True
        Me.txtDate.ValueIsNumeric = False
        Me.txtDate.DisplayOnly = False
        '
        'TdpDateTime
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dtp)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.txtLongDate)
        Me.Controls.Add(Me.txtDate)
        Me.Name = "TdpDateTime"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtDate As CMaskedTextBox
    Friend WithEvents txtLongDate As CTextBox
    Friend WithEvents txtTime As CTextBox
    Friend WithEvents dtp As CDateTimePicker
End Class
