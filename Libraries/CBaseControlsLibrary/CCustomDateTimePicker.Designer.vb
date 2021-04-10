

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CCustomDateTimePicker
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
        Me.floDatePicker = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.txtLongDate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtDate = New AATM.Libraries.CBaseControlsLibrary.CMaskedTextBox()
        Me.dtp = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.txtTime = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.btnCalendarType = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.floDatePicker.SuspendLayout
        Me.SuspendLayout()
        '
        'floDatePicker
        '
        Me.floDatePicker.BackColor = System.Drawing.Color.Transparent
        Me.floDatePicker.Controls.Add(Me.txtLongDate)
        Me.floDatePicker.Controls.Add(Me.txtDate)
        Me.floDatePicker.Controls.Add(Me.dtp)
        Me.floDatePicker.Controls.Add(Me.txtTime)
        Me.floDatePicker.Controls.Add(Me.btnCalendarType)
        Me.floDatePicker.Location = New System.Drawing.Point(0, 0)
        Me.floDatePicker.Margin = New System.Windows.Forms.Padding(0)
        Me.floDatePicker.Name = "floDatePicker"
        Me.floDatePicker.Size = New System.Drawing.Size(296, 24)
        Me.floDatePicker.TabIndex = 21
        '
        'txtLongDate
        '
        Me.txtLongDate.BackColor = System.Drawing.Color.White
        Me.txtLongDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDate.ComputedValue = False
        Me.txtLongDate.CustomFormat = Nothing
        Me.txtLongDate.DataBoundControl = True
        Me.txtLongDate.DisplayOnly = False
        Me.txtLongDate.EditingMode = True
        Me.txtLongDate.FindEnabled = True
        Me.txtLongDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtLongDate.ForeColor = System.Drawing.Color.Black
        Me.txtLongDate.LinkedLabel = Nothing
        Me.txtLongDate.Location = New System.Drawing.Point(0, 0)
        Me.txtLongDate.Margin = New System.Windows.Forms.Padding(0)
        Me.txtLongDate.MaximumValue = Nothing
        Me.txtLongDate.MinimumValue = Nothing
        Me.txtLongDate.Name = "txtLongDate"
        Me.txtLongDate.OldValue = Nothing
        Me.txtLongDate.ReadOnly = True
        Me.txtLongDate.Size = New System.Drawing.Size(110, 23)
        Me.txtLongDate.TabIndex = 16
        '
        'txtDate
        '
        Me.txtDate.BackColor = System.Drawing.Color.White
        Me.txtDate.DateField = False
        Me.txtDate.DefaultValue = Nothing
        Me.txtDate.DisplayOnly = False
        Me.txtDate.EditingMode = True
        Me.txtDate.EditsAllowed = True
        Me.txtDate.EmptyMask = ""
        Me.txtDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate.ForeColor = System.Drawing.Color.Black
        Me.txtDate.Location = New System.Drawing.Point(110, 0)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDate.MaximumValue = Nothing
        Me.txtDate.MinimumValue = Nothing
        Me.txtDate.Name = "txtDate"
        Me.txtDate.SearchField = Nothing
        Me.txtDate.SecurityKey = Nothing
        Me.txtDate.Size = New System.Drawing.Size(75, 23)
        Me.txtDate.TabIndex = 15
        Me.txtDate.ValueIsMandatory = False
        Me.txtDate.ValueIsNullable = True
        Me.txtDate.ValueIsNumeric = False
        '
        'dtp
        '
        Me.dtp.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.dtp.DesignerSelected = True
        Me.dtp.DisplayOnly = True
        Me.dtp.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp.Image = Global.AATM.Libraries.CBaseControlsLibrary.My.Resources.Resources.Calendar18x18
        Me.dtp.ImageIndex = 0
        Me.dtp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtp.Location = New System.Drawing.Point(185, 0)
        Me.dtp.Margin = New System.Windows.Forms.Padding(0)
        Me.dtp.Name = "dtp"
        Me.dtp.OriginalImageName = Nothing
        Me.dtp.SecurityKey = ""
        Me.dtp.Size = New System.Drawing.Size(21, 19)
        Me.dtp.TabIndex = 19
        Me.dtp.TabStop = False
        Me.dtp.Text = ""
        Me.dtp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'txtTime
        '
        Me.txtTime.BackColor = System.Drawing.Color.White
        Me.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTime.ComputedValue = False
        Me.txtTime.CustomFormat = Nothing
        Me.txtTime.DataBoundControl = True
        Me.txtTime.DisplayOnly = False
        Me.txtTime.EditingMode = True
        Me.txtTime.FindEnabled = True
        Me.txtTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtTime.ForeColor = System.Drawing.Color.Black
        Me.txtTime.LinkedLabel = Nothing
        Me.txtTime.Location = New System.Drawing.Point(206, 0)
        Me.txtTime.Margin = New System.Windows.Forms.Padding(0)
        Me.txtTime.MaximumValue = Nothing
        Me.txtTime.MinimumValue = Nothing
        Me.txtTime.Name = "txtTime"
        Me.txtTime.OldValue = Nothing
        Me.txtTime.ReadOnly = True
        Me.txtTime.Size = New System.Drawing.Size(70, 23)
        Me.txtTime.TabIndex = 17
        Me.txtTime.ValueIsNullable = True
        '
        'btnCalendarType
        '
        Me.btnCalendarType.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnCalendarType.DesignerSelected = False
        Me.btnCalendarType.DisplayOnly = True
        Me.btnCalendarType.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalendarType.ImageIndex = 0
        Me.btnCalendarType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCalendarType.Location = New System.Drawing.Point(276, 0)
        Me.btnCalendarType.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCalendarType.Name = "btnCalendarType"
        Me.btnCalendarType.OriginalImageName = Nothing
        Me.btnCalendarType.SecurityKey = ""
        Me.btnCalendarType.Size = New System.Drawing.Size(18, 19)
        Me.btnCalendarType.TabIndex = 21
        Me.btnCalendarType.TabStop = False
        Me.btnCalendarType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'CCustomDateTimePicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.floDatePicker)
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "CCustomDateTimePicker"
        Me.Size = New System.Drawing.Size(293, 25)
        Me.floDatePicker.ResumeLayout(False)
        Me.floDatePicker.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtp As CButton
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents txtLongDate As CTextBox
    Friend WithEvents txtDate As CMaskedTextBox
    Friend WithEvents txtTime As CTextBox
    Friend WithEvents floDatePicker As CFlowLayout
    Friend WithEvents btnCalendarType As CButton
End Class
