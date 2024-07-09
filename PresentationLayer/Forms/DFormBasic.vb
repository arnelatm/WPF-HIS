Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports System.Windows.Forms
Imports AATM.PresentationLayer.Views
Imports System.Globalization
Imports AATM.PresentationLayer.Events
Imports System.Drawing
Imports AATM.Libraries
Imports AATM.PresentationLayer.Presenters
Imports AATM.Libraries.MessagingLibrary
Imports System.ComponentModel

Public Class DFormBasic
    Implements IViewNew

    Public Dv As DataView
    Protected CaptionCollection As New Collection
    Private _debugSwitch As Byte = 0
    Private _originalText As String
    Private _systemViewIdNo As Int32
    Private _textDisplayLanguage As String
    Private _rightToLeftLayout As Boolean
    Private _formCulture As CultureInfo

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        KeyPreview = False
    End Sub

    Public Event AfterTranslateForm()
    Public Event TextDisplayLanguageChanged()
    Public Event ArabicDisplayRequested() Implements IViewNew.ArabicDisplayRequested
    Public Event OrigLanguageDisplayRequested() Implements IViewNew.OrigLanguageDisplayRequested

    Public ReadOnly Property FormName As String Implements IViewNew.FormName
        Get
            Return Name.Trim()
        End Get
    End Property

    Public Property ViewDisplayName As String Implements IViewNew.ViewDisplayName
    Protected Property TextDisplayLanguage As String
        Get
            Return _textDisplayLanguage
        End Get
        Set(value As String)
            If value <> _textDisplayLanguage Then
                _textDisplayLanguage = value
                SetCulture(_textDisplayLanguage)
                RaiseEvent TextDisplayLanguageChanged()
            End If
        End Set
    End Property

    Protected Property VSystemViewIdNo As Short
        Get
            Return GetSystemViewIdNo()
        End Get
        Set(value As Short)
            _systemViewIdNo = value
        End Set
    End Property

    Public Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16, userIdNo As Int16) As ArrayList
        Return GetUserSecurity(securityObjectIdNo, securityGroupIdNo, userIdNo)
    End Function

    Function IsTranslatable(ByRef ctrl As Control) As Boolean
        If TypeOf ctrl Is IEntryControl Then
            'Dim x As IEntryControl
            'x = ctrl
            'Return x.Translatable
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
               TypeOf ctrl Is TreeView OrElse
               TypeOf ctrl Is MenuStrip OrElse
               TypeOf ctrl Is ToolStrip OrElse
               TypeOf ctrl Is Label OrElse
               TypeOf ctrl Is Button OrElse
               TypeOf ctrl Is CheckBox OrElse
               TypeOf ctrl Is RadioButton OrElse
               TypeOf ctrl Is TabControl OrElse
               TypeOf ctrl Is TreeView OrElse
               TypeOf ctrl Is DataGrid Then
                'If TypeOf ctrl Is CButton Then
                '    Debugger.Break()
                'End If
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Sub TranslateForm()
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            'SuspendDrawing()
            Dim settings As New ControlSettingsSaver
            Dim allCtrl As New List(Of Control)
            allCtrl = GlobalFunctions.FindControlRecursive(allCtrl, Me)
            settings.SaveSetting(Me)
            ' form location is being changed when Resetting RightToLeftLayout so need to save values
            ' to restore form with the same size and location
            DoubleBuffered = True
            TranslateCaptions(allCtrl, _formCulture.Name)
            SetControlLayout(allCtrl)
            settings.RestoreSetting(Me)
            'ResumeDrawing()
            If GlobalVariables.TranslationMode Then
                RaiseEvent AfterTranslateForm()
            End If
        End If
    End Sub

    Protected Function GetFallBackLanguageIdNo(ByVal desiredLanguage As String) As Int16
        Dim cmd As String
        Dim fallBackLanguageIdNo As Int16
        Dim languageBaseCode = Strings.Left(desiredLanguage, desiredLanguage.IndexOf("-", StringComparison.Ordinal))
        cmd = "SELECT TOP 1 LanguageIdNo,COUNT(LanguageIdNo) AS value_occurrence FROM TranslatedCaption_View where RTrim(LanguageCode2) = '" + languageBaseCode + "' " +
              "GROUP BY LanguageIdNo ORDER BY value_occurrence DESC"
        fallBackLanguageIdNo = TranslatorDac.ExecScalar(Of Int16)(cmd)
        Return fallBackLanguageIdNo
    End Function

    Protected Function GetSystemViewIdNo()
        Dim cmd As String
        If ViewDisplayName Is Nothing Or ViewDisplayName = "" Then
            ViewDisplayName = Name
        End If
        cmd = "SELECT IdNo FROM SystemView where SystemViewName ='" + ViewDisplayName.Trim() + "'"
        Return TranslatorDac.ExecScalar(Of Int16)(cmd)
    End Function

    Protected Function GetTranslations(targetLanguageIdNo As Integer) As DataSet
        Dim cmd As String = "Select Caption, translatedCaption from SystemViewItemOriginal_view where LanguageIdNo = " + targetLanguageIdNo.ToString() + " and SystemViewIdNo = " + GetSystemViewIdNo.ToString()
        Dim translations As DataSet
        translations = TranslatorDac.ReturnDs(cmd)
        Return translations
    End Function

    Protected Sub LayOutControls(ByRef allCtrl As List(Of Control))
        For Each cCtrl As Control In allCtrl
            If IsTranslatable(cCtrl) Then
                If TypeOf cCtrl Is ToolStrip Then
                    Dim cToolStrip As ToolStrip = cCtrl
                    For Each obj As Object In cToolStrip.Items
                        If TypeOf obj Is ToolStripButton Then
                            TranslateToolStripButtonImage(obj)
                        ElseIf TypeOf obj Is TextBox Then
                            Dim c = CType(obj, TextBox)
                            If _rightToLeftLayout Then
                                c.RightToLeft = RightToLeft.Yes
                            Else
                                c.RightToLeft = RightToLeft.No
                            End If
                        End If
                    Next
                ElseIf TypeOf cCtrl Is CTreeViewOld Or TypeOf cCtrl Is TreeView Or TypeOf cCtrl Is CTreeView Then
                    Dim cT = CType(cCtrl, TreeView)
                    cT.ExpandAll()
                    cT.RightToLeftLayout = _rightToLeftLayout
                    cT.RightToLeft = If(_rightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
                ElseIf TypeOf cCtrl Is CButton Then
                    TranslateButton(cCtrl)
                ElseIf TypeOf cCtrl Is CTabControl Then
                    Dim tc = CType(cCtrl, CTabControl)
                    tc.RightToLeft = If(_rightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
                    tc.RightToLeftLayout = _rightToLeftLayout
                ElseIf TypeOf cCtrl Is CTextBox Then
                    Dim tc = CType(cCtrl, CTextBox)
                    If tc.ValueIsNumeric Then
                        If tc.RightToLeft = RightToLeft.Yes Then
                            tc.TextAlign = HorizontalAlignment.Left
                        Else
                            tc.TextAlign = HorizontalAlignment.Right
                        End If
                    Else
                        cCtrl.RightToLeft = If(_rightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
                    End If
                End If
            Else
                Try
                    cCtrl.RightToLeft = If(_rightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
                Catch ex As Exception
                    Debugger.Break()
                End Try
            End If
            'If TypeOf cCtrl Is CtDataGridView Or TypeOf cCtrl Is CtDataGridView Then
            '    Dim cControl As CtDataGridView = DirectCast(cCtrl, CtDataGridView)
            '    cControl.MakeGridSearchable()
            'End If
        Next
    End Sub

    'Protected Overridable Sub OnTextDisplayLanguageChanged() Handles Me.TextDisplayLanguageChanged
    '    CultureInfo.CurrentCulture = New CultureInfo(TextDisplayLanguage, False)
    '    'PublishEvent(New LanguageChanged(Me))
    'End Sub

    Protected Sub RunTranslator(ByVal nSystemViewIdNo)
        Dim frm As New TranslationTableManager()
        frm.SystemViewIdNoToTranslate = nSystemViewIdNo
        frm.AppDataDAC = AppDataDac
        frm.TranslatorDAC = TranslatorDac
        frm.Show()
    End Sub

    Protected Sub SetControlLayout(ByRef allCtrl As List(Of Control))
        Dim myImage As Bitmap
        myImage = BackgroundImage
        BackgroundImage = Nothing
        'If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
        '    GlobalVariables.RightToLeftLayout = True
        '    RightToLeft = RightToLeft.Yes
        '    RightToLeftLayout = True
        'Else
        '    GlobalVariables.RightToLeftLayout = False
        '    RightToLeft = RightToLeft.No
        '    RightToLeftLayout = False
        'End If
        LayOutControls(allCtrl)
        BackgroundImage = myImage
    End Sub

    Protected Sub TranslateCaptions(ByRef allCtrl As List(Of Control), ByVal desiredLanguage As String, Optional ByVal allowFallBack As Boolean = True)
        Try
            If (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
                ' continue
            Else
                Dim targetLanguageIdNo As Short = GetTargetLanguageIdNo(desiredLanguage, allowFallBack)
                If targetLanguageIdNo = 0 Then
                    UseOriginalCaptions()
                Else
                    TranslateToLanguageIdNo(allCtrl, targetLanguageIdNo)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub TranslateToLanguageIdNo(ByRef allCtrl As List(Of Control), targetLanguageIdNo As Integer)
        Dim translations As DataSet = GetTranslations(targetLanguageIdNo)
        Dv = translations.Tables(0).DefaultView
        Dv.Sort = "Caption"
        Dim r As Integer
        If Tag Is Nothing Then
            r = 0
        Else
            r = Dv.Find(Tag.ToString.TrimEnd)
        End If
        If r > 0 Then
            Text = Dv(r).Item("translatedCaption")
        Else
            Text = Tag
        End If
        For Each cCtrl As Control In allCtrl
            If IsTranslatable(cCtrl) Then
                If TypeOf cCtrl Is MenuStrip Then
                    Dim subMenuName = ""
                    Dim menuStrip As MenuStrip = cCtrl
                    TranslateMenuStripItems(menuStrip.Items, subMenuName)
                ElseIf TypeOf cCtrl Is ToolStrip Then
                    TranslateToolStripItems(cCtrl)
                ElseIf TypeOf cCtrl Is CTreeViewOld Or TypeOf cCtrl Is TreeView Then
                ElseIf TypeOf cCtrl Is DataGridView Then
                    TranslateDataGridView(cCtrl)
                ElseIf TypeOf cCtrl Is DataGrid Then
                    _originalText = CaptionCollection.Item(cCtrl.Name)
                    r = Dv.Find(_originalText)
                    If r >= 0 Then
                        CType(cCtrl, DataGrid).CaptionText = Dv(r).Item(1)
                    Else
                        CType(cCtrl, DataGrid).CaptionText = cCtrl.Tag
                    End If
                ElseIf TypeOf cCtrl Is CTabControl Then
                    TranslateTabControl(cCtrl)
                Else
                    If TypeOf cCtrl Is CButton Then
                        TranslateButton(cCtrl)
                    End If
                    Try
                        _originalText = CaptionCollection.Item(cCtrl.Name)
                        'if _originalText = "Gender" then
                        '    debugger.Break()
                        'End If
                        r = Dv.Find(_originalText)
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

    Protected Function TranslationLanguageExist(ByVal desiredLanguage As String)
        Dim cmd As String
        cmd = "SELECT count(*) FROM TranslatedCaption_View WHERE CultureInfoCode = '" _
              + desiredLanguage.TrimEnd + "'"
        Dim howMany As Integer = TranslatorDac.ExecScalar(Of Integer)(cmd)
        If howMany > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Shared Sub SetControlVisibility(ByRef cCtrl As Control, controlVisible As Boolean)
        ' if Visible is false, Don't show the controls content by masking content with '*' asterisk
        If UserIsASuperAdmin() Then
            SetPropertyValue(cCtrl, "Visible", True)
        ElseIf controlVisible Then
            SetPropertyValue(cCtrl, "Visible", True)
        Else
            SetPropertyValue(cCtrl, "Visible", False)
        End If
    End Sub

    'Private Sub ApplyMenuSecurityNew(ByRef obj As ToolStripMenuItem, ByRef subMenuName As String)
    '    Dim toolStripMenuItem As ToolStripMenuItem = obj
    '    Dim controlSecurityKey = subMenuName + " > " + Mid(toolStripMenuItem.Name, 18)
    '    If GlobalVariables.IsUserLoggedIn Then
    '        SetMenuSecurity(toolStripMenuItem, controlSecurityKey)
    '    Else
    '        toolStripMenuItem.Enabled = False
    '        toolStripMenuItem.Visible = True
    '    End If
    'End Sub

    Private Sub BtnArabic_Click(sender As Object, e As EventArgs) Handles btnArabic.Click
        SwitchDisplayToArabicLanguage()
    End Sub

    Private Sub btnDebug_Click(sender As Object, e As EventArgs) Handles btnDebug.Click
        If _debugSwitch = 0 Then
            _debugSwitch = 1
            Debugger.Break()
            btnDebug.Checked = False
        Else
            _debugSwitch = 0
            btnDebug.Checked = True
        End If
    End Sub

    Private Sub btnOriginal_Click(sender As Object, e As EventArgs) Handles btnOriginal.Click
        SwitchDisplayToOriginalLanguage()
    End Sub

    Protected Sub SwitchDisplayToOriginalLanguage()
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            Dim cultureCode As String = GlobalVariables.DefaultUnmirroredCultureInfoStr
            If IsCultureOk(cultureCode) Then
                _formCulture = New CultureInfo(cultureCode, False)
                _rightToLeftLayout = False
                RightToLeft = RightToLeft.No
                TranslateForm()
                btnArabic.Visible = True
                btnOriginal.Visible = False
                btnArabic.Enabled = True
                btnOriginal.Enabled = False
                RaiseEvent OrigLanguageDisplayRequested()
            Else
                MessageBox.Show("Invalid DefaultMirroredCultureInfoStr " & cultureCode & ".")
            End If
        End If
    End Sub

    Private Sub SwitchDisplayToArabicLanguage()
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            Dim cultureCode = GlobalVariables.DefaultMirroredCultureInfoStr
            If IsCultureOk(cultureCode) AndAlso IsRightToLeft(cultureCode) Then
                btnArabic.Visible = False
                btnOriginal.Visible = True
                btnArabic.Enabled = False
                btnOriginal.Enabled = True
                _rightToLeftLayout = True
                Dim curFormCulture As CultureInfo
                curFormCulture = New CultureInfo(cultureCode, False)
                _formCulture = curFormCulture
                RightToLeft = RightToLeft.Yes
                TranslateForm()
                RaiseEvent ArabicDisplayRequested()
            Else
                MessageBox.Show("Invalid DefaultMirroredCultureInfoStr " & cultureCode & ".")
            End If
        End If
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        Close()
    End Sub
    Private Sub btnTranslate_Click(sender As Object, e As EventArgs) Handles btnTranslate.Click
        If _debugSwitch Then
            Debugger.Break()
        End If

        RunTranslator(VSystemViewIdNo)
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        CopyText()
    End Sub

    Private Sub CutToolStripButton_Click(sender As Object, e As EventArgs) Handles CutToolStripButton.Click
        CutText()
    End Sub


    Private Function GetTargetLanguageIdNo(desiredLanguage As String, allowFallBack As Boolean) As Short
        Dim cmd As String
        Dim desiredLanguageIdNo As Int16
        Dim fallBackLanguageIdNo As Int16
        Dim fallBackLanguage As String
        Dim targetLanguageIdNo As Int16
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            cmd = "Select IdNo from Languages where cultureInfoCode = '" + desiredLanguage + "'"
            desiredLanguageIdNo = TranslatorDac.ExecScalar(Of Int16)(cmd)
            If desiredLanguageIdNo = 0 Then
                targetLanguageIdNo = 0
            Else
                If Not TranslationLanguageExist(desiredLanguage) Then
                    If allowFallBack Then
                        fallBackLanguageIdNo = GetFallBackLanguageIdNo(desiredLanguage)
                        cmd = "Select cultureInfoCode from Languages where IdNo = " + fallBackLanguageIdNo.ToString()
                        fallBackLanguage = TranslatorDac.ExecScalar(Of String)(cmd)
                        If Not NeedToTranslateText(fallBackLanguage) Then
                            targetLanguageIdNo = 0
                        Else
                            targetLanguageIdNo = fallBackLanguageIdNo
                        End If
                    Else
                        targetLanguageIdNo = 0
                    End If
                Else
                    targetLanguageIdNo = desiredLanguageIdNo
                End If
            End If
        End If
        Return targetLanguageIdNo
    End Function

    Private Function GetToolStripText(cToolStrip As ToolStrip, obj As Object, propName As String) As String
        Dim translatedText As String = ""
        Dim r As Integer
        If CaptionCollection.Contains(cToolStrip.Name + "." + obj.Name + "." + propName) Then
            r = Dv.Find(CaptionCollection.Item(cToolStrip.Name + "." + obj.Name + "." + propName))
            If r > 0 Then
                translatedText = Dv(r).Item("translatedCaption")
            Else
                translatedText = obj.Tag(If(propName = "Text", 0, 1))
            End If
        End If
        Return translatedText
    End Function
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

    Private Sub TranslateDataGridView(ByRef CtDataGridView As DataGridView)
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

    Private Sub TranslateMenuStripItems(dropDownItems As ToolStripItemCollection, subMenuName As String)
        Try
            For Each obj As Object In dropDownItems
                Dim subMenu = TryCast(obj, ToolStripMenuItem)
                If subMenu IsNot Nothing Then
                    Dim r As Int16
                    r = Dv.Find(obj.Tag)
                    If r > 0 Then
                        obj.Text = Dv(r).Item("translatedCaption")
                    Else
                        obj.Text = obj.Tag
                    End If
                    If subMenu.HasDropDownItems Then
                        subMenuName = subMenuName + "." + obj.Name
                        TranslateMenuStripItems(subMenu.DropDownItems, subMenuName)
                    End If

                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TranslateTabControl(ByRef cTabControl As CTabControl)
        For Each tabPage As TabPage In cTabControl.TabPages
            Dim r As Int16
            r = Dv.Find(tabPage.Tag)
            If r > 0 Then
                tabPage.Text = Dv(r).Item("translatedCaption")
            Else
                tabPage.Text = tabPage.Tag
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

    Private Sub TranslateToolStripItems(ByRef cToolStrip As ToolStrip)
        For Each obj As Object In cToolStrip.Items
            obj.Text = GetToolStripText(cToolStrip, obj, "Text")
            obj.ToolTipText = GetToolStripText(cToolStrip, obj, "ToolTipText")
            If TypeOf obj Is ToolStripButton Then
                TranslateToolStripButtonImage(obj)
            ElseIf TypeOf obj Is TextBox Then
                Dim c = CType(obj, TextBox)
                If GlobalVariables.RightToLeftLayout Then
                    c.Text = Messaging.TranslateCaption(c.Text)
                    c.RightToLeft = RightToLeft.Yes
                Else
                    c.RightToLeft = RightToLeft.No
                End If
            End If
        Next
    End Sub

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

    Private Sub UseOriginalCaptions()
        Dim allCtrl As New List(Of Control)
        For Each cCtrl As Control In GlobalFunctions.FindControlRecursive(allCtrl, Me)
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
            ElseIf TypeOf obj Is TextBox Then
                Dim c = CType(obj, TextBox)
                If GlobalVariables.RightToLeftLayout Then
                    c.Text = Messaging.TranslateCaption(c.Text)
                    c.RightToLeft = RightToLeft.Yes
                Else
                    c.RightToLeft = RightToLeft.No
                End If
            End If
        Next
    End Sub

    Private Sub DFormBasic_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        _formCulture = GlobalVariables.AppCultureInfo
        If _formCulture.TextInfo.IsRightToLeft Then
            _rightToLeftLayout = True
            RightToLeft = RightToLeft.Yes
        Else
            _rightToLeftLayout = False
            RightToLeft = RightToLeft.No
        End If
        If _rightToLeftLayout Then
            btnArabic.Visible = False
            btnOriginal.Visible = True
        Else
            btnArabic.Visible = True
            btnOriginal.Visible = False
        End If
        TranslateForm()
    End Sub
End Class
