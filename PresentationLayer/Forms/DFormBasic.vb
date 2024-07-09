Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports System.Windows.Forms
Imports AATM.PresentationLayer.Views
Imports System.Globalization
Imports AATM.Libraries
Imports System.ComponentModel

Public Class DFormBasic
    Implements IViewNew

    Public Dv As DataView
    Private _debugSwitch As Byte = 0
    Private _firstLoadSwitch As Integer = 0
    Private _originalText As String
    Private _systemViewIdNo As Int32
    Private _textDisplayLanguage As String
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        KeyPreview = False
    End Sub

    Public Event AfterTranslateForm()

    Public Event ArabicDisplayRequested() Implements IViewNew.ArabicDisplayRequested

    Public Event FormLoaded(sender As Object, captionCollection As Collection) Implements IViewNew.FormLoaded

    Public Event FormTranslating(sender As Object) Implements IViewNew.FormTranslating

    Public Event OrigLanguageDisplayRequested() Implements IViewNew.OrigLanguageDisplayRequested
    Public Property CaptionCollection As New Collection Implements IViewNew.CaptionCollection
    Public Property FormCulture As CultureInfo Implements IViewNew.FormCulture
    Public ReadOnly Property FormName As String Implements IViewNew.FormName
        Get
            Return Name.Trim()
        End Get
    End Property

    Public Property RightToLeftDisplay As String Implements IViewNew.RightToLeftDisplay
    Public Property ViewDisplayName As String Implements IViewNew.ViewDisplayName

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

    Protected Sub RunTranslator(ByVal nSystemViewIdNo)
        Dim frm As New TranslationTableManager()
        frm.SystemViewIdNoToTranslate = nSystemViewIdNo
        frm.AppDataDAC = AppDataDac
        frm.TranslatorDAC = TranslatorDac
        frm.Show()
    End Sub

    Protected Sub SwitchDisplayToOriginalLanguage()
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            Dim cultureCode As String = GlobalVariables.DefaultUnmirroredCultureInfoStr
            If IsCultureOk(cultureCode) Then
                FormCulture = New CultureInfo(cultureCode, False)
                RightToLeftDisplay = False
                RightToLeft = RightToLeft.No
                btnArabic.Visible = True
                btnOriginal.Visible = False
                btnArabic.Enabled = True
                btnOriginal.Enabled = False
                RaiseEvent FormTranslating(Me)
                RaiseEvent OrigLanguageDisplayRequested()
            Else
                MessageBox.Show("Invalid DefaultMirroredCultureInfoStr " & cultureCode & ".")
            End If
        End If
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

    Private Sub DFormBasic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _firstLoadSwitch = 0 Then
            RaiseEvent FormLoaded(sender, CaptionCollection)
            _firstLoadSwitch = 1
        End If
        'If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
        '    TextDisplayLanguage = CultureInfo.CurrentCulture.Name
        'End If
        'RaiseEvent BeforeLoad()
    End Sub

    Private Sub DFormBasic_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        FormCulture = GlobalVariables.AppCultureInfo
        If FormCulture.TextInfo.IsRightToLeft Then
            RightToLeftDisplay = True
            RightToLeft = RightToLeft.Yes
        Else
            RightToLeftDisplay = False
            RightToLeft = RightToLeft.No
        End If
        If RightToLeftDisplay Then
            btnArabic.Visible = False
            btnOriginal.Visible = True
        Else
            btnArabic.Visible = True
            btnOriginal.Visible = False
        End If
        RaiseEvent FormTranslating(Me)
    End Sub

    Private Sub SwitchDisplayToArabicLanguage()
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            Dim cultureCode = GlobalVariables.DefaultMirroredCultureInfoStr
            If IsCultureOk(cultureCode) AndAlso IsRightToLeft(cultureCode) Then
                btnArabic.Visible = False
                btnOriginal.Visible = True
                btnArabic.Enabled = False
                btnOriginal.Enabled = True
                RightToLeftDisplay = True
                Dim curFormCulture As CultureInfo
                curFormCulture = New CultureInfo(cultureCode, False)
                FormCulture = curFormCulture
                RightToLeft = RightToLeft.Yes
                TranslateForm(Me)
                RaiseEvent ArabicDisplayRequested()
            Else
                MessageBox.Show("Invalid DefaultMirroredCultureInfoStr " & cultureCode & ".")
            End If
        End If
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

End Class
