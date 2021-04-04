

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CDtpGregorianDate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CDtpGregorianDate))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtTime = New CTextBox()
        Me.txtLongDate = New CTextBox()
        Me.txtDate = New CMaskedTextBox()
        Me.CFlowLayout1 = New CFlowLayout()
        Me.dtp = New CButton()
        Me.CFlowLayout1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTime
        '
        Me.txtTime.AcceptsReturn = false
        Me.txtTime.AcceptsTab = false
        Me.txtTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTime.DataBoundControl = True
        resources.ApplyResources(Me.txtTime, "txtTime")
        Me.txtTime.LinkedLabel = Nothing
        Me.txtTime.Name = "txtTime"
        Me.txtTime.ValueIsNullable = True
        '
        'txtLongDate
        '
        Me.txtLongDate.AcceptsReturn = false
        Me.txtLongDate.AcceptsTab = false
        Me.txtLongDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtLongDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDate.DataBoundControl = True
        resources.ApplyResources(Me.txtLongDate, "txtLongDate")
        Me.txtLongDate.LinkedLabel = Nothing
        Me.txtLongDate.Name = "txtLongDate"
        '
        'txtDate
        '
        Me.txtDate.BackColor = System.Drawing.SystemColors.ControlLight
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
        'CFlowLayout1
        '
        Me.CFlowLayout1.Controls.Add(Me.txtLongDate)
        Me.CFlowLayout1.Controls.Add(Me.txtDate)
        Me.CFlowLayout1.Controls.Add(Me.dtp)
        Me.CFlowLayout1.Controls.Add(Me.txtTime)
        resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
        Me.CFlowLayout1.Name = "CFlowLayout1"
        '
        'dtp
        '
        resources.ApplyResources(Me.dtp, "dtp")
        Me.dtp.Name = "dtp"
        Me.dtp.TabStop = False
        '
        'CDtpGregorianDate
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "CDtpGregorianDate"
        Me.CFlowLayout1.ResumeLayout(False)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents txtTime As CTextBox
    Friend WithEvents txtLongDate As CTextBox
    Friend WithEvents txtDate As CMaskedTextBox
    Friend WithEvents dtp As CButton
    Friend WithEvents CFlowLayout1 As CFlowLayout
End Class
