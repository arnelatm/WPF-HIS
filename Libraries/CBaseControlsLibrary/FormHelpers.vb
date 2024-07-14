Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports Button = System.Windows.Forms.Button

Public Module FormHelpers

    Public Function GetFallBackLanguageIdNo(TranslatorDAC As Dac, ByVal desiredLanguage As String) As Int16
        Dim cmd As String
        Dim fallBackLanguageIdNo As Int16
        Dim languageBaseCode = Strings.Left(desiredLanguage, desiredLanguage.IndexOf("-", StringComparison.Ordinal))
        cmd = "SELECT TOP 1 LanguageIdNo,COUNT(LanguageIdNo) AS value_occurrence FROM TranslatedCaption_View where RTrim(LanguageCode2) = '" + languageBaseCode + "' " +
              "GROUP BY LanguageIdNo ORDER BY value_occurrence DESC"
        fallBackLanguageIdNo = TranslatorDAC.ExecScalar(Of Int16)(cmd)
        Return fallBackLanguageIdNo
    End Function

    Private Function GetFallBackLanguage(desiredLanguage As String, ByRef cmd As String, ByRef targetLanguageIdNo As Short, translatorDAC As Dac) As Int16
        Dim fallBackLanguageIdNo As Int16 = GetFallBackLanguageIdNo(translatorDAC, desiredLanguage)
        cmd = "Select cultureInfoCode from Languages where IdNo = " + fallBackLanguageIdNo.ToString()
        Dim fallBackLanguage As String = translatorDAC.ExecScalar(Of String)(cmd)
        If Not AATM.Libraries.GlobalFuncNSub.GlobalFunctions.NeedToTranslateText(fallBackLanguage) Then
            targetLanguageIdNo = 0
        Else
            targetLanguageIdNo = fallBackLanguageIdNo
        End If
        Return targetLanguageIdNo
    End Function

    Public Function GetFallBackMessage(TranslatorDAC As Dac, ByVal message As String, ByVal desiredLanguage As String) As String
        Dim cmd As String
        Dim languageBaseCode = Strings.Left(desiredLanguage, desiredLanguage.IndexOf("-", StringComparison.Ordinal))
        cmd = "SELECT TranslatedCaption from TranslatedMessages_View where Caption = '" + RTrim(message) + "' and RTrim(LanguageCode2) = '" + languageBaseCode + "' "
        Return TranslatorDAC.ExecScalar(Of String)(cmd)
    End Function

    Public Function GetFieldType(obj As Object, fieldName As String) As Type
        If Invoker.GetProperty(obj, fieldName) IsNot Nothing Then
            Return Invoker.GetProperty(obj, fieldName).GetType
        End If
        Return Nothing
    End Function

    Public Sub GetNSaveCaptions(sender As Object, captionCollection As Collection, AllControls As List(Of Control))
        If GlobalVariables.TranslationMode Then
            Dim storeCaptions As New StoreCaptions
            Dim translatorDAC As New Dac
            captionCollection = storeCaptions.StoreTranslation(sender, AllControls)
            storeCaptions.SaveControlsOriginalText(sender, AllControls)
            If sender.ViewDisplayName Is Nothing Or sender.ViewDisplayName = "" Then
                sender.ViewDisplayName = sender.Name
            End If
        End If
    End Sub

    Public Function GetSystemViewIdNo(cForm As Object, Optional translatorDac As Dac = Nothing)
        Dim cmd As String
        If cForm.ViewDisplayName Is Nothing Or cForm.ViewDisplayName = "" Then
            cForm.ViewDisplayName = cForm.Name
        End If
        cmd = "SELECT IdNo FROM SystemView where SystemViewName ='" + cForm.ViewDisplayName.Trim() + "'"
        If translatorDac Is Nothing Then
            translatorDac = New Dac
        End If
        Return translatorDac.ExecScalar(Of Int16)(cmd)
    End Function

    Private Function GetTargetLanguageIdNo(translatorDac As Dac, desiredLanguage As String) As Short
        Dim cmd As String
        Dim desiredLanguageIdNo As Int16
        Dim fallBackLanguageIdNo As Int16
        Dim fallBackLanguage As String
        Dim targetLanguageIdNo As Int16
        cmd = "Select IdNo from Languages where cultureInfoCode = '" + desiredLanguage + "'"
        desiredLanguageIdNo = translatorDac.ExecScalar(Of Int16)(cmd)
        If desiredLanguageIdNo = 0 Then
            targetLanguageIdNo = 0
        Else
            If Not TranslationLanguageExist(translatorDac, desiredLanguage) Then
                fallBackLanguageIdNo = GetFallBackLanguageIdNo(translatorDac, desiredLanguage)
                cmd = "Select cultureInfoCode from Languages where IdNo = " + fallBackLanguageIdNo.ToString()
                fallBackLanguage = translatorDac.ExecScalar(Of String)(cmd)
                If Not NeedToTranslateText(fallBackLanguage) Then
                    targetLanguageIdNo = 0
                Else
                    targetLanguageIdNo = fallBackLanguageIdNo
                End If
            Else
                targetLanguageIdNo = desiredLanguageIdNo
            End If
        End If
        Return targetLanguageIdNo
    End Function

    Public Function GetTranslations(form As Object, TranslatorDAC As Dac, targetLanguageIdNo As Integer) As DataSet
        Dim vSystemViewIdNo As Int16 = GetSystemViewIdNo(TranslatorDAC, form)
        Dim cmd As String = "Select Caption, translatedCaption from SystemViewItemOriginal_view where LanguageIdNo = " + targetLanguageIdNo.ToString() + " and SystemViewIdNo = " + vSystemViewIdNo.ToString()
        Dim translations As DataSet
        translations = TranslatorDAC.ReturnDs(cmd)
        Return translations
    End Function

    Private Function IsTranslatable(ByRef ctrl As Control) As Boolean
        If TypeOf ctrl Is IEntryControl Then
            Return CType(ctrl, IEntryControl).Translatable
        Else
            If TypeOf ctrl Is CLabel OrElse
               TypeOf ctrl Is CButton OrElse
               TypeOf ctrl Is CCheckBox OrElse
               TypeOf ctrl Is CRadioButton OrElse
               TypeOf ctrl Is CtDataGridView OrElse
               TypeOf ctrl Is CGroupBox OrElse
               TypeOf ctrl Is CTabControl OrElse
               TypeOf ctrl Is CTreeViewOld OrElse
               TypeOf ctrl Is Windows.Forms.TreeView OrElse
               TypeOf ctrl Is MenuStrip OrElse
               TypeOf ctrl Is ToolStrip OrElse
               TypeOf ctrl Is Label OrElse
               TypeOf ctrl Is Button OrElse
               TypeOf ctrl Is CheckBox OrElse
               TypeOf ctrl Is RadioButton OrElse
               TypeOf ctrl Is TabControl OrElse
               TypeOf ctrl Is DataGrid Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Sub MakeFormRightToLeft(pForm As Form, allControls As List(Of Control))
        For Each cCtrl As Control In allControls
            If TypeOf cCtrl Is CButton OrElse TypeOf cCtrl Is Button Then
                If GlobalFuncNSub.GetPropertyValue(cCtrl, "Image") IsNot Nothing Then
                    Dim btnImageName As String
                    btnImageName = (cCtrl.Name.ToString() + "_" + Strings.Left(CultureInfo.CurrentCulture.Name, 2)).ToLower()
                    Dim resource As Object = My.Resources.ResourceManager.GetObject(btnImageName)
                    If Not (resource Is Nothing) Then
                        Dim i = CType(cCtrl, CButton)
                        i.Image = DirectCast(resource, Image)
                    End If
                ElseIf TypeOf cCtrl Is CTabControl OrElse TypeOf cCtrl Is TabControl Then
                    Dim c = CType(cCtrl, CTabControl)
                    c.RightToLeftLayout = True
                    c.RightToLeft = RightToLeft.No
                End If
            End If
        Next cCtrl
    End Sub

    Public Sub TranslateForm(form As Object, allControls As List(Of Control))
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            Dim settings As New ControlSettingsSaver
            settings.SaveSetting(form)
            ' form location is being changed when Resetting RightToLeftLayout so need to save values
            ' to restore form with the same size and location
            'DoubleBuffered = True
            TranslateCaptions(form, allControls, form.formCulture.Name)
            SetControlLayout(form, allControls)
            settings.RestoreSetting(form)
            'ResumeDrawing()
            'If GlobalVariables.TranslationMode Then
            '    'RaiseEvent AfterTranslateForm()
            'End If
        End If
    End Sub

    Private Function GetToolStripText(form As Object, dv As DataView, cToolStrip As ToolStrip, obj As Object, propName As String) As String
        Dim translatedText As String = ""
        Dim r As Integer
        If form.CaptionCollection.Contains(cToolStrip.Name + "." + obj.Name + "." + propName) Then
            r = dv.Find(form.CaptionCollection.Item(cToolStrip.Name + "." + obj.Name + "." + propName))
            If r > 0 Then
                translatedText = dv(r).Item("translatedCaption")
            Else
                translatedText = obj.Tag(If(propName = "Text", 0, 1))
            End If
        End If
        Return translatedText
    End Function

    Private Sub LayOutControls(form As Object, ByRef allCtrl As List(Of Control))
        For Each cCtrl As Control In allCtrl
            If IsTranslatable(cCtrl) Then
                If TypeOf cCtrl Is ToolStrip Then
                    Dim cToolStrip As ToolStrip = cCtrl
                    For Each obj As Object In cToolStrip.Items
                        If TypeOf obj Is ToolStripButton Then
                            TranslateToolStripButtonImage(obj)
                        ElseIf TypeOf obj Is Windows.Forms.TextBox Then
                            Dim c = CType(obj, Windows.Forms.TextBox)
                            If form.RightToLeftDisplay Then
                                c.RightToLeft = RightToLeft.Yes
                            Else
                                c.RightToLeft = RightToLeft.No
                            End If
                        End If
                    Next
                ElseIf TypeOf cCtrl Is CTreeViewOld Or TypeOf cCtrl Is Windows.Forms.TreeView Or TypeOf cCtrl Is CTreeView Then
                    Dim cT = CType(cCtrl, Windows.Forms.TreeView)
                    cT.ExpandAll()
                    Try
                        cT.RightToLeftLayout = form.RighToLeftDisplay
                        cT.RightToLeft = If(form.RighToLeftDisplay, RightToLeft.Yes, RightToLeft.No)
                    Catch ex As Exception

                    End Try
                ElseIf TypeOf cCtrl Is CButton Then
                    TranslateButton(cCtrl)
                ElseIf TypeOf cCtrl Is CTabControl Then
                    Dim tc = CType(cCtrl, CTabControl)
                    tc.RightToLeft = If(form.RighToLeftDisplay, RightToLeft.Yes, RightToLeft.No)
                    tc.RightToLeftLayout = form.RighToLeftDisplay
                ElseIf TypeOf cCtrl Is CTextBox Then
                    Dim tc = CType(cCtrl, CTextBox)
                    If tc.ValueIsNumeric Then
                        If tc.RightToLeft = RightToLeft.Yes Then
                            tc.TextAlign = HorizontalAlignment.Left
                        Else
                            tc.TextAlign = HorizontalAlignment.Right
                        End If
                    Else
                        cCtrl.RightToLeft = If(form.RighToLeftDisplay, RightToLeft.Yes, RightToLeft.No)
                    End If
                End If
            Else
                Try
                    cCtrl.RightToLeft = If(form.RighToLeftDisplay, RightToLeft.Yes, RightToLeft.No)
                Catch ex As Exception
                    'Debugger.Break()
                End Try
            End If
            'If TypeOf cCtrl Is CtDataGridView Or TypeOf cCtrl Is CtDataGridView Then
            '    Dim cControl As CtDataGridView = DirectCast(cCtrl, CtDataGridView)
            '    cControl.MakeGridSearchable()
            'End If
        Next
    End Sub

    Private Sub SetControlLayout(form As Object, ByRef allCtrl As List(Of Control))
        Dim myImage As Bitmap
        myImage = form.BackgroundImage
        form.BackgroundImage = Nothing
        If form.FormCulture.TextInfo.IsRightToLeft Then
            form.RightToLeft = RightToLeft.Yes
            form.RightToLeftLayout = True
        Else
            form.RightToLeft = RightToLeft.No
            form.RightToLeftLayout = False
        End If
        LayOutControls(form, allCtrl)
        form.BackgroundImage = myImage
    End Sub

    Private Sub TranslateButton(cCtrl As Control)
        Dim o = CType(cCtrl, CButton)
        Dim cButton = CType(cCtrl, CButton)
        Dim cFileName = "btn" + o.OriginalImageName
        If cButton.Image IsNot Nothing And cButton.OriginalImageName IsNot Nothing Then
            If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                Dim cCurrentCulture = CultureInfo.CurrentCulture.Name.Replace("-", "_")
                cFileName = "btn" + o.OriginalImageName.ToLower() + "_" + cCurrentCulture.ToLower()
            Else
                cFileName = "btn" + o.OriginalImageName.ToLower()
            End If
        End If
        If GlobalResources.My.Resources.ResourceManager.GetObject(cFileName) IsNot Nothing Then
            cButton.Image = GlobalResources.My.Resources.ResourceManager.GetObject(cFileName)
        End If
    End Sub

    Private Sub TranslateCaptions(form As Object, ByRef allCtrl As List(Of Control), ByVal desiredLanguage As String)
        Try
            Dim translatorDac As New Dac
            Dim targetLanguageIdNo As Short = GetTargetLanguageIdNo(translatorDac, desiredLanguage)
            If targetLanguageIdNo = 0 Then
                UseOriginalCaptions(allCtrl)
            Else
                TranslateToLanguageIdNo(form, translatorDac, allCtrl, targetLanguageIdNo)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TranslateDataGridView(Dv As DataView, ByRef CtDataGridView As DataGridView)
        Dim cGrid As DataGridView = CtDataGridView
        Dim r As String
        For Each column As DataGridViewColumn In cGrid.Columns
            r = Dv.Find(column.HeaderText)
            If r >= 0 Then
                column.HeaderText = Dv(r).Item("TranslatedCaption")
            Else
                column.HeaderText = column.Tag
            End If
        Next
    End Sub

    Private Sub TranslateMenuStripItems(dv As DataView, dropDownItems As ToolStripItemCollection, subMenuName As String)
        Try
            For Each obj As Object In dropDownItems
                Dim subMenu = TryCast(obj, ToolStripMenuItem)
                If subMenu IsNot Nothing Then
                    Dim r As Int16
                    r = dv.Find(obj.Tag)
                    If r > 0 Then
                        obj.Text = dv(r).Item("translatedCaption")
                    Else
                        obj.Text = obj.Tag
                    End If
                    If subMenu.HasDropDownItems Then
                        subMenuName = subMenuName + "." + obj.Name
                        TranslateMenuStripItems(dv, subMenu.DropDownItems, subMenuName)
                    End If

                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TranslateTabControl(dv As DataView, ByRef cTabControl As CTabControl)
        For Each tabPage As TabPage In cTabControl.TabPages
            Dim r As Int16
            r = dv.Find(tabPage.Tag)
            If r > 0 Then
                tabPage.Text = dv(r).Item("translatedCaption")
            Else
                tabPage.Text = tabPage.Tag
            End If
        Next
    End Sub

    Private Sub TranslateToLanguageIdNo(form As Object, translatorDac As Dac, allCtrl As List(Of Control), targetLanguageIdNo As Integer)
        Dim translations As DataSet = GetTranslations(form, translatorDac, targetLanguageIdNo)
        Dim Dv As DataView
        Dv = translations.Tables(0).DefaultView
        Dv.Sort = "Caption"
        Dim r As Integer
        If form.Tag Is Nothing Then
            r = 0
        Else
            r = Dv.Find(form.Tag.ToString.TrimEnd)
        End If
        If r > 0 Then
            form.Text = Dv(r).Item("translatedCaption")
        Else
            form.Text = form.Tag
        End If
        For Each cCtrl As Control In allCtrl
            If IsTranslatable(cCtrl) Then
                If TypeOf cCtrl Is MenuStrip Then
                    Dim subMenuName = ""
                    Dim menuStrip As MenuStrip = cCtrl
                    TranslateMenuStripItems(Dv, menuStrip.Items, subMenuName)
                ElseIf TypeOf cCtrl Is ToolStrip Then
                    TranslateToolStripItems(form, Dv, cCtrl)
                ElseIf TypeOf cCtrl Is CTreeViewOld Or TypeOf cCtrl Is Windows.Forms.TreeView Then
                ElseIf TypeOf cCtrl Is DataGridView Then
                    TranslateDataGridView(Dv, cCtrl)
                ElseIf TypeOf cCtrl Is DataGrid Then
                    Dim originalText = form.CaptionCollection.Item(cCtrl.Name)
                    r = Dv.Find(originalText)
                    If r >= 0 Then
                        CType(cCtrl, DataGrid).CaptionText = Dv(r).Item(1)
                    Else
                        CType(cCtrl, DataGrid).CaptionText = cCtrl.Tag
                    End If
                ElseIf TypeOf cCtrl Is CTabControl Then
                    TranslateTabControl(Dv, cCtrl)
                Else
                    If TypeOf cCtrl Is CButton Then
                        TranslateButton(cCtrl)
                    End If
                    Try
                        Dim originalText = form.CaptionCollection.Item(cCtrl.Name)
                        originalText = form.CaptionCollection.Item(cCtrl.Name)
                        'if _originalText = "Gender" then
                        '    debugger.Break()
                        'End If
                        r = Dv.Find(originalText)
                        If r >= 0 Then
                            cCtrl.Text = Dv(r).Item("TranslatedCaption")
                        Else
                            cCtrl.Text = cCtrl.Tag
                        End If
                    Catch ex As Exception
                        cCtrl.Text = cCtrl.Tag
                    End Try
                End If
            End If
        Next
    End Sub

    Private Sub TranslateToolStripButtonImage(cButton As ToolStripButton)
        Dim cResourceName = cButton.Name.ToLower()
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            Dim cCurrentCulture = CultureInfo.CurrentCulture.Name.Replace("-", "_")
            cResourceName = cResourceName + "_" + cCurrentCulture.ToLower()
        Else
            If cButton.Image IsNot Nothing Then
                cResourceName = If(cButton.Image.Tag IsNot Nothing, cButton.Image.Tag, cResourceName)
            End If
            'cButton.ToolTipText = If(cButton.Tag IsNot Nothing, cButton.Tag(1), cButton.ToolTipText)
        End If
        If GlobalResources.My.Resources.ResourceManager.GetObject(cResourceName) IsNot Nothing Then
            cButton.Image = GlobalResources.My.Resources.ResourceManager.GetObject(cResourceName)
        End If
    End Sub

    Private Sub TranslateToolStripItems(form As Object, dv As DataView, ByRef cToolStrip As ToolStrip)
        For Each obj As Object In cToolStrip.Items
            obj.Text = GetToolStripText(form, dv, cToolStrip, obj, "Text")
            obj.ToolTipText = GetToolStripText(form, dv, cToolStrip, obj, "ToolTipText")
            If TypeOf obj Is ToolStripButton Then
                TranslateToolStripButtonImage(obj)
            ElseIf TypeOf obj Is Windows.Forms.TextBox Then
                Dim c = CType(obj, Windows.Forms.TextBox)
                If GlobalVariables.RightToLeftLayout Then
                    c.Text = Messaging.TranslateCaption(c.Text)
                    c.RightToLeft = RightToLeft.Yes
                Else
                    c.RightToLeft = RightToLeft.No
                End If
            End If
        Next
    End Sub

    Private Function TranslationLanguageExist(translatorDac As Dac, ByVal desiredLanguage As String)
        Dim cmd As String
        cmd = "SELECT count(*) FROM TranslatedCaption_View WHERE CultureInfoCode = '" _
              + desiredLanguage.TrimEnd + "'"
        Dim howMany As Integer = translatorDac.ExecScalar(Of Integer)(cmd)
        If howMany > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub UseOriginalButtonText(cCtrl As Control)
        Dim o = CType(cCtrl, CButton)
        Dim cButton = CType(cCtrl, CButton)
        Dim cFileName = "btn" + o.OriginalImageName
        If cButton.Image IsNot Nothing And cButton.OriginalImageName IsNot Nothing Then
            cFileName = "btn" + o.OriginalImageName.ToLower()
        End If
        If GlobalResources.My.Resources.ResourceManager.GetObject(cFileName) IsNot Nothing Then
            cButton.Image = GlobalResources.My.Resources.ResourceManager.GetObject(cFileName)
        End If
    End Sub

    Private Sub UseOriginalCaptions(allCtrl As List(Of Control))
        For Each cCtrl As Control In allCtrl
            If IsTranslatable(cCtrl) Then
                If TypeOf cCtrl Is MenuStrip Then
                    Dim subMenuName = ""
                    Dim menuStrip As MenuStrip = cCtrl
                    UseOriginalMenuStripCaptions(menuStrip.Items, subMenuName)
                ElseIf TypeOf cCtrl Is ToolStrip Then
                    UseOriginalToolStripItems(cCtrl)
                ElseIf TypeOf cCtrl Is DataGridView Then
                    UseOriginalDataGridView(cCtrl)
                ElseIf TypeOf cCtrl Is DataGrid Then
                    CType(cCtrl, DataGrid).CaptionText = cCtrl.Tag
                Else
                    If TypeOf cCtrl Is CButton Then
                        UseOriginalButtonText(cCtrl)
                    End If
                    cCtrl.Text = cCtrl.Tag
                End If
            End If
        Next
    End Sub
    Private Sub UseOriginalDataGridView(ByRef CtDataGridView As DataGridView)
        For Each col As DataGridViewColumn In CtDataGridView.Columns
            If col.Tag Is Nothing Then
                col.Tag = col.HeaderText
            Else
                col.HeaderText = col.Tag
            End If

        Next
    End Sub

    Private Sub UseOriginalMenuStripCaptions(dropDownItems As ToolStripItemCollection, subMenuName As String)
        Try
            For Each obj As Object In dropDownItems
                Dim subMenu = TryCast(obj, ToolStripMenuItem)
                If subMenu IsNot Nothing Then
                    If subMenu.HasDropDownItems Then
                        subMenuName = subMenuName + "." + obj.Name
                        obj.Text = obj.Tag
                        UseOriginalMenuStripCaptions(subMenu.DropDownItems, subMenuName)
                    Else
                        Dim toolStripMenuItem As ToolStripMenuItem = obj
                        toolStripMenuItem.Text = toolStripMenuItem.Tag
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UseOriginalToolStripButtonImage(cButton As ToolStripButton)
        Dim cResourceName = cButton.Name.ToLower()
        If GlobalResources.My.Resources.ResourceManager.GetObject(cResourceName) IsNot Nothing Then
            cButton.Image = GlobalResources.My.Resources.ResourceManager.GetObject(cResourceName)
        End If
    End Sub

    Private Sub UseOriginalToolStripItems(ByRef cToolStrip As ToolStrip)
        For Each obj As Object In cToolStrip.Items
            obj.Text = obj.Tag(0)
            obj.ToolTipText = obj.Tag(1)
            If TypeOf obj Is ToolStripButton Then
                UseOriginalToolStripButtonImage(obj)
            ElseIf TypeOf obj Is Windows.Forms.TextBox Then
                Dim c = CType(obj, Windows.Forms.TextBox)
                If GlobalVariables.RightToLeftLayout Then
                    c.Text = Messaging.TranslateCaption(c.Text)
                    c.RightToLeft = RightToLeft.Yes
                Else
                    c.RightToLeft = RightToLeft.No
                End If
            End If
        Next
    End Sub

    Public Sub SetControlVisibility(ByRef cCtrl As Control, controlVisible As Boolean)
        ' if Visible is false, Don't show the controls content by masking content with '*' asterisk
        If UserIsASuperAdmin() Then
            SetPropertyValue(cCtrl, "Visible", True)
        ElseIf controlVisible Then
            SetPropertyValue(cCtrl, "Visible", True)
        Else
            SetPropertyValue(cCtrl, "Visible", False)
        End If
    End Sub

End Module


Public Class ControlSettingsSaver

    Private _height As UInt16
    Private _left As UInt16
    Private _top As UInt16
    Private _visible As Boolean
    Private _width As UInt16
    Public Sub RestoreSetting(control As Control)
        control.Top = _top
        control.Left = _left
        control.Width = _width
        control.Height = _height
        control.Visible = _visible
    End Sub

    Public Sub SaveSetting(control As Control)
        _top = Math.Max(control.Top, 0)
        _left = Math.Max(control.Left, 0)
        _width = control.Width
        _height = control.Height
        _visible = control.Visible
    End Sub
End Class


'Public Class FormFunctions

'    Public Shared Function GetFormByName(ByVal formName As String) As Form
'        Dim T As Type = GetFormObjectByName(formName)
'        Return CType(Activator.CreateInstance(T), Form)
'    End Function

'    Private Shared Function GetFormObjectByName(formName As String) As Type
'        'first try: in case the full namespace has been provided (as it should ;-) )
'        Dim T As Type = Type.GetType(formName, False)
'        'if not found, search for it
'        If T Is Nothing Then T = FindType(formName)
'        'if still not found, throw exception
'        If T Is Nothing Then Throw New Exception(formName + " could not be found")
'        Return T
'    End Function

'    'Public Shared Function GetFormByName(ByVal formName As String, parameter As ArrayList) As Form
'    '    Dim T As Type = GetFormObjectByName(formName)
'    '    Return CType(Activator.CreateInstance(T, parameter), Form)
'    'End Function

'    Public Shared Function GetFormByName(ByVal formName As String, report As ReportModel) As Form
'        Dim T As Type = GetFormObjectByName(formName)
'        Return CType(Activator.CreateInstance(T, report), Form)
'    End Function

'#Region "Assemblies and types"

'    Public Shared Function GetAllAssemblies() As ArrayList
'        Dim al As New ArrayList
'        Dim a As [Assembly] = [Assembly].GetEntryAssembly()
'        FillAssemblies(a, al)
'        Return al
'    End Function

'    Private Shared Sub FillAssemblies(ByVal a As [Assembly], ByVal al As ArrayList)
'        If Not al.Contains(a) Then
'            al.Add(a)
'            Dim an As AssemblyName
'            For Each an In a.GetReferencedAssemblies()
'                If Not an.Name.StartsWith("System") Then FillAssemblies([Assembly].Load(an), al)
'            Next
'        End If
'    End Sub

'    Public Shared Function GetAllTypes() As ArrayList
'        Dim a As [Assembly], t As Type, al As New ArrayList
'        For Each a In GetAllAssemblies()
'            For Each t In a.GetTypes
'                If Not al.Contains(t) Then al.Add(t)
'            Next
'        Next
'        Return al
'    End Function

'    Public Shared Function FindType(ByVal Name As String) As Type
'        Dim T As Type
'        For Each T In GetAllTypes()
'            If T.Name = Name Then Return T
'        Next
'        Return Nothing
'    End Function

'#End Region

'End Class

''example call:
''Dim f As Form = FormFunctions.GetFormByName("Form1")
''f.Show()