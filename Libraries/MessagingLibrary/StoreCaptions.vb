Imports AATM.Libraries.GlobalFuncNSub

Public Class StoreCaptions
    Inherits System.ComponentModel.Component

    ' Generated form code omitted, except for the following overloaded
    ' constructor that I added:
    Private _dAc1 As Dac

    'Public Sub New()
    '    MyBase.New()
    'End Sub

    Public Sub New(ByVal dac As Dac)
        MyBase.New()
        'This call is required by the Component Designer.
        'Add any initialization after the InitializeComponent() call
        _dAc1 = dac
    End Sub

    Public Sub New()
    End Sub

    Public Captions As New Collection

    Function StoreCaptions(ByVal frm As Object) As Collection
        Dim systemViewIdNo As Int16
        Dim viewDisplayName As String
        _dAc1 = frm.TranslatorDAC
        frm.Tag = frm.Text
        If frm.ViewDisplayName Is Nothing OrElse frm.ViewDisplayName = "" Then
            viewDisplayName = frm.Name
        Else
            viewDisplayName = frm.ViewDisplayName
        End If
        InsertForm(viewDisplayName)
        systemViewIdNo = GetSystemViewIdNo(viewDisplayName)
        InsertTranslation(frm.Text, systemViewIdNo)
        Dim t As String
        Dim allCtrl As New List(Of Control)
        For Each cCtrl As Control In FindControlRecursive(allCtrl, frm)
            If TypeOf cCtrl Is MenuStrip Then
                Dim subMenuName = cCtrl.Name
                Dim menuStrip As MenuStrip = cCtrl
                StoreMenuStripTranslation(menuStrip.Items, subMenuName, systemViewIdNo)
            ElseIf TypeOf cCtrl Is ToolStrip Then
                Dim subMenuName = ""
                Dim toolStrip As ToolStrip = cCtrl
                Dim c As ToolStrip
                c = cCtrl
                For Each obj As Object In c.Items
                    TranslateToolStrip(systemViewIdNo, c, obj)
                Next
            ElseIf TypeOf cCtrl Is DataGridView Then
                Dim c As DataGridView
                c = cCtrl
                For Each col As DataGridViewColumn In c.Columns
                    TranslateDataGridView(systemViewIdNo, c, col)
                Next
            ElseIf TypeOf cCtrl Is DataGrid Then
                t = CType(cCtrl, DataGrid).CaptionText
                cCtrl.Tag = t
                Captions.Add(cCtrl.Text, cCtrl.Name)
            Else
                Try
                    If TypeOf cCtrl Is TextBox OrElse
                       TypeOf cCtrl Is ComboBox OrElse
                       TypeOf cCtrl Is MaskedTextBox OrElse
                       TypeOf cCtrl Is FlowLayoutPanel Then
                        'Debugger.Break()
                    Else
                        'TypeOf cCtrl Is Button OrElse
                        'TypeOf cCtrl Is Label OrElse
                        'TypeOf cCtrl Is CheckBox OrElse
                        'TypeOf cCtrl Is RadioButton OrElse
                        'TypeOf cCtrl Is TabControl OrElse
                        'TypeOf cCtrl Is TreeView OrElse
                        'TypeOf cCtrl Is Form OrElse
                        'TypeOf cCtrl Is DataGrid OrElse
                        'TypeOf cCtrl Is TabPage Then
                        'TypeOf cCtrl Is AATM.Libraries.CBaseControlsLibrary.CButton Then
                        t = cCtrl.Text
                        If Not String.IsNullOrWhiteSpace(t) Then
                            cCtrl.Tag = t
                            Captions.Add(cCtrl.Text, cCtrl.Name)
                            InsertTranslation(t, systemViewIdNo)
                        End If
                    End If
                Catch ex As Exception

                End Try
            End If
            'End If
        Next
        Return Captions
    End Function

    Function StoreTranslation(ByVal frm As Object) As Collection
        Dim systemViewIdNo As Int16
        Dim viewDisplayName As String
        _dAc1 = frm.TranslatorDAC
        SaveOriginalText(frm, frm.Text)
        frm.Tag = frm.Text
        If frm.ViewDisplayName Is Nothing OrElse frm.ViewDisplayName = "" Then
            viewDisplayName = frm.Name
        Else
            viewDisplayName = frm.ViewDisplayName
        End If
        InsertForm(viewDisplayName)
        systemViewIdNo = GetSystemViewIdNo(viewDisplayName)
        InsertTranslation(frm.Text, systemViewIdNo)
        Dim t As String
        Dim allCtrl As New List(Of Control)
        For Each cCtrl As Control In FindControlRecursive(allCtrl, frm)
            If TypeOf cCtrl Is MenuStrip Then
                Dim subMenuName = cCtrl.Name
                Dim menuStrip As MenuStrip = cCtrl
                StoreMenuStripTranslation(menuStrip.Items, subMenuName, systemViewIdNo)
            ElseIf TypeOf cCtrl Is ToolStrip Then
                Dim subMenuName = ""
                Dim toolStrip As ToolStrip = cCtrl
                Dim c As ToolStrip
                c = cCtrl
                For Each obj As Object In c.Items
                    StoreToolStripTranslation(systemViewIdNo, c, obj)
                Next
            ElseIf TypeOf cCtrl Is DataGridView Then
                Dim c As DataGridView
                c = cCtrl
                For Each col As DataGridViewColumn In c.Columns
                    StoreDataGridViewTranslation(systemViewIdNo, c, col)
                Next
            ElseIf TypeOf cCtrl Is DataGrid Then
                Captions.Add(cCtrl.Text, cCtrl.Name)
            Else
                Try
                    If TypeOf cCtrl Is TextBox OrElse
                       TypeOf cCtrl Is ComboBox OrElse
                       TypeOf cCtrl Is MaskedTextBox OrElse
                       cCtrl.GetType().Name = "CCustomDateTimePicker" OrElse
                       TypeOf cCtrl Is FlowLayoutPanel Then
                    Else
                        'TypeOf cCtrl Is Button OrElse
                        'TypeOf cCtrl Is Label OrElse
                        'TypeOf cCtrl Is CheckBox OrElse
                        'TypeOf cCtrl Is RadioButton OrElse
                        'TypeOf cCtrl Is TabControl OrElse
                        'TypeOf cCtrl Is TreeView OrElse
                        'TypeOf cCtrl Is Form OrElse
                        'TypeOf cCtrl Is DataGrid OrElse
                        'TypeOf cCtrl Is TabPage Then
                        'TypeOf cCtrl Is AATM.Libraries.CBaseControlsLibrary.CButton Then
                        t = cCtrl.Text
                        'If t = "Gender" Then
                        '    Debugger.Break()
                        'End If
                        If Not String.IsNullOrWhiteSpace(t) Then
                            Captions.Add(cCtrl.Text, cCtrl.Name)
                            InsertTranslation(t, systemViewIdNo)
                        End If
                    End If
                Catch ex As Exception

                End Try
            End If
        Next
        Return Captions
    End Function

    Private Sub TranslateToolStrip(SystemViewIdNo As Short, c As ToolStrip, obj As Object)
        Dim t As String
        Try
            obj.Tag = {obj.Text, obj.ToolTipText}
            If Not String.IsNullOrEmpty(obj.Text) Then
                t = obj.Text
                Captions.Add(t, c.Name + "." + obj.Name + ".Text")
                InsertTranslation(t, SystemViewIdNo)
            Else
                ' add an empty place holder
                Captions.Add("", c.Name + "." + obj.Name + ".Text")
            End If
            If Not String.IsNullOrEmpty(obj.ToolTipText) Then
                t = obj.ToolTipText
                Captions.Add(t, c.Name + "." + obj.Name + ".ToolTipText")
                InsertTranslation(t, SystemViewIdNo)
            Else
                Captions.Add("", c.Name + "." + obj.Name + ".ToolTipText")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub StoreToolStripTranslation(systemViewIdNo As Short, c As ToolStrip, obj As Object)
        Dim t As String
        Try
            If Not String.IsNullOrEmpty(obj.Text) Then
                t = obj.Text
                Captions.Add(t, c.Name + "." + obj.Name + ".Text")
                InsertTranslation(t, systemViewIdNo)
            Else
                ' add an empty place holder
                Captions.Add("", c.Name + "." + obj.Name + ".Text")
            End If
            If Not String.IsNullOrEmpty(obj.ToolTipText) Then
                t = obj.ToolTipText
                Captions.Add(t, c.Name + "." + obj.Name + ".ToolTipText")
                InsertTranslation(t, systemViewIdNo)
            Else
                Captions.Add("", c.Name + "." + obj.Name + ".ToolTipText")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveOriginalText(ByRef originalObject As Object, originalText As Object)
        originalObject.Tag = originalText
    End Sub

    Private Sub SaveOriginalToolStripText(systemViewIdNo As Short, c As ToolStrip, obj As Object)
        obj.Tag = {obj.Text, obj.ToolTipText}
    End Sub

    Private Sub TranslateDataGridView(systemViewIdNo As Short, c As DataGridView, obj As Object)
        Dim t As String
        Try
            For Each col As DataGridViewColumn In c.Columns
                t = col.HeaderText
                Captions.Add(t, c.Name + "." + col.HeaderText)
                InsertTranslation(t, systemViewIdNo)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub StoreDataGridViewTranslation(systemViewIdNo As Short, c As DataGridView, obj As Object)
        Dim t As String
        Try
            For Each col As DataGridViewColumn In c.Columns
                t = col.HeaderText
                Captions.Add(t, c.Name + "." + col.HeaderText)
                InsertTranslation(t, systemViewIdNo)
            Next
        Catch ex As Exception

        End Try
    End Sub

    'Public Sub StoreMessage(ByVal message As Object)
    '    InsertMessage(message)
    'End Sub

    Private Sub SetMenuStripItems(dropDownItems As ToolStripItemCollection, subMenuName As String, systemViewIdNo As Int16)
        'Try
        '    For Each obj As Object In dropDownItems
        '        Dim subMenu = TryCast(obj, ToolStripMenuItem)
        '        If subMenu IsNot Nothing Then
        '            subMenuName = subMenuName + "." + obj.Name
        '            If Not String.IsNullOrEmpty(obj.Text) Then
        '                Captions.Add(obj.text, subMenuName)
        '                InsertTranslation(obj.Text, systemViewIdNo)
        '                obj.Tag = obj.Text
        '            End If
        '            If subMenu.HasDropDownItems Then
        '                SetMenuStripItems(subMenu.DropDownItems, subMenuName, systemViewIdNo)
        '            End If
        '        End If
        '    Next
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, $"SetMenuStripItems", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        'End Try
    End Sub

    Private Sub StoreMenuStripTranslation(dropDownItems As ToolStripItemCollection, subMenuName As String, systemViewIdNo As Int16)
        Try
            For Each obj As Object In dropDownItems
                Dim subMenu = TryCast(obj, ToolStripMenuItem)
                If subMenu IsNot Nothing Then
                    subMenuName = subMenuName + "." + obj.Name
                    If Not String.IsNullOrEmpty(obj.Text) Then
                        Captions.Add(obj.text, subMenuName)
                        InsertTranslation(obj.Text, systemViewIdNo)
                    End If
                    If subMenu.HasDropDownItems Then
                        StoreMenuStripTranslation(subMenu.DropDownItems, subMenuName, systemViewIdNo)
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, $"SetMenuStripItems", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub SaveOriginalMenuStripText(dropDownItems As ToolStripItemCollection, subMenuName As String)
        For Each obj As Object In dropDownItems
            Dim subMenu = TryCast(obj, ToolStripMenuItem)
            If subMenu IsNot Nothing Then
                subMenuName = subMenuName + "." + obj.Name
                If Not String.IsNullOrEmpty(obj.Text) Then
                    SaveOriginalText(obj, obj.Text)
                End If
                If subMenu.HasDropDownItems Then
                    SaveOriginalMenuStripText(subMenu.DropDownItems, subMenuName)
                End If
            End If
        Next
    End Sub

    Function SaveControlsOriginalText(ByVal frm As Object) As Collection
        frm.Tag = frm.Text
        Dim t As String
        Dim allCtrl As New List(Of Control)
        For Each cCtrl As Control In FindControlRecursive(allCtrl, frm)
            If TypeOf cCtrl Is MenuStrip Then
                Dim subMenuName = cCtrl.Name
                Dim menuStrip As MenuStrip = cCtrl
                SaveOriginalMenuStripText(menuStrip.Items, subMenuName)
            ElseIf TypeOf cCtrl Is ToolStrip Then
                Dim c As ToolStrip = cCtrl
                For Each obj As Object In c.Items
                    SaveOriginalText(obj, {obj.Text, obj.TooltipText})
                Next
            ElseIf TypeOf cCtrl Is DataGridView Then
                Dim c As DataGridView = cCtrl
                For Each col As DataGridViewColumn In c.Columns
                    SaveOriginalText(col, col.HeaderText)
                Next
            ElseIf TypeOf cCtrl Is DataGrid Then
                t = CType(cCtrl, DataGrid).CaptionText
                SaveOriginalText(cCtrl, t)
            Else
                Try
                    If TypeOf cCtrl Is TextBox OrElse
                       TypeOf cCtrl Is ComboBox OrElse
                       TypeOf cCtrl Is MaskedTextBox OrElse
                       cCtrl.GetType().Name = "CCustomDateTimePicker" OrElse
                       TypeOf cCtrl Is FlowLayoutPanel Then
                        'Debugger.Break()
                    Else
                        'TypeOf cCtrl Is Button OrElse
                        'TypeOf cCtrl Is Label OrElse
                        'TypeOf cCtrl Is CheckBox OrElse
                        'TypeOf cCtrl Is RadioButton OrElse
                        'TypeOf cCtrl Is TabControl OrElse
                        'TypeOf cCtrl Is TreeView OrElse
                        'TypeOf cCtrl Is Form OrElse
                        'TypeOf cCtrl Is DataGrid OrElse
                        'TypeOf cCtrl Is TabPage Then
                        'TypeOf cCtrl Is AATM.Libraries.CBaseControlsLibrary.CButton Then
                        t = cCtrl.Text
                        If Not String.IsNullOrWhiteSpace(t) Then
                            SaveOriginalText(cCtrl, t)
                        End If
                    End If
                Catch ex As Exception

                End Try
            End If
        Next
        Return Captions
    End Function

    Friend Sub InsertWord(ByVal word As String)
        'If word.Contains("'") Then
        '    Debugger.Break()
        'End If
        Dim cmd As String
        If Not (String.IsNullOrEmpty(word) OrElse word = "  /  /") Then
            Dim params() As Object = {"@word", word}
            cmd = "SELECT COUNT(*) From OriginalCaptions where Caption = @word"
            Dim howMany As Int32 = _dAc1.ExecScalar(Of Int32)(cmd, params)
            If howMany = 0 Then
                'cmd = "INSERT INTO OriginalCaptions (caption) values ( '" + word + "')"
                cmd = "INSERT INTO OriginalCaptions (caption) values ( @word )"
                _dAc1.ExecCmd(cmd, params)
            End If
        End If
    End Sub

    Public Sub CreateMessage(ByVal Key As String, ByVal message As String)
        InsertMessage(Key, message)
        'Return GetTrans(key)
    End Sub

    Public Sub InsertMessage(ByVal key As String, ByVal message As String)
        Dim cmd As String
        Dim params() As Object = {"@key", key, "@message", message}
        cmd = "SELECT COUNT(*) FROM OriginalMessage where Key = @message"
        Dim howMany As Int32 = _dAc1.ExecScalar(Of Int32)(cmd, params)
        If howMany = 0 Then
            cmd = "INSERT INTO OriginalMessage (key, message) values (@key, @message)"
            _dAc1.ExecCmd(cmd, params)
        End If
    End Sub

    Public Sub InsertTranslation(ByVal text As String, ByVal systemViewIdNo As Int16)
        If GlobalVariables.TranslationMode Then
            InsertWord(text)
            InsertFormItem(systemViewIdNo, text)
        End If
    End Sub

    Friend Sub InsertFormItem(ByVal systemViewIdNo As Int16, ByVal itemName As String)
        Dim cmd As String
        Dim captionIdNo As Int32
        cmd = "Select IdNo From OriginalCaptions where Caption = @itemName"
        Dim params() As Object = {"@ItemName", itemName}
        captionIdNo = _dAc1.ExecScalar(Of Int32)(cmd, params)
        'if item.ToString().TrimEnd() = "Gender" then
        '    debugger.Break()
        'End If
        cmd = "SELECT COUNT(*) FROM SystemViewItem where CaptionIdNo = " + captionIdNo.ToString() + " and SystemViewIdNo = " + systemViewIdNo.ToString()
        Dim howMany As Integer = _dAc1.ExecScalar(Of Int16)(cmd)
        If howMany = 0 Then
            cmd = "INSERT INTO SystemViewItem (SystemViewIdNo, CaptionIdNO) values ( " + systemViewIdNo.ToString() + "," + captionIdNo.ToString() + ")"
            _dAc1.ExecCmd(cmd)
        End If
    End Sub

    Friend Sub InsertForm(ByVal formName As String)
        Dim cmd As String
        Dim params() As Object = {"@FormName", formName}
        cmd = "SELECT COUNT(*) FROM SystemView where SystemViewName = @formName "
        Dim howMany As Int16 = _dAc1.ExecScalar(Of Int16)(cmd, params)
        If howMany = 0 Then
            cmd = "INSERT INTO SystemView (SystemViewName) values (@formName)"
            _dAc1.ExecCmd(cmd, params)
        End If
    End Sub

    Friend Function GetSystemViewIdNo(ByVal formName As String) As Int16
        Dim cmd As String
        Dim params() As Object = {"@FormName", formName}
        cmd = "SELECT IdNo FROM SystemView where SystemViewName = @formName "
        Return _dAc1.ExecScalar(Of Int16)(cmd, params)
    End Function

    'Friend Function IsTranslatable(ByVal ctrl As Control)
    '    Dim retVal As Boolean = False
    '    If o.GetType().GetInterfaces().Contains(GetType(ISomething)) Then
    '        ' The interface is implemented
    '    End If
    '    Return retVal
    'End Function

    'Friend Function IsTranslatable(ByVal ctrl As Control)
    '    If TypeOf ctrl Is Label OrElse
    '               TypeOf ctrl Is Button OrElse
    '               TypeOf ctrl Is CheckBox OrElse
    '               TypeOf ctrl Is RadioButton OrElse
    '               TypeOf ctrl Is DataGrid OrElse
    '               TypeOf ctrl Is ToolStrip OrElse
    '               TypeOf ctrl Is TabControl OrElse
    '               TypeOf ctrl Is TabPage OrElse
    '               TypeOf ctrl Is GroupBox Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    'Friend Function IsTranslatable(ByVal ctrl As Control)
    '    If TypeOf ctrl Is CButton OrElse
    '       TypeOf ctrl Is CLabel OrElse
    '       TypeOf ctrl Is CCheckBox OrElse
    '       TypeOf ctrl Is CRadioButton OrElse
    '       TypeOf ctrl Is CDataGridView OrElse
    '       TypeOf ctrl Is CGroupBox OrElse
    '       TypeOf ctrl Is CTabControl OrElse
    '       TypeOf ctrl Is CTabPage OrElse
    '       TypeOf ctrl Is Label OrElse
    '       TypeOf ctrl Is Button OrElse
    '       TypeOf ctrl Is CheckBox OrElse
    '       TypeOf ctrl Is RadioButton OrElse
    '       TypeOf ctrl Is DataGrid OrElse
    '       TypeOf ctrl Is ToolStrip OrElse
    '       TypeOf ctrl Is TabControl OrElse
    '       TypeOf ctrl Is TabPage OrElse
    '       TypeOf ctrl Is GroupBox Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    'Friend Sub StoreMenuItems(
    '                          ByVal micoll As MenuItem.MenuItemCollection,
    '                          ByVal mLevel As String)
    '    For I As Int16 = 0 To micoll.Count - 1
    '        Dim mi As MenuItem
    '        mi = micoll.Item(I)
    '        Dim localMLevel As String = mLevel + I.ToString
    '        Captions.Add(mi.Text, localMLevel)
    '        InsertWord(mi.Text)
    '        If mi.MenuItems.Count > 0 Then _
    '            StoreMenuItems(mi.MenuItems, localMLevel)
    '    Next
    'End Sub

    Public Function FindControlRecursive(ByVal list As List(Of Control), ByVal parentControl As Control) As List(Of Control)
        If parentControl Is Nothing Then Return list
        list.Add(parentControl)
        For Each child As Control In parentControl.Controls
            FindControlRecursive(list, child)
        Next
        Return list
    End Function

End Class