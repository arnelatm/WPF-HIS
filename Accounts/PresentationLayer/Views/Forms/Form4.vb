Imports AATM.Accounts.DataLayer.AdoNet

Public Class Form4


    Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea
        Dim number As Double
        CLabel1.Text = AATM.Libraries.GlobalFuncNSub.DecimalToFraction(number, 32)
        CLabel2.Text = AATM.Libraries.GlobalFuncNSub.RealToFraction(number, 0.0001)
        CLabel3.Text = AATM.Libraries.GlobalFuncNSub.GetDecimalToFraction(number, 32, "U")
        _findText = ""
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ISPDATADataSet.Product' table. You can move, or remove it, as needed.
        Me.ProductTableAdapter.Fill(Me.ISPDATADataSet.Product)
        'TODO: This line of code loads data into the 'ISPDATADataSet.PurchaseDetail' table. You can move, or remove it, as needed.
        Me.PurchaseDetailTableAdapter.Fill(Me.ISPDATADataSet.PurchaseDetail)

        '' for columns    
        'DataGridViewAccGridComboBoxColumn1.ComboDataGridView = ProgramaticalyCreatedDataGridView
        '' selection is done by single click, i.e. not double click
        'DataGridViewAccGridComboBoxColumn1.CloseOnSingleClick = True
        '' binding is trigered on value change, i.e. not on validating
        'DataGridViewAccGridComboBoxColumn1.InstantBinding = True

        '' for comboboxes (second param is CloseOnSingleClick property setter)
        'Dim ProgramaticalyCreatedDataGridView As DataGridView = CreateDataGridViewForPersonInfo()
        'AccGridComboBox1.AddDataGridView(ProgramaticalyCreatedDataGridView, True)
        'AccGridComboBox1.InstantBinding = True

    End Sub

    Private SearchString As String = ""

    'Public Function HighlightText(ByVal InputTxt As String) As String
    '    Dim Search_Str As String = txtSearch.Text
    '    ' Setup the regular expression and add the Or operator.
    '    Dim RegExp As Regex = New Regex(Search_Str.Replace(" ", "|").Trim, RegexOptions.IgnoreCase)
    '    ' Highlight keywords by calling the
    '    'delegate each time a keyword is found.
    '    Return RegExp.Replace(InputTxt, New MatchEvaluator(AddressOf ReplaceKeyWords))
    'End Function

    'Public Function ReplaceKeyWords(ByVal m As Match) As String
    '    Return ("<span class=highlight>" + m.Value + "</span>")
    'End Function

    'Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
    '    '  Set the value of the SearchString so it gets
    '    SearchString = txtSearch.Text
    'End Sub

    'Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
    '    '  Simple clean up text to return the Gridview to it's default state
    '    txtSearch.Text = ""
    '    SearchString = ""
    '    gvDetails.DataBind()
    'End Sub

    Private Sub txtFinder_TextChanged(sender As Object, e As EventArgs) Handles txtFinder.TextChanged
        Dim dao As New ProductDao
        If txtFinder.Text.Length() < 3 Then
            DataGridViewProducts.DataSource = Nothing
        Else
            DataGridViewProducts.DataSource = dao.GetProductsBySearchString(txtFinder.Text)
        End If
        _findText = txtFinder.Text
    End Sub

    Private Sub SubDataGridViewProducts_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles DataGridViewProducts.CellPainting
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 AndAlso DataGridViewProducts.Columns(e.ColumnIndex).Name <> "Id" Then

            If Not String.IsNullOrWhiteSpace(_findText.Trim()) Then
                Dim gridCellValue As String = e.FormattedValue.ToString()
                Dim startIndexInCellValue As Integer = gridCellValue.ToLower().IndexOf(_findText.Trim().ToLower())

                If startIndexInCellValue >= 0 Then
                    e.Handled = True
                    e.PaintBackground(e.CellBounds, True)
                    Dim hl_rect As Rectangle = New Rectangle With {
                        .Y = e.CellBounds.Y + 2,
                        .Height = e.CellBounds.Height - 5
                    }
                    Dim sBeforeSearchword As String = gridCellValue.Substring(0, startIndexInCellValue)
                    Dim sSearchWord As String = gridCellValue.Substring(startIndexInCellValue, _findText.Trim().Length)
                    Dim s1 As Size = TextRenderer.MeasureText(e.Graphics, sBeforeSearchword, e.CellStyle.Font, e.CellBounds.Size)
                    Dim s2 As Size = TextRenderer.MeasureText(e.Graphics, sSearchWord, e.CellStyle.Font, e.CellBounds.Size)

                    If s1.Width > 5 Then
                        hl_rect.X = e.CellBounds.X + s1.Width - 5
                        hl_rect.Width = s2.Width - 6
                    Else
                        hl_rect.X = e.CellBounds.X + 2
                        hl_rect.Width = s2.Width - 6
                    End If

                    Dim hl_brush As SolidBrush
                    hl_brush = New SolidBrush(Color.Yellow)
                    e.Graphics.FillRectangle(hl_brush, hl_rect)
                    hl_brush.Dispose()
                    e.PaintContent(e.CellBounds)
                End If
            End If
        End If
    End Sub

    'Private Sub Dgv_OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewPurchase.CellBeginEdit
    '    If DataGridViewPurchase.CurrentCell.OwningColumn.Name = "ProductName" Then
    '        With DataGridViewPurchase.CurrentCell
    '            Dim cColumnName = .OwningColumn.Name.ToLower()
    '            Dim dao As New ProductDao
    '            If txtFinder.Text.Length() < 3 Then
    '                DataGridViewProducts.DataSource = Nothing
    '            Else
    '                DataGridViewProducts.DataSource = dao.GetProductsBySearchString(txtFinder.Text)
    '            End If
    '        End With
    '    End If
    'End Sub


    Private Sub Dgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPurchase.CellEndEdit
        If DataGridViewPurchase.CurrentCell.OwningColumn.Name = "ProductName" Then
            With DataGridViewPurchase.CurrentCell
                Dim cColumnName = .OwningColumn.Name.ToLower()
                Dim dao As New ProductDao
                _findText = DataGridViewPurchase.CurrentCell.EditedFormattedValue
                If _findText = "" Then
                    DataGridViewProducts.DataSource = Nothing
                Else
                    DataGridViewProducts.DataSource = dao.GetProductsBySearchString(_findText)
                End If
            End With
        End If
    End Sub

    Private _findText As String = ""

    Private Sub Dgv_OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)

    End Sub

    Private Sub Dgv_OnCellBeginEdit(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridViewPurchase_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPurchase.CellValueChanged
        If e.RowIndex >= 0 Then
            Dim newDate As DateTime

            Select Case Me.DataGridViewPurchase.Columns(e.ColumnIndex).Name
                Case "ProductName"
                    Dim newText As String = Me.DataGridViewPurchase.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
                Case "ColumnCombo"
                    Dim newPriority As String = Me.DataGridViewPurchase.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
                Case "ColumnDate"
                    DateTime.TryParse(Me.DataGridViewPurchase.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), newDate)
            End Select
        End If
    End Sub

    Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewPurchase.EditingControlShowing

        e.CellStyle.BackColor = Color.Aquamarine

    End Sub

    Public Function CreateDataGridViewForPersonInfo(ByVal TargetForm As Form, ByVal ListBindingSource As BindingSource) As DataGridView

        ' create the resulting grid and it's columns
        Dim result As New DataGridView
        Dim DataGridViewTextBoxColumn1 As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim DataGridViewTextBoxColumn2 As New System.Windows.Forms.DataGridViewTextBoxColumn

        ' begin initialization (to minimize events)
        CType(result, System.ComponentModel.ISupportInitialize).BeginInit()

        ' setup grid properties as you need
        result.AllowUserToAddRows = False
        result.AllowUserToDeleteRows = False
        result.AutoGenerateColumns = False
        result.AllowUserToResizeRows = False
        result.ColumnHeadersVisible = False
        result.RowHeadersVisible = False
        result.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        result.ReadOnly = True
        result.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        result.Size = New System.Drawing.Size(300, 220)
        result.AutoSize = False

        ' add datasource
        result.DataSource = ListBindingSource

        ' add columns
        result.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
            {DataGridViewTextBoxColumn1, DataGridViewTextBoxColumn2})

        ' setup columns as you need
        DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewTextBoxColumn1.DataPropertyName = "Name"
        DataGridViewTextBoxColumn1.HeaderText = "Name"
        DataGridViewTextBoxColumn1.Name = ""
        DataGridViewTextBoxColumn1.ReadOnly = True

        DataGridViewTextBoxColumn2.DataPropertyName = "Code"
        DataGridViewTextBoxColumn2.HeaderText = "Code"
        DataGridViewTextBoxColumn2.Name = ""
        DataGridViewTextBoxColumn2.ReadOnly = True
        DataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet

        ' assign binding context of the form that hosts
        ' the control in order to enable databinding
        result.BindingContext = TargetForm.BindingContext

        ' end initialization
        CType(result, System.ComponentModel.ISupportInitialize).EndInit()

        Return result
    End Function


End Class

