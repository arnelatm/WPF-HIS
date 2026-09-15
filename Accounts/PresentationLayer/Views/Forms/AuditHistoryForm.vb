Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Views.Forms

    Public Class AuditHistoryForm
        Inherits Form

        Private ReadOnly _fromDate As New DateTimePicker()
        Private ReadOnly _toDate As New DateTimePicker()
        Private ReadOnly _entity As New ComboBox()
        Private ReadOnly _action As New ComboBox()
        Private ReadOnly _recordId As New TextBox()
        Private ReadOnly _reference As New TextBox()
        Private ReadOnly _search As New Button()
        Private ReadOnly _grid As New DataGridView()
        Private ReadOnly _service As New AuditHistoryService()

        Public Sub New()
            Text = If(GlobalVariables.RightToLeftLayout, "سجل تحديث البيانات", "Data Update History")
            Width = 1250
            Height = 700
            StartPosition = FormStartPosition.CenterParent
            RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
            RightToLeftLayout = GlobalVariables.RightToLeftLayout
            BuildFilters()
            BuildGrid()
            AddHandler Load, Sub(sender, e) LoadHistory()
        End Sub

        Private Sub BuildFilters()
            Dim panel As New FlowLayoutPanel With {.Dock = DockStyle.Top, .Height = 72, .Padding = New Padding(8), .WrapContents = True}
            _fromDate.Format = DateTimePickerFormat.Short
            _toDate.Format = DateTimePickerFormat.Short
            _fromDate.Value = Date.Today.AddDays(-30)
            _toDate.Value = Date.Today
            AddFilter(panel, "From", _fromDate)
            AddFilter(panel, "To", _toDate)
            AddFilter(panel, "Entity", _entity)
            AddFilter(panel, "Action", _action)
            AddFilter(panel, "Record ID", _recordId)
            AddFilter(panel, "Reference", _reference)
            _entity.Items.AddRange(New Object() {"", "Account", "Customer", "Supplier", "GeneralJournal", "ApJournal", "ArJournal", "CashReceiptJournal", "CdJournal", "SalesJournal", "ErJournal"})
            _action.Items.AddRange(New Object() {"", "Insert", "Update", "Delete", "Post", "Approve", "Cancel"})
            _entity.DropDownStyle = ComboBoxStyle.DropDownList
            _action.DropDownStyle = ComboBoxStyle.DropDownList
            _entity.SelectedIndex = 0
            _action.SelectedIndex = 0
            _search.Text = If(GlobalVariables.RightToLeftLayout, "بحث", "Search")
            _search.AutoSize = True
            AddHandler _search.Click, Sub(sender, e) LoadHistory()
            panel.Controls.Add(_search)
            Controls.Add(panel)
        End Sub

        Private Shared Sub AddFilter(panel As FlowLayoutPanel, caption As String, control As Control)
            panel.Controls.Add(New Label With {.Text = caption, .AutoSize = True, .Margin = New Padding(8, 9, 2, 0)})
            control.Width = If(TypeOf control Is DateTimePicker, 100, 125)
            panel.Controls.Add(control)
        End Sub

        Private Sub BuildGrid()
            _grid.Dock = DockStyle.Fill
            _grid.ReadOnly = True
            _grid.AllowUserToAddRows = False
            _grid.AllowUserToDeleteRows = False
            _grid.AutoGenerateColumns = True
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            _grid.MultiSelect = False
            Controls.Add(_grid)
            ' Dock Fill must be in front of the top filter panel so it uses
            ' the remaining area instead of hiding its first rows underneath it.
            _grid.BringToFront()
        End Sub

        Private Sub LoadHistory()
            Try
                Dim fromUtc = _fromDate.Value.Date.ToUniversalTime()
                Dim toUtc = _toDate.Value.Date.AddDays(1).ToUniversalTime()
                Dim recordId As Integer? = Nothing
                Dim parsedId As Integer
                If Integer.TryParse(_recordId.Text.Trim(), parsedId) Then recordId = parsedId
                _grid.DataSource = _service.GetHistory(fromUtc, toUtc, Nothing,
                    Convert.ToString(_entity.SelectedItem), Convert.ToString(_action.SelectedItem),
                    recordId, _reference.Text.Trim(), 10000)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Audit History", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class

End Namespace
