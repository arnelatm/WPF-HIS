Public Class CFindForm
    Inherits CForm

    Private _TextToSearch As String
    Private _SearchAnywhere As Boolean

    Public Property TextToSearch As String
        Get
            Return _TextToSearch
        End Get
        Set
            _TextToSearch = Value
        End Set
    End Property

    Public Property SearchAnywhere As Boolean
        Get
            Return _SearchAnywhere
        End Get
        Set
            _SearchAnywhere = Value
        End Set
    End Property

    Private Sub CLabel1_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Public Function GetTextToSearch() As String
        Return TextToSearch
    End Function

    Public Function GetSearchAnywhere() As String
        Return SearchAnywhere
    End Function

    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnFind.Click
        _TextToSearch = TxtTextToSearch.Text
        If RBtnStart.Checked Then
            _SearchAnywhere = False
        Else
            _SearchAnywhere = True
        End If
        Close()
    End Sub

End Class