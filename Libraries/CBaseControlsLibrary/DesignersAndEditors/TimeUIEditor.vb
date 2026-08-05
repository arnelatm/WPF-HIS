Imports System.Windows.Forms.Design
Imports System.Drawing.Design
Imports System.ComponentModel

Class TimeUIEditor
    Inherits UITypeEditor

    ' Indicate that we display a modal dialog.
    Public Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
        Return UITypeEditorEditStyle.DropDown
    End Function

    ' Edit a Selected value.
    Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, _
        ByVal provider As IServiceProvider, ByVal value As Object) As Object
        ' Get the editor service.
        Dim editor_service As IWindowsFormsEditorService = _
            CType(provider.GetService(GetType(IWindowsFormsEditorService)), _
                IWindowsFormsEditorService)
        If editor_service Is Nothing Then Return value

        Using dropDownEditor As DropDowngTimeEditor = New DropDowngTimeEditor(editor_service)
            ' Prepare the editing dialog.
            With dropDownEditor
                If context.Instance.GetType Is GetType(gTimePickerCntrl) Then
                    Dim Instance As gTimePickerCntrl = CType(context.Instance, gTimePickerCntrl)
                    .DDgTimePickerCntrl.TimeAMPM = CType(Instance.TimeAMPM, gTimePickerCntrl.eTimeAMPM)
                    .DDgTimePickerCntrl.Hr24 = Instance.Hr24
                    .DDgTimePickerCntrl.TrueHour = Instance.TrueHour
                    .DDgTimePickerCntrl.Time = Instance.Time
                    .DDgTimePickerCntrl.TimeColors = Instance.TimeColors

                    ' Display the dialog.
                    editor_service.DropDownControl(dropDownEditor)

                ElseIf context.Instance.GetType Is GetType(gTimePicker) Then
                    Dim Instance As gTimePicker = CType(context.Instance, gTimePicker)
                    .DDgTimePickerCntrl.TimeAMPM = CType(Instance.TimeAMPM, gTimePickerCntrl.eTimeAMPM)
                    .DDgTimePickerCntrl.Hr24 = Instance.Hr24
                    .DDgTimePickerCntrl.TrueHour = Instance.TrueHour
                    .DDgTimePickerCntrl.Time = Instance.Time
                    .DDgTimePickerCntrl.TimeColors = Instance.TimeColors

                    ' Display the dialog.
                    editor_service.DropDownControl(dropDownEditor)

                End If
            End With
            ' Return the new value.
            If dropDownEditor.DDgTimePickerCntrl.Time = String.Empty Then
                Return Nothing
            Else
                Return dropDownEditor.DDgTimePickerCntrl.Time & IIf(dropDownEditor.DDgTimePickerCntrl.TimeAMPM = gTimePickerCntrl.eTimeAMPM.PM, "P", "A").ToString
            End If
        End Using
    End Function
End Class

