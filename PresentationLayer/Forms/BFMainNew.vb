Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views

Public Class BfMainNew
    Implements IViewNew

    Public Dv As DataView
    Public MyErrorProvider As New ErrorProviderExtended
    Public Presenter As Object
    Protected Shared ResetEvent As AutoResetEvent = New AutoResetEvent(False)
    Protected _addSecurityObject As Boolean = False
    Protected CaptionCollection As New Collection

    Protected DefaultMirroredLanguageIdNo As Int16
    Protected FormShown As Boolean = False
    Protected InitializationMode As Boolean = True
    Protected LtrCultureInfoStr = GlobalVariables.DefaultUnmirroredCultureInfoStr
    Protected RtlCultureInfoStr = GlobalVariables.DefaultMirroredCultureInfoStr
    Private _firstLoadSwitch As Int32 = 0
    Private _formCulture As CultureInfo
    Dim _originalText As String

    Private _parentIdNo As Int32 = 0

    Private _parentSecurityObjectIdNo As Int32

    Private _sw As Int16 = 0

    Private _systemViewIdNo As Int32

    '    Dim _menuLevel As String = " "
    Private _textDisplayLanguage As String

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            TextDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name
        End If
        InitializationMode = False
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Event FormLoaded()

    Public Event FormTranslated()
    Public Event TextDisplayLanguageChanged()

    Public Property CancelClose As Boolean

    Public Property DataFilter As String Implements IViewNew.DataFilter
    Public Property Errors As List(Of String) Implements IViewNew.Errors
    Public Property HideNavigatorButtons As Boolean

    Public Property IgnoreTextBoxNumParserMessage As Boolean

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
            Return GetSystemViewIdNo(TranslatorDAC, ViewDisplayName, Name)
        End Get
        Set(value As Short)
            _systemViewIdNo = value
        End Set
    End Property

    Public Shared Sub EnableDoubleBuff(ByVal cont As Control)
        Dim demoProp As Reflection.PropertyInfo = GetType(Control).GetProperty("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        demoProp.SetValue(cont, True, Nothing)
    End Sub

    Public Sub ForceEndEditForAllGridControls()
        Dim allControls As New List(Of Control)
        FindControlRecursive(allControls, Me)
        For Each cCtrl As Control In allControls
            If TypeOf cCtrl Is DataGridView Then
                Dim cGrid As DataGridView = cCtrl
                cGrid.EndEdit()
            End If
        Next
    End Sub

    Public Sub ForceLooseFocusOnCurrentControl()
        Dim currentActiveControl As Control = ActiveControl
        If currentActiveControl IsNot Nothing Then
            SelectNextControl(currentActiveControl, True, True, True, True)
        End If
        Refresh()
        If currentActiveControl IsNot Nothing AndAlso currentActiveControl.Visible AndAlso currentActiveControl.Enabled Then
            Try
                ActiveControl = currentActiveControl
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub GetNSaveCaptions() 'control As Control)
        DoubleBuffered = True
        If GlobalVariables.TranslationMode Then
            CaptionCollection = StoreCaptions1.StoreTranslation(Me)
            StoreCaptions1.SaveControlsOriginalText(Me)
            DefaultMirroredLanguageIdNo = TranslatorDAC.DefaultMirroredLanguageIdNo
            If ViewDisplayName Is Nothing Or ViewDisplayName = "" Then
                ViewDisplayName = Name
            End If
        End If
    End Sub

    Function IsTranslatable(ByRef ctrl As Control) As Boolean
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
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Sub RunSubForm(Of TF, TP)(data As Object, subFormParent As Form)
        Dim childForm = Activator.CreateInstance(GetType(TF), data)
        Activator.CreateInstance(GetType(TP), {childForm})
        Dim pType As Type = GetType(TP)
        childForm.Presenter = Activator.CreateInstance(pType, {childForm})
        childForm.Show()
        childForm.MdiParent = subFormParent
    End Sub

    Public Sub RunSubForm(Of TV, TP)()
        Dim childMdiForm = Activator.CreateInstance(GetType(TV))
        Dim pType As Type = GetType(TP)
        childMdiForm.Presenter = Activator.CreateInstance(pType, {childMdiForm})
        childMdiForm.MdiParent = Me
        childMdiForm.Show()
    End Sub

    Public Sub RunSubForm(Of TF, TP)(subFormParent As Form)
        Dim childForm = Activator.CreateInstance(GetType(TF))
        Activator.CreateInstance(GetType(TP), {childForm})
        Dim pType As Type = GetType(TP)
        childForm.Presenter = Activator.CreateInstance(pType, {childForm})
        childForm.Show()
        childForm.MdiParent = subFormParent
    End Sub

    Public Sub RunSubForm(Of TF, TP, TX)(ByRef subFormParent As Form, param As TX)
        Dim childMdiForm = Activator.CreateInstance(GetType(TF), param)
        childMdiForm.MdiParent = subFormParent
        Dim pType As Type = GetType(TP)
        childMdiForm.Presenter = Activator.CreateInstance(pType, {childMdiForm, param})
        childMdiForm.Show()
    End Sub

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

    Public Sub TranslateForm()
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            Dim settings As New ControlSettingsSaver
            Dim allCtrl As New List(Of Control)
            allCtrl = FindControlRecursive(allCtrl, Me)
            settings.SaveSetting(Me)
            ' form location is being changed when Resetting RightToLeftLayout so need to save values
            ' to restore form with the same size and location
            DoubleBuffered = True
            TranslateCaptions(allCtrl, TextDisplayLanguage)
            SetControlLayout(allCtrl)
            settings.RestoreSetting(Me)
            RaiseEvent FormTranslated()
        End If
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
            'If TypeOf cCtrl Is CtDataGridView Or TypeOf cCtrl Is CtDataGridView Then
            '    Dim cControl As CtDataGridView = DirectCast(cCtrl, CtDataGridView)
            '    cControl.MakeGridSearchable()
            'End If
        Next
    End Sub

    Protected Sub RunTranslator(ByVal nSystemViewIdNo)
        Dim frm As New TranslationTableManager()
        frm.SystemViewIdNoToTranslate = nSystemViewIdNo
        frm.AppDataDAC = AppDataDAC
        frm.TranslatorDAC = TranslatorDAC
        frm.Show()
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
    Protected Overridable Sub SwitchUiLanguage(originalUi As Boolean)
        Visible = False
        Dim sw As Integer = 0
        If originalUi Then
            If TextDisplayLanguage <> GlobalVariables.DefaultUnmirroredCultureInfoStr Then
                TextDisplayLanguage = GlobalVariables.DefaultUnmirroredCultureInfoStr
                sw = 1
            End If
            GlobalVariables.RightToLeftLayout = True
            RightToLeft = RightToLeft.No
        Else
            If TextDisplayLanguage <> GlobalVariables.DefaultMirroredCultureInfoStr Then
                TextDisplayLanguage = GlobalVariables.DefaultMirroredCultureInfoStr
                sw = 1
            End If
            GlobalVariables.RightToLeftLayout = True
            RightToLeft = RightToLeft.Yes
        End If
        TranslateForm()
        If sw = 1 Then
            CultureInfo.CurrentCulture = New CultureInfo(TextDisplayLanguage, False)
        End If
        Visible = True
    End Sub

    Protected Sub TranslateCaptions(ByRef allCtrl As List(Of Control), ByVal desiredLanguage As String, Optional ByVal allowFallBack As Boolean = True)
        Try
            If (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
                ' continue
            Else
                Dim targetLanguageIdNo As Short = GetTargetLanguageIdNo(TranslatorDAC, desiredLanguage, allowFallBack)
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
        Dim translations As DataSet = GetTranslations(TranslatorDAC, targetLanguageIdNo, ViewDisplayName, Name)
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

    Private Sub BFMainNew_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            If _firstLoadSwitch = 0 Then
                GetNSaveCaptions()
                _firstLoadSwitch = 1
            End If
            If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
                TextDisplayLanguage = CultureInfo.CurrentCulture.Name
            End If
            RaiseEvent FormLoaded()
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
        Return Presenter.GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo, GlobalVariables.UserIdNo)
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

    Private Sub OnCFormEntryNewShown() Handles MyBase.Shown
        'SuspendDrawing()
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            SwitchUiLanguage(False)
        Else
            SwitchUiLanguage(True)
        End If
        Me.Activate()
        Dim allCtrl As New List(Of Control)
        allCtrl = FindControlRecursive(allCtrl, Me)
        'ResumeDrawing()
        FormShown = True
    End Sub
    Private Sub SetControlEditability(ByRef cCtrl As Control, ByRef editable As Boolean)
        ' if Editable is False, make the control readonly property so that it can't be edited
        If Not editable Then
            SetPropertyValue(cCtrl, "DisplayOnly", True)
        End If
    End Sub

    Private Function SetControlSecurityValue(securityIdNo As Integer) As ArrayList
        Dim controlSecurityValues As ArrayList
        controlSecurityValues = Presenter.GetUserSecurity(Convert.ToInt16(securityIdNo), GlobalVariables.SecurityGroupIdNo, GlobalVariables.UserIdNo)
        Return controlSecurityValues
    End Function

    Private Sub SetMenuSecurity(cControl As Object, controlSecurityKey As String)
        If UserIsASuperAdmin() Then
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
                            controlSecurityValues = Presenter.GetUserSecurity(securityIdNo, GlobalVariables.SecurityGroupIdNo, GlobalVariables.UserIdNo)
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
End Class
