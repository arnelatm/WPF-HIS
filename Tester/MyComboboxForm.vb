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

        MyTable.Columns.Add("IdNo", GetType(String))
        MyTable.Columns.Add("Name", GetType(String))
        MyTable.Columns.Add("Code", GetType(String))
        MyTable.DefaultView.Sort = "Name"

        With MyTable.Rows
            .Add(2, "United Arab Emirates ", "AA")
            .Add(3, "Afghanistan", "AF")
            .Add(4, "Antigua and Barbuda", "AG")
            .Add(5, "Anguilla", "AI")
            .Add(6, "Albania", "AL")
            .Add(7, "Armenia", "AM")
            .Add(8, "Netherlands Antilles", "AN")
            .Add(9, "Angola", "AO")
            .Add(10, "Antarctica", "AQ")
            .Add(11, "Argentina", "AR")
            .Add(12, "American Samoa", "AS")
            .Add(13, "Austria", "AT")
            .Add(14, "Australia", "AU")
            .Add(15, "Aruba", "AW")
            .Add(16, "Aland Islands", "AX")
            .Add(17, "Azerbaijan", "AZ")
            .Add(18, "Bosnia and Herzegovina", "BA")
            .Add(19, "Barbados", "BB")
            .Add(20, "Bangladesh", "BD")
            .Add(21, "Belgium", "BE")
            .Add(22, "Burkina Faso", "BF")
            .Add(23, "Bulgaria", "BG")
            .Add(24, "Bahrain", "BH")
            .Add(25, "Burundi", "BI")
            .Add(26, "Benin", "BJ")
            .Add(27, "Saint Barthelemy1", "BL")
            .Add(28, "Bermuda", "BM")
            .Add(29, "Brunei Darussalam", "BN")
            .Add(30, "Bolivia", "BO")
            .Add(31, "Brazil", "BR")
            .Add(32, "Bahamas", "BS")
            .Add(33, "Bhutan", "BT")
            .Add(34, "Bouvet Island", "BV")
            .Add(35, "Botswana", "BW")
            .Add(36, "Belarus", "BY")
            .Add(37, "Belize", "BZ")
            .Add(38, "Canada", "CA")
            .Add(39, "Cocos (Keeling) Islands", "CC")
            .Add(40, "Central African Republic", "CF")
            .Add(41, "Congo", "CG")
            .Add(42, "Switzerland", "CH")
            .Add(43, "Ivory Coast", "CI")
            .Add(44, "Cook Islands", "CK")
            .Add(45, "Chile", "CL")
            .Add(46, "Cameroon", "CM")
            .Add(47, "China", "CN")
            .Add(48, "Colombia", "CO")
            .Add(49, "Costa Rica", "CR")
            .Add(50, "Cuba", "CU")
            .Add(51, "Cape Verde", "CV")
            .Add(52, "Cura‡ao", "CW")
            .Add(53, "Christmas Island", "CX")
            .Add(54, "Cyprus", "CY")
            .Add(55, "Czech Republic", "CZ")
            .Add(56, "Germany", "DE")
            .Add(57, "Djibouti", "DJ")
            .Add(58, "Denmark", "DK")
            .Add(59, "Dominica", "DM")
            .Add(60, "Dominican Republic", "DO")
            .Add(61, "Algeria", "DZ")
            .Add(62, "Ecuador", "EC")
            .Add(63, "Estonia", "EE")
            .Add(64, "Egypt", "EG")
            .Add(65, "Western Sahara", "EH")
            .Add(66, "Eritrea", "ER")
            .Add(67, "Spain", "ES")
            .Add(68, "Ethiopia", "ET")
            .Add(69, "Finland", "FI")
            .Add(70, "Fiji", "FJ")
            .Add(71, "Falkland Islands (Malvinas)", "FK")
            .Add(72, "Micronesia", "FM")
            .Add(73, "Faroe Islands", "FO")
            .Add(74, "France", "FR")
            .Add(75, "Gabon", "GA")
            .Add(76, "United Kingdom", "GB")
            .Add(77, "Grenada", "GD")
            .Add(78, "Georgia", "GE")
            .Add(79, "French Guiana", "GF")
            .Add(80, "Guernsey", "GG")
            .Add(81, "Ghana", "GH")
            .Add(82, "Gibraltar", "GI")
            .Add(83, "Greenland", "GL")
            .Add(84, "Gambia", "GM")
            .Add(85, "Guinea", "GN")
            .Add(86, "Guadeloupe", "GP")
            .Add(87, "Equatorial Guinea", "GQ")
            .Add(88, "Greece", "GR")
            .Add(89, "South Georgia and the South Sandwich", "GS")
            .Add(90, "Guatemala", "GT")
            .Add(91, "Guam", "GU")
            .Add(92, "Guinea-Bissau", "GW")
            .Add(93, "Guyana", "GY")
            .Add(94, "Hong Kong", "HK")
            .Add(95, "Heard and Mc Donald Islands", "HM")
            .Add(96, "Honduras", "HN")
            .Add(97, "Croatia", "HR")
            .Add(98, "Haiti", "HT")
            .Add(99, "Hungary", "HU")
            .Add(100, "Indonesia", "ID")
            .Add(101, "Ireland", "IE")
            .Add(102, "Israel", "IL")
            .Add(103, "Isle of Man", "IM")
            .Add(104, "India", "IN")
            .Add(105, "British Indian Ocean Territory", "IO")
            .Add(106, "Iraq", "IQ")
            .Add(107, "Iran", "IR")
            .Add(108, "Iceland", "IS")
            .Add(109, "Italy", "IT")
            .Add(110, "Jersey", "JE")
            .Add(111, "Jamaica", "JM")
            .Add(112, "Jordan", "JO")
            .Add(113, "Japan", "JP")
            .Add(114, "Kenya", "KE")
            .Add(115, "Kyrgyzstan", "KG")
            .Add(116, "Cambodia", "KH")
            .Add(117, "Kiribati", "KI")
            .Add(118, "Comoros", "KM")
            .Add(119, "Saint Kitts and Nevis", "KN")
            .Add(120, "Korea(North Korea)", "KP")
            .Add(121, "Korea(South Korea)", "KR")
            .Add(122, "Kuwait", "KW")
            .Add(123, "Cayman Islands", "KY")
            .Add(124, "Kazakhstan", "KZ")
            .Add(125, "Lao PDR", "LA")
            .Add(126, "Lebanon", "LB")
            .Add(127, "Saint Pierre and Miquelon", "LC")
            .Add(128, "Liechtenstein", "LI")
            .Add(129, "Sri Lanka", "LK")
            .Add(130, "Liberia", "LR")
            .Add(131, "Lesotho", "LS")
            .Add(132, "Lithuania", "LT")
            .Add(133, "Luxembourg", "LU")
            .Add(134, "Latvia", "LV")
            .Add(135, "Libya", "LY")
            .Add(136, "Morocco", "MA")
            .Add(137, "Monaco", "MC")
            .Add(138, "Moldova", "MD")
            .Add(139, "Montenegro", "ME")
            .Add(140, "Saint Martin (French part)", "MF")
            .Add(141, "Madagascar", "MG")
            .Add(142, "Marshall Islands", "MH")
            .Add(143, "Macedonia", "MK")
            .Add(144, "Mali", "ML")
            .Add(145, "Myanmar", "MM")
            .Add(146, "Mongolia", "MN")
            .Add(147, "Macau", "MO")
            .Add(148, "Northern Mariana Islands", "MP")
            .Add(149, "Martinique", "MQ")
            .Add(150, "Mauritania", "MR")
            .Add(151, "Montserrat", "MS")
            .Add(152, "Malta", "MT")
            .Add(153, "Mauritius", "MU")
            .Add(154, "Maldives", "MV")
            .Add(155, "Malawi", "MW")
            .Add(156, "Mexico", "MX")
            .Add(157, "Malaysia", "MY")
            .Add(158, "Mozambique", "MZ")
            .Add(159, "Namibia", "NA")
            .Add(160, "New Caledonia", "NC")
            .Add(161, "Niger", "NE")
            .Add(162, "Norfolk Island", "NF")
            .Add(163, "Nigeria", "NG")
            .Add(164, "Nicaragua", "NI")
            .Add(165, "Netherlands", "NL")
            .Add(166, "Norway", "NO")
            .Add(167, "Nepal", "NP")
            .Add(168, "Nauru", "NR")
            .Add(169, "Niue", "NU")
            .Add(170, "New Zealand", "NZ")
            .Add(171, "Oman", "OM")
            .Add(172, "Panama", "PA")
            .Add(173, "Peru", "PE")
            .Add(174, "French Polynesia", "PF")
            .Add(175, "Papua New Guinea", "PG")
            .Add(176, "Philippines", "PH")
            .Add(177, "Pakistan", "PK")
            .Add(178, "Poland", "PL")
            .Add(179, "Pitcairn", "PN")
            .Add(180, "Puerto Rico", "PR")
            .Add(181, "Palestine", "PS")
            .Add(182, "Portugal", "PT")
            .Add(183, "Palau", "PW")
            .Add(184, "Paraguay", "PY")
            .Add(185, "Qatar", "QA")
            .Add(186, "Reunion Island", "RE")
            .Add(187, "Romania", "RO")
            .Add(188, "Serbia", "RS")
            .Add(189, "Russian", "RU")
            .Add(190, "Rwanda", "RW")
            .Add(191, "Saudi Arabia", "SA")
            .Add(192, "Solomon Islands", "SB")
            .Add(193, "Seychelles", "SC")
            .Add(194, "Sudan", "SD")
            .Add(195, "Sweden", "SE")
            .Add(196, "Singapore", "SG")
            .Add(197, "Saint Helena", "SH")
            .Add(198, "Slovenia", "SI")
            .Add(199, "Svalbard and Jan Mayen", "SJ")
            .Add(200, "Slovakia", "SK")
            .Add(201, "Sierra Leone", "SL")
            .Add(202, "San Marino", "SM")
            .Add(203, "Senegal", "SN")
            .Add(204, "Somalia", "SO")
            .Add(205, "Suriname", "SR")
            .Add(206, "South Sudan", "SS")
            .Add(207, "Sao Tome and Principe", "ST")
            .Add(208, "El Salvador", "SV")
            .Add(209, "Sint Maarten (Dutch part)", "SX")
            .Add(210, "Syria", "SY")
            .Add(211, "Swaziland", "SZ")
            .Add(212, "Turks and Caicos Islands", "TC")
            .Add(213, "Chad", "TD")
            .Add(214, "French Southern and Antarctic Lands", "TF")
            .Add(215, "Togo", "TG")
            .Add(216, "Thailand", "TH")
            .Add(217, "Tajikistan", "TJ")
            .Add(218, "Tokelau", "TK")
            .Add(219, "Timor-Leste", "TL")
            .Add(220, "Turkmenistan", "TM")
            .Add(221, "Tunisia", "TN")
            .Add(222, "Tonga", "TO")
            .Add(223, "Turkey", "TR")
            .Add(224, "Trinidad and Tobago", "TT")
            .Add(225, "Tuvalu", "TV")
            .Add(226, "Taiwan", "TW")
            .Add(227, "Tanzania", "TZ")
            .Add(228, "Ukraine", "UA")
            .Add(229, "Uganda", "UG")
            .Add(230, "US Minor Outlying Islands", "UM")
            .Add(231, "United States", "US")
            .Add(232, "Uruguay", "UY")
            .Add(233, "Uzbekistan", "UZ")
            .Add(234, "Vatican City", "VA")
            .Add(235, "Saint Vincent and the Grenadines", "VC")
            .Add(236, "Venezuela", "VE")
            .Add(237, "Virgin Islands (U.S.)", "VI")
            .Add(238, "Vietnam", "VN")
            .Add(239, "Vanuatu", "VU")
            .Add(240, "Wallis and Futuna Islands", "WF")
            .Add(241, "Samoa", "WS")
            .Add(242, "Kosovo", "XK")
            .Add(243, "Yemen", "YE")
            .Add(244, "Mayotte", "YT")
            .Add(245, "South Africa", "ZA")
            .Add(246, "Zambia", "ZM")
            .Add(247, "Zimbabwe", "ZW")
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
            .DisplayMember = "Name"
            .ValueMember = "IdNo"
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
                                       String.Format("Name LIKE '*{0}*'",
                                                     text))
                    Dim y = .SelectedItem()
                    _flag = 1
                    .Text = text
                    _flag = 0
                    '.SelectionStart = selectionStart
                    If .SelectedIndex > 0 Then
                        If .Text = DirectCast(.SelectedItem, System.Data.DataRowView).Row.ItemArray(2) Then
                            .DroppedDown = False
                        Else
                            .DroppedDown = True
                        End If
                    Else
                        .DroppedDown = True
                    End If
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
                .[Select](Math.Max(0, Len(.Text) - 1), Math.Max(Len(.Text), 0))
            End With
        End If
    End Sub

    Private Sub comboBox1_DropDownClosed(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox1.DropDownClosed
        Me.BeginInvoke(New Action(Function()
                                      ComboBox1.[Select](Math.Max(0, Len(ComboBox1.Text)), Math.Max(Len(ComboBox1.Text), 0))
                                  End Function))
    End Sub

    Private _x As Int16 = 0

    Private Sub cbxMake_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ComboBox1.MouseClick
        Dim x As DataRowView = ComboBox1.SelectedItem()
        BindingSource1.Filter = Nothing
        ComboBox1.DroppedDown = True
        ComboBox1.SelectedItem = x
    End Sub

    'Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.
    '    If Not _initializing Then
    '        _x = _x + 1
    '    End If
    'End Sub

    Private Shared ReadOnly KeysToHandle As Keys() = {Keys.Down, Keys.Up, Keys.Enter, Keys.Escape, Keys.Back, Keys.Delete}

    Private _downSwitch As Int16 = 0
    Private _sw As Int16 = 0
    Protected Overloads Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If KeysToHandle.Contains(keyData) Then
            If ComboBox1.DroppedDown Then
                If ComboBox1.DroppedDown AndAlso KeysToHandle.Contains(keyData) Then

                    If keyData = Keys.Down Then
                        If _downSwitch = 0 Then
                            'keyData = 0 ' make sure the action wont be duplicated
                            Dim c As Int16 = ComboBox1.Items.Count()
                            Dim x As Int16 = ComboBox1.SelectedIndex
                            If x + 1 >= c Then
                                ComboBox1.SelectedIndex = c - 1
                            Else
                                ComboBox1.SelectedIndex = x + 1
                            End If
                            _flag = 1
                            _downSwitch = 1
                        End If
                        'ComboBox1.SelectedIndex = ComboBox1.SelectedIndex + 1
                        Return False
                    Else
                        _downSwitch = 0
                        'If ComboBox1.SelectedIndex = ComboBox1.SelectedIndex +
                        '    Flag = True Then
                        '    combo.Dropdown
                        'Else
                        '    combo.Value = combo.ItemData(0)
                        '    Flag = True
                        '    combo.Dropdown
                        'End If
                    End If
                    'Return True
                End If

                If _downSwitch = 1 Then
                    _downSwitch = _downSwitch + 1
                    Return False
                ElseIf _downSwitch > 1 Then
                    Return False
                Else
                    Return MyBase.ProcessCmdKey(msg, keyData)
                End If
            Else
                Return MyBase.ProcessCmdKey(msg, keyData)
            End If
        End If

        Dim flag As Int16 = 0
        If ComboBox1.DroppedDown AndAlso KeysToHandle.Contains(keyData) Then

            If keyData = Keys.Down Then
                If _downSwitch = 0 Then
                    'keyData = 0 ' make sure the action wont be duplicated
                    Dim c As Int16 = ComboBox1.Items.Count()
                    Dim x As Int16 = ComboBox1.SelectedIndex
                    If x + 1 >= c Then
                        ComboBox1.SelectedIndex = c - 1
                    Else
                        ComboBox1.SelectedIndex = x + 1
                    End If
                    flag = 1
                    _downSwitch = 1
                End If
                'ComboBox1.SelectedIndex = ComboBox1.SelectedIndex + 1
                'Return False
            Else
                _downSwitch = 0
                'If ComboBox1.SelectedIndex = ComboBox1.SelectedIndex +
                '    Flag = True Then
                '    combo.Dropdown
                'Else
                '    combo.Value = combo.ItemData(0)
                '    Flag = True
                '    combo.Dropdown
                'End If
            End If
            'Return True
        End If

        If _downSwitch = 1 Then
            _downSwitch = _downSwitch + 1
            Return False
        ElseIf _downSwitch > 1 Then
            Return False
        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
    End Function


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