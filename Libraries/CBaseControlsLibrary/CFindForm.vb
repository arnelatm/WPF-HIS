Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CFindForm
    Inherits CForm

    Private _TextToSearch As String
    Private _SearchAnywhere As Boolean
    Private _searchMode As Int16
    Private _control As Control
    Private _begDateToSearch As Date?
    Private _endDateToSearch As Date?

    Public Sub New(searchMode As Int16, Optional cControl As Control = Nothing)

        ' This call is required by the designer.
        InitializeComponent()
        _searchMode = searchMode
        _control = cControl
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Property EndDateToSearch As Date?
        Get
            Return _endDateToSearch
        End Get
        Set
            _endDateToSearch = Value
        End Set
    End Property

    Public Property BegDateToSearch As Date?
        Get
            Return _begDateToSearch
        End Get
        Set
            _begDateToSearch = Value
        End Set
    End Property

    Public Property TextToSearch As String
        Get
            Return _TextToSearch
        End Get
        Set
            _TextToSearch = Value
        End Set
    End Property


    Public Property SearchAnywhere As Boolean
        Get
            Return _SearchAnywhere
        End Get
        Set
            _SearchAnywhere = Value
        End Set
    End Property

    Private Sub CLabel1_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Public Function GetTextToSearch() As String
        Return TextToSearch
    End Function

    Public Function GetSearchAnywhere() As String
        Return SearchAnywhere
    End Function

    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnFind.Click
        If _searchMode = 1 Then
            ' combobox Search
            _TextToSearch = cboTextToSearch.SelectedValue
            _SearchAnywhere = False
        ElseIf _searchMode = 0 Then
            ' textbox search
            _TextToSearch = TxtTextToSearch.Text
            If RBtnStart.Checked Then
                _SearchAnywhere = False
            Else
                _SearchAnywhere = True
            End If
        ElseIf _searchMode = 2 Then
            ' date search
            _begDateToSearch = dtpBegDate.Value
            _endDateToSearch = dtpEndDate.Value
            SearchAnywhere = False
        End If
        Close()
    End Sub

    Private Sub SetFormLocation()
        Dim pnt As Point
        Dim formLocation As Point
        Dim screenRectangle As Rectangle
        Dim myForm = FindForm()
        screenRectangle = Screen.PrimaryScreen.WorkingArea
        Me.StartPosition = FormStartPosition.Manual
        pnt = System.Windows.Forms.Control.MousePosition
        If GlobalVariables.RightToLeftLayout Then
            formLocation = New Point(pnt.X - Me.Width, pnt.Y + Me.Height)
            If formLocation.X < 0 Then
                formLocation.X = pnt.X
            End If
        Else
            formLocation = New Point(pnt.X, pnt.Y)
            If formLocation.X + Me.Width > screenRectangle.Width Then
                formLocation.X = pnt.X - Me.Width
            End If
        End If
        If formLocation.Y + Me.Height > screenRectangle.Height Then
            formLocation.Y = pnt.Y - Me.Height
        End If
        Me.Location = formLocation
    End Sub

    Private Sub CFindForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetFormLocation()
        If _searchMode = 1 Then
            ' combobox search
            lblLookFor1.Visible = False
            lblLookFor2.Visible = True
            lblLookFor3.Visible = False
            lblLookFor4.Visible = False
            TxtTextToSearch.Visible = False
            cboTextToSearch.Visible = True
            RBtnAnywhere.Visible = False
            RBtnStart.Visible = False
            Dim myComboBox As CaComboBox = _control
            cboTextToSearch.DataSource = myComboBox.DataSource
            cboTextToSearch.DisplayMember = myComboBox.DisplayMember
            cboTextToSearch.ValueMember = myComboBox.ValueMember
            dtpBegDate.Visible = False
            dtpEndDate.Visible = False
            lblTo.Visible = False
            chkChecked.Visible = False
            Height = 125
        ElseIf _searchMode = 0 Then
            ' textbox search
            lblLookFor1.Visible = True
            lblLookFor2.Visible = False
            lblLookFor3.Visible = False
            lblLookFor4.Visible = False
            TxtTextToSearch.Visible = True
            cboTextToSearch.Visible = False
            RBtnAnywhere.Visible = True
            RBtnStart.Visible = True
            dtpBegDate.Visible = False
            dtpEndDate.Visible = False
            lblTo.Visible = False
            chkChecked.Visible = False
            Height = 175
        ElseIf _searchMode = 2 Then
            ' date search
            dtpBegDate.Visible = True
            dtpEndDate.Visible = True
            lblLookFor1.Visible = False
            lblLookFor2.Visible = False
            lblLookFor3.Visible = True
            lblLookFor4.Visible = False
            TxtTextToSearch.Visible = False
            cboTextToSearch.Visible = False
            RBtnAnywhere.Visible = False
            RBtnStart.Visible = False
            lblTo.Visible = True
            chkChecked.Visible = False
            Height = 125
        ElseIf _searchMode = 3 Then
            lblLookFor4.Visible = True
            chkChecked.Visible = True
            dtpBegDate.Visible = False
            dtpEndDate.Visible = False
            lblLookFor1.Visible = False
            lblLookFor2.Visible = False
            lblLookFor3.Visible = False
            TxtTextToSearch.Visible = False
            cboTextToSearch.Visible = False
            RBtnAnywhere.Visible = False
            RBtnStart.Visible = False
            lblTo.Visible = False
            Height = 125
        End If
    End Sub

    Private Sub dtpBegDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpBegDate.ValueChanged
        If dtpBegDate.Value > dtpEndDate.Value Then
            dtpEndDate.Value = dtpBegDate.Value
        End If
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged
        If dtpEndDate.Value < dtpBegDate.Value Then
            dtpBegDate.Value = dtpEndDate.Value
        End If
    End Sub

End Class