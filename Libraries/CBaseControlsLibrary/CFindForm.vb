Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class CFindForm
    Inherits CForm

    Private _textToSearch As String
    Private _searchPlace As SearchPlaceEnum
    Private _begDateToSearch As Date?
    Private _endDateToSearch As Date?
    Private _formPosition As Point
    Private _controlHeight As Int16
    Private _controlWidth As Int16
    Private ReadOnly _findableControl As IFindableControl
    Private _dgFindColumnNo As Int16

    Public Sub New(findableControl As IFindableControl)

        ' This call is required by the designer.
        InitializeComponent()
        _findableControl = findableControl

        'If TypeOf findableControl Is CtDataGridView Then
        '    _dgFindColumnNo = DirectCast(findableControl, CtDataGridView).FindColumnNo
        'End If
        Dim ctrl As Control
        Dim formPoint As Point
        'Dim ctrlPoint As Point
        ctrl = DirectCast(findableControl, Control)
        'ctrlPoint = New Point(ctrl.Location.X + ctrl.Width, ctrl.Location.Y)
        'formPoint = ctrl.PointToScreen(ctrlPoint)
        _formPosition.X = formPoint.X
        _formPosition.Y = formPoint.Y
        _controlHeight = ctrl.Height
        _controlWidth = ctrl.Width

        Dim pnt As Point = ctrl.PointToScreen(New Point(0 + ctrl.Width, 0))
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
        DialogResult = DialogResult.OK
        If _findableControl.FindDataType = IFindableControl.DataTypeEnum.String Then
            _findableControl.BegFindValue = TxtTextToSearch.Text
            If _findableControl.SearchMode = IFindableControl.SearchModeEnum.ComboBox Then
                _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
                If TypeOf _findableControl IsNot CdtComboBox Then
                    _findableControl.BegFindValue = cboTextToSearch.SelectedValue
                    _findableControl.EndFindValue = cboTextToSearch.SelectedValue
                Else
                    _findableControl.BegFindValue = cbtTextToSearch.SelectedValue
                    _findableControl.EndFindValue = cbtTextToSearch.SelectedValue
                End If
            ElseIf RBtnStart.Checked Then
                _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.StartOfField
            ElseIf RBtnExactMatch.Checked Then
                _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
            Else
                _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.AnywhereOnField
            End If
            If chkIgnoreCase.Checked Then
                _findableControl.IgnoreCase = True
            Else
                _findableControl.IgnoreCase = False
            End If
        ElseIf _findableControl.FindDataType = IFindableControl.DataTypeEnum.Date Then
            If _findableControl.SearchMode = IFindableControl.SearchModeEnum.ComboBox Then
                _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
                If TypeOf _findableControl IsNot CdtComboBox Then
                    _findableControl.BegFindValue = cboTextToSearch.SelectedValue
                    _findableControl.EndFindValue = cboTextToSearch.SelectedValue
                Else
                    _findableControl.BegFindValue = cbtTextToSearch.SelectedValue
                    _findableControl.EndFindValue = cbtTextToSearch.SelectedValue
                End If
            Else
                _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
                _findableControl.BegFindValue = dtpBegDate.Value
                _findableControl.EndFindValue = dtpEndDate.Value
            End If
        ElseIf _findableControl.FindDataType = IFindableControl.DataTypeEnum.Decimal Or _findableControl.FindDataType = IFindableControl.DataTypeEnum.Integer Then
            If _findableControl.SearchMode = IFindableControl.SearchModeEnum.ComboBox Then
                _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
                If TypeOf _findableControl IsNot CdtComboBox Then
                    _findableControl.BegFindValue = cboTextToSearch.SelectedValue
                    _findableControl.EndFindValue = cboTextToSearch.SelectedValue
                Else
                    _findableControl.BegFindValue = cbtTextToSearch.SelectedValue
                    _findableControl.EndFindValue = cbtTextToSearch.SelectedValue
                End If
            Else
                _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
                If txtBegValue.Text Is Nothing OrElse txtBegValue.Text = "" Then
                    _findableControl.BegFindValue = Nothing
                Else
                    If _findableControl.FindDataType = IFindableControl.DataTypeEnum.Decimal Then
                        Dim value As Decimal
                        If Not Decimal.TryParse(txtBegValue.Text, value) Then
                            MessagingLibrary.Messaging.Show(True, "MsgInvalidDecimalValue")
                            DialogResult = DialogResult.Cancel
                        Else
                            _findableControl.BegFindValue = txtBegValue.Text
                        End If
                    Else
                        Dim value As Integer
                        If Not Integer.TryParse(txtBegValue.Text, value) Then
                            MessagingLibrary.Messaging.Show(True, "MsgInvalidIntegerValue")
                        Else
                            _findableControl.BegFindValue = txtBegValue.Text
                        End If
                    End If
                End If
                If txtEndValue.Text Is Nothing OrElse txtEndValue.Text = "" Then
                    _findableControl.EndFindValue = Nothing
                Else
                    If _findableControl.FindDataType = IFindableControl.DataTypeEnum.Decimal Then
                        Dim value As Decimal
                        If Not Decimal.TryParse(txtEndValue.Text, value) Then
                            DialogResult = DialogResult.Cancel
                            MessagingLibrary.Messaging.Show(True, "MsgInvalidDecimalValue")
                        Else
                            _findableControl.EndFindValue = txtEndValue.Text
                        End If
                    Else
                        Dim value As Integer
                        If Not Integer.TryParse(txtEndValue.Text, value) Then
                            MessagingLibrary.Messaging.Show(True, "MsgInvalidIntegerValue")
                        Else
                            _findableControl.EndFindValue = txtEndValue.Text
                        End If
                    End If
                End If
            End If
        ElseIf _findableControl.FindDataType = IFindableControl.DataTypeEnum.Boolean Then
            _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
            _findableControl.BegFindValue = chkChecked.Checked
        End If
        Close()
    End Sub

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
        If _findableControl.SearchMode = IFindableControl.SearchModeEnum.ComboBox Then
            'lblLookFor1.Visible = False
            'lblLookFor2.Visible = True
            'lblLookFor3.Visible = False
            'lblLookFor4.Visible = False
            TxtTextToSearch.Visible = False
            If TypeOf _findableControl IsNot CdtComboBox Then
                cboTextToSearch.Visible = True
                cboTextToSearch.DataSource = _findableControl.FindDataSource
                cboTextToSearch.DisplayMember = _findableControl.FindDisplayMember
                cboTextToSearch.ValueMember = _findableControl.FindValueMember
                cboTextToSearch.EditingMode = True
                cbtTextToSearch.Visible = False
            Else
                cbtTextToSearch.Visible = True
                cbtTextToSearch.DataSource = _findableControl.FindDataSource
                cbtTextToSearch.DisplayMember = _findableControl.FindDisplayMember
                cbtTextToSearch.ValueMember = _findableControl.FindValueMember
                cbtTextToSearch.EditingMode = True
                cboTextToSearch.Visible = False
            End If
            RBtnAnywhere.Visible = False
            RBtnStart.Visible = False
            RBtnExactMatch.Visible = False
            dtpBegDate.Visible = False
            dtpEndDate.Visible = False
            lblTo1.Visible = False
            chkChecked.Visible = False
            txtBegValue.Visible = False
            txtEndValue.Visible = False
            dtpBegDate.EditingMode = True
            chkChecked.EditingMode = True
            Height = 200
        Else
            SetupDisplay()
        End If
    End Sub

    Private Sub SetFormSize()
        If _findableControl.FindDataType = IFindableControl.DataTypeEnum.String Then
            Height = 300
        ElseIf _findableControl.FindDataType = IFindableControl.DataTypeEnum.Date Then
            Height = 200
        ElseIf _findableControl.FindDataType = IFindableControl.DataTypeEnum.Decimal Or _findableControl.FindDataType = IFindableControl.DataTypeEnum.Integer Then
            Height = 200
        ElseIf _findableControl.FindDataType = IFindableControl.DataTypeEnum.Boolean Then
            Height = 200
        End If
    End Sub

    Private Sub SetupDisplay()
        If _findableControl.FindDataType = IFindableControl.DataTypeEnum.String Then
            TxtTextToSearch.Visible = True
            cboTextToSearch.Visible = False
            cbtTextToSearch.Visible = False
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
        ElseIf _findableControl.FindDataType = IFindableControl.DataTypeEnum.Date Then
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
            cbtTextToSearch.Visible = False
            RBtnExactMatch.Visible = False
            RBtnAnywhere.Visible = False
            RBtnStart.Visible = False
            lblTo1.Visible = True
            chkChecked.Visible = False
            txtBegValue.Visible = False
            txtEndValue.Visible = False
        ElseIf _findableControl.FindDataType = IFindableControl.DataTypeEnum.Decimal Or
                   _findableControl.FindDataType = IFindableControl.DataTypeEnum.Integer Then
            dtpBegDate.Visible = False
            dtpEndDate.Visible = False
            TxtTextToSearch.Visible = False
            cboTextToSearch.Visible = False
            cbtTextToSearch.Visible = False
            RBtnExactMatch.Visible = False
            RBtnAnywhere.Visible = False
            RBtnStart.Visible = False
            lblTo1.Visible = True
            chkChecked.Visible = False
            txtBegValue.Visible = True
            txtEndValue.Visible = True
            txtBegValue.Focus()
            txtBegValue.Select()
        ElseIf _findableControl.FindDataType = IFindableControl.DataTypeEnum.Boolean Then
            'lblLookFor4.Visible = True
            chkChecked.Visible = True
            dtpBegDate.Visible = False
            dtpEndDate.Visible = False
            'lblLookFor1.Visible = False
            'lblLookFor2.Visible = False
            'lblLookFor3.Visible = False
            TxtTextToSearch.Visible = False
            cboTextToSearch.Visible = False
            cbtTextToSearch.Visible = False
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

    Private Enum SearchPlaceEnum
        Anywhere
        ExactMatch
        Start
    End Enum

    Public Sub SetFieldDescription(fieldDescription As String)
        txtFieldToSearch.Text = fieldDescription
    End Sub

    Private Sub Gtin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTextToSearch.KeyPress
        If _findableControl.FieldName = "GTIN" Then
            Dim i As Integer = TxtTextToSearch.SelectionStart 'save for later use
            Select Case Asc(e.KeyChar)
                Case 29 'GS
                    TxtTextToSearch.Text = TxtTextToSearch.Text.Insert(TxtTextToSearch.SelectionStart, "<GS>")
                    TxtTextToSearch.SelectionStart = i + 5
                    e.Handled = True
            End Select
        End If
    End Sub

    Private Sub txtGTIN_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtTextToSearch.Validating
        If TxtTextToSearch.Text.Contains("<GS>") Then
            TxtTextToSearch.Text = ExtractGTin(TxtTextToSearch.Text)
        End If
    End Sub

    Private Function ExtractGTin(cText As String) As String
        Dim dataLength = Len(cText)
        Dim i As Int16 = 0
        Dim ai As String = Mid(cText, 1, 2)
        Dim lastPosition As Int16 = 2
        Dim GTin As String = Nothing
        While lastPosition < dataLength
            Select Case ai
                Case "01" 'GTIN
                    GTin = Mid(cText, lastPosition + 1, 14)
                    lastPosition += 14
                Case "17" 'Expiry Date
                    lastPosition += 6
                Case "11" 'manufacture date
                    lastPosition += 6
                Case "10" ' Batch Number
                    For i = lastPosition + 1 To dataLength
                        If Mid(cText, i, 4) = "<GS>" Or Mid(cText, i, 1) = ChrW(13) Or i >= dataLength Then ' separator
                            lastPosition = i + 3
                            Exit For
                        End If
                    Next
                Case "21" ' Serialization No.
                    For i = lastPosition + 1 To dataLength
                        If Mid(cText, i, 4) = "<GS>" Or Mid(cText, i, 1) = ChrW(13) Or i >= dataLength Then
                            lastPosition = i + 3
                            Exit For
                        End If
                    Next
            End Select
            If GTin IsNot Nothing OrElse lastPosition >= dataLength Then
                Exit While
            Else
                ai = Mid(cText, lastPosition + 1, 2)
                If ai = vbLf Or ai = vbCrLf Or ai = vbLf & vbCr Then
                    Exit While
                End If
                lastPosition += 2
            End If
        End While
        Return GTin

    End Function

End Class