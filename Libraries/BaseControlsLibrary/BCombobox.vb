Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class BCombobox
    Inherits ComboBox

    Public Sub New()
        MyBase.New()
        BackColor = SystemColors.ControlLight
        'AutoCompleteMode = AutoCompleteMode.Suggest
        'AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    <Category("Custom Properties")>
    <DefaultValue(CType(Nothing, String))>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String

End Class