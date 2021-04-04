<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CHijriCalendar
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
        Me.lblTodayMark = New System.Windows.Forms.Label()
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
        Me.lblYear = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.lblToday = New System.Windows.Forms.Label()
        Me.lblThursday = New System.Windows.Forms.Label()
        Me.lblFriday = New System.Windows.Forms.Label()
        Me.lblWednesday = New System.Windows.Forms.Label()
        Me.lblTuesday = New System.Windows.Forms.Label()
        Me.lblMonday = New System.Windows.Forms.Label()
        Me.lblSunday = New System.Windows.Forms.Label()
        Me.lblSaturday = New System.Windows.Forms.Label()
        CType(Me.YearsEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuMonths.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTodayMark
        '
        Me.lblTodayMark.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTodayMark.ForeColor = System.Drawing.Color.Black
        Me.lblTodayMark.Location = New System.Drawing.Point(190, 153)
        Me.lblTodayMark.Name = "lblTodayMark"
        Me.lblTodayMark.Size = New System.Drawing.Size(14, 15)
        Me.lblTodayMark.TabIndex = 20
        Me.lblTodayMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'YearsEdit
        '
        Me.YearsEdit.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.YearsEdit.Location = New System.Drawing.Point(44, 7)
        Me.YearsEdit.Maximum = New Decimal(New Integer() {1800, 0, 0, 0})
        Me.YearsEdit.Minimum = New Decimal(New Integer() {1200, 0, 0, 0})
        Me.YearsEdit.Name = "YearsEdit"
        Me.YearsEdit.ReadOnly = True
        Me.YearsEdit.Size = New System.Drawing.Size(49, 20)
        Me.YearsEdit.TabIndex = 4
        Me.YearsEdit.Value = New Decimal(New Integer() {1200, 0, 0, 0})
        Me.YearsEdit.Visible = False
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem12.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripMenuItem12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem12.Text = "ذو الحجة"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem11.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripMenuItem11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem11.Text = "ذو القعدة"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem10.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripMenuItem10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem10.Text = "شوال"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem9.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripMenuItem9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem9.Text = "رمضان"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem8.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripMenuItem8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem8.Text = "شعبان"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem7.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripMenuItem7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem7.Text = "رجب"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem6.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripMenuItem6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem6.Text = "جمادي ثان"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem5.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripMenuItem5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem5.Text = "جمادي أول"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem4.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripMenuItem4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem4.Text = "ربيع ثاني"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem3.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripMenuItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem3.Text = "ربيع أول"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem2.Text = "صفر"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripMenuItem1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem1.Text = "محرم"
        '
        'MenuMonths
        '
        Me.MenuMonths.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MenuMonths.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.ToolStripMenuItem8, Me.ToolStripMenuItem9, Me.ToolStripMenuItem10, Me.ToolStripMenuItem11, Me.ToolStripMenuItem12})
        Me.MenuMonths.Name = "MenuMonths"
        Me.MenuMonths.Size = New System.Drawing.Size(127, 268)
        '
        'lblYear
        '
        Me.lblYear.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblYear.ForeColor = System.Drawing.Color.White
        Me.lblYear.Location = New System.Drawing.Point(41, 1)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(51, 32)
        Me.lblYear.TabIndex = 3
        Me.lblYear.Text = "1428"
        Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnNext.Location = New System.Drawing.Point(6, 5)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(36, 23)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "<"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrevious.Location = New System.Drawing.Point(174, 5)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(36, 23)
        Me.btnPrevious.TabIndex = 1
        Me.btnPrevious.Text = ">"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'lblMonth
        '
        Me.lblMonth.ContextMenuStrip = Me.MenuMonths
        Me.lblMonth.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblMonth.ForeColor = System.Drawing.Color.White
        Me.lblMonth.Location = New System.Drawing.Point(93, -1)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(82, 32)
        Me.lblMonth.TabIndex = 0
        Me.lblMonth.Text = "الشهر"
        Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.panel1.Controls.Add(Me.btnNext)
        Me.panel1.Controls.Add(Me.lblYear)
        Me.panel1.Controls.Add(Me.btnPrevious)
        Me.panel1.Controls.Add(Me.lblMonth)
        Me.panel1.Controls.Add(Me.YearsEdit)
        Me.panel1.Location = New System.Drawing.Point(5, 3)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(216, 32)
        Me.panel1.TabIndex = 19
        '
        'lblToday
        '
        Me.lblToday.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblToday.ForeColor = System.Drawing.Color.Black
        Me.lblToday.Location = New System.Drawing.Point(28, 153)
        Me.lblToday.Name = "lblToday"
        Me.lblToday.Size = New System.Drawing.Size(160, 19)
        Me.lblToday.TabIndex = 14
        Me.lblToday.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblThursday
        '
        Me.lblThursday.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.lblThursday.Location = New System.Drawing.Point(34, 35)
        Me.lblThursday.Margin = New System.Windows.Forms.Padding(0)
        Me.lblThursday.Name = "lblThursday"
        Me.lblThursday.Size = New System.Drawing.Size(30, 17)
        Me.lblThursday.TabIndex = 18
        Me.lblThursday.Text = "خميس"
        Me.lblThursday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFriday
        '
        Me.lblFriday.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.lblFriday.Location = New System.Drawing.Point(3, 35)
        Me.lblFriday.Margin = New System.Windows.Forms.Padding(0)
        Me.lblFriday.Name = "lblFriday"
        Me.lblFriday.Size = New System.Drawing.Size(30, 17)
        Me.lblFriday.TabIndex = 17
        Me.lblFriday.Text = "جمعة"
        Me.lblFriday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblWednesday
        '
        Me.lblWednesday.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.lblWednesday.Location = New System.Drawing.Point(65, 35)
        Me.lblWednesday.Margin = New System.Windows.Forms.Padding(0)
        Me.lblWednesday.Name = "lblWednesday"
        Me.lblWednesday.Size = New System.Drawing.Size(30, 17)
        Me.lblWednesday.TabIndex = 16
        Me.lblWednesday.Text = "اربعاء"
        Me.lblWednesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTuesday
        '
        Me.lblTuesday.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.lblTuesday.Location = New System.Drawing.Point(96, 35)
        Me.lblTuesday.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTuesday.Name = "lblTuesday"
        Me.lblTuesday.Size = New System.Drawing.Size(30, 17)
        Me.lblTuesday.TabIndex = 15
        Me.lblTuesday.Text = "ثلاثاء"
        Me.lblTuesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonday
        '
        Me.lblMonday.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblMonday.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.lblMonday.Location = New System.Drawing.Point(127, 35)
        Me.lblMonday.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMonday.Name = "lblMonday"
        Me.lblMonday.Size = New System.Drawing.Size(30, 17)
        Me.lblMonday.TabIndex = 13
        Me.lblMonday.Text = "اٌثنين"
        Me.lblMonday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSunday
        '
        Me.lblSunday.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.lblSunday.Location = New System.Drawing.Point(158, 35)
        Me.lblSunday.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSunday.Name = "lblSunday"
        Me.lblSunday.Size = New System.Drawing.Size(30, 17)
        Me.lblSunday.TabIndex = 12
        Me.lblSunday.Text = "اٌحد"
        Me.lblSunday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSaturday
        '
        Me.lblSaturday.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.lblSaturday.Location = New System.Drawing.Point(189, 35)
        Me.lblSaturday.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSaturday.Name = "lblSaturday"
        Me.lblSaturday.Size = New System.Drawing.Size(30, 17)
        Me.lblSaturday.TabIndex = 11
        Me.lblSaturday.Text = "سبت"
        Me.lblSaturday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TdpHijriDatePicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblTodayMark)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.lblToday)
        Me.Controls.Add(Me.lblThursday)
        Me.Controls.Add(Me.lblFriday)
        Me.Controls.Add(Me.lblWednesday)
        Me.Controls.Add(Me.lblTuesday)
        Me.Controls.Add(Me.lblMonday)
        Me.Controls.Add(Me.lblSunday)
        Me.Controls.Add(Me.lblSaturday)
        Me.Name = "TdpHijriDatePicker"
        Me.Size = New System.Drawing.Size(225, 215)
        CType(Me.YearsEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuMonths.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents lblTodayMark As Windows.Forms.Label
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
    Private WithEvents lblYear As Windows.Forms.Label
    Private WithEvents btnNext As Windows.Forms.Button
    Private WithEvents btnPrevious As Windows.Forms.Button
    Private WithEvents lblMonth As Windows.Forms.Label
    Private WithEvents panel1 As Windows.Forms.Panel
    Private WithEvents lblToday As Windows.Forms.Label
    Private WithEvents lblThursday As Windows.Forms.Label
    Private WithEvents lblFriday As Windows.Forms.Label
    Private WithEvents lblWednesday As Windows.Forms.Label
    Private WithEvents lblTuesday As Windows.Forms.Label
    Private WithEvents lblMonday As Windows.Forms.Label
    Private WithEvents lblSunday As Windows.Forms.Label
    Private WithEvents lblSaturday As Windows.Forms.Label
End Class
