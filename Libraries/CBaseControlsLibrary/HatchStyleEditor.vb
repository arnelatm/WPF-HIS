Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

Public Class HatchStyleEditor
    Inherits UITypeEditor

    ' Indicate that we display a dropdown.
    Public Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
        Return UITypeEditorEditStyle.DropDown
    End Function

    ' Edit a line style
    Public Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
        ' Get an IWindowsFormsEditorService object.
        Dim editor_service As IWindowsFormsEditorService =
            CType(provider.GetService(GetType(IWindowsFormsEditorService)),
            IWindowsFormsEditorService)
        If editor_service Is Nothing Then
            Return MyBase.EditValue(context, provider, value)
        End If

        ' Pass the UI editor the current property value

        Dim colorA, colorB As Color
        If context.Instance.GetType Is GetType(gTimePicker) Then
            Dim Instance As gTimePicker = CType(context.Instance, gTimePicker)
            colorA = Color.FromArgb(Instance.NullAlpha, Instance.NullColorA)
            colorB = Color.FromArgb(Instance.NullAlpha, Instance.NullColorB)

        ElseIf context.Instance.GetType Is GetType(gDateTimePicker) Then
            Dim Instance As gDateTimePicker = CType(context.Instance, gDateTimePicker)
            colorA = Color.FromArgb(Instance.NullAlpha, Instance.NullColorA)
            colorB = Color.FromArgb(Instance.NullAlpha, Instance.NullColorB)

        ElseIf context.Instance.GetType Is GetType(gTimeBox) Then
            Dim Instance As gTimeBox = CType(context.Instance, gTimeBox)
            colorA = Color.FromArgb(Instance.NullAlpha, Instance.NullColorA)
            colorB = Color.FromArgb(Instance.NullAlpha, Instance.NullColorB)
        End If

        ' Convert the value into a BorderStyles value.
        Dim hatch_style As HatchStyle = DirectCast(value, HatchStyle)

        ' Make the editing control.
        Dim editor_control As New HatchStyleListBox(hatch_style.ToString,
            colorA, colorB, editor_service)
        ' Display the editing control.
        editor_service.DropDownControl(editor_control)

        ' Save the new results.
        Return CType(System.Enum.Parse(GetType(HatchStyle), editor_control.Text, True), HatchStyle)
    End Function

    Public Overrides ReadOnly Property IsDropDownResizable() As Boolean
        Get
            Return MyBase.IsDropDownResizable
        End Get
    End Property

    Public Overrides Function GetPaintValueSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Sub PaintValue(ByVal e As PaintValueEventArgs)
        Dim hatch As HatchStyle = CType(e.Value, HatchStyle)
        ' Pass the UI editor the current property value

        Dim colorA, colorB As Color
        Dim nullalpha As Integer

        If e.Context.Instance.GetType Is GetType(gTimePicker) Then
            Dim Instance As gTimePicker = CType(e.Context.Instance, gTimePicker)
            colorA = Color.FromArgb(Instance.NullAlpha, Instance.NullColorA)
            colorB = Color.FromArgb(Instance.NullAlpha, Instance.NullColorB)
            nullalpha = Instance.NullAlpha

        ElseIf e.Context.Instance.GetType Is GetType(gDateTimePicker) Then
            Dim Instance As gDateTimePicker = CType(e.Context.Instance, gDateTimePicker)
            colorA = Color.FromArgb(Instance.NullAlpha, Instance.NullColorA)
            colorB = Color.FromArgb(Instance.NullAlpha, Instance.NullColorB)
            nullalpha = Instance.NullAlpha

        ElseIf e.Context.Instance.GetType Is GetType(gTimeBox) Then
            Dim Instance As gTimeBox = CType(e.Context.Instance, gTimeBox)
            colorA = Color.FromArgb(Instance.NullAlpha, Instance.NullColorA)
            colorB = Color.FromArgb(Instance.NullAlpha, Instance.NullColorB)
            nullalpha = Instance.NullAlpha
        End If

        Using br As Brush = New HatchBrush(hatch, Color.FromArgb(nullalpha, colorA), Color.FromArgb(nullalpha, colorB))
            e.Graphics.FillRectangle(br, e.Bounds)
        End Using

    End Sub

End Class