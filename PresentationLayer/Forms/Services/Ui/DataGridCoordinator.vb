' ADD: New service to encapsulate DataGridView caching / edit finalization logic.
Imports System.Windows.Forms

Namespace Services.Ui
    Public Class DataGridCoordinator
        Private ReadOnly _root As Control
        Private _cached As List(Of DataGridView)
        Private _invalidated As Boolean = True

        Public Sub New(root As Control)
            _root = root
        End Sub

        Public Sub Invalidate()
            _invalidated = True
        End Sub

        Private Sub Ensure()
            If Not _invalidated AndAlso _cached IsNot Nothing Then Return
            _cached = New List(Of DataGridView)
            Dim list As New List(Of Control)
            Collect(_root, list)
            For Each c In list
                Dim dgv = TryCast(c, DataGridView)
                If dgv IsNot Nothing Then _cached.Add(dgv)
            Next
            _invalidated = False
        End Sub

        Private Sub Collect(parent As Control, list As List(Of Control))
            If parent Is Nothing Then Return
            For Each c As Control In parent.Controls
                list.Add(c)
                Collect(c, list)
            Next
        End Sub

        Public Sub EndAllEdits()
            Ensure()
            For Each dgv In _cached
                dgv.EndEdit()
            Next
        End Sub
    End Class
End Namespace