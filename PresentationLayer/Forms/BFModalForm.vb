Imports AATM.Libraries.CBaseControlsLibrary

Public Class BfModalForm
    Inherits CForm

    Private _searchedRecId As Integer = 0

    Public Property GetSearchRecId As Integer
        Get
            Return _searchedRecId
        End Get
        Set
            _searchedRecId = Value
        End Set
    End Property

    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnFind.Click
        _searchedRecId = TxtSearchValue.Text
        Close()
    End Sub

    Private Sub BFModalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

End Class