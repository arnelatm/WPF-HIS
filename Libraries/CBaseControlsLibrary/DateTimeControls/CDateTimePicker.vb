Imports System.ComponentModel
Imports System.Windows.Forms

Public Class CDateTimePicker
    Inherits DateTimePicker
    'Private _valueIsNull As Boolean
    'Private _textToSearch As String
    'Private _searchPlace As Char
    'Private _minimumDate As Date?
    'Private _lastDate As Date = Today()
    'Private _origCultureStr As String

    'Public Sub New()
    '    ' create a DATE variable from that string in a known format:
    '    Dim dMinDate As Date = Me.MinDate
    '    Dim newDate As Date = DateTime.ParseExact(, "dd-MM-yyyy", Globalization.CultureInfo.InvariantCulture)
    '    Me.MinimumDate = newDate
    '    Me.MinDate = newDate
    'End Sub

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is read only.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean = False

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is read only.")>
    <Browsable(True)>
    Public Property ReadOnlyDp As Boolean = True

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is mandatory.")>
    <Browsable(True)>
    Public Property ValueIsMandatory As Boolean

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String

    '<Bindable(True)>
    '<Category("Properties")>
    '<DefaultValue(GetType(Boolean))>
    '<Description("Set this to the Lowest possible date allowed for this control (don't use MinDate) that will be used for null dates.")>
    '<Browsable(True)>
    'Public Property MinimumDate() As Date?
    '    Get
    '        Return _MinimumDate
    '    End Get
    '    Set(ByVal value As Date?)
    '        _MinimumDate = value
    '    End Set
    'End Property

    Public Property DefaultValue As Object

    'Private Sub CDateTimePicker_GotFocus(sender As Object, e As EventArgs) Handles Me.DropDown
    '    _OrigCultureStr = System.Threading.Thread.CurrentThread.CurrentCulture.Name
    '    Dim curGregCulture = GlobalVariables.DefaultUnmirroredCultureInfoStr
    '    System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(curGregCulture)
    '    Me.Refresh()
    'End Sub

    'Private Sub CDateTimePicker_LostFocus(sender As Object, e As EventArgs) Handles Me.CloseUp
    '    System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(_OrigCultureStr)
    'End Sub

    'Public Shadows Property Value() As Date?
    '    Get
    '        Return MyBase.Value
    '    End Get
    '    Set(ByVal newValue As Date?)
    '        If newValue.HasValue Then
    '            ' newValue is not null (nothing)
    '            MyBase.Value = newValue.Value
    '        Else
    '            MyBase.Value = MinimumDate
    '        End If
    '    End Set
    'End Property

    'Private Sub CDateTimePicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ValueChanged
    '    If Me.ReadOnlyDP Then
    '        Me.Value = LastDate
    '    End If
    '    LastDate = Value
    'End Sub

    'Private Sub CDateTimePicker_DropDown(sender As Object, e As EventArgs) Handles Me.DropDown
    '    LastDate = Value
    'End Sub

    'Private Sub CDateTimePicker_GotFocus()
End Class

#Region "LastOK"

'Imports System.ComponentModel
'Imports System.Drawing
'Imports System.Windows.Forms
'Imports System.Windows.Forms.VisualStyles

'Public Class CDateTimePicker
'    Inherits System.Windows.Forms.DateTimePicker
'    Private oldFormat As DateTimePickerFormat = DateTimePickerFormat.Short
'    Private oldCustomFormat As String = Nothing
'    Private _NullCustomFormat As String = " "
'    Private _NonNullFormat As String
'    Private _NonNullCustomFormat As String
'    Private _ValueIsNull As Boolean
'    Private _displayOnly As Boolean = False
'    Public IsNull As Boolean = False
'    Private _TextDate As String
'    Private _IsReadOnly As Boolean
'    Private _ReadOnlyDP As Boolean = True
'    Private _DefaultValue As Object
'    Private _IsMandatory As Boolean
'    Private _TextToSearch As String
'    Private _SearchPlace As Char
'    Private _IsNullable As Boolean
'    Private _SecurityKey As String
'    Private _backDisabledColor As Color
'    Private _isInternalValueChanging = False

'    Public Sub New()
'        MyBase.New()
'        CausesValidation = True
'        ValueIsNullable = True
'        Format = DateTimePickerFormat.Short
'        _NonNullFormat = Me.Format
'        _NonNullCustomFormat = Me.CustomFormat
'    End Sub

'    ''' <summary>
'    ''' The Value that this Property will hold which can be a  NULL (nothing) value
'    ''' To make this control hold a value the property must be declared as nullable that
'    ''' is why the presence of the "?" in the end of the Date
'    ''' Also the Value property cannot also be set to NULL value so if the value is null
'    ''' set the Value property to the MINDATE (minimum date) value so that no error will occur
'    ''' so basically if the VALUEISNULL is true we will consider this vale as null
'    ''' </summary>
'    ''' <returns></returns>
'    Public Shadows Property Value() As Date?
'        Get
'            If Me.ValueIsNull Then
'                If Me.ValueIsNullable Then
'                    Return Me.MinDate
'                Else
'                    Me.ValueIsNull = False
'                    Return Me.DefaultValue
'                End If
'            Else
'                Return MyBase.Value
'            End If
'        End Get
'        Set(ByVal newValue As Date?)
'            If newValue.HasValue Then
'                Me.ValueIsNull = False
'                ' newValue is not null (nothing)
'                Me.Format = _NonNullFormat
'                Me.CustomFormat = _NonNullCustomFormat
'                MyBase.Value = newValue.Value
'            Else
'                Me.ValueIsNull = True
'                ' newValue is null (nothing)
'                If Me.ValueIsNullable Then
'                    Me.Format = DateTimePickerFormat.Custom
'                    Me.CustomFormat = _NullCustomFormat
'                    MyBase.Value = Nothing ' Me.MinDate
'                Else
'                    ' Value is not nullable (so don't accept null values)
'                    ' the following code sets the value to a non null value
'                    ' that is entered in the Me.DefaultValue property
'                    ' and if that value is null this will set it to the
'                    ' <Me.MinDate>
'                    MyBase.Value = Me.DefaultValue
'                    Me.Format = _NonNullFormat
'                    Me.CustomFormat = _NonNullCustomFormat
'                End If
'            End If
'        End Set
'    End Property

'    ''' <summary>
'    ''' Allows the user to select a new date if the control is already null.
'    ''' </summary>
'    ''' <param name="eventargs"></param>
'    ''' <remarks></remarks>
'    Protected Overrides Sub OnCloseUp(ByVal eventargs As System.EventArgs)
'        If Control.MouseButtons = Windows.Forms.MouseButtons.None Then
'            If Me.ValueIsNull Then
'                Me.Format = _NonNullFormat
'                Me.CustomFormat = _NonNullCustomFormat
'                Me.ValueIsNull = False
'            End If
'        End If
'        MyBase.OnCloseUp(eventargs)
'    End Sub

'    ''' <summary>
'    ''' Overrides the base class implementation to allow the user to create a Null value by pressing the Delete key.
'    ''' </summary>
'    ''' <param name="e"></param>
'    ''' <remarks></remarks>
'    '''     Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
'    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
'        MyBase.OnKeyUp(e)
'        If Me.ValueIsNullable AndAlso e.KeyCode = Keys.Delete Then
'            Me.Value = MinDate
'            Me.ValueIsNull = True
'        ElseIf ValueIsNull And (e.KeyCode = Keys.Space OrElse Char.IsNumber(ChrW(e.KeyValue)) OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Left) Then
'            Me.ValueIsNull = False
'            If Me.ValueIsNullable Then
'                Me.Value = Me.DefaultValue
'            Else
'                If Me.DefaultValue.HasValue Then
'                    Me.Value = Me.DefaultValue
'                Else
'                    Me.Value = Today()
'                End If
'            End If
'        End If
'    End Sub

'    ''' <summary>
'    ''' create a cheat to display a cursor like character when value is null
'    ''' </summary>
'    ''' <param name="e"></param>
'    Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
'        MyBase.OnGotFocus(e)
'        If Me.ValueIsNull Then
'            CustomFormat = "|"
'        End If
'    End Sub

'    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
'        If Me.ValueIsNull Then
'            CustomFormat = _NullCustomFormat
'        End If
'    End Sub

'    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
'        MyBase.OnKeyDown(e)
'        If Me.ValueIsNullable AndAlso e.KeyCode = Keys.Delete Then
'            Me.Value = MinDate
'            ValueIsNull = True
'        ElseIf ValueIsNull Then
'            _isInternalValueChanging = True
'            If e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Left Then
'                Me.Value = Me.DefaultValue
'                ValueIsNull = False
'            ElseIf (Char.IsNumber(ChrW(e.KeyValue)) AndAlso e.KeyValue <> 48) OrElse (e.KeyValue >= 97 AndAlso e.KeyValue <= 105) Then
'                Dim typedDigit As Integer = 1
'                If e.KeyValue >= 97 AndAlso e.KeyValue <= 105 Then
'                    typedDigit = Integer.Parse((ChrW((e.KeyValue - 48))).ToString())
'                Else
'                    typedDigit = Integer.Parse((ChrW(e.KeyValue)).ToString())
'                End If
'                Me.Value = DefaultValue
'                SendKeys.SendWait("{RIGHT}")
'                SendKeys.Send(typedDigit.ToString())
'            End If
'            _isInternalValueChanging = False
'        End If
'    End Sub

'    <Bindable(True)>
'    <Category("Properties")>
'    <DefaultValue(GetType(Boolean))>
'    <Description("Set to True to specify that this control is read only.")>
'    <Browsable(True)>
'    Public Property DisplayOnly() As Boolean
'        Get
'            Return _displayOnly
'        End Get
'        Set(ByVal value As Boolean)
'            _displayOnly = value
'        End Set
'    End Property

'    <Bindable(True)>
'    <Category("Properties")>
'    <DefaultValue(GetType(Boolean))>
'    <Description("Set to True to specify that this control is read only.")>
'    <Browsable(True)>
'    Public Property ReadOnlyDP() As Boolean
'        Get
'            Return _ReadOnlyDP
'        End Get
'        Set(ByVal value As Boolean)
'            _ReadOnlyDP = value
'        End Set
'    End Property

'    <Bindable(True)>
'    <Category("Properties")>
'    <DefaultValue(GetType(Boolean))>
'    <Description("Set to True to specify that this control is mandatory.")>
'    <Browsable(True)>
'    Public Property ValueIsMandatory() As Boolean
'        Get
'            Return _IsMandatory
'        End Get
'        Set(ByVal value As Boolean)
'            _IsMandatory = value
'        End Set
'    End Property

'    <Bindable(True)>
'    <Category("Properties")>
'    <DefaultValue(GetType(Boolean))>
'    <Description("Security Key to use for this control.")>
'    <Browsable(True)>
'    Public Property SecurityKey() As String
'        Get
'            Return _SecurityKey
'        End Get
'        Set(ByVal value As String)
'            _SecurityKey = value
'        End Set
'    End Property

'    Public Property ValueIsNullable() As Boolean
'        Get
'            Return _IsNullable
'        End Get
'        Set(ByVal value As Boolean)
'            _IsNullable = value
'        End Set
'    End Property

'    Public Property DefaultValue() As Object
'        Get
'            Return _DefaultValue
'        End Get
'        Set(ByVal Value As Object)
'            If Value Is Nothing AndAlso Me.ValueIsNullable Then
'                _DefaultValue = Nothing
'            ElseIf Value Is Nothing Then
'                ' if it passes here Me.ValueIsNullable is False
'                ' so just assigned Today's date as the default value
'                _DefaultValue = Today()
'            Else ' value is not Null ('nothing')
'                _DefaultValue = Value
'            End If
'        End Set
'    End Property

'    Public Property ValueIsNull As Boolean
'        Get
'            Return _ValueIsNull
'        End Get
'        Set(value As Boolean)
'            _ValueIsNull = value
'        End Set
'    End Property

'    Public Property TextDate As String
'        Get
'            Return _TextDate
'        End Get
'        Set(value As String)
'            _TextDate = value
'        End Set
'    End Property

'End Class

#End Region

#Region "OLD CODE"

'Imports System.ComponentModel
'Imports System.Drawing
'Imports System.Windows.Forms
'Imports System.Windows.Forms.VisualStyles

'Public Class CDateTimePicker
'    Inherits System.Windows.Forms.DateTimePicker
'    Private oldFormat As DateTimePickerFormat = DateTimePickerFormat.Short
'    Private oldCustomFormat As String = Nothing
'    Public IsNull As Boolean = False
'    Private _IsReadOnly As Boolean
'    Private _ReadOnlyDP As Boolean = True
'    Private _DefaultValue As Object
'    Private _IsMandatory As Boolean
'    Private _TextToSearch As String
'    Private _SearchPlace As Char
'    Private _IsNullable As Boolean
'    Private _SecurityKey As String
'    Private _backDisabledColor As Color
'    Private _isInternalValueChanging = False

'    Public Sub New()
'        MyBase.New()
'        DisplayOnly = False
'        CausesValidation = True
'        ValueIsNullable = True
'    End Sub

'    ' <summary>
'    ' The Date Value of the control (is Nullable, can be set to Nothing).
'    ' </summary>
'    ' <value></value>
'    ' <returns></returns>
'    ' <remarks></remarks>
'    Public Shadows Property Value() As Date?
'        Get
'            If Me.IsNull Then
'                If Me.ValueIsNullable Then
'                    Return Nothing
'                Else
'                    Me.IsNull = False
'                    Return Me.DefaultValue
'                End If
'            Else
'                Return MyBase.Value
'            End If
'        End Get
'        Set(ByVal newValue As Date?)
'            If newValue.HasValue Then
'                ' newValue is not null (nothing)
'                If Me.IsNull Then
'                    Me.Format = Me.oldFormat
'                    Me.CustomFormat = Me.oldCustomFormat
'                    Me.IsNull = False
'                End If
'                MyBase.Value = newValue.Value
'            Else
'                ' newValue is null (nothing)
'                If Me.ValueIsNullable Then
'                    If Not Me.IsNull Then
'                        Me.oldFormat = Me.Format
'                        Me.oldCustomFormat = Me.CustomFormat
'                    End If
'                    Me.IsNull = True
'                    Me.Format = DateTimePickerFormat.Custom
'                    Me.CustomFormat = " "
'                    ' don't set the value to null because it will error out, just retain the value
'                    ' anyway we flagged the value is null by the Me.IsNull property so we know that
'                    ' the value should be null.
'                Else
'                    ' Value is not nullable (so don't accept null values)
'                    If Me.IsNull Then
'                        Me.Format = Me.oldFormat
'                        Me.CustomFormat = Me.oldCustomFormat
'                        Me.IsNull = False
'                    End If
'                    MyBase.Value = Me.DefaultValue
'                End If
'            End If
'        End Set
'    End Property

'    ''' <summary>
'    ''' Allows the user to select a new date if the control is already null.
'    ''' </summary>
'    ''' <param name="eventargs"></param>
'    ''' <remarks></remarks>
'    Protected Overrides Sub OnCloseUp(ByVal eventargs As System.EventArgs)
'        If Control.MouseButtons = Windows.Forms.MouseButtons.None Then
'            If Me.IsNull Then
'                Me.Format = Me.oldFormat
'                Me.CustomFormat = Me.oldCustomFormat
'                Me.IsNull = False
'            End If
'        End If
'        MyBase.OnCloseUp(eventargs)
'    End Sub
'    'Protected Overrides Sub OnCloseUp(ByVal eventargs As System.EventArgs)
'    '    If Control.MouseButtons = Windows.Forms.MouseButtons.None Then
'    '        If Me.ValueIsNullable AndAlso Me.IsNull Then
'    '            Me.Format = Me.oldFormat
'    '            Me.CustomFormat = Me.oldCustomFormat
'    '            Me.IsNull = False
'    '        End If
'    '    End If
'    '    MyBase.OnCloseUp(eventargs)
'    'End Sub

'    ''' <summary>
'    ''' Overrides the base class implementation to allow the user to create a Null value by pressing the Delete key.
'    ''' </summary>
'    ''' <param name="e"></param>
'    ''' <remarks></remarks>
'    '''     Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
'    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
'        MyBase.OnKeyUp(e)
'        If e.KeyCode = Keys.Delete Then
'            Me.Value = Nothing
'        ElseIf IsNull And (e.KeyCode = Keys.Space OrElse Char.IsNumber(ChrW(e.KeyValue)) OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Left) Then
'            Me.Value = DateTime.Today
'        End If
'    End Sub
'    'Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
'    '    MyBase.OnKeyUp(e)
'    '    If Me.ValueIsNullable Then
'    '        If e.KeyCode = Keys.Delete Then
'    '            Me.Value = Nothing
'    '        ElseIf IsNull And (e.KeyCode = Keys.Space OrElse Char.IsNumber(ChrW(e.KeyValue)) OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Left) Then
'    '            Me.Value = DateTime.Today
'    '        End If
'    '    End If
'    'End Sub

'    Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
'        MyBase.OnGotFocus(e)
'        If IsNull Then
'            CustomFormat = "|"
'        End If
'    End Sub
'    'Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
'    '    MyBase.OnGotFocus(e)
'    '    If Me.ValueIsNullable AndAlso IsNull Then
'    '        CustomFormat = "|"
'    '    End If
'    'End Sub

'    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
'        If IsNull Then
'            CustomFormat = " "
'        End If
'    End Sub

'    'Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
'    '    If Me.ValueIsNullable AndAlso IsNull Then
'    '        CustomFormat = " "
'    '    End If
'    'End Sub

'    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
'        MyBase.OnKeyDown(e)
'        If e.KeyCode = Keys.Delete Then
'            Me.Value = Nothing
'        ElseIf IsNull Then
'            _isInternalValueChanging = True

'            If e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Left Then
'                Me.Value = DateTime.Today
'            ElseIf (Char.IsNumber(ChrW(e.KeyValue)) AndAlso e.KeyValue <> 48) OrElse (e.KeyValue >= 97 AndAlso e.KeyValue <= 105) Then
'                Dim typedDigit As Integer = 1

'                If e.KeyValue >= 97 AndAlso e.KeyValue <= 105 Then
'                    typedDigit = Integer.Parse((ChrW((e.KeyValue - 48))).ToString())
'                Else
'                    typedDigit = Integer.Parse((ChrW(e.KeyValue)).ToString())
'                End If

'                Me.Value = DateTime.Now
'                SendKeys.SendWait("{RIGHT}")
'                SendKeys.Send(typedDigit.ToString())
'            End If

'            _isInternalValueChanging = False
'        End If
'    End Sub

'    'Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
'    '    MyBase.OnKeyDown(e)
'    '    If Me.ValueIsNullable Then
'    '        If e.KeyCode = Keys.Delete Then
'    '            Me.Value = Nothing
'    '        ElseIf IsNull Then
'    '            _isInternalValueChanging = True

'    '            If e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Left Then
'    '                Me.Value = DateTime.Today
'    '            ElseIf (Char.IsNumber(ChrW(e.KeyValue)) AndAlso e.KeyValue <> 48) OrElse (e.KeyValue >= 97 AndAlso e.KeyValue <= 105) Then
'    '                Dim typedDigit As Integer = 1

'    '                If e.KeyValue >= 97 AndAlso e.KeyValue <= 105 Then
'    '                    typedDigit = Integer.Parse((ChrW((e.KeyValue - 48))).ToString())
'    '                Else
'    '                    typedDigit = Integer.Parse((ChrW(e.KeyValue)).ToString())
'    '                End If

'    '                Me.Value = DateTime.Now
'    '                SendKeys.SendWait("{RIGHT}")
'    '                SendKeys.Send(typedDigit.ToString())
'    '            End If

'    '            _isInternalValueChanging = False
'    '        End If
'    '    End If
'    'End Sub

'    <Bindable(True)>
'    <Category("Properties")>
'    <DefaultValue(GetType(Boolean))>
'    <Description("Set to True to specify that this control is read only.")>
'    <Browsable(True)>
'    Public Property DisplayOnly() As Boolean
'        Get
'            Return _IsReadOnly
'        End Get
'        Set(ByVal value As Boolean)
'            _IsReadOnly = value
'        End Set
'    End Property

'    <Bindable(True)>
'    <Category("Properties")>
'    <DefaultValue(GetType(Boolean))>
'    <Description("Set to True to specify that this control is read only.")>
'    <Browsable(True)>
'    Public Property ReadOnlyDP() As Boolean
'        Get
'            Return _ReadOnlyDP
'        End Get
'        Set(ByVal value As Boolean)
'            _ReadOnlyDP = value
'        End Set
'    End Property

'    <Bindable(True)>
'    <Category("Properties")>
'    <DefaultValue(GetType(Boolean))>
'    <Description("Set to True to specify that this control is mandatory.")>
'    <Browsable(True)>
'    Public Property ValueIsMandatory() As Boolean
'        Get
'            Return _IsMandatory
'        End Get
'        Set(ByVal value As Boolean)
'            _IsMandatory = value
'        End Set
'    End Property

'    <Bindable(True)>
'    <Category("Properties")>
'    <DefaultValue(GetType(Boolean))>
'    <Description("Security Key to use for this control.")>
'    <Browsable(True)>
'    Public Property SecurityKey() As String
'        Get
'            Return _SecurityKey
'        End Get
'        Set(ByVal value As String)
'            _SecurityKey = value
'        End Set
'    End Property

'    Public Property ValueIsNullable() As Boolean
'        Get
'            Return _IsNullable
'        End Get
'        Set(ByVal value As Boolean)
'            _IsNullable = value
'        End Set
'    End Property

'    Public Property DefaultValue() As Object
'        Get
'            Return _DefaultValue
'        End Get
'        Set(ByVal Value As Object)
'            If Value Is Nothing AndAlso Me.ValueIsNullable Then
'                _DefaultValue = Nothing
'            ElseIf Value Is Nothing Then
'                ' if it passes here Me.ValueIsNullable is False
'                ' so just assigned Today's date as the default value
'                _DefaultValue = Today()
'            Else ' value is not Null ('nothing')
'                _DefaultValue = Value
'            End If
'        End Set
'    End Property

'End Class

'Imports System.ComponentModel
'Imports System.Drawing
'Imports System.Windows.Forms
'Imports System.Windows.Forms.VisualStyles

'Public Class CDateTimePicker
'    Inherits System.Windows.Forms.DateTimePicker
'    Private oldFormat As DateTimePickerFormat = DateTimePickerFormat.Short
'    Private oldCustomFormat As String = Nothing
'    Public IsNull As Boolean = False
'    Private _IsReadOnly As Boolean
'    Private _ReadOnlyDP As Boolean = True
'    Private _DefaultValue As Object
'    Private _IsMandatory As Boolean
'    Private _TextToSearch As String
'    Private _SearchPlace As Char
'    Private _IsNullable As Boolean
'    Private _SecurityKey As String
'    Private _backDisabledColor As Color
'    Private _isInternalValueChanging = False

'    Public Sub New()
'        MyBase.New()
'        DisplayOnly = False
'        CausesValidation = True
'        ValueIsNullable = True
'    End Sub

'    ''' <summary>
'    ''' The Date Value of the control (is Nullable, can be set to Nothing).
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    'Public Shadows Property Value() As Date?
'    '    Get
'    '        If Me.ValueIsNullable AndAlso Me.IsNull Then
'    '            Return Nothing
'    '        Else
'    '            Return MyBase.Value
'    '        End If
'    '    End Get
'    '    Set(ByVal newValue As Date?)
'    '        If Not Me.ValueIsNullable Then
'    '            MyBase.Value = If(newValue.HasValue, newValue.Value, newValue.Value) 'Me.DefaultValue)
'    '        Else
'    '            If Not newValue.HasValue Then
'    '                If Not Me.IsNull Then
'    '                    Me.oldFormat = Me.Format
'    '                    Me.oldCustomFormat = Me.CustomFormat
'    '                    Me.IsNull = True
'    '                End If
'    '                Me.Format = DateTimePickerFormat.Custom
'    '                Me.CustomFormat = " "
'    '            Else
'    '                If Me.IsNull Then
'    '                    Me.Format = Me.oldFormat
'    '                    Me.CustomFormat = Me.oldCustomFormat
'    '                    Me.IsNull = False
'    '                End If
'    '                MyBase.Value = newValue.Value
'    '            End If
'    '        End If
'    '    End Set
'    'End Property
'    Public Shadows Property Value() As Date?
'        Get
'            If Me.IsNull Then
'                Return Nothing
'            Else
'                Return MyBase.Value
'            End If
'        End Get
'        Set(ByVal newValue As Date?)
'            If Not newValue.HasValue Then
'                If Not Me.IsNull Then
'                    Me.oldFormat = Me.Format
'                    Me.oldCustomFormat = Me.CustomFormat
'                    Me.IsNull = True
'                End If
'                Me.Format = DateTimePickerFormat.Custom
'                Me.CustomFormat = " "
'            Else
'                If Me.IsNull Then
'                    Me.Format = Me.oldFormat
'                    Me.CustomFormat = Me.oldCustomFormat
'                    Me.IsNull = False
'                End If
'                MyBase.Value = newValue.Value
'            End If
'        End Set
'    End Property

'    ''' <summary>
'    ''' Allows the user to select a new date if the control is already null.
'    ''' </summary>
'    ''' <param name="eventargs"></param>
'    ''' <remarks></remarks>
'    Protected Overrides Sub OnCloseUp(ByVal eventargs As System.EventArgs)
'        If Control.MouseButtons = Windows.Forms.MouseButtons.None Then
'            If Me.IsNull Then
'                Me.Format = Me.oldFormat
'                Me.CustomFormat = Me.oldCustomFormat
'                Me.IsNull = False
'            End If
'        End If
'        MyBase.OnCloseUp(eventargs)
'    End Sub
'    'Protected Overrides Sub OnCloseUp(ByVal eventargs As System.EventArgs)
'    '    If Control.MouseButtons = Windows.Forms.MouseButtons.None Then
'    '        If Me.ValueIsNullable AndAlso Me.IsNull Then
'    '            Me.Format = Me.oldFormat
'    '            Me.CustomFormat = Me.oldCustomFormat
'    '            Me.IsNull = False
'    '        End If
'    '    End If
'    '    MyBase.OnCloseUp(eventargs)
'    'End Sub

'    ''' <summary>
'    ''' Overrides the base class implementation to allow the user to create a Null value by pressing the Delete key.
'    ''' </summary>
'    ''' <param name="e"></param>
'    ''' <remarks></remarks>
'    '''     Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
'    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
'        MyBase.OnKeyUp(e)
'        If e.KeyCode = Keys.Delete Then
'            Me.Value = Nothing
'        ElseIf IsNull And (e.KeyCode = Keys.Space OrElse Char.IsNumber(ChrW(e.KeyValue)) OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Left) Then
'            Me.Value = DateTime.Today
'        End If
'    End Sub
'    'Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
'    '    MyBase.OnKeyUp(e)
'    '    If Me.ValueIsNullable Then
'    '        If e.KeyCode = Keys.Delete Then
'    '            Me.Value = Nothing
'    '        ElseIf IsNull And (e.KeyCode = Keys.Space OrElse Char.IsNumber(ChrW(e.KeyValue)) OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Left) Then
'    '            Me.Value = DateTime.Today
'    '        End If
'    '    End If
'    'End Sub

'    Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
'        MyBase.OnGotFocus(e)
'        If IsNull Then
'            CustomFormat = "|"
'        End If
'    End Sub
'    'Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
'    '    MyBase.OnGotFocus(e)
'    '    If Me.ValueIsNullable AndAlso IsNull Then
'    '        CustomFormat = "|"
'    '    End If
'    'End Sub

'    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
'        If IsNull Then
'            CustomFormat = " "
'        End If
'    End Sub

'    'Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
'    '    If Me.ValueIsNullable AndAlso IsNull Then
'    '        CustomFormat = " "
'    '    End If
'    'End Sub

'    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
'        MyBase.OnKeyDown(e)
'        If e.KeyCode = Keys.Delete Then
'            Me.Value = Nothing
'        ElseIf IsNull Then
'            _isInternalValueChanging = True

'            If e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Left Then
'                Me.Value = DateTime.Today
'            ElseIf (Char.IsNumber(ChrW(e.KeyValue)) AndAlso e.KeyValue <> 48) OrElse (e.KeyValue >= 97 AndAlso e.KeyValue <= 105) Then
'                Dim typedDigit As Integer = 1

'                If e.KeyValue >= 97 AndAlso e.KeyValue <= 105 Then
'                    typedDigit = Integer.Parse((ChrW((e.KeyValue - 48))).ToString())
'                Else
'                    typedDigit = Integer.Parse((ChrW(e.KeyValue)).ToString())
'                End If

'                Me.Value = DateTime.Now
'                SendKeys.SendWait("{RIGHT}")
'                SendKeys.Send(typedDigit.ToString())
'            End If

'            _isInternalValueChanging = False
'        End If
'    End Sub

'    'Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
'    '    MyBase.OnKeyDown(e)
'    '    If Me.ValueIsNullable Then
'    '        If e.KeyCode = Keys.Delete Then
'    '            Me.Value = Nothing
'    '        ElseIf IsNull Then
'    '            _isInternalValueChanging = True

'    '            If e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Left Then
'    '                Me.Value = DateTime.Today
'    '            ElseIf (Char.IsNumber(ChrW(e.KeyValue)) AndAlso e.KeyValue <> 48) OrElse (e.KeyValue >= 97 AndAlso e.KeyValue <= 105) Then
'    '                Dim typedDigit As Integer = 1

'    '                If e.KeyValue >= 97 AndAlso e.KeyValue <= 105 Then
'    '                    typedDigit = Integer.Parse((ChrW((e.KeyValue - 48))).ToString())
'    '                Else
'    '                    typedDigit = Integer.Parse((ChrW(e.KeyValue)).ToString())
'    '                End If

'    '                Me.Value = DateTime.Now
'    '                SendKeys.SendWait("{RIGHT}")
'    '                SendKeys.Send(typedDigit.ToString())
'    '            End If

'    '            _isInternalValueChanging = False
'    '        End If
'    '    End If
'    'End Sub

'    <Bindable(True)>
'    <Category("Properties")>
'    <DefaultValue(GetType(Boolean))>
'    <Description("Set to True to specify that this control is read only.")>
'    <Browsable(True)>
'    Public Property DisplayOnly() As Boolean
'        Get
'            Return _IsReadOnly
'        End Get
'        Set(ByVal value As Boolean)
'            _IsReadOnly = value
'        End Set
'    End Property

'    <Bindable(True)>
'    <Category("Properties")>
'    <DefaultValue(GetType(Boolean))>
'    <Description("Set to True to specify that this control is read only.")>
'    <Browsable(True)>
'    Public Property ReadOnlyDP() As Boolean
'        Get
'            Return _ReadOnlyDP
'        End Get
'        Set(ByVal value As Boolean)
'            _ReadOnlyDP = value
'        End Set
'    End Property

'    <Bindable(True)>
'    <Category("Properties")>
'    <DefaultValue(GetType(Boolean))>
'    <Description("Set to True to specify that this control is mandatory.")>
'    <Browsable(True)>
'    Public Property ValueIsMandatory() As Boolean
'        Get
'            Return _IsMandatory
'        End Get
'        Set(ByVal value As Boolean)
'            _IsMandatory = value
'        End Set
'    End Property

'    <Bindable(True)>
'    <Category("Properties")>
'    <DefaultValue(GetType(Boolean))>
'    <Description("Security Key to use for this control.")>
'    <Browsable(True)>
'    Public Property SecurityKey() As String
'        Get
'            Return _SecurityKey
'        End Get
'        Set(ByVal value As String)
'            _SecurityKey = value
'        End Set
'    End Property

'    Public Property ValueIsNullable() As Boolean
'        Get
'            Return _IsNullable
'        End Get
'        Set(ByVal value As Boolean)
'            _IsNullable = value
'        End Set
'    End Property

'    'Public Property DefaultValue() As Object
'    '    Get
'    '        Return _DefaultValue
'    '    End Get
'    '    Set(ByVal Value As Object)
'    '        If Me.ValueIsNullable Then
'    '            _DefaultValue = Value
'    '        Else
'    '            If Value Is Nothing Then
'    '                _DefaultValue = Today()
'    '            Else
'    '                _DefaultValue = Value
'    '            End If
'    '        End If
'    '    End Set
'    'End Property

'End Class

#End Region