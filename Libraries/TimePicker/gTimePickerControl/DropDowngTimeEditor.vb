
Imports System.Windows.Forms.Design
Imports System.ComponentModel

<ToolboxItem(False), ToolboxItemFilter("Prevent", ToolboxItemFilterType.Prevent)> _
Public Class DropDowngTimeEditor
    Inherits UserControl

    Private ReadOnly _editorService As IWindowsFormsEditorService

    Public Sub New(ByVal editorService As IWindowsFormsEditorService)
        InitializeComponent()
        _editorService = editorService
    End Sub

    Private Sub butClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles butClose.Click
        _editorService.CloseDropDown()

    End Sub

End Class
