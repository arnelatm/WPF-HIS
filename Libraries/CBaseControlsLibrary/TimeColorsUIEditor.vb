Imports System.Drawing.Design
Imports System.Windows.Forms.Design

Class TimeColorsUIEditor
    Inherits UITypeEditor

    ' Indicate that we display a modal dialog.
    Public Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
        Return UITypeEditorEditStyle.Modal
    End Function

    ' Edit a Selected value.
    Public Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext,
        ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
        ' Get the editor service.
        Dim editor_service As IWindowsFormsEditorService =
            CType(provider.GetService(GetType(IWindowsFormsEditorService)),
                IWindowsFormsEditorService)
        If editor_service Is Nothing Then Return value

        Dim dlg As dlgTimeColors = New dlgTimeColors

        ' Prepare the editing dialog.
        With dlg
            If context.Instance.GetType Is GetType(gTimePickerCntrl) Then
                Dim Instance As New gTimePickerCntrl
                Instance = CType(context.Instance, gTimePickerCntrl)
                .gTimePickerColors.TimeColors = Instance.TimeColors

                ' Display the dialog.
                editor_service.ShowDialog(dlg)
                context.OnComponentChanged()
                Instance.Refresh()

            ElseIf context.Instance.GetType Is GetType(gTimePicker) Then
                Dim Instance As New gTimePicker
                Instance = CType(context.Instance, gTimePicker)
                .gTimePickerColors.TimeColors = Instance.TimeColors

                ' Display the dialog.
                editor_service.ShowDialog(dlg)
                context.OnComponentChanged()
                Instance.Refresh()
                'Else
                '    'This is needed if using in a SmartTag
                '    Instance = CType(context.Instance., gTimePickerCntrl)
            End If

        End With

        ' Return the new value.
        Return dlg.gTimePickerColors.TimeColors
    End Function

End Class