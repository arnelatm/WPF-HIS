

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CCalendar
    Inherits CForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CCalendar))
        Me.cboMonths = New AATM.Libraries.CBaseControlsLibrary.CComboBox()
        Me.YearsEdit = New System.Windows.Forms.NumericUpDown()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.btnPrevMonth = New System.Windows.Forms.Button()
        Me.btnNextMonth = New System.Windows.Forms.Button()
        Me.btnCalendarOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCalendarCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.lblTodayMark = New System.Windows.Forms.Label()
        Me.lblThursday = New System.Windows.Forms.Label()
        Me.lblFriday = New System.Windows.Forms.Label()
        Me.lblWednesday = New System.Windows.Forms.Label()
        Me.lblTuesday = New System.Windows.Forms.Label()
        Me.lblMonday = New System.Windows.Forms.Label()
        Me.lblSaturday = New System.Windows.Forms.Label()
        Me.lblSunday = New System.Windows.Forms.Label()
        Me.lblToday = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.cboCalendars = New AATM.Libraries.CBaseControlsLibrary.CComboBox()
        CType(Me.YearsEdit,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'cboMonths
        '
        Me.cboMonths.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMonths.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMonths.BackColor = System.Drawing.Color.White
        Me.cboMonths.DefaultValue = Nothing
        Me.cboMonths.DisplayOnly = false
        Me.cboMonths.EditingMode = false
        resources.ApplyResources(Me.cboMonths, "cboMonths")
        Me.cboMonths.ForeColor = System.Drawing.Color.Black
        Me.cboMonths.FormattingEnabled = true
        Me.cboMonths.HideWhenNotEditingOrAdding = false
        Me.cboMonths.LinkedLabel = Nothing
        Me.cboMonths.MaximumValue = Nothing
        Me.cboMonths.MinimumValue = Nothing
        Me.cboMonths.Name = "cboMonths"
        Me.cboMonths.OldValue = 0
        Me.cboMonths.OriginalDataSource = Nothing
        Me.cboMonths.OriginalDropDownStyle = 1
        Me.cboMonths.OriginalList = Nothing
        Me.cboMonths.PreviousSelectedIndex = -1
        Me.cboMonths.ReadOnlyCombo = False
        Me.cboMonths.ValueIsMandatory = False
        Me.cboMonths.ValueIsNullable = False
        Me.cboMonths.ValueIsNumeric = False
        '
        'YearsEdit
        '
        resources.ApplyResources(Me.YearsEdit, "YearsEdit")
        Me.YearsEdit.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.YearsEdit.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.YearsEdit.Name = "YearsEdit"
        Me.YearsEdit.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.btnPrevMonth)
        Me.CFlowLayout1.Controls.Add(Me.cboMonths)
        Me.CFlowLayout1.Controls.Add(Me.YearsEdit)
        Me.CFlowLayout1.Controls.Add(Me.btnNextMonth)
        resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
        Me.CFlowLayout1.Name = "CFlowLayout1"
        '
        'btnPrevMonth
        '
        resources.ApplyResources(Me.btnPrevMonth, "btnPrevMonth")
        Me.btnPrevMonth.Name = "btnPrevMonth"
        '
        'btnNextMonth
        '
        resources.ApplyResources(Me.btnNextMonth, "btnNextMonth")
        Me.btnNextMonth.Name = "btnNextMonth"
        '
        'btnCalendarOk
        '
        Me.btnCalendarOk.BackColor = System.Drawing.Color.Lime
        Me.btnCalendarOk.DesignerSelected = False
        Me.btnCalendarOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCalendarOk.DisplayOnly = True
        Me.btnCalendarOk.ImageIndex = 0
        resources.ApplyResources(Me.btnCalendarOk, "btnCalendarOk")
        Me.btnCalendarOk.Name = "btnCalendarOk"
        Me.btnCalendarOk.OriginalImageName = Nothing
        Me.btnCalendarOk.SecurityKey = ""
        '
        'btnCalendarCancel
        '
        Me.btnCalendarCancel.BackColor = System.Drawing.Color.Lime
        Me.btnCalendarCancel.DesignerSelected = False
        Me.btnCalendarCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCalendarCancel.DisplayOnly = True
        resources.ApplyResources(Me.btnCalendarCancel, "btnCalendarCancel")
        Me.btnCalendarCancel.ImageIndex = 0
        Me.btnCalendarCancel.Name = "btnCalendarCancel"
        Me.btnCalendarCancel.OriginalImageName = Nothing
        Me.btnCalendarCancel.SecurityKey = ""
        '
        'lblTodayMark
        '
        resources.ApplyResources(Me.lblTodayMark, "lblTodayMark")
        Me.lblTodayMark.Name = "lblTodayMark"
        '
        'lblThursday
        '
        resources.ApplyResources(Me.lblThursday, "lblThursday")
        Me.lblThursday.Name = "lblThursday"
        '
        'lblFriday
        '
        resources.ApplyResources(Me.lblFriday, "lblFriday")
        Me.lblFriday.Name = "lblFriday"
        '
        'lblWednesday
        '
        resources.ApplyResources(Me.lblWednesday, "lblWednesday")
        Me.lblWednesday.Name = "lblWednesday"
        '
        'lblTuesday
        '
        resources.ApplyResources(Me.lblTuesday, "lblTuesday")
        Me.lblTuesday.Name = "lblTuesday"
        '
        'lblMonday
        '
        Me.lblMonday.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.lblMonday, "lblMonday")
        Me.lblMonday.Name = "lblMonday"
        '
        'lblSaturday
        '
        resources.ApplyResources(Me.lblSaturday, "lblSaturday")
        Me.lblSaturday.Name = "lblSaturday"
        '
        'lblSunday
        '
        resources.ApplyResources(Me.lblSunday, "lblSunday")
        Me.lblSunday.Name = "lblSunday"
        '
        'lblToday
        '
        Me.lblToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.lblToday, "lblToday")
        Me.lblToday.ForeColor = System.Drawing.Color.Black
        Me.lblToday.Name = "lblToday"
        '
        'ShapeContainer1
        '
        resources.ApplyResources(Me.ShapeContainer1, "ShapeContainer1")
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape4, Me.LineShape3, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape4
        '
        resources.ApplyResources(Me.LineShape4, "LineShape4")
        Me.LineShape4.Name = "LineShape4"
        '
        'LineShape3
        '
        resources.ApplyResources(Me.LineShape3, "LineShape3")
        Me.LineShape3.Name = "LineShape3"
        '
        'LineShape2
        '
        resources.ApplyResources(Me.LineShape2, "LineShape2")
        Me.LineShape2.Name = "LineShape2"
        '
        'LineShape1
        '
        resources.ApplyResources(Me.LineShape1, "LineShape1")
        Me.LineShape1.Name = "LineShape1"
        '
        'cboCalendars
        '
        Me.cboCalendars.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCalendars.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCalendars.BackColor = System.Drawing.Color.White
        Me.cboCalendars.DefaultValue = Nothing
        Me.cboCalendars.DisplayOnly = False
        Me.cboCalendars.EditingMode = False
        resources.ApplyResources(Me.cboCalendars, "cboCalendars")
        Me.cboCalendars.ForeColor = System.Drawing.Color.Black
        Me.cboCalendars.FormattingEnabled = True
        Me.cboCalendars.HideWhenNotEditingOrAdding = False
        Me.cboCalendars.LinkedLabel = Nothing
        Me.cboCalendars.MaximumValue = Nothing
        Me.cboCalendars.MinimumValue = Nothing
        Me.cboCalendars.Name = "cboCalendars"
        Me.cboCalendars.OldValue = 0
        Me.cboCalendars.OriginalDataSource = Nothing
        Me.cboCalendars.OriginalDropDownStyle = 1
        Me.cboCalendars.OriginalList = Nothing
        Me.cboCalendars.PreviousSelectedIndex = -1
        Me.cboCalendars.ReadOnlyCombo = false
        Me.cboCalendars.ValueIsMandatory = false
        Me.cboCalendars.ValueIsNullable = false
        Me.cboCalendars.ValueIsNumeric = false
        '
        'CCalendar
        '
        Me.AcceptButton = Me.btnCalendarOk
        Me.BackColor = System.Drawing.Color.LightBlue
        resources.ApplyResources(Me, "$this")
        Me.ControlBox = false
        Me.Controls.Add(Me.cboCalendars)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Controls.Add(Me.btnCalendarOk)
        Me.Controls.Add(Me.btnCalendarCancel)
        Me.Controls.Add(Me.lblTodayMark)
        Me.Controls.Add(Me.lblThursday)
        Me.Controls.Add(Me.lblFriday)
        Me.Controls.Add(Me.lblWednesday)
        Me.Controls.Add(Me.lblTuesday)
        Me.Controls.Add(Me.lblMonday)
        Me.Controls.Add(Me.lblSaturday)
        Me.Controls.Add(Me.lblSunday)
        Me.Controls.Add(Me.lblToday)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CCalendar"
        Me.TopMost = true
        CType(Me.YearsEdit,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.ResumeLayout(false)

    End Sub

    Friend WithEvents cboMonths As CComboBox
    Private WithEvents YearsEdit As Windows.Forms.NumericUpDown
    Friend WithEvents CFlowLayout1 As CFlowLayout
    Private WithEvents btnPrevMonth As Windows.Forms.Button
    Private WithEvents btnNextMonth As Windows.Forms.Button
    Friend WithEvents btnCalendarOk As CButton
    Friend WithEvents btnCalendarCancel As CButton
    Private WithEvents lblTodayMark As Windows.Forms.Label
    Private WithEvents lblThursday As Windows.Forms.Label
    Private WithEvents lblFriday As Windows.Forms.Label
    Private WithEvents lblWednesday As Windows.Forms.Label
    Private WithEvents lblTuesday As Windows.Forms.Label
    Private WithEvents lblMonday As Windows.Forms.Label
    Private WithEvents lblSaturday As Windows.Forms.Label
    Private WithEvents lblSunday As Windows.Forms.Label
    Private WithEvents lblToday As Windows.Forms.Label
    Friend WithEvents cboCalendars As CComboBox
    Private WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Private WithEvents LineShape4 As PowerPacks.LineShape
    Private WithEvents LineShape3 As PowerPacks.LineShape
    Private WithEvents LineShape2 As PowerPacks.LineShape
    Private WithEvents LineShape1 As PowerPacks.LineShape
End Class
