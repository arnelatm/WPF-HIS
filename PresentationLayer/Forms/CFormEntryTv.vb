Imports System.Reflection
Imports System.Windows.Forms

Public Class CFormEntryTv

    Private Shared ReadOnly DoubleBufferedProperty As PropertyInfo =
        GetType(Control).GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)

    Protected Overrides ReadOnly Property UseFastLanguageLayoutOnInitialDisplay As Boolean
        Get
            Return True
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            EnableDoubleBuffering(SplitContainer1)
            EnableDoubleBuffering(SplitContainer1.Panel1)
            EnableDoubleBuffering(SplitContainer1.Panel2)
            EnableDoubleBuffering(FormTreeView)
            ApplyFormLanguageDirection()
        End If

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Shared Sub EnableDoubleBuffering(control As Control)
        If control IsNot Nothing AndAlso DoubleBufferedProperty IsNot Nothing Then
            DoubleBufferedProperty.SetValue(control, True, Nothing)
        End If
    End Sub

    Public Property TreeViewData As New Object

    'Private Sub FormTreeView_AfterSelect(sender As Object, e As Windows.Forms.TreeViewEventArgs) Handles FormTreeView.AfterSelect
    '    RunAfterChangeRecord()
    'End Sub

    'Private Sub BfTvEntry_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    '    'If GlobalVariables.RightToLeftLayout Then
    '    '    RightToLeft = RightToLeft.Yes
    '    '    RightToLeftLayout = True
    '    '    FormTreeView.RightToLeft =
    '    RightToLeft.Yes
    '    '    FormTreeView.RightToLeftLayout = True
    '    'Else
    '    '    RightToLeft = RightToLeft.No
    '    '    RightToLeftLayout = False
    '    '    FormTreeView.RightToLeft = RightToLeft.No
    '    '    FormTreeView.RightToLeftLayout = False
    '    'End If
    '    'FormTreeView.ExpandAll()
    '    'GetNSaveCaptions()
    'End Sub

    'Protected Overrides Sub SwitchUiLanguage(originalUi As Boolean)
    '    MyBase.SwitchUiLanguage(originalUi)
    '    If Ea IsNot Nothing Then
    '        Ea.PublishEvent(New LanguageChanged(Me))
    '    End If
    'End Sub



End Class
