Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary

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
        Dim FormIdNo As Int16
        _dAc1 = frm.TranslatorDAC
        frm.Tag = frm.Text
        InsertForm(frm.Name)
        FormIdNo = GetFormIdNo(frm.Name)
        InsertWord(frm.Text)
        InsertFormItem(FormIdNo, frm.Text)
        Dim t As String
        Dim allCtrl As New List(Of Control)
        For Each cCtrl As Control In FindControlRecursive(allCtrl, frm)
            If IsTranslatable(cCtrl) Then
                If TypeOf cCtrl Is DataGrid Then
                    t = CType(cCtrl, DataGrid).CaptionText
                    cCtrl.Tag = t
                    Captions.Add(cCtrl.Text, cCtrl.Name)
                ElseIf TypeOf cCtrl Is ToolStrip Then
                    Dim subMenuName = ""
                    Dim toolStrip As ToolStrip = cCtrl
                    Dim c As ToolStrip
                    c = cCtrl
                    For Each obj As Object In c.Items
                        TranslateToolStrip(FormIdNo, c, obj)
                    Next
                ElseIf cCtrl.GetType().ToString() = "System.Windows.Forms.MenuStrip" Then
                    Dim subMenuName = cCtrl.Name
                    Dim menuStrip As MenuStrip = cCtrl
                    SetMenuStripItems(menuStrip.Items, subMenuName, FormIdNo)
                Else
                    Try
                        t = cCtrl.Text
                        cCtrl.Tag = t
                        Captions.Add(cCtrl.Text, cCtrl.Name)
                        InsertWord(t)
                        InsertFormItem(FormIdNo, t)
                    Catch ex As Exception

                    End Try
                End If
            End If
        Next
        Return Captions
    End Function

    Private Sub TranslateToolStrip(formIdNo As Short, c As ToolStrip, obj As Object)
        Dim t As String
        Try
            obj.Tag = {obj.Text, obj.ToolTipText}
            If Not String.IsNullOrEmpty(obj.Text) Then
                t = obj.Text
                Captions.Add(t, c.Name + "." + obj.Name + ".Text")
                InsertWord(t)
                InsertFormItem(formIdNo, t)
            Else
                ' add an empty place holder
                Captions.Add("", c.Name + "." + obj.Name + ".Text")
            End If
            If Not String.IsNullOrEmpty(obj.ToolTipText) Then
                t = obj.ToolTipText
                Captions.Add(t, c.Name + "." + obj.Name + ".ToolTipText")
                InsertWord(t)
                InsertFormItem(formIdNo, t)
            Else
                Captions.Add("", c.Name + "." + obj.Name + ".ToolTipText")
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Public Sub StoreMessage(ByVal message As Object)
    '    InsertMessage(message)
    'End Sub

    Private Sub SetMenuStripItems(dropDownItems As ToolStripItemCollection, subMenuName As String, formIdNo As Int16)
        Try
            For Each obj As Object In dropDownItems
                Dim subMenu = TryCast(obj, ToolStripMenuItem)
                If subMenu IsNot Nothing Then
                    subMenuName = subMenuName + "." + obj.Name
                    If Not String.IsNullOrEmpty(obj.Text) Then
                        Captions.Add(obj.text, subMenuName)
                        InsertWord(obj.Text)
                        InsertFormItem(formIdNo, obj.Text)
                        obj.Tag = obj.Text
                    End If
                    If subMenu.HasDropDownItems Then
                        SetMenuStripItems(subMenu.DropDownItems, subMenuName, formIdNo)
                    End If
                    't = obj.Text
                    'If Not String.IsNullOrEmpty(t) Then
                    '    Captions.Add(obj.text, subMenuName + "." + obj.Name)
                    '    InsertWord(obj.Text)
                    '    InsertFormItem(formIdNo, obj.Text)
                    'End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, $"SetMenuStripItems", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Friend Sub InsertWord(ByVal t As String)
        Dim cmd As String
        cmd = "SELECT COUNT(*) From OriginalCaptions where Caption = '" + t + "'"
        Dim howMany As Int32 = _dAc1.ExecScalar(Of Int32)(cmd)
        If howMany = 0 Then
            cmd = "INSERT INTO OriginalCaptions (caption) values ( '" + t + "')"
            _dAc1.ExecCmd(cmd)
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

    Friend Sub InsertFormItem(ByVal formIdNo As Int16, ByVal item As String)
        Dim cmd As String
        Dim captionIdNo As Int16
        cmd = "Select IdNo From OriginalCaptions where Caption = '" + item.ToString().TrimEnd() + "'"
        captionIdNo = _dAc1.ExecScalar(Of Int16)(cmd)
        cmd = "SELECT COUNT(*) FROM FormItems where CaptionIdNo = " + captionIdNo.ToString() + " and FormIdNo = " + formIdNo.ToString()
        Dim howMany As Integer = _dAc1.ExecScalar(Of Int16)(cmd)
        If howMany = 0 Then
            cmd = "INSERT INTO FormItems (FormIdNo, CaptionIdNO) values ( " + formIdNo.ToString() + "," + captionIdNo.ToString() + ")"
            _dAc1.ExecCmd(cmd)
        End If
    End Sub

    Friend Sub InsertForm(ByVal formName As String)
        Dim cmd As String
        cmd = "SELECT COUNT(*) FROM SystemForms where FormName ='" + formName + "'"
        Dim howMany As Int16 = _dAc1.ExecScalar(Of Int16)(cmd)
        If howMany = 0 Then
            cmd = "INSERT INTO SystemForms (FormName) values ( '" + formName + "')"
            _dAc1.ExecCmd(cmd)
        End If
    End Sub

    Friend Function GetFormIdNo(ByVal formName As String) As Int16
        Dim cmd As String
        cmd = "SELECT IdNo FROM SystemForms where FormName ='" + formName + "'"
        Return _dAc1.ExecScalar(Of Int16)(cmd)
    End Function

    Friend Function IsTranslatable(ByVal ctrl As Control)
        If TypeOf ctrl Is CButton OrElse
           TypeOf ctrl Is CLabel OrElse
           TypeOf ctrl Is CCheckBox OrElse
           TypeOf ctrl Is CRadioButton OrElse
           TypeOf ctrl Is CDataGridView OrElse
           TypeOf ctrl Is CGroupBox OrElse
           TypeOf ctrl Is CTabControl OrElse
           TypeOf ctrl Is CTabPage OrElse
           TypeOf ctrl Is Label OrElse
           TypeOf ctrl Is Button OrElse
           TypeOf ctrl Is CheckBox OrElse
           TypeOf ctrl Is RadioButton OrElse
           TypeOf ctrl Is DataGrid OrElse
           TypeOf ctrl Is ToolStrip OrElse
           TypeOf ctrl Is TabControl OrElse
           TypeOf ctrl Is TabPage OrElse
           TypeOf ctrl Is GroupBox Then
            Return True
        Else
            Return False
        End If
    End Function

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