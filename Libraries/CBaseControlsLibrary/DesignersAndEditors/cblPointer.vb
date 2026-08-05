Imports System.Drawing

Class cblPointer

    Sub New(ByVal pt As Single, ByVal c As Color, ByVal IsCurr As Boolean)
        pPos = pt
        pColor = c
        pIsCurr = IsCurr
    End Sub

    Private _pPos As Single

    Public Property pPos() As Single
        Get
            Return _pPos
        End Get
        Set(ByVal value As Single)
            _pPos = value
        End Set
    End Property

    Private _pColor As Color

    Public Property pColor() As Color
        Get
            Return _pColor
        End Get
        Set(ByVal value As Color)
            _pColor = value
        End Set
    End Property

    Private _pIsCurr As Boolean

    Public Property pIsCurr() As Boolean
        Get
            Return _pIsCurr
        End Get
        Set(ByVal value As Boolean)
            _pIsCurr = value
        End Set
    End Property

End Class