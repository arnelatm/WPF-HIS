Imports System
Imports AATM.Libraries

Namespace Services.SystemView
    ' Provides cached SystemView Id lookup for a form (by ViewDisplayName or Name)
    Public Class SystemViewIdProvider
        Private ReadOnly _translatorDac As Dac
        Private ReadOnly _viewNameFunc As Func(Of String) ' returns logical view name
        Private _cachedId As Integer
        Private ReadOnly _lockObj As New Object()

        Public Sub New(translatorDac As Dac, viewNameFunc As Func(Of String))
            _translatorDac = translatorDac
            _viewNameFunc = viewNameFunc
        End Sub

        Public Function GetId(Optional forceRefresh As Boolean = False) As Integer
            If forceRefresh Then
                SyncLock _lockObj
                    _cachedId = 0
                End SyncLock
            End If
            If _cachedId <> 0 Then Return _cachedId
            SyncLock _lockObj
                If _cachedId = 0 Then
                    If _translatorDac Is Nothing Then Return 0
                    Dim vn = _viewNameFunc().Trim()
                    Dim sql = "SELECT IdNo FROM SystemView WHERE SystemViewName = '" & vn.Replace("'", "''") & "'"
                    Try
                        _cachedId = _translatorDac.ExecScalar(Of Integer)(sql)
                    Catch
                        _cachedId = 0
                    End Try
                End If
                Return _cachedId
            End SyncLock
        End Function

        Public Sub Reset()
            SyncLock _lockObj
                _cachedId = 0
            End SyncLock
        End Sub
    End Class
End Namespace