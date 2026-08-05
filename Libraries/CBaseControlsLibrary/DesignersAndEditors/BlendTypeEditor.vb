Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

<System.Diagnostics.DebuggerStepThrough()>
Public Class BlendTypeEditor
    Inherits UITypeEditor

    Public Overloads Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
        If Not context Is Nothing Then
            Return UITypeEditorEditStyle.DropDown
        End If
        Return (MyBase.GetEditStyle(context))
    End Function

    Public Overloads Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
        If (Not context Is Nothing) And (Not provider Is Nothing) Then
            ' Access the property browser's UI display service, IWindowsFormsEditorService
            Dim editorService As IWindowsFormsEditorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
            If Not editorService Is Nothing Then
                ' Create an instance of the UI editor, passing a reference to the editor service
                Using dropDownEditor As DropdownColorBlender = New DropdownColorBlender(editorService)
                    ' Pass the UI editor the current property values
                    Dim Instance As CButton
                    If context.Instance.GetType Is GetType(CButton) Then
                        'For PropertyGrid
                        Instance = CType(context.Instance, CButton)
                    Else
                        'For SmartTag
                        Instance = CType(CType(context.Instance, CButtonActionList).CurrControl, CButton)
                    End If
                    'Update The Sample with the Current Instance's Properties
                    With dropDownEditor
                        Dim ratio As Single
                        If Instance.Width > Instance.Height Then
                            .TheSample.Height = CInt(.TheSample.Width * (Instance.Height / Instance.Width))
                            .TheSample.Top = CInt((.panSampleHolder.Height - .TheSample.Height) / 2)
                            ratio = CSng(.TheSample.Height / Instance.Height)
                        Else
                            .TheSample.Width = CInt(.TheSample.Height * (Instance.Width / Instance.Height))
                            .TheSample.Left = CInt((.panSampleHolder.Width - .TheSample.Width) / 2)
                            ratio = CSng(.TheSample.Width / Instance.Width)
                        End If
                        ' Set current Corners values
                        .TheSample.Shape = Instance.Shape
                        .TheSample.FillType = Instance.FillType
                        .TheSample.FillTypeLinear = Instance.FillTypeLinear
                        .TheSample.ColorFillSolid = Instance.ColorFillSolid
                        .TheSample.BorderColor = Instance.BorderColor
                        .TheSample.FocalPoints = Instance.FocalPoints
                        .TheSample.ColorFillBlend = Instance.ColorFillBlend
                        .TheSample.Corners =
                            New CornersProperty(CInt(Instance.Corners.LowerLeft * ratio),
                                                CInt(Instance.Corners.LowerRight * ratio),
                                                CInt(Instance.Corners.UpperLeft * ratio),
                                                CInt(Instance.Corners.UpperRight * ratio))
                        .LoadABlend(Instance.ColorFillBlend)
                        .TheSample.TextMargin =
                            New Padding(CInt(Instance.TextMargin.Left * ratio),
                                        CInt(Instance.TextMargin.Top * ratio),
                                        CInt(Instance.TextMargin.Right * ratio),
                                        CInt(Instance.TextMargin.Bottom * ratio))
                        .TheSample.Padding =
                            New Padding(CInt(Instance.Padding.Left * ratio),
                                        CInt(Instance.Padding.Top * ratio),
                                        CInt(Instance.Padding.Right * ratio),
                                        CInt(Instance.Padding.Bottom * ratio))
                        .TheSample.Text = Instance.Text
                        .TheSample.ForeColor = Instance.ForeColor
                        .TheSample.TextAlign = Instance.TextAlign
                        .TheSample.Font =
                            New Font(Instance.Font.FontFamily,
                                     Instance.Font.Size * ratio,
                                     Instance.Font.Style)
                        .TheSample.TextShadow = Instance.TextShadow
                        .TheSample.TextShadowShow = Instance.TextShadowShow
                    End With
                    ' Display the UI editor
                    editorService.DropDownControl(dropDownEditor)
                    ' Return the new property value from the editor
                    Return dropDownEditor.TheSample.ColorFillBlend
                End Using
            End If
        End If
        Return MyBase.EditValue(context, provider, value)
    End Function

    ' Indicate that we draw values in the Properties window.
    Public Overrides Function GetPaintValueSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    ' Draw a BorderStyles value.
    Public Overrides Sub PaintValue(ByVal e As PaintValueEventArgs)
        ' Erase the area.
        e.Graphics.FillRectangle(Brushes.White, e.Bounds)

        ' Draw the sample.
        Dim cblnd As cBlendItems = DirectCast(e.Value, cBlendItems)
        Using br As LinearGradientBrush =
            New LinearGradientBrush(e.Bounds, Color.Black, Color.Black,
                                    LinearGradientMode.Horizontal)
            Dim cb As New ColorBlend
            cb.Colors = cblnd.iColor
            cb.Positions = cblnd.iPoint
            br.InterpolationColors = cb
            e.Graphics.FillRectangle(br, e.Bounds)
        End Using
    End Sub

End Class