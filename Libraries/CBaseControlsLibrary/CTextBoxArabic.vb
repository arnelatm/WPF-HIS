Imports System.ComponentModel
Imports System.Windows.Forms

Public Class CTextBoxArabic
    Inherits CTextBox

    Public Sub New()
        MyBase.New()
        RightToLeft = RightToLeft.Yes
    End Sub

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Enter here the name of the control to English Control to translate.")>
    <Browsable(True)>
    Public Property EnglishControl As CTextBox

End Class