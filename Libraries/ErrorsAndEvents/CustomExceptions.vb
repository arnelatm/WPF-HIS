Public Class CustomExceptions
    Inherits Exception

    Public Sub New()
        MyBase.New("Invalid options selected")
    End Sub

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(message As String, exception As Exception)
        MyBase.New(message, exception)
    End Sub

End Class