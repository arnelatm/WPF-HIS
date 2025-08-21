Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data.Common
Imports System.Drawing
Imports System.Globalization
Imports System.Reflection.Emit
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

    '    Dim _menuLevel As String = " "
    Private _textDisplayLanguage As String
    ' Global translation cache for all forms/views/languages
    Protected _addSecurityObject As Boolean = False
    Private _parentSecurityObjectIdNo As Int32
    Private _sw As Int16 = 0
    Private _parentIdNo As Int32 = 0
    Private _formCulture As CultureInfo
    Private _systemViewIdNo As Int32
    Private _firstLoadSwitch As Int32 = 0

    'Private _myPresenter As UserPresenter
    Protected CaptionCollection As New Collection

    Protected InitializationMode As Boolean = True
    Protected LtrCultureInfoStr = GlobalVariables.DefaultUnmirroredCultureInfoStr
    Protected RtlCultureInfoStr = GlobalVariables.DefaultMirroredCultureInfoStr
    Protected DefaultMirroredLanguageIdNo As Int16
    Protected Shared ResetEvent As AutoResetEvent = New AutoResetEvent(False)
    Protected FormShown As Boolean = False
    Public Dv As DataView
    Public MyErrorProvider As New ErrorProviderExtended
    Public Ea As EventAggregator
    Public Presenter As Object

    Public Event AfterTranslateForm()

    Public Event BeforeLoad()

    ' Add these Win32 declarations at the top of your class
    Private Const WM_SETREDRAW As Integer = &HB
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Boolean, lParam As Integer) As IntPtr
    End Function

    ' Helper to suspend painting
    Private Sub SuspendDrawing(ctrl As Control)
        If ctrl.IsHandleCreated Then
            SendMessage(ctrl.Handle, WM_SETREDRAW, False, 0)
        End If
    End Sub

    ' Helper to resume painting
    Private Sub ResumeDrawing(ctrl As Control)
        If ctrl.IsHandleCreated Then
            SendMessage(ctrl.Handle, WM_SETREDRAW, True, 0)
            ctrl.Refresh()
        End If
    End Sub

    Private Sub EnableDataGridViewDoubleBuffering(dgv As DataGridView)
        Dim dgvType = dgv.GetType()
        Dim pi = dgvType.GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
        If pi IsNot Nothing Then
            pi.SetValue(dgv, True, Nothing)
        End If
    End Sub

    Private Sub EnableTreeViewDoubleBuffering(tv As TreeView)
        Dim tvType = tv.GetType()
        Dim pi = tvType.GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
        If pi IsNot Nothing Then
            pi.SetValue(tv, True, Nothing)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Ea = New EventAggregator
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            TextDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name
        End If
        InitializationMode = False
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal transDac As Dac, ByVal appDac As Dac)
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()
        Ea = New EventAggregator
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            TranslatorDAC = transDac
            AppDataDAC = appDac
        End If

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Event TextDisplayLanguageChanged()

    Public Property CancelClose As Boolean

    Public Property Errors As List(Of String) Implements IView.Errors
    Public Property DataFilter As String Implements IView.DataFilter

    Protected Property TextDisplayLanguage As String
        Get
            Return _textDisplayLanguage
        End Get
        Set(value As String)
            If value <> _textDisplayLanguage Then
                InvalidateTranslationCache() ' Invalidate cache when language changes
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
        Get
            Return GetSystemViewIdNo()
        End Get
        Set(value As Short)
            _systemViewIdNo = value
        End Set
    End Property

    'Private Function BuildTranslationDictionary()
    '    ' Build the translation dictionary once
    '    Dim translationDict As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
    '    If Dv IsNot Nothing AndAlso Dv.Table IsNot Nothing Then
    '        Dim captionCol As String = ""
    '        Dim translatedCol As String = ""
    '        If Dv.Table.Columns.Contains("Caption") Then captionCol = "Caption"
    '        If Dv.Table.Columns.Contains("TranslatedCaption") Then translatedCol = "TranslatedCaption"
    '        If captionCol = "" OrElse translatedCol = "" Then
    '            ' Optionally log: missing columns
    '            Return Nothing
    '        End If
    '        For Each row As DataRowView In Dv
    '            Dim key = Convert.ToString(row(captionCol))
    '            Dim value = Convert.ToString(row(translatedCol))
    '            If Not translationDict.ContainsKey(key) Then
    '                translationDict.Add(key, value)
    '            End If
    '        Next
    '    End If
    '    Return translationDict
    'End Function

    Private Function GetTranslationDictionary(languageIdNo As Integer) As Dictionary(Of String, String)
        Dim currentLanguage = TextDisplayLanguage
        Dim currentViewId = GetSystemViewIdNo()
        ' Use the utility (pass TranslatorDAC as the third argument)
        Return TranslationUtility.GetTranslationDictionary(currentLanguage, currentViewId, TranslatorDAC)
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
               TypeOf ctrl Is Windows.Forms.Label OrElse
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
        FlickerFreeTranslateForm()
        If sw = 1 Then
            CultureInfo.CurrentCulture = New CultureInfo(TextDisplayLanguage, False)
            If Ea IsNot Nothing Then
                Ea.PublishEvent(New LanguageChanged(Me))
            End If
        End If
        Visible = True
    End Sub

    ' Flicker-free translation routine
    Private Sub FlickerFreeTranslateForm()
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            Dim settings As New SettingsSaver
            Dim allControls As List(Of Control) = TranslationUtility.GetAllControls(Me)
            settings.SaveSetting(Me)
            Me.DoubleBuffered = True

            ' Enable double buffering for all containers
            For Each ctrl As Control In allControls
                If TypeOf ctrl Is Panel OrElse TypeOf ctrl Is TabControl OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is UserControl Then
                    EnableDoubleBuff(ctrl)
                ElseIf TypeOf ctrl Is DataGridView Then
                    EnableDataGridViewDoubleBuffering(ctrl)
                ElseIf TypeOf ctrl Is TreeView Then
                    EnableTreeViewDoubleBuffering(ctrl)
                ElseIf TypeOf ctrl Is FlowLayoutPanel Then
                    EnableDoubleBuff(ctrl)
                End If
            Next

            Me.Visible = False
            Me.SuspendLayout()
            SuspendAllDrawing(Me)
            Try
                TranslateCaptions(allControls, TextDisplayLanguage)
                SetControlLayout(allControls)
                SetGlobalFont(Me, New Font("Tahoma", 9))
                settings.RestoreSetting(Me)
            Finally
                ResumeAllDrawing(Me)
                Me.ResumeLayout(False)
                Me.PerformLayout()
                Me.Visible = True
            End Try

            If GlobalVariables.TranslationMode Then
                RaiseEvent AfterTranslateForm()
            End If
        End If
    End Sub

    ' Recursively suspend drawing for all controls
    Private Sub SuspendAllDrawing(ctrl As Control)
        SuspendDrawing(ctrl)
        For Each child As Control In ctrl.Controls
            SuspendAllDrawing(child)
        Next
    End Sub

    ' Recursively resume drawing for all controls
    Private Sub ResumeAllDrawing(ctrl As Control)
        ResumeDrawing(ctrl)
        For Each child As Control In ctrl.Controls
            ResumeAllDrawing(child)
        Next
    End Sub

    Public Sub TranslateForm()
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            Dim settings As New SettingsSaver
            Dim allControls As List(Of Control) = TranslationUtility.GetAllControls(Me)
            settings.SaveSetting(Me)
            ' If RightToLeftLayout is True, then the form location is being changed when Resetting RightToLeftLayout
            ' form location is being changed when Resetting RightToLeftLayout so need to save values
            ' to restore form with the same size and location
            DoubleBuffered = True
            Me.SuspendLayout()
            Try
                TranslateCaptions(allControls, TextDisplayLanguage)
                SetControlLayout(allControls)
                settings.RestoreSetting(Me)
            Finally
                Me.ResumeLayout()
            End Try
            If GlobalVariables.TranslationMode Then
                RaiseEvent AfterTranslateForm()
            End If
            SetGlobalFont(Me, New Font("Tahoma", 9)) ' Or another Unicode-supporting font
            settings.RestoreSetting(Me)
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

    Protected Sub TranslateCaptions(ByRef allControls As List(Of Control), ByVal desiredLanguage As String, Optional ByVal allowFallBack As Boolean = True)
        Try
            If (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
                ' continue
            Else
                TargetLanguageIdNo = GetTargetLanguageIdNo(desiredLanguage, allowFallBack)
                If TargetLanguageIdNo = 0 Then
                    UseOriginalCaptions()
                Else
                    TranslateToLanguageIdNo(allControls, TargetLanguageIdNo)
                End If
            End If
        Catch ex As Exception
            Messaging.Show("Error while translating form: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debugger.Break()
        End Try
    End Sub

    Private Function GetTargetLanguageIdNo(desiredLanguage As String, allowFallBack As Boolean) As Short
        Dim cmd As String
        Dim desiredLanguageIdNo As Int16
        Dim fallBackLanguageIdNo As Int16
        Dim fallBackLanguage As String
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            cmd = "Select IdNo from Languages where cultureInfoCode = '" + desiredLanguage + "'"
            desiredLanguageIdNo = TranslatorDAC.ExecScalar(Of Int16)(cmd)
            If desiredLanguageIdNo = 0 Then
                TargetLanguageIdNo = 0
            Else
                If Not TranslationLanguageExist(desiredLanguage) Then
                    If allowFallBack Then
                        fallBackLanguageIdNo = GetFallBackLanguageIdNo(desiredLanguage)
                        cmd = "Select cultureInfoCode from Languages where IdNo = " + fallBackLanguageIdNo.ToString()
                        fallBackLanguage = TranslatorDAC.ExecScalar(Of String)(cmd)
                        If Not NeedToTranslateText(fallBackLanguage) Then
                            TargetLanguageIdNo = 0
                        Else
                            TargetLanguageIdNo = fallBackLanguageIdNo
                        End If
                    Else
                        TargetLanguageIdNo = 0
                    End If
                Else
                    TargetLanguageIdNo = desiredLanguageIdNo
                End If
            End If
        End If
        Return TargetLanguageIdNo
    End Function

    Private Sub InvalidateTranslationCache()
        TranslationUtility.ClearCache()
    End Sub

    Protected Sub TranslateToLanguageIdNo(ByRef allCtrl As List(Of Control), targetLanguageIdNo As Integer)
        Dim translationDict = GetTranslationDictionary(targetLanguageIdNo)

        ' Standard WinForms controls
        For Each lbl As Windows.Forms.Label In allCtrl.OfType(Of Windows.Forms.Label)()
            Dim key = If(lbl.Tag IsNot Nothing, lbl.Tag.ToString(), lbl.Name)
            Dim translated As String = Nothing
            If translationDict.TryGetValue(key, translated) Then
                lbl.Text = translated
            End If
        Next

        For Each btn As Button In allCtrl.OfType(Of Button)()
            Dim key = If(btn.Tag IsNot Nothing, btn.Tag.ToString(), btn.Name)
            Dim translated As String = Nothing
            If translationDict.TryGetValue(key, translated) Then
                btn.Text = translated
            End If
        Next

        For Each chk As CheckBox In allCtrl.OfType(Of CheckBox)()
            Dim key = If(chk.Tag IsNot Nothing, chk.Tag.ToString(), chk.Name)
            Dim translated As String = Nothing
            If translationDict.TryGetValue(key, translated) Then
                chk.Text = translated
            End If
        Next

        For Each rad As RadioButton In allCtrl.OfType(Of RadioButton)()
            Dim key = If(rad.Tag IsNot Nothing, rad.Tag.ToString(), rad.Name)
            Dim translated As String = Nothing
            If translationDict.TryGetValue(key, translated) Then
                rad.Text = translated
            End If
        Next

        For Each tab As TabPage In allCtrl.OfType(Of TabPage)()
            Dim key = If(tab.Tag IsNot Nothing, tab.Tag.ToString(), tab.Name)
            Dim translated As String = Nothing
            If translationDict.TryGetValue(key, translated) Then
                tab.Text = translated
            End If
        Next

        ' Custom controls
        For Each cbtn As CButton In allCtrl.OfType(Of CButton)()
            TranslateButton(cbtn)
            Dim key = If(cbtn.Tag IsNot Nothing, cbtn.Tag.ToString(), cbtn.Name)
            Dim translated As String = Nothing
            If translationDict.TryGetValue(key, translated) Then
                cbtn.Text = translated
            End If
        Next

        For Each ctab As CTabControl In allCtrl.OfType(Of CTabControl)()
            TranslateTabControl(ctab, translationDict)
        Next

        '' Special controls
        For Each menuStrip As MenuStrip In allCtrl.OfType(Of MenuStrip)()
            TranslateMenuStrip(menuStrip, translationDict)
        Next

        For Each toolStripButton As ToolStripButton In allCtrl.OfType(Of ToolStripButton)()
            TranslateToolStripButton(toolStripButton, translationDict)
        Next

        For Each grid As DataGridView In allCtrl.OfType(Of DataGridView)()
            TranslateDataGridView(grid, targetLanguageIdNo)
        Next

        For Each grid As DataGrid In allCtrl.OfType(Of DataGrid)()
            TranslateDataGrid(grid, targetLanguageIdNo)
        Next

        ' Fallback for any other translatable controls not covered above
        For Each ctrl In allCtrl
            If Not (TypeOf ctrl Is Windows.Forms.Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is CheckBox OrElse
                TypeOf ctrl Is RadioButton OrElse TypeOf ctrl Is TabPage OrElse
                TypeOf ctrl Is CButton OrElse TypeOf ctrl Is CTabControl OrElse
                TypeOf ctrl Is MenuStrip OrElse TypeOf ctrl Is ToolStrip OrElse
                TypeOf ctrl Is DataGridView OrElse TypeOf ctrl Is DataGrid) AndAlso IsTranslatable(ctrl) Then

                Dim key = If(ctrl.Tag IsNot Nothing, ctrl.Tag.ToString(), ctrl.Name)
                Dim translated As String = Nothing
                If translationDict.TryGetValue(key, translated) Then
                    ctrl.Text = translated
                ElseIf ctrl.Tag IsNot Nothing Then
                    ctrl.Text = ctrl.Tag.ToString()
                Else
                    ctrl.Text = String.Empty
                End If
            End If
        Next
    End Sub


    '    ' This method is commented out because it is not used in the current implementation.
    'Protected Sub TranslateToLanguageIdNo(ByRef allCtrl As List(Of Control), targetLanguageIdNo As Integer)
    '    Dim translationDict = GetTranslationDictionary(targetLanguageIdNo)
    '    For Each cCtrl As Control In allCtrl
    '        If Not IsTranslatable(cCtrl) Then Continue For

    '        If TypeOf cCtrl Is MenuStrip Then
    '            Dim subMenuName As String = ""
    '            Dim menuStrip As MenuStrip = CType(cCtrl, MenuStrip)
    '            TranslateMenuStripItems(menuStrip.Items, subMenuName)
    '        ElseIf TypeOf cCtrl Is ToolStrip Then
    '            TranslateToolStripItems(cCtrl)
    '        ElseIf TypeOf cCtrl Is CTreeViewOld Or TypeOf cCtrl Is TreeView Then
    '            ' No translation needed for tree view controls here
    '        ElseIf TypeOf cCtrl Is DataGridView Then
    '            TranslateDataGridView(cCtrl, targetLanguageIdNo)
    '        ElseIf TypeOf cCtrl Is DataGrid Then
    '            TranslateDataGrid(cCtrl, targetLanguageIdNo)
    '        ElseIf TypeOf cCtrl Is CTabControl Then
    '            TranslateTabControl(cCtrl)
    '        ElseIf TypeOf cCtrl Is CButton Then
    '            TranslateButton(cCtrl)
    '        Else
    '            Dim originalText As String = cCtrl.Name
    '            If CaptionCollection.Contains(cCtrl.Name) Then
    '                originalText = CaptionCollection.Item(cCtrl.Name)
    '            End If
    '            Dim translated As String = Nothing
    '            If translationDict.TryGetValue(originalText, translated) Then
    '                cCtrl.Text = translated
    '            ElseIf cCtrl.Tag IsNot Nothing Then
    '                cCtrl.Text = cCtrl.Tag.ToString()
    '            Else
    '                cCtrl.Text = String.Empty
    '            End If
    '        End If
    '    Next
    'End Sub

    Protected Sub LayOutControls(ByRef allCtrl As List(Of Control))
        For Each cCtrl As Control In allCtrl
            If IsTranslatable(cCtrl) Then
                If TypeOf cCtrl Is ToolStrip Then
                    Dim cToolStrip As ToolStrip = cCtrl
                    cToolStrip.SuspendLayout()
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
                    cToolStrip.ResumeLayout()
                ElseIf TypeOf cCtrl Is CTreeViewOld Or TypeOf cCtrl Is TreeView Or TypeOf cCtrl Is CTreeView Then
                    Dim cT = CType(cCtrl, TreeView)
                    cT.SuspendLayout()
                    cT.ExpandAll()
                    cT.RightToLeftLayout = GlobalVariables.RightToLeftLayout
                    cT.RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
                    cT.ResumeLayout()
                ElseIf TypeOf cCtrl Is CButton Then
                    TranslateButton(cCtrl)
                ElseIf TypeOf cCtrl Is CTabControl Then
                    Dim tc = CType(cCtrl, CTabControl)
                    tc.SuspendLayout()
                    tc.RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
                    tc.RightToLeftLayout = GlobalVariables.RightToLeftLayout
                    tc.ResumeLayout()
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
        Dim cmd As String = "Select Caption, translatedCaption from SystemViewItemOriginal_view where LanguageIdNo = " + targetLanguageIdNo.ToString() + " and SystemViewIdNo = " + GetSystemViewIdNo.ToString()
        Dim translations As DataSet
        translations = TranslatorDAC.ReturnDs(cmd)
        Return translations
    End Function

    Protected Function GetSystemViewIdNo()
        Dim cmd As String
        If ViewDisplayName Is Nothing Or ViewDisplayName = "" Then
            ViewDisplayName = Name
        End If
        cmd = "SELECT IdNo FROM SystemView where SystemViewName ='" + ViewDisplayName.Trim() + "'"
        Return TranslatorDAC.ExecScalar(Of Int16)(cmd)
    End Function


    Private Sub TranslateMenuStrip(cMenuStrip As MenuStrip, translationDict As Dictionary(Of String, String))
        For Each obj As ToolStripMenuItem In cMenuStrip.Items
            Dim key = If(obj.Tag IsNot Nothing, obj.Tag.ToString(), obj.Name)
            Dim translatedText As String = Nothing
            If translationDict.TryGetValue(key, translatedText) Then
                obj.Text = translatedText
            ElseIf obj.Tag IsNot Nothing Then
                obj.Text = obj.Tag.ToString()
            Else
                obj.Text = obj.Name ' Fallback to Name if Tag and translation are missing
            End If

            ' Recursively translate submenus
            For Each toolStripMenuItem As ToolStripMenuItem In obj.DropDownItems.OfType(Of ToolStripMenuItem)()
                TranslateToolStripMenuItem(toolStripMenuItem, translationDict)
            Next
        Next

        ' Optionally, set RTL and font for the menu and its items
        cMenuStrip.RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
        cMenuStrip.Font = New Font("Tahoma", 9) ' Or another Unicode-supporting font
        cMenuStrip.Refresh()
    End Sub

    Private Sub TranslateToolStripMenuItem(cToolStripMenuItem As ToolStripMenuItem, translationDict As Dictionary(Of String, String))
        Dim key = If(cToolStripMenuItem.Tag IsNot Nothing, cToolStripMenuItem.Tag.ToString(), cToolStripMenuItem.Name)
        Dim translatedText As String = Nothing
        If translationDict.TryGetValue(key, translatedText) Then
            cToolStripMenuItem.Text = translatedText
        ElseIf cToolStripMenuItem.Tag IsNot Nothing Then
            cToolStripMenuItem.Text = cToolStripMenuItem.Tag.ToString()
        Else
            cToolStripMenuItem.Text = cToolStripMenuItem.Name ' Fallback to Name if Tag and translation are missing
        End If

        ' Recursively translate submenus
        For Each item As ToolStripMenuItem In cToolStripMenuItem.DropDownItems.OfType(Of ToolStripMenuItem)()
            TranslateToolStripMenuItem(item, translationDict)
        Next
    End Sub

    Private Sub TranslateToolStripButton(ByRef cToolStripButton As ToolStripButton, translationDict As Dictionary(Of String, String))
        Dim translatedText As String = Nothing
        translatedText = Nothing
        Dim key = If(cToolStripButton.Tag IsNot Nothing, cToolStripButton.Tag.ToString(), cToolStripButton.Name)
        If translationDict.TryGetValue(key, translatedText) Then
            cToolStripButton.Text = translatedText
        Else
            cToolStripButton.Text = cToolStripButton.Tag
        End If
    End Sub



    Private Sub TranslateToolStrip(ByRef cToolStrip As ToolStrip, translationDict As Dictionary(Of String, String))
        Dim translatedText As String = Nothing
        For Each obj As Object In cToolStrip.Items
            translatedText = Nothing
            Dim key = If(obj.Tag IsNot Nothing, obj.Tag.ToString(), obj.Name)
            If translationDict.TryGetValue(key, translatedText) Then
                obj.Text = translatedText
            Else
                obj.Text = obj.Tag
            End If
        Next
    End Sub



    Private Sub TranslateToolStripItems(ByRef cToolStrip As ToolStrip, translationDict As Dictionary(Of String, String))
        Dim translatedText As String = Nothing
        For Each obj As Object In cToolStrip.Items
            translatedText = Nothing
            Dim key = If(obj.Tag IsNot Nothing, obj.Tag.ToString(), obj.Name)
            If translationDict.TryGetValue(key, translatedText) Then
                obj.Text = translatedText
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

    Private Sub TranslateDataGridView(ByRef CtDataGridView As DataGridView, ByVal targetLanguageIdNo As Integer)
        CtDataGridView.SuspendLayout()
        Dim translationDict = GetTranslationDictionary(targetLanguageIdNo)
        For Each column As DataGridViewColumn In CtDataGridView.Columns
            Dim lookupKey As String = If(column.Tag IsNot Nothing, column.Tag.ToString(), column.Name)
            Dim translated As String = Nothing
            If translationDict.TryGetValue(lookupKey, translated) Then
                column.HeaderText = translated
            ElseIf column.Tag IsNot Nothing Then
                column.HeaderText = column.Tag.ToString()
            End If
            ' If both translation and tag are missing, keep the current HeaderText
        Next
        CtDataGridView.ResumeLayout()
    End Sub

    Private Sub TranslateDataGrid(ByRef cDataGrid As DataGrid, ByVal targetLanguageIdNo As Integer)
        cDataGrid.SuspendLayout()
        Dim translationDict = GetTranslationDictionary(targetLanguageIdNo)
        Dim originalText As String = cDataGrid.Name
        If CaptionCollection.Contains(cDataGrid.Name) Then
            originalText = CaptionCollection.Item(cDataGrid.Name)
        End If
        Dim translated As String = Nothing
        If translationDict.TryGetValue(originalText, translated) Then
            CType(cDataGrid, DataGrid).CaptionText = translated
        ElseIf cDataGrid.Tag IsNot Nothing Then
            CType(cDataGrid, DataGrid).CaptionText = cDataGrid.Tag.ToString()
        Else
            CType(cDataGrid, DataGrid).CaptionText = String.Empty
        End If
        cDataGrid.ResumeLayout()
    End Sub




    Private Sub TranslateTabControl(ByRef cTabControl As CTabControl, translationDict As Dictionary(Of String, String))
        cTabControl.SuspendLayout()
        For Each tabPage As TabPage In cTabControl.TabPages
            Dim lookupKey As String = If(tabPage.Tag IsNot Nothing, tabPage.Tag.ToString(), tabPage.Name)
            Dim translated As String = Nothing
            If translationDict.TryGetValue(lookupKey, translated) Then
                tabPage.Text = translated
            ElseIf tabPage.Tag IsNot Nothing Then
                tabPage.Text = tabPage.Tag.ToString()
            End If
        Next
        cTabControl.ResumeLayout()
        'Dim translationDict = GetTranslationDictionary(TargetLanguageIdNo)
        'For Each column As DataGridViewColumn In CtDataGridView.Columns
        '    Dim lookupKey As String = If(column.Tag IsNot Nothing, column.Tag.ToString(), column.Name)
        '    Dim translated As String = Nothing
        '    If translationDict.TryGetValue(lookupKey, translated) Then
        '        column.HeaderText = translated
        '    ElseIf column.Tag IsNot Nothing Then
        '        column.HeaderText = column.Tag.ToString()
        '    End If
        '    ' If both translation and tag are missing, keep the current HeaderText
        'Next
    End Sub

    Private _targetLanguageIdNo As Integer

    Private Property TargetLanguageIdNo As Integer
        Set(value As Integer)
            _targetLanguageIdNo = value
        End Set
        Get
            Return _targetLanguageIdNo
        End Get
    End Property



    Private Function GetToolStripText(cToolStrip As ToolStrip, obj As Object, propName As String) As String
        Dim key As String = cToolStrip.Name & "." & obj.Name & "." & propName
        Dim translatedText As String = Nothing
        Dim translationDict = GetTranslationDictionary(TargetLanguageIdNo)

        If translationDict IsNot Nothing AndAlso translationDict.TryGetValue(key, translatedText) Then
            Return translatedText
        End If

        ' Fallback: try to get from Tag (if it's an array, pick the right index)
        If obj.Tag IsNot Nothing Then
            If TypeOf obj.Tag Is Object() Then
                Dim tagArr = DirectCast(obj.Tag, Object())
                If propName = "ToolTipText" AndAlso tagArr.Length > 1 AndAlso tagArr(1) IsNot Nothing Then
                    Return tagArr(1).ToString()
                ElseIf propName = "Text" AndAlso tagArr.Length > 1 AndAlso tagArr(0) IsNot Nothing Then
                    Return tagArr(0).ToString()
                End If
            Else
                Return obj.Tag.ToString()
            End If
        End If

        Return String.Empty

        'Dim translatedText As String = ""
        'Dim r As Integer
        'If CaptionCollection.Contains(cToolStrip.Name + "." + obj.Name + "." + propName) Then
        '    r = Dv.Find(CaptionCollection.Item(cToolStrip.Name + "." + obj.Name + "." + propName))
        '    If r >= 0 Then
        '        translatedText = Dv(r).Item("translatedCaption")
        '    Else
        '        translatedText = obj.Tag(If(propName = "Text", 0, 1))
        '    End If
        'End If
        'Return translatedText
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
        If UserIsASuperAdmin() Then
            SetPropertyValue(cCtrl, "Visible", True)
        ElseIf controlVisible Then
            SetPropertyValue(cCtrl, "Visible", True)
        Else
            SetPropertyValue(cCtrl, "Visible", False)
        End If
    End Sub

    Private Sub ApplyMenuSecurityNew(ByRef obj As ToolStripMenuItem, ByRef subMenuName As String)
        Const menuPrefix As String = "ToolStripMenuItem"
        Dim toolStripMenuItem As ToolStripMenuItem = obj
        Dim shortName As String = toolStripMenuItem.Name
        If shortName.StartsWith(menuPrefix) Then
            shortName = shortName.Substring(menuPrefix.Length)
        End If
        Dim controlSecurityKey = subMenuName + " > " + shortName
        If GlobalVariables.IsUserLoggedIn Then
            SetMenuSecurity(toolStripMenuItem, controlSecurityKey)
        Else
            toolStripMenuItem.Enabled = False
            toolStripMenuItem.Visible = True
        End If
    End Sub

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

    Private Function SetControlSecurityValue(securityIdNo As Integer) As ArrayList
        Dim controlSecurityValues As ArrayList

        controlSecurityValues = Presenter.GetUserSecurity(Convert.ToInt16(securityIdNo),
                                                             GlobalVariables.SecurityGroupIdNo)
        Return controlSecurityValues
    End Function

    Private Sub BFMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            ' Preload translations for English and Arabic, and views 1 and 2
            TranslationUtility.PreloadTranslations(New String() {"en-US", "ar-SA"}, New Integer() {1, 2}, TranslatorDAC)

            If _firstLoadSwitch = 0 Then
                GetNSaveCaptions()
                _firstLoadSwitch = 1
            End If
            If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
                TextDisplayLanguage = CultureInfo.CurrentCulture.Name
            End If
            RaiseEvent BeforeLoad()
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

    Private Sub SetToolStripItemsNew(dropDownItems As ToolStripItemCollection, subMenuName As String)
        Const toolStripButtonPrefix As String = "ToolStripButton"
        For Each obj As Object In dropDownItems
            Dim toolStripButton = TryCast(obj, ToolStripButton)
            If toolStripButton IsNot Nothing Then
                ' Remove the known prefix from the button name, if present
                Dim controlSecurityKey As String = toolStripButton.Name
                If controlSecurityKey.StartsWith(toolStripButtonPrefix, StringComparison.OrdinalIgnoreCase) Then
                    controlSecurityKey = controlSecurityKey.Substring(toolStripButtonPrefix.Length)
                End If
                controlSecurityKey = controlSecurityKey.TrimEnd()
                controlSecurityKey = subMenuName & " > " & controlSecurityKey

                If GlobalVariables.IsUserLoggedIn Then
                    Dim controlSecurityValues As ArrayList = Nothing
                    Dim isSelectable As Boolean = True
                    Dim isVisible As Boolean = True
                    Dim securityIdNo As Int32 = GetControlSecurityIdNo(controlSecurityKey, True)
                    If securityIdNo <> 0 Then
                        If GlobalVariables.SecurityGroupIdNo <> 0 Then
                            controlSecurityValues = Presenter.GetUserSecurity(securityIdNo, GlobalVariables.SecurityGroupIdNo)
                            If controlSecurityValues IsNot Nothing AndAlso controlSecurityValues.Count > 0 Then
                                isVisible = CBool(controlSecurityValues(0))
                                isSelectable = CBool(controlSecurityValues(1))
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

    Private Sub TranslateMenuStripItems(dropDownItems As ToolStripItemCollection, subMenuName As String)
        Dim translationDict = GetTranslationDictionary(TargetLanguageIdNo)
        For Each obj As Object In dropDownItems
            Dim subMenu = TryCast(obj, ToolStripMenuItem)
            If subMenu IsNot Nothing Then

                Dim lookupKey As String = If(obj.Tag IsNot Nothing, obj.Tag.ToString(), obj.Name)
                Dim translated As String = Nothing
                Debug.WriteLine("Menu key: " & lookupKey)
                If translationDict.TryGetValue(lookupKey, translated) Then
                    obj.Text = translated
                ElseIf translated IsNot Nothing Then
                    obj.Text = lookupKey
                Else
                    obj.Text = String.Empty
                End If
                If subMenu.HasDropDownItems Then
                    Dim newSubMenuName = subMenuName
                    If Not String.IsNullOrEmpty(obj.Name) Then
                        newSubMenuName = newSubMenuName & "." & obj.Name
                    End If
                    TranslateMenuStripItems(subMenu.DropDownItems, newSubMenuName)
                End If
                Debug.WriteLine("Translation key: " & obj.Text)
                'Dim r As Int16 = -1
                'Dim tagValue As Object = obj.Tag
                'If tagValue IsNot Nothing AndAlso Dv IsNot Nothing Then


                '    r = Dv.Find(tagValue)
                'End If
                'If r >= 0 AndAlso Dv.Table.Columns.Contains("translatedCaption") Then
                '    obj.Text = Convert.ToString(Dv(r).Item("translatedCaption"))
                'ElseIf tagValue IsNot Nothing Then
                '    obj.Text = tagValue.ToString
                'Else
                '    obj.Text = String.Empty
                'End If
                'If subMenu.HasDropDownItems Then
                '    Dim newSubMenuName = subMenuName
                '    If Not String.IsNullOrEmpty(obj.Name) Then
                '        newSubMenuName = newSubMenuName & "." & obj.Name
                '    End If
                '    TranslateMenuStripItems(subMenu.DropDownItems, newSubMenuName)
                'End If

            End If
        Next
    End Sub

    Private Sub UseOriginalMenuStripCaptions(dropDownItems As ToolStripItemCollection, subMenuName As String)
        For Each obj As Object In dropDownItems
            Dim subMenu = TryCast(obj, ToolStripMenuItem)
            If subMenu IsNot Nothing Then
                Dim tagValue As Object = obj.Tag
                If subMenu.HasDropDownItems Then
                    Dim newSubMenuName = subMenuName
                    If Not String.IsNullOrEmpty(obj.Name) Then
                        newSubMenuName = newSubMenuName & "." & obj.Name
                    End If
                    obj.Text = If(tagValue IsNot Nothing, tagValue.ToString(), String.Empty)
                    UseOriginalMenuStripCaptions(subMenu.DropDownItems, newSubMenuName)
                Else
                    Dim toolStripMenuItem As ToolStripMenuItem = obj
                    toolStripMenuItem.Text = If(toolStripMenuItem.Tag IsNot Nothing, toolStripMenuItem.Tag.ToString(), String.Empty)
                End If
            End If
        Next
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
            If obj.Tag IsNot Nothing AndAlso TypeOf obj.Tag Is Object() Then
                Dim tagArr = DirectCast(obj.Tag, Object())
                If tagArr.Length > 0 Then obj.Text = tagArr(0)
                If tagArr.Length > 1 Then obj.ToolTipText = tagArr(1)
            ElseIf obj.Tag IsNot Nothing Then
                obj.Text = obj.Tag.ToString()
                obj.ToolTipText = ""
            Else
                obj.Text = ""
                obj.ToolTipText = ""
            End If
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

    Protected Overloads Sub CreateLookupDataTable(tableName As String, targetProperty As String)
        Ea.PublishEvent(New GetLookupDataTableRequested(tableName, Me, targetProperty))
    End Sub

    Protected Overloads Sub CreateLookupDataTable(tableName As String, targetProperty As String, filter As String)
        Ea.PublishEvent(New GetLookupDataTableRequested(tableName, Me, targetProperty, filter))
    End Sub

    Protected Overloads Sub CreateLookupDataTable(tableName As String, targetProperty As String, sortKey As String, filter As String)
        Ea.PublishEvent(New GetLookupDataTableRequested(tableName, Me, targetProperty, sortKey, filter))
    End Sub

    Protected Overloads Sub CreateLookupDataTable(tableName As String, targetProperty As String, fields As String(), Optional filter As String = Nothing)
        Ea.PublishEvent(New GetLookupDataTableRequested(tableName, Me, targetProperty, fields, filter))
    End Sub

    Protected Overloads Sub CreateLookupDataTable(tableName As String, targetProperty As String, sortField As String, fields As String(), Optional filter As String = Nothing)
        Ea.PublishEvent(New GetLookupDataTableRequested(tableName, Me, targetProperty, sortField, fields, filter))
    End Sub

    Public Function GetFieldType(fieldName As String) As Type
        If Invoker.GetProperty(Me, fieldName) IsNot Nothing Then
            Return Invoker.GetProperty(Me, fieldName).GetType
        End If
        Return Nothing
    End Function

    Protected Sub ProcessCellEndEdit(dataGridView As DataGridView, bindingSource As BindingSource)
        Dim firstDisplayedRow = dataGridView.FirstDisplayedScrollingRowIndex
        If bindingSource.Current IsNot Nothing Then
            Ea.PublishEvent(New DgvItemsChanged(bindingSource,
                                                dataGridView.CurrentRow.Index,
                                                dataGridView.CurrentCell.OwningColumn.DataPropertyName,
                                                dataGridView.CurrentCell.OwningColumn.Name,
                                                dataGridView.CurrentCell.Value))
        End If
        bindingSource.ResetBindings(False)
    End Sub

    Protected Sub ProcessCellValidating(dataGridView As DataGridView, bindingSource As BindingSource)
        Dim firstDisplayedRow = dataGridView.FirstDisplayedScrollingRowIndex
        Ea.PublishEvent(New DgvItemsChanged(bindingSource,
                                                dataGridView.CurrentRow.Index,
                                                dataGridView.CurrentCell.OwningColumn.DataPropertyName,
                                                dataGridView.CurrentCell.OwningColumn.Name,
                                                dataGridView.CurrentCell.Value))
        bindingSource.ResetBindings(False)
    End Sub

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

    Public Sub ForceLooseFocusOnCurrentControl()
        Dim currentActiveControl As Control = ActiveControl
        If currentActiveControl IsNot Nothing Then
            SelectNextControl(currentActiveControl, True, True, True, True)
        End If
        Refresh()
        If currentActiveControl IsNot Nothing Then
            ActiveControl = currentActiveControl
        End If
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

    Private Sub SetGlobalFont(ctrl As Control, font As Font)
        ctrl.Font = font
        For Each child As Control In ctrl.Controls
            SetGlobalFont(child, font)
        Next

        ' Special handling for MenuStrip and ToolStrip
        If TypeOf ctrl Is MenuStrip Then
            Dim menu = CType(ctrl, MenuStrip)
            menu.Font = font
            For Each item As ToolStripMenuItem In menu.Items
                SetToolStripItemFont(item, font)
            Next
        ElseIf TypeOf ctrl Is ToolStrip Then
            Dim tool = CType(ctrl, ToolStrip)
            tool.Font = font
            For Each item As ToolStripItem In tool.Items
                item.Font = font
            Next
        End If
    End Sub

    Private Sub SetToolStripItemFont(item As ToolStripMenuItem, font As Font)
        item.Font = font
        For Each subItem As ToolStripItem In item.DropDownItems
            If TypeOf subItem Is ToolStripMenuItem Then
                SetToolStripItemFont(CType(subItem, ToolStripMenuItem), font)
            Else
                subItem.Font = font
            End If
        Next
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