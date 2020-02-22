Imports System.ComponentModel

Public NotInheritable Class RunWorkerCompletedEventArgs(Of T)
    Inherits EventArgs

    Private _Cancelled As Boolean
    Private _Err As Exception
    Private _Result As T

    Public Sub New(result As T, err As Exception, cancelled As Boolean)
        _Cancelled = cancelled
        _Err = err
        _Result = result
    End Sub

    Public Shared Widening Operator CType(e As RunWorkerCompletedEventArgs(Of T)) As AsyncCompletedEventArgs
        Return New AsyncCompletedEventArgs(e.Err, e.Cancelled, e.Result)
    End Operator

    Public Property Cancelled As Boolean
        Get
            Return _Cancelled
        End Get
        Private Set
            _Cancelled = Value
        End Set
    End Property

    Public Property Err As Exception
        Get
            Return _Err
        End Get
        Private Set
            _Err = Value
        End Set
    End Property

    Public Property Result As T
        Get
            Return _Result
        End Get
        Private Set
            _Result = Value
        End Set
    End Property

End Class