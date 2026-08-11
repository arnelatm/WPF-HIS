Public Class Form2
    Dim dtDateTest As New DataTable
    Dim WithEvents dbDateTest As New BindingSource

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtDateTest = New DataTable
        GDateTimePicker1.DataBindings.Clear()
        GTimePicker1.DataBindings.Clear()

        dtDateTest.Columns.Add("Date", GetType(DateTime))
        dtDateTest.Columns.Add("Time", GetType(String))
        dtDateTest.Columns.Add("Name", GetType(String))
        dtDateTest.Columns("Date").AllowDBNull = True
        dtDateTest.Columns("Time").AllowDBNull = True
        Dim i As Integer = 1
        For Each wx As String In New String() {"Carl Denham", "Jack Driscoll", "Ann Darrow", _
            "Captain Englehorn", "Bruce Baxter", "Preston"}
            Dim rw As DataRow = dtDateTest.NewRow
            rw.Item("Date") = Choose(i, Today, #10/17/2000#, DBNull.Value, #3/27/1998#, DBNull.Value, DBNull.Value)
            rw.Item("Time") = Choose(i, Format(Now, "hh:mm"), "04:00", DBNull.Value, "21:00", "03:15", DBNull.Value)
            rw.Item("Name") = wx
            dtDateTest.Rows.Add(rw)
            i += 1
        Next
        dbDateTest.DataSource = dtDateTest
        With DataGridView1
            .DataSource = dbDateTest
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToAddRows = False
        End With

        GTimePicker1.DataBindings.Add("Time", dbDateTest, "Time", True, DataSourceUpdateMode.OnPropertyChanged)
        GDateTimePicker1.DataBindings.Add("gValue", dbDateTest, "Date", True, DataSourceUpdateMode.OnValidation Or DataSourceUpdateMode.OnPropertyChanged)

    End Sub

    Private Sub GDateTimePicker1_ValueOrNullChanged(ByVal sender As System.Object) Handles GDateTimePicker1.ValueOrNullChanged
        GDateTimePicker1.DataBindings.Item("gValue").WriteValue()
        SetDateNullText()
    End Sub

    Private Sub SetDateNullText()
        Try
            GDateTimePicker1.NullText = String.Format("{0} Has No Date", DataGridView1.SelectedCells.Item(2).Value.ToString)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dbDateTest_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbDateTest.PositionChanged
        Dim currRow As DataRowView = dbDateTest.Current
        If currRow.Item(0) Is DBNull.Value Then SetDateNullText()

    End Sub

End Class