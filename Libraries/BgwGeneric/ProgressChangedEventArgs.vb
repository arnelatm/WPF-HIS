Public Class ProgressChangedEventArgs(Of T)
    Inherits EventArgs

    Private _ProgressPercentage As Int32
    Private _UserState As T

    Public Sub New(progressPercentage As Int32, userState As T)
        _ProgressPercentage = progressPercentage
        _UserState = userState
    End Sub

    Public Property ProgressPercentage As Int32
        Get
            Return _ProgressPercentage
        End Get
        Private Set
            _ProgressPercentage = Value
        End Set
    End Property

    Public Property UserState As T
        Get
            Return _UserState
        End Get
        Private Set
            _UserState = Value
        End Set
    End Property

End Class