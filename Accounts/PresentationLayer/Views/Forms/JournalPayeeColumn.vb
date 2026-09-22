Imports System.Windows.Forms
Imports System.Data
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views.Forms

    Public Module JournalPayeeColumn

        Private Const PayeeColumnName As String = "dgvPayIdNo"

        Public Sub Configure(grid As CtDataGridView, payeeDataSource As Object)
            If grid Is Nothing OrElse payeeDataSource Is Nothing Then Return

            Dim payeeColumn As CDgvComboBoxColumn
            If grid.Columns.Contains(PayeeColumnName) Then
                payeeColumn = TryCast(grid.Columns(PayeeColumnName), CDgvComboBoxColumn)
                If payeeColumn Is Nothing Then Return
            Else
                payeeColumn = New CDgvComboBoxColumn With {
                    .Name = PayeeColumnName,
                    .DataPropertyName = "PayIdNo",
                    .HeaderText = Messaging.TranslateCaption("Payee"),
                    .Width = 200,
                    .SortMode = DataGridViewColumnSortMode.Automatic
                }

                Dim insertIndex As Integer = grid.Columns.Count
                If grid.Columns.Contains("dgvRevCostCenterIdNo") Then
                    insertIndex = grid.Columns("dgvRevCostCenterIdNo").Index + 1
                End If
                grid.Columns.Insert(insertIndex, payeeColumn)
            End If

            payeeColumn.DisplayMember = If(GlobalVariables.RightToLeftLayout, "ContactNameAra", "ContactName")
            payeeColumn.ValueMember = "IdNo"
            payeeColumn.DataSource = payeeDataSource
            payeeColumn.TreatZeroAsBlank = True
            payeeColumn.DisplayStyleForCurrentCellOnly = True
            payeeColumn.EditingMode = grid.EditingMode

            'Payee IDs are numeric keys, not journal amounts. The footer may have
            'auto-summed this dynamically added column, so exclude and clear it.
            For Each child As Control In grid.Controls
                Dim footer As DgvFooter = TryCast(child, DgvFooter)
                If footer Is Nothing OrElse Not footer.Columns.Contains(PayeeColumnName & "_footer") Then Continue For

                footer.ColumnToSum(PayeeColumnName) = False
                footer.SetText(PayeeColumnName, String.Empty)
            Next

            RemoveHandler grid.CellBeginEdit, AddressOf FilterPayeesForRow
            AddHandler grid.CellBeginEdit, AddressOf FilterPayeesForRow
            RemoveHandler grid.CellEndEdit, AddressOf RestorePayeeSource
            AddHandler grid.CellEndEdit, AddressOf RestorePayeeSource
        End Sub

        Private Sub FilterPayeesForRow(sender As Object, e As DataGridViewCellCancelEventArgs)
            Dim grid As DataGridView = TryCast(sender, DataGridView)
            If e.Cancel OrElse grid Is Nothing OrElse e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
            If grid.Columns(e.ColumnIndex).Name <> PayeeColumnName Then Return

            Dim payeeColumn As DataGridViewComboBoxColumn = TryCast(grid.Columns(e.ColumnIndex), DataGridViewComboBoxColumn)
            Dim payeeCell As DataGridViewComboBoxCell = TryCast(grid.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewComboBoxCell)
            If payeeColumn Is Nothing OrElse payeeCell Is Nothing Then Return

            Dim payeeType As String = GetPayeeType(grid.Rows(e.RowIndex))
            Dim filteredSource As DataView = CreatePayeeTypeView(payeeColumn.DataSource, payeeType)
            If filteredSource Is Nothing Then Return

            'A stale payee from a different account type is invalid for this row.
            'Clear it before assigning the filtered source so the combo can format safely.
            If Not PayeeExists(filteredSource, payeeCell.Value) Then
                payeeCell.Value = 0
            End If

            payeeCell.DataSource = filteredSource
            payeeCell.DisplayMember = payeeColumn.DisplayMember
            payeeCell.ValueMember = payeeColumn.ValueMember
        End Sub

        Private Sub RestorePayeeSource(sender As Object, e As DataGridViewCellEventArgs)
            Dim grid As DataGridView = TryCast(sender, DataGridView)
            If grid Is Nothing OrElse e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
            If grid.Columns(e.ColumnIndex).Name <> PayeeColumnName Then Return

            Dim payeeColumn As DataGridViewComboBoxColumn = TryCast(grid.Columns(e.ColumnIndex), DataGridViewComboBoxColumn)
            Dim payeeCell As DataGridViewComboBoxCell = TryCast(grid.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewComboBoxCell)
            If payeeColumn Is Nothing OrElse payeeCell Is Nothing Then Return

            payeeCell.DataSource = payeeColumn.DataSource
            payeeCell.DisplayMember = payeeColumn.DisplayMember
            payeeCell.ValueMember = payeeColumn.ValueMember
        End Sub

        Private Function GetPayeeType(row As DataGridViewRow) As String
            Dim item As IJournalItemView = TryCast(row.DataBoundItem, IJournalItemView)
            If item Is Nothing Then Return Nothing

            Select Case If(item.SpecialAccount, String.Empty).Trim().ToUpperInvariant()
                Case "AP", "AS", "PD"
                    Return "S"
                Case "AR", "CA", "SD"
                    Return "C"
                Case "RD"
                    Return "C"
                Case "EL"
                    Return "E"
            End Select

            Return NormalizePayeeType(item.PayeeType)
        End Function

        Private Function NormalizePayeeType(value As String) As String
            Dim payeeType As String = If(value, String.Empty).Trim().ToUpperInvariant()
            If payeeType = "C" OrElse payeeType = "S" OrElse payeeType = "E" Then Return payeeType
            Return Nothing
        End Function

        Private Function CreatePayeeTypeView(source As Object, payeeType As String) As DataView
            payeeType = NormalizePayeeType(payeeType)
            If payeeType Is Nothing Then Return Nothing

            Dim sourceView As DataView = TryCast(source, DataView)
            Dim payeeTable As DataTable
            Dim sourceFilter As String = String.Empty
            Dim sourceSort As String = String.Empty
            Dim rowState As DataViewRowState = DataViewRowState.CurrentRows

            If sourceView IsNot Nothing Then
                payeeTable = sourceView.Table
                sourceFilter = sourceView.RowFilter
                sourceSort = sourceView.Sort
                rowState = sourceView.RowStateFilter
            Else
                payeeTable = TryCast(source, DataTable)
                If payeeTable IsNot Nothing Then
                    sourceFilter = payeeTable.DefaultView.RowFilter
                    sourceSort = payeeTable.DefaultView.Sort
                    rowState = payeeTable.DefaultView.RowStateFilter
                End If
            End If

            If payeeTable Is Nothing OrElse Not payeeTable.Columns.Contains("CSECode") Then Return Nothing

            Dim rowFilter As String = "CSECode = '" & payeeType & "'"
            If Not String.IsNullOrWhiteSpace(sourceFilter) Then
                rowFilter = "(" & sourceFilter & ") AND (" & rowFilter & ")"
            End If

            Return New DataView(payeeTable, rowFilter, sourceSort, rowState)
        End Function

        Private Function PayeeExists(payees As DataView, value As Object) As Boolean
            If value Is Nothing OrElse value Is DBNull.Value Then Return True

            Dim idNo As Integer
            If Not Integer.TryParse(Convert.ToString(value), idNo) OrElse idNo <= 0 Then Return True
            If Not payees.Table.Columns.Contains("IdNo") Then Return False

            For Each payee As DataRowView In payees
                If Not Convert.IsDBNull(payee("IdNo")) AndAlso Convert.ToInt32(payee("IdNo")) = idNo Then Return True
            Next

            Return False
        End Function

    End Module

End Namespace
