Imports System.Drawing
Imports System.Globalization
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views

Public Class BfMain
    Implements IView

    Dim _originalText As String

    '    Dim _menuLevel As String = ""
    Private _textDisplayLanguage As String

    Protected CaptionCollection As New Collection
    Protected VSystemViewIdNo As Int16
    Protected InitializationMode As Boolean = True
    Protected LtrCultureInfoStr = GlobalVariables.DefaultUnmirroredCultureInfoStr
    Protected RtlCultureInfoStr = GlobalVariables.DefaultMirroredCultureInfoStr
    Protected DefaultMirroredLanguageIdNo As Int16
    Protected Shared ResetEvent As AutoResetEvent = New AutoResetEvent(False)
    Public Dv As DataView
    Public MyErrorProvider As New ErrorProviderExtended

    Public Event AfterTranslateForm()

    Public Event BeforeLoad()

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            TextDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name

            'If IsRightToLeft(TextDisplayLanguage) Then
            '    RightToLeft = RightToLeft.Yes
            '    RightToLeftLayout = True
            'Else
            '    RightToLeft = RightToLeft.No
            '    RightToLeftLayout = False
            'End If
        End If

        ' Add any initialization after the InitializeComponent() call.

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

    'Public Shadows Event Load(sender As Object, e As EventArgs)
    Public Overridable Property PresenterObj

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

    Protected Sub SetCulture(ByVal cultureCode As String)
        If FormCulture Is Nothing Then
            If IsCultureOk(cultureCode) Then
                CultureInfo.CurrentCulture = New CultureInfo(cultureCode, False)
            Else
                cultureCode = "en-US"
                _textDisplayLanguage = cultureCode
                CultureInfo.CurrentCulture = New CultureInfo("en-US", False)
            End If
            SetFormCulture()
        Else
            If FormCulture.Name = CultureInfo.CurrentCulture.Name Then
                ' nothing to do already set.
            Else
                SetFormCulture()
            End If
        End If
    End Sub

    Protected Sub SetFormCulture()
        FormCulture = CultureInfo.CurrentCulture
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

    Public Sub SetupDisplay()
        If IsRightToLeft(_textDisplayLanguage) Then
            RightToLeftLayout = True
            RightToLeft = RightToLeft.Yes
        Else
            RightToLeftLayout = False
            RightToLeft = RightToLeft.No
        End If
    End Sub

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
               TypeOf ctrl Is CTreeView OrElse
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

    'Public Sub ProcessMenuItems(ByVal menuItems As Menu.MenuItemCollection, ByVal mLevel As String)
    '    Dim i As Int16
    '    For i = 0 To menuItems.Count - 1
    '        Dim mi As MenuItem = menuItems(i)
    '        Dim localMLevel As String = mLevel + i.ToString
    '        _originalText = CaptionCollection.Item(localMLevel)
    '        Dim r As Integer = Dv.Find(_originalText)
    '        If r >= 0 Then mi.Text = Dv(r).Item($"TranslatedCaption") _
    '               Else mi.Text = _originalText
    '        If mi.MenuItems.Count > 0 Then _
    '        ProcessMenuItems(mi.MenuItems, localMLevel)
    '    Next
    'End Sub

    Public Sub TranslateForm()
        SuspendLayout()
        Dim myImage As Bitmap
        myImage = BackgroundImage
        BackgroundImage = Nothing
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            GlobalVariables.RightToLeftLayout = True
            RightToLeftLayout = True
            RightToLeft = RightToLeft.Yes
        Else
            GlobalVariables.RightToLeftLayout = False
            RightToLeftLayout = False
            RightToLeft = RightToLeft.No
        End If
        TranslateCaptions(TextDisplayLanguage)
        BackgroundImage = myImage
        ResumeLayout()
        RaiseEvent AfterTranslateForm()

    End Sub

    Protected Sub RunTranslator(ByVal nSystemViewIdNo)
        Dim frm As New TranslationTableManager()
        frm.SystemViewIdNoToTranslate = nSystemViewIdNo
        frm.AppDataDAC = AppDataDAC
        frm.TranslatorDAC = TranslatorDAC
        frm.Show()
    End Sub

    Protected Overridable Sub ChangeToLtrDisplay()
        SuspendLayout()
        RightToLeftLayout = False
        RightToLeft = RightToLeft.No
        ResumeLayout()
    End Sub

    'Private Function GetAvailableTranslationLanguageIdNo(ByVal desiredLanguage As String) As Int32
    '    Dim cmd As String
    '    Dim fallBackLanguageIdNo As Int16
    '    Dim fallBackLanguage As String
    '    Dim useOriginal As Boolean
    '    Dim desiredLanguageIdNo As Int16
    '    cmd = "Select  IdNo from Languages where cultureInfoCode = '" + desiredLanguage + "'"
    '    desiredLanguageIdNo = TranslatorDAC.ExecScalar(Of String)(cmd)
    '    If desiredLanguageIdNo = "_Original" Or desiredLanguage = GlobalVariables.OriginalAppLanguage Then
    '        Return 1 ' the userIdLanguageIdNo for originalcaption
    '    Else
    '        If Not TranslationExist(desiredLanguage) Then
    '            If allowFallBack Then
    '                fallBackLanguageIdNo = GetFallBackLanguageIdNo(desiredLanguage)
    '                cmd = "Select cultureInfoCode from Languages where IdNo = " + fallBackLanguageIdNo.ToString()
    '                fallBackLanguage = TranslatorDAC.ExecScalar(Of String)(cmd)
    '            End If
    '        End If
    '    End If
    '    Return
    'End Function
    Protected Overridable Sub ChangeToRtlDisplay()
        SuspendLayout()
        RightToLeftLayout = True
        RightToLeft = RightToLeft.Yes
        ResumeLayout()
    End Sub

    Protected Function GetFallBackLanguageIdNo(ByVal desiredLanguage As String) As Int16
        Dim cmd As String
        Dim fallBackLanguageIdNo As Int16
        Dim languageBaseCode = Strings.Left(desiredLanguage, desiredLanguage.IndexOf("-", StringComparison.Ordinal))
        cmd = "SELECT TOP 1 LanguageIdNo,COUNT(LanguageIdNo) AS value_occurrence FROM TranslatedCaption_View where RTrim(LanguageCode2) = '" + languageBaseCode + "' " +
              "GROUP BY LanguageIdNo ORDER BY value_occurrence DESC"
        fallBackLanguageIdNo = TranslatorDAC.ExecScalar(Of Int16)(cmd)
        'If fallBackLanguageIdNo = 0 Then
        '    fallBackLanguageIdNo = 0 'Original Language
        'End If
        Return fallBackLanguageIdNo
    End Function

    Protected Function GetFallBackMessage(ByVal message As String, ByVal desiredLanguage As String) As String
        Dim cmd As String
        Dim languageBaseCode = Strings.Left(desiredLanguage, desiredLanguage.IndexOf("-", StringComparison.Ordinal))
        cmd = "SELECT TranslatedCaption from TranslatedMessages_View where Caption = '" + RTrim(message) + "' and RTrim(LanguageCode2) = '" + languageBaseCode + "' "
        Return TranslatorDAC.ExecScalar(Of String)(cmd)
    End Function

    Protected Sub TranslateCaptions(ByVal desiredLanguage As String, Optional ByVal allowFallBack As Boolean = True)
        Dim cmd As String
        Dim desiredLanguageIdNo As Int16
        Dim fallBackLanguageIdNo As Int16
        Dim fallBackLanguage As String
        Dim targetLanguageIdNo As Int16 = 0
        Dim useOriginal As Boolean
        cmd = "Select IdNo from Languages where cultureInfoCode = '" + desiredLanguage + "'"
        desiredLanguageIdNo = TranslatorDAC.ExecScalar(Of Int16)(cmd)
        If desiredLanguageIdNo = 0 Then
            useOriginal = True
        Else
            If Not TranslationLanguageExist(desiredLanguage) Then
                If allowFallBack Then
                    fallBackLanguageIdNo = GetFallBackLanguageIdNo(desiredLanguage)
                    cmd = "Select cultureInfoCode from Languages where IdNo = " + fallBackLanguageIdNo.ToString()
                    fallBackLanguage = TranslatorDAC.ExecScalar(Of String)(cmd)
                    If NeedToTranslateText(fallBackLanguage) Then
                        useOriginal = True
                    Else
                        targetLanguageIdNo = fallBackLanguageIdNo
                    End If
                Else
                    useOriginal = True
                End If
            Else
                targetLanguageIdNo = desiredLanguageIdNo
            End If
        End If
        If useOriginal Then
            UserOriginalCaptions()
        Else
            cmd = "Select Caption, translatedCaption from SystemViewItemOriginal_view where LanguageIdNo = " + targetLanguageIdNo.ToString() + " and SystemViewIdNo = " + VSystemViewIdNo.ToString()
            Dim translations As DataSet
            translations = TranslatorDAC.ReturnDs(cmd)
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
            Dim allCtrl As New List(Of Control)
            For Each cCtrl As Control In FindControlRecursive(allCtrl, Me)
                If IsTranslatable(cCtrl) Then
                    If TypeOf cCtrl Is MenuStrip Then
                        Dim subMenuName = ""
                        Dim menuStrip As MenuStrip = cCtrl
                        TranslateMenuStripItems(menuStrip.Items, subMenuName)
                    ElseIf TypeOf cCtrl Is ToolStrip Then
                        TranslateToolStripItems(cCtrl)
                    ElseIf TypeOf cCtrl Is CTreeView Or TypeOf cCtrl Is TreeView Then
                        Dim cT = CType(cCtrl, TreeView)
                        cT.ExpandAll()
                        cT.RightToLeftLayout = GlobalVariables.RightToLeftLayout
                        cT.RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
                    ElseIf TypeOf cCtrl Is DataGridView Then
                        '_originalText = CaptionCollection.Item(cCtrl.Name)
                        'r = Dv.Find(_originalText)
                        'If r >= 0 Then
                        '    CType(cCtrl, DataGridView).Text = Dv(r).Item(1)
                        'Else
                        '    CType(cCtrl, DataGridView).Text = cCtrl.Tag
                        'End If
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
                            Dim tc = CType(cCtrl, CTabControl)
                            tc.RightToLeftLayout = GlobalVariables.RightToLeftLayout
                            tc.RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
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

    Private Sub TranslateToolStripButtonImage(cButton As ToolStripButton)
        Dim cResourceName = cButton.Name.ToLower()
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            Dim cCurrentCulture = CultureInfo.CurrentCulture.Name.Replace("-", "_")
            cResourceName = cResourceName + "_" + cCurrentCulture.ToLower()
        Else
            cResourceName = If(cButton.Image.Tag IsNot Nothing, cButton.Image.Tag, cResourceName)
            'cButton.ToolTipText = If(cButton.Tag IsNot Nothing, cButton.Tag(1), cButton.ToolTipText)
        End If
        If GlobalResources.My.Resources.ResourceManager.GetObject(cResourceName) IsNot Nothing Then
            cButton.Image = GlobalResources.My.Resources.ResourceManager.GetObject(cResourceName)
        End If
    End Sub

    'Private Sub TranslateToolStripLabel(cLabel As ToolStripLabel)
    '    Dim cResourceName = cLabel.Name.ToLower()
    '    cLabel.ToolTipText = Messaging.TranslateCaption(cLabel.Tag(1))
    'End Sub

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

    'Private Shared Sub SetControlMaskability(ByRef cCtrl As Control, controlViewable As Boolean)
    '    ' if Viewable is false, Don't show the controls content by masking content with '*' asterisk
    '    If Not controlViewable Then
    '        SetPropertyValue(cCtrl, "Viewable", controlViewable)
    '        'SetPropertyValue(cCtrl, "PasswordChar", Convert.ToChar("*"))
    '    End If
    'End Sub

    ''Private Shared Sub SetControlSelectability(ByRef cCtrl As Control, controlSelectable As Boolean)
    '    ' if Selectable is false, Don't let the user select the data so set enabled to False
    '    If Not controlSelectable Then
    '        SetPropertyValue(cCtrl, "Selectable", controlSelectable)
    '    End If
    'End Sub

    Private Shared Sub SetControlVisibility(ByRef cCtrl As Control, controlVisible As Boolean)
        ' if Visible is false, Don't show the controls content by masking content with '*' asterisk
        If Not controlVisible Then
            SetPropertyValue(cCtrl, "Visible", controlVisible)
        End If
    End Sub

    Private Sub ApplyMenuSecurity(ByRef obj As ToolStripMenuItem, ByRef subMenuName As String)
        Dim toolStripMenuItem As ToolStripMenuItem = obj
        Dim controlSecurityKey = subMenuName + "." + Mid(toolStripMenuItem.Name, 18)
        Dim controlSecurityValues As ArrayList
        Dim isSelectable As Boolean
        Dim isVisible As Boolean
        Dim securityIdNo As Int32
        'Dim service As New Service
        If GlobalVariables.IsUserLoggedIn Then
            ''if controlSecurityKey = "Main.Menu.Masters.Security" then
            ''    Debugger.Break()
            ''End If
            securityIdNo = GetControlSecurityIdNo(controlSecurityKey)
            If securityIdNo <> 0 Then
                'securityIdNo = Service.GetRecordFieldWithKey(controlSecurityKey, "SecurityObject", "SecurityObjectName", "IdNo")
                controlSecurityValues = PresenterObj.GetUserSecurity(Convert.ToInt16(securityIdNo),
                                                                GlobalVariables.SecurityGroupIdNo)
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
                isVisible = True
                isSelectable = True
            End If
            toolStripMenuItem.Enabled = isSelectable
            toolStripMenuItem.Visible = isVisible
            Dim securityControl As New SecurityControl With {.SecurityControlName = controlSecurityKey,
                    .SystemViewIdNo = VSystemViewIdNo}
            PresenterObj.AddSecurityControl(securityControl)
        Else
            toolStripMenuItem.Enabled = False
            toolStripMenuItem.Visible = True
        End If
    End Sub

    'Private Sub BfForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Dim allControls As New List(Of Control)
    '    SecurityPresenterObj = New SecurityPresenter
    '    For Each cCtrl As Control In FindControlRecursive(allControls, Me)
    '        SetControlSecurity(cCtrl)
    '    Next
    'End Sub

    Private Sub BFMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            'Dim ds As New DataSet
            'ds = TranslatorDAC.ReturnDs(
            '     "Select lang from languages")
            'cmbLanguagePicker.Items.Clear()
            'For Each dr As DataRow In ds.Tables(0).Rows
            '    cmbLanguagePicker.Items.Add(dr("lang"))
            'Next
            'ds = Nothing
            DoubleBuffered = True
            Dim cmd As String
            RaiseEvent BeforeLoad()
            CaptionCollection = StoreCaptions1.StoreCaptions(Me)
            DefaultMirroredLanguageIdNo = TranslatorDAC.DefaultMirroredLanguageIdNo
            If ViewDisplayName Is Nothing Then
                ViewDisplayName = Name
            End If
            cmd = "SELECT IdNo FROM SystemView where SystemViewName ='" + ViewDisplayName.Trim() + "'"
            VSystemViewIdNo = TranslatorDAC.ExecScalar(Of Int16)(cmd)
            TranslateForm()
        End If
    End Sub

    Private Function GetControlSecurityIdNo(ByRef controlSecurityKey As String) As Int64
        If PresenterObj Is Nothing Then
            'Dim securityPresenter As SecurityPresenter = New SecurityPresenter(Me)
            Dim idNo As Int32 = PresenterObj.GetRecordFieldWithKey(controlSecurityKey, "SecurityObject", "SecurityObjectName", "IdNo")
            Dim retVal As Integer
            If Not Integer.TryParse(idNo, retVal) Then
                Return retVal
            Else
                Return 0
            End If
        Else
            Return PresenterObj.GetRecordFieldWithKey(controlSecurityKey, "SecurityObject", "SecurityObjectName", "IdNo")
        End If
    End Function

    'Private Sub BfForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    '    Dim allControls As New List(Of Control)
    '    For Each cCtrl As Control In FindControlRecursive(allControls, Me)
    '        SetControlSecurity(cCtrl)
    '    Next
    'End Sub

    Public Sub SetControlSecurity(ByRef cCtrl As Control)
        Dim controlSecurityKey As String
        If TypeOf cCtrl Is MenuStrip Then
            ' check for MenuStrip first because MenuStrip is also a ToolStrip
            Dim subMenuName = MenuFormName + "." + cCtrl.Name.TrimEnd()
            Dim menuStrip As MenuStrip = cCtrl
            SetMenuStripItems(menuStrip.Items, subMenuName)
        ElseIf TypeOf cCtrl Is ToolStrip Then
            Dim subMenuName = MenuFormName + "." + cCtrl.Name.TrimEnd()
            Dim toolStrip As ToolStrip = cCtrl
            SetToolStripItems(toolStrip.Items, subMenuName)
        Else
            controlSecurityKey = GetControlSecurityKey(cCtrl)
            If controlSecurityKey Is Nothing Or controlSecurityKey = "" Then
                ' nothing to do just leave the default values
            Else
                Dim controlSecurityValues As ArrayList
                Dim isEditable As Boolean
                'Dim isSelectable As Boolean
                Dim isVisible As Boolean
                'Dim isViewable As Boolean
                controlSecurityValues = GetControlSecurityValues(controlSecurityKey)
                If controlSecurityValues.Count > 0 Then
                    ' Visible property stored in first element of the array
                    isVisible = controlSecurityValues(0)
                    ' Selectable property stored in second element of the array
                    'isSelectable = controlSecurityValues(1)
                    ' Viewable property stored in third element of the array
                    'isViewable = controlSecurityValues(2)
                    ' Editable property stored in fourth element of the array
                    isEditable = controlSecurityValues(1)
                Else
                    isVisible = False
                    'isSelectable = False
                    isEditable = False
                    'isViewable = False
                End If
                SetControlVisibility(cCtrl, isVisible)
                'SetControlMaskability(cCtrl, isViewable)
                SetControlEditability(cCtrl, isEditable)
                'SetControlSelectability(cCtrl, isSelectable)
            End If
        End If
    End Sub

    Private Function GetControlSecurityKey(ByRef cCtrl As Control)
        If cCtrl.GetType().GetProperty("SecurityKey") IsNot Nothing Then
            Return GetPropertyValue(cCtrl, "SecurityKey")
        Else
            Return ""
        End If
    End Function

    Private Function GetControlSecurityValues(ByRef controlSecurityKey As String) As ArrayList
        Dim controlSecurityObjectIdNo As Int16
        controlSecurityObjectIdNo = PresenterObj.GetControlSecurityIdNo(controlSecurityKey)
        Return PresenterObj.GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo)
    End Function

    Private Sub SetControlEditability(ByRef cCtrl As Control, ByRef editable As Boolean)
        ' if Editable is False, make the control readonly property so that it can't be edited
        If Not editable Then
            SetPropertyValue(cCtrl, "DisplayOnly", True)
        End If
    End Sub

    Private Sub SetMenuStripItems(dropDownItems As ToolStripItemCollection, subMenuName As String)
        Try
            Dim parentMenu As String
            parentMenu = subMenuName
            'IF parentMenu = "Main.Menu.Masters" then
            '    debugger.Break()
            'End If
            For Each obj As Object In dropDownItems
                Dim subMenu = TryCast(obj, ToolStripMenuItem)
                If subMenu IsNot Nothing Then
                    ApplyMenuSecurity(obj, parentMenu)
                    If subMenu.HasDropDownItems Then
                        subMenuName = parentMenu + "." + Mid(obj.Name, 18)
                        SetMenuStripItems(subMenu.DropDownItems, subMenuName)
                        'Dim securityControl As New SecurityControl With {.SecurityControlName = subMenuName,
                        '        .SystemViewIdNo = VSystemViewIdNo}
                        'PresenterObj.AddSecurityControl(securityControl)
                    End If
                End If
            Next
        Catch ex As Exception
            'MessageBox.Show(ex.Message, $"SetMenuStripItems", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub SetToolStripItems(dropDownItems As ToolStripItemCollection, subMenuName As String)
        Try
            For Each obj As Object In dropDownItems
                ' ReSharper disable once VBPossibleMistakenCallToGetType.2
                If obj.GetType().ToString() = "System.Windows.Forms.ToolStripButton" Then ' And GlobalVariables.SecurityGroupIdNo > 0 Then
                    Dim toolStripButton As ToolStripButton = obj
                    Dim controlSecurityKey = subMenuName + "." + Mid(toolStripButton.Name, 16).TrimEnd()
                    If GlobalVariables.IsUserLoggedIn Then
                        Dim controlSecurityValues As ArrayList
                        Dim isSelectable As Boolean
                        Dim isVisible As Boolean
                        'Dim service As New Service
                        Dim securityIdNo As Int32 = GetControlSecurityIdNo(controlSecurityKey)

                        If securityIdNo <> 0 Then
                            If GlobalVariables.SecurityGroupIdNo <> 0 Then
                                controlSecurityValues = PresenterObj.GetUserSecurity(securityIdNo,
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
                    Dim securityControl As New SecurityControl With {.SecurityControlName = controlSecurityKey,
                                                                     .SystemViewIdNo = VSystemViewIdNo}
                    PresenterObj.AddSecurityControl(securityControl)
                Else
                    obj.Enabled = True
                    obj.Visible = True
                End If

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, $"SetToolStripItems", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
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
                        'Else
                        '    Dim toolStripMenuItem As ToolStripMenuItem = obj
                        '    toolStripMenuItem.Text = toolStripMenuItem.Tag
                    End If

                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    'Protected Sub TranslateMessage(ByVal message As String, Optional ByVal allowFallBack As Boolean = True)
    '    Dim cmd As String
    '    Dim desiredLanguageIdNo As Int16 = 0
    '    Dim fallBackLanguageIdNo As Int16 = 0
    '    Dim fallBackLanguage As String = GlobalVariables.OriginalAppTextLanguage
    '    Dim useOriginal As Boolean
    '    cmd = "Select IdNo from Languages where cultureInfoCode = '" + textDisplayLanguage + "'"
    '    desiredLanguageIdNo = TranslatorDAC.ExecScalar(Of Int16)(cmd)
    '    If desiredLanguageIdNo = 0 Then
    '        useOriginal = True
    '    Else
    '        If Not TranslationLanguageExist(TextDisplayLanguage) Then
    '            If allowFallBack Then
    '                fallBackLanguageIdNo = GetFallBackLanguageIdNo(TextDisplayLanguage)
    '                cmd = "Select cultureInfoCode from Languages where IdNo = " + fallBackLanguageIdNo.ToString()
    '                fallBackLanguage = TranslatorDAC.ExecScalar(Of String)(cmd)
    '                If NeedToTranslateText(fallBackLanguage) Then
    '                    useOriginal = True
    '                Else
    '                    cmd = "select translated from formItemsOriginal_view where LanguageIdNo = " + fallBackLanguageIdNo.ToString()
    '                End If
    '            Else
    '                useOriginal = True
    '            End If
    '        Else
    '            cmd = "select translated from formItemsOriginal_view where LanguageIdNo = " + desiredLanguageIdNo.ToString() + " and VSystemViewIdNo = " + VSystemViewIdNo.ToString()
    '        End If
    '    End If
    '    If useOriginal Then
    '        UserOriginalCaptions()
    '    Else
    '        Dim translations As DataSet
    '        translations = TranslatorDAC.ReturnDs(cmd)
    '        Dv = translations.Tables(0).DefaultView
    '        Dv.Sort = "Original"
    '        Dim r As Integer
    '        If Tag Is Nothing Then
    '            r = 0
    '        Else
    '            r = Dv.Find(Tag.ToString.TrimEnd)
    '        End If
    '        If r > 0 Then
    '            Text = Dv(r).Item("translated")
    '        Else
    '            Text = Tag
    '        End If
    '        Dim allCtrl As New List(Of Control)
    '        For Each cCtrl As Control In FindControlRecursive(allCtrl, Me)
    '            If IsTranslatable(cCtrl) Then
    '                If TypeOf cCtrl Is DataGrid Then
    '                    _originalText = CaptionCollection.Item(cCtrl.Name)
    '                    r = Dv.Find(_originalText)
    '                    If r > 0 Then
    '                        CType(cCtrl, DataGrid).CaptionText = Dv(r).Item(1)
    '                    Else
    '                        CType(cCtrl, DataGrid).CaptionText = cCtrl.Tag
    '                    End If
    '                ElseIf cCtrl.GetType().ToString() = "System.Windows.Forms.ToolStrip" Then
    '                    Dim subMenuName = ""
    '                    Dim toolStrip As ToolStrip = cCtrl
    '                    Dim cToolStrip As ToolStrip
    '                    cToolStrip = cCtrl
    '                    For Each obj As Object In cToolStrip.Items
    '                        ' ReSharper disable once VBPossibleMistakenCallToGetType.2
    '                        'If obj.GetType().ToString() = "System.Windows.Forms.ToolStripButton" Then
    '                        Try
    '                            _originalText = CaptionCollection.Item(cToolStrip.Name + "." + obj.Name)
    '                            r = Dv.Find(_originalText)
    '                            If r > 0 Then
    '                                obj.Text = Dv(r).Item("translatedCaption")
    '                            Else
    '                                obj.Text = obj.Tag
    '                            End If
    '                        Catch ex As Exception

    '                        End Try
    '                    Next
    '                ElseIf cCtrl.GetType().ToString() = "System.Windows.Forms.MenuStrip" Then
    '                    Dim subMenuName = ""
    '                    Dim menuStrip As MenuStrip = cCtrl
    '                    TranslateMenuStripItems(menuStrip.Items, subMenuName)

    '                Else
    '                    _originalText = CaptionCollection.Item(cCtrl.Name)
    '                    r = Dv.Find(_originalText)
    '                    If r > 0 Then
    '                        cCtrl.Text = Dv(r).Item("translatedCaption")
    '                    Else
    '                        cCtrl.Text = cCtrl.Tag
    '                    End If
    '                End If
    '            End If
    '        Next
    '    End If
    '    If IsRightToLeft(targetLanguage) Then
    '        ChangeToRtlDisplay()
    '    Else
    '        ChangeToLtrDisplay()
    '    End If
    '    Refresh()
    'End Sub

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

    Private Sub UserOriginalCaptions()

        Dim allCtrl As New List(Of Control)
        For Each cCtrl As Control In FindControlRecursive(allCtrl, Me)
            If IsTranslatable(cCtrl) Then
                If TypeOf cCtrl Is DataGrid Then
                    CType(cCtrl, DataGrid).CaptionText = cCtrl.Tag
                ElseIf TypeOf cCtrl Is ToolStrip Then
                    Dim c As ToolStrip
                    c = cCtrl
                    For Each obj As Object In c.Items
                        ' ReSharper disable once VBPossibleMistakenCallToGetType.2
                        obj.Text = obj.Tag(0)
                        obj.ToolTipText = obj.Tag(1)
                        Dim button As ToolStripButton = TryCast(obj, ToolStripButton)
                        If (button IsNot Nothing) Then
                            button.Image = button.Image.Tag
                        End If
                    Next
                ElseIf cCtrl.GetType().ToString() = "System.Windows.Forms.MenuStrip" Then
                    Dim subMenuName = ""
                    Dim menuStrip As MenuStrip = cCtrl
                    UseOriginalMenuStripCaptions(menuStrip.Items, subMenuName)
                Else
                    cCtrl.Text = cCtrl.Tag
                End If
            End If
        Next
    End Sub

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

End Class