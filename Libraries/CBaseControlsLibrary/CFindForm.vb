Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

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

    Private Sub SetFormLocation()
        Dim pnt As Point
        Dim formLocation As Point
        Dim screenRectangle As Rectangle
        Dim myForm = FindForm()
        screenRectangle = Screen.PrimaryScreen.WorkingArea
        Me.StartPosition = FormStartPosition.Manual
        pnt = System.Windows.Forms.Control.MousePosition
        If GlobalVariables.RightToLeftLayout Then
            formLocation = New Point(pnt.X - Me.Width, pnt.Y + Me.Height)
            If formLocation.X < 0 Then
                formLocation.X = pnt.X
            End If
        Else
            formLocation = New Point(pnt.X, pnt.Y)
            If formLocation.X + Me.Width > screenRectangle.Width Then
                formLocation.X = pnt.X - Me.Width
            End If
        End If
        If formLocation.Y + Me.Height > screenRectangle.Height Then
            formLocation.Y = pnt.Y - Me.Height
        End If
        Me.Location = formLocation
    End Sub

    Private Sub CFindForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetFormLocation()
    End Sub

End Class