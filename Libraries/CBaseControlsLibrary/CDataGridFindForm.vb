Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDataGridFindForm
    Inherits CForm

    Private _textToSearch As String
    Private _begDateToSearch As Date?
    Private _endDateToSearch As Date?
    Private _formPosition As Point
    Private _controlHeight As Int16
    Private _controlWidth As Int16
    Private _dgView As CDataGridView
    Private _columnNumber As Integer


    ReadOnly Property FindDataSource As Object
    ReadOnly Property FindDisplayMember As String
    ReadOnly Property SearchMode As SearchModeEnum
    ReadOnly Property FindValueMember As String

    Public Sub New(findableGrid As CDataGridView, columnNumber As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        _columnNumber = columnNumber
        Dim formPoint As Point
        _dgView = findableGrid
        'Dim ctrlPoint As Point
        'ctrlPoint = New Point(ctrl.Location.X + ctrl.Width, ctrl.Location.Y)
        'formPoint = ctrl.PointToScreen(ctrlPoint)
        _formPosition.X = formPoint.X
        _formPosition.Y = formPoint.Y
        _controlHeight = findableGrid.Height
        _controlWidth = findableGrid.Width
        '_dgView = findableGrid

        Dim pnt As Point = findableGrid.PointToScreen(New Point(0 + _dgView.Width, 0))
        _formPosition.X = pnt.X
        _formPosition.Y = pnt.Y
       'pnt = Me.PointToClient(pnt)

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
        DialogResult = DialogResult.OK
        Dim dataType As IFindableControl.DataTypeEnum = GetObjectDataType(_dgView.Columns(_columnNumber).ValueType)
        If dataType = IFindableControl.DataTypeEnum.String Then
            _dgView.DgSearch(_columnNumber).TextToSearch = TxtTextToSearch.Text
            If SearchMode = IFindableControl.SearchModeEnum.ComboBox Then
                _dgView.DgSearch(_columnNumber).SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
                _dgView.DgSearch(_columnNumber).BegFindValue = cboTextToSearch.SelectedValue
            ElseIf RBtnStart.Checked Then
                _dgView.DgSearch(_columnNumber).SearchPlace = IFindableControl.SearchPlaceEnum.StartOfField
            ElseIf RBtnExactMatch.Checked Then
                _dgView.DgSearch(_columnNumber).SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
            Else
                _dgView.DgSearch(_columnNumber).SearchPlace = IFindableControl.SearchPlaceEnum.AnywhereOnField
            End If
            If chkIgnoreCase.Checked Then
                _dgView.IgnoreCase = True
            Else
                _dgView.IgnoreCase = False
            End If
        ElseIf dataType = IFindableControl.DataTypeEnum.Date Then
            If SearchMode = IFindableControl.SearchModeEnum.ComboBox Then
                _dgView.DgSearch(_columnNumber).SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
                _dgView.DgSearch(_columnNumber).BegFindValue = cboTextToSearch.SelectedValue
            Else
                _dgView.DgSearch(_columnNumber).SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
                _dgView.DgSearch(_columnNumber).BegFindValue = dtpBegDate.Value
                _dgView.DgSearch(_columnNumber).EndFindValue = dtpEndDate.Value
            End If
        ElseIf dataType = IFindableControl.DataTypeEnum.Decimal Or dataType = IFindableControl.DataTypeEnum.Integer Then
            If SearchMode = IFindableControl.SearchModeEnum.ComboBox Then
                _dgView.DgSearch(_columnNumber).SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
                _dgView.DgSearch(_columnNumber).BegFindValue = cboTextToSearch.SelectedValue
            Else
                _dgView.DgSearch(_columnNumber).SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
                If txtBegValue.Text Is Nothing OrElse txtBegValue.Text = "" Then
                    _dgView.DgSearch(_columnNumber).BegFindValue = Nothing
                Else
                    If dataType = IFindableControl.DataTypeEnum.Decimal Then
                        Dim value As Decimal
                        If Not Decimal.TryParse(txtBegValue.Text, value) Then
                            MessagingLibrary.Messaging.Show(True, "MsgInvalidDecimalValue")
                            DialogResult = DialogResult.Cancel
                        Else
                            _dgView.DgSearch(_columnNumber).BegFindValue = txtBegValue.Text
                        End If
                    Else
                        Dim value As Integer
                        If Not Integer.TryParse(txtBegValue.Text, value) Then
                            MessagingLibrary.Messaging.Show(True, "MsgInvalidIntegerValue")
                        Else
                            _dgView.DgSearch(_columnNumber).BegFindValue = txtBegValue.Text
                        End If
                    End If
                End If
                If txtEndValue.Text Is Nothing OrElse txtEndValue.Text = "" Then
                    _dgView.DgSearch(_columnNumber).EndFindValue = Nothing
                Else
                    If dataType = IFindableControl.DataTypeEnum.Decimal Then
                        Dim value As Decimal
                        If Not Decimal.TryParse(txtEndValue.Text, value) Then
                            DialogResult = DialogResult.Cancel
                            MessagingLibrary.Messaging.Show(True, "MsgInvalidDecimalValue")
                        Else
                            _dgView.DgSearch(_columnNumber).BegFindValue = txtEndValue.Text
                        End If
                    Else
                        Dim value As Integer
                        If Not Integer.TryParse(txtEndValue.Text, value) Then
                            MessagingLibrary.Messaging.Show(True, "MsgInvalidIntegerValue")
                        Else
                            _dgView.DgSearch(_columnNumber).BegFindValue = txtEndValue.Text
                        End If
                    End If
                End If
            End If
        ElseIf dataType = IFindableControl.DataTypeEnum.Boolean Then
            _dgView.DgSearch(_columnNumber).SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
            _dgView.DgSearch(_columnNumber).BegFindValue = chkChecked.Checked
        End If
        Close()
    End Sub

    'Private Function GetColumnSearchModeType(dataGridViewColumn As DataGridViewColumn) As Object
    '    If TypeOf dataGridViewColumn.CellTemplate Is DataGridViewTextBoxCell Then
    '        Return IFindableControl.SearchModeEnum.TextBox
    '    ElseIf TypeOf dataGridViewColumn.CellTemplate Is DataGridViewComboBoxCell Then
    '        Return IFindableControl.SearchModeEnum.ComboBox
    '    ElseIf TypeOf dataGridViewColumn.CellTemplate Is DataGridViewComboBoxCell Then
    '        Return IFindableControl.SearchModeEnum.ComboBox
    '    End If
    '    Return IFindableControl.SearchModeEnum.TextBox
    'End Function

    Private Sub SetFormLocation()
        Dim pnt As Point
        Dim formLocation As Point
        Dim screenRectangle As Rectangle
        SetFormSize()
        screenRectangle = Screen.PrimaryScreen.WorkingArea
        StartPosition = FormStartPosition.Manual
        pnt = _formPosition
        If GlobalVariables.RightToLeftLayout Then
            formLocation = New Point(pnt.X - Width - _controlWidth, pnt.Y)
        Else
            formLocation = New Point(pnt.X, pnt.Y)
        End If
        Dim horizontalCoordinateOutsideScreen As Boolean = False
        If formLocation.X < 0 Then
            formLocation.X = 0
            horizontalCoordinateOutsideScreen = True
        End If

        If formLocation.X + Width > screenRectangle.Width Then
            formLocation.X = screenRectangle.Width - Width
            horizontalCoordinateOutsideScreen = True
            ' set to true if form will not fit on the right
        End If
        If formLocation.Y < 0 Then
            formLocation.Y = 0
        End If
        If formLocation.Y + Height > screenRectangle.Height Then
            formLocation.Y = formLocation.Y - Height
        Else
            If horizontalCoordinateOutsideScreen Then
                ' move down so as not to cover the field to be searched
                formLocation.Y = formLocation.Y + _controlHeight
            End If
        End If
        Location = formLocation
    End Sub

    Private Sub CFindForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetFormLocation()
        'Dim searchModeType = GetColumnSearchModeType(_dgView.Columns(_columnNumber))
        If SearchMode = IFindableControl.SearchModeEnum.ComboBox Then
            'lblLookFor1.Visible = False
            'lblLookFor2.Visible = True
            'lblLookFor3.Visible = False
            'lblLookFor4.Visible = False
            TxtTextToSearch.Visible = False
            cboTextToSearch.Visible = True
            RBtnAnywhere.Visible = False
            RBtnStart.Visible = False
            RBtnExactMatch.Visible = False
            cboTextToSearch.DataSource = FindDataSource
            cboTextToSearch.DisplayMember = FindDisplayMember
            cboTextToSearch.ValueMember = FindValueMember
            dtpBegDate.Visible = False
            dtpEndDate.Visible = False
            lblTo1.Visible = False
            chkChecked.Visible = False
            txtBegValue.Visible = False
            txtEndValue.Visible = False
            Height = 165
        Else
            SetupDisplay()
        End If
    End Sub

    Private Sub SetFormSize()
        If _dgView.FindDataType = IFindableControl.DataTypeEnum.String Then
            Height = 270
        ElseIf _dgView.FindDataType = IFindableControl.DataTypeEnum.Date Then
            Height = 160
        ElseIf _dgView.FindDataType = IFindableControl.DataTypeEnum.Decimal Or _dgView.FindDataType = IFindableControl.DataTypeEnum.Integer Then
            Height = 160
        ElseIf _dgView.FindDataType = IFindableControl.DataTypeEnum.Boolean Then
            Height = 175
            Width = 200
        End If
    End Sub

    Private Sub SetupDisplay()
        If _dgView.FindDataType = IFindableControl.DataTypeEnum.String Then
            'lblLookFor1.Visible = True
            'lblLookFor2.Visible = False
            'lblLookFor3.Visible = False
            'lblLookFor4.Visible = False
            'lblLookFor5.Visible = False
            TxtTextToSearch.Visible = True
            cboTextToSearch.Visible = False
            RBtnAnywhere.Visible = True
            RBtnStart.Visible = True
            RBtnExactMatch.Visible = True
            dtpBegDate.Visible = False
            dtpEndDate.Visible = False
            txtBegValue.Visible = False
            txtEndValue.Visible = False
            lblTo1.Visible = False
            chkChecked.Visible = False
            lblIgnoreCase.Visible = True
            chkIgnoreCase.Visible = True
            TxtTextToSearch.Focus()
        ElseIf _dgView.FindDataType = IFindableControl.DataTypeEnum.Date Then
            dtpBegDate.Visible = True
            dtpEndDate.Visible = True
            dtpBegDate.Focus()
            dtpBegDate.Select()
            'lblLookFor1.Visible = False
            'lblLookFor2.Visible = False
            'lblLookFor3.Visible = True
            'lblLookFor4.Visible = False
            TxtTextToSearch.Visible = False
            cboTextToSearch.Visible = False
            RBtnExactMatch.Visible = False
            RBtnAnywhere.Visible = False
            RBtnStart.Visible = False
            lblTo1.Visible = True
            chkChecked.Visible = False
            txtBegValue.Visible = False
            txtEndValue.Visible = False
        ElseIf _dgView.FindDataType = IFindableControl.DataTypeEnum.Decimal Or
                   _dgView.FindDataType = IFindableControl.DataTypeEnum.Integer Then
            dtpBegDate.Visible = False
            dtpEndDate.Visible = False
            TxtTextToSearch.Visible = False
            cboTextToSearch.Visible = False
            RBtnExactMatch.Visible = False
            RBtnAnywhere.Visible = False
            RBtnStart.Visible = False
            lblTo1.Visible = True
            chkChecked.Visible = False
            txtBegValue.Visible = True
            txtEndValue.Visible = True
            txtBegValue.Focus()
            txtBegValue.Select()
        ElseIf _dgView.FindDataType = IFindableControl.DataTypeEnum.Boolean Then
            'lblLookFor4.Visible = True
            chkChecked.Visible = True
            dtpBegDate.Visible = False
            dtpEndDate.Visible = False
            'lblLookFor1.Visible = False
            'lblLookFor2.Visible = False
            'lblLookFor3.Visible = False
            TxtTextToSearch.Visible = False
            cboTextToSearch.Visible = False
            RBtnExactMatch.Visible = False
            RBtnAnywhere.Visible = False
            RBtnStart.Visible = False
            lblTo1.Visible = False
            txtBegValue.Visible = False
            txtEndValue.Visible = False
        End If
    End Sub

    Private Sub txtBegValue_ValueChanged(sender As Object, e As EventArgs) Handles txtBegValue.Validated
        If txtBegValue.Text > txtEndValue.Text Then
            txtEndValue.Text = txtBegValue.Text
        ElseIf txtEndValue.Text Is Nothing Then
            txtEndValue.Text = txtBegValue.Text
        End If
    End Sub

    Private Sub dtpBegDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpBegDate.Validated
        If dtpBegDate.Value > dtpEndDate.Value Then
            dtpEndDate.Value = dtpBegDate.Value
        ElseIf dtpEndDate.Value Is Nothing Then
            dtpEndDate.Value = dtpBegDate.Value
        End If
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.Validated
        If dtpEndDate.Value IsNot Nothing AndAlso dtpEndDate.Value < dtpBegDate.Value Then
            dtpBegDate.Value = dtpEndDate.Value
        End If
    End Sub

    Public Sub SetFieldDescription(fieldDescription As String)
        txtFieldToSearch.Text = fieldDescription
    End Sub

    Enum SearchModeEnum
        [TextBox]
        [Date]
        [ComboBox]
        [CheckBox]
    End Enum

    Public Enum SearchPlaceEnum
        [StartOfField]
        [AnywhereOnField]
        [ExactValue]
    End Enum

    Enum DataTypeEnum
        [String]
        [Date]
        [DateTime]
        [Integer]
        [Decimal]
        [Boolean]
    End Enum

    Public Property SearchLocation As SearchPlaceEnum
        Get
            If RBtnAnywhere.Checked Then
                Return SearchPlaceEnum.AnywhereOnField
            ElseIf RBtnExactMatch.Checked Then
                Return SearchPlaceEnum.ExactValue
            ElseIf RBtnStart.Checked Then
                Return SearchPlaceEnum.StartOfField
            Else
                Return SearchPlaceEnum.AnywhereOnField
            End If
        End Get
        Set(value As SearchPlaceEnum)
            If value = SearchPlaceEnum.AnywhereOnField Then
                RBtnAnywhere.Checked = True
            ElseIf SearchPlaceEnum.ExactValue Then
                RBtnExactMatch.Checked = True
            ElseIf SearchPlaceEnum.StartOfField Then
                RBtnStart.Checked = True
            Else
                RBtnAnywhere.Checked = False
                RBtnExactMatch.Checked = False
                RBtnStart.Checked = False
            End If
        End Set
    End Property

End Class


'Public Interface IFindableGrid
'    Property FindDataType As DataTypeEnum
'    Property FindEnabled As Boolean
'    Property BegFindValue As Object
'    Property EndFindValue As Object
'    Property SearchPlace As SearchPlaceEnum
'    Property FieldName As String
'    Property FieldDescription As String
'    Property IgnoreCase As Boolean
'    ReadOnly Property FindDataSource As Object
'    ReadOnly Property FindDisplayMember As String
'    ReadOnly Property SearchMode As SearchModeEnum
'    ReadOnly Property FindValueMember As String

'    Enum SearchModeEnum
'        [TextBox]
'        [Date]
'        [ComboBox]
'        [CheckBox]
'    End Enum

'    Enum SearchPlaceEnum
'        [StartOfField]
'        [AnywhereOnField]
'        [ExactValue]
'    End Enum

'    Enum DataTypeEnum
'        [String]
'        [Date]
'        [DateTime]
'        [Integer]
'        [Decimal]
'        [Boolean]
'    End Enum

'End Interface