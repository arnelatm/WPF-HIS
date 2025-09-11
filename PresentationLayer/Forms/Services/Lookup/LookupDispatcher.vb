Imports AATM.Libraries
Imports AATM.Presentation.Events

Namespace Services.Lookup
    Public Class LookupDispatcher
        Private ReadOnly _ea As EventAggregator
        Private ReadOnly _owner As Object

        Public Sub New(ea As EventAggregator, owner As Object)
            _ea = ea
            _owner = owner
        End Sub

        Public Sub Request(tableName As String, targetProperty As String)
            _ea?.PublishEvent(New GetLookupDataTableRequested(tableName, _owner, targetProperty))
        End Sub

        Public Sub Request(tableName As String, targetProperty As String, filter As String)
            _ea?.PublishEvent(New GetLookupDataTableRequested(tableName, _owner, targetProperty, filter))
        End Sub

        Public Sub Request(tableName As String, targetProperty As String, sortKey As String, filter As String)
            _ea?.PublishEvent(New GetLookupDataTableRequested(tableName, _owner, targetProperty, sortKey, filter))
        End Sub

        Public Sub Request(tableName As String, targetProperty As String, fields As String(), Optional filter As String = Nothing)
            _ea?.PublishEvent(New GetLookupDataTableRequested(tableName, _owner, targetProperty, fields, filter))
        End Sub

        Public Sub Request(tableName As String, targetProperty As String, sortField As String, fields As String(), Optional filter As String = Nothing)
            _ea?.PublishEvent(New GetLookupDataTableRequested(tableName, _owner, targetProperty, sortField, fields, filter))
        End Sub
    End Class
End Namespace