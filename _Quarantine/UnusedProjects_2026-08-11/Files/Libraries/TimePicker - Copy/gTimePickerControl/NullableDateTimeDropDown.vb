Imports System.Windows.Forms.Design

<System.ComponentModel.ToolboxItem(False)> _
Public Class NullableDateTimeDropDown
    Private _editorService As IWindowsFormsEditorService = Nothing

    Private _Value As Nullable(Of DateTime)
    Public Property Value() As Nullable(Of DateTime)
        Get
            Return _Value
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            _Value = value
            If _Value.HasValue Then MonthCalendar1.SetDate(CDate(_Value))
        End Set
    End Property

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        _Value = Nothing
        _editorService.CloseDropDown()

    End Sub

    Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        _Value = MonthCalendar1.SelectionRange.Start
        _editorService.CloseDropDown()

    End Sub

    Public Sub New(ByVal value As Nullable(Of DateTime), ByVal editorService As IWindowsFormsEditorService)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _editorService = editorService
        Me.Value = value
    End Sub
End Class
