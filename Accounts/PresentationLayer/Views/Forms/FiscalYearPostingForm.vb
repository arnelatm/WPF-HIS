Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms

    Partial Public Class FiscalYearPostingForm
        Inherits BFMain

        Private _lastPreview As DataSet

        Public Sub New()
            InitializeComponent()
            AddHandler _previewButton.Click, AddressOf PreviewButton_Click
            AddHandler _executeButton.Click, AddressOf ExecuteButton_Click
            AddHandler _closeButton.Click, Sub(sender, e) Close()
            AddHandler _monthlyButton.Click,
                Sub(sender, e)
                    Using monthlyForm As New MonthlyPostingForm()
                        monthlyForm.ShowDialog(Me)
                    End Using
                End Sub
            _fiscalYear.Value = Math.Max(_fiscalYear.Minimum, Date.Today.Year - 1)
            _executeButton.Enabled = False
        End Sub

        Private Sub PreviewButton_Click(sender As Object, e As EventArgs)
            LoadPosting(False)
        End Sub

        Private Sub ExecuteButton_Click(sender As Object, e As EventArgs)
            If _lastPreview Is Nothing OrElse _lastPreview.Tables.Count = 0 Then
                MessageBox.Show("Run Preview before executing posting.", "Fiscal-Year Posting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If MessageBox.Show(
                    "This will mark all currently unposted journal headers and items in fiscal year " & _fiscalYear.Value.ToString() & " as Posted." & Environment.NewLine &
                    "The operation is audited and cannot be undone by this screen. Continue?",
                    "Confirm fiscal-year posting", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
                Return
            End If

            LoadPosting(True)
        End Sub

        Private Sub LoadPosting(executePosting As Boolean)
            Try
                Cursor = Cursors.WaitCursor
                Dim data = ExecutePostingProcedure(executePosting)

                _lastPreview = data
                BindResults(data)

                If executePosting Then
                    _executeButton.Enabled = False
                    _statusLabel.Text = "Posting completed. Run Preview again to verify the final state."
                Else
                    Dim blockingErrors = GetInt(data, 0, "BlockingErrors")
                    Dim headersToPost = GetInt(data, 0, "HeadersToPost")
                    Dim itemsToPost = GetInt(data, 0, "ItemsToPost")
                    _executeButton.Enabled = blockingErrors = 0 AndAlso (headersToPost > 0 OrElse itemsToPost > 0)
                    _statusLabel.Text = String.Format(
                        "Blocking errors: {0}; headers to post: {1}; items to post: {2}",
                        blockingErrors, headersToPost, itemsToPost)
                End If
            Catch ex As Exception
                _executeButton.Enabled = False
                _statusLabel.Text = "Posting request failed."
                MessageBox.Show(ex.Message, "Fiscal-Year Posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Function ExecutePostingProcedure(executePosting As Boolean) As DataSet
            Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                Using command As New SqlCommand("dbo.PostFiscalYearJournalEntries", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.CommandTimeout = 120
                    command.Parameters.Add("@FiscalYear", SqlDbType.Int).Value = Convert.ToInt32(_fiscalYear.Value)
                    command.Parameters.Add("@ExecutePosting", SqlDbType.Bit).Value = executePosting

                    Using adapter As New SqlDataAdapter(command)
                        Dim result As New DataSet()
                        adapter.Fill(result)
                        Return result
                    End Using
                End Using
            End Using
        End Function

        Private Sub BindResults(data As DataSet)
            _summaryGrid.DataSource = Nothing
            _journalGrid.DataSource = Nothing
            _summaryInfo.Clear()
            _detailsText.Clear()

            If data Is Nothing OrElse data.Tables.Count = 0 Then Return

            _summaryGrid.DataSource = data.Tables(0)
            If data.Tables.Count > 1 Then _journalGrid.DataSource = data.Tables(1)

            If data.Tables(0).Rows.Count > 0 Then
                Dim summaryRow = data.Tables(0).Rows(0)
                Dim summaryValues = data.Tables(0).Columns.Cast(Of DataColumn)().
                    Select(Function(column) column.ColumnName & "=" & If(summaryRow(column) Is DBNull.Value, "", summaryRow(column).ToString()))
                _summaryInfo.Text = String.Join("  |  ", summaryValues)
            Else
                _summaryInfo.Text = "No validation summary was returned."
            End If

            For tableIndex As Integer = 2 To data.Tables.Count - 1
                _detailsText.AppendText("Result set " & tableIndex.ToString() & Environment.NewLine)
                For Each row As DataRow In data.Tables(tableIndex).Rows
                    Dim values = row.ItemArray.Select(Function(value) If(value Is DBNull.Value, "", value.ToString()))
                    _detailsText.AppendText(String.Join(" | ", values) & Environment.NewLine)
                Next
                _detailsText.AppendText(Environment.NewLine)
            Next
        End Sub

        Private Shared Function GetInt(data As DataSet, tableIndex As Integer, columnName As String) As Integer
            If data Is Nothing OrElse data.Tables.Count <= tableIndex OrElse data.Tables(tableIndex).Rows.Count = 0 Then Return 0
            Dim value = data.Tables(tableIndex).Rows(0)(columnName)
            If value Is DBNull.Value OrElse value Is Nothing Then Return 0
            Return Convert.ToInt32(value)
        End Function
    End Class

End Namespace
