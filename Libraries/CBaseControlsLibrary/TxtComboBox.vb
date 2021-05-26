Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class TxtComboBox
    Implements IEntryControl, ILinkedLabel

    Private _text As String = ""
    Private _dataSource As Object
    Private _valueMember As String
    Private _displayMember As String
    Private _selectedIndexProgrammaticChange As Boolean = False
    Private _dataSourceIsAnEnum As Boolean = False
    Private _dataSourceIsBoolean As Boolean = False
    Private _defaultValue As String = ""
    Private _displayOnly As Boolean
    Private _translatable As Boolean = False

    Public Event TcbLostFocus(sender As Object, e As EventArgs)

    Private _editingMode As Boolean = True
    Private _originalValue As Integer = 0

    'Private _fixedDataSource As Boolean = True
    Private _editsALlowed As Boolean = False

    Public Sub New()
        'This call Is required by the designer.
        InitializeComponent()
        Height = 22
        With txtReadOnly
            .DisplayOnly = True
            .ReadOnly = True
            .BringToFront()
            .SelectionLength = 0
            .Height = Height - 1
        End With
        With cboComboBox
            .Left = 0
            .Top = 0
            .Height = Height - 1
            .Width = Width
            .Enabled = Enabled
            .Visible = True
            .Name = "Cbo" + Mid(Name, 4)
            .DisplayOnly = DisplayOnly
            '.DataSource = DataSource
            .SelectionLength = 0
        End With
        With TxtTextBox
            .Left = 0
            .Top = 0
            .Height = Height - 1
            .Width = Width
            .Enabled = Enabled
            .DisplayOnly = DisplayOnly
            .Visible = False
            .Name = "Txt" + Mid(Name, 4)
            .SelectionLength = 0
        End With

        'Add any initialization after the InitializeComponent() call.
    End Sub

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(String))>
    <Description("The text associated with the control.")>
    <Browsable(True)>
    Public Overrides Property Text As String
        Get
            Return _text
        End Get
        Set
            _text = Value
            _selectedIndexProgrammaticChange = True
            UpdateValues(Value)
            _selectedIndexProgrammaticChange = False
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Object))>
    <Description("Indicates the property to use as the actual value for the items in the control.")>
    <Browsable(True)>
    Public Property ValueMember As String
        Get
            If _valueMember Is Nothing Or _valueMember = "" Then
                _valueMember = "IdNo"
                cboComboBox.ValueMember = _valueMember
            End If
            Return _valueMember
        End Get
        Set
            If Value Is Nothing Or Value = "" Then
                Value = "IdNo"
            End If
            _valueMember = Value
            cboComboBox.ValueMember = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True if the data source is an Enum")>
    <Browsable(True)>
    Public Property DataSourceIsAnEnum As Boolean
        Get
            Return _dataSourceIsAnEnum
        End Get
        Set
            _dataSourceIsAnEnum = Value
            If Value Then
                TcbTextBox.Visible = False
            End If
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True if the data source Data Type is an Boolean")>
    <Browsable(True)>
    Public Property DataSourceIsBoolean As Boolean
        Get
            Return _dataSourceIsBoolean
        End Get
        Set
            _dataSourceIsBoolean = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Object))>
    <Description("Indicates the property to display for the items in this control")>
    <Browsable(True)>
    Public Property DisplayMember As Object
        Get
            If _displayMember Is Nothing Or _displayMember = "" Then
                _displayMember = "Name"
                cboComboBox.DisplayMember = _displayMember
            End If
            Return _displayMember
        End Get
        Set
            If Value Is Nothing Or Value = "" Then
                Value = "Name"
            End If
            cboComboBox.DisplayMember = Value
            'If System.ComponentModel.LicenseManager.UsageMode <> System.ComponentModel.LicenseUsageMode.Designtime Then
            '    If GlobalVariables.RightToLeftLayout Then
            '        If Value Is Nothing Then
            '            _displayMember = Value
            '        Else
            '            _displayMember = GetTranslatedField(Value)
            '        End If
            '    Else
            '        _displayMember = Value
            '    End If
            'End If
            'cboComboBox.DisplayMember = _displayMember
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Object))>
    <Description("Indicates the list that this control will use to get its items.")>
    <Browsable(True)>
    Public Property DataSource As Object
        Get
            Return _dataSource
        End Get
        Set
            _dataSource = Value
            cboComboBox.DataSource = Value
            cboComboBox.OriginalDataSource = Value
            cboComboBox.OriginalList = Nothing
        End Set
    End Property

    Public Property TcbTextBox As CTextBox
        Get
            Return TxtTextBox
        End Get
        Set
            TxtTextBox = Value
            Text = TxtTextBox.Text
        End Set
    End Property

    Public Property TcbComboBox As CComboBox
        Get
            Return cboComboBox
        End Get
        Set
            cboComboBox = Value
        End Set
    End Property

    Private Sub TcbComboBox_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        TxtTextBox.Width = Width
        cboComboBox.Width = Width
        txtReadOnly.Width = Width
        TxtTextBox.Height = Height
        cboComboBox.Height = Height
        txtReadOnly.Height = Height
    End Sub

    Private Sub TcbComboBox_IndexChanged(sender As Object, e As EventArgs) Handles cboComboBox.SelectedIndexChanged
        TxtTextBox.Text = cboComboBox.Text
        If Not TcbComboBox.DatasourceProgrammaticChange Or Not _selectedIndexProgrammaticChange Then
            If cboComboBox.SelectedValue Is Nothing Then
                Text = Nothing
            Else
                If cboComboBox.SelectedValue.GetType().IsValueType OrElse cboComboBox.SelectedValue.GetType().Name = "String" Then
                    Text = cboComboBox.SelectedValue.ToString()
                Else
                    Text = GetPropertyValue(cboComboBox.SelectedValue, ValueMember)
                End If
            End If
        End If
        SelectedIndex = cboComboBox.SelectedIndex
    End Sub

    'Private sub TcbGotFocus(sender As Object, e As EventArgs) Handles cboComboBox.GotFocus
    '    DisplayMember = "Name"
    'End sub

    Private Sub TcbComboBox_LostFocus(sender As Object, e As EventArgs) Handles cboComboBox.LostFocus
        If cboComboBox.SelectedValue Is Nothing Then
            Text = Nothing
        Else
            'Dim cText As String = ""
            'cText = cboComboBox.SelectedValue.ToString()
            'Text = cText
        End If
        'DisplayMember = "Code"
        RaiseEvent TcbLostFocus(sender, e)
        'cboComboBox.DataSource = DataSource
    End Sub

    Private Sub UpdateValues(value As String)
        _selectedIndexProgrammaticChange = True
        Dim displayedText = ""
        'If NaToLower() = "txtparentidno" then
        '    Debugger.Break()
        'End If
        If String.IsNullOrWhiteSpace(value) Then
            cboComboBox.SelectedIndex = -1
            'txtReadOnly.Text = Nothing
        Else
            Dim lDisplayedText = False
            'dim i As Integer = 0
            If _dataSource IsNot Nothing Then
                For Each dataObj In _dataSource
                    If GetPropertyValue(dataObj, ValueMember) IsNot Nothing Then
                        If GetPropertyValue(dataObj, ValueMember).ToString() = value.ToString() Then
                            displayedText = GetPropertyValue(dataObj, DisplayMember.ToString())
                            lDisplayedText = True
                            Exit For
                        End If
                    End If
                    'i = i + 1
                Next
            End If
            If lDisplayedText Then
                'cboComboBox.SelectedIndex = i
                'cboComboBox.Text = displayedText
                'txtReadOnly.Text = displayedText
                cboComboBox.SelectedIndex = cboComboBox.FindStringExact(displayedText)
                'cboComboBox.SelectedIndex = 1
            Else
                cboComboBox.SelectedIndex = -1
            End If
        End If
        txtReadOnly.Text = displayedText
        _selectedIndexProgrammaticChange = False
    End Sub

    Public Property EnumConverter As TypeConverter

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(String))>
    <Description("The text associated with the control.")>
    <Browsable(True)>
    Public Property DefaultValue As String
        Get
            Return _defaultValue
        End Get
        Set
            _defaultValue = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(String))>
    <Description("Set to True to make this control Read Only")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set(value As Boolean)
            _displayOnly = value
            'EditingMode = value
            cboComboBox.DisplayOnly = value
            TxtTextBox.DisplayOnly = value
        End Set
    End Property

    <Category("Custom Properties")>
    <Description("Select the label to which this control is linked.")>
    <Browsable(True)>
    Public Property LinkedLabel As CLabel Implements ILinkedLabel.LinkedLabel

    Public Sub MakeDefault()
        Text = _defaultValue
    End Sub

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            cboComboBox.EditingMode = value
            TxtTextBox.EditingMode = value
            If value Or DisplayOnly Then
                cboComboBox.DropDownStyle = ComboBoxStyle.Simple
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                txtReadOnly.Text = cboComboBox.Text
                txtReadOnly.BringToFront()
                txtReadOnly.TabStop = True
                cboComboBox.Visible = False
                cboComboBox.TabStop = False
                TxtTextBox.TabStop = False
            Else
                cboComboBox.DropDownStyle = ComboBoxStyle.DropDown
                cboComboBox.Visible = True
                ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                cboComboBox.SelectedText = Nothing
                cboComboBox.Visible = True
                txtReadOnly.SendToBack()
                cboComboBox.Visible = True
                cboComboBox.TabStop = True
                cboComboBox.SelectionLength = 0
                TxtTextBox.TabStop = False
                txtReadOnly.TabStop = False
            End If
        End Set
    End Property

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(value As Boolean)
            _translatable = value
        End Set
    End Property

    'Public Sub MakeEditable(editableControl As Boolean) Implements IEntryControl.MakeEditable
    '    EditsAllowed = Not editableControl
    'End Sub

    Public Property EditsAllowed As Boolean
        Get
            Return _editsALlowed
        End Get
        Set(value As Boolean)
            _originalValue = cboComboBox.SelectedIndex
        End Set
    End Property

    'Public Sub MakeVisible(visibleControl As Boolean) Implements IEntryControl.MakeVisible
    '    TxtTextBox.MakeVisible(visibleControl)
    '    cboComboBox.MakeVisible(visibleControl)
    'End Sub

    Public Property SelectedIndex As Integer

    Private Sub txtComboBox_LostFocus(sender As Object, e As EventArgs) Handles cboComboBox.LostFocus
        cboComboBox.DataSource = DataSource
    End Sub

    Public Function GetControlDescription(Optional defaultDescription As String = Nothing) Implements ILinkedLabel.GetControlDescription
        Dim description As String
        If LinkedLabel Is Nothing OrElse LinkedLabel.Text Is Nothing OrElse LinkedLabel.Text = "" Then
            description = If(defaultDescription Is Nothing OrElse defaultDescription = "", Name, defaultDescription)
        Else
            description = LinkedLabel.Text
        End If
        Return description
    End Function

    'Public Sub MakeViewable(ViewableControl As Boolean) Implements IEntryControl.MakeViewable
    '    If ViewableControl
    '       TxtTextBox.PasswordChar = "*"
    '    End If
    'End Sub

    'Public Sub MakeSelectable(selectableControl As Boolean) Implements IEntryControl.MakeSelectable
    '    Enabled = selectableControl
    'End Sub

    'Private Sub cboComboBox_Enter(sender As Object, e As EventArgs) Handles cboComboBox.Enter
    '    cboCombobox.DataSource = DataSource
    'End Sub

    'Private Sub cboComboBox_DataSourceChanged(sender As Object, e As EventArgs) Handles cboComboBox.DataSourceChanged
    '    cboComboBox.
    'End Sub
End Class