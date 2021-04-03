Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CFindForm
    Inherits CForm

    Private _TextToSearch As String
    Private _SearchAnywhere As Boolean
    Private _useCombobox As Boolean
    Private _control As Control

    Public Sub New(useComboBox As Boolean, Optional cControl As Control = Nothing)

        ' This call is required by the designer.
        InitializeComponent()
        _useCombobox = useComboBox
        _control = cControl
        ' Add any initialization after the InitializeComponent() call.

    End Sub

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
        If _useCombobox Then
            _TextToSearch = cboTextToSearch.SelectedValue
        Else
            _TextToSearch = TxtTextToSearch.Text
            If RBtnStart.Checked Then
                _SearchAnywhere = False
            Else
                _SearchAnywhere = True
            End If
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
        If _useCombobox Then
            lblLookFor1.Visible = False
            lblLookFor2.Visible = True
            TxtTextToSearch.Visible = False
            cboTextToSearch.Visible = True
            RBtnAnywhere.Visible = False
            RBtnStart.Visible = False
            Dim myComboBox As CaComboBox = _control
            cboTextToSearch.DataSource = myComboBox.DataSource
            cboTextToSearch.DisplayMember = myComboBox.DisplayMember
            cboTextToSearch.ValueMember = myComboBox.ValueMember
        Else
            lblLookFor1.Visible = True
            lblLookFor2.Visible = False
            TxtTextToSearch.Visible = True
            cboTextToSearch.Visible = False
            RBtnAnywhere.Visible = True
            RBtnStart.Visible = True
        End If
    End Sub

End Class