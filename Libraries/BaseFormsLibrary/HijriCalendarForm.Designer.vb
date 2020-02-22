Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class HijriCalendarForm
    Inherits CModalForm

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New Container()
        Me.panel1 = New Panel()
        Me.btnNext = New Button()
        Me.lblYear = New Label()
        Me.btnPrevious = New Button()
        Me.lblMonth = New Label()
        Me.MenuMonths = New ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New ToolStripMenuItem()
        Me.YearsEdit = New NumericUpDown()
        Me.lblToday = New Label()
        Me.lblThursday = New Label()
        Me.lblFriday = New Label()
        Me.lblWednesday = New Label()
        Me.lblTuesday = New Label()
        Me.lblMonday = New Label()
        Me.lblSaturday = New Label()
        Me.lblTodayMark = New Label()
        Me.lblSunday = New Label()
        Me.panel1.SuspendLayout()
        Me.MenuMonths.SuspendLayout()
        CType(Me.YearsEdit, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.BackColor = SystemColors.ActiveCaption
        Me.panel1.Controls.Add(Me.btnNext)
        Me.panel1.Controls.Add(Me.lblYear)
        Me.panel1.Controls.Add(Me.btnPrevious)
        Me.panel1.Controls.Add(Me.lblMonth)
        Me.panel1.Controls.Add(Me.YearsEdit)
        Me.panel1.Location = New Point(2, 2)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New Size(216, 32)
        Me.panel1.TabIndex = 29
        '
        'btnNext
        '
        Me.btnNext.Font = New Font("Tahoma", 8.0!, FontStyle.Bold)
        Me.btnNext.Location = New Point(4, 4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New Size(36, 23)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "<"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'lblYear
        '
        Me.lblYear.Font = New Font("Tahoma", 8.0!, FontStyle.Bold)
        Me.lblYear.ForeColor = Color.White
        Me.lblYear.Location = New Point(39, 0)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New Size(51, 32)
        Me.lblYear.TabIndex = 3
        Me.lblYear.Text = "1428"
        Me.lblYear.TextAlign = ContentAlignment.MiddleCenter
        '
        'btnPrevious
        '
        Me.btnPrevious.Font = New Font("Tahoma", 8.0!, FontStyle.Bold)
        Me.btnPrevious.Location = New Point(172, 4)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New Size(36, 23)
        Me.btnPrevious.TabIndex = 1
        Me.btnPrevious.Text = ">"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'lblMonth
        '
        Me.lblMonth.ContextMenuStrip = Me.MenuMonths
        Me.lblMonth.Font = New Font("Tahoma", 8.0!, FontStyle.Bold)
        Me.lblMonth.ForeColor = Color.White
        Me.lblMonth.Location = New Point(91, -2)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New Size(82, 32)
        Me.lblMonth.TabIndex = 0
        Me.lblMonth.Text = "الشهر"
        Me.lblMonth.TextAlign = ContentAlignment.MiddleCenter
        '
        'MenuMonths
        '
        Me.MenuMonths.BackgroundImageLayout = ImageLayout.None
        Me.MenuMonths.Items.AddRange(New ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.ToolStripMenuItem8, Me.ToolStripMenuItem9, Me.ToolStripMenuItem10, Me.ToolStripMenuItem11, Me.ToolStripMenuItem12})
        Me.MenuMonths.Name = "MenuMonths"
        Me.MenuMonths.Size = New Size(127, 268)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Alignment = ToolStripItemAlignment.Right
        Me.ToolStripMenuItem1.BackColor = SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem1.BackgroundImageLayout = ImageLayout.None
        Me.ToolStripMenuItem1.DisplayStyle = ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New Size(126, 22)
        Me.ToolStripMenuItem1.Text = "محرم"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Alignment = ToolStripItemAlignment.Right
        Me.ToolStripMenuItem2.BackColor = SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem2.BackgroundImageLayout = ImageLayout.None
        Me.ToolStripMenuItem2.DisplayStyle = ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New Size(126, 22)
        Me.ToolStripMenuItem2.Text = "صفر"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Alignment = ToolStripItemAlignment.Right
        Me.ToolStripMenuItem3.BackColor = SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem3.BackgroundImageLayout = ImageLayout.None
        Me.ToolStripMenuItem3.DisplayStyle = ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New Size(126, 22)
        Me.ToolStripMenuItem3.Text = "ربيع أول"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Alignment = ToolStripItemAlignment.Right
        Me.ToolStripMenuItem4.BackColor = SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem4.BackgroundImageLayout = ImageLayout.None
        Me.ToolStripMenuItem4.DisplayStyle = ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New Size(126, 22)
        Me.ToolStripMenuItem4.Text = "ربيع ثاني"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Alignment = ToolStripItemAlignment.Right
        Me.ToolStripMenuItem5.BackColor = SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem5.BackgroundImageLayout = ImageLayout.None
        Me.ToolStripMenuItem5.DisplayStyle = ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New Size(126, 22)
        Me.ToolStripMenuItem5.Text = "جمادي أول"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Alignment = ToolStripItemAlignment.Right
        Me.ToolStripMenuItem6.BackColor = SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem6.BackgroundImageLayout = ImageLayout.None
        Me.ToolStripMenuItem6.DisplayStyle = ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New Size(126, 22)
        Me.ToolStripMenuItem6.Text = "جمادي ثان"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Alignment = ToolStripItemAlignment.Right
        Me.ToolStripMenuItem7.BackColor = SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem7.BackgroundImageLayout = ImageLayout.None
        Me.ToolStripMenuItem7.DisplayStyle = ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New Size(126, 22)
        Me.ToolStripMenuItem7.Text = "رجب"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Alignment = ToolStripItemAlignment.Right
        Me.ToolStripMenuItem8.BackColor = SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem8.BackgroundImageLayout = ImageLayout.None
        Me.ToolStripMenuItem8.DisplayStyle = ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New Size(126, 22)
        Me.ToolStripMenuItem8.Text = "شعبان"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Alignment = ToolStripItemAlignment.Right
        Me.ToolStripMenuItem9.BackColor = SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem9.BackgroundImageLayout = ImageLayout.None
        Me.ToolStripMenuItem9.DisplayStyle = ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New Size(126, 22)
        Me.ToolStripMenuItem9.Text = "رمضان"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Alignment = ToolStripItemAlignment.Right
        Me.ToolStripMenuItem10.BackColor = SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem10.BackgroundImageLayout = ImageLayout.None
        Me.ToolStripMenuItem10.DisplayStyle = ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New Size(126, 22)
        Me.ToolStripMenuItem10.Text = "شوال"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Alignment = ToolStripItemAlignment.Right
        Me.ToolStripMenuItem11.BackColor = SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem11.BackgroundImageLayout = ImageLayout.None
        Me.ToolStripMenuItem11.DisplayStyle = ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New Size(126, 22)
        Me.ToolStripMenuItem11.Text = "ذو القعدة"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Alignment = ToolStripItemAlignment.Right
        Me.ToolStripMenuItem12.BackColor = SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem12.BackgroundImageLayout = ImageLayout.None
        Me.ToolStripMenuItem12.DisplayStyle = ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New Size(126, 22)
        Me.ToolStripMenuItem12.Text = "ذو الحجة"
        '
        'YearsEdit
        '
        Me.YearsEdit.Font = New Font("Tahoma", 8.0!, FontStyle.Bold)
        Me.YearsEdit.Location = New Point(42, 6)
        Me.YearsEdit.Maximum = New Decimal(New Integer() {1800, 0, 0, 0})
        Me.YearsEdit.Minimum = New Decimal(New Integer() {1200, 0, 0, 0})
        Me.YearsEdit.Name = "YearsEdit"
        Me.YearsEdit.ReadOnly = True
        Me.YearsEdit.Size = New Size(49, 20)
        Me.YearsEdit.TabIndex = 4
        Me.YearsEdit.Value = New Decimal(New Integer() {1200, 0, 0, 0})
        Me.YearsEdit.Visible = False
        '
        'lblToday
        '
        Me.lblToday.Font = New Font("Tahoma", 8.0!, FontStyle.Bold)
        Me.lblToday.ForeColor = Color.Black
        Me.lblToday.Location = New Point(25, 152)
        Me.lblToday.Name = "lblToday"
        Me.lblToday.Size = New Size(160, 19)
        Me.lblToday.TabIndex = 24
        Me.lblToday.TextAlign = ContentAlignment.MiddleRight
        '
        'lblThursday
        '
        Me.lblThursday.Font = New Font("Tahoma", 7.0!)
        Me.lblThursday.Location = New Point(31, 34)
        Me.lblThursday.Margin = New Padding(0)
        Me.lblThursday.Name = "lblThursday"
        Me.lblThursday.Size = New Size(30, 17)
        Me.lblThursday.TabIndex = 28
        Me.lblThursday.Text = "خميس"
        Me.lblThursday.TextAlign = ContentAlignment.MiddleCenter
        '
        'lblFriday
        '
        Me.lblFriday.Font = New Font("Tahoma", 7.0!)
        Me.lblFriday.Location = New Point(0, 34)
        Me.lblFriday.Margin = New Padding(0)
        Me.lblFriday.Name = "lblFriday"
        Me.lblFriday.Size = New Size(30, 17)
        Me.lblFriday.TabIndex = 27
        Me.lblFriday.Text = "جمعة"
        Me.lblFriday.TextAlign = ContentAlignment.MiddleCenter
        '
        'lblWednesday
        '
        Me.lblWednesday.Font = New Font("Tahoma", 7.0!)
        Me.lblWednesday.Location = New Point(62, 34)
        Me.lblWednesday.Margin = New Padding(0)
        Me.lblWednesday.Name = "lblWednesday"
        Me.lblWednesday.Size = New Size(30, 17)
        Me.lblWednesday.TabIndex = 26
        Me.lblWednesday.Text = "اربعاء"
        Me.lblWednesday.TextAlign = ContentAlignment.MiddleCenter
        '
        'lblTuesday
        '
        Me.lblTuesday.Font = New Font("Tahoma", 7.0!)
        Me.lblTuesday.Location = New Point(93, 34)
        Me.lblTuesday.Margin = New Padding(0)
        Me.lblTuesday.Name = "lblTuesday"
        Me.lblTuesday.Size = New Size(30, 17)
        Me.lblTuesday.TabIndex = 25
        Me.lblTuesday.Text = "ثلاثاء"
        Me.lblTuesday.TextAlign = ContentAlignment.MiddleCenter
        '
        'lblMonday
        '
        Me.lblMonday.FlatStyle = FlatStyle.Flat
        Me.lblMonday.Font = New Font("Tahoma", 7.0!)
        Me.lblMonday.Location = New Point(124, 34)
        Me.lblMonday.Margin = New Padding(0)
        Me.lblMonday.Name = "lblMonday"
        Me.lblMonday.Size = New Size(30, 17)
        Me.lblMonday.TabIndex = 23
        Me.lblMonday.Text = "اٌثنين"
        Me.lblMonday.TextAlign = ContentAlignment.MiddleCenter
        '
        'lblSaturday
        '
        Me.lblSaturday.Font = New Font("Tahoma", 7.0!)
        Me.lblSaturday.Location = New Point(186, 34)
        Me.lblSaturday.Margin = New Padding(0)
        Me.lblSaturday.Name = "lblSaturday"
        Me.lblSaturday.Size = New Size(30, 17)
        Me.lblSaturday.TabIndex = 21
        Me.lblSaturday.Text = "سبت"
        Me.lblSaturday.TextAlign = ContentAlignment.MiddleCenter
        '
        'lblTodayMark
        '
        Me.lblTodayMark.Font = New Font("Tahoma", 8.0!, FontStyle.Bold)
        Me.lblTodayMark.ForeColor = Color.Black
        Me.lblTodayMark.Location = New Point(187, 152)
        Me.lblTodayMark.Name = "lblTodayMark"
        Me.lblTodayMark.Size = New Size(14, 15)
        Me.lblTodayMark.TabIndex = 30
        Me.lblTodayMark.TextAlign = ContentAlignment.MiddleCenter
        '
        'lblSunday
        '
        Me.lblSunday.Font = New Font("Tahoma", 7.0!)
        Me.lblSunday.Location = New Point(155, 34)
        Me.lblSunday.Margin = New Padding(0)
        Me.lblSunday.Name = "lblSunday"
        Me.lblSunday.Size = New Size(30, 17)
        Me.lblSunday.TabIndex = 22
        Me.lblSunday.Text = "اٌحد"
        Me.lblSunday.TextAlign = ContentAlignment.MiddleCenter
        '
        'HijriCalendarForm
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.ClientSize = New Size(221, 181)
        Me.ControlBox = False
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.lblToday)
        Me.Controls.Add(Me.lblThursday)
        Me.Controls.Add(Me.lblFriday)
        Me.Controls.Add(Me.lblWednesday)
        Me.Controls.Add(Me.lblTuesday)
        Me.Controls.Add(Me.lblMonday)
        Me.Controls.Add(Me.lblSaturday)
        Me.Controls.Add(Me.lblTodayMark)
        Me.Controls.Add(Me.lblSunday)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New Size(220, 174)
        Me.Name = "HijriCalendarForm"
        Me.ShowIcon = False
        Me.SizeGripStyle = SizeGripStyle.Hide
        Me.StartPosition = FormStartPosition.Manual
        Me.TopMost = True
        Me.panel1.ResumeLayout(False)
        Me.MenuMonths.ResumeLayout(False)
        CType(Me.YearsEdit, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents panel1 As Panel
    Private WithEvents btnNext As Button
    Private WithEvents lblYear As Label
    Private WithEvents btnPrevious As Button
    Private WithEvents lblMonth As Label
    Private WithEvents MenuMonths As ContextMenuStrip
    Private WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem6 As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem7 As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem8 As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem9 As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem10 As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem11 As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem12 As ToolStripMenuItem
    Private WithEvents YearsEdit As NumericUpDown
    Private WithEvents lblToday As Label
    Private WithEvents lblThursday As Label
    Private WithEvents lblFriday As Label
    Private WithEvents lblWednesday As Label
    Private WithEvents lblTuesday As Label
    Private WithEvents lblMonday As Label
    Private WithEvents lblSaturday As Label
    Private WithEvents lblTodayMark As Label
    Private WithEvents lblSunday As Label
End Class
