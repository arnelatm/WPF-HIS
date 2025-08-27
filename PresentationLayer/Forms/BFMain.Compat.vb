' OPTIONAL COMPATIBILITY SHIM
' Include this file temporarily if other code still calls the removed members.
' Marked Obsolete to guide migration.

Imports System
Imports System.Collections
Imports System.Windows.Forms

Partial Class BfMain

    <Obsolete("Use Services.ApplySecurity(control) instead.")>
    Public Sub SetObjectSecurityNew(ByRef cCtrl As Control)
        _services.ApplySecurity(cCtrl)
    End Sub

    <Obsolete("Use Services.EndAllGridEdits().")>
    Public Sub ForceEndEditForAllGridControls()
        _services.EndAllGridEdits()
    End Sub

    <Obsolete("Use Services.InvalidateControlCaches().")>
    Public Sub InvalidateControlCaches()
        _services.InvalidateControlCaches()
    End Sub

    <Obsolete("Use Services.ProcessCellEndEdit(dgv, bs).")>
    Protected Sub ProcessCellEndEdit(dataGridView As DataGridView, bindingSource As BindingSource)
        _services.ProcessCellEndEdit(dataGridView, bindingSource)
    End Sub

    <Obsolete("Use Services.RequestLookup(...) directly.")>
    Protected Overloads Sub CreateLookupDataTable(tableName As String, targetProperty As String)
        _services.RequestLookup(tableName, targetProperty)
    End Sub
End Class