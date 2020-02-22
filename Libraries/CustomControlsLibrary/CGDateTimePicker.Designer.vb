Imports AATM.Libraries.CBaseControlsLibrary

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CGDateTimePicker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CGDateTimePicker))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtLongDate = New CTextBox()
        Me.txtDate = New CMaskedTextBox()
        Me.txtTime = New CTextBox()
        Me.CFlowLayout1 = New CFlowLayout()
        Me.dtp = New CButton()
        Me.CFlowLayout1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtLongDate
        '
        Me.txtLongDate.AcceptsReturn = false
        Me.txtLongDate.AcceptsTab = false
        Me.txtLongDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtLongDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDate.DataBoundControl = True
        Me.txtLongDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtLongDate.LinkedLabel = Nothing
        Me.txtLongDate.Location = New System.Drawing.Point(0, 0)
        Me.txtLongDate.Margin = New System.Windows.Forms.Padding(0)
        Me.txtLongDate.Name = "txtLongDate"
        Me.txtLongDate.Size = New System.Drawing.Size(0, 23)
        Me.txtLongDate.TabIndex = 21
        Me.txtLongDate.Visible = False
        '
        'txtDate
        '
        Me.txtDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDate.DefaultValue = Nothing
        Me.txtDate.EmptyMask = ""
        Me.txtDate.Location = New System.Drawing.Point(0, 0)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.SecurityKey = Nothing
        Me.txtDate.Size = New System.Drawing.Size(65, 20)
        Me.txtDate.TabIndex = 20
        Me.txtDate.ValueIsMandatory = False
        Me.txtDate.ValueIsNullable = True
        Me.txtDate.ValueIsNumeric = False
        Me.txtDate.DisplayOnly = False
        '
        'txtTime
        '
        Me.txtTime.AcceptsReturn = false
        Me.txtTime.AcceptsTab = false
        Me.txtTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTime.DataBoundControl = True
        Me.txtTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtTime.LinkedLabel = Nothing
        Me.txtTime.Location = New System.Drawing.Point(89, 0)
        Me.txtTime.Margin = New System.Windows.Forms.Padding(0)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(0, 23)
        Me.txtTime.TabIndex = 22
        Me.txtTime.ValueIsNullable = True
        Me.txtTime.Visible = False
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.Controls.Add(Me.txtLongDate)
        Me.CFlowLayout1.Controls.Add(Me.txtDate)
        Me.CFlowLayout1.Controls.Add(Me.dtp)
        Me.CFlowLayout1.Controls.Add(Me.txtTime)
        Me.CFlowLayout1.Location = New System.Drawing.Point(0, 0)
        Me.CFlowLayout1.Margin = New System.Windows.Forms.Padding(0)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(90, 20)
        Me.CFlowLayout1.TabIndex = 24
        '
        'dtp
        '
        Me.dtp.BackColor = System.Drawing.Color.Transparent
        Me.dtp.BackgroundImage = CType(resources.GetObject("dtp.BackgroundImage"), System.Drawing.Image)
        Me.dtp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.dtp.Location = New System.Drawing.Point(68, 3)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(18, 20)
        Me.dtp.TabIndex = 24
        '
        'CGDateTimePicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "CGDateTimePicker"
        Me.Size = New System.Drawing.Size(85, 20)
        Me.CFlowLayout1.ResumeLayout(False)
        Me.CFlowLayout1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents txtLongDate As CTextBox
    Friend WithEvents txtDate As CMaskedTextBox
    Friend WithEvents txtTime As CTextBox
    Friend WithEvents CFlowLayout1 As CFlowLayout
    Friend WithEvents dtp As CButton
End Class
