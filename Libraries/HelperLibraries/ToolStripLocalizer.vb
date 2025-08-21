Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

' Reusable localization helper for ToolStrip/MenuStrip items
Public NotInheritable Class ToolStripLocalizer
    Private Sub New()
    End Sub

    ' Core: translate a single ToolStripItem and recurse into its dropdowns
    Public Shared Sub TranslateToolStripItem(item As ToolStripItem,
                                             translationDict As IDictionary(Of String, String),
                                             Optional buttonImageTranslator As Action(Of ToolStripButton) = Nothing)
        If item Is Nothing OrElse translationDict Is Nothing Then Return

        Dim txtKey As String = Nothing
        Dim tipKey As String = Nothing
        GetKeysFromTag(item, txtKey, tipKey)

        If String.IsNullOrWhiteSpace(txtKey) Then
            txtKey = If(Not String.IsNullOrWhiteSpace(item.Text), item.Text, item.Name)
        End If
        If String.IsNullOrWhiteSpace(tipKey) Then
            tipKey = item.ToolTipText
        End If

        Dim translated As String = Nothing
        If Not String.IsNullOrWhiteSpace(txtKey) AndAlso translationDict.TryGetValue(txtKey, translated) Then
            If item.Text <> translated Then item.Text = translated
        End If
        If Not String.IsNullOrWhiteSpace(tipKey) AndAlso translationDict.TryGetValue(tipKey, translated) Then
            If item.ToolTipText <> translated Then item.ToolTipText = translated
        End If

        Dim btn = TryCast(item, ToolStripButton)
        If btn IsNot Nothing AndAlso buttonImageTranslator IsNot Nothing Then
            buttonImageTranslator(btn)
        End If

        Dim dd = TryCast(item, ToolStripDropDownItem)
        If dd IsNot Nothing Then
            For Each subItem As ToolStripItem In dd.DropDownItems
                TranslateToolStripItem(subItem, translationDict, buttonImageTranslator)
            Next
        End If
    End Sub

    ' Translate a ToolStrip (toolbar/status strip)
    Public Shared Sub TranslateToolStrip(tool As ToolStrip,
                                         translationDict As IDictionary(Of String, String),
                                         Optional buttonImageTranslator As Action(Of ToolStripButton) = Nothing)
        If tool Is Nothing OrElse translationDict Is Nothing Then Return
        For Each item As ToolStripItem In tool.Items
            TranslateToolStripItem(item, translationDict, buttonImageTranslator)
        Next
    End Sub

    ' Translate a MenuStrip with optional RTL and font styling
    Public Shared Sub TranslateMenuStrip(menu As MenuStrip,
                                         translationDict As IDictionary(Of String, String),
                                         Optional applyRtl As Boolean = False,
                                         Optional rightToLeft As Boolean = False,
                                         Optional font As Font = Nothing,
                                         Optional buttonImageTranslator As Action(Of ToolStripButton) = Nothing)
        If menu Is Nothing OrElse translationDict Is Nothing Then Return

        For Each item As ToolStripItem In menu.Items
            TranslateToolStripItem(item, translationDict, buttonImageTranslator)
        Next

        If applyRtl Then
            menu.RightToLeft = rightToLeft
        End If
        If font IsNot Nothing Then
            menu.Font = font
        End If
        menu.Refresh()
    End Sub

    ' Translate a ContextMenuStrip
    Public Shared Sub TranslateContextMenuStrip(ctx As ContextMenuStrip,
                                                translationDict As IDictionary(Of String, String),
                                                Optional buttonImageTranslator As Action(Of ToolStripButton) = Nothing)
        If ctx Is Nothing OrElse translationDict Is Nothing Then Return
        For Each item As ToolStripItem In ctx.Items
            TranslateToolStripItem(item, translationDict, buttonImageTranslator)
        Next
        ctx.Refresh()
    End Sub

    ' Reset helpers (restore from Tag to original values)
    Public Shared Sub ResetToolStripToOriginalTags(tool As ToolStrip)
        If tool Is Nothing Then Return
        For Each item As ToolStripItem In tool.Items
            ResetItemToOriginalTag(item)
        Next
    End Sub

    Public Shared Sub ResetMenuStripToOriginalTags(menu As MenuStrip)
        If menu Is Nothing Then Return
        For Each item As ToolStripItem In menu.Items
            ResetItemToOriginalTag(item)
        Next
        menu.Refresh()
    End Sub

    ' Internal: get keys from Tag (Object() or String)
    Private Shared Sub GetKeysFromTag(item As ToolStripItem, ByRef textKey As String, ByRef tipKey As String)
        textKey = Nothing
        tipKey = Nothing

        If item.Tag Is Nothing Then Return

        If TypeOf item.Tag Is Object() Then
            Dim tagArr = DirectCast(item.Tag, Object())
            If tagArr.Length > 0 AndAlso tagArr(0) IsNot Nothing Then textKey = tagArr(0).ToString()
            If tagArr.Length > 1 AndAlso tagArr(1) IsNot Nothing Then tipKey = tagArr(1).ToString()
        Else
            textKey = item.Tag.ToString()
        End If
    End Sub

    ' Internal: reset one item (and its dropdown) from Tag
    Private Shared Sub ResetItemToOriginalTag(item As ToolStripItem)
        If item Is Nothing Then Return

        If item.Tag IsNot Nothing AndAlso TypeOf item.Tag Is Object() Then
            Dim tagArr = DirectCast(item.Tag, Object())
            If tagArr.Length > 0 AndAlso tagArr(0) IsNot Nothing Then item.Text = CStr(tagArr(0))
            If tagArr.Length > 1 AndAlso tagArr(1) IsNot Nothing Then item.ToolTipText = CStr(tagArr(1))
        ElseIf item.Tag IsNot Nothing Then
            item.Text = item.Tag.ToString()
            item.ToolTipText = ""
        Else
            ' leave as-is
        End If

        Dim dd = TryCast(item, ToolStripDropDownItem)
        If dd IsNot Nothing Then
            For Each subItem As ToolStripItem In dd.DropDownItems
                ResetItemToOriginalTag(subItem)
            Next
        End If
    End Sub
End Class