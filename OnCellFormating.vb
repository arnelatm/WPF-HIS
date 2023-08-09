Private Sub OnCellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridViewPurchaseDetails.CellFormatting
    If e.ColumnIndex = DataGridViewPurchaseDetails.Columns("dgvDiscountAmount").Index Then
        e.FormattingApplied = True
        Dim row As DataGridViewRow = DataGridViewPurchaseDetails.Rows(e.RowIndex)
        e.Value = String.Format("{0,12:N2}", row.Cells("dgvGrossAmount").Value * row.Cells("dgvDiscountPercent").Value / 100)
    End If
End Sub
