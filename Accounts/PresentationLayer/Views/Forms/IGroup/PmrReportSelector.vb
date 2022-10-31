Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class PmrReportSelector

    Private ReadOnly _findableControl As IFindableControl

    Public Sub New(findableControl As IFindableControl)

        ' This call is required by the designer.
        InitializeComponent()
        _findableControl = findableControl
        Dim ctrl As Control
        'Dim formPoint As Point
        'Dim ctrlPoint As Point
        ctrl = DirectCast(findableControl, Control)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub CLabel1_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    'Public Function GetTextToSearch() As String
    '    Return TextToSearch
    'End Function

    'Public Function GetSearchPlace() As String
    '    Return SearchPlace
    'End Function

    Private Sub BtnFind_Click(sender As Object, e As EventArgs)
        DialogResult = DialogResult.OK
        'If _findableControl.FindDataType = IFindableControl.DataTypeEnum.String Then
        '    _findableControl.BegFindValue = TxtTextToSearch.Text
        '    If _findableControl.SearchMode = IFindableControl.SearchModeEnum.ComboBox Then
        '        _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
        '        _findableControl.BegFindValue = cboTextToSearch.SelectedValue
        '    ElseIf rbRadiology.Checked Then
        '        _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
        '    Else
        '        _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.AnywhereOnField
        '    End If
        '    If chkIgnoreCase.Checked Then
        '        _findableControl.IgnoreCase = True
        '    Else
        '        _findableControl.IgnoreCase = False
        '    End If
        'ElseIf _findableControl.FindDataType = IFindableControl.DataTypeEnum.Date Then
        '    If _findableControl.SearchMode = IFindableControl.SearchModeEnum.ComboBox Then
        '        _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
        '        _findableControl.BegFindValue = cboTextToSearch.SelectedValue
        '    Else
        '        _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
        '        _findableControl.BegFindValue = dtpBegDate.Value
        '        _findableControl.EndFindValue = dtpEndDate.Value
        '    End If
        'ElseIf _findableControl.FindDataType = IFindableControl.DataTypeEnum.Decimal Or _findableControl.FindDataType = IFindableControl.DataTypeEnum.Integer Then
        '    If _findableControl.SearchMode = IFindableControl.SearchModeEnum.ComboBox Then
        '        _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
        '        _findableControl.BegFindValue = cboTextToSearch.SelectedValue
        '    Else
        '        _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
        '        If txtBegValue.Text Is Nothing OrElse txtBegValue.Text = "" Then
        '            _findableControl.BegFindValue = Nothing
        '        Else
        '            If _findableControl.FindDataType = IFindableControl.DataTypeEnum.Decimal Then
        '                Dim value As Decimal
        '                If Not Decimal.TryParse(txtBegValue.Text, value) Then
        '                    MessagingLibrary.Messaging.Show(True, "MsgInvalidDecimalValue")
        '                    DialogResult = DialogResult.Cancel
        '                Else
        '                    _findableControl.BegFindValue = txtBegValue.Text
        '                End If
        '            Else
        '                Dim value As Integer
        '                If Not Integer.TryParse(txtBegValue.Text, value) Then
        '                    MessagingLibrary.Messaging.Show(True, "MsgInvalidIntegerValue")
        '                Else
        '                    _findableControl.BegFindValue = txtBegValue.Text
        '                End If
        '            End If
        '        End If
        '        If txtEndValue.Text Is Nothing OrElse txtEndValue.Text = "" Then
        '            _findableControl.EndFindValue = Nothing
        '        Else
        '            If _findableControl.FindDataType = IFindableControl.DataTypeEnum.Decimal Then
        '                Dim value As Decimal
        '                If Not Decimal.TryParse(txtEndValue.Text, value) Then
        '                    DialogResult = DialogResult.Cancel
        '                    MessagingLibrary.Messaging.Show(True, "MsgInvalidDecimalValue")
        '                Else
        '                    _findableControl.EndFindValue = txtEndValue.Text
        '                End If
        '            Else
        '                Dim value As Integer
        '                If Not Integer.TryParse(txtEndValue.Text, value) Then
        '                    MessagingLibrary.Messaging.Show(True, "MsgInvalidIntegerValue")
        '                Else
        '                    _findableControl.EndFindValue = txtEndValue.Text
        '                End If
        '            End If
        '        End If
        '    End If
        'ElseIf _findableControl.FindDataType = IFindableControl.DataTypeEnum.Boolean Then
        '    _findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
        '    _findableControl.BegFindValue = chkChecked.Checked
        'End If
        Close()
    End Sub

End Class