Imports AATM.Libraries.CBaseControlsLibrary

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BfCalendarUmAlQura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BfCalendarUmAlQura))
        Me.lblToday = New System.Windows.Forms.Label()
        Me.lblThursday = New System.Windows.Forms.Label()
        Me.lblFriday = New System.Windows.Forms.Label()
        Me.lblWednesday = New System.Windows.Forms.Label()
        Me.lblTuesday = New System.Windows.Forms.Label()
        Me.lblMonday = New System.Windows.Forms.Label()
        Me.lblSaturday = New System.Windows.Forms.Label()
        Me.lblSunday = New System.Windows.Forms.Label()
        Me.YearsEdit = New System.Windows.Forms.NumericUpDown()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuMonths = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnNext = New System.Windows.Forms.Button()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.lblTodayMark = New System.Windows.Forms.Label()
        Me.btnQuit = New CButton()
        CType(Me.YearsEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuMonths.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblToday
        '
        resources.ApplyResources(Me.lblToday, "lblToday")
        Me.lblToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblToday.ForeColor = System.Drawing.Color.Black
        Me.lblToday.Name = "lblToday"
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
        resources.ApplyResources(Me.lblMonday, "lblMonday")
        Me.lblMonday.FlatStyle = System.Windows.Forms.FlatStyle.Flat
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
        'YearsEdit
        '
        resources.ApplyResources(Me.YearsEdit, "YearsEdit")
        Me.YearsEdit.Maximum = New Decimal(New Integer() {1800, 0, 0, 0})
        Me.YearsEdit.Minimum = New Decimal(New Integer() {1200, 0, 0, 0})
        Me.YearsEdit.Name = "YearsEdit"
        Me.YearsEdit.ReadOnly = True
        Me.YearsEdit.Value = New Decimal(New Integer() {1200, 0, 0, 0})
        '
        'ToolStripMenuItem12
        '
        resources.ApplyResources(Me.ToolStripMenuItem12, "ToolStripMenuItem12")
        Me.ToolStripMenuItem12.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem12.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripMenuItem12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        '
        'ToolStripMenuItem11
        '
        resources.ApplyResources(Me.ToolStripMenuItem11, "ToolStripMenuItem11")
        Me.ToolStripMenuItem11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem11.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripMenuItem11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        '
        'ToolStripMenuItem10
        '
        resources.ApplyResources(Me.ToolStripMenuItem10, "ToolStripMenuItem10")
        Me.ToolStripMenuItem10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem10.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripMenuItem10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        '
        'ToolStripMenuItem9
        '
        resources.ApplyResources(Me.ToolStripMenuItem9, "ToolStripMenuItem9")
        Me.ToolStripMenuItem9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem9.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripMenuItem9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        '
        'ToolStripMenuItem8
        '
        resources.ApplyResources(Me.ToolStripMenuItem8, "ToolStripMenuItem8")
        Me.ToolStripMenuItem8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem8.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripMenuItem8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        '
        'ToolStripMenuItem7
        '
        resources.ApplyResources(Me.ToolStripMenuItem7, "ToolStripMenuItem7")
        Me.ToolStripMenuItem7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem7.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripMenuItem7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        '
        'ToolStripMenuItem6
        '
        resources.ApplyResources(Me.ToolStripMenuItem6, "ToolStripMenuItem6")
        Me.ToolStripMenuItem6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem6.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripMenuItem6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        '
        'ToolStripMenuItem5
        '
        resources.ApplyResources(Me.ToolStripMenuItem5, "ToolStripMenuItem5")
        Me.ToolStripMenuItem5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripMenuItem5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        '
        'ToolStripMenuItem4
        '
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        Me.ToolStripMenuItem4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripMenuItem4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        '
        'ToolStripMenuItem3
        '
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        Me.ToolStripMenuItem3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripMenuItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        '
        'ToolStripMenuItem2
        '
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        Me.ToolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        '
        'ToolStripMenuItem1
        '
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        Me.ToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        '
        'MenuMonths
        '
        resources.ApplyResources(Me.MenuMonths, "MenuMonths")
        Me.MenuMonths.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.ToolStripMenuItem8, Me.ToolStripMenuItem9, Me.ToolStripMenuItem10, Me.ToolStripMenuItem11, Me.ToolStripMenuItem12})
        Me.MenuMonths.Name = "MenuMonths"
        '
        'btnNext
        '
        resources.ApplyResources(Me.btnNext, "btnNext")
        Me.btnNext.Name = "btnNext"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'lblYear
        '
        resources.ApplyResources(Me.lblYear, "lblYear")
        Me.lblYear.ForeColor = System.Drawing.Color.White
        Me.lblYear.Name = "lblYear"
        '
        'btnPrevious
        '
        resources.ApplyResources(Me.btnPrevious, "btnPrevious")
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'lblMonth
        '
        resources.ApplyResources(Me.lblMonth, "lblMonth")
        Me.lblMonth.ContextMenuStrip = Me.MenuMonths
        Me.lblMonth.ForeColor = System.Drawing.Color.White
        Me.lblMonth.Name = "lblMonth"
        '
        'panel1
        '
        resources.ApplyResources(Me.panel1, "panel1")
        Me.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.panel1.Controls.Add(Me.btnNext)
        Me.panel1.Controls.Add(Me.lblYear)
        Me.panel1.Controls.Add(Me.lblMonth)
        Me.panel1.Controls.Add(Me.YearsEdit)
        Me.panel1.Controls.Add(Me.btnPrevious)
        Me.panel1.Name = "panel1"
        '
        'lblTodayMark
        '
        resources.ApplyResources(Me.lblTodayMark, "lblTodayMark")
        Me.lblTodayMark.ForeColor = System.Drawing.Color.Black
        Me.lblTodayMark.Name = "lblTodayMark"
        '
        'btnQuit
        '
        resources.ApplyResources(Me.btnQuit, "btnQuit")
        Me.btnQuit.BackColor = System.Drawing.Color.Transparent
        Me.btnQuit.Name = "btnQuit"
        '
        'BFCalendarUmAlQura
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ControlBox = False
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.lblToday)
        Me.Controls.Add(Me.lblThursday)
        Me.Controls.Add(Me.lblFriday)
        Me.Controls.Add(Me.lblWednesday)
        Me.Controls.Add(Me.lblTuesday)
        Me.Controls.Add(Me.lblMonday)
        Me.Controls.Add(Me.lblSaturday)
        Me.Controls.Add(Me.lblSunday)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.lblTodayMark)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "BFCalendarUmAlQura"
        CType(Me.YearsEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuMonths.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents lblToday As Windows.Forms.Label
    Private WithEvents lblThursday As Windows.Forms.Label
    Private WithEvents lblFriday As Windows.Forms.Label
    Private WithEvents lblWednesday As Windows.Forms.Label
    Private WithEvents lblTuesday As Windows.Forms.Label
    Private WithEvents lblMonday As Windows.Forms.Label
    Private WithEvents lblSaturday As Windows.Forms.Label
    Private WithEvents lblSunday As Windows.Forms.Label
    Private WithEvents YearsEdit As Windows.Forms.NumericUpDown
    Private WithEvents ToolStripMenuItem12 As Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem11 As Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem10 As Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem9 As Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem8 As Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem7 As Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem6 As Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem5 As Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem4 As Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem3 As Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem2 As Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem1 As Windows.Forms.ToolStripMenuItem
    Private WithEvents MenuMonths As Windows.Forms.ContextMenuStrip
    Private WithEvents btnNext As Windows.Forms.Button
    Private WithEvents lblYear As Windows.Forms.Label
    Private WithEvents btnPrevious As Windows.Forms.Button
    Private WithEvents lblMonth As Windows.Forms.Label
    Private WithEvents panel1 As Windows.Forms.Panel
    Private WithEvents lblTodayMark As Windows.Forms.Label
    Friend WithEvents btnQuit As CButton
End Class
