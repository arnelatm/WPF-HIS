Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.Libraries.Translations
Imports AATM.PresentationLayer.Views

Public Class BfMain
    Implements IView

    Dim _originalText As String

    '    Dim _menuLevel As String = ""
    Private _formCultureInfo As CultureInfo

    Private _formLanguage As String
    Private _textDisplayLanguage As String
    Protected CaptionCollection As New Collection
    Protected FormIdNo As Int16
    Protected InitializationMode As Boolean = True
    Protected LtrCultureInfoStr = GlobalVariables.DefaultUnmirroredCultureInfoStr
    Protected RtlCultureInfoStr = GlobalVariables.DefaultMirroredCultureInfoStr
    Protected DefaultMirroredLanguageIdNo As Int16
    Protected Shared ResetEvent As AutoResetEvent = New AutoResetEvent(False)
    Public Dv As DataView
    Public MyErrorProvider As New ErrorProviderExtended

    Public Event AfterTranslateForm()

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        KeyPreview = True
        If Not DesignMode Then
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
        Me.DoubleBuffered = True
        Dim dac As New Dac
        Dim cmd As String
        cmd = "Select IdNo from Languages where cultureInfoCode = '" + GlobalVariables.DefaultMirroredCultureInfoStr + "'"
    End Sub

    Public Sub New(ByVal transDac As Dac, ByVal appDac As Dac)
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()
        If Not DesignMode Then
            TranslatorDAC = transDac
            AppDataDAC = appDac
        End If

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Event TextDisplayLanguageChanged()

    Public Property CancelClose As Boolean

    'Public Shadows Event Load(sender As Object, e As EventArgs)
    Public Property PresenterObj As Object

    Public Property SecurityPresenterObj As Object

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

    Public Sub ProcessMenuItems(ByVal menuItems As Menu.MenuItemCollection, ByVal mLevel As String)
        Dim i As Int16
        For i = 0 To menuItems.Count - 1
            Dim mi As MenuItem = menuItems(i)
            Dim localMLevel As String = mLevel + i.ToString
            _originalText = CaptionCollection.Item(localMLevel)
            Dim r As Integer = Dv.Find(_originalText)
            If r >= 0 Then mi.Text = Dv(r).Item("translated") _
                   Else mi.Text = _originalText
            If mi.MenuItems.Count > 0 Then _
            ProcessMenuItems(mi.MenuItems, localMLevel)
        Next
    End Sub

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
        cmd = "SELECT TOP 1 LanguageIdNo,COUNT(LanguageIdNo) AS value_occurrence FROM TranslatedCaptions_View where RTrim(LanguageCode2) = '" + languageBaseCode + "' " +
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
        cmd = "SELECT TranslatedCaptions from TranslatedMessages_View where Caption = '" + RTrim(message) + "' and RTrim(LanguageCode2) = '" + languageBaseCode + "' "
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
            targetLanguageIdNo = 0
        Else
            cmd = "Select Caption, translated from formItemsOriginal_view where LanguageIdNo = " + targetLanguageIdNo.ToString() + " and formIdNo = " + FormIdNo.ToString()
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
                Text = Dv(r).Item("translated")
            Else
                Text = Tag
            End If
            Dim allCtrl As New List(Of Control)
            For Each cCtrl As Control In FindControlRecursive(allCtrl, Me)
                If IsTranslatable(cCtrl) Then
                    If TypeOf cCtrl Is DataGrid Then
                        _originalText = CaptionCollection.Item(cCtrl.Name)
                        r = Dv.Find(_originalText)
                        If r >= 0 Then
                            CType(cCtrl, DataGrid).CaptionText = Dv(r).Item(1)
                        Else
                            CType(cCtrl, DataGrid).CaptionText = cCtrl.Tag
                        End If
                    ElseIf TypeOf cCtrl Is ToolStrip Then
                        'Dim c As ToolStrip
                        'c = cCtrl
                        TranslateToolStripItems(cCtrl)
                    ElseIf TypeOf cCtrl Is MenuStrip Then
                        Dim subMenuName = ""
                        Dim menuStrip As MenuStrip = cCtrl
                        TranslateMenuStripItems(menuStrip.Items, subMenuName)
                    ElseIf TypeOf cCtrl Is CTreeView Or TypeOf cCtrl Is TreeView Then
                        Dim cT = CType(cCtrl, TreeView)
                        cT.ExpandAll()
                        cT.RightToLeftLayout = GlobalVariables.RightToLeftLayout
                        cT.RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
                    Else
                        If TypeOf cCtrl Is CButton Then
                            TranslateButton(cCtrl)
                        ElseIf TypeOf cCtrl Is CTabControl Then
                            Dim tc = CType(cCtrl, CTabControl)
                            tc.RightToLeftLayout = GlobalVariables.RightToLeftLayout
                            tc.RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
                        End If
                        _originalText = CaptionCollection.Item(cCtrl.Name)
                        r = Dv.Find(_originalText)
                        If r >= 0 Then
                            cCtrl.Text = Dv(r).Item("translated")
                        Else
                            cCtrl.Text = cCtrl.Tag
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub TranslateToolStripItems(ByRef cToolStrip As ToolStrip)
        Dim r As Integer
        Dim originalText As String
        Dim OriginalToolTipText as String
        For Each obj As Object In cToolStrip.Items
            Try
                originalText = CaptionCollection.Item(cToolStrip.Name + "." + obj.Name + ".Text")
                r = Dv.Find(originalText)
                If r > 0 Then
                    obj.Text = Dv(r).Item("translated")
                Else
                    obj.Text = obj.Tag(0)
                End If
                originalToolTipText = CaptionCollection.Item(cToolStrip.Name + "." + obj.Name + ".ToolTipText")
                r = Dv.Find(originalToolTipText)
                If r > 0 Then
                    obj.ToolTipText = Dv(r).Item("translated")
                Else
                    obj.ToolTipText = obj.Tag(1)
                End If
                If TypeOf obj Is ToolStripButton Then
                    TranslateToolStripButton(obj)
                ElseIf TypeOf obj Is TextBox Then
                    Dim c = CType(obj, TextBox)
                    If GlobalVariables.RightToLeftLayout Then
                        c.Text = Messaging.TranslateCaption(c.Text)
                        c.RightToLeft = RightToLeft.Yes
                    Else
                        c.RightToLeft = RightToLeft.No
                    End If
                End If
            Catch ex As Exception

            End Try
        Next
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

    Private Sub TranslateToolStripButton(cButton As ToolStripButton)
        Dim cResourceName = cButton.Name.ToLower()
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            Dim cCurrentCulture = CultureInfo.CurrentCulture.Name.Replace("-", "_")
            cResourceName = cResourceName + "_" + cCurrentCulture.ToLower()
            'cButton.ToolTipText = Messaging.TranslateCaption(cButton.Tag(1))
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
        cmd = "SELECT count(*) FROM TranslatedCaptions_View WHERE CultureInfoCode = '" _
              + desiredLanguage.TrimEnd + "'"
        Dim howMany As Integer = TranslatorDAC.ExecScalar(Of Integer)(cmd)
        If howMany > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Shared Sub SetControlMaskability(ByRef cCtrl As Control, controlViewable As Boolean)
        ' if Viewable is false, Don't show the controls content by masking content with '*' asterisk
        If Not controlViewable Then
            SetPropertyValue(cCtrl, "Viewable", controlViewable)
            'SetPropertyValue(cCtrl, "PasswordChar", Convert.ToChar("*"))
        End If
    End Sub

    Private Shared Sub SetControlSelectability(ByRef cCtrl As Control, controlSelectable As Boolean)
        ' if Selectable is false, Don't let the user select the data so set enabled to False
        If Not controlSelectable Then
            SetPropertyValue(cCtrl, "Selectable", controlSelectable)
        End If
    End Sub

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
        Dim securityIdNo As String
        'Dim service As New Service
        If GlobalVariables.IsUserLoggedIn Then
            securityIdNo = SecurityPresenterObj.GetControlSecurityIdNo(controlSecurityKey)
            If securityIdNo IsNot Nothing Then
                'securityIdNo = Service.GetRecordFieldWithKey(controlSecurityKey, "SecurityObject", "SecurityObjectName", "IdNo")
                controlSecurityValues = SecurityPresenterObj.GetUserSecurity(Convert.ToInt32(securityIdNo),
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
        If Not DesignMode Then
            'Dim ds As New DataSet
            'ds = TranslatorDAC.ReturnDs(
            '     "Select lang from languages")
            'cmbLanguagePicker.Items.Clear()
            'For Each dr As DataRow In ds.Tables(0).Rows
            '    cmbLanguagePicker.Items.Add(dr("lang"))
            'Next
            'ds = Nothing
            CaptionCollection = StoreCaptions1.StoreCaptions(Me)
            Dim cmd As String
            'Dim dac As New Dac
            'dac = TranslatorDAC
            DefaultMirroredLanguageIdNo = TranslatorDAC.DefaultMirroredLanguageIdNo
            cmd = "SELECT IdNo FROM SystemForms where FormName ='" + Name + "'"
            FormIdNo = TranslatorDAC.ExecScalar(Of Int16)(cmd)
            TranslateForm()
        End If

    End Sub

    Private Function GetControlSecurityIdNo(ByRef controlSecurityKey As String) As Int64
        Return SecurityPresenterObj.GetRecordFieldWithKey(controlSecurityKey, "SecurityObject", "SecurityObjectName", "IDNo")
    End Function

    'Private Sub BfForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    '    Dim allControls As New List(Of Control)
    '    For Each cCtrl As Control In FindControlRecursive(allControls, Me)
    '        SetControlSecurity(cCtrl)
    '    Next
    'End Sub

    Public Sub SetControlSecurity(ByRef cCtrl As Control)
        Dim controlSecurityKey As String
        If cCtrl.GetType().ToString() = "System.Windows.Forms.ToolStrip" Then
            Dim subMenuName = MenuFormName + "." + cCtrl.Name.TrimEnd()
            Dim toolStrip As ToolStrip = cCtrl
            SetToolStripItems(toolStrip.Items, subMenuName)
        ElseIf cCtrl.GetType().ToString() = "System.Windows.Forms.MenuStrip" Then
            Dim subMenuName = MenuFormName + "." + cCtrl.Name.TrimEnd()
            Dim menuStrip As MenuStrip = cCtrl
            SetMenuStripItems(menuStrip.Items, subMenuName)
        Else
            controlSecurityKey = GetControlSecurityKey(cCtrl)
            If controlSecurityKey Is Nothing Or controlSecurityKey = "" Then
                ' nothing to do just leave the default values
            Else
                Dim controlSecurityValues As ArrayList
                Dim isEditable As Boolean
                Dim isSelectable As Boolean
                Dim isVisible As Boolean
                Dim isViewable As Boolean
                controlSecurityValues = GetControlSecurityValues(controlSecurityKey)
                If controlSecurityValues.Count > 0 Then
                    ' Visible property stored in first element of the array
                    isVisible = controlSecurityValues(0)
                    ' Selectable property stored in second element of the array
                    isSelectable = controlSecurityValues(1)
                    ' Viewable property stored in third element of the array
                    isViewable = controlSecurityValues(2)
                    ' Editable property stored in fourth element of the array
                    isEditable = controlSecurityValues(3)
                Else
                    isVisible = False
                    isSelectable = False
                    isEditable = False
                    isViewable = False
                End If
                SetControlVisibility(cCtrl, isVisible)
                SetControlMaskability(cCtrl, isViewable)
                SetControlEditability(cCtrl, isEditable)
                SetControlSelectability(cCtrl, isSelectable)
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
        Dim controlSecurityObjectIdNo As Int32
        controlSecurityObjectIdNo = SecurityPresenterObj.GetControlSecurityIdNo(controlSecurityKey)
        Return SecurityPresenterObj.GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo)
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
            For Each obj As Object In dropDownItems
                Dim subMenu = TryCast(obj, ToolStripMenuItem)
                If subMenu IsNot Nothing Then
                    ApplyMenuSecurity(obj, subMenuName)
                    If subMenu.HasDropDownItems Then
                        subMenuName = parentMenu + "." + Mid(obj.Name, 18)
                        'ApplyMenuSecurity(obj, subMenuName)
                        SetMenuStripItems(subMenu.DropDownItems, subMenuName)
                    Else
                        'ApplyMenuSecurity(obj, subMenuName)
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
                    If GlobalVariables.IsUserLoggedIn Then
                        Dim controlSecurityKey = subMenuName + "." + Mid(toolStripButton.Name, 16).TrimEnd()
                        Dim controlSecurityValues As ArrayList
                        Dim isSelectable As Boolean
                        Dim isVisible As Boolean
                        'Dim service As New Service
                        Dim securityIdNo As String = SecurityPresenterObj.GetControlSecurityIdNo(controlSecurityKey)

                        If securityIdNo IsNot Nothing Then
                            If GlobalVariables.SecurityGroupIdNo <> 0 Then
                                controlSecurityValues = SecurityPresenterObj.GetUserSecurity(securityIdNo,
                                                                                GlobalVariables.SecurityGroupIdNo)
                                If controlSecurityValues.Count > 0 Then
                                    ' Visible property stored in first element of the array
                                    isVisible = controlSecurityValues(0)
                                    ' Selectable property stored in second element of the array
                                    isSelectable = controlSecurityValues(1)
                                    ' Editable property stored in third element of the array
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, $"SetToolStripItems", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub TranslateMenuStripItems(dropDownItems As ToolStripItemCollection, subMenuName As String)
        Try
            For Each obj As Object In dropDownItems
                Dim subMenu = TryCast(obj, ToolStripMenuItem)
                If subMenu IsNot Nothing Then
                    Dim r As Int16 = 0
                    r = Dv.Find(obj.Tag)
                    If r > 0 Then
                        obj.Text = Dv(r).Item("translated")
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
    '            cmd = "select translated from formItemsOriginal_view where LanguageIdNo = " + desiredLanguageIdNo.ToString() + " and formIdNo = " + FormIdNo.ToString()
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
    '                                obj.Text = Dv(r).Item("translated")
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
    '                        cCtrl.Text = Dv(r).Item("translated")
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
                ElseIf cCtrl.GetType().ToString() = "System.Windows.Forms.ToolStrip" Then
                    Dim c As ToolStrip
                    c = cCtrl
                    For Each obj As Object In c.Items
                        ' ReSharper disable once VBPossibleMistakenCallToGetType.2
                        If obj.GetType().ToString() = "System.Windows.Forms.ToolStripButton" Then
                            Try
                                If Not String.IsNullOrEmpty(obj.Tag) Then
                                    obj.Text = obj.Tag
                                End If
                            Catch ex As Exception

                            End Try
                        Else
                            Try
                                If Not String.IsNullOrEmpty(obj.Tag) Then
                                    obj.Text = obj.Tag
                                End If
                            Catch ex As Exception

                            End Try
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

End Class