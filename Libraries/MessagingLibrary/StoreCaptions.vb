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
        Dim SystemViewIdNo As Int16
        _dAc1 = frm.TranslatorDAC
        frm.Tag = frm.Text
        InsertForm(frm.Name)
        SystemViewIdNo = GetSystemViewIdNo(frm.Name)
        InsertWord(frm.Text)
        InsertFormItem(SystemViewIdNo, frm.Text)
        Dim t As String
        Dim allCtrl As New List(Of Control)
        For Each cCtrl As Control In FindControlRecursive(allCtrl, frm)
            If TypeOf cCtrl Is MenuStrip Then
                Dim subMenuName = cCtrl.Name
                Dim menuStrip As MenuStrip = cCtrl
                SetMenuStripItems(menuStrip.Items, subMenuName, SystemViewIdNo)
            ElseIf TypeOf cCtrl Is ToolStrip Then
                Dim subMenuName = ""
                Dim toolStrip As ToolStrip = cCtrl
                Dim c As ToolStrip
                c = cCtrl
                For Each obj As Object In c.Items
                    TranslateToolStrip(SystemViewIdNo, c, obj)
                Next
            ElseIf TypeOf cCtrl Is DataGridView Then
                Dim c As DataGridView
                c = cCtrl
                For Each col As DataGridViewColumn In c.Columns
                    TranslateDataGridView(SystemViewIdNo, c, col)
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
                            InsertWord(t)
                            InsertFormItem(SystemViewIdNo, t)
                        End If
                    End If
                Catch ex As Exception

                End Try
            End If
            'End If
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
                InsertWord(t)
                InsertFormItem(SystemViewIdNo, t)
            Else
                ' add an empty place holder
                Captions.Add("", c.Name + "." + obj.Name + ".Text")
            End If
            If Not String.IsNullOrEmpty(obj.ToolTipText) Then
                t = obj.ToolTipText
                Captions.Add(t, c.Name + "." + obj.Name + ".ToolTipText")
                InsertWord(t)
                InsertFormItem(SystemViewIdNo, t)
            Else
                Captions.Add("", c.Name + "." + obj.Name + ".ToolTipText")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TranslateDataGridView(SystemViewIdNo As Short, c As DataGridView, obj As Object)
        Dim t As String
        Try
            For Each col As DataGridViewColumn In c.Columns
                t = col.HeaderText
                Captions.Add(t, c.Name + "." + col.HeaderText)
                InsertWord(t)
                InsertFormItem(SystemViewIdNo, t)
            Next
        Catch ex As Exception

        End Try
    End Sub

    'Public Sub StoreMessage(ByVal message As Object)
    '    InsertMessage(message)
    'End Sub

    Private Sub SetMenuStripItems(dropDownItems As ToolStripItemCollection, subMenuName As String, SystemViewIdNo As Int16)
        Try
            For Each obj As Object In dropDownItems
                Dim subMenu = TryCast(obj, ToolStripMenuItem)
                If subMenu IsNot Nothing Then
                    subMenuName = subMenuName + "." + obj.Name
                    If Not String.IsNullOrEmpty(obj.Text) Then
                        Captions.Add(obj.text, subMenuName)
                        InsertWord(obj.Text)
                        InsertFormItem(SystemViewIdNo, obj.Text)
                        obj.Tag = obj.Text
                    End If
                    If subMenu.HasDropDownItems Then
                        SetMenuStripItems(subMenu.DropDownItems, subMenuName, SystemViewIdNo)
                    End If
                    't = obj.Text
                    'If Not String.IsNullOrEmpty(t) Then
                    '    Captions.Add(obj.text, subMenuName + "." + obj.Name)
                    '    InsertWord(obj.Text)
                    '    InsertFormItem(SystemViewIdNo, obj.Text)
                    'End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, $"SetMenuStripItems", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Friend Sub InsertWord(ByVal t As String)
        Dim cmd As String
        If Not (String.IsNullOrEmpty(t) OrElse t = "  /  /") Then
            cmd = "SELECT COUNT(*) From OriginalCaptions where Caption = '" + t + "'"
            Dim howMany As Int32 = _dAc1.ExecScalar(Of Int32)(cmd)
            If howMany = 0 Then
                cmd = "INSERT INTO OriginalCaptions (caption) values ( '" + t + "')"
                _dAc1.ExecCmd(cmd)
            End If
        End If
    End Sub

    Public Sub CreateMessage(ByVal Key As String, ByVal message As String)
        InsertMessage(Key, message)
        'Return GetTrans(key)
    End Sub

    Public Sub InsertMessage(ByVal key As String, ByVal message As String)
        Dim cmd As String
        cmd = "SELECT COUNT(*) FROM OriginalMessage where Key = '" + key + "'"
        Dim howMany As Int32 = _dAc1.ExecScalar(Of Int32)(cmd)
        If howMany = 0 Then
            cmd = "INSERT INTO OriginalMessage (key, message) values ( '" + key + "','" + message + "')"
            _dAc1.ExecCmd(cmd)
        End If
    End Sub

    Friend Sub InsertFormItem(ByVal SystemViewIdNo As Int16, ByVal item As String)
        Dim cmd As String
        Dim captionIdNo As Int32
        cmd = "Select IdNo From OriginalCaptions where Caption = '" + item.ToString().TrimEnd() + "'"
        captionIdNo = _dAc1.ExecScalar(Of Int32)(cmd)
        cmd = "SELECT COUNT(*) FROM SystemViewItem where CaptionIdNo = " + captionIdNo.ToString() + " and SystemViewIdNo = " + SystemViewIdNo.ToString()
        Dim howMany As Integer = _dAc1.ExecScalar(Of Int16)(cmd)
        If howMany = 0 Then
            cmd = "INSERT INTO SystemViewItem (SystemViewIdNo, CaptionIdNO) values ( " + SystemViewIdNo.ToString() + "," + captionIdNo.ToString() + ")"
            _dAc1.ExecCmd(cmd)
        End If
    End Sub

    Friend Sub InsertForm(ByVal formName As String)
        Dim cmd As String
        cmd = "SELECT COUNT(*) FROM SystemView where SystemViewName ='" + formName + "'"
        Dim howMany As Int16 = _dAc1.ExecScalar(Of Int16)(cmd)
        If howMany = 0 Then
            cmd = "INSERT INTO SystemView (SystemViewName) values ( '" + formName + "')"
            _dAc1.ExecCmd(cmd)
        End If
    End Sub

    Friend Function GetSystemViewIdNo(ByVal formName As String) As Int16
        Dim cmd As String
        cmd = "SELECT IdNo FROM SystemView where SystemViewName ='" + formName + "'"
        Return _dAc1.ExecScalar(Of Int16)(cmd)
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