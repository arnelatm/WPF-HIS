Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Module DatagridViewExtensions

    <DebuggerStepThrough()>
    <Extension()>
    Public Function IsComboBoxCell(ByVal sender As DataGridViewCell) As Boolean
        Dim Result As Boolean = False
        If sender.EditType IsNot Nothing Then
            If sender.EditType Is GetType(EcbComboBoxEditingControl) Then
                Result = True
            End If
        End If
        Return Result
    End Function

    <DebuggerHidden()>
    <Extension()>
    Public Sub ExpandColumns(ByVal sender As DataGridView)
        For Each col As DataGridViewColumn In sender.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub

End Module