Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary

' General localization helper for WinForms controls (was ToolStripLocalizer)
Public NotInheritable Class ControlLocalizer
    Private Sub New()
    End Sub

#Region "Public Orchestrators"

    ' Translate an entire control tree
    Public Shared Sub TranslateControls(root As Control,
                                        translationDict As IDictionary(Of String, String),
                                        targetLanguageIdNo As Integer,
                                        Optional toolStripButtonImageTranslator As Action(Of ToolStripButton) = Nothing)

        If root Is Nothing OrElse translationDict Is Nothing Then Return

        ' Breadth-first traversal
        Dim queue As New Queue(Of Control)
        queue.Enqueue(root)

        While queue.Count > 0
            Dim current = queue.Dequeue()

            TranslateSingleControl(current, translationDict, toolStripButtonImageTranslator, targetLanguageIdNo)

            For Each child As Control In current.Controls
                queue.Enqueue(child)
            Next
        End While
    End Sub

    ' Reset (restore original captions from Tag when available)
    Public Shared Sub ResetControls(root As Control,
                                    Optional resetToolStripButtonImage As Action(Of ToolStripButton) = Nothing)
        If root Is Nothing Then Return

        Dim queue As New Queue(Of Control)
        queue.Enqueue(root)

        While queue.Count > 0
            Dim current = queue.Dequeue()

            ResetSingleControl(current, resetToolStripButtonImage)

            For Each child As Control In current.Controls
                queue.Enqueue(child)
            Next
        End While
    End Sub

#End Region

#Region "Single Control Translation / Reset"

    Private Shared Sub TranslateSingleControl(ctrl As Control,
                                              translationDict As IDictionary(Of String, String),
                                              toolStripButtonImageTranslator As Action(Of ToolStripButton),
                                              targetLanguageIdNo As Integer)

        ' ToolStrip / MenuStrip
        If TypeOf ctrl Is MenuStrip Then
            TranslateMenuStrip(DirectCast(ctrl, MenuStrip), translationDict,
                               applyRtl:=False,
                               rightToLeft:=CultureInfo.CurrentCulture.TextInfo.IsRightToLeft,
                               font:=Nothing,
                               buttonImageTranslator:=toolStripButtonImageTranslator)
            Return
        ElseIf TypeOf ctrl Is ToolStrip Then
            TranslateToolStrip(DirectCast(ctrl, ToolStrip), translationDict, toolStripButtonImageTranslator)
            Return
        End If

        ' Data grids
        If TypeOf ctrl Is DataGridView Then
            TranslateDataGridView(DirectCast(ctrl, DataGridView), translationDict)
            Return
        ElseIf TypeOf ctrl Is DataGrid Then
            TranslateDataGrid(DirectCast(ctrl, DataGrid), translationDict)
            Return
        End If

        ' Tab controls
        If TypeOf ctrl Is CTabControl Then
            TranslateTabControl(DirectCast(ctrl, CTabControl), translationDict)
        ElseIf TypeOf ctrl Is TabControl Then
            For Each page As TabPage In DirectCast(ctrl, TabControl).TabPages
                TranslateTabPage(page, translationDict)
            Next
        End If

        ' Custom button
        If TypeOf ctrl Is CButton Then
            TranslateCButton(DirectCast(ctrl, CButton))
        End If

        ' Standard text-bearing
        If TypeOf ctrl Is Label OrElse
           TypeOf ctrl Is Button OrElse
           TypeOf ctrl Is CheckBox OrElse
           TypeOf ctrl Is RadioButton OrElse
           TypeOf ctrl Is GroupBox Then

            Dim key = GetLookupKey(ctrl)
            Dim translated As String = Nothing
            If translationDict.TryGetValue(key, translated) Then
                If ctrl.Text <> translated Then ctrl.Text = translated
            End If
        End If
    End Sub

    Private Shared Sub ResetSingleControl(ctrl As Control,
                                          resetToolStripButtonImage As Action(Of ToolStripButton))

        If TypeOf ctrl Is MenuStrip Then
            ResetMenuStripToOriginalTags(DirectCast(ctrl, MenuStrip))
            Return
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
            ResetDataGridView(DirectCast(ctrl, DataGridView))
            Return
        ElseIf TypeOf ctrl Is DataGrid Then
            ResetDataGrid(DirectCast(ctrl, DataGrid))
            Return
        End If

        If TypeOf ctrl Is CButton Then
            ResetCButtonImage(DirectCast(ctrl, CButton))
        End If

        If TypeOf ctrl Is TabControl Then
            For Each page As TabPage In DirectCast(ctrl, TabControl).TabPages
                ResetFromTag(page)
            Next
        End If

        ' Generic
        ResetFromTag(ctrl)
    End Sub

#End Region

#Region "Generic helpers"

    Private Shared Function GetLookupKey(ctrl As Control) As String
        ' Prefer Tag when present, else Name
        If ctrl.Tag IsNot Nothing Then
            Return ctrl.Tag.ToString()
        End If
        Return ctrl.Name
    End Function

    Private Shared Sub ResetFromTag(ctrl As Control)
        If ctrl.Tag IsNot Nothing Then
            Try
                ctrl.Text = ctrl.Tag.ToString()
            Catch
                ' ignore
            End Try
        End If
    End Sub

#End Region

#Region "CButton"

    Private Shared Sub TranslateCButton(btn As CButton)
        If btn Is Nothing OrElse btn.OriginalImageName Is Nothing Then Return
        Dim base = "btn" & btn.OriginalImageName.ToLower()
        Dim key = base
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            Dim cultureSuffix = CultureInfo.CurrentCulture.Name.Replace("-", "_").ToLower()
            key = base & "_" & cultureSuffix
        End If
        Dim obj = My.Resources.ResourceManager.GetObject(key)
        If obj IsNot Nothing Then
            btn.Image = DirectCast(obj, Image)
        End If
    End Sub

    Private Shared Sub ResetCButtonImage(btn As CButton)
        If btn Is Nothing OrElse btn.OriginalImageName Is Nothing Then Return
        Dim key = "btn" & btn.OriginalImageName.ToLower()
        Dim obj = My.Resources.ResourceManager.GetObject(key)
        If obj IsNot Nothing Then
            btn.Image = DirectCast(obj, Image)
        End If
    End Sub

#End Region

#Region "Tab Controls"

    Private Shared Sub TranslateTabControl(tc As TabControl,
                                           translationDict As IDictionary(Of String, String))
        If tc Is Nothing Then Return
        For Each page As TabPage In tc.TabPages
            TranslateTabPage(page, translationDict)
        Next
    End Sub

    Private Shared Sub TranslateTabPage(page As TabPage,
                                        translationDict As IDictionary(Of String, String))
        Dim key = GetLookupKey(page)
        Dim translated As String = Nothing
        If translationDict.TryGetValue(key, translated) Then
            If page.Text <> translated Then page.Text = translated
        End If
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
        If grid.Tag IsNot Nothing Then
            grid.CaptionText = grid.Tag.ToString()
        End If
    End Sub

#End Region

#Region "ToolStrip / MenuStrip (migrated from original ToolStripLocalizer)"

    Public Shared Sub TranslateToolStrip(tool As ToolStrip,
                                         translationDict As IDictionary(Of String, String),
                                         Optional buttonImageTranslator As Action(Of ToolStripButton) = Nothing)
        If tool Is Nothing OrElse translationDict Is Nothing Then Return
        For Each item As ToolStripItem In tool.Items
            TranslateToolStripItem(item, translationDict, buttonImageTranslator)
        Next
    End Sub

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
            menu.RightToLeft = If(rightToLeft, Windows.Forms.RightToLeft.Yes, Windows.Forms.RightToLeft.No)
        End If
        If font IsNot Nothing Then menu.Font = font
        menu.Refresh()
    End Sub

    Public Shared Sub TranslateContextMenuStrip(ctx As ContextMenuStrip,
                                                translationDict As IDictionary(Of String, String),
                                                Optional buttonImageTranslator As Action(Of ToolStripButton) = Nothing)
        If ctx Is Nothing OrElse translationDict Is Nothing Then Return
        For Each item As ToolStripItem In ctx.Items
            TranslateToolStripItem(item, translationDict, buttonImageTranslator)
        Next
        ctx.Refresh()
    End Sub

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
        If String.IsNullOrWhiteSpace(tipKey) Then tipKey = item.ToolTipText

        Dim translated As String = Nothing
        If translationDict.TryGetValue(txtKey, translated) Then
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

    ' ToolStripButton image translator (shared)
    Public Shared Sub TranslateToolStripButtonImage(btn As ToolStripButton)
        If btn Is Nothing Then Return
        Dim resourceName = btn.Name.ToLower()
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            Dim culture = CultureInfo.CurrentCulture.Name.Replace("-", "_").ToLower()
            resourceName &= "_" & culture
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