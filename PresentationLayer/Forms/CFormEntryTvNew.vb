Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Public Class CFormEntryTvNew

    Protected TvMainFieldName As String
    Protected TvSecondaryFieldName As String
    Protected TvSortKey As String

    'Protected FormTreeView As TreeView
    Private _bypassSelectedChange As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Property TreeViewData As New Object

    Public Sub DisplayTreeViewData()
        If Ea IsNot Nothing Then
            Ea.PublishEvent(New TreeViewDisplay(FormTreeView))
        End If
    End Sub

    Protected Overrides Sub OnTextDisplayLanguageChanged() Handles Me.TextDisplayLanguageChanged
        MyBase.OnTextDisplayLanguageChanged()
        DisplayTreeViewData()
    End Sub

    Private Sub CFormEntryTv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            FormTreeView.Nodes(0).Text = MainTableName
            DisplayTreeViewData()
            FormTreeView.ExpandAll()
            FormTreeView.Refresh()
        End If
    End Sub

    Private Sub BfTvEntry_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        _bypassSelectedChange = True
        If GlobalVariables.RightToLeftLayout Then
            RightToLeftLayout = True
            FormTreeView.RightToLeftLayout = True
            FormTreeView.RightToLeft = RightToLeft.Yes
        Else
            RightToLeftLayout = False
            FormTreeView.RightToLeftLayout = False
            FormTreeView.RightToLeft = RightToLeft.No
        End If
        FormTreeView.ExpandAll()
        _bypassSelectedChange = False
    End Sub

End Class