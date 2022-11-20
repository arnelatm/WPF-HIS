Public Class TestForm3

    Private dt As DataTable = New DataTable()

    Private Sub Main_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        dt.Columns.Add("colCustomers", GetType(String))
        dt.Rows.Add(New Object() {"1 John"})
        dt.Rows.Add(New Object() {"2 Kate"})
        dt.Rows.Add(New Object() {"3 Jill"})
        dt.Rows.Add(New Object() {"4 arnel"})
        dt.Rows.Add(New Object() {"5 May"})
        dt.Rows.Add(New Object() {"6 Janu"})
        dt.Rows.Add(New Object() {"7 Seatiel"})
        ComboBox1.DataSource = dt.DefaultView
        ComboBox1.DisplayMember = "ColCustomers"
    End Sub

    Private Sub comboBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox1.TextChanged
        If ComboBox1.SelectedIndex = -1 Then
            dt.DefaultView.RowFilter = "colCustomers LIKE '%" & ComboBox1.Text & "%'"
        End If
    End Sub


End Class