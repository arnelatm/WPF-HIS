Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class BTextBox
    Inherits TextBox

    Public Sub New()
        MyBase.New()
        BackColor = SystemColors.ControlLight
    End Sub

    <Category("Custom Properties")>
    <DefaultValue(CType(Nothing, String))>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Data bound Control.")>
    <Browsable(True)>
    Public Property DataBoundControl As Boolean

End Class