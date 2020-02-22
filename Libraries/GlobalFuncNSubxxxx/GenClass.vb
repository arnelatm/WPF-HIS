

Public Class GenClass (Of T)
    Private _myCollection As IList(Of T)

    Public Property MyProperty As IList(Of T)
        Get
            Return Me._myCollection
        End Get
        Set
            Me._myCollection = value
        End Set
    End Property
End Class

Public Class GenericModel (Of T)
    Private _myModel As T

    Public Property MyModel As T
        Get
            Return Me._myModel
        End Get
        Set
            Me._myModel = value
        End Set
    End Property
End Class


