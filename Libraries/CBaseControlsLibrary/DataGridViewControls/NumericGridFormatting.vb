Imports System.Windows.Forms

Public NotInheritable Class NumericGridFormatting

    ' Unknown-scale Decimal fields keep all 28 fractional digits without database padding.
    Public Const UnspecifiedDecimalFormat As String = "0.############################"

    Private Sub New()
    End Sub

    Public Shared Sub SetFormatIfMissing(column As DataGridViewColumn, format As String)
        ' InheritedStyle also respects a format supplied by the owning grid.
        If String.IsNullOrEmpty(column.InheritedStyle.Format) Then
            column.DefaultCellStyle.Format = format
        End If
    End Sub

End Class
