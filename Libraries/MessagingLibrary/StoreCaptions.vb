Option Strict On
Option Explicit On

Imports System.Diagnostics
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

' NOTE:
' Public API kept backward compatible:
'   Function StoreCaptions(frm As Object) As Collection
'   Function StoreTranslation(frm As Object) As Collection
'   Function SaveControlsOriginalText(frm As Object) As Collection
'
' Internally both StoreCaptions & StoreTranslation now delegate to a single Capture routine
' with different CaptureMode flags.
Public Class StoreCaptions
    Inherits System.ComponentModel.Component

#Region "Fields / Nested"
    Private _dAc1 As Dac

    ' Legacy VB Collection kept for existing consumers.
    Public ReadOnly Captions As New Collection

    ' Strongly typed mirror (optional consumers).
    Public ReadOnly CaptionMap As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)

    Private Enum CaptureMode
        CaptureAndPersistWithOriginalTagging   ' (Former StoreCaptions)
        CaptureAndPersistPreserveOriginalTexts ' (Former StoreTranslation)
        OriginalTextTaggingOnly                ' (Former SaveControlsOriginalText)
    End Enum

    <Serializable>
    Private Class OriginalMeta
        Public Property OriginalText As Object
        Public Sub New(value As Object)
            OriginalText = value
        End Sub
    End Class
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub

    Public Sub New(dac As Dac)
        _dAc1 = dac
    End Sub
#End Region

#Region "Public (Backward Compatible) API"
    ' Original behavior: tag + capture + persist.
    Public Function StoreCaptions(frm As Object) As Collection
        Return Capture(frm, CaptureMode.CaptureAndPersistWithOriginalTagging)
    End Function

    ' Original behavior: preserve original text (tag) + capture + persist (slightly different traversal previously).
    Public Function StoreTranslation(frm As Object) As Collection
        Return Capture(frm, CaptureMode.CaptureAndPersistPreserveOriginalTexts)
    End Function

    ' Original behavior: only tag / store originals (no persistence of new items).
    Public Function SaveControlsOriginalText(frm As Object) As Collection
        Return Capture(frm, CaptureMode.OriginalTextTaggingOnly)
    End Function
#End Region

#Region "Unified Capture"
    Private Function Capture(frm As Object, mode As CaptureMode) As Collection
        ' Enforce early binding under Option Strict On
        Dim formCtrl As Control = TryCast(frm, Control)
        If formCtrl Is Nothing Then Return Captions

        EnsureDacFromForm(formCtrl)

        Dim viewDisplayName = ResolveViewDisplayName(formCtrl)
        Dim systemViewIdNo As Int16 = 0

        ' Persist form + its own caption unless only tagging originals
        If mode <> CaptureMode.OriginalTextTaggingOnly Then
            InsertForm(viewDisplayName)
            systemViewIdNo = GetSystemViewIdNo(viewDisplayName)
            InsertTranslation(SafeToString(formCtrl.Text), systemViewIdNo)
        End If

        ' Tag original form text
        TagOriginal(formCtrl, formCtrl.Text)

        ' Add the form caption
        AddCaptionEntry(formCtrl, formCtrl.Name, SafeToString(formCtrl.Text), systemViewIdNo, mode)

        ' Traverse all child controls
        Dim allControls As New List(Of Control)
        FindControlRecursive(allControls, formCtrl)

        For Each c As Control In allControls
            Try
                ProcessControl(c, systemViewIdNo, mode)
            Catch ex As Exception
                Debug.WriteLine($"[StoreCaptions] Control processing error ({c.Name}): {ex.Message}")
            End Try
        Next

        Return Captions
    End Function
#End Region

#Region "Control Processing"
    Private Sub ProcessControl(ctrl As Control, systemViewIdNo As Int16, mode As CaptureMode)
        If TypeOf ctrl Is MenuStrip Then
            Dim ms = DirectCast(ctrl, MenuStrip)
            If mode = CaptureMode.OriginalTextTaggingOnly Then
                SaveOriginalMenuStripText(ms.Items, ms.Name)
            Else
                StoreMenuStripTranslation(ms.Items, ms.Name, systemViewIdNo, mode)
            End If
            Return
        End If

        If TypeOf ctrl Is ToolStrip Then
            Dim ts = DirectCast(ctrl, ToolStrip)
            For Each item As ToolStripItem In ts.Items
                ProcessToolStripItem(ts, item, systemViewIdNo, mode)
            Next
            Return
        End If

        If TypeOf ctrl Is DataGridView Then
            Dim dgv = DirectCast(ctrl, DataGridView)
            ProcessDataGridView(dgv, systemViewIdNo, mode)
            Return
        End If

        If TypeOf ctrl Is DataGrid Then
            Dim dg = DirectCast(ctrl, DataGrid)
            Dim original = dg.CaptionText
            If mode <> CaptureMode.CaptureAndPersistPreserveOriginalTexts Then TagOriginal(dg, original)
            AddCaptionEntry(dg, dg.Name, SafeToString(dg.Text), systemViewIdNo, mode)
            Return
        End If

        ' Skip unwanted control types
        If ShouldSkipControl(ctrl) Then Return

        Dim text = SafeToString(ctrl.Text)
        If String.IsNullOrWhiteSpace(text) Then Return

        If mode <> CaptureMode.CaptureAndPersistPreserveOriginalTexts Then
            TagOriginal(ctrl, text)
        End If

        AddCaptionEntry(ctrl, ctrl.Name, text, systemViewIdNo, mode)
    End Sub

    Private Sub ProcessToolStripItem(owner As ToolStrip, item As ToolStripItem, systemViewIdNo As Int16, mode As CaptureMode)
        Dim baseKey = owner.Name & "." & item.Name

        Dim txt = SafeToString(item.Text)
        Dim tip = SafeToString(item.ToolTipText)

        If mode <> CaptureMode.CaptureAndPersistPreserveOriginalTexts Then
            ' Tag both text + tooltip as array metadata
            TagOriginal(item, New Object() {txt, tip})
        End If

        If mode <> CaptureMode.OriginalTextTaggingOnly Then
            AddCompositeCaption(baseKey & ".Text", txt, systemViewIdNo)
            AddCompositeCaption(baseKey & ".ToolTipText", tip, systemViewIdNo)
        End If

        ' Recurse dropdown items
        Dim menuItem = TryCast(item, ToolStripMenuItem)
        If menuItem IsNot Nothing AndAlso menuItem.HasDropDownItems Then
            For Each child As ToolStripItem In menuItem.DropDownItems
                ProcessToolStripItem(owner, child, systemViewIdNo, mode)
            Next
        End If
    End Sub

    Private Sub ProcessDataGridView(dgv As DataGridView, systemViewIdNo As Int16, mode As CaptureMode)
        For Each col As DataGridViewColumn In dgv.Columns
            Dim header = SafeToString(col.HeaderText)
            If String.IsNullOrWhiteSpace(header) Then Continue For
            If mode <> CaptureMode.CaptureAndPersistPreserveOriginalTexts Then TagOriginal(col, header)
            If mode <> CaptureMode.OriginalTextTaggingOnly Then
                AddCompositeCaption(dgv.Name & "." & header, header, systemViewIdNo)
            End If
        Next
    End Sub

    Private Function ShouldSkipControl(c As Control) As Boolean
        Return TypeOf c Is TextBox _
               OrElse TypeOf c Is ComboBox _
               OrElse TypeOf c Is MaskedTextBox _
               OrElse TypeOf c Is FlowLayoutPanel _
               OrElse c.GetType().Name = "CCustomDateTimePicker"
    End Function
#End Region

#Region "Caption Entry Helpers"
    Private Sub AddCaptionEntry(source As Object, key As String, text As String, systemViewIdNo As Int16, mode As CaptureMode)
        If String.IsNullOrEmpty(key) Then Return
        If Not CaptionMap.ContainsKey(key) Then
            CaptionMap(key) = text
            Try
                Captions.Add(text, key) ' legacy collection
            Catch
                ' duplicate key in VB Collection: ignore
            End Try
        End If
        If mode <> CaptureMode.OriginalTextTaggingOnly Then
            InsertTranslation(text, systemViewIdNo)
        End If
    End Sub

    Private Sub AddCompositeCaption(key As String, text As String, systemViewIdNo As Int16)
        If String.IsNullOrEmpty(key) Then Return
        If Not CaptionMap.ContainsKey(key) Then
            CaptionMap(key) = text
            Try
                Captions.Add(text, key)
            Catch
            End Try
        End If
        InsertTranslation(text, systemViewIdNo)
    End Sub
#End Region

#Region "MenuStrip Traversal"
    Private Sub StoreMenuStripTranslation(items As ToolStripItemCollection, prefix As String, systemViewIdNo As Int16, mode As CaptureMode)
        For Each it As ToolStripItem In items
            Dim subMenu = TryCast(it, ToolStripMenuItem)
            If subMenu Is Nothing Then Continue For
            Dim path = prefix & "." & subMenu.Name
            Dim txt = SafeToString(subMenu.Text)
            If mode <> CaptureMode.CaptureAndPersistPreserveOriginalTexts Then TagOriginal(subMenu, txt)
            If Not String.IsNullOrEmpty(txt) AndAlso mode <> CaptureMode.OriginalTextTaggingOnly Then
                AddCompositeCaption(path, txt, systemViewIdNo)
            End If
            If subMenu.HasDropDownItems Then
                StoreMenuStripTranslation(subMenu.DropDownItems, path, systemViewIdNo, mode)
            End If
        Next
    End Sub

    Private Sub SaveOriginalMenuStripText(items As ToolStripItemCollection, prefix As String)
        For Each it As ToolStripItem In items
            Dim subMenu = TryCast(it, ToolStripMenuItem)
            If subMenu Is Nothing Then Continue For
            Dim txt = SafeToString(subMenu.Text)
            TagOriginal(subMenu, txt)
            If subMenu.HasDropDownItems Then
                SaveOriginalMenuStripText(subMenu.DropDownItems, prefix & "." & subMenu.Name)
            End If
        Next
    End Sub
#End Region

#Region "Tagging"
    Private Sub TagOriginal(target As Object, originalValue As Object)
        If target Is Nothing Then Return
        Try
            Dim pi = target.GetType().GetProperty("Tag")
            If pi Is Nothing Then Return
            Dim existing = pi.GetValue(target, Nothing)
            If existing Is Nothing OrElse TypeOf existing Is OriginalMeta Then
                pi.SetValue(target, New OriginalMeta(originalValue), Nothing)
            End If
        Catch ex As Exception
            Debug.WriteLine($"[StoreCaptions] TagOriginal failed: {ex.Message}")
        End Try
    End Sub
#End Region

#Region "Database Persistence"
    Public Sub InsertTranslation(text As String, systemViewIdNo As Int16)
        If Not GlobalVariables.TranslationMode Then Return
        If String.IsNullOrWhiteSpace(text) Then Return
        InsertWord(text)
        InsertFormItem(systemViewIdNo, text)
    End Sub

    Friend Sub InsertWord(word As String)
        If String.IsNullOrWhiteSpace(word) OrElse word = "  /  /" Then Return
        Dim cmd = "SELECT COUNT(*) FROM OriginalCaptions WHERE Caption = @word"
        Dim p = {"@word", word}
        Dim howMany = ExecScalarSafe(Of Int32)(cmd, p)
        If howMany = 0 Then
            ExecNonQuerySafe("INSERT INTO OriginalCaptions (Caption) VALUES (@word)", p)
        End If
    End Sub

    Public Sub InsertMessage(key As String, message As String)
        If String.IsNullOrWhiteSpace(key) Then Return
        Dim cmd = "SELECT COUNT(*) FROM OriginalMessage WHERE [Key] = @key"
        Dim p = {"@key", key}
        Dim howMany = ExecScalarSafe(Of Int32)(cmd, p)
        If howMany = 0 Then
            ExecNonQuerySafe("INSERT INTO OriginalMessage ([Key], [Message]) VALUES (@key, @message)",
                             {"@key", key, "@message", message})
        End If
    End Sub

    Public Sub CreateMessage(key As String, message As String)
        InsertMessage(key, message)
    End Sub

    Friend Sub InsertFormItem(systemViewIdNo As Int16, itemName As String)
        If String.IsNullOrWhiteSpace(itemName) Then Return
        ' Resolve caption id
        Dim captionId = ExecScalarSafe(Of Int32)(
            "SELECT IdNo FROM OriginalCaptions WHERE Caption = @itemName",
            {"@itemName", itemName})

        If captionId <= 0 Then Return

        Dim exists = ExecScalarSafe(Of Int32)(
            "SELECT COUNT(*) FROM SystemViewItem WHERE CaptionIdNo = @cid AND SystemViewIdNo = @sid",
            {"@cid", captionId, "@sid", systemViewIdNo})

        If exists = 0 Then
            ExecNonQuerySafe(
                "INSERT INTO SystemViewItem (SystemViewIdNo, CaptionIdNo) VALUES (@sid, @cid)",
                {"@sid", systemViewIdNo, "@cid", captionId})
        End If
    End Sub

    Friend Sub InsertForm(formName As String)
        If String.IsNullOrWhiteSpace(formName) Then Return
        Dim exists = ExecScalarSafe(Of Int32)(
            "SELECT COUNT(*) FROM SystemView WHERE SystemViewName = @name",
            {"@name", formName})
        If exists = 0 Then
            ExecNonQuerySafe(
                "INSERT INTO SystemView (SystemViewName) VALUES (@name)",
                {"@name", formName})
        End If
    End Sub

    Friend Function GetSystemViewIdNo(formName As String) As Int16
        If String.IsNullOrWhiteSpace(formName) Then Return 0
        Return ExecScalarSafe(Of Int16)(
            "SELECT IdNo FROM SystemView WHERE SystemViewName = @name",
            {"@name", formName})
    End Function
#End Region

#Region "DB Helpers"
    Private Sub EnsureDacFromForm(frm As Object)
        If _dAc1 IsNot Nothing Then Return
        Try
            Dim pi = frm.GetType().GetProperty("TranslatorDAC")
            If pi IsNot Nothing Then
                _dAc1 = TryCast(pi.GetValue(frm, Nothing), Dac)
            End If
        Catch ex As Exception
            Debug.WriteLine($"[StoreCaptions] Could not resolve TranslatorDAC: {ex.Message}")
        End Try
    End Sub

    Private Function ExecScalarSafe(Of T)(sql As String, params() As Object) As T
        If _dAc1 Is Nothing Then Return Nothing
        Try
            Return _dAc1.ExecScalar(Of T)(sql, params)
        Catch ex As Exception
            Debug.WriteLine($"[StoreCaptions] ExecScalar failed: {ex.Message} | {sql}")
            Return Nothing
        End Try
    End Function

    Private Sub ExecNonQuerySafe(sql As String, params() As Object)
        If _dAc1 Is Nothing Then Return
        Try
            _dAc1.ExecCmd(sql, params)
        Catch ex As Exception
            Debug.WriteLine($"[StoreCaptions] ExecCmd failed: {ex.Message} | {sql}")
        End Try
    End Sub
#End Region

#Region "Utilities"
    Private Function ResolveViewDisplayName(frm As Object) As String
        Try
            Dim prop = frm.GetType().GetProperty("ViewDisplayName")
            If prop IsNot Nothing Then
                Dim val = SafeToString(prop.GetValue(frm, Nothing))
                If Not String.IsNullOrWhiteSpace(val) Then Return val
            End If
        Catch
        End Try
        Try
            Dim nameProp = frm.GetType().GetProperty("Name")
            If nameProp IsNot Nothing Then
                Return SafeToString(nameProp.GetValue(frm, Nothing))
            End If
        Catch
        End Try
        Return "UnnamedView"
    End Function

    Private Function SafeToString(obj As Object) As String
        If obj Is Nothing Then Return String.Empty
        Return Convert.ToString(obj, Globalization.CultureInfo.InvariantCulture)
    End Function

    Public Function FindControlRecursive(list As List(Of Control), parentControl As Control) As List(Of Control)
        If parentControl Is Nothing Then Return list
        list.Add(parentControl)
        For Each child As Control In parentControl.Controls
            FindControlRecursive(list, child)
        Next
        Return list
    End Function
#End Region

End Class
'Imports AATM.Libraries.GlobalFuncNSub

'Public Class StoreCaptions
'    Inherits System.ComponentModel.Component

'    ' Generated form code omitted, except for the following overloaded
'    ' constructor that I added:
'    Private _dAc1 As Dac

'    'Public Sub New()
'    '    MyBase.New()
'    'End Sub

'    Public Sub New(ByVal dac As Dac)
'        MyBase.New()
'        'This call is required by the Component Designer.
'        'Add any initialization after the InitializeComponent() call
'        _dAc1 = dac
'    End Sub

'    Public Sub New()
'    End Sub

'    Public Captions As New Collection

'    Function StoreCaptions(ByVal frm As Object) As Collection
'        Dim systemViewIdNo As Int16
'        Dim viewDisplayName As String
'        _dAc1 = frm.TranslatorDAC
'        frm.Tag = frm.Text
'        If frm.ViewDisplayName Is Nothing OrElse frm.ViewDisplayName = "" Then
'            viewDisplayName = frm.Name
'        Else
'            viewDisplayName = frm.ViewDisplayName
'        End If
'        InsertForm(viewDisplayName)
'        systemViewIdNo = GetSystemViewIdNo(viewDisplayName)
'        InsertTranslation(frm.Text, systemViewIdNo)
'        Dim t As String
'        Dim allCtrl As New List(Of Control)
'        For Each cCtrl As Control In FindControlRecursive(allCtrl, frm)
'            If TypeOf cCtrl Is MenuStrip Then
'                Dim subMenuName = cCtrl.Name
'                Dim menuStrip As MenuStrip = cCtrl
'                StoreMenuStripTranslation(menuStrip.Items, subMenuName, systemViewIdNo)
'            ElseIf TypeOf cCtrl Is ToolStrip Then
'                Dim subMenuName = ""
'                Dim toolStrip As ToolStrip = cCtrl
'                Dim c As ToolStrip
'                c = cCtrl
'                For Each obj As Object In c.Items
'                    TranslateToolStrip(systemViewIdNo, c, obj)
'                Next
'            ElseIf TypeOf cCtrl Is DataGridView Then
'                Dim c As DataGridView
'                c = cCtrl
'                For Each col As DataGridViewColumn In c.Columns
'                    TranslateDataGridView(systemViewIdNo, c, col)
'                Next
'            ElseIf TypeOf cCtrl Is DataGrid Then
'                t = CType(cCtrl, DataGrid).CaptionText
'                cCtrl.Tag = t
'                Captions.Add(cCtrl.Text, cCtrl.Name)
'            Else
'                Try
'                    If TypeOf cCtrl Is TextBox OrElse
'                       TypeOf cCtrl Is ComboBox OrElse
'                       TypeOf cCtrl Is MaskedTextBox OrElse
'                       TypeOf cCtrl Is FlowLayoutPanel Then
'                        'Debugger.Break()
'                    Else
'                        'TypeOf cCtrl Is Button OrElse
'                        'TypeOf cCtrl Is Label OrElse
'                        'TypeOf cCtrl Is CheckBox OrElse
'                        'TypeOf cCtrl Is RadioButton OrElse
'                        'TypeOf cCtrl Is TabControl OrElse
'                        'TypeOf cCtrl Is TreeView OrElse
'                        'TypeOf cCtrl Is Form OrElse
'                        'TypeOf cCtrl Is DataGrid OrElse
'                        'TypeOf cCtrl Is TabPage Then
'                        'TypeOf cCtrl Is AATM.Libraries.CBaseControlsLibrary.CButton Then
'                        t = cCtrl.Text
'                        If Not String.IsNullOrWhiteSpace(t) Then
'                            cCtrl.Tag = t
'                            Captions.Add(cCtrl.Text, cCtrl.Name)
'                            InsertTranslation(t, systemViewIdNo)
'                        End If
'                    End If
'                Catch ex As Exception

'                End Try
'            End If
'            'End If
'        Next
'        Return Captions
'    End Function

'    Function StoreTranslation(ByVal frm As Object) As Collection
'        Dim systemViewIdNo As Int16
'        Dim viewDisplayName As String
'        _dAc1 = frm.TranslatorDAC
'        SaveOriginalText(frm, frm.Text)
'        frm.Tag = frm.Text
'        If frm.ViewDisplayName Is Nothing OrElse frm.ViewDisplayName = "" Then
'            viewDisplayName = frm.Name
'        Else
'            viewDisplayName = frm.ViewDisplayName
'        End If
'        InsertForm(viewDisplayName)
'        systemViewIdNo = GetSystemViewIdNo(viewDisplayName)
'        InsertTranslation(frm.Text, systemViewIdNo)
'        Dim t As String
'        Dim allCtrl As New List(Of Control)
'        For Each cCtrl As Control In FindControlRecursive(allCtrl, frm)
'            If TypeOf cCtrl Is MenuStrip Then
'                Dim subMenuName = cCtrl.Name
'                Dim menuStrip As MenuStrip = cCtrl
'                StoreMenuStripTranslation(menuStrip.Items, subMenuName, systemViewIdNo)
'            ElseIf TypeOf cCtrl Is ToolStrip Then
'                Dim subMenuName = ""
'                Dim toolStrip As ToolStrip = cCtrl
'                Dim c As ToolStrip
'                c = cCtrl
'                For Each obj As Object In c.Items
'                    StoreToolStripTranslation(systemViewIdNo, c, obj)
'                Next
'            ElseIf TypeOf cCtrl Is DataGridView Then
'                Dim c As DataGridView
'                c = cCtrl
'                For Each col As DataGridViewColumn In c.Columns
'                    StoreDataGridViewTranslation(systemViewIdNo, c, col)
'                Next
'            ElseIf TypeOf cCtrl Is DataGrid Then
'                Captions.Add(cCtrl.Text, cCtrl.Name)
'            Else
'                Try
'                    If TypeOf cCtrl Is TextBox OrElse
'                       TypeOf cCtrl Is ComboBox OrElse
'                       TypeOf cCtrl Is MaskedTextBox OrElse
'                       cCtrl.GetType().Name = "CCustomDateTimePicker" OrElse
'                       TypeOf cCtrl Is FlowLayoutPanel Then
'                    Else
'                        'TypeOf cCtrl Is Button OrElse
'                        'TypeOf cCtrl Is Label OrElse
'                        'TypeOf cCtrl Is CheckBox OrElse
'                        'TypeOf cCtrl Is RadioButton OrElse
'                        'TypeOf cCtrl Is TabControl OrElse
'                        'TypeOf cCtrl Is TreeView OrElse
'                        'TypeOf cCtrl Is Form OrElse
'                        'TypeOf cCtrl Is DataGrid OrElse
'                        'TypeOf cCtrl Is TabPage Then
'                        'TypeOf cCtrl Is AATM.Libraries.CBaseControlsLibrary.CButton Then
'                        t = cCtrl.Text
'                        'If t = "Gender" Then
'                        '    Debugger.Break()
'                        'End If
'                        If Not String.IsNullOrWhiteSpace(t) Then
'                            Captions.Add(cCtrl.Text, cCtrl.Name)
'                            InsertTranslation(t, systemViewIdNo)
'                        End If
'                    End If
'                Catch ex As Exception

'                End Try
'            End If
'        Next
'        Return Captions
'    End Function

'    Private Sub TranslateToolStrip(SystemViewIdNo As Short, c As ToolStrip, obj As Object)
'        Dim t As String
'        Try
'            obj.Tag = {obj.Text, obj.ToolTipText}
'            If Not String.IsNullOrEmpty(obj.Text) Then
'                t = obj.Text
'                Captions.Add(t, c.Name + "." + obj.Name + ".Text")
'                InsertTranslation(t, SystemViewIdNo)
'            Else
'                ' add an empty place holder
'                Captions.Add("", c.Name + "." + obj.Name + ".Text")
'            End If
'            If Not String.IsNullOrEmpty(obj.ToolTipText) Then
'                t = obj.ToolTipText
'                Captions.Add(t, c.Name + "." + obj.Name + ".ToolTipText")
'                InsertTranslation(t, SystemViewIdNo)
'            Else
'                Captions.Add("", c.Name + "." + obj.Name + ".ToolTipText")
'            End If
'        Catch ex As Exception

'        End Try
'    End Sub

'    Private Sub StoreToolStripTranslation(systemViewIdNo As Short, c As ToolStrip, obj As Object)
'        Dim t As String
'        Try
'            If Not String.IsNullOrEmpty(obj.Text) Then
'                t = obj.Text
'                Captions.Add(t, c.Name + "." + obj.Name + ".Text")
'                InsertTranslation(t, systemViewIdNo)
'            Else
'                ' add an empty place holder
'                Captions.Add("", c.Name + "." + obj.Name + ".Text")
'            End If
'            If Not String.IsNullOrEmpty(obj.ToolTipText) Then
'                t = obj.ToolTipText
'                Captions.Add(t, c.Name + "." + obj.Name + ".ToolTipText")
'                InsertTranslation(t, systemViewIdNo)
'            Else
'                Captions.Add("", c.Name + "." + obj.Name + ".ToolTipText")
'            End If
'        Catch ex As Exception

'        End Try
'    End Sub

'    Private Sub SaveOriginalText(ByRef originalObject As Object, originalText As Object)
'        originalObject.Tag = originalText
'    End Sub

'    Private Sub SaveOriginalToolStripText(systemViewIdNo As Short, c As ToolStrip, obj As Object)
'        obj.Tag = {obj.Text, obj.ToolTipText}
'    End Sub

'    Private Sub TranslateDataGridView(systemViewIdNo As Short, c As DataGridView, obj As Object)
'        Dim t As String
'        Try
'            For Each col As DataGridViewColumn In c.Columns
'                t = col.HeaderText
'                Captions.Add(t, c.Name + "." + col.HeaderText)
'                InsertTranslation(t, systemViewIdNo)
'            Next
'        Catch ex As Exception

'        End Try
'    End Sub

'    Private Sub StoreDataGridViewTranslation(systemViewIdNo As Short, c As DataGridView, obj As Object)
'        Dim t As String
'        Try
'            For Each col As DataGridViewColumn In c.Columns
'                t = col.HeaderText
'                Captions.Add(t, c.Name + "." + col.HeaderText)
'                InsertTranslation(t, systemViewIdNo)
'            Next
'        Catch ex As Exception

'        End Try
'    End Sub

'    'Public Sub StoreMessage(ByVal message As Object)
'    '    InsertMessage(message)
'    'End Sub

'    Private Sub SetMenuStripItems(dropDownItems As ToolStripItemCollection, subMenuName As String, systemViewIdNo As Int16)
'        'Try
'        '    For Each obj As Object In dropDownItems
'        '        Dim subMenu = TryCast(obj, ToolStripMenuItem)
'        '        If subMenu IsNot Nothing Then
'        '            subMenuName = subMenuName + "." + obj.Name
'        '            If Not String.IsNullOrEmpty(obj.Text) Then
'        '                Captions.Add(obj.text, subMenuName)
'        '                InsertTranslation(obj.Text, systemViewIdNo)
'        '                obj.Tag = obj.Text
'        '            End If
'        '            If subMenu.HasDropDownItems Then
'        '                SetMenuStripItems(subMenu.DropDownItems, subMenuName, systemViewIdNo)
'        '            End If
'        '        End If
'        '    Next
'        'Catch ex As Exception
'        '    MessageBox.Show(ex.Message, $"SetMenuStripItems", MessageBoxButtons.OK, MessageBoxIcon.[Error])
'        'End Try
'    End Sub

'    Private Sub StoreMenuStripTranslation(dropDownItems As ToolStripItemCollection, subMenuName As String, systemViewIdNo As Int16)
'        Try
'            For Each obj As Object In dropDownItems
'                Dim subMenu = TryCast(obj, ToolStripMenuItem)
'                If subMenu IsNot Nothing Then
'                    subMenuName = subMenuName + "." + obj.Name
'                    If Not String.IsNullOrEmpty(obj.Text) Then
'                        Captions.Add(obj.text, subMenuName)
'                        InsertTranslation(obj.Text, systemViewIdNo)
'                    End If
'                    If subMenu.HasDropDownItems Then
'                        StoreMenuStripTranslation(subMenu.DropDownItems, subMenuName, systemViewIdNo)
'                    End If
'                End If
'            Next
'        Catch ex As Exception
'            'MessageBox.Show(ex.Message, $"SetMenuStripItems", MessageBoxButtons.OK, MessageBoxIcon.[Error])
'        End Try
'    End Sub

'    Private Sub SaveOriginalMenuStripText(dropDownItems As ToolStripItemCollection, subMenuName As String)
'        For Each obj As Object In dropDownItems
'            Dim subMenu = TryCast(obj, ToolStripMenuItem)
'            If subMenu IsNot Nothing Then
'                subMenuName = subMenuName + "." + obj.Name
'                If Not String.IsNullOrEmpty(obj.Text) Then
'                    SaveOriginalText(obj, obj.Text)
'                End If
'                If subMenu.HasDropDownItems Then
'                    SaveOriginalMenuStripText(subMenu.DropDownItems, subMenuName)
'                End If
'            End If
'        Next
'    End Sub

'    Function SaveControlsOriginalText(ByVal frm As Object) As Collection
'        frm.Tag = frm.Text
'        Dim t As String
'        Dim allCtrl As New List(Of Control)
'        For Each cCtrl As Control In FindControlRecursive(allCtrl, frm)
'            If TypeOf cCtrl Is MenuStrip Then
'                Dim subMenuName = cCtrl.Name
'                Dim menuStrip As MenuStrip = cCtrl
'                SaveOriginalMenuStripText(menuStrip.Items, subMenuName)
'            ElseIf TypeOf cCtrl Is ToolStrip Then
'                Dim c As ToolStrip = cCtrl
'                For Each obj As Object In c.Items
'                    SaveOriginalText(obj, {obj.Text, obj.TooltipText})
'                Next
'            ElseIf TypeOf cCtrl Is DataGridView Then
'                Dim c As DataGridView = cCtrl
'                For Each col As DataGridViewColumn In c.Columns
'                    SaveOriginalText(col, col.HeaderText)
'                Next
'            ElseIf TypeOf cCtrl Is DataGrid Then
'                t = CType(cCtrl, DataGrid).CaptionText
'                SaveOriginalText(cCtrl, t)
'            Else
'                Try
'                    If TypeOf cCtrl Is TextBox OrElse
'                       TypeOf cCtrl Is ComboBox OrElse
'                       TypeOf cCtrl Is MaskedTextBox OrElse
'                       cCtrl.GetType().Name = "CCustomDateTimePicker" OrElse
'                       TypeOf cCtrl Is FlowLayoutPanel Then
'                        'Debugger.Break()
'                    Else
'                        'TypeOf cCtrl Is Button OrElse
'                        'TypeOf cCtrl Is Label OrElse
'                        'TypeOf cCtrl Is CheckBox OrElse
'                        'TypeOf cCtrl Is RadioButton OrElse
'                        'TypeOf cCtrl Is TabControl OrElse
'                        'TypeOf cCtrl Is TreeView OrElse
'                        'TypeOf cCtrl Is Form OrElse
'                        'TypeOf cCtrl Is DataGrid OrElse
'                        'TypeOf cCtrl Is TabPage Then
'                        'TypeOf cCtrl Is AATM.Libraries.CBaseControlsLibrary.CButton Then
'                        t = cCtrl.Text
'                        If Not String.IsNullOrWhiteSpace(t) Then
'                            SaveOriginalText(cCtrl, t)
'                        End If
'                    End If
'                Catch ex As Exception

'                End Try
'            End If
'        Next
'        Return Captions
'    End Function

'    Friend Sub InsertWord(ByVal word As String)
'        'If word.Contains("'") Then
'        '    Debugger.Break()
'        'End If
'        Dim cmd As String
'        If Not (String.IsNullOrEmpty(word) OrElse word = "  /  /") Then
'            Dim params() As Object = {"@word", word}
'            cmd = "SELECT COUNT(*) From OriginalCaptions where Caption = @word"
'            Dim howMany As Int32 = _dAc1.ExecScalar(Of Int32)(cmd, params)
'            If howMany = 0 Then
'                'cmd = "INSERT INTO OriginalCaptions (caption) values ( '" + word + "')"
'                cmd = "INSERT INTO OriginalCaptions (caption) values ( @word )"
'                _dAc1.ExecCmd(cmd, params)
'            End If
'        End If
'    End Sub

'    Public Sub CreateMessage(ByVal Key As String, ByVal message As String)
'        InsertMessage(Key, message)
'        'Return GetTrans(key)
'    End Sub

'    Public Sub InsertMessage(ByVal key As String, ByVal message As String)
'        Dim cmd As String
'        Dim params() As Object = {"@key", key, "@message", message}
'        cmd = "SELECT COUNT(*) FROM OriginalMessage where Key = @message"
'        Dim howMany As Int32 = _dAc1.ExecScalar(Of Int32)(cmd, params)
'        If howMany = 0 Then
'            cmd = "INSERT INTO OriginalMessage (key, message) values (@key, @message)"
'            _dAc1.ExecCmd(cmd, params)
'        End If
'    End Sub

'    Public Sub InsertTranslation(ByVal text As String, ByVal systemViewIdNo As Int16)
'        If GlobalVariables.TranslationMode Then
'            InsertWord(text)
'            InsertFormItem(systemViewIdNo, text)
'        End If
'    End Sub

'    Friend Sub InsertFormItem(ByVal systemViewIdNo As Int16, ByVal itemName As String)
'        Dim cmd As String
'        Dim captionIdNo As Int32
'        cmd = "Select IdNo From OriginalCaptions where Caption = @itemName"
'        Dim params() As Object = {"@ItemName", itemName}
'        captionIdNo = _dAc1.ExecScalar(Of Int32)(cmd, params)
'        'if item.ToString().TrimEnd() = "Gender" then
'        '    debugger.Break()
'        'End If
'        cmd = "SELECT COUNT(*) FROM SystemViewItem where CaptionIdNo = " + captionIdNo.ToString() + " and SystemViewIdNo = " + systemViewIdNo.ToString()
'        Dim howMany As Integer = _dAc1.ExecScalar(Of Int16)(cmd)
'        If howMany = 0 Then
'            cmd = "INSERT INTO SystemViewItem (SystemViewIdNo, CaptionIdNO) values ( " + systemViewIdNo.ToString() + "," + captionIdNo.ToString() + ")"
'            _dAc1.ExecCmd(cmd)
'        End If
'    End Sub

'    Friend Sub InsertForm(ByVal formName As String)
'        Dim cmd As String
'        Dim params() As Object = {"@FormName", formName}
'        cmd = "SELECT COUNT(*) FROM SystemView where SystemViewName = @formName "
'        Dim howMany As Int16 = _dAc1.ExecScalar(Of Int16)(cmd, params)
'        If howMany = 0 Then
'            cmd = "INSERT INTO SystemView (SystemViewName) values (@formName)"
'            _dAc1.ExecCmd(cmd, params)
'        End If
'    End Sub

'    Friend Function GetSystemViewIdNo(ByVal formName As String) As Int16
'        Dim cmd As String
'        Dim params() As Object = {"@FormName", formName}
'        cmd = "SELECT IdNo FROM SystemView where SystemViewName = @formName "
'        Return _dAc1.ExecScalar(Of Int16)(cmd, params)
'    End Function

'    'Friend Function IsTranslatable(ByVal ctrl As Control)
'    '    Dim retVal As Boolean = False
'    '    If o.GetType().GetInterfaces().Contains(GetType(ISomething)) Then
'    '        ' The interface is implemented
'    '    End If
'    '    Return retVal
'    'End Function

'    'Friend Function IsTranslatable(ByVal ctrl As Control)
'    '    If TypeOf ctrl Is Label OrElse
'    '               TypeOf ctrl Is Button OrElse
'    '               TypeOf ctrl Is CheckBox OrElse
'    '               TypeOf ctrl Is RadioButton OrElse
'    '               TypeOf ctrl Is DataGrid OrElse
'    '               TypeOf ctrl Is ToolStrip OrElse
'    '               TypeOf ctrl Is TabControl OrElse
'    '               TypeOf ctrl Is TabPage OrElse
'    '               TypeOf ctrl Is GroupBox Then
'    '        Return True
'    '    Else
'    '        Return False
'    '    End If
'    'End Function

'    'Friend Function IsTranslatable(ByVal ctrl As Control)
'    '    If TypeOf ctrl Is CButton OrElse
'    '       TypeOf ctrl Is CLabel OrElse
'    '       TypeOf ctrl Is CCheckBox OrElse
'    '       TypeOf ctrl Is CRadioButton OrElse
'    '       TypeOf ctrl Is CtDataGridView OrElse
'    '       TypeOf ctrl Is CGroupBox OrElse
'    '       TypeOf ctrl Is CTabControl OrElse
'    '       TypeOf ctrl Is CTabPage OrElse
'    '       TypeOf ctrl Is Label OrElse
'    '       TypeOf ctrl Is Button OrElse
'    '       TypeOf ctrl Is CheckBox OrElse
'    '       TypeOf ctrl Is RadioButton OrElse
'    '       TypeOf ctrl Is DataGrid OrElse
'    '       TypeOf ctrl Is ToolStrip OrElse
'    '       TypeOf ctrl Is TabControl OrElse
'    '       TypeOf ctrl Is TabPage OrElse
'    '       TypeOf ctrl Is GroupBox Then
'    '        Return True
'    '    Else
'    '        Return False
'    '    End If
'    'End Function

'    'Friend Sub StoreMenuItems(
'    '                          ByVal micoll As MenuItem.MenuItemCollection,
'    '                          ByVal mLevel As String)
'    '    For I As Int16 = 0 To micoll.Count - 1
'    '        Dim mi As MenuItem
'    '        mi = micoll.Item(I)
'    '        Dim localMLevel As String = mLevel + I.ToString
'    '        Captions.Add(mi.Text, localMLevel)
'    '        InsertWord(mi.Text)
'    '        If mi.MenuItems.Count > 0 Then _
'    '            StoreMenuItems(mi.MenuItems, localMLevel)
'    '    Next
'    'End Sub

'    Public Function FindControlRecursive(ByVal list As List(Of Control), ByVal parentControl As Control) As List(Of Control)
'        If parentControl Is Nothing Then Return list
'        list.Add(parentControl)
'        For Each child As Control In parentControl.Controls
'            FindControlRecursive(list, child)
'        Next
'        Return list
'    End Function

'End Class