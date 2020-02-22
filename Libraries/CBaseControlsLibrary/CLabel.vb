Imports System.Drawing
Imports System.Windows.Forms

Public Class CLabel
    Inherits Label

    Public Sub New()
        MyBase.New()
        Dim myFont As New Font("Sans Serif", 10, FontStyle.Regular)
        Text = ""
        TextAlign = ContentAlignment.MiddleLeft
        Font = myFont
        Margin = New Padding(1, 1, 1, 1)
    End Sub

End Class