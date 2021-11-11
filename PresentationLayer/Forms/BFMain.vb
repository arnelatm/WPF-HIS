Imports System.Drawing
Imports System.Globalization
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Views

Public Class BfMain
    Implements IView

    Dim _originalText As String

    '    Dim _menuLevel As String = ""
    Private _textDisplayLanguage As String

    Protected _addSecurityObject As Boolean = False
    Private _parentSecurityObjectIdNo As Int32
    Private _sw As Int16 = 0
    Private _parentIdNo As Int32 = 0
    Private _formCulture As CultureInfo

    'Private _myPresenter As UserPresenter
    Protected CaptionCollection As New Collection

    Protected InitializationMode As Boolean = True
    Protected LtrCultureInfoStr = GlobalVariables.DefaultUnmirroredCultureInfoStr
    Protected RtlCultureInfoStr = GlobalVariables.DefaultMirroredCultureInfoStr
    Protected DefaultMirroredLanguageIdNo As Int16
    Protected Shared ResetEvent As AutoResetEvent = New AutoResetEvent(False)
    Public Dv As DataView
    Public MyErrorProvider As New ErrorProviderExtended
    Public Ea As EventAggregator
    Public Presenter As Object

    Public Event AfterTranslateForm()

    Public Event BeforeLoad()

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Ea = New EventAggregator
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            TextDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name
        End If
        ' Add any initialization after the InitializeComponent() call.
        VSystemViewIdNo = GetSystemViewIdNo()
    End Sub

    Public Sub New(ByVal transDac As Dac, ByVal appDac As Dac)
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            TranslatorDAC = transDac
            AppDataDAC = appDac
        End If

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Event TextDisplayLanguageChanged()

    Public Property CancelClose As Boolean

    Public Property Errors As List(Of String) Implements IView.Errors

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

    Protected Sub SetFormCulture(cCultureInfo As CultureInfo)
        FormCulture = cCultureInfo

        If FormCulture.TextInfo.IsRightToLeft Then
            RightToLeftLayout = True
            RightToLeft = RightToLeft.Yes
        Else
            RightToLeftLayout = False
            RightToLeft = RightToLeft.No
        End If
        If CultureInfo.CurrentUICulture.Name <> CultureInfo.CurrentCulture.Name Then
            CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture
        End If
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture
    End Sub

    Protected Property FormCulture As CultureInfo
        Get
            If _formCulture Is Nothing Then
                Return CultureInfo.CurrentCulture
            Else
                Return _formCulture
            End If
        End Get
        Set(value As CultureInfo)
            _formCulture = value
        End Set
    End Property

    Protected Property VSystemViewIdNo As Short

    'Public Sub SetupDisplay()
    '    If IsRightToLeft(_textDisplayLanguage) Then
    '        RightToLeft = RightToLeft.Yes
    '        RightToLeftLayout = True
    '    Else
    '        RightToLeft = RightToLeft.No
    '        RightToLeftLayout = False
    '    End If
    'End Sub

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
               TypeOf ctrl Is CDataGridView OrElse
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
        Parent.SuspendDrawing()
        Dim settings As New SettingsSaver
        Dim allCtrl As New List(Of Control)
        allCtrl = FindControlRecursive(allCtrl, Me)
        settings.SaveSetting(Me)
        ' form location is being changed when Resetting RightToLeftLayout so need to save values
        ' to restore form with the same size and location
        DoubleBuffered = True
        TranslateCaptions(allCtrl, TextDisplayLanguage)
        SetControlLayout(allCtrl)
        settings.RestoreSetting(Me)
        Parent.ResumeDrawing()
        If GlobalVariables.TranslationMode Then
            RaiseEvent AfterTranslateForm()
        End If
    End Sub

    Protected Sub SetControlLayout(ByRef allCtrl As List(Of Control))
        Dim myImage As Bitmap
        myImage = BackgroundImage
        BackgroundImage = Nothing
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            GlobalVariables.RightToLeftLayout = True
            RightToLeft = RightToLeft.Yes
            RightToLeftLayout = True
        Else
            GlobalVariables.RightToLeftLayout = False
            RightToLeft = RightToLeft.No
            RightToLeftLayout = False
        End If
        LayOutControls(allCtrl)
        BackgroundImage = myImage
    End Sub

    Protected Sub RunTranslator(ByVal nSystemViewIdNo)
        Dim frm As New TranslationTableManager()
        frm.SystemViewIdNoToTranslate = nSystemViewIdNo
        frm.AppDataDAC = AppDataDAC
        frm.TranslatorDAC = TranslatorDAC
        frm.Show()
    End Sub

    Protected Overridable Sub ChangeToLtrDisplay()
        'SuspendLayout()
        RightToLeft = RightToLeft.No
        RightToLeftLayout = False
        'ResumeLayout()
    End Sub

    Protected Overridable Sub ChangeToRtlDisplay()
        SuspendLayout()
        RightToLeft = RightToLeft.Yes
        RightToLeftLayout = True
        ResumeLayout()
    End Sub

    Protected Function GetFallBackLanguageIdNo(ByVal desiredLanguage As String) As Int16
        Dim cmd As String
        Dim fallBackLanguageIdNo As Int16
        Dim languageBaseCode = Strings.Left(desiredLanguage, desiredLanguage.IndexOf("-", StringComparison.Ordinal))
        cmd = "SELECT TOP 1 LanguageIdNo,COUNT(LanguageIdNo) AS value_occurrence FROM TranslatedCaption_View where RTrim(LanguageCode2) = '" + languageBaseCode + "' " +
              "GROUP BY LanguageIdNo ORDER BY value_occurrence DESC"
        fallBackLanguageIdNo = TranslatorDAC.ExecScalar(Of Int16)(cmd)
        Return fallBackLanguageIdNo
    End Function

    Protected Function GetFallBackMessage(ByVal message As String, ByVal desiredLanguage As String) As String
        Dim cmd As String
        Dim languageBaseCode = Strings.Left(desiredLanguage, desiredLanguage.IndexOf("-", StringComparison.Ordinal))
        cmd = "SELECT TranslatedCaption from TranslatedMessages_View where Caption = '" + RTrim(message) + "' and RTrim(LanguageCode2) = '" + languageBaseCode + "' "
        Return TranslatorDAC.ExecScalar(Of String)(cmd)
    End Function

    Protected Sub TranslateCaptions(ByRef allCtrl As List(Of Control), ByVal desiredLanguage As String, Optional ByVal allowFallBack As Boolean = True)
        Dim targetLanguageIdNo As Short = GetTargetLanguageIdNo(desiredLanguage, allowFallBack)
        If targetLanguageIdNo = 0 Then
            UseOriginalCaptions()
        Else
            TranslateToLanguageIdNo(allCtrl, targetLanguageIdNo)
        End If
    End Sub

    Private Function GetTargetLanguageIdNo(desiredLanguage As String, allowFallBack As Boolean) As Short
        Dim cmd As String
        Dim desiredLanguageIdNo As Int16
        Dim fallBackLanguageIdNo As Int16
        Dim fallBackLanguage As String
        Dim targetLanguageIdNo As Int16
        cmd = "Select IdNo from Languages where cultureInfoCode = '" + desiredLanguage + "'"
        desiredLanguageIdNo = TranslatorDAC.ExecScalar(Of Int16)(cmd)
        If desiredLanguageIdNo = 0 Then
            targetLanguageIdNo = 0
        Else
            If Not TranslationLanguageExist(desiredLanguage) Then
                If allowFallBack Then
                    fallBackLanguageIdNo = GetFallBackLanguageIdNo(desiredLanguage)
                    cmd = "Select cultureInfoCode from Languages where IdNo = " + fallBackLanguageIdNo.ToString()
                    fallBackLanguage = TranslatorDAC.ExecScalar(Of String)(cmd)
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
        Return targetLanguageIdNo
    End Function

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
                Else
                    If TypeOf cCtrl Is CButton Then
                        TranslateButton(cCtrl)
                    ElseIf TypeOf cCtrl Is CTabControl Then
                    End If
                    Try
                        _originalText = CaptionCollection.Item(cCtrl.Name)
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
                            If GlobalVariables.RightToLeftLayout Then
                                c.RightToLeft = RightToLeft.Yes
                            Else
                                c.RightToLeft = RightToLeft.No
                            End If
                        End If
                    Next
                ElseIf TypeOf cCtrl Is CTreeViewOld Or TypeOf cCtrl Is TreeView Or TypeOf cCtrl Is CTreeView Then
                    Dim cT = CType(cCtrl, TreeView)
                    cT.ExpandAll()
                    cT.RightToLeftLayout = GlobalVariables.RightToLeftLayout
                    cT.RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
                ElseIf TypeOf cCtrl Is CButton Then
                    TranslateButton(cCtrl)
                ElseIf TypeOf cCtrl Is CTabControl Then
                    Dim tc = CType(cCtrl, CTabControl)
                    tc.RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
                    tc.RightToLeftLayout = GlobalVariables.RightToLeftLayout
                End If
            ElseIf TypeOf cCtrl Is CTextBox Then
                Dim tc = CType(cCtrl, CTextBox)
                If tc.ValueIsNumeric Then
                    If tc.RightToLeft = RightToLeft.Yes Then
                        tc.TextAlign = HorizontalAlignment.Left
                    Else
                        tc.TextAlign = HorizontalAlignment.Right
                    End If
                End If
            End If
        Next
    End Sub

    Protected Function GetTranslations(targetLanguageIdNo As Integer) As DataSet
        Dim cmd As String = "Select Caption, translatedCaption from SystemViewItemOriginal_view where LanguageIdNo = " + targetLanguageIdNo.ToString() + " and SystemViewIdNo = " + VSystemViewIdNo.ToString()
        Dim translations As DataSet
        translations = TranslatorDAC.ReturnDs(cmd)
        Return translations
    End Function

    Protected Function GetSystemViewIdNo()
        Dim cmd As String
        If ViewDisplayName Is Nothing Then
            ViewDisplayName = Name
        End If
        cmd = "SELECT IdNo FROM SystemView where SystemViewName ='" + ViewDisplayName.Trim() + "'"
        Return TranslatorDAC.ExecScalar(Of Int16)(cmd)
    End Function

    'Protected Sub TranslateControls(targetLanguageIdNo As Integer)
    '    Dim cmd As String
    '    cmd = "Select Caption, translatedCaption from SystemViewItemOriginal_view where LanguageIdNo = " + targetLanguageIdNo.ToString() + " and SystemViewIdNo = " + VSystemViewIdNo.ToString()
    '    Dim translations As DataSet
    '    translations = TranslatorDAC.ReturnDs(cmd)
    '    Dv = translations.Tables(0).DefaultView
    '    Dv.Sort = "Caption"
    '    Dim r As Integer
    '    If Tag Is Nothing Then
    '        r = 0
    '    Else
    '        r = Dv.Find(Tag.ToString.TrimEnd)
    '    End If
    '    If r > 0 Then
    '        Text = Dv(r).Item("translatedCaption")
    '    Else
    '        Text = Tag
    '    End If
    '    Dim allCtrl As New List(Of Control)
    '    For Each cCtrl As Control In FindControlRecursive(allCtrl, Me)
    '        If IsTranslatable(cCtrl) Then
    '            If TypeOf cCtrl Is MenuStrip Then
    '                Dim subMenuName = ""
    '                Dim menuStrip As MenuStrip = cCtrl
    '                TranslateMenuStripItems(menuStrip.Items, subMenuName)
    '            ElseIf TypeOf cCtrl Is ToolStrip Then
    '                TranslateToolStripItems(cCtrl)
    '            ElseIf TypeOf cCtrl Is CTreeViewOld Or TypeOf cCtrl Is TreeView Then
    '                Dim cT = CType(cCtrl, TreeView)
    '                cT.ExpandAll()
    '                'cT.RightToLeftLayout = GlobalVariables.RightToLeftLayout
    '                'cT.RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
    '            ElseIf TypeOf cCtrl Is DataGridView Then
    '                '_originalText = CaptionCollection.Item(cCtrl.Name)
    '                'r = Dv.Find(_originalText)
    '                'If r >= 0 Then
    '                ' CType(cCtrl, DataGridView).Text = Dv(r).Item(1)
    '                'Else
    '                'CType(cCtrl, DataGridView).Text = cCtrl.Tag
    '                'End If
    '                TranslateDataGridView(cCtrl)
    '            ElseIf TypeOf cCtrl Is DataGrid Then
    '                _originalText = CaptionCollection.Item(cCtrl.Name)
    '                r = Dv.Find(_originalText)
    '                If r >= 0 Then
    '                    CType(cCtrl, DataGrid).CaptionText = Dv(r).Item(1)
    '                Else
    '                    CType(cCtrl, DataGrid).CaptionText = cCtrl.Tag
    '                End If
    '            Else
    '                If TypeOf cCtrl Is CButton Then
    '                    TranslateButton(cCtrl)
    '                ElseIf TypeOf cCtrl Is CTabControl Then
    '                    Dim tc = CType(cCtrl, CTabControl)
    '                    tc.RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
    '                    tc.RightToLeftLayout = GlobalVariables.RightToLeftLayout
    '                End If
    '                Try
    '                    _originalText = CaptionCollection.Item(cCtrl.Name)

    '                    r = Dv.Find(_originalText)
    '                    If r >= 0 Then
    '                        cCtrl.Text = Dv(r).Item("TranslatedCaption")
    '                    Else
    '                        cCtrl.Text = cCtrl.Tag
    '                    End If
    '                Catch ex As Exception
    '                    cCtrl.Text = cCtrl.Tag
    '                End Try

    '            End If
    '        ElseIf TypeOf cCtrl Is CTextBox Then
    '            Dim tc = CType(cCtrl, CTextBox)
    '            If tc.ValueIsNumeric Then
    '                If tc.RightToLeft = RightToLeft.Yes Then
    '                    tc.TextAlign = HorizontalAlignment.Left
    '                Else
    '                    tc.TextAlign = HorizontalAlignment.Right
    '                End If
    '            End If
    '        End If
    '    Next
    'End Sub

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

    Private Sub UseOriginalDataGridView(ByRef cDataGridView As DataGridView)
        For Each col As DataGridViewColumn In cDataGridView.Columns
            col.HeaderText = col.Tag
        Next
    End Sub

    Private Sub TranslateDataGridView(ByRef cDataGridView As DataGridView)
        For Each col As DataGridViewColumn In cDataGridView.Columns
            col.HeaderText = Messaging.TranslateCaption(col.HeaderText)
        Next
    End Sub

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

    Protected Function TranslationLanguageExist(ByVal desiredLanguage As String)
        Dim cmd As String
        cmd = "SELECT count(*) FROM TranslatedCaption_View WHERE CultureInfoCode = '" _
              + desiredLanguage.TrimEnd + "'"
        Dim howMany As Integer = TranslatorDAC.ExecScalar(Of Integer)(cmd)
        If howMany > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Shared Sub SetControlVisibility(ByRef cCtrl As Control, controlVisible As Boolean)
        ' if Visible is false, Don't show the controls content by masking content with '*' asterisk
        If GlobalVariables.UserName = $"Arnel" Then
            SetPropertyValue(cCtrl, "Visible", True)
        ElseIf controlVisible Then
            SetPropertyValue(cCtrl, "Visible", True)
        Else
            SetPropertyValue(cCtrl, "Visible", False)
        End If
    End Sub

    Private Sub ApplyMenuSecurityNew(ByRef obj As ToolStripMenuItem, ByRef subMenuName As String)
        Dim toolStripMenuItem As ToolStripMenuItem = obj
        Dim controlSecurityKey = subMenuName + " > " + Mid(toolStripMenuItem.Name, 18)
        If GlobalVariables.IsUserLoggedIn Then
            SetMenuSecurity(toolStripMenuItem, controlSecurityKey)
        Else
            toolStripMenuItem.Enabled = False
            toolStripMenuItem.Visible = True
        End If
    End Sub

    'Private Function ApplyMenuSecurity(ByRef obj As ToolStripMenuItem, ByRef subMenuName As String, ByVal parentIdNo As Int32) As Int32
    '    Dim toolStripMenuItem As ToolStripMenuItem = obj

    '    Dim controlSecurityKey = subMenuName + " > " + Mid(toolStripMenuItem.Name, 18)
    '    'Dim service As New Service
    '    If GlobalVariables.IsUserLoggedIn Then
    '        SetMenuSecurity(toolStripMenuItem, controlSecurityKey)
    '        If _addSecurityObject Then
    '            Dim securityObject As New SecurityObject With {.SecurityObjectName = Mid(toolStripMenuItem.Name, 18),
    '                    .SystemViewIdNo = _VSystemViewIdNo,
    '                    .ParentIdNo = parentIdNo}
    '            parentIdNo = Presenter.AddSecurityObject(securityObject)
    '        End If
    '    Else
    '        toolStripMenuItem.Enabled = False
    '        toolStripMenuItem.Visible = True
    '    End If
    '    If GlobalVariables.UserName = $"Arnel" Then
    '        ' make all editable and visible regardless of security values
    '        toolStripMenuItem.Enabled = True
    '        toolStripMenuItem.Visible = True
    '    End If
    '    Return parentIdNo
    'End Function

    Private Sub SetMenuSecurity(cControl As Object, controlSecurityKey As String)
        If GlobalVariables.UserName = $"Arnel" Then
            ' make all editable and visible regardless of security values
            cControl.Enabled = True
            cControl.Visible = True
        Else
            Dim securityIdNo As Integer
            Dim controlSecurityValues As ArrayList
            Dim isSelectable As Boolean
            Dim isVisible As Boolean

            securityIdNo = GetControlSecurityIdNo(controlSecurityKey, True)

            If securityIdNo <> 0 Then
                controlSecurityValues = SetControlSecurityValue(securityIdNo)
                If controlSecurityValues.Count > 0 Then
                    ' Visible property stored in first element of the array
                    isVisible = controlSecurityValues(0)
                    isSelectable = controlSecurityValues(1)
                    ' Editable property stored in second element of the array
                Else
                    isVisible = False
                    isSelectable = False
                End If
            Else
                isVisible = False
                isSelectable = False
            End If
            cControl.Enabled = isSelectable
            cControl.Visible = isVisible
        End If
    End Sub

    Private Function SetControlSecurityValue(securityIdNo As Integer) As ArrayList
        Dim controlSecurityValues As ArrayList

        controlSecurityValues = Presenter.GetUserSecurity(Convert.ToInt16(securityIdNo),
                                                             GlobalVariables.SecurityGroupIdNo)
        Return controlSecurityValues
    End Function

    Private Sub BFMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            RaiseEvent BeforeLoad()
        End If
    End Sub

    Public Sub GetNSaveCaptions() 'control As Control)
        DoubleBuffered = True
        If GlobalVariables.TranslationMode Then
            CaptionCollection = StoreCaptions1.StoreTranslation(Me)
            StoreCaptions1.SaveControlsOriginalText(Me)
            DefaultMirroredLanguageIdNo = TranslatorDAC.DefaultMirroredLanguageIdNo
            If ViewDisplayName Is Nothing Then
                ViewDisplayName = Name
            End If
        End If
    End Sub

    Private Function GetControlSecurityIdNo(ByRef controlSecurityKey As String, Optional objIsMenu As Boolean = False) As Int64
        If objIsMenu Then
            Return Presenter.GetRecordFieldWithKey(controlSecurityKey, "SecurityObject_View1", "FullPathName", "IdNo")
        Else
            Dim idNo As Int32 = Presenter.GetRecordFieldWithKey(controlSecurityKey, "SecurityObject", "SecurityObjectName", "IdNo")
            Dim retVal As Integer
            If Not Integer.TryParse(idNo, retVal) Then
                Return retVal
            Else
                Return 0
            End If
        End If
    End Function

    Public Sub SetObjectSecurityNew(ByRef cCtrl As Control)
        Dim objectSecurityKey As String
        If TypeOf cCtrl Is MenuStrip Then
            ' check for MenuStrip first because MenuStrip is also a ToolStrip
            Dim subMenuName = MenuFormName + " > " + cCtrl.Name.Trim()
            Dim menuStrip As MenuStrip = cCtrl
            SetMenuSecurity(menuStrip, subMenuName)
            SetMenuStripItemsNew(menuStrip.Items, subMenuName)
        ElseIf TypeOf cCtrl Is ToolStrip Then
            Dim subMenuName = MenuFormName + " > " + cCtrl.Name.TrimEnd()
            Dim toolStrip As ToolStrip = cCtrl
            SetMenuSecurity(toolStrip, subMenuName)
            SetToolStripItemsNew(toolStrip.Items, subMenuName)
        Else
            objectSecurityKey = GetControlSecurityKey(cCtrl)
            If objectSecurityKey Is Nothing OrElse objectSecurityKey = "" Then
                'cCtrl.Visible = True
                'cCtrl.Enabled = True
            Else
                Dim controlSecurityValues As ArrayList
                Dim isEditable As Boolean
                Dim isVisible As Boolean
                controlSecurityValues = GetControlSecurityValues(objectSecurityKey)
                If controlSecurityValues.Count > 0 Then
                    isVisible = controlSecurityValues(0)
                    isEditable = controlSecurityValues(1)
                Else
                    isVisible = False
                    isEditable = False
                End If
                SetControlVisibility(cCtrl, isVisible)
                SetControlEditability(cCtrl, isEditable)
            End If
        End If
    End Sub

    'Private Sub InitializeSecurityObject(ByRef cCtrl As Control)
    '    Dim objectSecurityKey As String
    '    If TypeOf cCtrl Is MenuStrip Then
    '        ' check for MenuStrip first because MenuStrip is also a ToolStrip
    '        Dim subMenuName = MenuFormName + " > " + cCtrl.Name.Trim()
    '        Dim menuStrip As MenuStrip = cCtrl
    '        SetMenuSecurity(menuStrip, subMenuName)
    '        SetMenuStripItemsNew(menuStrip.Items, subMenuName)
    '    ElseIf TypeOf cCtrl Is ToolStrip Then
    '        Dim subMenuName = MenuFormName + " > " + cCtrl.Name.TrimEnd()
    '        Dim toolStrip As ToolStrip = cCtrl
    '        SetMenuSecurity(toolStrip, subMenuName)
    '        SetToolStripItemsNew(toolStrip.Items, subMenuName)
    '    Else
    '        objectSecurityKey = GetControlSecurityKey(cCtrl)
    '        If objectSecurityKey Is Nothing Or objectSecurityKey = "" Then
    '            cCtrl.Visible = True
    '            cCtrl.Enabled = True
    '        Else
    '            Dim controlSecurityValues As ArrayList
    '            Dim isEditable As Boolean
    '            Dim isVisible As Boolean
    '            controlSecurityValues = GetControlSecurityValues(objectSecurityKey)
    '            If controlSecurityValues.Count > 0 Then
    '                isVisible = controlSecurityValues(0)
    '                isEditable = controlSecurityValues(1)
    '            Else
    '                isVisible = False
    '                isEditable = False
    '            End If
    '            SetControlVisibility(cCtrl, isVisible)
    '            SetControlEditability(cCtrl, isEditable)
    '        End If
    '    End If
    'End Sub

    Private Function GetControlSecurityKey(ByRef cCtrl As Control)
        If cCtrl.GetType().GetProperty("SecurityKey") IsNot Nothing Then
            Return GetPropertyValue(cCtrl, "SecurityKey")
        Else
            Return ""
        End If
    End Function

    Private Function GetControlSecurityValues(ByRef controlSecurityKey As String) As ArrayList
        Dim controlSecurityObjectIdNo As Int32
        controlSecurityObjectIdNo = Presenter.GetControlSecurityIdNo(controlSecurityKey)
        Return Presenter.GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo)
    End Function

    Private Sub SetControlEditability(ByRef cCtrl As Control, ByRef editable As Boolean)
        ' if Editable is False, make the control readonly property so that it can't be edited
        If Not editable Then
            SetPropertyValue(cCtrl, "DisplayOnly", True)
        End If
    End Sub

    Private Sub SetMenuStripItemsNew(dropDownItems As ToolStripItemCollection, pParentMenuName As String)
        For Each dropDownItem As Object In dropDownItems
            Dim subMenu = TryCast(dropDownItem, ToolStripMenuItem)
            If subMenu IsNot Nothing Then
                Dim parentMenuName = pParentMenuName
                ApplyMenuSecurityNew(dropDownItem, parentMenuName)
                If subMenu.HasDropDown Then
                    Dim childSubMenuName As String = pParentMenuName + " > " + Mid(dropDownItem.Name, 18)
                    SetMenuStripItemsNew(subMenu.DropDownItems, childSubMenuName)
                End If
            End If
        Next
    End Sub

    'Private Sub SetMenuStripItems(dropDownItems As ToolStripItemCollection, pParentMenuName As String, pParentIdNo As Int32)
    '    Dim parentIdNo As Int32
    '    Dim systemViewIdNo = VSystemViewIdNo
    '    For Each dropDownItem As Object In dropDownItems
    '        Dim subMenu = TryCast(dropDownItem, ToolStripMenuItem)
    '        If subMenu IsNot Nothing Then
    '            Dim parentMenuName = pParentMenuName
    '            parentIdNo = ApplyMenuSecurity(dropDownItem, parentMenuName, pParentIdNo)
    '            If subMenu.HasDropDown Then
    '                Dim childSubMenuName As String = pParentMenuName + " > " + Mid(dropDownItem.Name, 18)
    '                SetMenuStripItems(subMenu.DropDownItems, childSubMenuName, parentIdNo)
    '            End If
    '        End If
    '    Next
    'End Sub

    Private Sub SetToolStripItemsNew(dropDownItems As ToolStripItemCollection, subMenuName As String)
        For Each obj As Object In dropDownItems
            ' ReSharper disable once VBPossibleMistakenCallToGetType.2
            If obj.GetType().ToString() = "System.Windows.Forms.ToolStripButton" Then
                Dim toolStripButton As ToolStripButton = obj
                Dim controlSecurityKey = Mid(toolStripButton.Name, 16).TrimEnd()
                If GlobalVariables.IsUserLoggedIn Then
                    Dim controlSecurityValues As ArrayList
                    Dim isSelectable As Boolean
                    Dim isVisible As Boolean
                    Dim securityIdNo As Int32 = GetControlSecurityIdNo(subMenuName + " > " + controlSecurityKey, True)
                    If securityIdNo <> 0 Then
                        If GlobalVariables.SecurityGroupIdNo <> 0 Then
                            controlSecurityValues = Presenter.GetUserSecurity(securityIdNo,
                                                                            GlobalVariables.SecurityGroupIdNo)
                            If controlSecurityValues.Count > 0 Then
                                ' Visible property stored in first element of the array
                                isVisible = controlSecurityValues(0)
                                ' Editable property stored in third element of the array
                                isSelectable = controlSecurityValues(1)
                            Else
                                isVisible = False
                                isSelectable = False
                            End If
                        Else
                            isVisible = True
                            isSelectable = False
                        End If
                    Else
                        isVisible = True
                        isSelectable = True
                    End If
                    toolStripButton.Enabled = isSelectable
                    toolStripButton.Visible = isVisible
                Else
                    If obj.Name = "ToolStripButtonLogin" Then
                        toolStripButton.Enabled = True
                        toolStripButton.Visible = True
                    Else
                        toolStripButton.Enabled = False
                        toolStripButton.Visible = True
                    End If
                End If
            Else
                obj.Enabled = True
                obj.Visible = True
            End If
        Next
    End Sub

    'Private Sub SetToolStripItems(dropDownItems As ToolStripItemCollection, subMenuName As String, parentIdNo As Int32)
    '    Try
    '        Dim systemViewIdNo = VSystemViewIdNo
    '        For Each obj As Object In dropDownItems
    '            ' ReSharper disable once VBPossibleMistakenCallToGetType.2
    '            If obj.GetType().ToString() = "System.Windows.Forms.ToolStripButton" Then ' And GlobalVariables.SecurityGroupIdNo > 0 Then
    '                Dim toolStripButton As ToolStripButton = obj
    '                'Dim controlSecurityKey = pParentMenuName + "." + Mid(toolStripButton.Name, 16).TrimEnd()
    '                Dim controlSecurityKey = Mid(toolStripButton.Name, 16).TrimEnd()
    '                If GlobalVariables.IsUserLoggedIn Then
    '                    Dim controlSecurityValues As ArrayList
    '                    Dim isSelectable As Boolean
    '                    Dim isVisible As Boolean
    '                    'Dim service As New Service
    '                    Dim securityIdNo As Int32 = GetControlSecurityIdNo(subMenuName + " > " + controlSecurityKey, True)

    '                    If securityIdNo <> 0 Then
    '                        If GlobalVariables.SecurityGroupIdNo <> 0 Then
    '                            controlSecurityValues = Presenter.GetUserSecurity(securityIdNo,
    '                                                                            GlobalVariables.SecurityGroupIdNo)
    '                            If controlSecurityValues.Count > 0 Then
    '                                ' Visible property stored in first element of the array
    '                                isVisible = controlSecurityValues(0)
    '                                ' Editable property stored in third element of the array
    '                                isSelectable = controlSecurityValues(1)
    '                            Else
    '                                isVisible = False
    '                                isSelectable = False
    '                            End If
    '                        Else
    '                            isVisible = True
    '                            isSelectable = False
    '                        End If
    '                    Else
    '                        isVisible = True
    '                        isSelectable = True
    '                    End If
    '                    toolStripButton.Enabled = isSelectable
    '                    toolStripButton.Visible = isVisible
    '                Else
    '                    If obj.Name = "ToolStripButtonLogin" Then
    '                        toolStripButton.Enabled = True
    '                        toolStripButton.Visible = True
    '                    Else
    '                        toolStripButton.Enabled = False
    '                        toolStripButton.Visible = True
    '                    End If
    '                End If
    '                If _addSecurityObject Then
    '                    Dim securityObject As New SecurityObject With {.SecurityObjectName = controlSecurityKey,
    '                                                                   .SystemViewIdNo = systemViewIdNo,
    '                                                                   .ParentIdNo = parentIdNo}
    '                    Presenter.AddSecurityObject(securityObject)
    '                End If
    '            Else
    '                obj.Enabled = True
    '                obj.Visible = True
    '            End If
    '        Next
    '        If GlobalVariables.UserName = $"Arnel" Then
    '            ' override values regardless of security values
    '            For Each obj As Object In dropDownItems
    '                obj.Enabled = True
    '                obj.Visible = True
    '            Next
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, $"SetToolStripItems", MessageBoxButtons.OK, MessageBoxIcon.[Error])
    '    End Try
    'End Sub

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

    Private Sub UseOriginalCaptions()
        Dim allCtrl As New List(Of Control)
        For Each cCtrl As Control In FindControlRecursive(allCtrl, Me)
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

    Private Sub UseOriginalToolStripButtonImage(cButton As ToolStripButton)
        Dim cResourceName = cButton.Name.ToLower()
        If GlobalResources.My.Resources.ResourceManager.GetObject(cResourceName) IsNot Nothing Then
            cButton.Image = GlobalResources.My.Resources.ResourceManager.GetObject(cResourceName)
        End If
    End Sub

    'Private Sub CFormEntryNew_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
    '    Debugger.Break()
    'End Sub

    'Private Sub BfMain_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
    '    If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft And BackgroundImage IsNot Nothing Then
    '        ' this routine is needed for righttoleft languages because the backgroundimage is
    '        ' not redrawn for this culture.  So need to manually repaint the background form with
    '        ' this procedure.
    '        Dim r As Rectangle = ClientRectangle
    '        e.Graphics.DrawImage(BackgroundImage, r)
    '    End If
    'End Sub

    'Protected Overridable Sub EndEditOnAllBindingSources()
    '    'Dim bindingSourcesQuery = From BindingSources In components.Components
    '    '                          Where (TypeOf BindingSources Is Windows.Forms.BindingSource)
    '    'Select Case BindingSources
    '    Dim currentComponents = components.Components
    '    For Each item In currentComponents
    '        If TypeOf item Is Windows.Forms.BindingSource Then
    '            item.EndEdit()
    '        End If
    '    Next
    'End Sub

    Public Shared Sub EnableDoubleBuff(ByVal cont As Control)
        Dim demoProp As Reflection.PropertyInfo = GetType(Control).GetProperty("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        demoProp.SetValue(cont, True, Nothing)
    End Sub

    Public Property HideNavigatorButtons As Boolean
    Public Property IgnoreTextBoxNumParserMessage As Boolean

    Protected Function TextBoxNumParser(Of T As Structure)(ByRef control As CTextBox) As T
        Dim retValue As T
        Try
            retValue = Parser(Of T).Parser(control.Text)
            Text = retValue.ToString()
        Catch ex As Exception
            If Not IgnoreTextBoxNumParserMessage Then
                Dim description As String
                If TypeOf control Is ILinkedLabel Then
                    description = DirectCast(control, ILinkedLabel).GetControlDescription()
                Else
                    description = control.Name
                End If
            End If
            retValue = Parser(Of T).Parser("0")
        End Try
        Return retValue
    End Function

    Protected Overloads Sub CreateDataSource(tableName As String, ByRef control As Control)
        If Ea IsNot Nothing Then
            Ea.PublishEvent(New GetDataSource(tableName, control))
        End If
    End Sub

    Protected Overloads Sub CreateDataSource(tableName As String, ByRef control As Control, filter As String)
        If Ea IsNot Nothing Then
            Ea.PublishEvent(New GetDataSource(tableName, control, filter))
        End If
    End Sub

    Protected Overloads Sub CreateDataSource(tableName As String, ByRef control As Control, sortKey As String, filter As String)
        If Ea IsNot Nothing Then
            Ea.PublishEvent(New GetDataSource(tableName, control, sortKey, filter))
        End If
    End Sub

    Protected Overloads Sub CreateDataSource(tableName As String, ByRef control As Control, fields As String(), optional sortKey As String = "", Optional filter As String = "")
        If Ea IsNot Nothing Then
            Ea.PublishEvent(New GetDataSource(tableName, control, fields, sortKey, filter))
        End If
    End Sub

    'Protected Overloads Sub CreateLookupData(tableName As String, ByRef targetLookup As List(Of Lookup.LookupData), Optional filter As String = Nothing)
    '    Dim varName = NameOf(targetLookup)
    '    Ea.PublishEvent(New GetLookupDataRequested(tableName, Me, varName, filter))
    'End Sub

    'Protected Function CreateLookupData(tableName As String, targetProperty As String) As List(Of Lookup.LookupData)
    '    Dim data As List(Of Lookup.LookupData)
    '    Ea.PublishEvent(New GetLookupDataRequested(tableName, Me, targetProperty))
    '    Return data
    'End Function

    ' ReSharper disable once UnassignedField.Local

    Protected Sub GetLookupData(tableName As String, targetProperty As String, Optional filter As String = Nothing) 'As List(Of Lookup.LookupData)
        'Dim dataLookupFunctionVariable As New List(Of Lookup.LookupData)
        Ea.PublishEvent(New GetLookupDataRequested(tableName, Me, targetProperty, filter))
        'Return dataLookupFunctionVariable
    End Sub

    Protected Overloads Sub CreateLookupData(tableName As String, targetProperty As String)
        Ea.PublishEvent(New GetLookupDataRequested(tableName, Me, targetProperty))
    End Sub

    Protected Overloads Sub CreateLookupData(tableName As String, targetProperty As String, filter As String)
        Ea.PublishEvent(New GetLookupDataRequested(tableName, Me, targetProperty, filter))
    End Sub

    Protected Overloads Sub CreateLookupData(tableName As String, targetProperty As String, sortKey As String, filter As String)
        Ea.PublishEvent(New GetLookupDataRequested(tableName, Me, targetProperty, sortKey, filter))
    End Sub

    Protected Overloads Sub CreateLookupData(tableName As String, targetProperty As String, fields As String(), Optional filter As String = Nothing)
        Ea.PublishEvent(New GetLookupDataRequested(tableName, Me, targetProperty, fields, filter))
    End Sub

    Protected Overloads Sub CreateLookupData(tableName As String, targetProperty As String, sortField As String, fields As String(), Optional filter As String = Nothing)
        Ea.PublishEvent(New GetLookupDataRequested(tableName, Me, targetProperty, sortField, fields, filter))
    End Sub

    Public Sub CreateEnumDataSource(Of TE)(ByRef comboControl As CaComboBox)
        comboControl.DataSource = GetEnumData(Of TE)()
    End Sub

    Public Sub CreateEnumData(Of TE)(ByRef dataTarget As Object)
        dataTarget = GetEnumData(Of TE)()
    End Sub

    Private Function GetEnumData(Of TE)()
        Dim dataList As New List(Of Lookup.LookupData)
        For Each c In [Enum].GetValues(GetType(TE))
            Dim data As New Lookup.LookupData With {
                    .IdNo = CInt(c),
                    .Code = EnumToCode(c),
                    .Name = Messaging.TranslateCaption(c.ToString().SplitCamelCase())
                    }
            dataList.Add(data)
        Next
        Return dataList
    End Function

    Public Function GetFieldType(fieldName As String) As Type
        Return Invoker.GetProperty(Me, fieldName).GetType
    End Function

    Protected Sub ProcessCellEndEdit(dataGridView As DataGridView, bindingSource As BindingSource)
        Dim firstDisplayedRow = dataGridView.FirstDisplayedScrollingRowIndex
        Ea.PublishEvent(New DataChanged(bindingSource,
                                                dataGridView.CurrentRow.Index,
                                                dataGridView.CurrentCell.OwningColumn.DataPropertyName,
                                                dataGridView.CurrentCell.OwningColumn.Name,
                                                dataGridView.CurrentCell.Value))

    End Sub

    Public Sub RunSubForm(Of TF, TP)(data As Object, subFormParent As Form)
        Dim childForm = Activator.CreateInstance(GetType(TF), data)
        Activator.CreateInstance(GetType(TP), {childForm})
        Dim pType As Type = GetType(TP)
        childForm.Presenter = Activator.CreateInstance(pType, {childForm})
        childForm.MdiParent = subFormParent
        childForm.Show()
    End Sub

End Class

Public Class SettingsSaver
    Private _top As UInt16
    Private _left As UInt16
    Private _width As UInt16
    Private _height As UInt16
    Private _visible As Boolean

    Public Sub SaveSetting(control As Control)
        _top = Math.Max(control.Top, 0)
        _left = Math.Max(control.Left, 0)
        _width = control.Width
        _height = control.Height
        _visible = control.Visible
    End Sub

    Public Sub RestoreSetting(control As Control)
        control.Top = _top
        control.Left = _left
        control.Width = _width
        control.Height = _height
        control.Visible = _visible
    End Sub

End Class