Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Security.Cryptography.X509Certificates

Public Class MyComboboxForm

    Public Property MyTable As New DataTable
    Public Property MyTable2 As New DataTable
    Private _initializing As Boolean = True

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        MyTable.Columns.Add("Value", GetType(String))

        With MyTable.Rows
            .Add("server123")
            .Add("server456")
            .Add("computer")
            .Add("terminal33")
            .Add("client34 ")
        End With

        MyTable2.Columns.Add("Value", GetType(String))

        With MyTable2.Rows
            .Add("server123")
            .Add("server456")
            .Add("computer")
            .Add("terminal33")
            .Add("client34 ")
        End With


        BindingSource1.DataSource = MyTable
        With ComboBox1
            .DisplayMember = "Value"
            .DataSource = BindingSource1

            'Binding will select the first item so we must explicitly clear it.
            .SelectedItem = Nothing
            .Text = Nothing
        End With

        With ComboBox2
            .DisplayMember = "Value"
            .DataSource = BindingSource1
            '.DropDownStyle = ComboBoxStyle.DropDown
            '.AutoCompleteMode = AutoCompleteMode.Suggest
            '.AutoCompleteCustomSource = AutoCompleteSource
            'Binding will select the first item so we must explicitly clear it.
            .SelectedItem = Nothing
            .Text = Nothing
        End With

        AddHandler ComboBox1.SelectedValueChanged, Sub(s, e)
                                                       ComboBox1.BeginInvoke(DirectCast(Sub()
                                                                                            ComboBox1.SelectionStart = ComboBox1.Text.Length
                                                                                        End Sub, MethodInvoker))
                                                   End Sub

        _initializing = False
    End Sub


    'Private _filterOld As String = Nothing
    'Private _filterNew As String = Nothing
    'Private _flag As Int16 = 0

    'Private Sub combobox2_textchanged(sender As Object, e As EventArgs) Handles ComboBox2.TextChanged
    '    If _flag = 1 Then
    '        _flag = 0
    '        Return
    '    End If
    '    'modifying the filter will replace the text so we must change it back again afterwards.
    '    Dim ctext As String = ComboBox2.Text
    '    Dim selectionstart = ComboBox2.SelectionStart
    '    _filterNew = ctext
    '    If _filterOld Is Nothing OrElse _filterNew <> _filterOld Then
    '        _filterOld = _filterNew
    '        'filter the drop-down list if and only if the user has entered some non-whitespace text.
    '        If String.IsNullOrWhiteSpace(ctext) Then
    '            BindingSource1.Filter = Nothing
    '        Else
    '            BindingSource1.Filter = String.Format("value like '*{0}*'", ctext)
    '        End If
    '        _flag = 0
    '        ComboBox2.Text = ctext
    '        ComboBox2.SelectionStart = selectionstart
    '        BindingSource1.ResetBindings(True)
    '        'ctext = Nothing
    '        ''MyTable2.DefaultView.RowFilter = Nothing
    '        'Else
    '        '    'MyTable2.DefaultView.RowFilter = String.Format("value like '*{0}*'", text)
    '        'End If
    '        ''combobox2.datasource = mytable
    '        'combobox2.displaymember = "value"
    '        'combobox2.valuemember = "value"
    '        'if not combobox1.droppeddown then
    '        '    combobox1.droppeddown = true
    '        'end if
    '    End If
    'End Sub

    'Private Sub MyComboboxForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    'End Sub




    'Private _downSwitch As Int16 = 0

    'Protected Overloads Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
    '    Dim flag As Int16 = 0
    '    If KeysToHandle.Contains(keyData) Then
    '        If ComboBox1.DroppedDown Then

    '            If keyData = Keys.Down Then
    '                If _downSwitch = 0 Then
    '                    'keyData = 0 ' make sure the action wont be duplicated
    '                    Dim c As Int16 = ComboBox1.Items.Count()
    '                    Dim x As Int16 = ComboBox1.SelectedIndex
    '                    If x + 1 >= c Then
    '                        ComboBox1.SelectedIndex = c - 1
    '                    Else
    '                        ComboBox1.SelectedIndex = x + 1
    '                    End If
    '                    flag = 1
    '                    _downSwitch = 1
    '                End If
    '                'ComboBox1.SelectedIndex = ComboBox1.SelectedIndex + 1
    '                'Return False
    '            Else
    '                _downSwitch = 0
    '                'If ComboBox1.SelectedIndex = ComboBox1.SelectedIndex +
    '                '    Flag = True Then
    '                '    combo.Dropdown
    '                'Else
    '                '    combo.Value = combo.ItemData(0)
    '                '    Flag = True
    '                '    combo.Dropdown
    '                'End If
    '            End If
    '            'Return True
    '        End If

    '        If _downSwitch = 1 Then
    '            _downSwitch = _downSwitch + 1
    '            Return False
    '        ElseIf _downSwitch > 1 Then
    '            Return False
    '        Else
    '            Return MyBase.ProcessCmdKey(msg, keyData)
    '        End If
    '    Else
    '        Return MyBase.ProcessCmdKey(msg, keyData)
    '    End If
    'End Function

    Private _flag As Int16 = 0
    Private _selectedText As String = ""
    Private Sub combobox1_textchanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        'Modifying the filter will replace the text so we must change it back again afterwards.
        If Not _initializing Then
            If _flag = 0 Then
                With ComboBox1
                    Dim text = .Text
                    Dim selectionStart = .SelectionStart

                    'Filter the drop-down list if and only if the user has entered some non-whitespace text.
                    BindingSource1.Filter = If(String.IsNullOrWhiteSpace(text),
                                       Nothing,
                                       String.Format("Value LIKE '*{0}*'",
                                                     text))
                    Dim y = .SelectedItem()
                    _flag = 1
                    .Text = text
                    _flag = 0
                    '.SelectionStart = selectionStart
                    .DroppedDown = True
                End With
            End If
        End If
    End Sub

    Private Sub combobox1_indexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Modifying the filter will replace the text so we must change it back again afterwards.
        If Not _initializing Then
            With ComboBox1
                .SelectionStart = 0 'IIf(Len(.Text) <= 0, 0, Len(.Text))
                .SelectionLength = 0
                .[Select](Len(.Text), Len(.Text))
            End With
        End If
    End Sub

    Private Sub comboBox1_DropDownClosed(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox1.DropDownClosed
        Me.BeginInvoke(New Action(Function()
                                      ComboBox1.[Select](Len(ComboBox1.Text), Len(ComboBox1.Text))
                                  End Function))
    End Sub

    Private _x As Int16 = 0

    Private Sub cbxMake_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ComboBox1.MouseClick
        Dim x As String = ComboBox1.SelectedItem
        BindingSource1.Filter = Nothing
        ComboBox1.DroppedDown = True
        ComboBox1.SelectedItem = x
    End Sub

    'Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.
    '    If Not _initializing Then
    '        _x = _x + 1
    '    End If
    'End Sub

    'Private Shared ReadOnly KeysToHandle As Keys() = {Keys.Down, Keys.Up, Keys.Enter, Keys.Escape}

    'Private _downSwitch As Int16 = 0
    'Private _flag As Int16 = 0
    'Protected Overloads Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
    '    If KeysToHandle.Contains(keyData) Then
    '        If ComboBox1.DroppedDown Then
    '            If ComboBox1.DroppedDown AndAlso KeysToHandle.Contains(keyData) Then

    '                If keyData = Keys.Down Then
    '                    If _downSwitch = 0 Then
    '                        'keyData = 0 ' make sure the action wont be duplicated
    '                        Dim c As Int16 = ComboBox1.Items.Count()
    '                        Dim x As Int16 = ComboBox1.SelectedIndex
    '                        If x + 1 >= c Then
    '                            ComboBox1.SelectedIndex = c - 1
    '                        Else
    '                            ComboBox1.SelectedIndex = x + 1
    '                        End If
    '                        _flag = 1
    '                        _downSwitch = 1
    '                    End If
    '                    'ComboBox1.SelectedIndex = ComboBox1.SelectedIndex + 1
    '                    'Return False
    '                Else
    '                    _downSwitch = 0
    '                    'If ComboBox1.SelectedIndex = ComboBox1.SelectedIndex +
    '                    '    Flag = True Then
    '                    '    combo.Dropdown
    '                    'Else
    '                    '    combo.Value = combo.ItemData(0)
    '                    '    Flag = True
    '                    '    combo.Dropdown
    '                    'End If
    '                End If
    '                'Return True
    '            End If

    '            If _downSwitch = 1 Then
    '                _downSwitch = _downSwitch + 1
    '                Return False
    '            ElseIf _downSwitch > 1 Then
    '                Return False
    '            Else
    '                Return MyBase.ProcessCmdKey(msg, keyData)
    '            End If
    '        Else
    '            Return MyBase.ProcessCmdKey(msg, keyData)
    '        End If
    '    End If

    '    Dim flag As Int16 = 0
    '    If ComboBox1.DroppedDown AndAlso KeysToHandle.Contains(keyData) Then

    '        If keyData = Keys.Down Then
    '            If _downSwitch = 0 Then
    '                'keyData = 0 ' make sure the action wont be duplicated
    '                Dim c As Int16 = ComboBox1.Items.Count()
    '                Dim x As Int16 = ComboBox1.SelectedIndex
    '                If x + 1 >= c Then
    '                    ComboBox1.SelectedIndex = c - 1
    '                Else
    '                    ComboBox1.SelectedIndex = x + 1
    '                End If
    '                flag = 1
    '                _downSwitch = 1
    '            End If
    '            'ComboBox1.SelectedIndex = ComboBox1.SelectedIndex + 1
    '            'Return False
    '        Else
    '            _downSwitch = 0
    '            'If ComboBox1.SelectedIndex = ComboBox1.SelectedIndex +
    '            '    Flag = True Then
    '            '    combo.Dropdown
    '            'Else
    '            '    combo.Value = combo.ItemData(0)
    '            '    Flag = True
    '            '    combo.Dropdown
    '            'End If
    '        End If
    '        'Return True
    '    End If

    '    If _downSwitch = 1 Then
    '        _downSwitch = _downSwitch + 1
    '        Return False
    '    ElseIf _downSwitch > 1 Then
    '        Return False
    '    Else
    '        Return MyBase.ProcessCmdKey(msg, keyData)
    '    End If
    'End Function


    'Private Sub ComboBox2_TextChanged(sender As Object, e As EventArgs) Handles ComboBox2.TextChanged
    '    If ComboBox2.DroppedDown Then
    '        Dim text = ComboBox2.Text
    '        Dim selectionStart = ComboBox1.SelectionStart
    '        Dim selectionLength = ComboBox1.SelectionLength

    '        ComboBox2.DroppedDown = False
    '        ComboBox2.Text = text
    '        ComboBox2.SelectionStart = selectionStart
    '        ComboBox2.SelectionLength = selectionLength
    '    End If
    'End Sub



End Class


'Class SurroundingClass
'    Public Class ComboFillBox
'        Public Property Name As String
'        Public Property Value As Integer
'    End Class

'    Private dataList As List(Of ComboFillBox)

'    Private Sub cmbComboBox_TextUpdate(ByVal sender As Object, ByVal e As EventArgs)
'        Dim strForSearch As String = cmbComboBox.Text

'        If strForSearch.Length > 0 Then
'            Dim searchData As List(Of ComboFillBox) = dataList.Where(Function(x) x.Name.Contains(strForSearch)).ToList()

'            If searchData.Count() > 0 Then
'                cmbComboBox.DataSource = searchData
'                cmbComboBox.DroppedDown = True
'            Else
'                cmbComboBox.DroppedDown = False
'            End If
'        Else
'            cmbComboBox.DataSource = dataList
'            cmbComboBox.DroppedDown = True
'        End If

'        cmbComboBox.DisplayMember = "Name"
'        cmbComboBox.ValueMember = "Value"
'        cmbComboBox.Text = strForSearch
'        cmbComboBox.SelectionStart = strForSearch.Length
'        cmbComboBox.SelectionLength = 0
'    End Sub
'End Class


Public Class ThreadingHelpers
    Public Shared Function GetText(ByVal comboBox As ComboBox) As String
        If comboBox.InvokeRequired Then
            Return CStr(comboBox.Invoke(New Func(Of String)(Function() GetText(comboBox))))
        End If
        SyncLock comboBox
            Return comboBox.Text
        End SyncLock
    End Function

    Public Shared Sub SetText(ByVal comboBox As ComboBox, ByVal text As String)
        If comboBox.InvokeRequired Then
            comboBox.Invoke(New Action(Sub() SetText(comboBox, text)))
            Return
        End If

        SyncLock comboBox
            comboBox.Text = text
        End SyncLock
    End Sub
End Class