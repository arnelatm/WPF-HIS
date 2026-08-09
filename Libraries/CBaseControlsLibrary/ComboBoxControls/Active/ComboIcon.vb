Imports System.Drawing
Imports System.Windows.Forms

Public Class ComboIcon
    Inherits CtCombobox

    Private ReadOnly _imageList As New ImageList
    'It is the ImageList associated to the Combo

    Public Sub New()
        MyBase.New()
        DrawMode = DrawMode.OwnerDrawFixed
        'Set the DrawMode to OwnerDraw
    End Sub

    Protected Overrides Sub OnDrawItem(ByVal e _
                                          As System.Windows.Forms.DrawItemEventArgs)
        e.DrawBackground()
        e.DrawFocusRectangle()
        Dim item As New ComboBoxIconItem
        Dim imageSize As New Size
        imageSize = _imageList.ImageSize
        Dim bounds As New Rectangle
        bounds = e.Bounds
        Using textBrush As New SolidBrush(e.ForeColor)
            Try
                item = Items(e.Index)
                If (item.ImageIndex <> -1) Then
                    _imageList.Draw(e.Graphics, bounds.Left,
                                    bounds.Top, item.ImageIndex)
                    e.Graphics.DrawString(item.Text, e.Font, textBrush, bounds.Left + imageSize.Width, bounds.Top)
                Else
                    e.Graphics.DrawString(item.Text, e.Font, textBrush, bounds.Left, bounds.Top)
                End If
            Catch ex As Exception
                If (e.Index <> -1) Then
                    e.Graphics.DrawString(Items(e.Index).ToString(), e.Font, textBrush, bounds.Left, bounds.Top)
                Else
                    e.Graphics.DrawString(Text, e.Font, textBrush, bounds.Left, bounds.Top)
                End If
            End Try
        End Using
        MyBase.OnDrawItem(e)
    End Sub

End Class

Class ComboBoxIconItem
    Private _text As String

    Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal Value As String)
            _text = Value
        End Set
    End Property

    Public Property ImageIndex As Integer

    Public Sub New()
        _text = ""
    End Sub

    Public Sub New(ByVal text As String)
        _text = text
    End Sub

    Public Sub New(ByVal text As String, ByVal imageIndex As Integer)
        _text = text
        Me.ImageIndex = imageIndex
    End Sub

    Public Overrides Function ToString() As String
        Return _text
    End Function

End Class
