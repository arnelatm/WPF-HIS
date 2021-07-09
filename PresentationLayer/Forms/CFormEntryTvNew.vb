Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters

Public Class CFormEntryTvNew

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Property TreeViewData As New Object

    'Private Sub BfTvEntry_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    '    'If GlobalVariables.RightToLeftLayout Then
    '    '    RightToLeft = RightToLeft.Yes
    '    '    RightToLeftLayout = True
    '    '    FormTreeView.RightToLeft = RightToLeft.Yes
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