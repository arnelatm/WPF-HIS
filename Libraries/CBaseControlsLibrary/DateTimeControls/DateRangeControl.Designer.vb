<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DateRangeControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DateRangeControl))
        Me.lblBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpBeginningDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpEndingDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.SuspendLayout()
        '
        'lblBeginningDate
        '
        Me.lblBeginningDate.DisplayOnly = True
        Me.lblBeginningDate.EditingMode = False
        Me.lblBeginningDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblBeginningDate.Location = New System.Drawing.Point(1, 1)
        Me.lblBeginningDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBeginningDate.Name = "lblBeginningDate"
        Me.lblBeginningDate.Size = New System.Drawing.Size(150, 25)
        Me.lblBeginningDate.TabIndex = 25
        Me.lblBeginningDate.Text = "Beginning Date :"
        Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBeginningDate.Translatable = True
        '
        'dtpBeginningDate
        '
        Me.dtpBeginningDate.AutoSize = True
        Me.dtpBeginningDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpBeginningDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpBeginningDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpBeginningDate.DefaultValue = Nothing
        Me.dtpBeginningDate.DisplayOnly = False
        Me.dtpBeginningDate.DtpDefaultValue = Nothing
        Me.dtpBeginningDate.EditingMode = True
        Me.dtpBeginningDate.EditsAllowed = False
        Me.dtpBeginningDate.ForeColor = System.Drawing.Color.Black
        Me.dtpBeginningDate.LinkedLabel = Nothing
        Me.dtpBeginningDate.Location = New System.Drawing.Point(153, 1)
        Me.dtpBeginningDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpBeginningDate.Name = "dtpBeginningDate"
        Me.dtpBeginningDate.ReadOnlyDp = False
        Me.dtpBeginningDate.SecurityKey = Nothing
        Me.dtpBeginningDate.ShowLongDate = False
        Me.dtpBeginningDate.ShowTime = False
        Me.dtpBeginningDate.Size = New System.Drawing.Size(118, 27)
        Me.dtpBeginningDate.TabIndex = 27
        Me.dtpBeginningDate.TargetCalendar = CType(resources.GetObject("dtpBeginningDate.TargetCalendar"), System.Globalization.Calendar)
        Me.dtpBeginningDate.Translatable = False
        Me.dtpBeginningDate.Value = Nothing
        Me.dtpBeginningDate.ValueIsMandatory = False
        Me.dtpBeginningDate.ValueIsNullable = False
        '
        'CLabel3
        '
        Me.CLabel3.DisplayOnly = True
        Me.CLabel3.EditingMode = False
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel3.Location = New System.Drawing.Point(1, 30)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(150, 25)
        Me.CLabel3.TabIndex = 26
        Me.CLabel3.Text = "Ending Date:"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel3.Translatable = True
        '
        'dtpEndingDate
        '
        Me.dtpEndingDate.AutoSize = True
        Me.dtpEndingDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpEndingDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpEndingDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndingDate.DefaultValue = Nothing
        Me.dtpEndingDate.DisplayOnly = False
        Me.dtpEndingDate.DtpDefaultValue = Nothing
        Me.dtpEndingDate.EditingMode = True
        Me.dtpEndingDate.EditsAllowed = False
        Me.dtpEndingDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndingDate.LinkedLabel = Nothing
        Me.dtpEndingDate.Location = New System.Drawing.Point(153, 30)
        Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndingDate.Name = "dtpEndingDate"
        Me.dtpEndingDate.ReadOnlyDp = False
        Me.dtpEndingDate.SecurityKey = Nothing
        Me.dtpEndingDate.ShowLongDate = False
        Me.dtpEndingDate.ShowTime = False
        Me.dtpEndingDate.Size = New System.Drawing.Size(118, 27)
        Me.dtpEndingDate.TabIndex = 28
        Me.dtpEndingDate.TargetCalendar = CType(resources.GetObject("dtpEndingDate.TargetCalendar"), System.Globalization.Calendar)
        Me.dtpEndingDate.Translatable = False
        Me.dtpEndingDate.Value = Nothing
        Me.dtpEndingDate.ValueIsMandatory = False
        Me.dtpEndingDate.ValueIsNullable = False
        '
        'DateRangeControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblBeginningDate)
        Me.Controls.Add(Me.dtpBeginningDate)
        Me.Controls.Add(Me.CLabel3)
        Me.Controls.Add(Me.dtpEndingDate)
        Me.Name = "DateRangeControl"
        Me.Size = New System.Drawing.Size(274, 62)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblBeginningDate As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents dtpBeginningDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
    Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents dtpEndingDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
End Class
