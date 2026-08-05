Public Class ValidationControlCollection
    Inherits CollectionBase

    Default Public Property Item(listIndex As Integer) As ValidationControl
        Get
            Return List(listIndex)
        End Get
        Set
            List(listIndex) = Value
        End Set
    End Property

    Default Public Property Item(pControl As Object) As ValidationControl
        Get
            If IsNothing(pControl) Then
                Return Nothing
            End If
            If GetIndex(pControl.Name) < 0 Then
                Return New ValidationControl
            End If
            Return (List(GetIndex(pControl.Name)))
        End Get
        Set
            If IsNothing(pControl) OrElse GetIndex(pControl.Name) < 0 Then
                List(GetIndex(pControl.Name)) = Nothing
            Else
                List(GetIndex(pControl.Name)) = Value
            End If
        End Set
    End Property

    Function GetIndex(controlName As String) As Integer
        Dim i As Integer
        For i = 0 To Count - 1
            If Item(i).ControlObj.name.toupper = controlName.ToUpper Then
                Return i
            End If
        Next
        Return -1
    End Function

    Public Sub AddMandatory(ByRef pControl As Object, pDisplayName As String)
        If IsNothing(pControl) Then Exit Sub
        Dim obj As New ValidationControl With {
                .ControlObj = pControl,
                .DisplayName = pDisplayName,
                .ErrorMessage = "Please enter " + pDisplayName
                }
        List.Add(obj)
    End Sub

    Public Sub AddValidation(ByRef pControl As Object, pDisplayName As String, pErrorMessage As String)
        If IsNothing(pControl) Then Exit Sub
        Dim obj As New ValidationControl With {
                .ControlObj = pControl,
                .DisplayName = pDisplayName,
                .ErrorMessage = pErrorMessage,
                .Mandatory = False
                }
        List.Add(obj)
    End Sub

    Public Sub AddMandatory(ByRef pControl As Object, pDisplayName As String, pErrorMessage As String)
        If IsNothing(pControl) Then
            Exit Sub
        End If

        Dim obj As New ValidationControl With {
                .ControlObj = pControl,
                .DisplayName = pDisplayName,
                .ErrorMessage = pErrorMessage,
                .Mandatory = True
                }
        List.Add(obj)
    End Sub

    Public Sub AddMandatory(ByRef pControl As Object)
        If IsNothing(pControl) Then
            Exit Sub
        End If

        Dim obj As New ValidationControl With {
                .ControlObj = pControl,
                .DisplayName = pControl.Name,
                .ErrorMessage = "Please enter " + pControl.Name
                }
        List.Add(obj)
    End Sub

    Public Sub AddMandatory(pControl As ValidationControl)
        If IsNothing(pControl) Then Exit Sub
        List.Add(pControl)
    End Sub

    Public Sub Remove(pControl As Object)
        If IsNothing(pControl) Then Exit Sub
        Dim i As Integer = GetIndex(pControl.Name)
        If i >= 0 Then
            List.RemoveAt(i)
        End If
    End Sub

End Class