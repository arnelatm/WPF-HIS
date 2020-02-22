Imports System.ComponentModel

Public Class DoWorkEventArgs(Of TArgument, TResult)
    Inherits CancelEventArgs

    Private _Argument As TArgument
    Private _Result As TResult

    Public Sub New(argument As TArgument)
        _Argument = argument
    End Sub

    Public Property Argument As TArgument
        Get
            Return _Argument
        End Get
        Private Set
            _Argument = Value
        End Set
    End Property

    Public Property Result As TResult
        Get
            Return _Result
        End Get
        Set
            _Result = Value
        End Set
    End Property

End Class

Public Class DoWorkEventArgs(Of T)
    Inherits CancelEventArgs

    Private _Argument As T
    Private _Result As T

    Public Sub New(argument As T)
        _Argument = argument
    End Sub

    Public Property Argument As T
        Get
            Return _Argument
        End Get
        Private Set
            _Argument = Value
        End Set
    End Property

    Public Property Result As T
        Get
            Return _Result
        End Get
        Set
            _Result = Value
        End Set
    End Property

End Class