Imports System.Drawing
Imports System.Globalization
Imports System.Resources
Imports System.Windows.Forms

Namespace Localization

    Public NotInheritable Class ControlLocalizer
        Private Sub New()
        End Sub

        ' Wrapper indices & sentinel
        Private Const IDX_ORIGINAL As Integer = 0
        Private Const IDX_USERDATA As Integer = 1
        Private Const IDX_SENTINEL As Integer = 2
        Private Const LOC_SENTINEL As String = "__LOC_SENTINEL__"

#Region "Public Orchestrators"
        Public Shared Sub TranslateControls(root As Control,
                                            translationDict As IDictionary(Of String, String),
                                            Optional toolStripButtonImageTranslator As Action(Of ToolStripButton) = Nothing,
                                            Optional imageResourceManager As ResourceManager = Nothing)
            If root Is Nothing OrElse translationDict Is Nothing Then Return
            Dim q As New Queue(Of Control)
            q.Enqueue(root)
            While q.Count > 0
                Dim current = q.Dequeue()
                TranslateSingleControl(current, translationDict, toolStripButtonImageTranslator, imageResourceManager)
                For Each child As Control In current.Controls
                    q.Enqueue(child)
                Next
            End While
        End Sub

        Public Shared Sub ResetControls(root As Control,
                                        Optional resetToolStripButtonImage As Action(Of ToolStripButton) = Nothing,
                                        Optional imageResourceManager As ResourceManager = Nothing)
            If root Is Nothing Then Return
            Dim q As New Queue(Of Control)
            q.Enqueue(root)
            While q.Count > 0
                Dim current = q.Dequeue()
                ResetSingleControl(current, resetToolStripButtonImage, imageResourceManager)
                For Each child As Control In current.Controls
                    q.Enqueue(child)
                Next
            End While
        End Sub
#End Region

#Region "Single Control Translation / Reset"
        Private Shared Sub TranslateSingleControl(ctrl As Control,
                                                  translationDict As IDictionary(Of String, String),
                                                  toolStripButtonImageTranslator As Action(Of ToolStripButton),
                                                  imageResourceManager As ResourceManager)

            If IsStandardTextControl(ctrl) AndAlso Not TypeOf ctrl Is TabPage AndAlso Not TypeOf ctrl Is TabControl Then
                EnsureWrapped(ctrl)
                ApplyTextTranslation(ctrl, translationDict)
            End If

            If TypeOf ctrl Is MenuStrip Then
                TranslateMenuStrip(DirectCast(ctrl, MenuStrip), translationDict,
                                   applyRtl:=False,
                                   rightToLeft:=CultureInfo.CurrentCulture.TextInfo.IsRightToLeft,
                                   font:=Nothing,
                                   buttonImageTranslator:=toolStripButtonImageTranslator,
                                   imageResourceManager:=imageResourceManager)
                Return
            ElseIf TypeOf ctrl Is ToolStrip Then
                TranslateToolStrip(DirectCast(ctrl, ToolStrip), translationDict, toolStripButtonImageTranslator, imageResourceManager)
                Return
            End If

            If TypeOf ctrl Is DataGridView Then
                TranslateDataGridView(DirectCast(ctrl, DataGridView), translationDict) : Return
            ElseIf TypeOf ctrl Is DataGrid Then
                TranslateDataGrid(DirectCast(ctrl, DataGrid), translationDict) : Return
            End If

            If ctrl.GetType().Name.Equals("CTabControl", StringComparison.OrdinalIgnoreCase) _
               OrElse TypeOf ctrl Is TabControl Then
                TranslateTabControl(DirectCast(ctrl, TabControl), translationDict)
            End If

            If ctrl.GetType().Name.Equals("CButton", StringComparison.OrdinalIgnoreCase) Then
                TranslateCButton(ctrl, imageResourceManager)
            End If
        End Sub

        Private Shared Sub ResetSingleControl(ctrl As Control,
                                              resetToolStripButtonImage As Action(Of ToolStripButton),
                                              imageResourceManager As ResourceManager)

            If TypeOf ctrl Is MenuStrip Then
                ResetMenuStripToOriginalTags(DirectCast(ctrl, MenuStrip)) : Return
            ElseIf TypeOf ctrl Is ToolStrip Then
                ResetToolStripToOriginalTags(DirectCast(ctrl, ToolStrip))
                If resetToolStripButtonImage IsNot Nothing Then
                    For Each it As ToolStripItem In DirectCast(ctrl, ToolStrip).Items
                        Dim btn = TryCast(it, ToolStripButton)
                        If btn IsNot Nothing Then resetToolStripButtonImage(btn)
                    Next
                End If
                Return
            End If

            If TypeOf ctrl Is DataGridView Then
                ResetDataGridView(DirectCast(ctrl, DataGridView)) : Return
            ElseIf TypeOf ctrl Is DataGrid Then
                ResetDataGrid(DirectCast(ctrl, DataGrid)) : Return
            End If

            If ctrl.GetType().Name.Equals("CButton", StringComparison.OrdinalIgnoreCase) Then
                ResetCButton(ctrl, imageResourceManager)
            End If

            If TypeOf ctrl Is TabControl Then
                For Each page As TabPage In DirectCast(ctrl, TabControl).TabPages
                    ResetFromWrapper(page)
                Next
            End If

            If IsStandardTextControl(ctrl) Then
                ResetFromWrapper(ctrl)
            End If
        End Sub
#End Region

#Region "Wrapper / Preservation / Lookup"
        ' Ensure Tag is wrapped with our sentinel, preserving any existing value (including Object()).
        Private Shared Sub EnsureWrapped(ctrl As Control)
            ' Already wrapped?
            If IsWrapped(ctrl.Tag) Then
                ' If original slot empty, fill it
                Dim arr = DirectCast(ctrl.Tag, Object())
                If (arr(IDX_ORIGINAL) Is Nothing OrElse arr(IDX_ORIGINAL).ToString() = "") Then
                    arr(IDX_ORIGINAL) = If(String.IsNullOrEmpty(ctrl.Text), ctrl.Name, ctrl.Text)
                End If
                Return
            End If

            Dim originalText = If(String.IsNullOrEmpty(ctrl.Text), ctrl.Name, ctrl.Text)

            If ctrl.Tag Is Nothing Then
                ctrl.Tag = New Object() {originalText, Nothing, LOC_SENTINEL}
            Else
                ' If Tag was Object(), preserve entire array as user payload
                Dim userPayload As Object = ctrl.Tag
                ctrl.Tag = New Object() {originalText, userPayload, LOC_SENTINEL}
            End If
        End Sub

        Private Shared Function IsWrapped(tagObj As Object) As Boolean
            If tagObj Is Nothing Then Return False
            If TypeOf tagObj Is Object() Then
                Dim arr = DirectCast(tagObj, Object())
                If arr.Length >= 3 AndAlso
                   TypeOf arr(arr.Length - 1) Is String AndAlso
                   String.Equals(arr(arr.Length - 1).ToString(), LOC_SENTINEL, StringComparison.Ordinal) Then
                    Return True
                End If
            End If
            Return False
        End Function

        Private Shared Function GetOriginal(ctrl As Control) As String
            If Not IsWrapped(ctrl.Tag) Then Return Nothing
            Dim arr = DirectCast(ctrl.Tag, Object())
            Return If(arr(IDX_ORIGINAL), Nothing)?.ToString()
        End Function

        Private Shared Function GetUserPayload(ctrl As Control) As Object
            If Not IsWrapped(ctrl.Tag) Then Return ctrl.Tag
            Dim arr = DirectCast(ctrl.Tag, Object())
            Return arr(IDX_USERDATA)
        End Function

        Private Shared Function GetLookupKey(ctrl As Control) As String
            If Not IsWrapped(ctrl.Tag) Then
                ' Legacy behavior: plain Tag value or Name
                If ctrl.Tag Is Nothing Then Return ctrl.Name
                Return ctrl.Tag.ToString()
            End If

            Dim original = GetOriginal(ctrl)
            Dim userPayload = GetUserPayload(ctrl)

            ' If user payload is a non-empty string treat it as translation key
            Dim userKey = TryCast(userPayload, String)
            If Not String.IsNullOrEmpty(userKey) Then Return userKey

            ' Fallback to original text
            If Not String.IsNullOrEmpty(original) Then Return original

            Return ctrl.Name
        End Function

        Private Shared Sub ApplyTextTranslation(ctrl As Control, translationDict As IDictionary(Of String, String))
            Dim key = GetLookupKey(ctrl)
            Dim translated As String = Nothing
            If translationDict.TryGetValue(key, translated) Then
                If ctrl.Text <> translated Then ctrl.Text = translated
            Else
                ResetFromWrapper(ctrl)
            End If
        End Sub

        Private Shared Sub ResetFromWrapper(ctrl As Control)
            Dim orig = GetOriginal(ctrl)
            If Not String.IsNullOrEmpty(orig) AndAlso ctrl.Text <> orig Then
                ctrl.Text = orig
            End If
        End Sub
#End Region

#Region "Classification"
        Private Shared Function IsStandardTextControl(ctrl As Control) As Boolean
            Return TypeOf ctrl Is Label OrElse
                   TypeOf ctrl Is Button OrElse
                   TypeOf ctrl Is CheckBox OrElse
                   TypeOf ctrl Is RadioButton OrElse
                   TypeOf ctrl Is GroupBox OrElse
                   TypeOf ctrl Is TabPage
        End Function
#End Region

#Region "Custom Button (CButton via reflection)"
        Private Shared Sub TranslateCButton(ctrl As Control, imageResourceManager As ResourceManager)
            Dim origProp = ctrl.GetType().GetProperty("OriginalImageName")
            If origProp Is Nothing Then Return
            Dim original = TryCast(origProp.GetValue(ctrl, Nothing), String)
            If String.IsNullOrWhiteSpace(original) Then Return
            Dim baseKey = "btn" & original.ToLower()
            Dim key = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft,
                         baseKey & "_" & CultureInfo.CurrentCulture.Name.Replace("-", "_").ToLower(),
                         baseKey)
            Dim img = ResolveImage(imageResourceManager, key, baseKey)
            If img IsNot Nothing Then ctrl.GetType().GetProperty("Image")?.SetValue(ctrl, img, Nothing)
        End Sub

        Private Shared Sub ResetCButton(ctrl As Control, imageResourceManager As ResourceManager)
            Dim origProp = ctrl.GetType().GetProperty("OriginalImageName")
            If origProp Is Nothing Then Return
            Dim original = TryCast(origProp.GetValue(ctrl, Nothing), String)
            If String.IsNullOrWhiteSpace(original) Then Return
            Dim baseKey = "btn" & original.ToLower()
            Dim img = ResolveImage(imageResourceManager, baseKey)
            If img IsNot Nothing Then ctrl.GetType().GetProperty("Image")?.SetValue(ctrl, img, Nothing)
        End Sub

        Private Shared Function ResolveImage(rm As ResourceManager,
                                             ParamArray keys() As String) As Image
            Dim mgr = If(rm, My.Resources.ResourceManager)
            For Each k In keys
                If String.IsNullOrWhiteSpace(k) Then Continue For
                Dim obj = mgr.GetObject(k)
                If obj IsNot Nothing Then Return TryCast(obj, Image)
            Next
            Return Nothing
        End Function
#End Region

#Region "Tabs"
        Private Shared Sub TranslateTabControl(tc As TabControl,
                                               translationDict As IDictionary(Of String, String))
            If tc Is Nothing Then Return
            For Each page As TabPage In tc.TabPages
                EnsureWrapped(page)
                ApplyTextTranslation(page, translationDict)
            Next
        End Sub
#End Region

#Region "DataGrid / DataGridView"
        Private Shared Sub TranslateDataGridView(dgv As DataGridView,
                                                 translationDict As IDictionary(Of String, String))
            If dgv Is Nothing Then Return
            For Each col As DataGridViewColumn In dgv.Columns
                Dim key = If(col.Tag IsNot Nothing, col.Tag.ToString(), col.Name)
                Dim translated As String = Nothing
                If translationDict.TryGetValue(key, translated) Then
                    col.HeaderText = translated
                ElseIf col.Tag IsNot Nothing Then
                    col.HeaderText = col.Tag.ToString()
                End If
            Next
        End Sub

        Private Shared Sub ResetDataGridView(dgv As DataGridView)
            If dgv Is Nothing Then Return
            For Each col As DataGridViewColumn In dgv.Columns
                If col.Tag Is Nothing Then
                    col.Tag = col.HeaderText
                Else
                    col.HeaderText = col.Tag.ToString()
                End If
            Next
        End Sub

        Private Shared Sub TranslateDataGrid(grid As DataGrid,
                                             translationDict As IDictionary(Of String, String))
            If grid Is Nothing Then Return
            Dim key = If(grid.Tag IsNot Nothing, grid.Tag.ToString(), grid.Name)
            Dim translated As String = Nothing
            If translationDict.TryGetValue(key, translated) Then
                grid.CaptionText = translated
            ElseIf grid.Tag IsNot Nothing Then
                grid.CaptionText = grid.Tag.ToString()
            End If
        End Sub

        Private Shared Sub ResetDataGrid(grid As DataGrid)
            If grid Is Nothing Then Return
            If grid.Tag IsNot Nothing Then grid.CaptionText = grid.Tag.ToString()
        End Sub
#End Region

#Region "ToolStrip / MenuStrip"
        Public Shared Sub TranslateToolStrip(tool As ToolStrip,
                                             translationDict As IDictionary(Of String, String),
                                             Optional buttonImageTranslator As Action(Of ToolStripButton) = Nothing,
                                             Optional imageResourceManager As ResourceManager = Nothing)
            If tool Is Nothing OrElse translationDict Is Nothing Then Return
            For Each item As ToolStripItem In tool.Items
                TranslateToolStripItem(item, translationDict, buttonImageTranslator, imageResourceManager)
            Next
        End Sub

        Public Shared Sub TranslateMenuStrip(menu As MenuStrip,
                                             translationDict As IDictionary(Of String, String),
                                             Optional applyRtl As Boolean = False,
                                             Optional rightToLeft As Boolean = False,
                                             Optional font As Font = Nothing,
                                             Optional buttonImageTranslator As Action(Of ToolStripButton) = Nothing,
                                             Optional imageResourceManager As ResourceManager = Nothing)
            If menu Is Nothing OrElse translationDict Is Nothing Then Return
            For Each item As ToolStripItem In menu.Items
                TranslateToolStripItem(item, translationDict, buttonImageTranslator, imageResourceManager)
            Next
            If applyRtl Then menu.RightToLeft = If(rightToLeft, Windows.Forms.RightToLeft.Yes, Windows.Forms.RightToLeft.No)
            If font IsNot Nothing Then menu.Font = font
            menu.Refresh()
        End Sub

        Public Shared Sub TranslateContextMenuStrip(ctx As ContextMenuStrip,
                                                    translationDict As IDictionary(Of String, String),
                                                    Optional buttonImageTranslator As Action(Of ToolStripButton) = Nothing,
                                                    Optional imageResourceManager As ResourceManager = Nothing)
            If ctx Is Nothing OrElse translationDict Is Nothing Then Return
            For Each item As ToolStripItem In ctx.Items
                TranslateToolStripItem(item, translationDict, buttonImageTranslator, imageResourceManager)
            Next
            ctx.Refresh()
        End Sub

        Public Shared Sub TranslateToolStripItem(item As ToolStripItem,
                                                 translationDict As IDictionary(Of String, String),
                                                 Optional buttonImageTranslator As Action(Of ToolStripButton) = Nothing,
                                                 Optional imageResourceManager As ResourceManager = Nothing)
            EnsureWrappedToolStripItem(item)
            If item Is Nothing OrElse translationDict Is Nothing Then Return
            Dim textKey As String = Nothing
            Dim tipKey As String = Nothing
            GetKeysFromTag(item, textKey, tipKey)

            If String.IsNullOrWhiteSpace(textKey) Then
                textKey = If(Not String.IsNullOrWhiteSpace(item.Text), item.Text, item.Name)
            End If
            If String.IsNullOrWhiteSpace(tipKey) Then tipKey = item.ToolTipText

            Dim translated As String = Nothing
            If translationDict.TryGetValue(textKey, translated) AndAlso item.Text <> translated Then
                item.Text = translated
            End If
            If Not String.IsNullOrWhiteSpace(tipKey) AndAlso translationDict.TryGetValue(tipKey, translated) AndAlso item.ToolTipText <> translated Then
                item.ToolTipText = translated
            End If

            Dim btn = TryCast(item, ToolStripButton)
            If btn IsNot Nothing AndAlso buttonImageTranslator IsNot Nothing Then
                buttonImageTranslator(btn)
            End If

            Dim dd = TryCast(item, ToolStripDropDownItem)
            If dd IsNot Nothing Then
                For Each subItem As ToolStripItem In dd.DropDownItems
                    TranslateToolStripItem(subItem, translationDict, buttonImageTranslator, imageResourceManager)
                Next
            End If
        End Sub

        Private Shared Sub EnsureWrappedToolStripItem(item As ToolStripItem)
            If item.Tag Is Nothing OrElse Not (TypeOf item.Tag Is Object()) OrElse Not IsWrapped(item.Tag) Then
                Dim originalText = If(String.IsNullOrEmpty(item.Text), item.Name, item.Text)
                Dim originalTip = If(String.IsNullOrEmpty(item.ToolTipText), Nothing, item.ToolTipText)
                item.Tag = New Object() {originalText, originalTip, LOC_SENTINEL}
            End If
        End Sub

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

        Public Shared Sub TranslateToolStripButtonImage(btn As ToolStripButton)
            If btn Is Nothing Then Return
            Dim resourceName = btn.Name.ToLower()
            If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                resourceName &= "_" & CultureInfo.CurrentCulture.Name.Replace("-", "_").ToLower()
            ElseIf btn.Image IsNot Nothing AndAlso btn.Image.Tag IsNot Nothing Then
                resourceName = btn.Image.Tag.ToString()
            End If
            Dim img = TryCast(My.Resources.ResourceManager.GetObject(resourceName), Image)
            If img IsNot Nothing Then btn.Image = img
        End Sub

        Public Shared Sub ResetToolStripButtonImage(btn As ToolStripButton)
            If btn Is Nothing Then Return
            Dim resourceName = btn.Name.ToLower()
            Dim img = TryCast(My.Resources.ResourceManager.GetObject(resourceName), Image)
            If img IsNot Nothing Then btn.Image = img
        End Sub

        Private Shared Sub GetKeysFromTag(item As ToolStripItem,
                                          ByRef textKey As String,
                                          ByRef tipKey As String)
            textKey = Nothing
            tipKey = Nothing
            If item.Tag Is Nothing Then Return
            If TypeOf item.Tag Is Object() Then
                Dim arr = DirectCast(item.Tag, Object())
                If arr.Length > 0 AndAlso arr(0) IsNot Nothing Then textKey = arr(0).ToString()
                If arr.Length > 1 AndAlso arr(1) IsNot Nothing Then tipKey = arr(1).ToString()
            Else
                textKey = item.Tag.ToString()
            End If
        End Sub

        Private Shared Sub ResetItemToOriginalTag(item As ToolStripItem)
            If item Is Nothing Then Return
            If item.Tag IsNot Nothing AndAlso TypeOf item.Tag Is Object() Then
                Dim arr = DirectCast(item.Tag, Object())
                If arr.Length > 0 AndAlso arr(0) IsNot Nothing Then item.Text = CStr(arr(0))
                If arr.Length > 1 AndAlso arr(1) IsNot Nothing Then item.ToolTipText = CStr(arr(1))
            ElseIf item.Tag IsNot Nothing Then
                item.Text = item.Tag.ToString()
                item.ToolTipText = ""
            End If
            Dim dd = TryCast(item, ToolStripDropDownItem)
            If dd IsNot Nothing Then
                For Each subItem As ToolStripItem In dd.DropDownItems
                    ResetItemToOriginalTag(subItem)
                Next
            End If
        End Sub
#End Region

    End Class
End Namespace