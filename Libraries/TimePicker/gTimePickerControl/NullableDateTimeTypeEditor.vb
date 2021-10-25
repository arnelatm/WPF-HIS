Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

Public Class NullableDateTimeTypeEditor
    Inherits UITypeEditor

    ' Indicate that we display a dropdown.
    Public Overrides Function GetEditStyle( _
        ByVal context As System.ComponentModel.ITypeDescriptorContext) _
        As System.Drawing.Design.UITypeEditorEditStyle

        Return UITypeEditorEditStyle.DropDown
    End Function

    Public Overrides Function EditValue( _
        ByVal context As System.ComponentModel.ITypeDescriptorContext, _
        ByVal provider As System.IServiceProvider, ByVal value As Object) As Object

        ' Get an IWindowsFormsEditorService object.
        Dim editor_service As IWindowsFormsEditorService = _
            CType(provider.GetService(GetType(IWindowsFormsEditorService)), _
            IWindowsFormsEditorService)
        If editor_service Is Nothing Then
            Return MyBase.EditValue(context, provider, value)
        End If

        ' Pass the UI editor the current property value
        Dim Instance As New gDateTimePicker
        If context.Instance.GetType Is GetType(gDateTimePicker) Then
            Instance = CType(context.Instance, gDateTimePicker)
        End If

        ' Make the editing control.
        Dim editor_control As New NullableDateTimeDropDown(Instance.gValue, editor_service)
        ' Display the editing control.
        editor_service.DropDownControl(editor_control)

        ' Save the new results.
        Return editor_control.Value
    End Function

End Class
