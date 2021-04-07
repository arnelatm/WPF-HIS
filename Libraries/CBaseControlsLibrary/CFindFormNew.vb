Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class CFindFormNew
    Inherits CForm

    Private _textToSearch As String
    Private _searchPlace As SearchPlaceEnum
    Private _begDateToSearch As Date?
    Private _endDateToSearch As Date?
    Private ReadOnly _findableControl As IFindableControl

    Public Sub New(findableControl As IFindableControl)

        ' This call is required by the designer.
        InitializeComponent()
        _findableControl = findableControl
        'If findableControl.SearchMode = "String" Then
        '    _searchMode = SearchModeEnum.TextBox
        'ElseIf findableControl.SearchMode = "ComboBox" Then
        '    _searchMode = SearchModeEnum.ComboBox
        'ElseIf findableControl.SearchMode = "Date" Then
        '    _searchMode = SearchModeEnum.CustomDateTimePicker
        'ElseIf findableControl.SearchMode = "Boolean" Then
        '    _searchMode = SearchModeEnum.TextBox
        'End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Property SearchPlace As SearchPlaceEnum
        Get
            Return _searchPlace
        End Get
        Set
            _searchPlace = Value
        End Set
    End Property

    Private Sub CLabel1_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    'Public Function GetTextToSearch() As String
    '    Return TextToSearch
    'End Function

    'Public Function GetSearchPlace() As String
    '    Return SearchPlace
    'End Function

    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnFind.Click
        If _findableControl.SearchMode = IFindableControl.SearchModeEnum.ComboBox Then
            _searchPlace = SearchPlaceEnum.ExactMatch
            _findableControl.BegFindValue = TxtTextToSearch.Text
        ElseIf _findableControl.SearchMode = IFindableControl.SearchModeEnum.String Then
            If RBtnStart.Checked Then
                _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.StartOfField
            ElseIf RBtnExactMatch.Checked Then
                _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
            Else
                _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.AnywhereOnField
            End If
            _findableControl.BegFindValue = TxtTextToSearch.Text
        ElseIf _findableControl.SearchMode = IFindableControl.SearchModeEnum.Date Then
            _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
            _findableControl.BegFindValue = dtpBegDate.Value
            _findableControl.EndFindValue = dtpEndDate.Value
        ElseIf _findableControl.SearchMode = IFindableControl.SearchModeEnum.CheckBox Then
            _findableControl.BegFindValue = chkChecked.Checked
            _findableControl.EndFindValue = Nothing
        End If
        Close()
    End Sub

    Private Sub SetFormLocation()
        Dim pnt As Point
        Dim formLocation As Point
        Dim screenRectangle As Rectangle
        screenRectangle = Screen.PrimaryScreen.WorkingArea
        StartPosition = FormStartPosition.Manual
        pnt = MousePosition
        If GlobalVariables.RightToLeftLayout Then
            formLocation = New Point(pnt.X - Width, pnt.Y + Height)
            If formLocation.X < 0 Then
                formLocation.X = pnt.X
            End If
        Else
            formLocation = New Point(pnt.X, pnt.Y)
            If formLocation.X + Width > screenRectangle.Width Then
                formLocation.X = pnt.X - Width
            End If
        End If
        If formLocation.Y + Height > screenRectangle.Height Then
            formLocation.Y = pnt.Y - Height
        End If
        Location = formLocation
    End Sub

    Private Sub CFindForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetFormLocation()
        If _findableControl.SearchMode = IFindableControl.SearchModeEnum.ComboBox Then
            lblLookFor1.Visible = False
            lblLookFor2.Visible = True
            lblLookFor3.Visible = False
            lblLookFor4.Visible = False
            TxtTextToSearch.Visible = False
            cboTextToSearch.Visible = True
            RBtnAnywhere.Visible = False
            RBtnStart.Visible = False
            RBtnExactMatch.Visible = False
            cboTextToSearch.DataSource = _findableControl.FindDataSource
            cboTextToSearch.DisplayMember = _findableControl.FindDisplayMember
            cboTextToSearch.ValueMember = _findableControl.FindValueMember
            dtpBegDate.Visible = False
            dtpEndDate.Visible = False
            lblTo.Visible = False
            chkChecked.Visible = False
            Height = 140
        ElseIf _findableControl.SearchMode = IFindableControl.SearchModeEnum.String Then
            lblLookFor1.Visible = True
            lblLookFor2.Visible = False
            lblLookFor3.Visible = False
            lblLookFor4.Visible = False
            TxtTextToSearch.Visible = True
            cboTextToSearch.Visible = False
            RBtnAnywhere.Visible = True
            RBtnStart.Visible = True
            RBtnExactMatch.Visible = True
            dtpBegDate.Visible = False
            dtpEndDate.Visible = False
            lblTo.Visible = False
            chkChecked.Visible = False
            Height = 220
        ElseIf _findableControl.SearchMode = IFindableControl.SearchModeEnum.Date Then
            dtpBegDate.Visible = True
            dtpEndDate.Visible = True
            lblLookFor1.Visible = False
            lblLookFor2.Visible = False
            lblLookFor3.Visible = True
            lblLookFor4.Visible = False
            TxtTextToSearch.Visible = False
            cboTextToSearch.Visible = False
            RBtnExactMatch.Visible = False
            RBtnAnywhere.Visible = False
            RBtnStart.Visible = False
            lblTo.Visible = True
            chkChecked.Visible = False
            Height = 135
        ElseIf _findableControl.SearchMode = IFindableControl.SearchModeEnum.CheckBox Then
            lblLookFor4.Visible = True
            chkChecked.Visible = True
            dtpBegDate.Visible = False
            dtpEndDate.Visible = False
            lblLookFor1.Visible = False
            lblLookFor2.Visible = False
            lblLookFor3.Visible = False
            TxtTextToSearch.Visible = False
            cboTextToSearch.Visible = False
            RBtnExactMatch.Visible = False
            RBtnAnywhere.Visible = False
            RBtnStart.Visible = False
            lblTo.Visible = False
            Height = 125
        End If
    End Sub

    Private Sub dtpBegDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpBegDate.Validated
        If dtpBegDate.Value > dtpEndDate.Value Then
            dtpEndDate.Value = dtpBegDate.Value
        End If
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.Validated
        If dtpEndDate.Value IsNot Nothing AndAlso dtpEndDate.Value < dtpBegDate.Value Then
            dtpBegDate.Value = dtpEndDate.Value
        End If
    End Sub

    Private Enum SearchPlaceEnum
        Anywhere
        ExactMatch
        Start
    End Enum

End Class