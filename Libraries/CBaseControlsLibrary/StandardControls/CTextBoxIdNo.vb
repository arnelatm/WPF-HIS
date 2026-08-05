Public Class CTextBoxIdNo
    Inherits CTextBox
    Private _cEnglishTextBox As CTextBox

    Public Sub New()
        MyBase.New()
        DisplayOnly = True
    End Sub

End Class