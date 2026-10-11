Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports AATM.Accounts.ServiceLayer

Namespace PresentationLayer.Views.Forms

    Public Class PayrollJournalPreviewForm
        Inherits Form

        Private ReadOnly _lines As List(Of PayrollJournalPreviewLine)
        Private ReadOnly _isArabic As Boolean
        Private ReadOnly _grid As New DataGridView
        Private ReadOnly _totalsLabel As New Label

        Public Sub New(payrollDescription As String, lines As IEnumerable(Of PayrollJournalPreviewLine), isArabic As Boolean)
            _lines = If(lines Is Nothing, New List(Of PayrollJournalPreviewLine)(), lines.ToList())
            _isArabic = isArabic
            Text = If(_isArabic, "معاينة قيد الرواتب", "Payroll General Journal Preview")
            StartPosition = FormStartPosition.CenterParent
            FormBorderStyle = FormBorderStyle.Sizable
            MinimumSize = New Size(900, 520)
            Size = New Size(1180, 700)
            RightToLeft = If(_isArabic, System.Windows.Forms.RightToLeft.Yes, System.Windows.Forms.RightToLeft.No)
            RightToLeftLayout = _isArabic

            Dim layout As New TableLayoutPanel With {
                .Dock = DockStyle.Fill,
                .ColumnCount = 1,
                .RowCount = 4,
                .Padding = New Padding(10),
                .RightToLeft = If(_isArabic, System.Windows.Forms.RightToLeft.Yes, System.Windows.Forms.RightToLeft.No)
            }
            layout.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            layout.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            layout.RowStyles.Add(New RowStyle(SizeType.AutoSize))

            Dim descriptionLabel As New Label With {
                .AutoSize = True,
                .Dock = DockStyle.Fill,
                .Padding = New Padding(4, 4, 4, 10),
                .Text = If(_isArabic,
                           String.Format("معاينة مسودة قيد اليومية لـ {0}. لن يتم إنشاء القيد أو ترحيله حتى تضغط إنشاء المسودة.", payrollDescription),
                           String.Format("Preview for {0}. No journal is created or posted until you choose Create Draft.", payrollDescription))
            }
            ConfigureGrid()
            _grid.DataSource = _lines

            Dim totalDebit As Decimal = _lines.Sum(Function(line) line.Debit)
            Dim totalCredit As Decimal = _lines.Sum(Function(line) line.Credit)
            _totalsLabel.AutoSize = True
            _totalsLabel.Dock = DockStyle.Fill
            _totalsLabel.Padding = New Padding(4, 8, 4, 8)
            _totalsLabel.TextAlign = ContentAlignment.MiddleRight
            _totalsLabel.Text = If(_isArabic,
                                   String.Format("الإجمالي - مدين: {0:N2}    دائن: {1:N2}", totalDebit, totalCredit),
                                   String.Format("Totals - Debit: {0:N2}    Credit: {1:N2}", totalDebit, totalCredit))

            Dim buttons As New FlowLayoutPanel With {
                .AutoSize = True,
                .Dock = DockStyle.Fill,
                .FlowDirection = If(_isArabic, FlowDirection.LeftToRight, FlowDirection.RightToLeft),
                .WrapContents = False
            }
            Dim createButton As New Button With {
                .AutoSize = True,
                .DialogResult = DialogResult.OK,
                .Text = If(_isArabic, "إنشاء المسودة", "Create Draft")
            }
            Dim cancelButton As New Button With {
                .AutoSize = True,
                .DialogResult = DialogResult.Cancel,
                .Text = If(_isArabic, "إلغاء", "Cancel")
            }
            buttons.Controls.Add(createButton)
            buttons.Controls.Add(cancelButton)
            layout.Controls.Add(descriptionLabel, 0, 0)
            layout.Controls.Add(_grid, 0, 1)
            layout.Controls.Add(_totalsLabel, 0, 2)
            layout.Controls.Add(buttons, 0, 3)
            Controls.Add(layout)
            AcceptButton = createButton
            CancelButton = cancelButton
        End Sub

        Private Sub ConfigureGrid()
            _grid.Dock = DockStyle.Fill
            _grid.ReadOnly = True
            _grid.AllowUserToAddRows = False
            _grid.AllowUserToDeleteRows = False
            _grid.AllowUserToOrderColumns = True
            _grid.AutoGenerateColumns = False
            _grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            _grid.BackgroundColor = SystemColors.Window
            _grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            _grid.MultiSelect = False
            _grid.RowHeadersVisible = False
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            _grid.RightToLeft = If(_isArabic, System.Windows.Forms.RightToLeft.Yes, System.Windows.Forms.RightToLeft.No)
            AddColumn("Sequence", "Sequence", If(_isArabic, "م", "No."), 55)
            AddColumn("AccountCode", "AccountCode", If(_isArabic, "رقم الحساب", "Account Code"), 105)
            AddColumn("AccountName", "AccountName", If(_isArabic, "اسم الحساب", "Account Name"), 230)
            AddColumn("EmployeeName", "EmployeeName", If(_isArabic, "الموظف", "Employee"), 190)
            AddColumn("RevCostCenterCode", "RevCostCenterCode", If(_isArabic, "رمز مركز التكلفة", "Cost Center Code"), 125)
            AddColumn("RevCostCenterName", "RevCostCenterName", If(_isArabic, "مركز التكلفة", "Cost Center"), 180)
            AddColumn("Debit", "Debit", If(_isArabic, "مدين", "Debit"), 115, "N2")
            AddColumn("Credit", "Credit", If(_isArabic, "دائن", "Credit"), 115, "N2")
        End Sub

        Private Sub AddColumn(name As String, dataPropertyName As String, headerText As String, width As Integer, Optional format As String = Nothing)
            Dim column As New DataGridViewTextBoxColumn With {
                .Name = name,
                .DataPropertyName = dataPropertyName,
                .HeaderText = headerText,
                .Width = width,
                .SortMode = DataGridViewColumnSortMode.NotSortable
            }
            If Not String.IsNullOrEmpty(format) Then
                column.DefaultCellStyle.Format = format
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            _grid.Columns.Add(column)
        End Sub
    End Class

End Namespace